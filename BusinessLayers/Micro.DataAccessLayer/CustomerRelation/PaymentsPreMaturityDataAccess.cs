using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class PaymentsPreMaturityDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsPreMaturityDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsPreMaturityDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsPreMaturityDataAccess();
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

        #region Methods & Implementations
        public DataTable GetPaymentsPrematurityList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_PreMaturityPayments_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertPaymentPreMaturity(PaymentsPreMaturity thePaymentsPreMaturity)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityApprovalID", SqlDbType.Int, thePaymentsPreMaturity.PreMaturityApprovalID));
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityPaymentDate", SqlDbType.VarChar, thePaymentsPreMaturity.PreMaturityPaymentDate));
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityPrincipalPaid", SqlDbType.Decimal, thePaymentsPreMaturity.PreMaturityPrincipalPaid));
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityInterestPaid", SqlDbType.Decimal, thePaymentsPreMaturity.PreMaturityInterestPaid));
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityBonusPaid", SqlDbType.Decimal, thePaymentsPreMaturity.PreMaturityBonusPaid));
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityTotalPaid", SqlDbType.Decimal, thePaymentsPreMaturity.PreMaturityTotalPaid));
                //InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
				InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				InsertCommand.CommandText = "pCRM_PreMaturityPayments_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
