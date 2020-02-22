using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
	public partial class CommonKeyDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Private static member to implement Singleton Desing Pattern
		/// </summary>
		private static CommonKeyDataAccess instance = new CommonKeyDataAccess();

		/// <summary>
		/// Static property of the class which will provide the singleton instance of it
		/// </summary>
		public static CommonKeyDataAccess GetInstance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		#region Methods and Implementation
		public DataTable GetCommonKeyList(string searchText)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
				SelectCommand.CommandText = "pADM_CommonKeys_SelectAll";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetCommonKeyListByName(string commonKeyName)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CommonKeyName", SqlDbType.VarChar, commonKeyName));
				SelectCommand.CommandText = "pADM_CommonKeys_SelectByCommonKeyName";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetCommonKeyByName(string commonKeyName)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CommonKeyName", SqlDbType.VarChar, commonKeyName));
				SelectCommand.CommandText = "pADM_CommonKeys_SelectByCommonKeyName";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataRow GetCommonKeyByID(int commonKeyID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CommonKeyID", SqlDbType.Int, commonKeyID));
				SelectCommand.CommandText = "pADM_CommonKeys_SelectByCommonKeyID";
				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int InsertCommonKey(CommonKey theCommonKey)
		{
			int ReturnValue = 0;

			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@CommonKeyName", SqlDbType.VarChar, theCommonKey.CommonKeyName));
				InsertCommand.Parameters.Add(GetParameter("@CommonKeyValue", SqlDbType.VarChar, theCommonKey.CommonKeyValue));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				InsertCommand.CommandText = "pADM_CommonKeys_Insert";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public int UpdateCommonKey(CommonKey theCommonKey)
		{
			int ReturnValue = 0;

			using (SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@CommonKeyID", SqlDbType.Int, theCommonKey.CommonKeyID));
				UpdateCommand.Parameters.Add(GetParameter("@CommonKeyName", SqlDbType.VarChar, theCommonKey.CommonKeyName));
				UpdateCommand.Parameters.Add(GetParameter("@CommonKeyValue", SqlDbType.VarChar, theCommonKey.CommonKeyValue));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

				UpdateCommand.CommandText = "pADM_CommonKeys_Update";

				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public int DeleteCommonKey(CommonKey theCommonKey)
		{
			int ReturnValue = 0;

			using (SqlCommand DeleteCommand = new SqlCommand())
			{
				DeleteCommand.CommandType = CommandType.StoredProcedure;
				DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("@CommonKeyID", SqlDbType.Int, theCommonKey.CommonKeyID));
				DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				DeleteCommand.CommandText = "pADM_CommonKeys_Delete";

				ExecuteStoredProcedure(DeleteCommand);

				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}
		#endregion
	}
}
