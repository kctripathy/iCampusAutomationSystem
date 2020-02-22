using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class DCReceipt
    {
        public int DCReceiptID
        {
            get;
            set;
        }

        public int DCAccountID
        {
            get;
            set;
        }

        public string DCReceiptDate
        {
            get;
            set;
        }

        public decimal DCReceiptAmount
        {
            get;
            set;
        }

        public string DCReceiptNumber
        {
            get;
            set;
        }

        public int DCCollectorID
        {
            get;
            set;
        }

        public int DCDeviceID
        {
            get;
            set;
        }

        public string DCPaymentMode
        {
            get;
            set;
        }

        public string DCPaymentReference
        {
            get;
            set;
        }

        public string DCAmountActualCollectionDateTime
        {
            get;
            set;
        }

        public bool IsCancelled
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
        public string DCAccountCode
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }
        public int CollectorID
        {
            get;
            set;
        }
        public string DCCollectorName
        {
            get;
            set;
        }
        public string DCCollectorCode
        {
            get;
            set;
        }
        public string DCDeviceCode
        {
            get;
            set;
        }
        public string DCDeviceSerialNumber
        {
            get;
            set;
        }
        public int CancelledReceiptID
        {
            get;
            set;
        }

       
    }
}
