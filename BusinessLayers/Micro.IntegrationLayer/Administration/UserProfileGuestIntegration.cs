using System;
using Micro.Objects.Administration;
using Micro.DataAccessLayer.Administration;
using System.Reflection;


namespace Micro.IntegrationLayer.Administration
{
  public partial  class UserProfileGuestIntegration
  {
      #region Transactional Methods(Insert,Update,Delete)
      public static int UpdateUserProfileGuest(UserProfileGuest theGuest)
      { 
      try
      {
          return UserProfileGuestDataAccess.GetInstance.UpdateUserProfileGuest(theGuest);
      }
          catch(Exception ex)
      {
          throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
      }
          
      }
      #endregion
  }
}
