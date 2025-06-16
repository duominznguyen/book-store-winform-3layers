USE master
GO
DROP DATABASE IF EXISTS BookstoreDB_ver1
GO

-- Create database
CREATE DATABASE BookstoreDB_ver1;
GO

-- Use the database
USE BookstoreDB_ver1;
GO

-- Create BookCategories table
CREATE TABLE BookCategories (
    CategoryID INT PRIMARY KEY,
    CategoryName NVARCHAR(50)
);
GO

-- Create Books table
CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title NVARCHAR(100),
    Author NVARCHAR(50),
    Publisher NVARCHAR(100),
    Price DECIMAL(10, 2),
    Description NVARCHAR(100),
    Quantity INT,
    CategoryID INT FOREIGN KEY REFERENCES BookCategories(CategoryID)
);
GO

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);
GO

-- Create Employees table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(255),
    Role NVARCHAR(50),
);
GO

CREATE TABLE Accounts (
    Username VARCHAR(50) UNIQUE,
    Password VARCHAR(100),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    PRIMARY KEY (Username, EmployeeID)
)


-- Create Suppliers table
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);
GO


-- Create BookPurchases table
CREATE TABLE Purchases (
    PurchaseID INT PRIMARY KEY,
    PurchaseDate DATETIME,
    SupplierID INT FOREIGN KEY REFERENCES Suppliers(SupplierID),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    TotalAmount DECIMAL(10,2) DEFAULT 0
);
GO

-- Create PurchaseDetails table
CREATE TABLE PurchaseDetails (
    PurchaseDetailID INT IDENTITY(1,1) PRIMARY KEY,
    PurchaseID INT FOREIGN KEY REFERENCES Purchases(PurchaseID),
    BookID INT FOREIGN KEY REFERENCES Books(BookID),
    Quantity INT,
    PurchasePrice DECIMAL(10, 2)
);
GO

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATETIME,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    TotalAmount DECIMAL(10,2) DEFAULT 0
);
GO

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    BookID INT FOREIGN KEY REFERENCES Books(BookID),
    Quantity INT,
    SellPrice DECIMAL(10, 2)
);
GO




DROP TRIGGER IF EXISTS trg_DeleteBookCategory
GO
CREATE TRIGGER trg_DeleteBookCategory
ON BookCategories
INSTEAD OF DELETE
AS
BEGIN
    -- Set NULL trong bảng Books
    UPDATE Books
    SET CategoryID = NULL
    WHERE CategoryID IN (SELECT CategoryID FROM DELETED);

    -- Xóa bản ghi trong bảng BookCategories
    DELETE FROM BookCategories
    WHERE CategoryID IN (SELECT CategoryID FROM DELETED);
END;
GO



DROP TRIGGER IF EXISTS trg_DeleteBook;
GO
CREATE TRIGGER trg_DeleteBook
ON Books
INSTEAD OF DELETE
AS
BEGIN
    -- Set NULL trong bảng OrderDetails
    UPDATE OrderDetails
    SET BookID = NULL
    WHERE BookID IN (SELECT BookID FROM DELETED);

    -- Set NULL trong bảng PurchaseDetails
    UPDATE PurchaseDetails
    SET BookID = NULL
    WHERE BookID IN (SELECT BookID FROM DELETED);

    -- Xóa bản ghi trong bảng Books
    DELETE FROM Books
    WHERE BookID IN (SELECT BookID FROM DELETED);
END;
GO



DROP TRIGGER IF EXISTS trg_DeleteEmployee;
GO
CREATE TRIGGER trg_DeleteEmployee
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    -- Set NULL trong bảng Orders
    UPDATE Orders
    SET EmployeeID = NULL
    WHERE EmployeeID IN (SELECT EmployeeID FROM DELETED);

    -- Set NULL trong bảng BookPurchases
    UPDATE Purchases
    SET EmployeeID = NULL
    WHERE EmployeeID IN (SELECT EmployeeID FROM DELETED);

    -- Set NULL trong bảng Accounts
    DELETE FROM Accounts
    WHERE EmployeeID IN (SELECT EmployeeID FROM DELETED);

    -- Xóa bản ghi trong bảng Employees
    DELETE FROM Employees
    WHERE EmployeeID IN (SELECT EmployeeID FROM DELETED);

END;
GO


DROP TRIGGER IF EXISTS trg_DeleteCustomer;
GO
CREATE TRIGGER trg_DeleteCustomer
ON Customers
INSTEAD OF DELETE
AS
BEGIN
    -- Set NULL trong bảng Orders
    UPDATE Orders
    SET CustomerID = NULL
    WHERE CustomerID IN (SELECT CustomerID FROM DELETED);

    -- Xóa bản ghi trong bảng Customers
    DELETE FROM Customers
    WHERE CustomerID IN (SELECT CustomerID FROM DELETED);
END;
GO



DROP TRIGGER IF EXISTS trg_DeleteSupplier
GO
CREATE TRIGGER trg_DeleteSupplier
ON Suppliers
INSTEAD OF DELETE
AS
BEGIN
    -- Set NULL trong bảng BookPurchases
    UPDATE Purchases
    SET SupplierID = NULL
    WHERE SupplierID IN (SELECT SupplierID FROM DELETED);

    -- Xóa bản ghi trong bảng Suppliers
    DELETE FROM Suppliers
    WHERE SupplierID IN (SELECT SupplierID FROM DELETED);
