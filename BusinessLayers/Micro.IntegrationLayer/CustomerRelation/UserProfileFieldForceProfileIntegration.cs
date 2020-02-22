#region System Namespace
using System;
using System.Reflection;
#endregion

#region Micro Namespaces
using Micro.Objects.CustomerRelation;
using Micro.DataAccessLayer.CustomerRelation;
#endregion

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class UserProfileFieldForceProfileIntegration
   {
       #region Transactional Mathods(Insert,Update,Delete)
       public static int UpdateUserProfileFieldForceProfile(UserProfileFieldForceProfile objUserProfileFieldForceProfile)
       {
           try
           {
               return UserProfileFieldForceProfileDataAccess.GetInstance.UpdateUserProfileFieldForceProfile(objUserProfileFieldForceProfile);
           }

           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       #endregion
   }
}
