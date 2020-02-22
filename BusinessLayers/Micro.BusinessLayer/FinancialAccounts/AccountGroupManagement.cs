using System.Collections.Generic;
using Micro.IntegrationLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.BusinessLayer.FinancialAccounts
{
    public partial class AccountGroupManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountGroupManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountGroupManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountGroupManagement();
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
        public string DefaultColumns = "AccountGroupDescription,AccountGroupAlias,PrimaryGroupDescription,IsUserDefined";
        public string DisplayMember = "AccountGroupDescription";
        public string ValueMember = "AccountGroupID";
        #endregion

        #region Methods & Implemetation
        public List<AccountGroup> GetAccountGroupList(string searchText = "", bool showPrimary = false)
        {
            return AccountGroupIntegration.GetAccountGroupList(searchText, showPrimary);
        }

		public List<AccountGroup> GetAccountGroupList(int groupID)
		{
			return AccountGroupIntegration.GetAccountGroupList(groupID);
		}

        public int InsertAccountGroup(AccountGroup theAccountGroup)
        {
            return AccountGroupIntegration.InsertAccountGroup(theAccountGroup);
        }

        public int UpdateAccountGroup(AccountGroup theAccountGroup)
        {
            return AccountGroupIntegration.UpdateAccountGroup(theAccountGroup);
        }

        public int DeleteAccountGroup(AccountGroup theAccountGroup)
        {
            return AccountGroupIntegration.DeleteAccountGroup(theAccountGroup);
        }

        public AccountGroup GetAccountGroupByID(int accountGroupID)
        {
            return AccountGroupIntegration.GetAccountGroupByID(accountGroupID);
        }
        #endregion
    }
}
