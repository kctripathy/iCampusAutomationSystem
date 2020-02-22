using System;
using System.Collections.Generic;

namespace Micro.Objects.ICAS.FINANCE
{

    public class TempTransaction
    {

        public int TranOfficeID
        {
            get;
            set;
        }
        public int TransactionID
        {
            get;
            set;
        }

        public DateTime TransactionDate
        {
            get;
            set;
        }

        public string VoucherNumber
        {
            get;
            set;
        }

        public string Narration
        {
            get;
            set;
        }

        public List<TempTranAccount> TempTranAccountList
        {
            get;
            set;
        }

        public decimal TotalDebitAmount
        {
            get;
            set;
        }

        public decimal TotalCreditAmount
        {
            get;
            set;
        }
    }
    public class TempTranAccount
    {
        public int AccountID
        {
            get;
            set;
        }

        public string AccountCode
        {
            get;
            set;
        }

        public string AccountName
        {
            get;
            set;
        }

        public string BalanceType
        {
            get;
            set;
        }

        public decimal TranAmount
        {
            get;
            set;
        }



    }
    public class CurrentSavingAccountTransaction
    {
        public string DateOfTransaction
        {
            get;
            set;
        }
        public string Particulars
        {
            get;
            set;
        }
        public decimal CreditAmount
        {
            get;
            set;
        }
        public decimal DebitAmount
        {
            get;
            set;
        }
        public string ChallanNo
        {
            get;
            set;
        }
        public decimal TotalBalance
        {
            get;
            set;
        }
    }
}
