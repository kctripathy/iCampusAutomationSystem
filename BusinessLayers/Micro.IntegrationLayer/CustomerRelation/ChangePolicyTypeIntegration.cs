using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class ChangePolicyTypeIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static int UpdatePolicyTypeChange(CustomerAccount theCustomerAccount, CustomerAccountReceipt theCustomerAccountReceipt)
        {
            return ChangePolicyTypeDataAccess.GetInstance.UpdatePolicyTypeChange(theCustomerAccount, theCustomerAccountReceipt);
        }
        #endregion
    }
}
