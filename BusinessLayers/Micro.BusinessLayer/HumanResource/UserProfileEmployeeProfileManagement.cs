using System;
using System.Collections.Generic;
using System.Reflection;
using Micro.IntegrationLayer.HumanResource;
using Micro.Objects.HumanResource;


namespace Micro.BusinessLayer.HumanResource
{
  public partial  class UserProfileEmployeeProfileManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
      private static UserProfileEmployeeProfileManagement _Instance;

      public static UserProfileEmployeeProfileManagement GetInstance
      {
          get 
          {
              if (_Instance == null)
              {
                  _Instance = new UserProfileEmployeeProfileManagement();
              }
              return _Instance;
          }
          set 
          {
              _Instance = value;
          }
      }

        #region Transactional Mathods(Insert,Update,Delete)
      public  int UpdateUserProfileEmployeeProfile(UserProfileEmployeeProfile objUserProfileEmployeeProfile)
      {
          try
          {
              return UserProfileEmployeeProfileIntegration.UpdateUserProfileEmployeeProfile(objUserProfileEmployeeProfile);
          }
          catch(Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }
      public List<UserProfileEmployeeProfile> GetPhotoByEmployeeID(int TheEmployeeID)
      {
          try
          {
              return UserProfileEmployeeProfileIntegration.GetPhotoByEmployeeID(TheEmployeeID);
          }
          catch (Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }
      public UserProfileEmployeeProfile GetEmployeePhotoByUserID(int TheEmployeeID)
      {
          try
          {
              return UserProfileEmployeeProfileIntegration.GetEmployeePhotoByUserID(TheEmployeeID);
          }
          catch(Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }
        #endregion

        #endregion
    }
}
