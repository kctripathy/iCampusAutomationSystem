using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
   public partial  class ChangePolicyTypeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static ChangePolicyTypeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static ChangePolicyTypeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangePolicyTypeManagement();
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
              
       #endregion

       #region Methods & Implementation
       public int UpdatePolicyTypeChange(CustomerAccount theCustomerAccount, CustomerAccountReceipt theCustomerAccountReceipt)
       {
           return ChangePolicyTypeIntegration.UpdatePolicyTypeChange(theCustomerAccount, theCustomerAccountReceipt);
       }
        #endregion
    }
}
