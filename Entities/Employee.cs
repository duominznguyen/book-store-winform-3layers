using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        private int _employeeID;
        private string _name;
        private string _email;
        private string _phone;
        private string _address;
        private string _role;

        public int EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be null or empty.");
                _name = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Email cannot be null or empty.");
                _email = value;
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Phone cannot be null or empty.");
                _phone = value;
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Address cannot be null or empty.");
                _address = value;
            }
        }

        public string Role
        {
            get { return _role; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Role cannot be null or empty.");
                _role = value;
            }
        }
        public Employee() { } // Default constructor for serialization purposes
        public Employee(int employeeID, string name, string email, string phone, string address, string role)
        {
            EmployeeID = employeeID;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Role = role;
        }
    }
}
