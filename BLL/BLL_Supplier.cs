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
    public class BLL_Supplier
    {
        private DAL_Supplier _dalSupplier;
        public BLL_Supplier()
        {
            _dalSupplier = new DAL_Supplier();
        }

        public DataTable GetAllSuppliers()
        {
            return _dalSupplier.GetAllSupplieres();
        }

        public DataTable GetSupplierById(int supplierId)
        {
            return _dalSupplier.GetById(supplierId);
        }

        public DataTable SearchSuppliers(string searchTerm)
        {
            return _dalSupplier.Search(searchTerm);
        }

        public DataTable SearchSuppliersByName(string name)
        {
            return _dalSupplier.SearchByName(name);
        }

        public DataTable SearchSuppliersByPhone(string phone)
        {
            return _dalSupplier.SearchByPhone(phone);
        }

        public DataTable SearchSuppliersByAddress(string address)
        {
            return _dalSupplier.SearchByAddress(address);
        }


        public bool IsLogicValidSupplierForAdding(Supplier supplier)
        {
            if (_dalSupplier.GetById(supplier.SupplierId).Rows.Count > 0)
            {
                throw new Exception("Mã nhà cung cấp đã tồn tại");
            }
            return true;
        }

        public bool IsLogicValidSupplierForUpdating(Supplier supplier)
        {
            if (_dalSupplier.GetById(supplier.SupplierId).Rows.Count == 0)
            {
                throw new Exception("Mã nhà cung cấp không tồn tại");
            }
            return true;
        }

        public bool IsLogicValidSupplierForDeleting(int supplierId)
        {
            if (_dalSupplier.GetById(supplierId).Rows.Count == 0)
            {
                throw new Exception("Mã nhà cung cấp không tồn tại");
            }
            return true;
        }



        public bool AddSupplier(Supplier supplier)
        {
            if (!IsLogicValidSupplierForAdding(supplier))
            {
                return false;
            }
            return _dalSupplier.Insert(supplier) > 0;
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            if (!IsLogicValidSupplierForUpdating(supplier))
            {
                return false;
            }
            return _dalSupplier.Update(supplier) > 0;
        }

        public bool DeleteSupplier(int supplierId)
        {
            if (!IsLogicValidSupplierForDeleting(supplierId))
            {
                return false;
            }
            return _dalSupplier.Delete(supplierId) > 0;
        }
    }
}
