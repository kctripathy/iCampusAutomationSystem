using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class DCAccountDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static DCAccountDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static DCAccountDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new DCAccountDataAccess();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		#region Declaration
		#endregion

		#region Methods & Implementation
        public DataTable GetDCAccountList(bool allOffices = false, bool showDeleted = false)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pCRM_DCAccounts_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetUnallotedDCAccounts(bool allOffices = false, bool showDeleted = false)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
				SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				SelectCommand.CommandText = "pCRM_DCAccounts_SelectUnalloted";
				
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataRow GetDCAccountById(int theDCAccountID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@DCAccountID", SqlDbType.Int, theDCAccountID));
				SelectCommand.CommandText = "pCRM_DCAccounts_SelectByDCAccountID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int InsertDCAccount(DCAccount theDCAccount)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@CustomerName", SqlDbType.VarChar, theDCAccount.CustomerName));
				InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theDCAccount.FatherName));
				InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theDCAccount.Address_Present_TownOrCity));
				InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theDCAccount.Address_Present_Landmark));
				InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theDCAccount.Address_Present_PinCode));
				InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theDCAccount.Address_Present_DistrictID));
				InsertCommand.Parameters.Add(GetParameter("@CommencementDate", SqlDbType.VarChar, theDCAccount.CommencementDate));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmountDaily", SqlDbType.Decimal, theDCAccount.InstallmentAmountDaily));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmountMonthly", SqlDbType.Decimal, theDCAccount.InstallmentAmountMonthly));
				InsertCommand.Parameters.Add(GetParameter("@DCCollectorID", SqlDbType.Int, theDCAccount.DCCollectorID));
				InsertCommand.Parameters.Add(GetParameter("@AccountStatus", SqlDbType.VarChar, theDCAccount.AccountStatus));
				InsertCommand.Parameters.Add(GetParameter("@BalanceAmount", SqlDbType.Decimal, theDCAccount.BalanceAmount));
				InsertCommand.Parameters.Add(GetParameter("@IsToBeUpdated", SqlDbType.Bit, theDCAccount.IsToBeUpdated));
				InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_DCAccounts_Insert";

				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}

		public int UpdateDCAccount(DCAccount theDCAccount)
		{
			int ReturnValue = 0;

			using(SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@DCAccountID", SqlDbType.Int, theDCAccount.DCAccountID));
				//UpdateCommand.Parameters.Add(GetParameter("@DCAccountCode", SqlDbType.VarChar, theDCAccount.DCAccountCode));
				UpdateCommand.Parameters.Add(GetParameter("@CustomerName", SqlDbType.VarChar, theDCAccount.CustomerName));
				UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theDCAccount.FatherName));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theDCAccount.Address_Present_TownOrCity));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theDCAccount.Address_Present_Landmark));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theDCAccount.Address_Present_PinCode));
				UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theDCAccount.Address_Present_DistrictID));
				UpdateCommand.Parameters.Add(GetParameter("@CommencementDate", SqlDbType.VarChar, theDCAccount.CommencementDate));
				UpdateCommand.Parameters.Add(GetParameter("@InstallmentAmountDaily", SqlDbType.Decimal, theDCAccount.InstallmentAmountDaily));
				UpdateCommand.Parameters.Add(GetParameter("@InstallmentAmountMonthly", SqlDbType.Decimal, theDCAccount.InstallmentAmountMonthly));
				UpdateCommand.Parameters.Add(GetParameter("@DCCollectorID", SqlDbType.Int, theDCAccount.DCCollectorID));
				UpdateCommand.Parameters.Add(GetParameter("@AccountStatus", SqlDbType.VarChar, theDCAccount.AccountStatus));
				UpdateCommand.Parameters.Add(GetParameter("@BalanceAmount", SqlDbType.Decimal, theDCAccount.BalanceAmount));
				UpdateCommand.Parameters.Add(GetParameter("@IsToBeUpdated", SqlDbType.Bit, theDCAccount.IsToBeUpdated));
				UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				UpdateCommand.CommandText = "pCRM_DCAccounts_Update";
				
				ExecuteStoredProcedure(UpdateCommand);
				
				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
				
				return ReturnValue;
			}
		}

		public int DeleteDCAccount(DCAccount theDCAccount)
		{
			int ReturnValue = 0;

			using(SqlCommand DeleteCommand = new SqlCommand())
			{
				DeleteCommand.CommandType = CommandType.StoredProcedure;
				DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("@DCAccountID", SqlDbType.Int, theDCAccount.DCAccountID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				DeleteCommand.CommandText = "pCRM_DCAccounts_Delete";
				
				ExecuteStoredProcedure(DeleteCommand);
				
				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
				
				return ReturnValue;
			}
		}
		#endregion
	}
}
