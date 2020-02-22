using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;
using System.Reflection;

namespace Micro.DataAccessLayer.Administration
{
  public partial  class UserProfileGuestDataAccess:AbstractData_SQLClient
  {
      #region Code to Make this as Singleton Class
      /// <summary>
      /// Declare a private static variable
      /// </summary>
      private static UserProfileGuestDataAccess _Instance;
      /// <summary>
      /// Return the instance of the application by initialising once only.
      /// </summary>
      public static UserProfileGuestDataAccess GetInstance
      {
          get 
          {
              if (_Instance == null)
              {
                  _Instance = new UserProfileGuestDataAccess();
              }
              return _Instance;
          }
          set
          {
              _Instance = value;
          }
      }

      #endregion

      #region Transactional Methods(Insert,Update,Delete)
      public int UpdateUserProfileGuest(UserProfileGuest theGuest)
      {
          try
          {
              int ReturnValue = 0;
              SqlCommand SqlCmd = new SqlCommand();
              SqlCmd.CommandType = CommandType.StoredProcedure;
              SqlCmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
              SqlCmd.Parameters.Add(GetParameter("GuestID", SqlDbType.Int, theGuest.GuestID));
              SqlCmd.Parameters.Add(GetParameter("Salutation", SqlDbType.VarChar, theGuest.Salutation));
              SqlCmd.Parameters.Add(GetParameter("GuestName", SqlDbType.VarChar, theGuest.GuestName));
              SqlCmd.Parameters.Add(GetParameter("Gender", SqlDbType.VarChar, theGuest.Gender));
              SqlCmd.Parameters.Add(GetParameter("Age",SqlDbType.Int,theGuest.Age));
              SqlCmd.Parameters.Add(GetParameter("Address_Present_TownOrCity", SqlDbType.VarChar, theGuest.Address_Present_TownOrCity));
              SqlCmd.Parameters.Add(GetParameter("Address_Present_DistrictID", SqlDbType.Int, theGuest.Address_Present_DistrictID));
              SqlCmd.Parameters.Add(GetParameter("PhoneNumber", SqlDbType.VarChar, theGuest.PhoneNumber));
              SqlCmd.Parameters.Add(GetParameter("PersonalEMailID", SqlDbType.VarChar, theGuest.PersonalEMailID));
              SqlCmd.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
              SqlCmd.CommandText = "pADM_UserProfile_Guest_Update";
              ExecuteStoredProcedure(SqlCmd);
              ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());
              return ReturnValue;


          }
          catch (Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }
      #endregion
  }
}
