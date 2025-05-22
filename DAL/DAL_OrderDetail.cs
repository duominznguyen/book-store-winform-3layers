using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class DAL_OrderDetail : DbConnect
    {
        public DAL_OrderDetail() : base() { }

        public DataTable GetOrderDetailById(int orderDetailId)
        {
            string query = $"SELECT * FROM OrderDetails WHERE OrderDetailID = {orderDetailId}";
            return ExecuteQuery(query);
        }
        public DataTable GetOrderDetailsByOrderId(int orderId)
        {
            string query = $"SELECT * FROM OrderDetails WHERE OrderID = {orderId}";
            return ExecuteQuery(query);
        }

        public DataTable GetOrderDetailsByOrderDetailId(int orderDetailId)
        {
            string query = $"SELECT * FROM OrderDetails WHERE OrderDetailID = {orderDetailId}";
            return ExecuteQuery(query);
        }

        public int GetSelledBookQuantityByOrderDetailID(int orderDetailId)
        {
            string query = $"SELECT Quantity FROM OrderDetails WHERE OrderDetailID = {orderDetailId}";
            DataTable dataTable = ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                return Convert.ToInt32(dataTable.Rows[0]["Quantity"]);
            }
            return 0;
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            string query = $"INSERT INTO OrderDetails (OrderID, BookID, Quantity, SellPrice) VALUES ({orderDetail.OrderId}, {orderDetail.BookId}, {orderDetail.Quantity}, {orderDetail.SellPrice})";
            return ExecuteNonQuery(query) > 0;
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            string query = $"UPDATE OrderDetails SET BookID = {orderDetail.BookId}, Quantity = {orderDetail.Quantity}, SellPrice = {orderDetail.SellPrice} WHERE OrderDetailID = {orderDetail.OrderDetailId}";
            return ExecuteNonQuery(query) > 0;
        }

        public bool DeleteOrderDetail(int orderDetailId)
        {
            string query = $"DELETE FROM OrderDetails WHERE OrderDetailID = {orderDetailId}";
            return ExecuteNonQuery(query) > 0;
        }

        public DataTable GetOrderDetails_BookByOrderId(int orderId)
        {
            string query = 
                $"SELECT odt.OrderDetailID, odt.BookID, bk.Title, odt.Quantity, odt.SellPrice\n" +
                $"FROM OrderDetails odt\n" +
                $"INNER JOIN Books bk ON odt.BookID = bk.BookID\n" +
                $"WHERE odt.OrderID = {orderId}";

            try
            {
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất csdl", ex);
            }
        }


        public DataTable GetOrderPrint(int orderId)
        {
            string query =
                $"SELECT od.OrderID, od.OrderDate, c.CustomerID, c.Name AS 'CustomerName', e.EmployeeID, e.Name AS 'EmployeeName', b.BookID, b.Title, odt.Quantity, odt.SellPrice\r\n" +
                $"FROM OrderDetails odt\r\n" +
                $"INNER JOIN Orders od ON odt.OrderID = od.OrderID\r\n" +
                $"INNER JOIN Customers c ON od.CustomerID = c.CustomerID\r\n" +
                $"INNER JOIN Employees e ON od.EmployeeID = e.EmployeeID\r\n" +
                $"INNER JOIN Books b ON odt.BookID = b.BookID\r\n" +
                $"WHERE odt.OrderID = {orderId};";

            return ExecuteQuery(query);
        }


    }


}
