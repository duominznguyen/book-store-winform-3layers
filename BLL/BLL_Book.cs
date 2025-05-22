using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLL_Book
    {
        private DAL_Book _dal;
        public BLL_Book()
        {
            _dal = new DAL_Book();
        }

        public bool AddBook(Book book)
        {
            if (LogicValidateForAdd(book))
            {
                return _dal.AddBook(book);
            }
            else
            {
                throw new Exception("Mã sách đã tồn tại.");
            }
        }

        public bool UpdateBook(Book book)
        {
            if (LogicValidateForUpdate(book))
            {
                return _dal.UpdateBook(book);
            }
            else
            {
                throw new Exception("Mã sách không tồn tại.");
            }
        }

        public bool DeleteBook(string bookID)
        {
            if (LogicValidateForDelete(bookID))
            {
                return _dal.DeleteBook(bookID);
            }
            else
            {
                throw new Exception("Mã sách không tồn tại.");
            }
        }

        public DataTable GetAllBooks()
        {
            return _dal.GetAllBooks();
        }

        public DataTable GetAllBooks_BookCategories()
        {
            return _dal.GetAllBooks_BookCategories();
        }

        public DataTable GetBookByID(string id)
        {
            return _dal.GetBookByID(id);
        }

        public bool LogicValidateForAdd(Book book)
        {
            return _dal.GetBookByID(book.BookID).Rows.Count == 0;
        }

        public bool LogicValidateForUpdate(Book book)
        {
            return _dal.GetBookByID(book.BookID).Rows.Count > 0;
        }

        public bool LogicValidateForDelete(string bookID)
        {
            return _dal.GetBookByID(bookID).Rows.Count > 0;
        }

        public DataTable SearchBooks(string SearchOption, string searchValue)
        {
            try
            {
                return _dal.SearchBook(SearchOption, searchValue);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sách: " + ex.Message);
            }
        }

    }
}
