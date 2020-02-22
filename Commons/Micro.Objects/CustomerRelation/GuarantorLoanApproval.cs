using System;

namespace Micro.Objects.CustomerRelation
{
     [Serializable]
    public class GuarantorLoanApproval
    {

         public int GuarantorLoanApprovalID
         {
             get;
             set;
         }
         public int GuarantorLoanApplicationID
         {
             get;
             set;
         }
         public int LoanApplicationID
         {
             get;
             set;
         }
         public string LoanApplicationNumber
         {
             get;
             set;
         }
         public string LoanApprovalDate
         {
             get;
             set;
         }
         public decimal LoanApprovalAmount
         {
             get;
             set;
         }
         public int LoanApprovedTenureInMonths
         {
             get;
             set;
         }
         public decimal LoanApprovedRateOfInterest
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
         public string LoanApplicantName
         {
             get;
             set;
         }
    }
}
