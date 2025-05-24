using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data;

namespace BLL
{
    public class BLL_PurchaseDetail
    {
        private DAL_PurchaseDetail _dalPurchaseDetail;
        private DAL_Book _dalBook;

        public BLL_PurchaseDetail()
        {
            _dalPurchaseDetail = new DAL_PurchaseDetail();
            _dalBook = new DAL_Book();
        }

        public DataTable GetPurchaseDetailsByPurchaseId(int purchaseID)
        {
            try
            {
                return _dalPurchaseDetail.GetPurchaseDetailViewByPurchaseID(purchaseID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất chi tiết đơn hàng: " + ex.Message);
            }
        }

        private Result IsLogicValidForAddingPurchaseDetail(PurchaseDetail purchaseDetail)
        {
            if (_dalBook.GetBookByID(purchaseDetail.BookID).Rows.Count == 0)
            {
                return new Result(false, "Mã sách không tồn tại.");
            }


            return new Result(true, "");
        }

        public Result AddPurchaseDetail(PurchaseDetail purchaseDetail)
        {
            try
            {
                Result result = IsLogicValidForAddingPurchaseDetail(purchaseDetail);
                if (result.IsSuccess)
                {


                    return _dalPurchaseDetail.AddPurchaseDetail(purchaseDetail);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi khi thêm chi tiết đơn hàng: " + ex.Message);
            }
        }

        private Result IsLogicValidForUpdatingPurchaseDetail(PurchaseDetail purchaseDetail)
        {
            if (_dalBook.GetBookByID(purchaseDetail.BookID).Rows.Count == 0)
            {
                return new Result(false, "Mã sách không tồn tại.");
            }

            return new Result(true, "");
        }

        public Result UpdatePurchaseDetail(PurchaseDetail purchaseDetail)
        {
            try
            {
                Result result = IsLogicValidForUpdatingPurchaseDetail(purchaseDetail);
                if (result.IsSuccess)
                {
                    return _dalPurchaseDetail.UpdatePurchaseDetail(purchaseDetail);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi khi cập nhật chi tiết đơn hàng: " + ex.Message);
            }
        }

        private Result IsLogicValidForDeletingPurchaseDetail(int purchaseDetailID)
        {
            return new Result(true, "");
        }

        public Result DeletePurchaseDetail(int purchaseDetailID)
        {
            try
            {
                Result result = IsLogicValidForDeletingPurchaseDetail(purchaseDetailID);
                if (result.IsSuccess)
                {
                    return _dalPurchaseDetail.DeletePurchaseDetail(purchaseDetailID);
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Lỗi khi xóa chi tiết đơn hàng: " + ex.Message);
            }
        }


        public DataTable GetPurchaseReportData(int purchaseID)
        {
            try
            {
                return _dalPurchaseDetail.GetPurchaseReportData(purchaseID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
