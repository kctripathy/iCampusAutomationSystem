using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
    public partial class UserDataAccess : AbstractData_SQLClient
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public DataTable GetUserSettingKeyList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_UserSettingKeys_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetUserSettingList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_UserSettings_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetUserSettingListByUserID()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@UserId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserId));
                SelectCommand.CommandText = "pADM_UserSettings_SelectByUserID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

		public DataTable GetUserSettingListByUserID(int userId)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@UserId", SqlDbType.Int, userId));
				SelectCommand.CommandText = "pADM_UserSettings_SelectByUserID";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public int SaveUserSettings(string settingKey, string settingValue)
        {
			int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@UserId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.Parameters.Add(GetParameter("@UserSettingKeyName", SqlDbType.VarChar, settingKey));
				InsertCommand.Parameters.Add(GetParameter("@UserSettingValue", SqlDbType.VarChar, settingValue));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pADM_UserSettings_Insert";
                ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
            }
        }

        public void SaveUserSettings(List<UserSetting> userSettingList)
        {
            int TotSettings = userSettingList.Count + 1;
            int Ctr = 0;

            SqlCommand[] InsertCommand = new SqlCommand[TotSettings];

            // Command object to delete all the records or settings before inserting new values
            InsertCommand[Ctr] = new SqlCommand();
            InsertCommand[Ctr].Parameters.Add(GetParameter("@TheUserId", SqlDbType.Int, 0)); // No need to delete, so supplied 0 as user id
            InsertCommand[Ctr].CommandText = "pADM_UserSettings_DeleteByUserId";

            // Command object to Insert a settings
            foreach (UserSetting ust in userSettingList)
            {
                Ctr++;
                InsertCommand[Ctr] = new SqlCommand();
                InsertCommand[Ctr].Parameters.Add(GetParameter("@UserId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser));
                InsertCommand[Ctr].Parameters.Add(GetParameter("@SettingKey", SqlDbType.VarChar, ust.UserSettingKeyName));
                InsertCommand[Ctr].Parameters.Add(GetParameter("@SettingValue", SqlDbType.VarChar, ust.UserSettingValue));
                InsertCommand[Ctr].Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser));
                InsertCommand[Ctr].CommandText = "pADM_UserSettings_InsertKeyValue";
            }

            ExecuteStoredProcedure(InsertCommand);
        }

        public void DeleteAllUserSettings()
        {
            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@TheUserId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pADM_UserSettings_DeleteByUserId";
                ExecuteStoredProcedure(DeleteCommand);
            }
        }
        #endregion
    }
}
