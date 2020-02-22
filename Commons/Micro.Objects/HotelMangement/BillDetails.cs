using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Hotel
{
    [Serializable]
    public partial class BillDetail
    {
        public int BillDetailID
        {
            get;
            set;
        }
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

        public int ItemID
        {
            get;
            set;
        }
        public int ItemQuantity
        {
            get;
            set;
        }
        public string QuantityOfMesurement
        {
            get;
            set;
        }
        public string PriceUnit
        {
            get;
            set;
        }
        public decimal PriceTotal
        {
            get;
            set;
        }

    }
}