END;
GO


DROP TRIGGER IF EXISTS trg_DeleteOrders
GO
CREATE TRIGGER trg_DeleteOrders
ON Orders
INSTEAD OF DELETE
AS
BEGIN
    -- Delete related records in OrderDetails first
    DELETE FROM OrderDetails
    WHERE OrderID IN (SELECT OrderID FROM DELETED);

    -- Now delete the records in Orders
    DELETE FROM Orders
    WHERE OrderID IN (SELECT OrderID FROM DELETED);
END
GO

DROP TRIGGER IF EXISTS trg_DeletePurchases
GO
CREATE TRIGGER trg_DeletePurchases
ON Purchases
INSTEAD OF DELETE
AS
BEGIN
    -- Delete related records in PurchaseDetails first
    DELETE FROM PurchaseDetails
    WHERE PurchaseID IN (SELECT PurchaseID FROM DELETED);

    -- Now delete the records in Purchases
    DELETE FROM Purchases
    WHERE PurchaseID IN (SELECT PurchaseID FROM DELETED);
END
GO




-- DROP TRIGGER IF EXISTS trg_OrderDetailsChange
-- GO
CREATE TRIGGER trg_OrderDetailsChange
ON OrderDetails
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -------------------------------
    -- Xử lý khi DELETE
    -------------------------------
    IF EXISTS (SELECT * FROM DELETED) AND NOT EXISTS (SELECT * FROM INSERTED)
    BEGIN
        -- Cộng lại số lượng sách (khôi phục)
        UPDATE b
        SET b.Quantity = b.Quantity + d.TotalQuantity
        FROM Books b
        JOIN (
            SELECT BookID, SUM(Quantity) AS TotalQuantity
            FROM DELETED
            GROUP BY BookID
        ) d ON b.BookID = d.BookID;

        -- Trừ tổng tiền đơn hàng
        UPDATE o
        SET o.TotalAmount = ISNULL(o.TotalAmount, 0) - d.TotalAmount
        FROM Orders o
        JOIN (
            SELECT OrderID, SUM(ISNULL(Quantity,0) * ISNULL(SellPrice,0)) AS TotalAmount
            FROM DELETED
            GROUP BY OrderID
        ) d ON o.OrderID = d.OrderID;
    END

    -------------------------------
    -- Xử lý khi INSERT
    -------------------------------
    IF EXISTS (SELECT * FROM INSERTED) AND NOT EXISTS (SELECT * FROM DELETED)
    BEGIN
        -- Trừ số lượng sách
        UPDATE b
        SET b.Quantity = b.Quantity - i.TotalQuantity
        FROM Books b
        JOIN (
            SELECT BookID, SUM(Quantity) AS TotalQuantity
            FROM INSERTED
            GROUP BY BookID
        ) i ON b.BookID = i.BookID;

        -- Cộng tổng tiền đơn hàng
        UPDATE o
        SET o.TotalAmount = ISNULL(o.TotalAmount, 0) + i.TotalAmount
        FROM Orders o
        JOIN (
            SELECT OrderID, SUM(ISNULL(Quantity,0) * ISNULL(SellPrice,0)) AS TotalAmount
            FROM INSERTED
            GROUP BY OrderID
        ) i ON o.OrderID = i.OrderID;
    END

    -------------------------------
    -- Xử lý khi UPDATE
    -------------------------------
    IF EXISTS (SELECT * FROM INSERTED) AND EXISTS (SELECT * FROM DELETED)
    BEGIN
        -- Khôi phục số lượng cũ
        UPDATE b
        SET b.Quantity = b.Quantity + d.TotalQuantity
        FROM Books b
        JOIN (
            SELECT BookID, SUM(Quantity) AS TotalQuantity
            FROM DELETED
            GROUP BY BookID
        ) d ON b.BookID = d.BookID;

        -- Trừ số lượng mới
        UPDATE b
        SET b.Quantity = b.Quantity - i.TotalQuantity
        FROM Books b
        JOIN (
            SELECT BookID, SUM(Quantity) AS TotalQuantity
            FROM INSERTED
            GROUP BY BookID
        ) i ON b.BookID = i.BookID;

        -- Trừ tiền cũ
        UPDATE o
        SET o.TotalAmount = ISNULL(o.TotalAmount, 0) - d.TotalAmount
        FROM Orders o
        JOIN (
            SELECT OrderID, SUM(ISNULL(Quantity,0) * ISNULL(SellPrice,0)) AS TotalAmount
            FROM DELETED
            GROUP BY OrderID
        ) d ON o.OrderID = d.OrderID;

        -- Cộng tiền mới
        UPDATE o
        SET o.TotalAmount = ISNULL(o.TotalAmount, 0) + i.TotalAmount
        FROM Orders o
        JOIN (
            SELECT OrderID, SUM(ISNULL(Quantity,0) * ISNULL(SellPrice,0)) AS TotalAmount
            FROM INSERTED
            GROUP BY OrderID
        ) i ON o.OrderID = i.OrderID;
    END
END;
GO





