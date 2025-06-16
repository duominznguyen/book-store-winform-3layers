using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_BookCategory
    {
        private DAL.DAL_BookCategory _dal;
        public BLL_BookCategory()
        {
            _dal = new DAL.DAL_BookCategory();
        }


        private bool IsLogicVaidatedAddCategory(int categoryId)
        {
            return true;
        }

        private bool IsLogicVaidatedUpdateCategory(int categoryId)
        {
            return _dal.GetBookCategoryById(categoryId) != null;
        }

        private bool IsLogicVaidatedDeleteCategory(int categoryId)
        {
            return _dal.GetBookCategoryById(categoryId) != null;
        }

        public bool AddBookCategory(int categoryId, string categoryName)
        {
            if (IsLogicVaidatedAddCategory(categoryId))
            {
                return _dal.AddBookCategory(categoryId, categoryName);
            }
            else
            {
                throw new Exception("Danh mục đã tồn tại trong hệ thống!");
            }

        }

        public bool UpdateBookCategory(int categoryId, string categoryName)
        {
            if (IsLogicVaidatedUpdateCategory(categoryId))
            {
                return _dal.UpdateBookCategory(categoryId, categoryName);
            }
            else
            {
                throw new Exception("Danh mục không tồn tại trong hệ thống!");
            }
        }

        public bool DeleteBookCategory(int categoryId)
        {
            if (IsLogicVaidatedDeleteCategory(categoryId))
            {
                return _dal.DeleteBookCategory(categoryId);
            }
            else
            {
                throw new Exception("Danh mục không tồn tại trong hệ thống!");
            }
        }


        public DataTable GetAllBookCategories()
        {
            return _dal.GetAllBookCategories();
        }

        public DataTable SearchBookCategory(string SearchOptions, string searchStr)
        {
            if (SearchOptions == "ID")
            {
                return _dal.GetBookCategoryById(int.Parse(searchStr));
            }
            if (SearchOptions == "Tên thể loại")
            {
                return _dal.GetBookCategoryByName(searchStr);
            }

            return null;
        }
    }
}
