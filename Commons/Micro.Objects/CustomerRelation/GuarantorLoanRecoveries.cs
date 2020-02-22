using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
   public class GuarantorLoanRecoveries
    {
        public int GuarantorLoanReceiptID
        {
            get;
            set;
        }

        public string ReceiptSeries
        {
            get;
            set;
        }
        public string GuarantorLoanReceiptNumber
        {
            get;
            set;
        }

        public int GuarantorLoanID
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

        public string PaymentMode
        {
            get;
            set;
        }

        public string PaymentReference
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

     //For Active Loan Details

        public string GuarantorLoanCode
        {
            get;
            set;
        }

        public string LoanIssueDate
        {
            get;
            set;
        }

        public string LastRecoveryDate
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

        public decimal DuePrincipalAmount
        {
            get;
            set;
        }

        public decimal DueInterestAmount
        {
            get;
            set;
        }

        public decimal InterestPaid
        {
            get;
            set;
        }

        public decimal LoanAmountRecovered
        {
            get;
            set;
        }

        public int NumberOfInstallmentsPaid
        {
            get;
            set;
        }
    }
}
	
	 
	 
	 
	 
	 
	 
	 
