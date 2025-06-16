using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BookCategory : DbConnect
    {
        public bool AddBookCategory(int categoryId, string categoryName)
        {
            string query = $"INSERT INTO BookCategories (CategoryName) VALUES (N'{categoryName}')";
            return ExecuteNonQuery(query) > 0;
        }

        public bool UpdateBookCategory(int categoryId, string categoryName)
        {
            string query = $"UPDATE BookCategories SET CategoryName = N'{categoryName}' WHERE CategoryID = {categoryId}";
            return ExecuteNonQuery(query) > 0;
        }

        public bool DeleteBookCategory(int categoryId)
        {
            string query = $"DELETE FROM BookCategories WHERE CategoryID = {categoryId}";
            return ExecuteNonQuery(query) > 0;
        }

        public DataTable GetAllBookCategories()
        {
            string query = "SELECT * FROM BookCategories";
            return ExecuteQuery(query);
        }

        public DataTable GetBookCategoryById(int categoryId)
        {
            string query = $"SELECT * FROM BookCategories WHERE CategoryID = {categoryId}";
            return ExecuteQuery(query);
        }

        public DataTable GetBookCategoryByName(string categoryName)
        {
            string query = $"SELECT * FROM BookCategories WHERE CategoryName LIKE '%{categoryName}%'";
            return ExecuteQuery(query);
        }
    }
}
