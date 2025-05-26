using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data;
using System.Configuration;

namespace BLL
{
    public class BLL_Purchase
    {
        private DAL_Purchase _dalPurchase;
        private DAL_Supplier _dalSupplier;
        private DAL_Employee _dalEmployee;

        

        public BLL_Purchase()
        {
            _dalPurchase = new DAL_Purchase();
            _dalSupplier = new DAL_Supplier();
            _dalEmployee = new DAL_Employee();
        }

        public DataTable GetAllPurchases()
        {
            try
            {
                return _dalPurchase.GetAllPurchases();
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
                return _dalPurchase.GetPurchaseByID(purchaseID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private Result IsLogicValidForAddingPurchase(Purchase purchase)
        {
            if (_dalPurchase.GetPurchaseByID(purchase.PurchaseID).Rows.Count > 0)
            {
                return new Result(false, "Mã đơn hàng đã tồn tại");
            }

            if (_dalSupplier.GetById(purchase.SupplierID).Rows.Count == 0)
            {
                return new Result(false, "Mã nhà cung cấp không tồn tại");
            }

            if (_dalEmployee.GetEmployeeById(purchase.EmployeeID).Rows.Count == 0)
            {
                return new Result(false, "Mã nhân viên không tồn tại");
            }

            return new Result(true, "");
        }

        public Result AddPurchase(Purchase purchase)
        {
            try
            {
                Result validationResult = IsLogicValidForAddingPurchase(purchase);
                if (validationResult.IsSuccess)
                {
                    return _dalPurchase.AddPurchase(purchase);
                }
                else
                {
                    return validationResult;
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
        }


        private Result IsLogicValidForUpdatingPurchase(Purchase purchase)
        {
            if (_dalPurchase.GetPurchaseByID(purchase.PurchaseID).Rows.Count == 0)
            {
                return new Result(false, "Mã đơn hàng không tồn tại");
            }

            if (_dalSupplier.GetById(purchase.SupplierID).Rows.Count == 0)
            {
                return new Result(false, "Mã nhà cung cấp không tồn tại");
            }

            if (_dalEmployee.GetEmployeeById(purchase.EmployeeID).Rows.Count == 0)
            {
                return new Result(false, "Mã nhân viên không tồn tại");
            }


            return new Result(true, "");
        }

        public Result UpdatePurchase(Purchase purchase)
        {
            try
            {
                Result validationResult = IsLogicValidForUpdatingPurchase(purchase);
                if (validationResult.IsSuccess)
                {
                    return _dalPurchase.UpdatePurchase(purchase);
                }
                else
                {
                    return validationResult;
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
        }

        private Result IsLogicValidForDeletingPurchase(int purchaseID)
        {
            if (_dalPurchase.GetPurchaseByID(purchaseID).Rows.Count == 0)
            {
                return new Result(false, "Mã đơn hàng không tồn tại");
            }
            return new Result(true, "");
        }

        public Result DeletePurchase(int purchaseID)
        {
            try
            {
                Result validationResult = IsLogicValidForDeletingPurchase(purchaseID);
                if (validationResult.IsSuccess)
                {
                    return _dalPurchase.DeletePurchase(purchaseID);
                }
                else
                {
                    return validationResult;
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi truy xuất cơ sở dữ liệu: " + ex.Message);
            }
        }


        public DataTable SearchPurchases(string searchOption, string searchValue)
        {
            try
            {
                DataTable purchases = _dalPurchase.GetAllPurchases();
                
                switch(searchOption)
                {
                    case "PurchaseID":
                        return purchases.AsEnumerable()
                            .Where(row => row.Field<int>("PurchaseID").ToString().Contains(searchValue))
                            .CopyToDataTable();
                    case "PurchaseDate":
                        return purchases.AsEnumerable()
                            .Where(row => row.Field<DateTime>("PurchaseDate").ToString("dd/MM/yyyy").Contains(searchValue))
                            .CopyToDataTable();
                    case "SupplierID":
                        return purchases.AsEnumerable()
                            .Where(row => row.Field<int>("SupplierID").ToString().Contains(searchValue))
                            .CopyToDataTable();
                    case "SupplierName":
                        // tôi muốn tìm kiếm không phân biệt chữ hoa chữ thường
                        return purchases.AsEnumerable()
                            .Where(row => row.Field<string>("SupplierName").IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                            .CopyToDataTable();

                    case "EmployeeID":
                        return purchases.AsEnumerable()
                            .Where(row => row.Field<int>("EmployeeID").ToString().Contains(searchValue))
                            .CopyToDataTable();
                    case "EmployeeName":
                        return purchases.AsEnumerable()
                            .Where(row => row.Field<string>("EmployeeName").IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                            .CopyToDataTable();
                    case "General":
                        return purchases.AsEnumerable()
                            .Where(row => row.Field<int>("PurchaseID").ToString().Contains(searchValue) ||
                                          row.Field<DateTime>("PurchaseDate").ToString("dd/MM/yyyy").Contains(searchValue) ||
                                          row.Field<int>("SupplierID").ToString().Contains(searchValue) ||
                                          row.Field<string>("SupplierName").IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                          row.Field<int>("EmployeeID").ToString().Contains(searchValue) ||
                                          row.Field<string>("EmployeeName").IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                            .CopyToDataTable();
                    default:
                        throw new Exception("Tùy chọn tìm kiếm không hợp lệ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm đơn hàng: " + ex.Message);
            }
        }
    }

}
