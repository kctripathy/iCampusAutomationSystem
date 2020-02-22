using System;

namespace Micro.Objects.ICAS.FINANCE
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

        public int ACC_YEAR_ID
        {
            get;
            set;
        }

        public string CURRENT_START_DATE
        {
            get;
            set;
        }

        public string CURRENT_END_DATE
        {
            get;
            set;
        }

        public string PREVIOUS_START_DATE
        {
            get;
            set;
        }

        public string PREVIOUS_END_DATE
        {
            get;
            set;
        }

        public string BOOK_CLOSING_FLAG
        {
            get;
            set;
        }

        public string YEAR_CLOSING_FLAG
        {
            get;
            set;
        }

        public string STATUS_FLAG
        {
            get;
            set;
        }

        public string MOD_DATE
        {
            get;
            set;
        }

        public string AUTH_CODE
        {
            get;
            set;
        }

        public int AddedBy
        {
            get;
            set;
        }

        public int SocietyID
        {
            get;
            set;
        }
        public int SlNo
        {
            get;
            set;
        }

        public string ForMonth
        {
            get;
            set;
        }
    }
}