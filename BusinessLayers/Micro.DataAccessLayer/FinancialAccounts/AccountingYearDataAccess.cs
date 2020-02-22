using System.Data;
using System.Data.SqlClient;
using Micro.Objects.FinancialAccounts;

namespace Micro.DataAccessLayer.FinancialAccounts
{
   public partial class AccountingYearDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static AccountingYearDataAccess instance = new AccountingYearDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static AccountingYearDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Methods & Implentation
        public DataTable GetAccountingYearList(string searchText)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            //SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
            SelectCommand.CommandText = "[pAccount_Years_SelectAll]";//"pFIN_AccountingYears_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }

        public int InsertAccountingYear(AccountingYear TheAccountingYear)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;
            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@AccountingYearDescription", SqlDbType.VarChar, TheAccountingYear.AccountingYearDescription));
            InsertCommand.Parameters.Add(GetParameter("@YearStartDate",SqlDbType.DateTime, TheAccountingYear.YearStartDate));
            InsertCommand.Parameters.Add(GetParameter("@YearEndDate",SqlDbType.DateTime, TheAccountingYear.YearEndDate));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            InsertCommand.CommandText = "pAccount_Years_SelectAll"; // "pFIN_AccountingYears_SelectAll

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int UpdateAccountingYear(AccountingYear TheAccountingYear)
        {
            int ReturnValue = 0;

            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;

            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@AccountingYearID", SqlDbType.Int, TheAccountingYear.AccountingYearID));
            UpdateCommand.Parameters.Add(GetParameter("@AccountingYearDescription", SqlDbType.VarChar, TheAccountingYear.AccountingYearDescription));
            UpdateCommand.Parameters.Add(GetParameter("@YearStartDate", SqlDbType.DateTime, TheAccountingYear.YearStartDate));
            UpdateCommand.Parameters.Add(GetParameter("@YearEndDate", SqlDbType.DateTime, TheAccountingYear.YearEndDate));
            UpdateCommand.CommandText = "pAccount_Years_Insert"; // "pFIN_AccountingYears_Update";

            ExecuteStoredProcedure(UpdateCommand);
            ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int DeleteAccountingYear(AccountingYear TheAccountingYear)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@AccountingYearID", SqlDbType.Int, TheAccountingYear.AccountingYearID));
            DeleteCommand.CommandText = "pFIN_AccountingYears_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public DataRow GetAccountingYearById(int recordId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@AccountingYearID", SqlDbType.Int, recordId));
            SelectCommand.CommandText = "pFIN_AccountingYears_SelectByAccountingYearID";

            return ExecuteGetDataRow(SelectCommand);
        }
        #endregion
    }
}