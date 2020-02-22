using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class GuarantorLoanApprovalManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static GuarantorLoanApprovalManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static GuarantorLoanApprovalManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GuarantorLoanApprovalManagement();
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
        public string DefaultColumns = "LoanApplicationNumber,LoanApplicantName,LoanApprovalDate";
        public string DisplayMember = "LoanApplicantName";
        public string ValueMember = "GuarantorLoanApprovalID";
        #endregion

        #region Methods & Implementation
        public List<GuarantorLoanApproval> GetAllUnpaidApproveLoanList(bool allOffices = true)
        {
            return GuarantorLoanApprovalIntegration.GetAllUnpaidApproveLoanList(allOffices);
        }

        public GuarantorLoanApproval GetAllApproveLoanDetailByID(int GuarantorLoanApprovalID)
        {
            return GuarantorLoanApprovalIntegration.GetAllApproveLoanDetailByID(GuarantorLoanApprovalID);
        }

        public int InsertGuarantorLoanApproval(GuarantorLoanApproval theLoanApproval)
        {
            return GuarantorLoanApprovalIntegration.InsertGuarantorLoanApproval(theLoanApproval);
        }
        #endregion
    }
}
