using System;

namespace Micro.Objects.ICAS.FINANCE
{
    [Serializable]
    public class Accounts_DailyTransactions
    {
        public int RecordNumber
        {
            get;
            set;
        }
        public string VoucherNumber
        {
            get;
            set;
        }
        public string TranDate
        {
            get;
            set;
        }
        public long TranNumber
        {
            get;
            set;
        }
        public int SerialNumber
        {
            get;
            set;
        }
        public int AccountsID
        {
            get;
            set;
        }
        public string AccountDescription
        {
            get;
            set;
        }
        public string AccountCode
        {
            get;
            set;
        }
        public string TranType
        {
            get;
            set;
        }
        public decimal TranAmount
        {
            get;
            set;
        }
        public string BalanceType
        {
            get;
            set;
        }
        public string Narration
        {
            get;
            set;
        }
        public string IsPosted
        {
            get;
            set;
        }
        public int PostedBy
        {
            get;
            set;
        }
        public string PostedDate
        {
            get;
            set;
        }
        public string PostMode
        {
            get;
            set;
        }
        public int AccountsYearID
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public int SocietyID
        {
            get;
            set;
        }
    }
}
