using System;

namespace Micro.Objects.ICAS.FINANCE
{
    [Serializable]
    public class VoucherDetails
    {
         public int VoucherDetailID
        {
            get;
            set;
        }

        public int VoucherID
        {
            get;
            set;
        }

        public int AccountLedgerID
        {
            get;
            set;
        }

        public string AccountLedgerDescription;

        public decimal VoucherAmount
        {
            get;
            set;
        }

        public string VoucherEntryType
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
