using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using Micro.Objects.FinancialAccounts;

namespace Micro.DataAccessLayer.FinancialAccounts
{
    public partial class AccountHeadDataAccess : AbstractData_SQLClient
    {
        #region Declaration
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static AccountHeadDataAccess instance = new AccountHeadDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static AccountHeadDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetAccountHeadList(bool showPrimary = true, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShowPrimary", SqlDbType.Bit, showPrimary));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pFIN_AccountHeads_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetAccountHeadByID(int accountHeadID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AccountHeadID", SqlDbType.Int, accountHeadID));
                SelectCommand.CommandText = "pFIN_AccountHeads_SelectByID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertAccountHead(AccountHead theAccountHead)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@AccountHeadDescription", SqlDbType.VarChar, theAccountHead.AccountHeadDescription));
                InsertCommand.Parameters.Add(GetParameter("@AccountHeadType", SqlDbType.VarChar, theAccountHead.AccountHeadType));
                if (theAccountHead.ParentAccountHeadID != null)
                    InsertCommand.Parameters.Add(GetParameter("@ParentAccountHeadID", SqlDbType.Int, theAccountHead.ParentAccountHeadID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, 1));//TO DO : Micro.Commons.Connection.LoggedOnUser.UserID
                InsertCommand.Parameters.Add(GetParameter("@IsPrimary", SqlDbType.Int, theAccountHead.IsPrimary));
                InsertCommand.CommandText = "pFIN_AccountHeads_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateAccountHead(AccountHead theAccountHead)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@AccountHeadID", SqlDbType.Int, theAccountHead.AccountHeadID));
                UpdateCommand.Parameters.Add(GetParameter("@AccountHeadDescription", SqlDbType.VarChar, theAccountHead.AccountHeadDescription));
                UpdateCommand.Parameters.Add(GetParameter("@AccountHeadType", SqlDbType.VarChar, theAccountHead.AccountHeadType));
                if (theAccountHead.ParentAccountHeadID != null)
                    UpdateCommand.Parameters.Add(GetParameter("@ParentAccountHeadID", SqlDbType.Int, theAccountHead.ParentAccountHeadID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pFIN_AccountHeads_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteAccountHead(AccountHead theAccountHead)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@AccountHeadID", SqlDbType.Int, theAccountHead.AccountHeadID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, 1));//TO DO  Remove HC:KP :Micro.Commons.Connection.LoggedOnUser.UserID
                DeleteCommand.CommandText = "pFIN_AccountHeads_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateDisplayOrder(List<AccountHead> accountHeadList)
        {
            int ReturnValue = 0;

            int ListCount = accountHeadList.Count;
            int ListCounter = 0;

            SqlCommand[] UpdateCommand = new SqlCommand[ListCount];

            foreach (AccountHead TheAccountHead in accountHeadList)
            {
                UpdateCommand[ListCounter] = new SqlCommand();

                UpdateCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@AccountHeadID", SqlDbType.Int, TheAccountHead.AccountHeadID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@DisplayOrder", SqlDbType.Int, TheAccountHead.DisplayOrder));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand[ListCounter].CommandText = "pFIN_AccountHeads_UpdateDisplayOrder";

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
