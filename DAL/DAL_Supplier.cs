using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class DAL_Supplier : DbConnect
    {
        public DataTable GetAllSupplieres()
        {
            string query = "SELECT * FROM Suppliers";
            return ExecuteQuery(query);
        }

        public DataTable GetById(int supplierId)
        {
            string query = $"SELECT * FROM Suppliers WHERE SupplierId = {supplierId}";
            return ExecuteQuery(query);
        }

        public int Insert(Supplier supplier)
        {
            string query = $"INSERT INTO Suppliers (Name, Phone, Address) VALUES (N'{supplier.Name}', '{supplier.Phone}', N'{supplier.Address}')";
            return ExecuteNonQuery(query);
        }
        public int Update(Supplier supplier)
        {
            string query = $"UPDATE Suppliers SET Name = N'{supplier.Name}', Phone = '{supplier.Phone}', Address = N'{supplier.Address}' WHERE SupplierId = {supplier.SupplierId}";
            return ExecuteNonQuery(query);
        }
        public int Delete(int supplierId)
        {
            string query = $"DELETE FROM Suppliers WHERE SupplierId = {supplierId}";
            return ExecuteNonQuery(query);
        }

        public DataTable Search(string searchTerm)
        {
            string query = $"SELECT * FROM Suppliers WHERE Name LIKE N'%{searchTerm}%' OR Phone LIKE '%{searchTerm}%' OR Address LIKE N'%{searchTerm}%' OR SupplierID = {searchTerm}";
            return ExecuteQuery(query);
        }

        public DataTable SearchByName(string name)
        {
            string query = $"SELECT * FROM Suppliers WHERE Name LIKE N'%{name}%'";
            return ExecuteQuery(query);
        }

        public DataTable SearchByPhone(string phone)
        {
            string query = $"SELECT * FROM Suppliers WHERE Phone LIKE '%{phone}%'";
            return ExecuteQuery(query);
        }

        public DataTable SearchByAddress(string address)
        {
            string query = $"SELECT * FROM Suppliers WHERE Address LIKE N'%{address}%'";
            return ExecuteQuery(query);
        }

    }
}
