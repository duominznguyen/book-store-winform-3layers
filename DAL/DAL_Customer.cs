using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace DAL
{
    public class DAL_Customer : DbConnect
    {
        public DAL_Customer() : base()
        {
        }

        public Result AddCustomer(Customer customer)
        {
            try
            {
                // Code to add customer to the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     context.Customers.Add(customer);
                //     context.SaveChanges();
                // }
                string query = "INSERT INTO Customers (CustomerID, Name, Email, Phone, Address) " +
                               $"VALUES ({customer.CustomerID}, N'{customer.Name}', '{customer.Email}', '{customer.Phone}', N'{customer.Address}')";
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Thêm khách hàng thành công.");
                }
                else
                {
                    return new Result(false, "Thêm khách hàng không thành công.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Lỗi khi thêm khách hàng: {ex.Message}");
            }
        }


        public Result UpdateCustomer(Customer customer)
        {
            try
            {
                // Code to update customer in the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     context.Entry(customer).State = EntityState.Modified;
                //     context.SaveChanges();
                // }
                string query = $"UPDATE Customers SET " +
                               $"Name = N'{customer.Name}', " +
                               $"Email = '{customer.Email}', " +
                               $"Phone = '{customer.Phone}', " +
                               $"Address = N'{customer.Address}' " +
                               $"WHERE CustomerID = {customer.CustomerID}";
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Cập nhật thông tin khách hàng thành công.");
                }
                else
                {
                    return new Result(false, "Cập nhật thông tin khách hàng không thành công");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Lỗi khi cập nhật thông tin khách hàng: {ex.Message}");
            }
        }


        public Result DeleteCustomer(int customerId)
        {
            try
            {
                // Code to delete customer from the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     var customer = context.Customers.Find(customerId);
                //     if (customer != null)
                //     {
                //         context.Customers.Remove(customer);
                //         context.SaveChanges();
                //     }
                // }
                string query = "DELETE FROM Customers WHERE CustomerID = " + customerId;
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Xóa khách hàng thành công.");
                }
                else
                {
                    return new Result(false, "Xóa khách hàng không thành công.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Lỗi khi xóa khách hàng: {ex.Message}");
            }
        }


        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Code to retrieve all customers from the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     dataTable = context.Customers.ToList();
                // }
                string query = "SELECT * FROM Customers";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi truy vấn database: {ex.Message}");
            }
            return dataTable;
        }


        public DataTable GetCustomerById(int customerId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Code to retrieve customer by ID from the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     dataTable = context.Customers.Where(c => c.CustomerID == customerId).ToList();
                // }
                string query = "SELECT * FROM Customers WHERE CustomerID = " + customerId;
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi truy vấn database: {ex.Message}");
            }
            return dataTable;
        }


        private DataTable SearchCustomersByName(string name)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Code to search customers by name in the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     dataTable = context.Customers.Where(c => c.Name.Contains(name)).ToList();
                // }
                string query = "SELECT * FROM Customers WHERE Name LIKE N'%" + name + "%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi truy vấn database: {ex.Message}");
            }
            return dataTable;
        }

        private DataTable SearchCustomersByEmail(string email)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Code to search customers by email in the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     dataTable = context.Customers.Where(c => c.Email.Contains(email)).ToList();
                // }
                string query = "SELECT * FROM Customers WHERE Email LIKE '%" + email + "%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi truy vấn database: {ex.Message}");
            }
            return dataTable;
        }

        private DataTable SearchCustomersByPhone(string phone)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Code to search customers by phone in the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     dataTable = context.Customers.Where(c => c.Phone.Contains(phone)).ToList();
                // }
                string query = "SELECT * FROM Customers WHERE Phone LIKE '%" + phone + "%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi truy vấn database: {ex.Message}");
            }
            return dataTable;
        }

        private DataTable SearchCustomersByAddress(string address)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Code to search customers by address in the database
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     dataTable = context.Customers.Where(c => c.Address.Contains(address)).ToList();
                // }
                string query = "SELECT * FROM Customers WHERE Address LIKE N'%" + address + "%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi truy vấn database: {ex.Message}");
            }
            return dataTable;
        }

        private DataTable SearchCustomers(string searchTerm)
        {
            // Code to generally search customers in the database

            DataTable dataTable = new DataTable();
            try
            {
                // For example:
                // using (var context = new YourDbContext())
                // {
                //     dataTable = context.Customers.Where(c => c.Name.Contains(searchTerm) || c.Email.Contains(searchTerm) || c.Phone.Contains(searchTerm) || c.Address.Contains(searchTerm)).ToList();
                // }
                string query = $"SELECT * FROM Customers WHERE " +
                               $"Name LIKE N'%{searchTerm}%' OR " +
                               $"Email LIKE '%{searchTerm}%' OR " +
                               $"Phone LIKE '%{searchTerm}%' OR " +
                               $"Address LIKE N'%{searchTerm}%' OR " +
                               $"CustomerID LIKE '%{searchTerm}%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi truy vấn database: {ex.Message}");
            }
            return dataTable;
        }

        public DataTable SearchCustomers(string searchTerm, string searchOption)
        {
            DataTable dataTable = new DataTable();
            try
            {
                switch (searchOption)
                {
                    case "CustomerID":
                        dataTable = GetCustomerById(Convert.ToInt32(searchTerm));
                        break;
                    case "Name":
                        dataTable = SearchCustomersByName(searchTerm);
                        break;
                    case "Email":
                        dataTable = SearchCustomersByEmail(searchTerm);
                        break;
                    case "Phone":
                        dataTable = SearchCustomersByPhone(searchTerm);
                        break;
                    case "Address":
                        dataTable = SearchCustomersByAddress(searchTerm);
                        break;
                    case "All":
                        dataTable = SearchCustomers(searchTerm);
                        break;
                    default:
                        throw new Exception("Tùy chọn tìm kiếm không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi truy vấn database: {ex.Message}");
            }
            return dataTable;
        }

    }
}
