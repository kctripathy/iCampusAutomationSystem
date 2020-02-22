using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class PaymentsBrokerage
    {
        public int PaymentsBrokerageID
        {
            get;
            set;
        }

        public string FromDate
        {
            get;
            set;
        }

        public string ToDate
        {
            get;
            set;
        }

        public int FieldForceID
        {
            get;
            set;
        }

        public string FieldForceCode
        {
            get;
            set;
        }

        public string FieldForceName
        {
            get;
            set;
        }

        public string FieldStaffRank
        {
            get;
            set;
        }

        public decimal BrokerageAmount
        {
            get;
            set;
        }

        public string BrokerageType
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public string PaymentMode
        {
            get;
            set;
        }

        public string BankAccountNumber
        {
            get;
            set;
        }

        public int ForMonth
        {
            get;
            set;
        }

        public int ForYear
        {
            get;
            set;
        }

        public string BusinessType
        {
            get;
            set;
        }

        public decimal BusinessAmount
        {
            get;
            set;
        }
    }
}
