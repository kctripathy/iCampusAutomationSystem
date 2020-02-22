using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.DataAccessLayer.ICAS.FINANCE
{
    public partial class AccountMasterDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountMasterDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountMasterDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountMasterDataAccess();
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
        public DataTable GetAccountMasterList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pAccounts_Master_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetAccountMasterByAccountID(int accountID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, accountID));
                SelectCommand.CommandText = "pAccounts_Master_SelectByAccountID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetAccountMasterByAccountDescription(string accountDescription)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AccountDescription", SqlDbType.VarChar, accountDescription));
                SelectCommand.CommandText = "pAccounts_Master_SelectByAccountDescription";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetAccountMasterByAccountCode(string accountCode)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AccountCode", SqlDbType.VarChar, accountCode));
                SelectCommand.CommandText = "pAccounts_Master_SelectByAccountCode";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertAccountMaster(AccountMaster theAccountMaster)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, theAccountMaster.AccountGroupID));
                InsertCommand.Parameters.Add(GetParameter("@AccountName", SqlDbType.VarChar, theAccountMaster.AccountDescription));
                //InsertCommand.Parameters.Add(GetParameter("@AccountCode", SqlDbType.VarChar, theAccountMaster.AccountCode));
                InsertCommand.Parameters.Add(GetParameter("@TheCompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                InsertCommand.Parameters.Add(GetParameter("@TheOfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.CommandText = "[pAccounts_Master_Insert_New]";

                //InsertCommand.CommandType = CommandType.StoredProcedure;
                //InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                //InsertCommand.Parameters.Add(GetParameter("@AccountDescription", SqlDbType.VarChar, theAccountMaster.AccountDescription));
                //InsertCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, theAccountMaster.AccountGroupID));
                //InsertCommand.Parameters.Add(GetParameter("@AccountCode", SqlDbType.VarChar, theAccountMaster.AccountCode));
                //InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                //InsertCommand.CommandText = "pAccounts_Master_Insert";
                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int UpdateAccountMaster(AccountMaster theAccountMaster)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, theAccountMaster.AccountID));
                UpdateCommand.Parameters.Add(GetParameter("@AccountDescription", SqlDbType.VarChar, theAccountMaster.AccountDescription));
                UpdateCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, theAccountMaster.AccountGroupID));
                //UpdateCommand.Parameters.Add(GetParameter("@ParentAccountID", SqlDbType.Int, theAccountMaster.ParentAccountID));
                //UpdateCommand.Parameters.Add(GetParameter("@AccessType", SqlDbType.VarChar, theAccountMaster.AccessType));
                //UpdateCommand.Parameters.Add(GetParameter("@AnalysisFlag", SqlDbType.VarChar, theAccountMaster.AnalysisFlag));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pAccounts_Master_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int DeleteAccountMaster(AccountMaster theAccountMaster)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, theAccountMaster.AccountID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "";

                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}

