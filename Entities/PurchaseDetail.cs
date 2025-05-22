using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PurchaseDetail
    {
        private int _purchaseDetailId;
        private int _purchaseId;
        private int _bookId;
        private int _quantity;
        private decimal _purchasePrice;

        public int PurchaseDetailID
        {
            get { return _purchaseDetailId; }
            set { _purchaseDetailId = value; }
        }
        public int PurchaseID
        {
            get { return _purchaseId; }
            set { _purchaseId = value; }
        }
        public int BookID
        {
            get { return _bookId; }
            set { _bookId = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set { _purchasePrice = value; }
        }

        public PurchaseDetail() { }

        public PurchaseDetail(int purchaseDetailId, int purchaseId, int bookId, int quantity, decimal purchasePrice)
        {
            _purchaseDetailId = purchaseDetailId;
            _purchaseId = purchaseId;
            _bookId = bookId;
            _quantity = quantity;
            _purchasePrice = purchasePrice;
        }
    }
}

