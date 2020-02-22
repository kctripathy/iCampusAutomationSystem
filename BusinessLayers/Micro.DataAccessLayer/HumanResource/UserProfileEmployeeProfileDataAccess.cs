#region System Namespace
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
#endregion

#region Micro Namespaces
using Micro.Commons;
using Micro.Objects.HumanResource;
#endregion

namespace Micro.DataAccessLayer.HumanResource
{
public partial	class UserProfileEmployeeProfileDataAccess:AbstractData_SQLClient
	{
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
    private static UserProfileEmployeeProfileDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
    public static UserProfileEmployeeProfileDataAccess GetInstance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new UserProfileEmployeeProfileDataAccess();
            }
            return _Instance;
        }
        set
        {
            _Instance = value;
        }
    }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

    public int UpdateUserProfileEmployeeProfile(UserProfileEmployeeProfile objUserProfileEmployeeProfile)
    {
        try
        {
            int ReturnValue = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

            SqlCmd.Parameters.Add(GetParameter("EmployeeID", SqlDbType.Int, objUserProfileEmployeeProfile.EmployeeID));
            SqlCmd.Parameters.Add(GetParameter("SettingKeyID", SqlDbType.Int, objUserProfileEmployeeProfile.SettingKeyID));
            SqlCmd.Parameters.Add(GetParameter("SettingKeyValue", SqlDbType.VarBinary, ImageFunctions.ImageToByte(objUserProfileEmployeeProfile.SettingKeyValue)));
            SqlCmd.Parameters.Add(GetParameter("SettingKeyDescription", SqlDbType.VarChar, objUserProfileEmployeeProfile.SettingKeyDescription));
            //SqlCmd.Parameters.Add(GetParameter("DateModified", SqlDbType.DateTime, objUserProfileEmployeeProfile.DateModified));
            SqlCmd.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            SqlCmd.CommandText = "pHRM_UserProfile_EmployeeProfiles_Update";
            ExecuteStoredProcedure(SqlCmd);

            ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());
            return ReturnValue;

        }
        catch(Exception ex)
        {
            throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        }
    }
    public int GetEmployeePhotoByUserID(UserProfileEmployeeProfile objUserProfileEmployeeProfile)
    {
        try
        {
            int ReturnValue = 0;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            SqlCmd.Parameters.Add(GetParameter("EmployeeID", SqlDbType.Int, objUserProfileEmployeeProfile.EmployeeID));

            SqlCmd.Parameters.Add(GetParameter("SettingKeyValue", SqlDbType.VarBinary, ImageFunctions.ImageToByte(objUserProfileEmployeeProfile.SettingKeyValue)));

            SqlCmd.CommandText = "pHRM_EmployeePhoto_Select";
            ExecuteStoredProcedure(SqlCmd);

            ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());
            return ReturnValue;
        }
        catch (Exception ex)
        {
            throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        }
    }
    public DataRow GetPhotoByUserID(int EmployeeID)
    {
        try
        {
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
            SelectCommand.CommandText = "pHRM_EmployeePhoto_Select";
            return ExecuteGetDataRow(SelectCommand);
        }
        catch (Exception ex)
        {
            throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        }
    }

    public DataTable GetPhotoByEmployeeID(int EmployeeID)
    {
        try
        {
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
            SelectCommand.CommandText = "pHRM_EmployeePhoto_Select";
            return ExecuteGetDataTable(SelectCommand);
        }
        catch (Exception ex)
        {
            throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        }
    }

        #endregion
    }
}
