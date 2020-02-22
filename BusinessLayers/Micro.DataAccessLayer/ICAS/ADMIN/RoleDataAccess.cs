using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.ADMIN;

namespace Micro.DataAccessLayer.ICAS.ADMIN
{
	public partial class RoleDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static RoleDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static RoleDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new RoleDataAccess();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		#region Methods & Implementation
		public DataTable GetAllRoles(System.String searchText = null, bool showDeleted = false)
		{
			SqlCommand SelectCmd = new SqlCommand();
			SelectCmd.CommandType = CommandType.StoredProcedure;

			SelectCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
			SelectCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
			SelectCmd.CommandText = "pADM_Roles_Select";

			return ExecuteGetDataTable(SelectCmd);
		}

		public DataTable GetRoleList(bool showDeleted = false)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.CommandText = "pADM_Roles_SelectAll";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataRow GetRoleById(int roleId)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.Parameters.Add(GetParameter("@RoleId", SqlDbType.Int, roleId));
				SelectCommand.CommandText = "pADM_Roles_SelectByID";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int InsertRole(Role theRole)
		{
			int ReturnValue=0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@RoleDescription", SqlDbType.VarChar, theRole.RoleDescription));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pADM_Roles_Insert";
				ExecuteStoredProcedure(InsertCommand);
				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				return ReturnValue;
			}
		}

		public int UpdateRole(Role theRole)
		{
			int ReturnValue=0;

			using(SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@RoleId", SqlDbType.Int, theRole.RoleID));
				UpdateCommand.Parameters.Add(GetParameter("@RoleDescription", SqlDbType.VarChar, theRole.RoleDescription));
				UpdateCommand.Parameters.Add(GetParameter("@UpdatedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				UpdateCommand.CommandText = "pADM_Roles_Update";
				ExecuteStoredProcedure(UpdateCommand);
				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
				return ReturnValue;
			}
		}

		public int DeleteRole(int roleId)
		{
			int ReturnValue=0;

			using(SqlCommand DeleteCommand = new SqlCommand())
			{
				DeleteCommand.CommandType = CommandType.StoredProcedure;
				DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("@RoleId", SqlDbType.Int, roleId));
				DeleteCommand.CommandText = "pADM_Roles_Delete";
				ExecuteStoredProcedure(DeleteCommand);
				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
				return ReturnValue;
			}
		}

		#endregion
        public string SendMicroSMS(string phoneNumber, string messageText)
        {
            string ReturnValue = string.Empty;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@Response", SqlDbType.VarChar, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@MobileNumber", SqlDbType.VarChar, phoneNumber));
                InsertCommand.Parameters.Add(GetParameter("@SMSText", SqlDbType.VarChar, messageText));
                InsertCommand.CommandText = "MYMESSAGE";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = InsertCommand.Parameters[0].Value.ToString();
                return ReturnValue;
            }
        }

	}
}
