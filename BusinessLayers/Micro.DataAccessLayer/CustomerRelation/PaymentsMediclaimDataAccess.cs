using Micro.Objects.CustomerRelation;
using System.Data.SqlClient;
using System.Data;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class PaymentsMediclaimDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsMediclaimDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsMediclaimDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsMediclaimDataAccess();
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
        public DataTable GetMediClaimPaymentList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_MediclaimPayments_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetMediclaimPaymentByMediClaimApplicationID(int mediclaimApplicationID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@MediclaimApplicationID", SqlDbType.Int, mediclaimApplicationID));
                SelectCommand.CommandText = "pCRM_MediclaimPayments_SelectByMediclaimApplicationID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertMediclaimPayment(MediclaimPayment theMediclaimPayment)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@MediclaimApplicationID", SqlDbType.Int, theMediclaimPayment.MediclaimApplicationID));
                InsertCommand.Parameters.Add(GetParameter("@PaymentDate", SqlDbType.VarChar, theMediclaimPayment.PaymentDate));
                InsertCommand.Parameters.Add(GetParameter("@AmountPaid", SqlDbType.Decimal, theMediclaimPayment.AmountPaid));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_MediclaimPayments_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}
