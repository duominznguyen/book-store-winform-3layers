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
    PurchaseDate DATE,
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
    OrderDate DATE,
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

-- Insert data into Books
INSERT INTO Books (BookID, Title, Author, Publisher, Price, Description, Quantity, CategoryID)
VALUES 
    (1, N'Truyện Kiều', N'Nguyễn Du', N'Nhà xuất bản Văn học', 120000, N'Tác phẩm kinh điển của văn học Việt Nam', 50, 1),
    (2, N'Những người khốn khổ', N'Victor Hugo', N'Nhà xuất bản Kim Đồng', 150000, N'Tiểu thuyết nổi tiếng thế giới', 30, 1),
    (3, N'Lược sử thời gian', N'Stephen Hawking', N'Nhà xuất bản Trẻ', 180000, N'Khám phá vũ trụ', 20, 3),
    (4, N'Mã sạch', N'Robert C. Martin', N'Nhà xuất bản Khoa học Kỹ thuật', 350000, N'Thực hành lập trình tốt', 40, 4),
    (5, N'Nhật ký Đặng Thùy Trâm', N'Đặng Thùy Trâm', N'Nhà xuất bản Hội Nhà văn', 90000, N'Câu chuyện về lòng yêu nước', 25, 5);

-- Insert data into Customers
INSERT INTO Customers (CustomerID, Name, Email, Phone, Address)
VALUES 
    (1, N'Nguyễn Bình An', N'nguyenbinhan@example.com', N'0123456789', N'123 Đường Láng, Hà Nội'),
    (2, N'Trần Minh Khánh', N'tranminhkhanh@example.com', N'0987654321', N'456 Nguyễn Trãi, TP.HCM'),
    (3, N'Phạm Hồng Minh', N'phamhongminh@example.com', N'0345678901', N'789 Lê Lợi, Đà Nẵng'),
    (4, N'Lê Đức Thịnh', N'leducthinh@example.com', N'0567890123', N'101 Hai Bà Trưng, Huế'),
    (5, N'Trịnh Trần Phương Tắn', N'trinhtranphuongtan@example.com', N'0789012345', N'202 Đường Láng, Bến Tre');

-- Insert data into Employees
INSERT INTO Employees (EmployeeID, Name, Email, Phone, Address, Role)
VALUES 
    (1, N'Nguyễn Thị Hoa', N'nguyenhoa@example.com', N'0123456789', N'123 Cầu Giấy, Hà Nội', N'Quản lý'),
    (2, N'Lê Minh Tùng', N'letung@example.com', N'0987654321', N'456 Tô Hiệu, TP.HCM', N'Nhân viên'),
    (3, N'Phan Anh Tuấn', N'phantuan@example.com', N'0345678901', N'789 Hoàng Hoa Thám, Đà Nẵng', N'Nhân viên'),
    (4, N'Vũ Thị Hồng', N'vuhong@example.com', N'0567890123', N'101 Lý Tự Trọng, Huế', N'Nhân viên'),
    (5, N'Hoàng Văn Long', N'hoanglong@example.com', N'0789012345', N'202 Phan Đình Phùng, Cần Thơ', N'Nhân viên');

-- Insert data into Accounts
INSERT INTO Accounts (Username, Password, EmployeeID)
VALUES 
    ('log1', '123', 1),
    ('log2', '123', 2),
    ('log3', '123', 3),
    ('log4', '123', 4),
    ('log5', '123', 5);

-- Insert data into Suppliers
INSERT INTO Suppliers (SupplierID, Name, Phone, Address)
VALUES 
    (1, N'Công ty Sách Việt', N'0987654321', N'500 Nguyễn Văn Cừ, Hà Nội'),
    (2, N'Nhà sách Tiến Đạt', N'0123456789', N'100 Lê Văn Sỹ, TP.HCM'),
    (3, N'Thế Giới Sách', N'0345678901', N'300 Trần Phú, Đà Nẵng'),
    (4, N'Nhà sách Hồng Hà', N'0567890123', N'400 Nguyễn Huệ, Huế'),
    (5, N'Sách và Cuộc Sống', N'0789012345', N'600 Phan Chu Trinh, Cần Thơ');

-- Insert data into BookPurchases
INSERT INTO Purchases (PurchaseID, PurchaseDate, SupplierID, EmployeeID)
VALUES 
    (1, '2025-01-01', 1, 1),
    (2, '2025-01-02', 2, 2),
    (3, '2025-01-03', 3, 3),
    (4, '2025-01-04', 4, 4),
    (5, '2025-01-05', 5, 5);

-- Insert data into PurchaseDetails
INSERT INTO PurchaseDetails (PurchaseID, BookID, Quantity, PurchasePrice)
VALUES 
    (1, 1, 10, 100000),
    (2, 2, 15, 140000),
    (3, 3, 20, 170000),
    (4, 4, 10, 320000),
    (5, 5, 25, 80000);

-- Insert data into Orders
INSERT INTO Orders (OrderID, OrderDate, CustomerID, EmployeeID)
VALUES 
    (1, '2025-01-06', 1, 1),
    (2, '2025-01-07', 2, 2),
    (3, '2025-01-08', 3, 3),
    (4, '2025-01-09', 4, 4),
    (5, '2025-01-10', 5, 5);

-- Insert data into OrderDetails
INSERT INTO OrderDetails (OrderID, BookID, Quantity, SellPrice)
VALUES 
    (1, 1, 2, 120000),
    (2, 2, 1, 150000),
    (3, 3, 3, 180000),
    (4, 4, 4, 350000),
    (5, 5, 1, 90000);

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



-- DELETE FROM OrderDetails;
-- DELETE FROM Orders;
-- DELETE FROM PurchaseDetails;
-- DELETE FROM Purchases;
-- DELETE FROM Suppliers;
-- DELETE FROM Accounts;
-- DELETE FROM Employees;
-- DELETE FROM Customers;
-- DELETE FROM Books;
-- DELETE FROM BookCategories;
