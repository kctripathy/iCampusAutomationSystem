using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class GuarantorLoanManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static GuarantorLoanManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static GuarantorLoanManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GuarantorLoanManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string DefaultColumns = "LoanApplicantName , LoanIssueDate, EMIStartsFromDate, LoanAmount, RateOfInterest, TenureInMonths,RequiredFor";
        public string DisplayMember = "LoanApplicantName";
        public string ValueMember = "GuarantorLoanID";
        #endregion

        #region Methods & Implementation
        public List<GuarantorLoan> GetGuarantorLoanList(bool allOffices = true, bool showDeleted = false, bool showClosed = false)
        {
			return GuarantorLoanIntegration.GetGuarantorLoanList(allOffices,showDeleted,showClosed);
        }

        //public List<GuarantorLoan> GetGuarantorLoans(string loanAppliedBy, string officeIds)
        //{
        //    return GuarantorLoanIntegration.GetGuarantorLoans(loanAppliedBy, officeIds);
        //}

        public List<GuarantorLoan> GetAllPreviousLoanDetailByID(int LoanApplicantID, string LoanAppliedBy)
        {
            return GuarantorLoanIntegration.GetAllPreviousLoanDetailByID(LoanApplicantID, LoanAppliedBy);
        }

        public List<GuarantorLoan> GetGuarantorLoansByOfficeID(bool allOffices, string officeIds)
        {
            return GuarantorLoanIntegration.GetGuarantorLoansByOfficeID(allOffices, officeIds);
        }

        public GuarantorLoan GetPreviousLoanDetails(int LoanApplicantID, string RecordValue)
        {
            return GuarantorLoanIntegration.GetPreviousLoanDetails(LoanApplicantID, RecordValue);
        }

        public GuarantorLoan GetEMIChartDetails(int LoanApplicantID)
        {
            return GuarantorLoanIntegration.GetEMIChartDetails(LoanApplicantID);
        }

        public List<GuarantorLoan> EMITable(double RateOfInterest, double Tenure, double PrincipalAmount, double Emiamount)
        {
            return GuarantorLoanIntegration.EMITable(RateOfInterest, Tenure, PrincipalAmount, Emiamount);
        }

        public List<GuarantorLoan> GetGuarantorLoansByLoanAppliedBy(string loanAppliedBy, bool allOffices, string officeIds)
        {
            return GuarantorLoanIntegration.GetGuarantorLoansByLoanAppliedBy(loanAppliedBy, allOffices, officeIds);
        }

        public GuarantorLoan GetGuarantorLoanDetails(int GuarantorLoanID)
        {
            return GuarantorLoanIntegration.GetGuarantorLoanDetails(GuarantorLoanID);
        }

        public int InsertGuarantorLoan(GuarantorLoan theGuarantorLoan)
        {
            return GuarantorLoanIntegration.InsertGuarantorLoan(theGuarantorLoan);
        }

        public int UpdateGuarantorLoan(GuarantorLoan theGuarantorLoan)
        {
            return GuarantorLoanIntegration.UpdateGuarantorLoan(theGuarantorLoan);
        }

        public int DeleteGuarantorLoan(GuarantorLoan theGuarantorLoan)
        {
            return GuarantorLoanIntegration.DeleteGuarantorLoan(theGuarantorLoan);
        }

        public GuarantorLoan GetGuarantorLoansById(int GuarantorLoanID)
        {
            return GuarantorLoanIntegration.GetGuarantorLoansById(GuarantorLoanID);
        }
        #endregion
    }
}
