using System.Collections.Generic;
using Micro.IntegrationLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.BusinessLayer.FinancialAccounts
{
	public partial class AccountNameManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static AccountNameManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static AccountNameManagement GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new AccountNameManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

        #region Declaraton
        public string DefaultColumns = "AccountDescription, AccountHeadDescription";
		public string DisplayMember = "AccountDescription";
        public string ValueMember = "AccountID";
        #endregion

		#region Methods & Implementation
        public List<AccountName> GetAccountList(bool showPrimary = true, bool showDeleted = false)
        {
            return AccountNameIntegration.GetAccountList(showPrimary, showDeleted);
        }

        public List<AccountName> GetAccountListByAccessType(string accessType)
        {
            return AccountNameIntegration.GetAccountListByAccessType(accessType);
        }

        public List<AccountName> GetAccountListByAnalysisFlag(string analysisFlag, bool showPrimary = true, bool showDeleted = false)
        {
            return AccountNameIntegration.GetAccountListByAnalysisFlag(analysisFlag, showPrimary, showDeleted);
        }

        public List<AccountName> GetAccountListByAnalysisFlag(List<AccountName> accountNameList, string analysisFlag)
        {
            return AccountNameIntegration.GetAccountListByAnalysisFlag(accountNameList, analysisFlag);
        }

        public AccountName GetAccountByID(int accountID)
        {
            return AccountNameIntegration.GetAccountByID(accountID);
        }

        public int InsertAccount(AccountName theAccount)
        {
            return AccountNameIntegration.InsertAccount(theAccount);
        }

        public int UpdateAccount(AccountName theAccount)
        {
            return AccountNameIntegration.UpdateAccount(theAccount);
        }

        public int DeleteAccount(AccountName theAccount)
        {
            return AccountNameIntegration.DeleteAccount(theAccount);
        }

        public int UpdateDisplayOrder(List<AccountName> accountList)
        {
            return AccountNameIntegration.UpdateDisplayOrder(accountList);
        }
		#endregion
	}
}
