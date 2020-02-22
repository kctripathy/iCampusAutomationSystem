using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.DataAccessLayer.ICAS.FINANCE
{    
    public partial class AccountsTransactionsDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountsTransactionsDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountsTransactionsDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountsTransactionsDataAccess();
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
        public DataTable GetAccountsDailyTransactionList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pAccounts_Transactions_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertAccountsDailyTransactions(Accounts_DailyTransactions theAccountsDailyTransactions)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@VoucherNumber", SqlDbType.VarChar, theAccountsDailyTransactions.VoucherNumber));
                InsertCommand.Parameters.Add(GetParameter("@TranDate", SqlDbType.VarChar, theAccountsDailyTransactions.TranDate));
                InsertCommand.Parameters.Add(GetParameter("@TranNumber", SqlDbType.Int, theAccountsDailyTransactions.TranNumber));
                InsertCommand.Parameters.Add(GetParameter("@SerialNumber", SqlDbType.Int, theAccountsDailyTransactions.SerialNumber));
                InsertCommand.Parameters.Add(GetParameter("@AccountsID", SqlDbType.Int, theAccountsDailyTransactions.AccountsID));
                InsertCommand.Parameters.Add(GetParameter("@AccountsCode", SqlDbType.VarChar, theAccountsDailyTransactions.AccountCode));
                InsertCommand.Parameters.Add(GetParameter("@TranType", SqlDbType.VarChar, theAccountsDailyTransactions.TranType));
                InsertCommand.Parameters.Add(GetParameter("@TranAmount", SqlDbType.Decimal, theAccountsDailyTransactions.TranAmount));
                InsertCommand.Parameters.Add(GetParameter("@BalanceType", SqlDbType.VarChar, theAccountsDailyTransactions.BalanceType));
                InsertCommand.Parameters.Add(GetParameter("@Narration", SqlDbType.VarChar, theAccountsDailyTransactions.Narration));
                InsertCommand.Parameters.Add(GetParameter("@IsPosted", SqlDbType.VarChar, theAccountsDailyTransactions.IsPosted));
                InsertCommand.Parameters.Add(GetParameter("@PostedBy", SqlDbType.Int, theAccountsDailyTransactions.PostedBy));
                InsertCommand.Parameters.Add(GetParameter("@PostedDate", SqlDbType.VarChar, theAccountsDailyTransactions.PostedDate));
                InsertCommand.Parameters.Add(GetParameter("@PostMode", SqlDbType.VarChar, theAccountsDailyTransactions.PostMode));
                InsertCommand.Parameters.Add(GetParameter("@AccountsYearID", SqlDbType.Int, theAccountsDailyTransactions.AccountsYearID));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, theAccountsDailyTransactions.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@SocietyID", SqlDbType.Int, theAccountsDailyTransactions.SocietyID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pAccounts_Transactions_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public DataTable GetValidTransactionsList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "GetValidTransactionsAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetCurrentMonthTransactionsList(int officeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
                SelectCommand.CommandText = "GetCurrentMonthTransactionsAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int UpdateTransactionsPostingBatch(List<Voucher2PostUpdate> voucher2PostUpdateList)
        {
            int ReturnValue = 0;
            int ListCount = voucher2PostUpdateList.Count;
            int ListCounter = 0;

            SqlCommand[] UpdateCommandList = new SqlCommand[ListCount];

            foreach (Voucher2PostUpdate vpu in voucher2PostUpdateList)
            {
                UpdateCommandList[ListCounter] = new SqlCommand();

                UpdateCommandList[ListCounter].CommandType = CommandType.StoredProcedure;
                UpdateCommandList[ListCounter].Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommandList[ListCounter].Parameters.Add(GetParameter("@TransactionNumber", SqlDbType.Int, vpu.TranNumber));
                UpdateCommandList[ListCounter].Parameters.Add(GetParameter("@CheckState", SqlDbType.Bit, vpu.CheckState));
                UpdateCommandList[ListCounter].Parameters.Add(GetParameter("@PostedBy", SqlDbType.Int, vpu.PostedBy));
                UpdateCommandList[ListCounter].Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                UpdateCommandList[ListCounter].CommandText = "pTransactions_PostingBatch";

                ListCounter++;
            }

            ExecuteStoredProcedure(UpdateCommandList);
            ReturnValue = int.Parse(UpdateCommandList[ListCounter-1].Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public long GetNextTransactionNumber()
        {
            long ReturnValue = 0;
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@NEXT_VALUE", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SelectCommand.CommandText = "[GetNextValue]";
                ExecuteStoredProcedure(SelectCommand);

                ReturnValue = long.Parse(SelectCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public DataTable GetAccountsBookCloseList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.Parameters.Add(GetParameter("@AccountsYearId", SqlDbType.Int, Micro.Commons.Connection.ConnectionKeyValue));
                SelectCommand.CommandText = "pAccounts_BookClose_SelectByYear";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetAccountLedgerListByAccountID(int officeID, int accountID, int accountYearID, string ledgerType)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType=CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
            SelectCommand.Parameters.Add(GetParameter("@AccountsID", SqlDbType.Int, accountID));
            SelectCommand.Parameters.Add(GetParameter("@AccountsYearID", SqlDbType.Int, accountYearID));
            SelectCommand.Parameters.Add(GetParameter("@LedgerType", SqlDbType.VarChar, ledgerType));
            SelectCommand.CommandText = "GetAccountsLedgerByID";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataTable GetAccountLedgerListByOfficeID(int officeID, int accountYearID)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
            SelectCommand.Parameters.Add(GetParameter("@AccountsYearID", SqlDbType.Int, accountYearID));
            SelectCommand.CommandText = "GetAccountsLedgerByOfficeID";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataTable GetCashAndBankBookByAccountID(int officeID, int accountID, int accountYearID, string ledgerType)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
            SelectCommand.Parameters.Add(GetParameter("@AccountsID", SqlDbType.Int, accountID));
            SelectCommand.Parameters.Add(GetParameter("@AccountsYearID", SqlDbType.Int, accountYearID));
            SelectCommand.Parameters.Add(GetParameter("@LedgerType", SqlDbType.VarChar, ledgerType));
            SelectCommand.CommandText = "GetAccountsLedgerCashAndBankBook";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataTable GetIncomeAndExpendituresByParentAccountGroup(int officeID, int accountYearID, string parentAccountGroup, string DateFrom, string DateTo)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
            SelectCommand.Parameters.Add(GetParameter("@AccountsYearID", SqlDbType.Int, accountYearID));
            SelectCommand.Parameters.Add(GetParameter("@ParentGroupDescription", SqlDbType.VarChar, parentAccountGroup));
            SelectCommand.Parameters.Add(GetParameter("@DateFrom", SqlDbType.VarChar, DateFrom));
            SelectCommand.Parameters.Add(GetParameter("@DateTo", SqlDbType.VarChar, DateTo));
            SelectCommand.CommandText = "GetAccountsLedgerByAccountGroup";

            return ExecuteGetDataTable(SelectCommand);
        }

        //Account Book Month Closing------------------------------------------------------------------------------------------------------------------------
        public int CloseAccountingMonthBookByOffice(int officeID, int accountsYearId, string accountsYearName, string accountsMonthName, char bookCloseFlag)
        {
            int ProcReturnValue = 0;
            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ProcReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
            UpdateCommand.Parameters.Add(GetParameter("@AccountsYearId", SqlDbType.Int, accountsYearId));
            UpdateCommand.Parameters.Add(GetParameter("@AccountsYearName", SqlDbType.VarChar, accountsYearName));
            UpdateCommand.Parameters.Add(GetParameter("@AccountsMonthName", SqlDbType.VarChar, accountsMonthName));
            UpdateCommand.Parameters.Add(GetParameter("@BookCloseFlag", SqlDbType.Char, bookCloseFlag));
            UpdateCommand.Parameters.Add(GetParameter("@BookClosedByUserId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            UpdateCommand.CommandText = "pAccounts_BookCloseByMonthAndYear";

            ExecuteStoredProcedure(UpdateCommand);
            ProcReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ProcReturnValue;
        }

        //Account Book Year Closing--------------------------------------------------------------------
        public int CloseAccountingYearBookBySociety(int accountYearID, int societyID)
        {
            int ProcReturnValue = 0;
            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ProcReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@AccountYearID", SqlDbType.Int, accountYearID));
            UpdateCommand.Parameters.Add(GetParameter("@SocietyID", SqlDbType.Int, societyID));
            UpdateCommand.Parameters.Add(GetParameter("@ClosedByAuthority", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            UpdateCommand.CommandText = "pAccounts_BookCloseFinanceYear";

            ExecuteStoredProcedure(UpdateCommand);
            ProcReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ProcReturnValue;
        }

        public DataRow GetAccountingYearByFlag(string flag)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@Flag", SqlDbType.VarChar, flag));
            SelectCommand.CommandText = "pAccount_Years_SelectByFlag";

            return ExecuteGetDataRow(SelectCommand);
        }

        public DataTable GetSavingAccountTransactionList(string accountsCode)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@AccountsCode", SqlDbType.VarChar, accountsCode));
            SelectCommand.CommandText = "pAccounts_Transactions_SelectSavingAccountTransactionsByAccountsCode";

            return ExecuteGetDataTable(SelectCommand);
        }
        #endregion
    }
}
