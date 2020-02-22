using System;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;
using System.Reflection;

namespace Micro.BusinessLayer.Administration
{
  public partial  class UserProfileGuestManagement
  {
      #region Code to make this as a Singleton
      /// <summary>
      /// Declare a private static variable
      /// </summary>
      private static UserProfileGuestManagement _Instance;
      /// <summary>
      /// Return the instance of the application by initialising once only.
      /// </summary>
      public static UserProfileGuestManagement GetInstance
      {
          get 
          {
              if (_Instance == null)
              {
                  _Instance = new UserProfileGuestManagement();
              }
              return _Instance; 
          }
          set 
          {
              _Instance = value;
          }
      }
      #endregion

      #region Transactional Mefthods(Insert,Update,Delete)
      public int UpdateUserProfileGuest(UserProfileGuest theGuest)
      {
          try
          {
              return UserProfileGuestIntegration.UpdateUserProfileGuest(theGuest);
          }
          catch(Exception ex) 
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }
 
      #endregion

  }
}
