using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class CustomerLoanReceipt
    {
        public int CustomerLoanReceiptID
        {
            get;
            set;
        }

        public string ReceiptSeries
        {
            get;
            set;
        }

        public string CustomerLoanReceiptNumber
        {
            get;
            set;
        }

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

        public string DateOfRecovery
        {
            get;
            set;
        }

        public decimal AmountPaid
        {
            get;
            set;
        }

        public decimal AmountPaidAsPrincipal
        {
            get;
            set;
        }

        public decimal AmountPaidAsInterest
        {
            get;
            set;
        }

        public int InstallmentNumber
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

		public bool IsCancelled
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
