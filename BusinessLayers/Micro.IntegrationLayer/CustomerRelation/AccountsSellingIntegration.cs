using Micro.Objects.CustomerRelation;
using Micro.DataAccessLayer.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class AccountsSellingIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

       public static int InsertSellingAccount(CustomerAccount theCustomerAccount)
       {
           return AccountsSellingDataAccess.GetInstance.InsertSellingAccount(theCustomerAccount);
       }
        #endregion
    }
}
