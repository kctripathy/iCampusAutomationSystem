using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
	public partial class CustomerAccountReceiptDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static CustomerAccountReceiptDataAccess _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static CustomerAccountReceiptDataAccess GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new CustomerAccountReceiptDataAccess();
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
		public DataTable GetCustomerAccountReceiptsByScrollID(int scrollID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, scrollID));
				SelectCommand.CommandText = "pCRM_Receipts_SelectByScrollID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetCustomerAccountReceiptsByCustomerAccountID(int customerAccountID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, customerAccountID));
				SelectCommand.CommandText = "pCRM_Receipts_SelectByCustomerAccountID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetCustomerAccountReceiptsByDCAccountID(int DCAccountID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@DCAccountID", SqlDbType.Int, DCAccountID));
				SelectCommand.CommandText = "pCRM_Receipts_SelectByDCAccountID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public int CancelCustomerAccountReceipt(CustomerAccountReceipt theCustomerAccountReceipt)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@CancelledReceiptID", SqlDbType.Int, theCustomerAccountReceipt.ReceiptID));
				InsertCommand.Parameters.Add(GetParameter("@ReceiptSeries", SqlDbType.VarChar, theCustomerAccountReceipt.ReceiptSeries));
				InsertCommand.Parameters.Add(GetParameter("@ReceiptDate", SqlDbType.VarChar, theCustomerAccountReceipt.ReceiptDate));
				InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theCustomerAccountReceipt.CustomerAccountID));
				InsertCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, theCustomerAccountReceipt.PolicyTypeID));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentNumberFrom", SqlDbType.Int, theCustomerAccountReceipt.InstallmentNumberFrom));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentNumberTo", SqlDbType.Int, theCustomerAccountReceipt.InstallmentNumberTo));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmountPayable", SqlDbType.Decimal, theCustomerAccountReceipt.InstallmentAmountPayable));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmountPaid", SqlDbType.Decimal, theCustomerAccountReceipt.InstallmentAmountPaid));
				InsertCommand.Parameters.Add(GetParameter("@AdmissionOrFineAmount", SqlDbType.Decimal, theCustomerAccountReceipt.AdmissionOrFineAmount));
				InsertCommand.Parameters.Add(GetParameter("@RebateAmount", SqlDbType.Decimal, theCustomerAccountReceipt.RebateAmount));
				InsertCommand.Parameters.Add(GetParameter("@PaymentMode", SqlDbType.VarChar, theCustomerAccountReceipt.PaymentMode));
				InsertCommand.Parameters.Add(GetParameter("@PaymentReference", SqlDbType.VarChar, theCustomerAccountReceipt.PaymentReference));
				InsertCommand.Parameters.Add(GetParameter("@DueDateOfNextInstallment", SqlDbType.VarChar, theCustomerAccountReceipt.DueDateOfNextInstallment));
				InsertCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, theCustomerAccountReceipt.ScrollID));
				InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_Receipts_Cancel";

				ExecuteStoredProcedure(InsertCommand);
	
				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				
				return ReturnValue;
			}
		}

        public int InsertCustomerAccountReceipt(CustomerAccountReceipt theCustomerAccountReceipt)
        {
            int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@ReceiptDate", SqlDbType.VarChar, theCustomerAccountReceipt.ReceiptDate));
				InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theCustomerAccountReceipt.CustomerAccountID));
				InsertCommand.Parameters.Add(GetParameter("@PolicyTypeID", SqlDbType.Int, theCustomerAccountReceipt.PolicyTypeID));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentNumberFrom", SqlDbType.Int, theCustomerAccountReceipt.InstallmentNumberFrom));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentNumberTo", SqlDbType.Int, theCustomerAccountReceipt.InstallmentNumberTo));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmountPayable", SqlDbType.Decimal, theCustomerAccountReceipt.InstallmentAmountPayable));
				InsertCommand.Parameters.Add(GetParameter("@InstallmentAmountPaid", SqlDbType.Decimal, theCustomerAccountReceipt.InstallmentAmountPaid));
				InsertCommand.Parameters.Add(GetParameter("@AdmissionOrFineAmount", SqlDbType.Decimal, theCustomerAccountReceipt.AdmissionOrFineAmount));
				InsertCommand.Parameters.Add(GetParameter("@RebateAmount", SqlDbType.Decimal, theCustomerAccountReceipt.RebateAmount));
				InsertCommand.Parameters.Add(GetParameter("@PaymentMode", SqlDbType.VarChar, theCustomerAccountReceipt.PaymentMode));
				InsertCommand.Parameters.Add(GetParameter("@PaymentReference", SqlDbType.VarChar, theCustomerAccountReceipt.PaymentReference));
				InsertCommand.Parameters.Add(GetParameter("@DueDateOfNextInstallment", SqlDbType.VarChar, theCustomerAccountReceipt.DueDateOfNextInstallment));
				InsertCommand.Parameters.Add(GetParameter("@ScrollID", SqlDbType.Int, theCustomerAccountReceipt.ScrollID));
				InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_Receipts_Insert";
				
				ExecuteStoredProcedure(InsertCommand);

				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				
				return ReturnValue;
			}
        }
		#endregion
	}
}
