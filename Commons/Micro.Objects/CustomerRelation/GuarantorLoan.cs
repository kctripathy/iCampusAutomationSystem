using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class GuarantorLoan
    {
        public int GuarantorLoanID
        {
            get;
            set;
        }
        public int GuarantorLoanApplicationID
        {
            get;
            set;
        }
        public string LoanIssueDate
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
        public string InstallmentType
        {
            get;
            set;
        }
        public int SanctionedByEmployeeID
        {
            get;
            set;
        }
        public string DateSanctioned
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }
        public int TenureInMonths
        {
            get;
            set;
        }
        public string EMIStartsFromDate
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
        public string DateAdded
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        //For Loan Applcation 

        public string LoanAppliedBy
        {
            get;
            set;
        }
        public int LoanApplicantID
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
        public string RequiredFor
        {
            get;
            set;
        }
        public decimal LoanAmountApplied
        {
            get;
            set;
        }
        public string ApprovalStatus
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }

        public string LoanApplicantName
        {
            get;
            set;
        }
        //Previous Loan Information
        public string LastRecoveryDate
        {
            get;
            set;
        }
        public decimal DuePrincipalAmount
        {
            get;
            set;
        }
        public decimal InterestPaid
        {
            get;
            set;
        }
        public double Emiamount
        {
            get;
            set;
        }
        public double Tenure
        {
            get;
            set;
        }
        public double PrincipalAmount
        {
            get;
            set;
        }
        public double Interestrate
        {
            get;
            set;
        }
        //Loan History Tab In GuarantorLoanApproval
        public string GuarantorLoanCode
        {
            get;
            set;
        }
        public decimal LoanAmountRecovered
        {
            get;
            set;
        }
        public int NumberOfInstallmaentPaid
        {
            get;
            set;
        }
        public decimal DueInterestAmount
        {
            get;
            set;
        }

        
    
    }

}