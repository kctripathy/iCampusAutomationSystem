using System.Collections.Generic;
using System.Web;
using Micro.IntegrationLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.BusinessLayer.ICAS.FINANCE
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
        public List<AccountGroup> GetAccountGroupList()
        {
            string Context = "GetAccountGroupList";
            List<AccountGroup> AccountGroupList = new List<AccountGroup>();
            
            //if (HttpRuntime.Cache[Context] == null)
            //{
                
                AccountGroupList = AccountGroupIntegration.GetAccountGroupList();
                HttpRuntime.Cache[Context] = AccountGroupList;
            //}
            //else
            //{
            //    AccountGroupList = ((List<AccountGroup>)(HttpRuntime.Cache[Context]));
            //}
            return AccountGroupList;
        }
        public List<AccountGroup> GetMasterAccountGroupList()
        {
            string Context = "GetMasterAccountGroupList";
            List<AccountGroup> AccountGroupList = new List<AccountGroup>();          
            AccountGroupList = AccountGroupIntegration.GetMasterAccountGroupList();
            HttpRuntime.Cache[Context] = AccountGroupList;          
            return AccountGroupList;
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
