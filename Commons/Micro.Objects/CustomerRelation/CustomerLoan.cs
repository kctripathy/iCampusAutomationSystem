using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class CustomerLoan
    {
        public int CustomerLoanID
        {
            get;
            set;
        }

        public string CustomerLoanCode
        {
            get;
            set;
        }

        public int CustomerAccountID
        {
            get;
            set;
        }

        public string CustomerAccountCode
        {
            get;
            set;
        }

		public int CustomerID
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

        public string LoanApplicationNumber
        {
            get;
            set;
        }

        public string LoanApplicationDate
        {
            get;
            set;
        }

        public decimal LoanApplicationFee
        {
            get;
            set;
        }

        public decimal LoanAmount
        {
            get;
            set;
        }

        public decimal RateOfInterest
        {
            get;
            set;
        }

        public string RequiredFor
        {
            get;
            set;
        }

        public string InstallmentType
        {
            get;
            set;
        }

        public int SanctionedByID
        {
            get;
            set;
        }

		public string SanctionedByName
		{
			get;
			set;
		}
        
		public bool IsClosed
        {
            get;
            set;
        }

        public string ClosureDate
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
