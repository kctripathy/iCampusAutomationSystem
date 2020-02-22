using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects;
namespace Micro.DataAccessLayer.FinancialAccounts
{
    public partial class AccountLedgerDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static AccountLedgerDataAccess instance = new AccountLedgerDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static AccountLedgerDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Methods & Implementations
        public DataTable GetAccountLedgerList(String SearchText)
        {
            SqlCommand SelectCommand = new SqlCommand();
            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
            SelectCommand.CommandText = "pFIN_AccountLedgers_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataTable GetNonCaseAccountLedgerList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pFIN_AccountLedgers_SelectAllNonCashLedgers";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetBankLedgerList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pFIN_AccountLedgers_SelectAllBankLedgers";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetAccountLedgerByID(int accountLedgerID)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@AccountLedgerID", SqlDbType.Int, accountLedgerID));
            SelectCommand.CommandText = "pFIN_AccountLedgers_SelectByAccountLedgerID";

            return ExecuteGetDataRow(SelectCommand);
        }

        public int InsertAccountLedger(AccountLedger theAccountLedger)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;
            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@AccountLedgerDescription", SqlDbType.VarChar, theAccountLedger.AccountLedgerDescription));
            InsertCommand.Parameters.Add(GetParameter("@AccountLedgerAlias", SqlDbType.VarChar, theAccountLedger.AccountLedgerAlias));
            InsertCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, theAccountLedger.AccountGroupID));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            InsertCommand.CommandText = "pFIN_AccountLedgers_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int UpdateAccountLedger(AccountLedger theAccountLedger)
        {
            int ReturnValue = 0;

            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@AccountLedgerID", SqlDbType.Int, theAccountLedger.AccountLedgerID));
            UpdateCommand.Parameters.Add(GetParameter("@AccountLedgerDescription", SqlDbType.VarChar, theAccountLedger.AccountLedgerDescription));
            UpdateCommand.Parameters.Add(GetParameter("@AccountLedgerAlias", SqlDbType.VarChar, theAccountLedger.AccountLedgerAlias));
            UpdateCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, theAccountLedger.AccountGroupID));
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            UpdateCommand.CommandText = "pFIN_AccountLedgers_Update";

            ExecuteStoredProcedure(UpdateCommand);
            ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int DeleteAccountLedger(AccountLedger theAccountLedger)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@AccountLedgerID", SqlDbType.Int, theAccountLedger.AccountLedgerID));
            DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            DeleteCommand.CommandText = "pFIN_AccountLedgers_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }
        #endregion
    }
}
