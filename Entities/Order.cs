using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        private int _orderId;
        private DateTime _orderDate;
        private int _employeeId;
        private int _customerId;

        public int OrderID
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
        public int EmployeeID
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }
        public int CustomerID
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public Order() { }
        public Order(int orderId, DateTime orderDate, int employeeId, int customerId)
        {
            _orderId = orderId;
            _orderDate = orderDate;
            _employeeId = employeeId;
            _customerId = customerId;
        }
    }
}
