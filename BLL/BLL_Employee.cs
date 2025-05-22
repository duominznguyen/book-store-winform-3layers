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
    public class BLL_Employee
    {
        private DAL_Employee _dalEmployee;
        public BLL_Employee()
        {
            _dalEmployee = new DAL_Employee();
        }

        public DataTable GetAllEmployees()
        {
            try
            {
                return _dalEmployee.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
        }

        public DataTable GetEmployeeById(int employeeId)
        {
            try
            {
                return _dalEmployee.GetEmployeeById(employeeId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin nhân viên: " + ex.Message);
            }
        }

        public DataTable SearchEmployees(string searchOption, string searchTerm)
        {
            try
            {
                return _dalEmployee.SearchEmployees(searchOption, searchTerm);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }
        }

        private Result IsLogicValidForAddingEmployee(Employee employee)
        {
            // logic to check if the employee can be added
            // 1.Check if the employee ID already exists
            if (_dalEmployee.GetEmployeeById(employee.EmployeeID).Rows.Count > 0)
            {
                return new Result(false, "Mã nhân viên đã tồn tại.");
            }
            return new Result(true, "");
        }

        public Result AddEmployee(Employee employee)
        {
            Result isValid = IsLogicValidForAddingEmployee(employee);
            if (isValid.IsSuccess)
            {
                return _dalEmployee.AddEmployee(employee);
            }
            else
            {
                return isValid;
            }
        }


        private Result IsLogicValidForUpdatingEmployee(Employee employee)
        {
            // logic to check if the employee can be updated
            // 1.Check if the employee ID exists
            if (_dalEmployee.GetEmployeeById(employee.EmployeeID).Rows.Count == 0)
            {
                return new Result(false, "Mã nhân viên không tồn tại.");
            }
            return new Result(true, "");
        }

        public Result UpdateEmployee(Employee employee)
        {
            Result isValid = IsLogicValidForUpdatingEmployee(employee);
            if (isValid.IsSuccess)
            {
                return _dalEmployee.UpdateEmployee(employee);
            }
            else
            {
                return isValid;
            }
        }


        private Result IsLogicValidForDeletingEmployee(int employeeId)
        {
            // logic to check if the employee can be deleted
            // 1.Check if the employee ID exists
            if (_dalEmployee.GetEmployeeById(employeeId).Rows.Count == 0)
            {
                return new Result(false, "Mã nhân viên không tồn tại.");
            }
            return new Result(true, "");
        }

        public Result DeleteEmployee(int employeeId)
        {
            Result isValid = IsLogicValidForDeletingEmployee(employeeId);
            if (isValid.IsSuccess)
            {
                return _dalEmployee.DeleteEmployee(employeeId);
            }
            else
            {
                return isValid;
            }
        }



    }
}
