using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Hotel
{
    [Serializable]
    public partial class Bill
    {
        public int BillID
        {
            get;
            set;
        }
        public DateTime BillDate
        {

            get;
            set;
        }
        public int CustomerID
        {
            get;
            set;
        }
        public decimal BillAmount
        {
            get;
            set;
        }
        public decimal GrossAmount
        {
            get;
            set;
        }
        public decimal Taxes
        {
            get;
            set;
        }
        public decimal Discount
        {
            get;
            set;
        }
        public decimal NetAmount
        {
            get;
            set;
        }
        public string BillStatus
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }
    }
}
