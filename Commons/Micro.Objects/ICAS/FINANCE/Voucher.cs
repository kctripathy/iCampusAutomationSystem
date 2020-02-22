using System;

namespace Micro.Objects.ICAS.FINANCE
{
    [Serializable]
    public class Voucher
    {
        public int VoucherID
        {
            get;
            set;
        }

        public string VoucherCode
        {
            get;
            set;
        }

        public string VoucherType
        {
            get;
            set;
        }

        public string VoucherDate
        {
            get;
            set;
        }

        public string VoucherNarration
        {
            get;
            set;
        }

        public bool IsPosted
        {
            get;
            set;
        }

        public int OfficeID
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
