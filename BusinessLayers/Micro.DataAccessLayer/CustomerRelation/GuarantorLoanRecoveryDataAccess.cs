using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class GuarantorLoanRecoveryDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static GuarantorLoanRecoveryDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static GuarantorLoanRecoveryDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GuarantorLoanRecoveryDataAccess();
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
        public DataTable GetGuarantorLoanRecoveries(string searchText)
       {
           SqlCommand SelectCommand = new SqlCommand();

           SelectCommand.CommandType = CommandType.StoredProcedure;
           SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
           SelectCommand.CommandText = "pCRM_GuarantorLoanReceipts_SelectAll";

           return ExecuteGetDataTable(SelectCommand);
       }

        public DataTable GetActiveLoanDetails(int loanApplicantId, string loanAppliedBy)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@LoanApplicantID", SqlDbType.Int, loanApplicantId));
            SelectCommand.Parameters.Add(GetParameter("@LoanAppliedBy", SqlDbType.VarChar, loanAppliedBy));
            SelectCommand.CommandText = "pCRM_GuarantorLoans_SelectActiveLoanByLoanApplicantID";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataTable GetGuarantorLoanRecoveriesByGuarantorLoanId(int guarantorloanId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@GuarantorLoanID", SqlDbType.Int, guarantorloanId));
            SelectCommand.CommandText = "pCRM_GuarantorLoanReceipts_SelectByGuarantorLoanID";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataRow GetGuarantorLoanRecoveriesById(int recordId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@GuarantorLoanReceiptID", SqlDbType.Int, recordId));
            SelectCommand.CommandText = "pCRM_GuarantorLoanReceipts_SelectByGuarantorLoanReceiptID";

            return ExecuteGetDataRow(SelectCommand);
        }

        public DataTable GetLoanHistoryDetails(int RecordID)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@GuarantorLoanID", SqlDbType.Int, RecordID));
            SelectCommand.CommandText = "pCRM_GuarantorLoanReceipts_SelectByGuarantorLoanID";

            return ExecuteGetDataTable(SelectCommand);
        }

        public int InsertGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;

            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@GuarantorLoanID", SqlDbType.Int, theGuarantorLoanRecovery.GuarantorLoanID));
            InsertCommand.Parameters.Add(GetParameter("@ReceiptSeries", SqlDbType.VarChar, theGuarantorLoanRecovery.ReceiptSeries));
            InsertCommand.Parameters.Add(GetParameter("@DateOfRecovery", SqlDbType.VarChar, theGuarantorLoanRecovery.DateOfRecovery));
            InsertCommand.Parameters.Add(GetParameter("@InstallmentNumber", SqlDbType.Int, theGuarantorLoanRecovery.InstallmentNumber));
            InsertCommand.Parameters.Add(GetParameter("@AmountPaid", SqlDbType.Decimal, theGuarantorLoanRecovery.AmountPaid));
            InsertCommand.Parameters.Add(GetParameter("@AmountPaidAsPrincipal", SqlDbType.Decimal, theGuarantorLoanRecovery.AmountPaidAsPrincipal));
            InsertCommand.Parameters.Add(GetParameter("@AmountPaidAsInterest", SqlDbType.Decimal, theGuarantorLoanRecovery.AmountPaidAsInterest));
            InsertCommand.Parameters.Add(GetParameter("@PaymentMode", SqlDbType.VarChar, theGuarantorLoanRecovery.PaymentMode));
            InsertCommand.Parameters.Add(GetParameter("@PaymentReference", SqlDbType.VarChar, theGuarantorLoanRecovery.PaymentReference));
            InsertCommand.Parameters.Add(GetParameter("@Remark", SqlDbType.VarChar, theGuarantorLoanRecovery.Remark));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

            InsertCommand.CommandText = "pCRM_GuarantorLoanReceipts_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int UpdateGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            int ReturnValue = 0;

            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;

            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@GuarantorLoanReceiptID", SqlDbType.Int, theGuarantorLoanRecovery.GuarantorLoanReceiptID));
            UpdateCommand.Parameters.Add(GetParameter("@GuarantorLoanID", SqlDbType.Int, theGuarantorLoanRecovery.GuarantorLoanID));
            UpdateCommand.Parameters.Add(GetParameter("@ReceiptSeries", SqlDbType.VarChar, theGuarantorLoanRecovery.ReceiptSeries));
            UpdateCommand.Parameters.Add(GetParameter("@DateOfRecovery", SqlDbType.VarChar, theGuarantorLoanRecovery.DateOfRecovery));
            UpdateCommand.Parameters.Add(GetParameter("@InstallmentNumber", SqlDbType.Int, theGuarantorLoanRecovery.InstallmentNumber));
            UpdateCommand.Parameters.Add(GetParameter("@AmountPaid", SqlDbType.Decimal, theGuarantorLoanRecovery.AmountPaid));
            UpdateCommand.Parameters.Add(GetParameter("@AmountPaidAsPrincipal", SqlDbType.Decimal, theGuarantorLoanRecovery.AmountPaidAsPrincipal));
            UpdateCommand.Parameters.Add(GetParameter("@AmountPaidAsInterest", SqlDbType.Decimal, theGuarantorLoanRecovery.AmountPaidAsInterest));
            UpdateCommand.Parameters.Add(GetParameter("@PaymentMode", SqlDbType.VarChar, theGuarantorLoanRecovery.PaymentMode));
            UpdateCommand.Parameters.Add(GetParameter("@PaymentReference", SqlDbType.VarChar, theGuarantorLoanRecovery.PaymentReference));
            UpdateCommand.Parameters.Add(GetParameter("@Remark", SqlDbType.VarChar, theGuarantorLoanRecovery.Remark));
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

            UpdateCommand.CommandText = "pCRM_GuarantorLoanReceipts_Update";

            ExecuteStoredProcedure(UpdateCommand);
            ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int DeleteGuarantorLoanRecovery(GuarantorLoanRecoveries theGuarantorLoanRecovery)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@GuarantorLoanReceiptID", SqlDbType.Int, theGuarantorLoanRecovery.GuarantorLoanReceiptID));
            DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            DeleteCommand.CommandText = "pCRM_GuarantorLoanReceipts_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }
        #endregion
    }
}
