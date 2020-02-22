using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class CustomerLoanReceiptDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static CustomerLoanReceiptDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static CustomerLoanReceiptDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new CustomerLoanReceiptDataAccess();
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
		public DataTable GetCustomerLoanReceiptList()
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.CommandText = "pCRM_CustomerLoanReceipts_SelectAll";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetCustomerLoanReceiptListByCustomerLoanID(int customerLoanID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CustomerLoanID", SqlDbType.Int, customerLoanID));
				SelectCommand.CommandText = "pCRM_CustomerLoanReceipts_SelectByCustomerLoanID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataRow GetCustomerLoanReceiptByID(int loanReceiptID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CustomerLoanReceiptID", SqlDbType.Int, loanReceiptID));
				SelectCommand.CommandText = "pCRM_CustomerLoanReceipts_SelectByCustomerLoanReceiptID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public int InsertCustomerLoanReceipt(CustomerLoanReceipt theCustomerLoanReceipt)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@ReceiptSeries", SqlDbType.VarChar, theCustomerLoanReceipt.ReceiptSeries));
				InsertCommand.Parameters.Add(GetParameter("@CustomerLoanID", SqlDbType.Int, theCustomerLoanReceipt.CustomerLoanID));
				InsertCommand.Parameters.Add(GetParameter("@DateOfRecovery", SqlDbType.VarChar, theCustomerLoanReceipt.DateOfRecovery));
				InsertCommand.Parameters.Add(GetParameter("@AmountPaid", SqlDbType.Decimal, theCustomerLoanReceipt.AmountPaid));
				InsertCommand.Parameters.Add(GetParameter("@AmountPaidAsPrincipal", SqlDbType.Decimal, theCustomerLoanReceipt.AmountPaidAsPrincipal));
				InsertCommand.Parameters.Add(GetParameter("@AmountPaidAsInterest", SqlDbType.Decimal, theCustomerLoanReceipt.AmountPaidAsInterest));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentNumber", SqlDbType.Int, theCustomerLoanReceipt.InstallmentNumber));
				InsertCommand.Parameters.Add(GetParameter("@Remark", SqlDbType.VarChar, theCustomerLoanReceipt.Remark));
				InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_CustomerLoanReceipts_Insert";
				ExecuteStoredProcedure(InsertCommand);
				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				return ReturnValue;
			}
		}

		public int UpdateCustomerLoanReceipt()
		{
			return 0;
		}

		public int DeleteCustomerLoanReceipt()
		{
			return 0;
		}
		#endregion
	}
}
