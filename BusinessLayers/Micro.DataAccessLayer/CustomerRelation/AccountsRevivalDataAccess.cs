using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class AccountsRevivalDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountsRevivalDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountsRevivalDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountsRevivalDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Methods & Implementation
		public DataTable GetAccountsRevivalList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_Revivals_SelectAll";
                
				return ExecuteGetDataTable(SelectCommand);
            }
        }

		public int InsertAccountsRevivals(AccountsRevival theAccountsRevival)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@RevivalDate", SqlDbType.VarChar, theAccountsRevival.RevivalDate));
                InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, theAccountsRevival.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@RevivedFromInstallmentNumber", SqlDbType.Int, theAccountsRevival.RevivedFromInstallmentNumber));
                InsertCommand.Parameters.Add(GetParameter("@TotalInstallmentsRevived", SqlDbType.Int, theAccountsRevival.TotalInstallmentsRevived));
                InsertCommand.Parameters.Add(GetParameter("@DueDateOfLastPayment", SqlDbType.VarChar, theAccountsRevival.DueDateOfLastPayment));
                InsertCommand.Parameters.Add(GetParameter("@DueDateOfMaturity", SqlDbType.VarChar, theAccountsRevival.DueDateOfMaturity));
                InsertCommand.Parameters.Add(GetParameter("@PayToCompany", SqlDbType.Decimal, theAccountsRevival.PayToCompany));
                InsertCommand.Parameters.Add(GetParameter("@GuaranteedDividend", SqlDbType.Decimal, theAccountsRevival.GuaranteedDividend));
                InsertCommand.Parameters.Add(GetParameter("@BonusAmount", SqlDbType.Decimal, theAccountsRevival.BonusAmount));
                InsertCommand.Parameters.Add(GetParameter("@PayByCompany", SqlDbType.Decimal, theAccountsRevival.PayByCompany));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_Revivals_Insert";
                
				ExecuteStoredProcedure(InsertCommand);
                
				ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                
				return ReturnValue;
            }
        }
        #endregion
    }
}
