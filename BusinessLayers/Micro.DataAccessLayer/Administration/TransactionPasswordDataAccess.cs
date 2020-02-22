using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
	public partial class TransactionPasswordDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static TransactionPasswordDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static TransactionPasswordDataAccess GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new TransactionPasswordDataAccess();
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
		public DataRow GetTransactionPasswordByEmployeeID(int EmployeeID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
				SelectCommand.CommandText = "pHRM_TransactionPasswords_SelectByEmployeeID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int InsertTransactionPassword(TransactionPassword theTransactionPassword)
		{
			int ReturnValue = 0;
			
			using (SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, theTransactionPassword.EmployeeID));
				InsertCommand.Parameters.Add(GetParameter("@TransactionPassword", SqlDbType.VarChar, theTransactionPassword.TransactionsPassword));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pHRM_TransactionPasswords_Insert";

				ExecuteStoredProcedure(InsertCommand);
			
				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}
		#endregion
	}
}
