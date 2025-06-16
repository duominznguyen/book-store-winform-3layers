using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class DAL_Employee : DbConnect
    {
        public DAL_Employee() : base() { }

        public DataTable GetAllEmployees()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = "SELECT * FROM Employees";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
            return dataTable;
        }

        public DataTable GetEmployeeById(int employeeId)
        {
            string query = $"SELECT * FROM Employees WHERE EmployeeID = {employeeId}";
            return ExecuteQuery(query);
        }

        public DataTable SearchEmployeesByName(string name)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = $"SELECT * FROM Employees WHERE Name LIKE N'%{name}%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
            return dataTable;
        }

        public DataTable SearchEmployeesByEmail(string email)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = $"SELECT * FROM Employees WHERE Email LIKE '%{email}%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
            return dataTable;
        }

        public DataTable SearchEmployeesByPhone(string phone)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = $"SELECT * FROM Employees WHERE Phone LIKE '%{phone}%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
            return dataTable;
        }

        public DataTable SearchEmployeesByAddress(string address)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = $"SELECT * FROM Employees WHERE Address LIKE N'%{address}%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
            return dataTable;
        }


        public DataTable SearchEmployeesByRole(string role)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = $"SELECT * FROM Employees WHERE Role LIKE N'%{role}%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
            return dataTable;
        }


        public DataTable SeacrhEmployeesByGeneral(string searchTerm)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = $"SELECT * FROM Employees WHERE Name LIKE N'%{searchTerm}%' OR Email LIKE '%{searchTerm}%' OR Phone LIKE '%{searchTerm}%' OR Address LIKE N'%{searchTerm}%' OR Role LIKE N'%{searchTerm}%' OR EmployeeID LIKE '%{searchTerm}%'";
                dataTable = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
            return dataTable;
        }

        public DataTable SearchEmployees(string searchOption, string searchTerm)
        {
            DataTable dataTable = new DataTable();
            try
            {
                switch (searchOption)
                {
                    case "Name":
                        dataTable = SearchEmployeesByName(searchTerm);
                        break;
                    case "Email":
                        dataTable = SearchEmployeesByEmail(searchTerm);
                        break;
                    case "Phone":
                        dataTable = SearchEmployeesByPhone(searchTerm);
                        break;
                    case "Address":
                        dataTable = SearchEmployeesByAddress(searchTerm);
                        break;
                    case "Role":
                        dataTable = SearchEmployeesByRole(searchTerm);
                        break;
                    case "EmployeeID":
                        dataTable = GetEmployeeById(int.Parse(searchTerm));
                        break;
                    case "General":
                        dataTable = SeacrhEmployeesByGeneral(searchTerm);
                        break;
                    default:
                        throw new ArgumentException("Tùy chọn tìm kiếm không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
            return dataTable;
        }

        public Result AddEmployee(Employee employee)
        {
            try
            {
                string query = $"INSERT INTO Employees (Name, Email, Phone, Address, Role) " +
                               $"VALUES (N'{employee.Name}', '{employee.Email}', '{employee.Phone}', N'{employee.Address}', N'{employee.Role}')";
                ExecuteNonQuery(query);
                return new Result(true, "Thêm nhân viên thành công.");
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi thêm nhân viên: " + ex.Message);

            }
        }

        public Result UpdateEmployee(Employee employee)
        {
            try
            {
                string query = $"UPDATE Employees SET Name = N'{employee.Name}', Email = '{employee.Email}', Phone = '{employee.Phone}', Address = N'{employee.Address}', Role = N'{employee.Role}' WHERE EmployeeID = {employee.EmployeeID}";
                ExecuteNonQuery(query);
                return new Result(true, "Cập nhật nhân viên thành công.");
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi cập nhật nhân viên: " + ex.Message);
            }
        }

        public Result DeleteEmployee(int employeeId)
        {
            try
            {
                string query = $"DELETE FROM Employees WHERE EmployeeID = {employeeId}";
                ExecuteNonQuery(query);
                return new Result(true, "Xóa nhân viên thành công.");
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi xóa nhân viên: " + ex.Message);
            }
        }


    }
}
