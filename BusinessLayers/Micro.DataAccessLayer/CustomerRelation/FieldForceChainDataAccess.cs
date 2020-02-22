using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class FieldForceChainDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static FieldForceChainDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static FieldForceChainDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new FieldForceChainDataAccess();
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
		public DataTable GetFieldForceChain(int fieldForceId)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, fieldForceId));
				SelectCommand.CommandText = "pCRM_FieldForces_SelectChainByFieldForceID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetFieldForceChainsByFieldForceID(int fieldForceId)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, fieldForceId));
				SelectCommand.CommandText = "pCRM_FieldForceChains_SelectByFieldForceID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public int InsertFieldForceChain(FieldForce theFieldForce)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, theFieldForce.FieldForceID));
				InsertCommand.Parameters.Add(GetParameter("@ReportingToFieldForceID", SqlDbType.Int, theFieldForce.ReportingToFieldForceID));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_FieldForceChains_Insert";

				ExecuteStoredProcedure(InsertCommand);
				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
			}

			return ReturnValue;
		}

		public int UpdateFieldForceChain(FieldForce theFieldForce)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@FieldForceID", SqlDbType.Int, theFieldForce.FieldForceID));
				InsertCommand.Parameters.Add(GetParameter("@ReportingToFieldForceID", SqlDbType.Int, theFieldForce.ReportingToFieldForceID));
				InsertCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_FieldForceChains_UpdateChainSetting";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}
		#endregion
	}
}
