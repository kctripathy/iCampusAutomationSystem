
namespace Micro.BusinessLayer.FinancialAccounts
{
    public partial class AccountRemittanceManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountRemittanceManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountRemittanceManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountRemittanceManagement();
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
        #endregion

        #region Methods & Implementation
        #endregion
    }
}
