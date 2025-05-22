using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Account
    {
        private string _username;
        private string _password;
        private int _employeeId;
        public string Username
        {
            get { return _username; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Username cannot be null or empty.");
                _username = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Password cannot be null or empty.");
                _password = value;
            }
        }
        public int EmployeeId
        {
            get { return _employeeId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Employee ID must be a positive integer.");
                _employeeId = value;
            }
        }

        public Account() { } // Default constructor for serialization purposes
        public Account(string username, string password, int employeeId)
        {
            Username = username;
            Password = password;
            EmployeeId = employeeId;
        }



    }
}
