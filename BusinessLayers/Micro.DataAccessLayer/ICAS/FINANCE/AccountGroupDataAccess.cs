using System.Data;
using System.Data.SqlClient;
using Micro.Objects.ICAS.FINANCE;


namespace Micro.DataAccessLayer.ICAS.FINANCE
{
    public partial class AccountGroupDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static AccountGroupDataAccess instance = new AccountGroupDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static AccountGroupDataAccess GetInstance
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
        public DataTable GetAccountGroupList()
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.CommandText = "pAccountGroups_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }
        public DataTable GetMasterAccountGroupList()
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.CommandText = "pMasterAccountGroups_SelectAll";

            return ExecuteGetDataTable(SelectCommand);
        }
        public DataRow GetAccountGroupByID(int recordId)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, recordId));
            SelectCommand.CommandText = "pFIN_AccountGroups_SelectByAccountGroupID";

            return ExecuteGetDataRow(SelectCommand);
        }

        public int InsertAccountGroup(AccountGroup theAccountGroup)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;
            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@AccountGroupDescription", SqlDbType.VarChar, theAccountGroup.AccountGroupDescription));
            InsertCommand.Parameters.Add(GetParameter("@AccountGroupAlias", SqlDbType.VarChar, theAccountGroup.AccountGroupAlias));
            InsertCommand.Parameters.Add(GetParameter("@AccountGroupParentID", SqlDbType.Int, theAccountGroup.AccountGroupParentID));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            InsertCommand.CommandText = "pFIN_AccountGroups_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int UpdateAccountGroup(AccountGroup theAccountGroup)
        {
            int ReturnValue = 0;

            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, theAccountGroup.AccountGroupID));
            UpdateCommand.Parameters.Add(GetParameter("@AccountGroupDescription", SqlDbType.VarChar, theAccountGroup.AccountGroupDescription));
            UpdateCommand.Parameters.Add(GetParameter("@AccountGroupAlias", SqlDbType.VarChar, theAccountGroup.AccountGroupAlias));
            UpdateCommand.Parameters.Add(GetParameter("@AccountGroupParentID", SqlDbType.Int, theAccountGroup.AccountGroupParentID));
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
            UpdateCommand.CommandText = "pFIN_AccountGroups_Update";

            ExecuteStoredProcedure(UpdateCommand);
            ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int DeleteAccountGroup(AccountGroup theAccountGroup)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, theAccountGroup.AccountGroupID));
            DeleteCommand.CommandText = "pFIN_AccountGroups_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public DataRow GetAccountGroupById(int accountGroupID)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@AccountGroupID", SqlDbType.Int, accountGroupID));
            SelectCommand.CommandText = "pFIN_AccountGroups_SelectByAccountGroupID";

            return ExecuteGetDataRow(SelectCommand);
        }
        #endregion
    }
}
