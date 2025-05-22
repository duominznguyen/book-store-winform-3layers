using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Supplier
    {
        private int _supplierId;
        private string _name;
        private string _phone;
        private string _address;

        public int SupplierId
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
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

        public Supplier() { } // Default constructor for serialization purposes
        public Supplier(int supplierId, string name, string phone, string address)
        {
            _supplierId = supplierId;
            _name = name;
            _phone = phone;
            _address = address;
        }

    }
}
