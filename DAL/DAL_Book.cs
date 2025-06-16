using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Book : DbConnect
    {
        public bool AddBook(Book book)
        {

            string query = $"INSERT INTO Books (Title, Author, Publisher, Price, Description, Quantity, CategoryID) " +
                           $"VALUES (N'{book.Title}', N'{book.Author}', N'{book.Publisher}', {book.Price}, N'{book.Description}', {book.Quantity}, '{book.CategoryID}')";
            int rowsAffected = ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool UpdateBook(Book book)
        {
            string query = $"UPDATE Books SET Title = N'{book.Title}', Author = N'{book.Author}', Publisher = N'{book.Publisher}', " +
                           $"Price = {book.Price}, Description = N'{book.Description}', Quantity = {book.Quantity}, CategoryID = '{book.CategoryID}' " +
                           $"WHERE BookID = '{book.BookID}'";
            int rowsAffected = ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool DeleteBook(string bookID)
        {
            string query = $"DELETE FROM Books WHERE BookID = '{bookID}'";
            int rowsAffected = ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public DataTable GetAllBooks()
        {
            string query = "SELECT * FROM Books";
            return ExecuteQuery(query);
        }

        public DataTable GetAllBooks_BookCategories()
        {
            string query = "SELECT Books.*, BookCategories.CategoryName FROM Books " +
                           "LEFT JOIN BookCategories ON Books.CategoryID = BookCategories.CategoryID";
            return ExecuteQuery(query);
        }

        public int GetBookQuantity(int bookID)
        {
            string query = $"SELECT Quantity FROM Books WHERE BookID = '{bookID}'";
            DataTable dataTable = ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                return Convert.ToInt32(dataTable.Rows[0]["Quantity"]);
            }
            return 0;
        }

        public DataTable GetBookByID(string bookID)
        {
            return ExecuteQuery($"SELECT * FROM Books WHERE BookID = '{bookID}'");
        }

        public DataTable GetBookByID(int bookID)
        {
            return ExecuteQuery($"SELECT * FROM Books WHERE BookID = {bookID}");
        }

        private DataTable SearchBookByTitle(string title)
        {
            try
            {
                string query = $"SELECT * FROM Books WHERE Title LIKE N'%{title}%'";
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("(Database)Lỗi khi tìm kiếm sách: " + ex.Message);
            }
        }

        private DataTable SearchBookByAuthor(string author)
        {
            try
            {
                string query = $"SELECT * FROM Books WHERE Author LIKE N'%{author}%'";
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("(Database)Lỗi khi tìm kiếm sách: " + ex.Message);
            }
        }

        private DataTable SearchBookByPublisher(string publisher)
        {
            try
            {
                string query = $"SELECT * FROM Books WHERE Publisher LIKE N'%{publisher}%'";
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("(Database)Lỗi khi tìm kiếm sách: " + ex.Message);
            }
        }

        private DataTable SearchBookByCategoryName(string categoryName)
        {
            try
            {
                string query = $"SELECT Books.* FROM Books " +
                               $"LEFT JOIN BookCategories ON Books.CategoryID = BookCategories.CategoryID " +
                               $"WHERE BookCategories.CategoryName LIKE N'%{categoryName}%'";

                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("(Database)Lỗi khi tìm kiếm sách: " + ex.Message);
            }
        }

        private DataTable GeneralSearchBook(string searchTerm)
        {
            try
            {
                // tôi muốn tìm kiếm theo tên sách, tác giả, nhà xuất bản, theo id sách, theo CategoryName
                string query = $@"
                SELECT Books.* 
                FROM Books
                LEFT JOIN BookCategories ON Books.CategoryID = BookCategories.CategoryID
                WHERE 
                    Books.Title LIKE N'%{searchTerm}%' OR 
                    Books.Author LIKE N'%{searchTerm}%' OR 
                    Books.Publisher LIKE N'%{searchTerm}%' OR 
                    Books.BookID LIKE N'%{searchTerm}%' OR 
                    BookCategories.CategoryName LIKE N'%{searchTerm}%'";

                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("(Database)Lỗi khi tìm kiếm sách: " + ex.Message);
            }
        }


        public DataTable SearchBook(string searchOption, string searchTerm)
        {
            try
            {
                switch (searchOption)
                {
                    case "Title":
                        return SearchBookByTitle(searchTerm);
                    case "Author":
                        return SearchBookByAuthor(searchTerm);
                    case "Publisher":
                        return SearchBookByPublisher(searchTerm);
                    case "BookID":
                        return GetBookByID(searchTerm);
                    case "CategoryName":
                        return SearchBookByCategoryName(searchTerm);
                    case "General":
                        return GeneralSearchBook(searchTerm);
                    default:
                        throw new Exception("Lựa chọn tìm kiếm không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sách: " + ex.Message);
            }
        }
    }
}