-- DROP TRIGGER IF EXISTS trg_OrderDetailsChange
-- GO

-- CREATE TRIGGER trg_OrderDetailsChange
-- ON OrderDetails
-- AFTER INSERT, DELETE, UPDATE
-- AS
-- BEGIN
--     -- Xử lý khi xóa chi tiết đơn hàng
--     IF EXISTS (SELECT * FROM DELETED) AND NOT EXISTS (SELECT * FROM INSERTED)
--     BEGIN
--         -- Khôi phục số lượng sản phẩm cũ
--         UPDATE Books
--         SET Quantity = b.Quantity + d.Quantity
--         FROM Books b
--         INNER JOIN DELETED d ON b.BookID = d.BookID;
--     END

--     -- Xử lý khi thêm chi tiết đơn hàng
--     IF EXISTS (SELECT * FROM INSERTED) AND NOT EXISTS (SELECT * FROM DELETED)
--     BEGIN
--         -- Trừ số lượng sản phẩm mới
--         UPDATE Books
--         SET Quantity = b.Quantity - i.Quantity
--         FROM Books b
--         INNER JOIN INSERTED i ON b.BookID = i.BookID;
--     END

--     -- Xử lý khi cập nhật chi tiết đơn hàng
--     IF EXISTS (SELECT * FROM INSERTED) AND EXISTS (SELECT * FROM DELETED)
--     BEGIN
--         -- Khôi phục số lượng sản phẩm cũ
--         UPDATE Books
--         SET Quantity = b.Quantity + d.Quantity - i.Quantity
--         FROM Books b
--         INNER JOIN DELETED d ON b.BookID = d.BookID
--         INNER JOIN INSERTED i ON b.BookID = i.BookID;
--     END
-- END;
-- GO


CREATE TRIGGER trg_PurchaseDetailsChange
ON PurchaseDetails
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -------------------------------
    -- Xử lý khi DELETE
    -------------------------------
    IF EXISTS (SELECT 1 FROM DELETED) AND NOT EXISTS (SELECT 1 FROM INSERTED)
    BEGIN
        -- Trừ số lượng sản phẩm
        UPDATE b
        SET b.Quantity = b.Quantity - d.TotalQuantity
        FROM Books b
        JOIN (
            SELECT BookID, SUM(Quantity) AS TotalQuantity
            FROM DELETED
            GROUP BY BookID
        ) d ON b.BookID = d.BookID;

        -- Trừ tổng tiền đơn hàng
        UPDATE p
        SET p.TotalAmount = ISNULL(p.TotalAmount, 0) - d.TotalAmount
        FROM Purchases p
        JOIN (
            SELECT PurchaseID, SUM(ISNULL(Quantity,0) * ISNULL(PurchasePrice,0)) AS TotalAmount
            FROM DELETED
            GROUP BY PurchaseID
        ) d ON p.PurchaseID = d.PurchaseID;
    END

    -------------------------------
    -- Xử lý khi INSERT
    -------------------------------
    IF EXISTS (SELECT 1 FROM INSERTED) AND NOT EXISTS (SELECT 1 FROM DELETED)
    BEGIN
        -- Cộng số lượng sản phẩm
        UPDATE b
        SET b.Quantity = b.Quantity + i.TotalQuantity
        FROM Books b
        JOIN (
            SELECT BookID, SUM(Quantity) AS TotalQuantity
            FROM INSERTED
            GROUP BY BookID
        ) i ON b.BookID = i.BookID;

        -- Cộng tổng tiền đơn hàng
        UPDATE p
        SET p.TotalAmount = ISNULL(p.TotalAmount, 0) + i.TotalAmount
        FROM Purchases p
        JOIN (
            SELECT PurchaseID, SUM(ISNULL(Quantity,0) * ISNULL(PurchasePrice,0)) AS TotalAmount
            FROM INSERTED
            GROUP BY PurchaseID
        ) i ON p.PurchaseID = i.PurchaseID;
    END

    -------------------------------
    -- Xử lý khi UPDATE
    -------------------------------
    IF EXISTS (SELECT 1 FROM INSERTED) AND EXISTS (SELECT 1 FROM DELETED)
    BEGIN
        -- Trừ dữ liệu cũ
        UPDATE b
        SET b.Quantity = b.Quantity - d.TotalQuantity
        FROM Books b
        JOIN (
            SELECT BookID, SUM(Quantity) AS TotalQuantity
            FROM DELETED
            GROUP BY BookID
        ) d ON b.BookID = d.BookID;

        -- Cộng dữ liệu mới
        UPDATE b
        SET b.Quantity = b.Quantity + i.TotalQuantity
        FROM Books b
        JOIN (
            SELECT BookID, SUM(Quantity) AS TotalQuantity
            FROM INSERTED
            GROUP BY BookID
        ) i ON b.BookID = i.BookID;

        -- Trừ tổng tiền cũ
        UPDATE p
        SET p.TotalAmount = ISNULL(p.TotalAmount, 0) - d.TotalAmount
        FROM Purchases p
        JOIN (
            SELECT PurchaseID, SUM(ISNULL(Quantity,0) * ISNULL(PurchasePrice,0)) AS TotalAmount
            FROM DELETED
            GROUP BY PurchaseID
        ) d ON p.PurchaseID = d.PurchaseID;

        -- Cộng tổng tiền mới
        UPDATE p
        SET p.TotalAmount = ISNULL(p.TotalAmount, 0) + i.TotalAmount
        FROM Purchases p
        JOIN (
            SELECT PurchaseID, SUM(ISNULL(Quantity,0) * ISNULL(PurchasePrice,0)) AS TotalAmount
            FROM INSERTED
            GROUP BY PurchaseID
        ) i ON p.PurchaseID = i.PurchaseID;
    END
