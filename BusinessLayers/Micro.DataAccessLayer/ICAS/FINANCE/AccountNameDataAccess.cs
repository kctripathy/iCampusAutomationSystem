using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.DataAccessLayer.ICAS.FINANCE
{
    public partial class AccountNameDataAccess : AbstractData_SQLClient
    {
        #region Declaration
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static AccountNameDataAccess instance = new AccountNameDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static AccountNameDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetAccountList(bool showPrimary = true, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShowPrimary", SqlDbType.Bit, showPrimary));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pICAS_FIN_Accounts_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetAccountByID(int accountID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, accountID));
                SelectCommand.CommandText = "pICAS_FIN_Accounts_SelectByID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertAccount(AccountName theAccount)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@AccountDescription", SqlDbType.VarChar, theAccount.AccountDescription));
                InsertCommand.Parameters.Add(GetParameter("@AccountHeadID", SqlDbType.Int, theAccount.AccountHeadID));
                if (theAccount.ParentAccountID != null)
                    InsertCommand.Parameters.Add(GetParameter("@ParentAccountID", SqlDbType.Int, theAccount.ParentAccountID));
                InsertCommand.Parameters.Add(GetParameter("@AccessType", SqlDbType.VarChar, theAccount.AccessType));
                InsertCommand.Parameters.Add(GetParameter("@AnalysisFlag", SqlDbType.VarChar, theAccount.AnalysisFlag));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pICAS_FIN_Accounts_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateAccount(AccountName theAccount)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, theAccount.AccountID));
                UpdateCommand.Parameters.Add(GetParameter("@AccountDescription", SqlDbType.VarChar, theAccount.AccountDescription));
                UpdateCommand.Parameters.Add(GetParameter("@AccountHeadID", SqlDbType.Int, theAccount.AccountHeadID));
                if (theAccount.ParentAccountID > 0)
                    UpdateCommand.Parameters.Add(GetParameter("@ParentAccountID", SqlDbType.Int, theAccount.ParentAccountID));
                UpdateCommand.Parameters.Add(GetParameter("@AccessType", SqlDbType.VarChar, theAccount.AccessType));
                UpdateCommand.Parameters.Add(GetParameter("@AnalysisFlag", SqlDbType.VarChar, theAccount.AnalysisFlag));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pICAS_FIN_Accounts_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteAccount(AccountName theAccount)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, theAccount.AccountID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pICAS_FIN_Accounts_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateDisplayOrder(List<AccountName> accountList)
        {
            int ReturnValue = 0;

            int ListCount = accountList.Count;
            int ListCounter = 0;

            SqlCommand[] UpdateCommand = new SqlCommand[ListCount];

            foreach (AccountName TheAccount in accountList)
            {
                UpdateCommand[ListCounter] = new SqlCommand();

                UpdateCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@AccountID", SqlDbType.Int, TheAccount.AccountID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@DisplayOrder", SqlDbType.Int, TheAccount.DisplayOrder));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand[ListCounter].CommandText = "pICAS_FIN_Accounts_UpdateDisplayOrder";

                ListCounter++;
            }

            ReturnValue = ExecuteStoredProcedure(UpdateCommand);

            if ((ReturnValue + ListCount).Equals(0))
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Success + 1;
            }
            else
            {
                ReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            }

            return ReturnValue;
        }
        #endregion
    }
}
