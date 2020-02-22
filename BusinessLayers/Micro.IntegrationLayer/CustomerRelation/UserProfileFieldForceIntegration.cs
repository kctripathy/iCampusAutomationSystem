using System;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;
using System.Reflection;


namespace Micro.IntegrationLayer.CustomerRelation
{
  public partial  class UserProfileFieldForceIntegration
  {
      #region Declaration

      #endregion

      #region TransactionalMethods(Insert,Update,Delete)
      public static int UpdateUserProfileFieldforce(UserProfileFieldForce theFieldforce)
      {
          try
          {
              return UserProfileFieldForceDataAccess.GetInstance.UpdateUserProfileFieldForce(theFieldforce);
          }
          catch (Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }
      #endregion
  }
}
