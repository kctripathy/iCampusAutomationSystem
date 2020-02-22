using System.Collections.Generic;
using Micro.IntegrationLayer.ICAS.FINANCE;
using Micro.Objects;

namespace Micro.BusinessLayer.ICAS.FINANCE
{
    public partial class AccountLedgerManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountLedgerManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountLedgerManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountLedgerManagement();
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
        public string DefaultColumns = "AccountLedgerDescription,AccountLedgerAlias,AccountGroupDescription";
        public string DisplayMember = "AccountLedgerDescription";
        public string ValueMember = "AccountLedgerID";
        #endregion

        #region Methods & Implementations
        public List<AccountLedger> GetAccountLedgerList(string searchText)
        {
            return AccountLedgerIntegration.GetAccountLedgerList(searchText);
        }

        public List<AccountLedger> GetNonCaseAccountLedgerList(bool allOffices = false, bool showDeleted = false)
        {
            return AccountLedgerIntegration.GetNonCaseAccountLedgerList(allOffices, showDeleted);
        }

        public List<AccountLedger> GetBankLedgerList(bool allOffices = false, bool showDeleted = false)
        {
            return AccountLedgerIntegration.GetBankLedgerList(allOffices, showDeleted);
        }

        public AccountLedger GetAccountLedgerByID(int accountLedgerID)
        {
            return AccountLedgerIntegration.GetAccountLedgerByID(accountLedgerID);
        }

        public int InsertAccountLedger(AccountLedger theAccountLedger)
        {
            return AccountLedgerIntegration.InsertAccountLedger(theAccountLedger);
        }

        public int UpdateAccountLedger(AccountLedger theAccountLedger)
        {
            return AccountLedgerIntegration.UpdateAccountLedger(theAccountLedger);
        }

        public int DeleteAccountLedger(AccountLedger theAccountLedger)
        {
            return AccountLedgerIntegration.DeleteAccountLedger(theAccountLedger);
        }
        #endregion
    }
}
