using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderDetail
    {
        private int _orderDetailId;
        private int _orderId;
        private int _bookId;
        private int _quantity;
        private decimal _sellPrice;

        public int OrderDetailId
        {
            get { return _orderDetailId; }
            set { _orderDetailId = value; }
        }
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal SellPrice
        {
            get { return _sellPrice; }
            set { _sellPrice = value; }
        }
        public OrderDetail()
        {
        }

        public OrderDetail(int orderDetailId, int orderId, int bookId, int quantity, decimal sellPrice)
        {
            _orderDetailId = orderDetailId;
            _orderId = orderId;
            _bookId = bookId;
            _quantity = quantity;
            _sellPrice = sellPrice;
        }
    }
}
