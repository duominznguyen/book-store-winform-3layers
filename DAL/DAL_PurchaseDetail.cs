using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class DAL_PurchaseDetail : DbConnect
    {
        public DAL_PurchaseDetail() : base() { }

        public DataTable GetPurchaseDetailViewByPurchaseID(int purchaseID)
        {
            try
            {
                string query = $"SELECT pd.PurchaseDetailID, pd.PurchaseID, pd.BookID, bk.Title, pd.PurchasePrice, pd.Quantity\r\nFROM PurchaseDetails pd\r\nINNER JOIN Books bk ON pd.BookID = bk.BookID\r\nWHERE pd.PurchaseID = {purchaseID}";
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất csdl", ex);
            }
        }

        public Result AddPurchaseDetail(PurchaseDetail purchaseDetail)
        {
            try
            {
                string query = $"INSERT INTO PurchaseDetails (PurchaseID, BookID, Quantity, PurchasePrice) VALUES ({purchaseDetail.PurchaseID}, {purchaseDetail.BookID}, {purchaseDetail.Quantity}, {purchaseDetail.PurchasePrice})";
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Thêm chi tiết đơn hàng thành công.");
                }
                else
                {
                    return new Result(false, "Thêm chi tiết đơn hàng thất bại.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi khi thêm chi tiết đơn hàng: " + ex.Message);
            }
        }

        public Result UpdatePurchaseDetail(PurchaseDetail purchaseDetail)
        {
            try
            {
                string query = $"UPDATE PurchaseDetails SET BookID = {purchaseDetail.BookID}, Quantity = {purchaseDetail.Quantity}, PurchasePrice = {purchaseDetail.PurchasePrice} WHERE PurchaseDetailID = {purchaseDetail.PurchaseDetailID}";
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Cập nhật chi tiết đơn hàng thành công.");
                }
                else
                {
                    return new Result(false, "Cập nhật chi tiết đơn hàng thất bại.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi khi cập nhật chi tiết đơn hàng: " + ex.Message);
            }
        }

        public Result DeletePurchaseDetail(int purchaseDetailID)
        {
            try
            {
                string query = $"DELETE FROM PurchaseDetails WHERE PurchaseDetailID = {purchaseDetailID}";
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Xóa chi tiết đơn hàng thành công.");
                }
                else
                {
                    return new Result(false, "Xóa chi tiết đơn hàng thất bại.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi khi xóa chi tiết đơn hàng: " + ex.Message);
            }
        }
    }
}
