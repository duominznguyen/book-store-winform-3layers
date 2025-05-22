using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DAL_Account : DbConnect
    {
        public bool LogIn(string userName, string password)
        {
            string query = $"SELECT COUNT(*) FROM Accounts WHERE Username = '{userName}' AND Password = '{password}'";
            object result = ExecuteScalar(query);
            if (result != null && int.TryParse(result.ToString(), out int count))
            {
                return count > 0;
            }
            return false;
        }

        public bool IsExistAccount(string userName)
        {
            string query = $"SELECT COUNT(*) FROM Accounts WHERE Username = '{userName}'";
            object result = ExecuteScalar(query);
            if (result != null && int.TryParse(result.ToString(), out int count))
            {
                return count > 0;
            }
            return false;
        }


        public Account GetAccount(string userName, string password)
        {
            string query = $"SELECT * FROM Accounts WHERE Username = '{userName}' AND Password = '{password}'";
            DataTable dataTable = ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new Account
                {
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    EmployeeId = Convert.ToInt32(row["EmployeeId"])
                };
            }
            return null;
        }

        public DataTable GetAllAccount_Employee()
        {
            string query =
                $"SELECT ac.*, ep.Name, ep.Role\r\n" +
                $"FROM Accounts ac\r\n" +
                $"INNER JOIN Employees ep ON ac.EmployeeID = ep.EmployeeID";

            try
            {
                DataTable dataTable = ExecuteQuery(query);
                return dataTable;
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw new Exception("Lỗi truy cuất csdl: " + ex.Message);
            }
        }

        public Result AddAccount(Account account)
        {
            string query = $"INSERT INTO Accounts (Username, Password, EmployeeId) VALUES ('{account.Username}', '{account.Password}', {account.EmployeeId})";
            try
            {
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Thêm tài khoản thành công");
                }
                else
                {
                    return new Result(false, "Thêm tài khoản thất bại");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw new Exception("Lỗi truy cuất csdl: " + ex.Message);
            }
        }

        public Result UpdateAccount(Account account)
        {
            string query = $"UPDATE Accounts SET Password = '{account.Password}', EmployeeId = {account.EmployeeId} WHERE Username = '{account.Username}'";
            try
            {
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Cập nhật tài khoản thành công");
                }
                else
                {
                    return new Result(false, "Cập nhật tài khoản thất bại");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw new Exception("Lỗi truy cuất csdl: " + ex.Message);
            }
        }


        public Result DeleteAccount(string username)
        {
            string query = $"DELETE FROM Accounts WHERE Username = '{username}'";
            try
            {
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Xóa tài khoản thành công");
                }
                else
                {
                    return new Result(false, "Xóa tài khoản thất bại");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw new Exception("Lỗi truy cuất csdl: " + ex.Message);
            }
        }
    }
}