END;








-- DROP TRIGGER IF EXISTS trg_PurchaseDetailsChange
-- GO
-- CREATE TRIGGER trg_PurchaseDetailsChange
-- ON PurchaseDetails
-- AFTER INSERT, DELETE, UPDATE
-- AS
-- BEGIN
--     -- Xử lý khi xóa chi tiết mua hàng
--     IF EXISTS (SELECT * FROM DELETED) AND NOT EXISTS (SELECT * FROM INSERTED)
--     BEGIN
--         -- Trừ số lượng sản phẩm cũ
--         UPDATE Books
--         SET Quantity = b.Quantity - d.Quantity
--         FROM Books b
--         INNER JOIN DELETED d ON b.BookID = d.BookID;

--         -- Xử lý total amount khi xóa 
--         UPDATE p
--         SET p.TotalAmount = p.TotalAmount - d.Quantity * d.PurchasePrice
--         FROM Purchases p
--         INNER JOIN DELETED d ON p.PurchaseID = d.PurchaseID;
--     END

--     -- Xử lý khi thêm chi tiết mua hàng
--     IF EXISTS (SELECT * FROM INSERTED) AND NOT EXISTS (SELECT * FROM DELETED)
--     BEGIN
--         -- Cộng số lượng sản phẩm mới
--         UPDATE Books
--         SET Quantity = b.Quantity + i.Quantity
--         FROM Books b
--         INNER JOIN INSERTED i ON b.BookID = i.BookID;


--         -- xử lý total amount khi thêm đơn hàng
--         UPDATE p
--         SET p.TotalAmount = p.TotalAmount + i.Quantity * i.PurchasePrice
--         FROM Purchases p
--         INNER JOIN INSERTED i ON p.PurchaseID = i.PurchaseID;

--     END

--     -- Xử lý khi cập nhật chi tiết mua hàng
--     IF EXISTS (SELECT * FROM INSERTED) AND EXISTS (SELECT * FROM DELETED)
--     BEGIN
--         -- Trừ số lượng sản phẩm cũ và cộng số lượng sản phẩm mới
--         UPDATE Books
--         SET Quantity = b.Quantity - d.Quantity + i.Quantity
--         FROM Books b
--         INNER JOIN DELETED d ON b.BookID = d.BookID
--         INNER JOIN INSERTED i ON b.BookID = i.BookID;

--         -- xử lý total amount khi cập nhật 
        
--     END
-- END;
-- GO

INSERT INTO BookCategories (CategoryID, CategoryName)
VALUES 
    (1, N'Tiểu thuyết'),
    (2, N'Phi hư cấu'),
    (3, N'Khoa học'),
    (4, N'Công nghệ'),
    (5, N'Tự truyện');
GO

-- Insert data into Books
INSERT INTO Books (BookID, Title, Author, Publisher, Price, Description, Quantity, CategoryID)
VALUES 
    (1, N'Truyện Kiều', N'Nguyễn Du', N'Nhà xuất bản Văn học', 120000, N'Tác phẩm kinh điển của văn học Việt Nam', 50, 1),
    (2, N'Những người khốn khổ', N'Victor Hugo', N'Nhà xuất bản Kim Đồng', 150000, N'Tiểu thuyết nổi tiếng thế giới', 30, 1),
    (3, N'Lược sử thời gian', N'Stephen Hawking', N'Nhà xuất bản Trẻ', 180000, N'Khám phá vũ trụ', 20, 3),
    (4, N'Mã sạch', N'Robert C. Martin', N'Nhà xuất bản Khoa học Kỹ thuật', 350000, N'Thực hành lập trình tốt', 40, 4),
    (5, N'Nhật ký Đặng Thùy Trâm', N'Đặng Thùy Trâm', N'Nhà xuất bản Hội Nhà văn', 90000, N'Câu chuyện về lòng yêu nước', 25, 5);
GO

-- Insert data into Customers
INSERT INTO Customers (CustomerID, Name, Email, Phone, Address)
VALUES 
    (1, N'Nguyễn Bình An', N'nguyenbinhan@example.com', N'0123456789', N'123 Đường Láng, Hà Nội'),
    (2, N'Trần Minh Khánh', N'tranminhkhanh@example.com', N'0987654321', N'456 Nguyễn Trãi, TP.HCM'),
    (3, N'Phạm Hồng Minh', N'phamhongminh@example.com', N'0345678901', N'789 Lê Lợi, Đà Nẵng'),
    (4, N'Lê Đức Thịnh', N'leducthinh@example.com', N'0567890123', N'101 Hai Bà Trưng, Huế'),
    (5, N'Trịnh Trần Phương Tắn', N'trinhtranphuongtan@example.com', N'0789012345', N'202 Đường Láng, Bến Tre');
