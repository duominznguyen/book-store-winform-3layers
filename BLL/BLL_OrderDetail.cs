using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
namespace BLL
{
    public class BLL_OrderDetail
    {
        private DAL_OrderDetail _dalOrderDetail;
        private DAL_Employee _dalEmployee;
        private DAL_Book _dalBook;
        public BLL_OrderDetail()
        {
            _dalOrderDetail = new DAL_OrderDetail();
            _dalEmployee = new DAL_Employee();
            _dalBook = new DAL_Book();
        }

        public DataTable GetOrderDetailByOrderID(int orderId)
        {
            return _dalOrderDetail.GetOrderDetailsByOrderId(orderId);
        }

        public DataTable GetOrderDetail_BookByOrderID(int orderId)
        {
            return _dalOrderDetail.GetOrderDetails_BookByOrderId(orderId);
        }

        private Result IsLogicValidInputForAdd(OrderDetail orderDetail)
        {
            if (_dalBook.GetBookByID(orderDetail.BookId.ToString()).Rows.Count == 0)
            {
                return new Result(false, "Sách không tồn tại trong hệ thống.");
            }

            if (_dalBook.GetBookQuantity(orderDetail.BookId) < orderDetail.Quantity)
            {
                return new Result(false, "Số lượng sách không đủ.");
            }
            return new Result(true, "");

        }

        private Result IsLogicValidForUpdatingOrderDetail(OrderDetail orderDetail)
        {
            if (_dalOrderDetail.GetOrderDetailsByOrderDetailId(orderDetail.OrderDetailId).Rows.Count == 0)
            {
                return new Result(false, "Đơn hàng không tồn tại trong hệ thống.");
            }
            if (_dalBook.GetBookByID(orderDetail.BookId.ToString()).Rows.Count == 0)
            {
                return new Result(false, "Sách không tồn tại trong hệ thống.");
            }
            if (_dalOrderDetail.GetSelledBookQuantityByOrderDetailID(orderDetail.OrderDetailId) + _dalBook.GetBookQuantity(orderDetail.BookId) < orderDetail.Quantity)
            {
                return new Result(false, "Số lượng sách không đủ.");
            }
            return new Result(true, "");
        }

        private Result IsLogicValidForDeletingOrderDetail(int orderDetailId)
        {
            if (_dalOrderDetail.GetOrderDetailsByOrderDetailId(orderDetailId).Rows.Count == 0)
            {
                return new Result(false, "(BLL)Đơn hàng không tồn tại trong hệ thống.");
            }
            return new Result(true, "");
        }


        public Result AddOrderDetail(OrderDetail orderDetail)
        {
            Result isLogicValid = IsLogicValidInputForAdd(orderDetail);
            if (isLogicValid.IsSuccess)
            {
                bool isAdded = _dalOrderDetail.AddOrderDetail(orderDetail);
                if (isAdded)
                {
                    return new Result(true, "Thêm chi tiết đơn hàng thành công.");
                }
                else
                {
                    return new Result(false, "Thêm chi tiết đơn hàng thất bại.");
                }
            }
            else
            {
                return isLogicValid;
            }

        }

        public Result UpdateOrderDetail(OrderDetail orderDetail)
        {
            Result isLogicValid = IsLogicValidForUpdatingOrderDetail(orderDetail);
            if (isLogicValid.IsSuccess)
            {
                bool isUpdated = _dalOrderDetail.UpdateOrderDetail(orderDetail);
                if (isUpdated)
                {
                    return new Result(true, "Cập nhật chi tiết đơn hàng thành công.");
                }
                else
                {
                    return new Result(false, "Cập nhật chi tiết đơn hàng thất bại.");
                }
            }
            else
            {
                return isLogicValid;
            }
        }

        public Result DeleteOrderDetail(int orderDetailId)
        {
            Result isLogicValid = IsLogicValidForDeletingOrderDetail(orderDetailId);
            if (isLogicValid.IsSuccess)
            {
                bool isDeleted = _dalOrderDetail.DeleteOrderDetail(orderDetailId);
                if (isDeleted)
                {
                    return new Result(true, "Xóa chi tiết đơn hàng thành công.");
                }
                else
                {
                    return new Result(false, "Xóa chi tiết đơn hàng thất bại.");
                }
            }
            else
            {
                return isLogicValid;
            }
        }


        public DataTable GetOrderPrint(int orderId)
        {
            return _dalOrderDetail.GetOrderPrint(orderId);
        }

    }
}
