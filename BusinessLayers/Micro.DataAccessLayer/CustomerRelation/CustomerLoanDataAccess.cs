using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;
using System;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class CustomerLoanDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CustomerLoanDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CustomerLoanDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerLoanDataAccess();
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
        public DataTable GetCustomerLoanList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_CustomerLoans_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetCustomerLoanListByCustomerAccountID(int customerAccountID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, customerAccountID));
				SelectCommand.CommandText = "pCRM_CustomerLoans_SelectByCustomerAccountID";

				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public DataTable GetCustomerLoanListByOfficeIDs(string officeIDs, bool allOffices)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, officeIDs));
                SelectCommand.CommandText = "pRPT_CustomerLoans_SelectByOfficeID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

		public DataRow GetCustomerLoanByCustomerLoanID(int customerLoanID)
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CustomerLoanID", SqlDbType.Int, customerLoanID));
				SelectCommand.CommandText = "pCRM_CustomerLoans_SelectByCustomerLoanID";

				return ExecuteGetDataRow(SelectCommand);
			}
		}

		public DataRow GetMaxLoanCanAvailByCustomerAccountID(int customerAccountID)
        {
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, customerAccountID));
				SelectCommand.CommandText = "pCRM_CustomerLoans_SelectMaxLoanCanAvailByCustomerAccountID";

				return ExecuteGetDataRow(SelectCommand);
			}
        }

        public DataRow GetActiveLoanDetailsByCustomerAccountID(int customerAccountID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, customerAccountID));
                SelectCommand.CommandText = "pCRM_CustomerLoans_SelectActiveLoanByCustomerAccountID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetInterestAmount(int customerLoanID, DateTime recoveryDate)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerLoanID", SqlDbType.Int, customerLoanID));
                SelectCommand.Parameters.Add(GetParameter("@DateOfRecovery", SqlDbType.Date, recoveryDate));
                SelectCommand.CommandText = "pCRM_CustomerLoans_SelectInterestAmount";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

		public int InsertCustomerLoan(CustomerLoan theCustomerLoan)
		{
			int ReturnValue = 0;

			using(SqlCommand InsertCommand = new SqlCommand())
			{
				InsertCommand.CommandType = CommandType.StoredProcedure;
				InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theCustomerLoan.CustomerAccountID));
				InsertCommand.Parameters.Add(GetParameter("@LoanApplicationDate", SqlDbType.VarChar, theCustomerLoan.LoanApplicationDate));
				InsertCommand.Parameters.Add(GetParameter("@LoanAmount", SqlDbType.Decimal, theCustomerLoan.LoanAmount));
				InsertCommand.Parameters.Add(GetParameter("@RequiredFor", SqlDbType.VarChar, theCustomerLoan.RequiredFor));
				InsertCommand.Parameters.Add(GetParameter("@LoanApplicationFee", SqlDbType.Decimal, theCustomerLoan.LoanApplicationFee));
				InsertCommand.Parameters.Add(GetParameter("@RateOfInterest", SqlDbType.Decimal, theCustomerLoan.RateOfInterest));
				InsertCommand.Parameters.Add(GetParameter("@SanctionedByID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_CustomerLoans_Insert";

				ExecuteStoredProcedure(InsertCommand);
				
				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
				
				return ReturnValue;
			}
		}

		public int UpdateCustomerLoan(CustomerLoan theCustomerLoan)
		{
			int ReturnValue = 0;

			using(SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationNumber", SqlDbType.VarChar, theCustomerLoan.LoanApplicationNumber));
				UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationDate", SqlDbType.VarChar, theCustomerLoan.LoanApplicationDate));
				UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationFee", SqlDbType.Decimal, theCustomerLoan.LoanApplicationFee));
				UpdateCommand.Parameters.Add(GetParameter("@LoanAmount", SqlDbType.Decimal, theCustomerLoan.LoanAmount));
				UpdateCommand.Parameters.Add(GetParameter("@RateOfInterest", SqlDbType.Decimal, theCustomerLoan.RateOfInterest));
				UpdateCommand.Parameters.Add(GetParameter("@RequiredFor", SqlDbType.VarChar, theCustomerLoan.RequiredFor));
				UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				UpdateCommand.CommandText = "pCRM_CustomerLoans_Update";
				
				ExecuteStoredProcedure(UpdateCommand);
				
				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
				
				return ReturnValue;
			}
		}

		public int DeleteCustomerLoan(CustomerLoan theCustomerLoan)
		{
			int ReturnValue = 0;

			using(SqlCommand DeleteCommand = new SqlCommand())
			{
				DeleteCommand.CommandType = CommandType.StoredProcedure;
				DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				DeleteCommand.Parameters.Add(GetParameter("@CustomerLoanID", SqlDbType.Int, theCustomerLoan.CustomerLoanID));
				DeleteCommand.CommandText = "pCRM_CustomerLoans_Delete";
				
				ExecuteStoredProcedure(DeleteCommand);
				
				ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
				
				return ReturnValue;
			}
		}

        public DataTable GetCustomerLoanListByCustomerID(int customerID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, customerID));
                SelectCommand.CommandText = "pCRM_CustomerLoans_SelectByCustomerID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        #endregion
    }
}
