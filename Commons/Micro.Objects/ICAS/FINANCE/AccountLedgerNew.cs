using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.FINANCE
{
    [Serializable]
    public class AccountLedgerNew
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

        public string AccountDescription
        {
            get;
            set;
        }

        public int AccountGroupID
        {
            get;
            set;
        }

        public string AccountGroupDescription
        {
            get;
            set;
        }

        public int ParentAccountGroupID
        {
            get;
            set;
        }

        public string ParentAccountGroupDescription
        {
            get;
            set;
        }

        public string BalanceType
        {
            get;
            set;
        }

        public decimal Debit
        {
            get;
            set;
        }

        public decimal Credit
        {
            get;
            set;
        }
        //public int OfficeID
        //{
        //    get;
        //    set;
        //}

        //public int SocietyID
        //{
        //    get;
        //    set;
        //}
    }
}
