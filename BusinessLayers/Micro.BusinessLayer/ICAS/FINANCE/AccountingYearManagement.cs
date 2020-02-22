using System.Collections.Generic;
using System.Web;
using Micro.IntegrationLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.BusinessLayer.ICAS.FINANCE
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
            // VICKY : GetAccountingYearById : CACHE THIS AS DONE IF AccountGroupManagement-GetAccountGroupList()

            string Context = string.Format("GetAccountingYearById_{0}", recordId);
            AccountingYear AccountYear = new AccountingYear();

            if (HttpRuntime.Cache[Context] == null)
            {

                AccountYear = AccountingYearIntegration.GetAccountingYearById(recordId);
                HttpRuntime.Cache[Context] = AccountYear;
            }
            else
            {
                AccountYear = ((AccountingYear)(HttpRuntime.Cache[Context]));
            }

            return AccountYear;
        }

        public int GetAccountingYearIDByFlag(string flag)
        {
            //VICKY : GetAccountingYearIDByFlag : CACHE THIS AS DONE IF AccountGroupManagement-GetAccountGroupList()

            string Context = string.Format("GetAccountingYearIDByFlag_{0}", flag);
            int AccountYear;

            if (HttpRuntime.Cache[Context] == null)
            {

                AccountYear = AccountingYearIntegration.GetAccountingYearIDByFlag(flag);
                HttpRuntime.Cache[Context] = AccountYear;
            }
            else
            {
                AccountYear = ((int)(HttpRuntime.Cache[Context]));
            }

            return AccountYear;
            
        }

        public List<AccountingYear> GetAllMonthsFromCurrentAccountYear()
        {
            return AccountingYearIntegration.GetAllMonthsFromCurrentAccountYear();
        }
        #endregion

        #region Methods & Implementation for Account Book Close

        public List<AccountBookClose> GetMonthByOfficeId(int OfficeId)
        {
            return AccountingYearIntegration.GetMonthByOfficeId(OfficeId);
        }

        #endregion
    }
}