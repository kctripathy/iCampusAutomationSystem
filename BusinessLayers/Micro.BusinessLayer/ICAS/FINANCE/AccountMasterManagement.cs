using System.Collections.Generic;
using System.Linq;
using System.Web;
using Micro.IntegrationLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.BusinessLayer.ICAS.FINANCE
{
    public partial class AccountMasterManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountMasterManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountMasterManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountMasterManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion.

        #region Declaration
        public string DefaultColumn = "AccountDescription, AccountCode, AccountGroupDescription";
        public string DisplayMember = "AccountDescription";
        public string ValueMember = "AccountID";
        #endregion

        #region Methods & Implementation
        
        public List<AccountMaster> GetAccountMasterList()
        {
            // VICKY : ACCOUNTS MASTER: CACHE THIS AS DONE IF AccountGroupManagement-GetAccountGroupList()
            string Context = "GetAccountMasterList";
            List<AccountMaster> AccountMasterList = new List<AccountMaster>();

            if (HttpRuntime.Cache[Context] == null)
            {

                AccountMasterList = AccountMasterIntegration.GetAccountMasterList();
                HttpRuntime.Cache[Context] = AccountMasterList;
            }
            else
            {
                AccountMasterList = ((List<AccountMaster>)(HttpRuntime.Cache[Context]));
            }

            return AccountMasterList;
        }

        public List<AccountMaster> GetAccountMasterListByAccountLedgerType(string accountLedgerType)
        {
            List<AccountMaster> theAccountMasterList=new List<AccountMaster>();
            if (accountLedgerType == "SL")
            {
                theAccountMasterList = GetAccountMasterList().Where(am => !am.AccountLedgerType.Equals(accountLedgerType)).ToList();
            }
            else
            {
                theAccountMasterList = GetAccountMasterList().Where(am => am.AccountLedgerType.Equals(accountLedgerType)).ToList();
            }
            return theAccountMasterList;

        }

        public AccountMaster GetAccountMasterByAccountID(int accountID)
        {
            return AccountMasterIntegration.GetAccountMasterByAccountID(accountID);
        }

        public AccountMaster GetAccountMasterByAccountDescription(string accountDescription)
        {
            return AccountMasterIntegration.GetAccountMasterByAccountDescription(accountDescription);
        }

        public AccountMaster GetAccountMasterByAccountCode(string accountCode)
        {
            return AccountMasterIntegration.GetAccountMasterByAccountCode(accountCode);
        }

        public int InsertAccountMaster(AccountMaster theAccountMaster)
        {
            return AccountMasterIntegration.InsertAccountMaster(theAccountMaster);
        }

        public int UpdateAccountMaster(AccountMaster theAccountMaster)
        {
            return AccountMasterIntegration.UpdateAccountMaster(theAccountMaster);
        }

        public int DeleteAccountMaster(AccountMaster theAccountMaster)
        {
            return AccountMasterIntegration.DeleteAccountMaster(theAccountMaster);
        }
        #endregion
    }
}
