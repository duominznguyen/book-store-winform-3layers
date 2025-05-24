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
            string query = $"EXEC sp_GetOrderReport @OrderID = {orderId}";
            try
            {
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất csdl", ex);
            }
        }

    }


}
