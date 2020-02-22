using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class DCCollectorDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DCCollectorDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DCCollectorDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DCCollectorDataAccess();
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

        public DataTable GetDCCollectorList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
				SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_DCCollectors_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetDCCollectorsById(int DCCollectorID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@DCCollectorID", SqlDbType.Int, DCCollectorID));
                SelectCommand.CommandText = "pCRM_DCCollectors_ByDCCollectorID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertDCCollector(DCCollector theDCCollector)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theDCCollector.Salutation));
                InsertCommand.Parameters.Add(GetParameter("@DCCollectorName", SqlDbType.VarChar, theDCCollector.DCCollectorName));
                InsertCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theDCCollector.FatherName));
                InsertCommand.Parameters.Add(GetParameter("@SpouseName", SqlDbType.VarChar, theDCCollector.SpouseName));
                InsertCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theDCCollector.Gender));
                InsertCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theDCCollector.MaritalStatus));
                InsertCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theDCCollector.DateOfBirth));
                InsertCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theDCCollector.Age));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theDCCollector.Address_Present_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theDCCollector.Address_Present_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theDCCollector.Address_Present_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theDCCollector.Address_Present_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theDCCollector.Address_Permanent_TownOrCity));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theDCCollector.Address_Permanent_Landmark));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theDCCollector.Address_Permanent_PinCode));
                InsertCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theDCCollector.Address_Permanent_DistrictID));
                InsertCommand.Parameters.Add(GetParameter("@Phone", SqlDbType.VarChar, theDCCollector.Phone));
                InsertCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theDCCollector.Mobile));
                InsertCommand.Parameters.Add(GetParameter("@Email", SqlDbType.VarChar, theDCCollector.Email));
                InsertCommand.Parameters.Add(GetParameter("@Qualification", SqlDbType.VarChar, theDCCollector.Qualification));
                InsertCommand.Parameters.Add(GetParameter("@Occupation", SqlDbType.VarChar, theDCCollector.Occupation));
                InsertCommand.Parameters.Add(GetParameter("@Nationality", SqlDbType.VarChar, theDCCollector.Nationality));
                InsertCommand.Parameters.Add(GetParameter("@Religion", SqlDbType.VarChar, theDCCollector.Religion));
                InsertCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theDCCollector.Caste));
                InsertCommand.Parameters.Add(GetParameter("@Photo", SqlDbType.VarBinary, theDCCollector.Photo));
                InsertCommand.Parameters.Add(GetParameter("@Signature", SqlDbType.VarBinary, theDCCollector.Signature));
                InsertCommand.Parameters.Add(GetParameter("@DateOfJoining", SqlDbType.VarChar, theDCCollector.DateOfJoining));
                InsertCommand.Parameters.Add(GetParameter("@MaximumCollectionAmountAllowed", SqlDbType.Decimal, theDCCollector.MaximumCollectionAmountAllowed));
                InsertCommand.Parameters.Add(GetParameter("@MaximumMinutesAllowed", SqlDbType.Int, theDCCollector.MaximumMinutesAllowed));
                InsertCommand.Parameters.Add(GetParameter("@MaximumTransactionsAllowed", SqlDbType.Int, theDCCollector.MaximumTransactionsAllowed));
                InsertCommand.Parameters.Add(GetParameter("@CanDownloadMaster", SqlDbType.Bit, theDCCollector.CanDownloadMaster));
                InsertCommand.Parameters.Add(GetParameter("@CanDoTransactions", SqlDbType.Bit, theDCCollector.CanDoTransactions));
                InsertCommand.Parameters.Add(GetParameter("@CanPrintDuplicateReceipts", SqlDbType.Bit, theDCCollector.CanPrintDuplicateReceipts));
                InsertCommand.Parameters.Add(GetParameter("@CanCancelTransaction", SqlDbType.Bit, theDCCollector.CanCancelTransaction));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_DCCollectors_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateDCCollector(DCCollector theDCCollector)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@DCCollectorID", SqlDbType.Int, theDCCollector.DCCollectorID));
                UpdateCommand.Parameters.Add(GetParameter("@Salutation", SqlDbType.VarChar, theDCCollector.Salutation));
                UpdateCommand.Parameters.Add(GetParameter("@DCCollectorName", SqlDbType.VarChar, theDCCollector.DCCollectorName));
                UpdateCommand.Parameters.Add(GetParameter("@FatherName", SqlDbType.VarChar, theDCCollector.FatherName));
                UpdateCommand.Parameters.Add(GetParameter("@SpouseName", SqlDbType.VarChar, theDCCollector.SpouseName));
                UpdateCommand.Parameters.Add(GetParameter("@Gender", SqlDbType.VarChar, theDCCollector.Gender));
                UpdateCommand.Parameters.Add(GetParameter("@MaritalStatus", SqlDbType.VarChar, theDCCollector.MaritalStatus));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfBirth", SqlDbType.VarChar, theDCCollector.DateOfBirth));
                UpdateCommand.Parameters.Add(GetParameter("@Age", SqlDbType.Int, theDCCollector.Age));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_TownOrCity", SqlDbType.VarChar, theDCCollector.Address_Present_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_Landmark", SqlDbType.VarChar, theDCCollector.Address_Present_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_PinCode", SqlDbType.VarChar, theDCCollector.Address_Present_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Present_DistrictID", SqlDbType.Int, theDCCollector.Address_Present_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_TownOrCity", SqlDbType.VarChar, theDCCollector.Address_Permanent_TownOrCity));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_Landmark", SqlDbType.VarChar, theDCCollector.Address_Permanent_Landmark));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_PinCode", SqlDbType.VarChar, theDCCollector.Address_Permanent_PinCode));
                UpdateCommand.Parameters.Add(GetParameter("@Address_Permanent_DistrictID", SqlDbType.Int, theDCCollector.Address_Permanent_DistrictID));
                UpdateCommand.Parameters.Add(GetParameter("@Phone", SqlDbType.VarChar, theDCCollector.Phone));
                UpdateCommand.Parameters.Add(GetParameter("@Mobile", SqlDbType.VarChar, theDCCollector.Mobile));
                UpdateCommand.Parameters.Add(GetParameter("@Email", SqlDbType.VarChar, theDCCollector.Email));
                UpdateCommand.Parameters.Add(GetParameter("@Qualification", SqlDbType.VarChar, theDCCollector.Qualification));
                UpdateCommand.Parameters.Add(GetParameter("@Occupation", SqlDbType.VarChar, theDCCollector.Occupation));
                UpdateCommand.Parameters.Add(GetParameter("@Nationality", SqlDbType.VarChar, theDCCollector.Nationality));
                UpdateCommand.Parameters.Add(GetParameter("@Religion", SqlDbType.VarChar, theDCCollector.Religion));
                UpdateCommand.Parameters.Add(GetParameter("@Caste", SqlDbType.VarChar, theDCCollector.Caste));
                UpdateCommand.Parameters.Add(GetParameter("@Photo", SqlDbType.VarBinary, theDCCollector.Photo));
                UpdateCommand.Parameters.Add(GetParameter("@Signature", SqlDbType.VarBinary, theDCCollector.Signature));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfJoining", SqlDbType.VarChar, theDCCollector.DateOfJoining));
                UpdateCommand.Parameters.Add(GetParameter("@DCCollectorPassword", SqlDbType.VarChar, theDCCollector.DCCollectorPassword));
                UpdateCommand.Parameters.Add(GetParameter("@MaximumCollectionAmountAllowed", SqlDbType.Decimal, theDCCollector.MaximumCollectionAmountAllowed));
                UpdateCommand.Parameters.Add(GetParameter("@MaximumMinutesAllowed", SqlDbType.Int, theDCCollector.MaximumMinutesAllowed));
                UpdateCommand.Parameters.Add(GetParameter("@MaximumTransactionsAllowed", SqlDbType.Int, theDCCollector.MaximumTransactionsAllowed));
                UpdateCommand.Parameters.Add(GetParameter("@CanDownloadMaster", SqlDbType.Bit, theDCCollector.CanDownloadMaster));
                UpdateCommand.Parameters.Add(GetParameter("@CanDoTransactions", SqlDbType.Bit, theDCCollector.CanDoTransactions));
                UpdateCommand.Parameters.Add(GetParameter("@CanPrintDuplicateReceipts", SqlDbType.Bit, theDCCollector.CanPrintDuplicateReceipts));
                UpdateCommand.Parameters.Add(GetParameter("@CanCancelTransaction", SqlDbType.Bit, theDCCollector.CanCancelTransaction));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_DCCollectors_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteDCCollector(DCCollector theDCCollector)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@DCCollectorID", SqlDbType.Int, theDCCollector.DCCollectorID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_DCCollectors_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        #endregion

    }
}
