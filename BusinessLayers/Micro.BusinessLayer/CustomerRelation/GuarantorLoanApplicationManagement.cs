using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class GuarantorLoanApplicationManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static GuarantorLoanApplicationManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static GuarantorLoanApplicationManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new GuarantorLoanApplicationManagement();
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
        public string DefaultColumns = "LoanApplicantName, LoanApplicationNumber, LoanApplicationDate, RequiredFor, ApprovalStatus";
        public string DisplayMember = "LoanApplicantName";
        public string ValueMember = "GuarantorLoanApplicationID";
		#endregion

		#region Methods & Implementation
        public List<GuarantorLoanApplication> GetGuarantorLoanApplicationList(bool allOffices = false, bool showDeleted = false)
		{
			return GuarantorLoanApplicationIntegration.GetGuarantorLoanApplicationList(allOffices,showDeleted);
		}

        public GuarantorLoanApplication GetGuarantorLoanApplicationByID(int guarantorLoanApplicationID)
		{
            return GuarantorLoanApplicationIntegration.GetGuarantorLoanApplicationByID(guarantorLoanApplicationID);
		}

        public List<GuarantorLoanApplication> GetGuarantorLoanApplicationListByApprovalStatus(string approvalStatus, bool allOffices = false)
		{
			return GuarantorLoanApplicationIntegration.GetGuarantorLoanApplicationListByApprovalStatus(approvalStatus,allOffices);
		}

        public List<GuarantorLoanApplication> GetGuarantorLoanApplicationListByApplicantID(int loanApplicantId)
		{
			return GuarantorLoanApplicationIntegration.GetGuarantorLoanApplicationListByApplicantID(loanApplicantId);
		}

        public List<GuarantorLoanApplication> GetGuarantorLoanApplicationListByApplicantID(int loanApplicantId, string loanAppliedBy)
		{
			return GuarantorLoanApplicationIntegration.GetGuarantorLoanApplicationListByApplicantID(loanApplicantId, loanAppliedBy);
		}

        public List<GuarantorLoanApplication> GetGuarantorLoanApplicationListByApplicantID(int loanApplicantId, string loanAppliedBy, string approvalStatus)
		{
			return GuarantorLoanApplicationIntegration.GetGuarantorLoanApplicationListByApplicantID(loanApplicantId, loanAppliedBy, approvalStatus);
		}

        public int InsertGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
		{
			return GuarantorLoanApplicationIntegration.InsertGuarantorLoanApplication(theGuarantorLoanApplication);
		}

        public int UpdateGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
		{
			return GuarantorLoanApplicationIntegration.UpdateGuarantorLoanApplication(theGuarantorLoanApplication);
		}

        public int DeleteGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
		{
			return GuarantorLoanApplicationIntegration.DeleteGuarantorLoanApplication(theGuarantorLoanApplication);
		}

        public int RejectGuarantorLoanApplication(GuarantorLoanApplication theLoanReject)
        {
            return GuarantorLoanApplicationIntegration.RejectGuarantorLoanApplication(theLoanReject);
        }
		#endregion
	}
}
