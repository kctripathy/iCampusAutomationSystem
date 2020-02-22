using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Micro.Objects.ICAS.ADMIN;

namespace Micro.DataAccessLayer.ICAS.ADMIN
{
    public partial class UserDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static UserDataAccess instance = new UserDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static UserDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implemenations
        public DataTable GetUserList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                //SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                //SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                //SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pADM_Users_SelectDetailsAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetUserByID(int userID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@UserId", SqlDbType.Int, userID));
                SelectCommand.CommandText = "pADM_Users_SelectByUserID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetUserByLoginName(string loginName)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@LoginName", SqlDbType.VarChar, loginName));
                SelectCommand.CommandText = "pADM_Users_SelectByLoginName";
                return ExecuteGetDataRow(SelectCommand);
            }
        }
		/// <summary>
		/// Used For LogIn User Control
		/// </summary>
		/// <param name="loginName"></param>
		/// <returns></returns>
		public DataRow GetUserByLoginNameGuset(string loginName)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@LoginName", SqlDbType.VarChar, loginName));
				SelectCommand.CommandText = "pADM_Users_SelectByLoginName_Test";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public DataRow GetUserByUserReferenceID(int UserReferenceID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@UserReferenceID", SqlDbType.Int, UserReferenceID));
				SelectCommand.CommandText = "pADM_Users_SelectByUserReferenceID";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

        public DataRow GetUserByLoginCredentials(User theUser)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@UserName", SqlDbType.VarChar, theUser.UserName));
                SelectCommand.Parameters.Add(GetParameter("@Password", SqlDbType.VarChar, theUser.Password));
                SelectCommand.CommandText = "pADM_Users_SelectByLoginCredentials";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GeneratePassword()
        {
            try
            {
                string ReturnValue = "";

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.VarChar, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.CommandText = "pADM_Users_GenerateNewPassword";

                return ExecuteGetDataRow(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateUser(User theUser)
        {
            int ReturnValue = 0;
            {
                using (SqlCommand UpdateCommand = new SqlCommand())
                {
                    UpdateCommand.CommandType = CommandType.StoredProcedure;
                    UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                    UpdateCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theUser.UserID));
                    //UpdateCommand.Parameters.Add(GetParameter("@OldPassword", SqlDbType.VarChar, Micro.Commons.Connection.LoggedOnUser.Password));
                    UpdateCommand.Parameters.Add(GetParameter("@NewPassword", SqlDbType.VarChar, theUser.Password));
                    UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                    UpdateCommand.CommandText = "pADM_Users_Update";

                    ExecuteStoredProcedure(UpdateCommand);

                    ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                    return ReturnValue;
                }
            }
        }

        public int UpdateUserPassword(User theUser)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theUser.UserID));
                UpdateCommand.Parameters.Add(GetParameter("@NewPassword", SqlDbType.VarChar,Micro.Commons.MicroSecuritty.Encrypt(theUser.Password)));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pADM_Users_ResetPassword";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int UpdateUserRole(User theUser)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, theUser.UserID));
                UpdateCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, theUser.RoleID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pADM_Users_UpdateRole";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int InsertUser(User theUser)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@UserName", SqlDbType.VarChar, theUser.UserName));
                InsertCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, theUser.RoleID));
                InsertCommand.Parameters.Add(GetParameter("@Password", SqlDbType.VarChar, theUser.Password));
                InsertCommand.Parameters.Add(GetParameter("@UserType", SqlDbType.VarChar, theUser.UserType));
                InsertCommand.Parameters.Add(GetParameter("@UserReferenceID", SqlDbType.Int, theUser.UserReferenceID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pADM_Users_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int DeleteUser(int UserID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand DeleteCommand = new SqlCommand();
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, UserID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pADM_Users_Delete";

                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;

            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

		public int InsertUserPageVisit(int logId, int pageId)
		{
			int ReturnValue = 0;
			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@LogId", SqlDbType.Int,logId));
				InsertCommand.Parameters.Add(GetParameter("@WebMenuId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pADM_UserPageVisits_Insert";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public void UpdateUserPageVisit(int recordId)
		{
			using (SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@RecordID", SqlDbType.Int, recordId));
				UpdateCommand.CommandText = "pADM_UserPageVisits_Update";

				ExecuteStoredProcedure(UpdateCommand);

			}
		}

		public DataTable GetErrorLogs()
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.CommandText = "pADM_ErrorLog_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}
        #endregion
    }
}
