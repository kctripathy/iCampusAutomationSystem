using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class GuarantorLoanRecoveryManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static GuarantorLoanRecoveryManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static GuarantorLoanRecoveryManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GuarantorLoanRecoveryManagement();
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
        public string DefaultColumns = "GuarantorLoanReceiptNumber, DateOfRecovery, LoanAmount, InstallmentsPaid , DuePrincipalAmount, DueInterestAmount, InterestPaid, LoanRecovered ";
        public string DisplayMember = "GuarantorLoanReceiptNumber";
        public string ValueMember = "GuarantorLoanReceiptID";
        #endregion

        #region Methods & Implementation
        public List<GuarantorLoanRecoveries> GetGuarantorLoanRecoveries(string searchText)
        {
            return GuarantorLoanRecoveryIntegration.GetGuarantorLoanRecoveries(searchText);
        }

        public List<GuarantorLoanRecoveries> GetActiveLoanDetails(int loanApplicantId, string loanAppliedBy)
        {
            return GuarantorLoanRecoveryIntegration.GetActiveLoanDetails(loanApplicantId, loanAppliedBy);
        }

        public List<GuarantorLoanRecoveries> GetGuarantorLoanRecoveriesByGuarantorLoanId(int guarantorloanId)
        {
            return GuarantorLoanRecoveryIntegration.GetGuarantorLoanRecoveriesByGuarantorLoanId(guarantorloanId);
        }

        public bool GetGuarantorLoanRecoveriesByGuarantorLoanId(int guarantorloanId, decimal loanAmount)
        {
            return GuarantorLoanRecoveryIntegration.GetGuarantorLoanRecoveriesByGuarantorLoanId(guarantorloanId, loanAmount);
        }

        public List<GuarantorLoanRecoveries> GetLoanHistoryDetails(int RecordID)
        {
            return GuarantorLoanRecoveryIntegration.GetLoanHistoryDetails(RecordID);
        }

        public int InsertGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            return GuarantorLoanRecoveryIntegration.InsertGuarantorLoanRecovery(theGuarantorLoanRecovery);
        }

        public int UpdateGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            return GuarantorLoanRecoveryIntegration.UpdateGuarantorLoanRecovery(theGuarantorLoanRecovery);
        }

        public int DeleteGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            return GuarantorLoanRecoveryIntegration.DeleteGuarantorLoanRecovery(theGuarantorLoanRecovery);
        }

        public GuarantorLoanRecoveries GetGuarantorLoanRecoveriesById(int recordId)
        {
            return GuarantorLoanRecoveryIntegration.GetGuarantorLoanRecoveriesById(recordId);
        }
        #endregion
    }
}
