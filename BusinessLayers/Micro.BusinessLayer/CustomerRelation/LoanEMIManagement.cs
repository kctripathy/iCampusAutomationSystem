using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class LoanEMIManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static LoanEMIManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static LoanEMIManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new LoanEMIManagement();
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
        public string DefaultColumns = "EMIAmount, InterestAmount, PrincipalReduction, BalanceDue, TotalPrincipalPayable, TotalInterestPayable, TotalPayable, RoundOff";
        public string DisplayMember = "EMIAmount";
        public string ValueMember = "EMINumber";
        #endregion

        #region Methods & Implementation
        public List<LoanEMI> GetLoanEMIChart(decimal rateOfInterest, decimal tenureInMonths, decimal loanAmount)
		{
			return LoanEMIIntegration.GetLoanEMIChart(rateOfInterest, tenureInMonths, loanAmount);
		}

		public LoanEMI GetLoanEMIByEMINumber(decimal rateOfInterest, decimal tenureInMonths, decimal loanAmount, int emiNumber)
		{
			return LoanEMIIntegration.GetLoanEMIByEMINumber(rateOfInterest, tenureInMonths, loanAmount, emiNumber);
		}

		public LoanEMI GetLoanEMIByEMINumber(List<LoanEMI> theLoanEMIChart, int emiNumber)
		{
			return LoanEMIIntegration.GetLoanEMIByEMINumber(theLoanEMIChart, emiNumber);
		}

		public LoanEMI GetLoanSettlement(decimal rateOfInterest, decimal tenureInMonths, decimal loanAmount, int installmentsPaid)
		{
			return LoanEMIIntegration.GetLoanSettlement(rateOfInterest, tenureInMonths, loanAmount, installmentsPaid);
		}
		#endregion
	}
}
