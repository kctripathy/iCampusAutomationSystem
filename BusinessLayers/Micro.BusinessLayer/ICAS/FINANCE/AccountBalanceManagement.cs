using System.Collections.Generic;
using Micro.IntegrationLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.BusinessLayer.ICAS.FINANCE
{
    public partial class AccountBalanceManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountBalanceManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountBalanceManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountBalanceManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion
        #region Methods & Implementation
        public List<AccountBalance> GetAccountsBalanceListByAccountsYearID(int accountsYearID, int officeID)
        {
            return AccountBalanceIntegration.GetAccountsBalanceListByAccountsYearID(accountsYearID, officeID);
        }

        public int UpdateFinyearOpeningBalance(AccountBalance theAccountBalance)
        {
            return AccountBalanceIntegration.UpdateFinyearOpeningBalance(theAccountBalance);
        }
        #endregion
    }
}
