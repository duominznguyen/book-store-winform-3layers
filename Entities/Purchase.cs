using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Purchase
    {
        private int _purchaseId;
        private DateTime _purchaseDate;
        private int _supplierId;
        private int _employeeId;

        public int PurchaseID
        {
            get { return _purchaseId; }
            set { _purchaseId = value; }
        }
        public DateTime PurchaseDate
        {
            get { return _purchaseDate; }
            set { _purchaseDate = value; }
        }

        public int SupplierID
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }
        public int EmployeeID
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public Purchase(int purchaseId, DateTime purchaseDate, int supplierId, int employeeId)
        {
            _purchaseId = purchaseId;
            _purchaseDate = purchaseDate;
            _supplierId = supplierId;
            _employeeId = employeeId;
        }
    }
}
