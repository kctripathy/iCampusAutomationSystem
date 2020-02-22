using System.Collections.Generic;
using Micro.IntegrationLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.BusinessLayer.FinancialAccounts
{
    public partial class AccountHeadManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountHeadManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountHeadManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountHeadManagement();
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
        public string DefaultColumns = "AccountHeadDescription, AccountHeadType";
        public string DisplayMember = "AccountHeadDescription";
        public string ValueMember = "AccountHeadID";
        #endregion

        #region Methods & Implementation
        public List<AccountHead> GetAccountHeadList(bool showPrimary = true, bool showDeleted = false)
        {
            return AccountHeadIntegration.GetAccountHeadList(showPrimary, showDeleted);
        }

        public List<AccountHead> GetAccountHeadListByType(string accountHeadType, bool showPrimary = true, bool showDeleted = false)
        {
            return AccountHeadIntegration.GetAccountHeadListByType(accountHeadType, showPrimary, showDeleted);
        }

        public List<AccountHead> GetAccountHeadListByType(List<AccountHead> accountHeadList, string accountHeadType, bool showPrimary = true, bool showDeleted = false)
        {
            return AccountHeadIntegration.GetAccountHeadListByType(accountHeadList, accountHeadType, showPrimary, showDeleted);
        }

        public AccountHead GetAccountHeadByID(int accountHeadID)
        {
            return AccountHeadIntegration.GetAccountHeadByID(accountHeadID);
        }

        public int InsertAccountHead(AccountHead theAccountHead)
        {
            return AccountHeadIntegration.InsertAccountHead(theAccountHead);
        }

        public int UpdatetAccountHead(AccountHead theAccountHead)
        {
            return AccountHeadIntegration.UpdateAccountHead(theAccountHead);
        }

        public int DeleteAccountHead(AccountHead theAccountHead)
        {
            return AccountHeadIntegration.DeleteAccountHead(theAccountHead);
        }

        public int UpdateDisplayOrder(List<AccountHead> accountHeadList)
        {
            return AccountHeadIntegration.UpdateDisplayOrder(accountHeadList);
        }
        #endregion
    }
}
