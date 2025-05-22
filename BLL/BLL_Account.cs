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
    public class BLL_Account
    {
        private DAL_Account _dalAccount;
        private DAL_Employee _dalEmployee;
        public BLL_Account()
        {
            _dalAccount = new DAL_Account();
            _dalEmployee = new DAL_Employee();
        }
        public bool LogIn(string userName, string password)
        {
            return _dalAccount.LogIn(userName, password);
        }

        public Account GetAccount(string userName, string password)
        {
            return _dalAccount.GetAccount(userName, password);
        }
        

        public DataTable GetAllAccount_Employee()
        {
            try
            {
                return _dalAccount.GetAllAccount_Employee();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        private Result IsLogicValidForAdding(Account account)
        {
            if (_dalAccount.IsExistAccount(account.Username))
            {
                return new Result(false, "Tài khoản đã tồn tại");
            }
            if (_dalEmployee.GetEmployeeById(account.EmployeeId).Rows.Count == 0)
            {
                return new Result(false, "Nhân viên không tồn tại");
            }

            return new Result(true, "");
        }

        public Result AddAccount(Account account)
        {
            try
            {
                Result result = IsLogicValidForAdding(account);
                if (!result.IsSuccess)
                {
                    return result;
                }
                return _dalAccount.AddAccount(account);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        private Result IsLogicValidForUpdating(Account account)
        {
            if (!_dalAccount.IsExistAccount(account.Username))
            {
                return new Result(false, "Tài khoản không tồn tại");
            }
            return new Result(true, "");
        }

        public Result UpdateAccount(Account account)
        {
            try
            {
                Result result = IsLogicValidForUpdating(account);
                if (!result.IsSuccess)
                {
                    return result;
                }
                return _dalAccount.UpdateAccount(account);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        private Result IsLogicValidForDeleting(string username)
        {
            if (!_dalAccount.IsExistAccount(username))
            {
                return new Result(false, "Tài khoản không tồn tại");
            }
            return new Result(true, "");
        }

        public Result DeleteAccount(string username)
        {
            try
            {
                Result result = IsLogicValidForDeleting(username);
                if (!result.IsSuccess)
                {
                    return result;
                }
                return _dalAccount.DeleteAccount(username);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }


        }
    }
}
