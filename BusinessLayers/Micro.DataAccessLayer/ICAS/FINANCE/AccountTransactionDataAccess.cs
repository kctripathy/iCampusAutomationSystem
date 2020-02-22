using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.DataAccessLayer.ICAS.FINANCE
{
    public partial class AccountTransactionDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static AccountTransactionDataAccess instance = new AccountTransactionDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static AccountTransactionDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Methods & Implementation
        public DataTable GetAccountTransactionList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 23));//TO DO :rEMOVE HARDCODE: Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.CommandText = "pICAS_FIN_Transactions_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetAccountTransactionListByDate(string transactionDate, bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@TransactionDate", SqlDbType.VarChar, transactionDate));
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pICAS_FIN_Transactions_SelectByDate";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetAccountTransactionByID(int transactionID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@TransactionID", SqlDbType.Int, transactionID));
                SelectCommand.CommandText = "pICAS_FIN_Transactions_SelectByID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetCashBalances()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 23));//SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID
                SelectCommand.CommandText = "pICAS_FIN_Transactions_SelectCashBalances";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertAccountTransaction(AccountTransaction theAccountTransaction)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@TransactionDate", SqlDbType.VarChar, theAccountTransaction.TransactionDate));
                InsertCommand.Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, theAccountTransaction.AccountID));
                InsertCommand.Parameters.Add(GetParameter("@AccountHeadID", SqlDbType.Int, theAccountTransaction.AccountHeadID));
                InsertCommand.Parameters.Add(GetParameter("@TransactionToCategory", SqlDbType.VarChar, theAccountTransaction.TransactionToCategory));
                InsertCommand.Parameters.Add(GetParameter("@TransactionToID", SqlDbType.VarChar, theAccountTransaction.TransactionToID));
                InsertCommand.Parameters.Add(GetParameter("@ThirdPartyDescription", SqlDbType.VarChar, theAccountTransaction.ThirdPartyDescription));
                InsertCommand.Parameters.Add(GetParameter("@TransactionAmount", SqlDbType.Decimal, theAccountTransaction.TransactionAmount));
                InsertCommand.Parameters.Add(GetParameter("@TransactionMode", SqlDbType.VarChar, theAccountTransaction.TransactionMode));
                //InsertCommand.Parameters.Add(GetParameter("@TransactionReference", SqlDbType.VarChar, theAccountTransaction.TransactionReference));
                InsertCommand.Parameters.Add(GetParameter("@BankName", SqlDbType.VarChar, theAccountTransaction.BankName));
                InsertCommand.Parameters.Add(GetParameter("@ChqDate", SqlDbType.VarChar, theAccountTransaction.ChqDate));
                InsertCommand.Parameters.Add(GetParameter("@ChqNumber", SqlDbType.VarChar, theAccountTransaction.ChqNumber));
                InsertCommand.Parameters.Add(GetParameter("@EntrySide", SqlDbType.VarChar, theAccountTransaction.EntrySide));
                InsertCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theAccountTransaction.Remarks));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, 23));//TO DO REMOVEHARDCODE: Micro.Commons.Connection.LoggedOnUser.OfficeID 
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));//Micro.Commons.Connection.LoggedOnUser.CompanyID
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//Micro.Commons.Connection.LoggedOnUser.UserID
                InsertCommand.CommandText = "pICAS_FIN_Transactions_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int DeleteAccountTransaction(AccountTransaction theAccountTransaction,int Record)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@TransactionID", SqlDbType.Int, Record));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));//TO DO// Micro.Commons.Connection.LoggedOnUser.UserID
                DeleteCommand.CommandText = "pICAS_FIN_Transactions_Delete";

                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}
