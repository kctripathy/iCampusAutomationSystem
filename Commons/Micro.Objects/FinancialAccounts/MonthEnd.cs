using System;

namespace Micro.Objects.FinancialAccounts
{
    [Serializable]
    public class MonthEnd
    {
        public int MonthEndID
        {
            get;
            set;
        }

        public string DateFrom
        {
            get;
            set;
        }

        public string DateTo
        {
            get;
            set;
        }

        public int GraceDays
        {
            get;
            set;
        }

        public string ClosingDate
        {
            get;
            set;
        }

        public bool Status
        {
            get;
            set;
        }

        public int OfficeID
        {
            get;
            set;
        }

        public string OfficeName
        {
            get;
            set;
        }
    }
}
