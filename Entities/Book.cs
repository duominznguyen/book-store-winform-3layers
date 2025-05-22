using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Book
    {
        private string _bookID;
        private string _title;
        private string _author;
        private string _publisher;
        private float _price; 
        private string _description;
        private int _quantity;
        private string _categoryID;
        public string BookID
        {
            get { return _bookID; }
            set { _bookID = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        public Book()
        {
        }
        public Book(string bookID, string title, string author, string publisher, float price, string description, int quantity, string categoryID)
        {
            _bookID = bookID;
            _title = title;
            _author = author;
            _publisher = publisher;
            _price = price;
            _description = description;
            _quantity = quantity;
            _categoryID = categoryID;
        }


    }
}