GO

-- Insert data into Employees
INSERT INTO Employees (EmployeeID, Name, Email, Phone, Address, Role)
VALUES 
    (1, N'Nguyễn Thị Hoa', N'nguyenhoa@example.com', N'0123456789', N'123 Cầu Giấy, Hà Nội', N'Quản lý'),
    (2, N'Lê Minh Tùng', N'letung@example.com', N'0987654321', N'456 Tô Hiệu, TP.HCM', N'Nhân viên'),
    (3, N'Phan Anh Tuấn', N'phantuan@example.com', N'0345678901', N'789 Hoàng Hoa Thám, Đà Nẵng', N'Nhân viên'),
    (4, N'Vũ Thị Hồng', N'vuhong@example.com', N'0567890123', N'101 Lý Tự Trọng, Huế', N'Nhân viên'),
    (5, N'Hoàng Văn Long', N'hoanglong@example.com', N'0789012345', N'202 Phan Đình Phùng, Cần Thơ', N'Nhân viên');
GO

-- Insert data into Accounts
INSERT INTO Accounts (Username, Password, EmployeeID)
VALUES 
    ('log1', '123', 1),
    ('log2', '123', 2),
    ('log3', '123', 3),
    ('log4', '123', 4),
    ('log5', '123', 5);
GO

-- Insert data into Suppliers
INSERT INTO Suppliers (SupplierID, Name, Phone, Address)
VALUES 
    (1, N'Công ty Sách Việt', N'0987654321', N'500 Nguyễn Văn Cừ, Hà Nội'),
    (2, N'Nhà sách Tiến Đạt', N'0123456789', N'100 Lê Văn Sỹ, TP.HCM'),
    (3, N'Thế Giới Sách', N'0345678901', N'300 Trần Phú, Đà Nẵng'),
    (4, N'Nhà sách Hồng Hà', N'0567890123', N'400 Nguyễn Huệ, Huế'),
    (5, N'Sách và Cuộc Sống', N'0789012345', N'600 Phan Chu Trinh, Cần Thơ');
GO

-- Insert data into BookPurchases
INSERT INTO Purchases (PurchaseID, PurchaseDate, SupplierID, EmployeeID)
VALUES 
    (1, '2025-01-01 12:00:00', 1, 1),
    (2, '2025-01-02 12:00:01', 2, 2),
    (3, '2025-01-03 12:00:02', 3, 3),
    (4, '2025-01-04 12:01:00', 4, 4),
    (5, '2025-01-05 12:02:00', 5, 5);
GO

-- Insert data into PurchaseDetails
INSERT INTO PurchaseDetails (PurchaseID, BookID, Quantity, PurchasePrice)
VALUES 
    (1, 1, 10, 100000),
    (2, 2, 15, 140000),
    (3, 3, 20, 170000),
    (4, 4, 10, 320000),
    (5, 5, 25, 80000);
GO


INSERT INTO PurchaseDetails (PurchaseID, BookID, Quantity, PurchasePrice)
VALUES 
    (1, 2, 8, 135000),
    (1, 3, 12, 165000),
    (2, 1, 10, 95000),
    (2, 4, 7, 310000),
    (3, 5, 15, 85000),
    (3, 2, 10, 138000),
    (4, 1, 5, 98000),
    (4, 3, 8, 168000),
    (5, 2, 20, 130000),
    (5, 4, 6, 325000);
GO

-- Insert data into Orders
INSERT INTO Orders (OrderID, OrderDate, CustomerID, EmployeeID)
VALUES 
    (1, '2025-01-12 12:00:00', 1, 1),
    (2, '2025-01-12 12:00:01', 2, 2),
    (3, '2025-01-12 13:00:02', 3, 3),
    (4, '2025-01-12 13:01:00', 4, 4),
    (5, '2025-01-12 13:02:00', 5, 5),
    (6, '2025-01-12 13:00:00', 1, 1),
    (7, '2025-01-12 13:00:01', 2, 2),
    (8, '2025-01-12 13:00:02', 3, 3),
    (9, '2025-01-12 13:01:00', 4, 4),
    (10, '2025-01-13 14:02:00', 5, 5),
    (11, '2025-01-13 14:00:00', 1, 1),
    (12, '2025-01-14 20:00:01', 2, 2),
    (13, '2025-01-14 20:00:02', 3, 3),
    (14, '2025-01-15 21:01:00', 4, 4),
    (15, '2025-01-24 21:02:00', 5, 5),
    (16, '2025-03-24 12:00:00', 1, 1),
    (17, '2025-03-24 12:00:01', 2, 2),
    (18, '2025-03-24 12:00:02', 3, 3),
    (19, '2025-04-24 12:01:00', 4, 4),
    (20, '2025-04-24 12:02:00', 5, 5),
    (21, '2025-04-24 12:00:00', 1, 1),
    (22, '2025-04-24 12:00:01', 2, 2),
    (23, '2025-04-24 12:00:02', 3, 3),
    (24, '2025-04-24 12:01:00', 4, 4),
    (25, '2025-04-24 12:02:00', 5, 5),
    (26, '2025-05-24 12:00:00', 1, 1),
    (27, '2025-05-24 12:00:01', 2, 2),
    (28, '2025-05-24 12:00:02', 3, 3),
    (29, '2025-05-24 12:01:00', 4, 4),
    (30, '2025-05-24 12:02:00', 5, 5);
