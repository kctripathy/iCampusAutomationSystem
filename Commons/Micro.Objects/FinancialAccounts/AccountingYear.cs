using System;

namespace Micro.Objects.FinancialAccounts
{
    [Serializable]
    public class AccountingYear
    {
        public int AccountingYearID
        {
            get;
            set;
        }

        public string AccountingYearDescription
        {
            get;
            set;
        }

        public string YearStartDate
        {
            get;
            set;
        }

        public string YearEndDate
        {
            set;
            get;
        }
    }
}