using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class AccountsSellingManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountsSellingManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountsSellingManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountsSellingManagement();
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
        public  int InsertSellingAccount(CustomerAccount theCustomerAccount)
        {
            return AccountsSellingIntegration.InsertSellingAccount(theCustomerAccount);
        }
        #endregion

    }
}
