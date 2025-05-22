using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BookCategory
    {
        private string _categoryID;
        private string _categoryName;
        public string CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        public BookCategory() { }

        public BookCategory(string categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }

    }
}
