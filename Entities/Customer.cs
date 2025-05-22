using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        private int _customerId;
        private string _name;
        private string _email;
        private string _phone;
        private string _address;

        public int CustomerID
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
            }
        }


        public Customer() { } // Default constructor for serialization purposes
        public Customer(int customerId, string name, string email, string phone, string address)
        {
            _customerId = customerId;
            _name = name;
            _email = email;
            _phone = phone;
            _address = address;
        }

    }
}
