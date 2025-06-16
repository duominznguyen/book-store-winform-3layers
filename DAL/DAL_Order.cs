using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class DAL_Order : DbConnect
    {
        public DAL_Order() : base() { }

        public DataTable GetAllOrder()
        {
            string query = "SELECT * FROM Orders";
            return ExecuteQuery(query);
        }

        public DataTable GetOrderById(int orderId)
        {
            string query = $"SELECT * FROM Orders WHERE OrderID = {orderId}";
            return ExecuteQuery(query);
        }

        public DataTable GetOrderByEmployeeId(int employeeId)
        {
            string query = $"SELECT * FROM Orders WHERE EmployeeID = {employeeId}";
            return ExecuteQuery(query);
        }

        public DataTable GetOrderByCustomerId(int customerId)
        {
            string query = $"SELECT * FROM Orders WHERE CustomerID = {customerId}";
            return ExecuteQuery(query);
        }

        public DataTable GetOrderByOrderDate(DateTime orderDate)
        {
            string query = $"SELECT * FROM Orders WHERE OrderDate = '{orderDate.ToString("yyyy-MM-dd")}'";
            return ExecuteQuery(query);
        }

        public DataTable GetDayOrdersChartData(DateTime oderDate)
        {
            DataTable data = new DataTable();
            try
            {
                string query = $"EXEC sp_GetDayOrderChartdataByDate '{oderDate.ToString("yyyy-MM-dd")}'";
                data = ExecuteQuery(query);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất dữ liệu biểu đồ: " + ex.Message);
            }
        }

        public DataTable GetMonthOrdersChartData(int year, int month)
        {
            DataTable data = new DataTable();
            try
            {
                string query = $"EXEC sp_GetMonthOrderChartdata @Year = {year}, @Month = {month}";
                data = ExecuteQuery(query);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất dữ liệu biểu đồ: " + ex.Message);
            }
        }

        public DataTable GetYearOrdersChartData(int year)
        {
            DataTable data = new DataTable();
            try
            {
                string query = $"EXEC sp_GetYearOrderChartdata @Year = {year}";
                data = ExecuteQuery(query);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất dữ liệu biểu đồ: " + ex.Message);
            }
        }

        public DataTable GetRevenueByDate(DateTime orderDate)
        {
            DataTable data = new DataTable();
            try
            {
                string query = $"EXEC sp_GetRevenueByDate '{orderDate.ToString("yyyy-MM-dd")}'";
                data = ExecuteQuery(query);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất dữ liệu doanh thu: " + ex.Message);
            }
        }

        public DataTable GetDailyRevenueChartData(DateTime startDate, DateTime endDate)
        {
            DataTable data = new DataTable();
            try
            {
                string query = $"EXEC sp_GetDailyRevenueChartData @StartDate = '{startDate}', @EndDate = '{endDate}'";
                data = ExecuteQuery(query);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất dữ liệu biểu đồ doanh thu: " + ex.Message);
            }
        }

        public DataTable GetMonthlyRevenueChartData(int year)
        {
            DataTable data = new DataTable();
            try
            {
                string query = $"EXEC sp_GetMonthlyRevenueChartData @Year = {year}";
                data = ExecuteQuery(query);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất dữ liệu biểu đồ doanh thu: " + ex.Message);
            }
        }


        // C_UD operations for Order
        public bool AddOrder(Order order)
        {
            string query = $"INSERT INTO Orders (OrderDate, EmployeeID, CustomerID) VALUES ('{order.OrderDate.ToString("yyyy-MM-dd")}', {order.EmployeeID}, {order.CustomerID})";
            return ExecuteNonQuery(query) > 0;
        }

        public bool UpdateOrder(Order order)
        {
            string query = $"UPDATE Orders SET OrderDate = '{order.OrderDate.ToString("yyyy-MM-dd")}', EmployeeID = {order.EmployeeID}, CustomerID = {order.CustomerID} WHERE OrderID = {order.OrderID}";
            return ExecuteNonQuery(query) > 0;
        }

        public bool DeleteOrder(int orderId)
        {
            string query = $"DELETE FROM Orders WHERE OrderID = {orderId}";
            return ExecuteNonQuery(query) > 0;
        }


    }
}
