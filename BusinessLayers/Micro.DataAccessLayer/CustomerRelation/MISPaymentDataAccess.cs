using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class MISPaymentDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static MISPaymentDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static MISPaymentDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MISPaymentDataAccess();
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
        public DataTable GetMISPaymentList(string searchText="")
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SelectCommand.CommandText = "pCRM_MISPayments_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

		public DataTable GetMISPaymentsByCustomerAccountID(int recordId)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, recordId));
                SelectCommand.CommandText = "pCRM_MISPayments_SelectByCustomerAccountID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertMISPayment(MISPayment thePaymentsMISInterest)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, thePaymentsMISInterest.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@MISFirstDueDate", SqlDbType.VarChar, thePaymentsMISInterest.MISFirstDueDate));
                InsertCommand.Parameters.Add(GetParameter("@MISLastDueDate", SqlDbType.VarChar, thePaymentsMISInterest.MISLastDueDate));
                InsertCommand.Parameters.Add(GetParameter("@MISNumberFrom", SqlDbType.Int, thePaymentsMISInterest.MISNumberFrom));
                InsertCommand.Parameters.Add(GetParameter("@MISNumberTo", SqlDbType.Int, thePaymentsMISInterest.MISNumberTo));
                InsertCommand.Parameters.Add(GetParameter("@MISPayable", SqlDbType.Decimal, thePaymentsMISInterest.MISPayable));
                InsertCommand.Parameters.Add(GetParameter("@MISPaymentDate", SqlDbType.VarChar, thePaymentsMISInterest.MISPaymentDate));
                InsertCommand.Parameters.Add(GetParameter("@MISPaid", SqlDbType.Decimal, thePaymentsMISInterest.MISPaid));
                InsertCommand.Parameters.Add(GetParameter("@MISPaymentMode", SqlDbType.VarChar, thePaymentsMISInterest.MISPaymentMode));
                InsertCommand.Parameters.Add(GetParameter("@MISPaymentReference", SqlDbType.VarChar, thePaymentsMISInterest.MISPaymentReference));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_MISPayments_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
