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
    public class BLL_Customer
    {
        private DAL_Customer _dalCustomer;
        public BLL_Customer()
        {
            _dalCustomer = new DAL_Customer();
        }

        public DataTable GetAllCustomers()
        {
            try
            {
                return _dalCustomer.GetAllCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }
        }

        public DataTable GetCustomerById(int customerId)
        {
            try
            {
                return _dalCustomer.GetCustomerById(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
        }

        public DataTable SearchCustomers(string searchOption, string searchTerm)
        {
            try
            {
                return _dalCustomer.SearchCustomers(searchOption, searchTerm);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
        }

        private Result IsLogicValidForAddingCustomer(Customer customer)
        {
            return new Result(true, "");
        }
        public Result AddCustomer(Customer customer)
        {
            Result isLogicValid = IsLogicValidForAddingCustomer(customer);
            if (isLogicValid.IsSuccess)
            {
                return _dalCustomer.AddCustomer(customer);
            }
            else
            {
                return isLogicValid;
            }
        }

        private Result IsLogicValidForUpdatingCustomer(Customer customer)
        {
            // logic to check if the customer can be updated
            // 1.Check if the customer ID not exists
            if (_dalCustomer.GetCustomerById(customer.CustomerID).Rows.Count == 0)
            {
                return new Result(false, "Mã khách hàng không tồn tại.");
            }
            return new Result(true, "");
        }

        public Result UpdateCustomer(Customer customer)
        {
            Result isLogicValid = IsLogicValidForUpdatingCustomer(customer);
            if (isLogicValid.IsSuccess)
            {
                return _dalCustomer.UpdateCustomer(customer);
            }
            else
            {
                return isLogicValid;
            }
        }

        private Result IsLogicValidForDeletingCustomer(int customerId)
        {
            // logic to check if the customer can be deleted
            // 1.Check if the customer ID not exists
            if (_dalCustomer.GetCustomerById(customerId).Rows.Count == 0)
            {
                return new Result(false, "Mã khách hàng không tồn tại.");
            }
            return new Result(true, "");
        }

        public Result DeleteCustomer(int customerId)
        {
            Result isLogicValid = IsLogicValidForDeletingCustomer(customerId);
            if (isLogicValid.IsSuccess)
            {
                return _dalCustomer.DeleteCustomer(customerId);
            }
            else
            {
                return isLogicValid;
            }
        }

    }
}
