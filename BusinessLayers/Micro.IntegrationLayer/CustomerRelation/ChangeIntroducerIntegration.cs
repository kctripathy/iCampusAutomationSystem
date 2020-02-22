using Micro.Objects.CustomerRelation;
using Micro.DataAccessLayer.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class ChangeIntroducerIntegration
   {
       #region Declaration
       #endregion

       #region Methods & Implementation

       public static int InsertIntroducer(ChangeIntroducer theIntroducer)
       {
           return ChangeIntroducerDataAccess.GetInstance.InsertIntroducer(theIntroducer);
       }
       #endregion
   }
}
