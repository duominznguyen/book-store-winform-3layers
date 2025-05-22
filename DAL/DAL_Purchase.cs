using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class DAL_Purchase : DbConnect
    {
        //public DataTable GetAllPurchases()
        //{
        //    try
        //    {
        //        string query = "SELECT * FROM Purchases";
        //        DataTable dataTable = ExecuteQuery(query);
        //        return dataTable;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
        //    }
        //}

        public DataTable GetAllPurchases()
        {
            try
            {
                string query = "SELECT pc.PurchaseID, pc.PurchaseDate, em.EmployeeID, em.Name AS EmployeeName, pc.SupplierID, sp.Name AS SupplierName\r\nFROM Purchases pc\r\nINNER JOIN Suppliers sp ON pc.SupplierID = sp.SupplierID\r\nINNER JOIN Employees em ON pc.EmployeeID = em.EmployeeID";
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
        }

        public DataTable GetPurchaseByID(int purchaseID)
        {
            try
            {
                string query = $"SELECT * FROM Purchases WHERE PurchaseID = {purchaseID}";
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
        }

        public Result AddPurchase(Purchase purchase)
        {
            try
            {
                string query = $"INSERT INTO Purchases (PurchaseID, PurchaseDate, SupplierID, EmployeeID) VALUES ({purchase.PurchaseID}, '{purchase.PurchaseDate}', {purchase.SupplierID}, {purchase.EmployeeID})";
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Thêm đơn hàng thành công");
                }
                else
                {
                    return new Result(false, "Thêm đơn hàng thất bại");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
        }

        public Result UpdatePurchase(Purchase purchase)
        {
            try
            {
                string query = $"UPDATE Purchases SET PurchaseDate = '{purchase.PurchaseDate}', SupplierID = {purchase.SupplierID}, EmployeeID = {purchase.EmployeeID} WHERE PurchaseID = {purchase.PurchaseID}";
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Cập nhật đơn hàng thành công");
                }
                else
                {
                    return new Result(false, "Cập nhật đơn hàng thất bại");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
        }

        public Result DeletePurchase(int purchaseId)
        {
            try
            {
                string query = $"DELETE FROM Purchases WHERE PurchaseID = {purchaseId}";
                int rowsAffected = ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    return new Result(true, "Xóa đơn hàng thành công");
                }
                else
                {
                    return new Result(false, "Xóa đơn hàng thất bại");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
        }


    }
}
