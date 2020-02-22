using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer
{
    public class LoginManagementData: AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static LoginManagementData instance = new LoginManagementData();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static LoginManagementData GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Specify the connection to database
        private LoginManagementData()
        {
            this.ConnectionKey = "CONNECTION-MicroERP";
        }
        #endregion

        #region Methods and Implementations
        public DataRow CheckLoginCredentials(User CurrentUser)
        {
            DataRow drUserInfo = null;
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@UserName", SqlDbType.VarChar, CurrentUser.UserName));
            SelectCommand.Parameters.Add(GetParameter("@Password", SqlDbType.VarChar, CurrentUser.Password));
            SelectCommand.CommandText = "pADM_Users_SelectByLoginCredentials";

            drUserInfo = ExecuteGetDataRow(SelectCommand);
            return drUserInfo;
        }

		public int InsertUserSessionLog(UserLog usrLog)
		{
			SqlCommand InsertCommand = new SqlCommand();
			int ReturnValue = 0;
			InsertCommand.CommandType = CommandType.StoredProcedure;
			InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
			InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, usrLog.OfficeID));
			InsertCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, usrLog.UserID));
			InsertCommand.Parameters.Add(GetParameter("@LoggedOnDateTime", SqlDbType.DateTime, DateTime.Now));
			InsertCommand.Parameters.Add(GetParameter("@LoggedOnFromSystemIP", SqlDbType.VarChar, usrLog.LoggedOnFromSystemIP));
			InsertCommand.Parameters.Add(GetParameter("@ClientComputerName", SqlDbType.VarChar, usrLog.ClientComputerName));
			InsertCommand.Parameters.Add(GetParameter("@SessionId", SqlDbType.VarChar, usrLog.SessionID));
			InsertCommand.CommandText = "dbo.pADM_Users_Log_Insert";

			ExecuteStoredProcedure(InsertCommand);

			ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

			return ReturnValue;
		}

		public void UpdateUserSessionLogout(int logId)
		{
		
			SqlCommand UpdateCommand = new SqlCommand();
			UpdateCommand.CommandType = CommandType.StoredProcedure;
			UpdateCommand.Parameters.Add(GetParameter("@LogId", SqlDbType.Int, logId));
			UpdateCommand.Parameters.Add(GetParameter("@LoggedOutDateTime", SqlDbType.DateTime, DateTime.Now));
			UpdateCommand.CommandText = "dbo.pADM_Users_Log_Update";

			ExecuteStoredProcedure(UpdateCommand);
		}


		public DataTable SelectUserSessionLogs()
		{

			SqlCommand SelectCommand = new SqlCommand();
			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.CommandText = "dbo.pADM_Users_Log_Select";

			return ExecuteGetDataTable(SelectCommand);
		}
        #endregion
    }
}
