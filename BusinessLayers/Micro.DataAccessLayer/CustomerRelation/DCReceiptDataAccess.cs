using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class DCReceiptDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DCReceiptDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DCReceiptDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DCReceiptDataAccess();
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
        public DataTable GetDCReceiptList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_DCReceipts_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetDCReceiptsByAccountID(int DCAccountID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@DCAccountID", SqlDbType.Int, DCAccountID));
                SelectCommand.CommandText = "pCRM_DCReceipts_SelectByDCAccountID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetDCReceiptsByReceiptId(int DCReceiptID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@DCReceiptID", SqlDbType.Int, DCReceiptID));
                SelectCommand.CommandText = "pCRM_DCReceipts_SelectByDCReceiptID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertDcReceipt(DCReceipt theDcReceipt)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@DCAccountID", SqlDbType.Int, theDcReceipt.DCAccountID));
                InsertCommand.Parameters.Add(GetParameter("@DCReceiptDate", SqlDbType.VarChar, theDcReceipt.DCReceiptDate));
                InsertCommand.Parameters.Add(GetParameter("@DCReceiptAmount", SqlDbType.Decimal, theDcReceipt.DCReceiptAmount));
                InsertCommand.Parameters.Add(GetParameter("@DCPaymentMode", SqlDbType.VarChar, theDcReceipt.DCPaymentMode));
                InsertCommand.Parameters.Add(GetParameter("@DCPaymentReference", SqlDbType.VarChar, theDcReceipt.DCPaymentReference));
                InsertCommand.Parameters.Add(GetParameter("@DCAmountActualCollectionDateTime", SqlDbType.VarChar, theDcReceipt.DCAmountActualCollectionDateTime));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_DCReceipts_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int CancelDcReceipt(DCReceipt theDcReceipt)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@CancelledReceiptID", SqlDbType.Int, theDcReceipt.CancelledReceiptID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_DCReceipts_Cancel";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
