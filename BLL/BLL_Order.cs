using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLL_Order
    {
        private DAL_Order _dalOrder;
        public BLL_Order()
        {
            _dalOrder = new DAL_Order();
        }

        public bool IsLogicValidInputForAdd(Order order)
        {
            bool IsNotExistOrder = _dalOrder.GetOrderById(order.OrderID).Rows.Count == 0;
            return IsNotExistOrder;
        }

        public bool IsLogicValidInputForUpdate(Order order)
        {
            bool IsExistOrder = _dalOrder.GetOrderById(order.OrderID).Rows.Count > 0;
            return IsExistOrder;
        }
        public bool IsLogicValidInputForDelete(int orderId)
        {
            bool IsExistOrder = _dalOrder.GetOrderById(orderId).Rows.Count > 0;
            return IsExistOrder;
        }

        public bool AddOrder(Order order)
        {
            if (IsLogicValidInputForAdd(order))
            {
                return _dalOrder.AddOrder(order);
            }
            else
            {
                throw new Exception("Đơn hàng đã tồn tại trong hệ thống.");
            }
        }
        public bool UpdateOrder(Order order)
        {
            if (IsLogicValidInputForUpdate(order))
            {
                return _dalOrder.UpdateOrder(order);
            }
            else
            {
                throw new Exception("Đơn hàng không tồn tại.");
            }
        }
        public bool DeleteOrder(int orderId)
        {
            if (IsLogicValidInputForDelete(orderId))
            {
                return _dalOrder.DeleteOrder(orderId);
            }
            else
            {
                throw new Exception("Đơn hàng không tồn tại.");
            }
        }

        public DataTable SearchOrder(string SearchOption, string SearchValue)
        {
            DataTable dt = new DataTable();
            switch (SearchOption)
            {
                case "Mã Đơn Bán":
                    dt = _dalOrder.GetOrderById(int.Parse(SearchValue));
                    break;
                case "Ngày Bán":
                    dt = _dalOrder.GetOrderByOrderDate(DateTime.Parse(SearchValue));
                    break;
                case "Mã Nhân Viên":
                    dt = _dalOrder.GetOrderByEmployeeId(int.Parse(SearchValue));
                    break;
                case "Mã Khách Hàng":
                    dt = _dalOrder.GetOrderByCustomerId(int.Parse(SearchValue));
                    break;
                default:
                    throw new Exception("Invalid search option.");
            }
            return dt;
        }


        public DataTable GetAllOrder()
        {
            return _dalOrder.GetAllOrder();
        }

        public DataTable GetOrderById(int orderId)
        {
            try
            {
                return _dalOrder.GetOrderById(orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