GO

-- Insert data into OrderDetails
INSERT INTO OrderDetails (OrderID, BookID, Quantity, SellPrice)
VALUES 
    (1, 1, 2, 120000),
    (2, 2, 1, 150000),
    (3, 3, 3, 180000),
    (4, 4, 4, 350000),
    (5, 5, 1, 90000);
GO 

-- Insert data into OrderDetails (từ bản ghi 6 đến 50)
INSERT INTO OrderDetails (OrderID, BookID, Quantity, SellPrice)
VALUES 
    (6, 1, 2, 110000),
    (6, 2, 1, 130000),
    (7, 3, 1, 160000),
    (8, 4, 2, 340000),
    (9, 5, 1, 95000),
    (10, 1, 3, 125000),
    (11, 2, 2, 155000),
    (12, 3, 4, 185000),
    (13, 4, 1, 360000),
    (14, 5, 2, 88000),
    (15, 1, 1, 120000),
    (16, 2, 2, 145000),
    (17, 3, 3, 170000),
    (18, 4, 4, 340000),
    (19, 5, 1, 91000),
    (20, 1, 2, 130000),
    (21, 2, 3, 140000),
    (22, 3, 1, 160000),
    (23, 4, 2, 355000),
    (24, 5, 1, 97000),
    (25, 1, 3, 115000),
    (26, 2, 2, 152000),
    (27, 3, 4, 190000),
    (28, 4, 1, 345000),
    (29, 5, 2, 94000),
    (30, 1, 1, 123000),
    (6, 3, 2, 175000),
    (7, 4, 3, 350000),
    (8, 5, 1, 92000),
    (9, 1, 2, 118000),
    (10, 2, 2, 149000),
    (11, 3, 3, 172000),
    (12, 4, 1, 365000),
    (13, 5, 2, 93000),
    (14, 1, 1, 121000),
    (15, 2, 2, 148000),
    (16, 3, 4, 185000),
    (17, 4, 1, 335000),
    (18, 5, 2, 91000),
    (19, 1, 2, 119000),
    (20, 2, 3, 151000),
    (21, 3, 1, 180000),
    (22, 4, 2, 348000),
    (23, 5, 1, 89000),
    (24, 1, 3, 112000),
    (25, 2, 2, 147000),
    (26, 3, 4, 176000),
    (27, 4, 1, 355000),
    (28, 5, 2, 95000),
    (29, 1, 1, 126000),
    (30, 2, 2, 153000);
GO


SELECT * FROM BookCategories;
SELECT * FROM Books;
SELECT * FROM Customers;
SELECT * FROM Employees;
SELECT * FROM Accounts;
SELECT * FROM Suppliers;
SELECT * FROM Purchases;
SELECT * FROM PurchaseDetails;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;



DELETE FROM OrderDetails;
DELETE FROM Orders;
DELETE FROM PurchaseDetails;
DELETE FROM Purchases;
DELETE FROM Suppliers;
DELETE FROM Accounts;
DELETE FROM Employees;
DELETE FROM Customers;
DELETE FROM Books;
DELETE FROM BookCategories;


DROP PROCEDURE IF EXISTS sp_GetPurchaseReport
GO
CREATE PROCEDURE sp_GetPurchaseReport
    @PurchaseID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Khai báo biến lưu thông tin đơn mua
    DECLARE 
        @PurchaseDate DATE,
        @EmployeeID INT,
        @EmployeeName NVARCHAR(100),
        @SupplierID INT,
        @SupplierName NVARCHAR(100),
        @TotalAmount MONEY;

    -- Lấy thông tin đơn mua từ bảng Purchases
    SELECT 
        @PurchaseDate = p.PurchaseDate,
        @EmployeeID = e.EmployeeID,
        @EmployeeName = e.Name,
        @SupplierID = s.SupplierID,
        @SupplierName = s.Name,
        @TotalAmount = p.TotalAmount
    FROM Purchases p
    INNER JOIN Employees e ON p.EmployeeID = e.EmployeeID
    INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
    WHERE p.PurchaseID = @PurchaseID;

    -- Trả về chi tiết đơn mua kèm thông tin chung
    SELECT 
        @PurchaseID AS PurchaseID,
        @PurchaseDate AS PurchaseDate,
        @EmployeeID AS EmployeeID,
        @EmployeeName AS EmployeeName,
        @SupplierID AS SupplierID,
        @SupplierName AS SupplierName,
        pd.BookID,
        b.Title,
        SUM(pd.Quantity) AS Quantity,
        pd.PurchasePrice,
        SUM(pd.Quantity * pd.PurchasePrice) AS Total,
        @TotalAmount AS TotalAmount
    FROM PurchaseDetails pd
    INNER JOIN Books b ON pd.BookID = b.BookID
    WHERE pd.PurchaseID = @PurchaseID
    GROUP BY pd.BookID, b.Title, pd.PurchasePrice;
END
GO


-- -- test script
-- EXEC sp_GetPurchaseReport @PurchaseID = 3
-- SELECT * FROM PurchaseDetails WHERE PurchaseID = 3




