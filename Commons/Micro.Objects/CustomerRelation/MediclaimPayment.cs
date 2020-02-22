using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class MediclaimPayment
    {
        public int MediclaimPaymentID
        {
            get;
            set;
        }

        public int MediclaimApplicationID
        {
            get;
            set;
        }

        public string CustomerCode
        {
            get;
            set;
        }

        public string CustomerName
        {
            get;
            set;
        }

        public string PaymentDate
        {
            get;
            set;
        }

        public decimal AmountPaid
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
    }
}
