using System.Collections.Generic;
using Micro.IntegrationLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.BusinessLayer.FinancialAccounts
{
    public partial class MonthEndManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static MonthEndManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static MonthEndManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MonthEndManagement();
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
        public string DefaultColumns = "DateFrom, DateTo, GraceDays, ClosingDate, Status";
        public string DisplayMember = "DateFrom";
        public string ValueMember = "MonthEndID";
        #endregion

        #region Methods & Implementation
        public List<MonthEnd> GetMonthEndList(bool allOffices = false, bool showDeleted = false)
        {
            return MonthEndIntegration.GetMonthEndList(allOffices, showDeleted);
        }

        public List<MonthEnd> GetMonthEndList(string officeIDs, bool allOffices = false, bool showDeleted = false)
        {
            return MonthEndIntegration.GetMonthEndList(officeIDs, allOffices, showDeleted);
        }
        #endregion
    }
}