DROP PROC IF EXISTS sp_GetOrderReport
GO
CREATE PROCEDURE sp_GetOrderReport
    @OrderID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Khai báo biến lưu thông tin đơn hàng
    DECLARE 
        @OrderDate DATE,
        @EmployeeID INT,
        @EmployeeName NVARCHAR(100),
        @CustomerID INT,
        @CustomerName NVARCHAR(100),
        @TotalAmount MONEY;

    -- Lấy thông tin đơn hàng từ bảng Orders
    SELECT 
        @OrderDate = o.OrderDate,
        @EmployeeID = e.EmployeeID,
        @EmployeeName = e.Name,
        @CustomerID = c.CustomerID,
        @CustomerName = c.Name,
        @TotalAmount = o.TotalAmount
    FROM Orders o
    INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID
    INNER JOIN Customers c ON o.CustomerID = c.CustomerID
    WHERE o.OrderID = @OrderID;

    -- Trả về chi tiết đơn hàng kèm theo TotalAmount
    SELECT 
        @OrderID AS OrderID,
        @OrderDate AS OrderDate,
        @EmployeeID AS EmployeeID,
        @EmployeeName AS EmployeeName,
        @CustomerID AS CustomerID,
        @CustomerName AS CustomerName,
        od.BookID,
        b.Title,
        SUM(od.Quantity) AS Quantity,
        od.SellPrice,
        SUM(od.Quantity * od.SellPrice) AS Total,
        @TotalAmount AS TotalAmount

    FROM OrderDetails od
    INNER JOIN Books b ON od.BookID = b.BookID
    WHERE od.OrderID = @OrderID
    GROUP BY od.BookID, b.Title, SellPrice;
END


-- -- test
-- EXEC sp_GetOrderReport @OrderID = 3
-- GO
-- SELECT * FROM OrderDetails WHERE OrderID = 3




DROP PROC IF EXISTS sp_GetDayOrderChartdataByDate
GO
CREATE PROC sp_GetDayOrderChartdataByDate
    @Date DATETIME
AS
BEGIN
    WITH hourList AS (
        SELECT 0 AS Order_hour
        UNION ALL SELECT 1
        UNION ALL SELECT 2
        UNION ALL SELECT 3
        UNION ALL SELECT 4
        UNION ALL SELECT 5
        UNION ALL SELECT 6
        UNION ALL SELECT 7
        UNION ALL SELECT 8
        UNION ALL SELECT 9
        UNION ALL SELECT 10
        UNION ALL SELECT 11
        UNION ALL SELECT 12
        UNION ALL SELECT 13
        UNION ALL SELECT 14
        UNION ALL SELECT 15
        UNION ALL SELECT 16
        UNION ALL SELECT 17
        UNION ALL SELECT 18
        UNION ALL SELECT 19
        UNION ALL SELECT 20
        UNION ALL SELECT 21
        UNION ALL SELECT 22
        UNION ALL SELECT 23
    )

    SELECT 
        l.Order_hour,
        COUNT(o.OrderID) AS OrderCount
    FROM hourList l
    LEFT JOIN Orders o 
        ON DATEPART(HOUR, o.OrderDate) = l.Order_hour
        AND CONVERT(DATE, o.OrderDate) = CONVERT(DATE, @Date)
    GROUP BY 
        l.Order_hour
    ORDER BY 
        l.Order_hour
END


-- -- test
-- SELECT * FROM Orders
EXEC sp_GetDayOrderChartdataByDate '2025-01-12'



-- DROP PROC IF EXISTS GetDayNumbersInMonth
-- GO
-- CREATE PROCEDURE GetDayNumbersInMonth
--     @Month INT,
--     @Year INT
-- AS
-- BEGIN
--     SET NOCOUNT ON;

--     DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1);
--     DECLARE @EndDate DATE = EOMONTH(@StartDate);

--     ;WITH Dates AS
--     (
--         SELECT @StartDate AS Day
--         UNION ALL
--         SELECT DATEADD(DAY, 1, Day)
--         FROM Dates
--         WHERE Day < @EndDate
--     )
--     SELECT DAY(Day) AS DayNumber
--     FROM Dates
--     OPTION (MAXRECURSION 0);
-- END


-- EXEC GetDayNumbersInMonth @Month = 2, @Year = 2025;



DROP FUNCTION IF EXISTS dbo.GetDayNumbersInMonth
GO
CREATE FUNCTION dbo.GetDayNumbersInMonth
(
    @Month INT,
    @Year INT
)
RETURNS @Days TABLE
(
    DayNumber INT
)
AS
BEGIN
    DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1);
    DECLARE @EndDate DATE = EOMONTH(@StartDate);
    DECLARE @CurrentDate DATE = @StartDate;

    WHILE @CurrentDate <= @EndDate
    BEGIN
        INSERT INTO @Days (DayNumber)
        VALUES (DAY(@CurrentDate));

        SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
    END

    RETURN;
END
GO

