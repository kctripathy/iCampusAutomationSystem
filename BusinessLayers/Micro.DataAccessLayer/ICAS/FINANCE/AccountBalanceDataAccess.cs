using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.DataAccessLayer.ICAS.FINANCE
{
    public partial class AccountBalanceDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static AccountBalanceDataAccess instance = new AccountBalanceDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static AccountBalanceDataAccess GetInstance
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
        public DataTable GetAccountsBalanceListByAccountsYearID(int accountsYearID, int officeID)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@AccountsYearID", SqlDbType.Int, accountsYearID));
            SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeID));
            SelectCommand.CommandText = "pAccounts_Balance_SelectByAccountsYearID";

            return ExecuteGetDataTable(SelectCommand);
        }

        public int UpdateFinyearOpeningBalance(AccountBalance theAccountBalance)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@AccountsYearID", SqlDbType.Int, theAccountBalance.AccountsYearID));
                InsertCommand.Parameters.Add(GetParameter("@FinYearStartDate", SqlDbType.VarChar, theAccountBalance.FinYearStartDate));
                InsertCommand.Parameters.Add(GetParameter("@AccountsID", SqlDbType.Int, theAccountBalance.AccountsID));
                InsertCommand.Parameters.Add(GetParameter("@FinYearOpeningBalance", SqlDbType.Decimal, theAccountBalance.FinYearOpeningBalance));
                InsertCommand.Parameters.Add(GetParameter("@FinYearOpeningBalanceType", SqlDbType.VarChar, theAccountBalance.FinYearOpeningBalanceType));
                InsertCommand.Parameters.Add(GetParameter("@SocietyID", SqlDbType.Int, theAccountBalance.SocietyID));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, theAccountBalance.OfficeID));

                InsertCommand.CommandText = "pAccounts_Balance_FinYearOpeningBalance_Update";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        } 
        #endregion
    }
}
