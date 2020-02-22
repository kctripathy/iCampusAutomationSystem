using System.Collections.Generic;
using Micro.IntegrationLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.BusinessLayer.FinancialAccounts
{
    public partial class AccountingYearManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountingYearManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountingYearManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountingYearManagement();
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
        public string DefaultColumns = "AccountingYearDescription,YearStartDate,YearEndDate";
        public string DisplayMember = "AccountingYearDescription";
        public string ValueMember = "AccountingYearID";
        #endregion

        #region Methods & Implementation
        public List<AccountingYear> GetAccountingYearList(string searchText)
        {
            return AccountingYearIntegration.GetAccountingYearList(searchText);
        }

        public int InsertAccountingYear(AccountingYear theAccountingYear)
        {
            return AccountingYearIntegration.InsertAccountingYear(theAccountingYear);
        }

        public int UpdateAccountingYear(AccountingYear theAccountingYear)
        {
            return AccountingYearIntegration.UpdateAccountingYear(theAccountingYear);
        }

        public int DeleteAccountingYear(AccountingYear theAccountingYear)
        {
            return AccountingYearIntegration.DeleteAccountingYear(theAccountingYear);
        }

        public AccountingYear GetAccountingYearById(int recordId)
        {
            return AccountingYearIntegration.GetAccountingYearById(recordId);
        }
        #endregion
    }
}