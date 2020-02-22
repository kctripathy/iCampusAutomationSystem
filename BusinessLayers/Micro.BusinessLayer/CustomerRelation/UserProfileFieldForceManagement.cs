using System;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;
using System.Reflection;

namespace Micro.BusinessLayer.CustomerRelation
{
  public partial  class UserProfileFieldForceManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
      private static UserProfileFieldForceManagement _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
      public static UserProfileFieldForceManagement GetInstance
      {
          get 
          {
              if (_Instance == null)
              {
                  _Instance = new UserProfileFieldForceManagement();
              }
              return _Instance;
          }
          set 
          {
              _Instance = value;
          }
      }
        #endregion

        #region Transaction Methods(Insert,Update,Delete)
      public int UpdateUserProfileFieldForce(UserProfileFieldForce theFieldForce)

      {
          try
          {
              return UserProfileFieldForceIntegration.UpdateUserProfileFieldforce(theFieldForce);
          }

          catch (Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
  }
        #endregion
    }
}
