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
        private DAL_Customer _dalCustomer;
        private DAL_Employee _dalEmployee;
        public BLL_Order()
        {
            _dalOrder = new DAL_Order();
            _dalCustomer = new DAL_Customer();
            _dalEmployee = new DAL_Employee();
        }

        public bool IsLogicValidInputForAdd(Order order)
        {
            if(_dalCustomer.GetCustomerById(order.CustomerID).Rows.Count == 0)
            {
                throw new Exception("Khách hàng không tồn tại.");
            }
            if (_dalEmployee.GetEmployeeById(order.EmployeeID).Rows.Count == 0)
            {
                throw new Exception("Nhân viên không tồn tại.");
            }
            return true; // Logic for checking if the order can be added, e.g., checking if it already exists.
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
            try
            {
                if (IsLogicValidInputForAdd(order))
                {
                    return _dalOrder.AddOrder(order);
                }
                else
                {
                    throw new Exception("Đơn hàng không thể thêm do dữ liệu không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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


        public DataTable GetDayOrdersChartData(DateTime orderDate)
        {
            try
            {
                return _dalOrder.GetDayOrdersChartData(orderDate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable GetMonthOrdersChartData(int year, int month)
        {
            try
            {
                return _dalOrder.GetMonthOrdersChartData(year, month);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetYearOrdersChartData(int year)
        {
            try
            {
                return _dalOrder.GetYearOrdersChartData(year);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetRevenueByDate(DateTime orderDate)
        {
            try
            {
                return _dalOrder.GetRevenueByDate(orderDate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetDailyRevenueChartData(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _dalOrder.GetDailyRevenueChartData(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetMonthlyRevenueChartData(int year)
        {
            try
            {
                return _dalOrder.GetMonthlyRevenueChartData(year);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
