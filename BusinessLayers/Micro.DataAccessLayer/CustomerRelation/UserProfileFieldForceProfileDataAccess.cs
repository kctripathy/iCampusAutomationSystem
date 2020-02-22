using System;
using Micro.Objects.CustomerRelation;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using System.Reflection;

namespace Micro.DataAccessLayer.CustomerRelation
{
   public partial class UserProfileFieldForceProfileDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static UserProfileFieldForceProfileDataAccess _Instancae;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static UserProfileFieldForceProfileDataAccess GetInstance
       {
           get
           {
               if (_Instancae == null)
               {
                   _Instancae = new UserProfileFieldForceProfileDataAccess();
               }
               return _Instancae;
           }
           set
           {
               _Instancae = value;
           }
       }
        #endregion


       #region Transactional Methods(Insert,Update,Delete)
       public int UpdateUserProfileFieldForceProfile(UserProfileFieldForceProfile objUserProfileFieldForceProfile)
       {
           try
           {
               int ReturnValue = 0;
               SqlCommand SqlCmd = new SqlCommand();
               SqlCmd.CommandType = CommandType.StoredProcedure;

               SqlCmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

               SqlCmd.Parameters.Add(GetParameter("FieldForceID", SqlDbType.Int, objUserProfileFieldForceProfile.FieldForceID));
               //SqlCmd.Parameters.Add(GetParameter("SettingKeyID", SqlDbType.Int, objUserProfileFieldForceProfile.SettingKeyID));
                SqlCmd.Parameters.Add(GetParameter("SettingKeyValue", SqlDbType.VarBinary, ImageFunctions.ImageToByte(objUserProfileFieldForceProfile.SettingKeyValue)));
               SqlCmd.Parameters.Add(GetParameter("SettingKeyDescription", SqlDbType.VarChar, objUserProfileFieldForceProfile.SettingKeyDescription));
               //SqlCmd.Parameters.Add(GetParameter("DateModified", SqlDbType.DateTime, objUserProfileEmployeeProfile.DateModified));
               SqlCmd.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               SqlCmd.CommandText = "pCRM_UserProfile_FieldForceProfiles_Update";
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