DROP PROC IF EXISTS sp_GetMonthOrderChartdata
GO
CREATE PROC sp_GetMonthOrderChartdata
    @Year INT,
    @Month INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        d.DayNumber AS Order_day,
        COUNT(o.OrderID) AS OrderCount              
    FROM 
        dbo.GetDayNumbersInMonth(@Month, @Year) AS d
    LEFT JOIN 
        Orders o 
        ON DAY(o.OrderDate) = d.DayNumber
           AND MONTH(o.OrderDate) = @Month
           AND YEAR(o.OrderDate) = @Year
    GROUP BY 
        d.DayNumber
    ORDER BY 
        d.DayNumber;
END

-- test
EXEC sp_GetMonthOrderChartdata @Year = 2025, @Month = 3
SELECT * FROM Orders





DROP PROC IF EXISTS sp_GetYearOrderChartdata
GO
CREATE PROC sp_GetYearOrderChartdata
    @Year INT
AS
BEGIN
    WITH MonthList AS (
        SELECT 0 AS Order_month
        UNION ALL SELECT 1
        UNION ALL SELECT 2
        UNION ALL SELECT 3
        UNION ALL SELECT 4
        UNION ALL SELECT 5
        UNION ALL SELECT 6
        UNION ALL SELECT 7
        UNION ALL SELECT 8
        UNION ALL SELECT 9
        UNION ALL SELECT 10
        UNION ALL SELECT 11
        UNION ALL SELECT 12
    )

    SELECT 
        l.Order_month,
        COUNT(o.OrderID) AS OrderCount
    FROM MonthList l
    LEFT JOIN Orders o 
        ON DATEPART(MONTH, o.OrderDate) = l.Order_month
        AND DATEPART(YEAR, o.OrderDate) = @Year
    GROUP BY 
        l.Order_month
    ORDER BY 
        l.Order_month
END

EXEC sp_GetYearOrderChartdata @Year = 2025
EXEC sp_GetYearOrderChartdata @Year = 2024
EXEC sp_GetYearOrderChartdata @Year = 2023



GO
CREATE FUNCTION dbo.GetDateRange
(
    @StartDate DATE,
    @EndDate DATE
)
RETURNS TABLE
AS
RETURN
(
    WITH Numbers AS (
        SELECT TOP (DATEDIFF(DAY, @StartDate, @EndDate) + 1)
               ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
        FROM master.dbo.spt_values -- hoặc dùng sys.all_objects để có đủ dòng
    )
    SELECT DATEADD(DAY, n, @StartDate) AS DateValue
    FROM Numbers
);
GO

-- test
SELECT * FROM dbo.GetDateRange('2024-06-01', '2024-07-02');




DROP PROC IF EXISTS sp_GetRevenueByDate
GO
CREATE PROC sp_GetRevenueByDate
    @Date DATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalRevenue MONEY;

    SELECT 
        @TotalRevenue = ISNULL(SUM(od.Quantity * od.SellPrice), 0)
    FROM 
        Orders o
    INNER JOIN 
        OrderDetails od ON o.OrderID = od.OrderID
    WHERE 
        CONVERT(DATE, o.OrderDate) = @Date;

    -- Trả về tổng doanh thu cho ngày cụ thể
    SELECT 
        @Date AS RevenueDate,
        @TotalRevenue AS TotalRevenue;
END
GO

-- test
EXEC sp_GetRevenueByDate '2025-01-12'



DROP PROC IF EXISTS sp_GetDailyRevenueChartData
GO
CREATE PROC sp_GetDailyRevenueChartData
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        DAY(d.DateValue) AS Order_date,
        ISNULL(SUM(od.Quantity * od.SellPrice), 0) AS TotalRevenue
    FROM 
        dbo.GetDateRange(@StartDate, @EndDate) AS d
    LEFT JOIN 
        Orders o ON CONVERT(DATE, o.OrderDate) = d.DateValue
    LEFT JOIN 
        OrderDetails od ON o.OrderID = od.OrderID
    GROUP BY 
        d.DateValue
    ORDER BY 
        d.DateValue;
END
GO

-- test
EXEC sp_GetDailyRevenueChartData @StartDate = '2025-01-01 00:00:00', @EndDate = '2025-01-31'


DROP PROC IF EXISTS sp_GetMonthlyRevenueChartData
GO
CREATE PROC sp_GetMonthlyRevenueChartData
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;

    WITH MonthList AS (
        SELECT 0 AS Order_month
        UNION ALL SELECT 1
        UNION ALL SELECT 2
        UNION ALL SELECT 3
        UNION ALL SELECT 4
        UNION ALL SELECT 5
        UNION ALL SELECT 6
        UNION ALL SELECT 7
        UNION ALL SELECT 8
        UNION ALL SELECT 9
        UNION ALL SELECT 10
        UNION ALL SELECT 11
        UNION ALL SELECT 12
    )

    SELECT 
        l.Order_month,
        ISNULL(SUM(od.Quantity * od.SellPrice), 0) AS TotalRevenue
    FROM MonthList l
    LEFT JOIN Orders o 
        ON DATEPART(MONTH, o.OrderDate) = l.Order_month
           AND DATEPART(YEAR, o.OrderDate) = @Year
    LEFT JOIN OrderDetails od ON o.OrderID = od.OrderID
    GROUP BY 
        l.Order_month
    ORDER BY 
        l.Order_month;
END
GO

-- test
EXEC sp_GetMonthlyRevenueChartData @Year = 2025



