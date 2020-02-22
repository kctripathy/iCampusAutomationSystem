using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class MediclaimApplicationDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static MediclaimApplicationDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static MediclaimApplicationDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MediclaimApplicationDataAccess();
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
        public DataTable GetMediclaimApplicationsList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_MediclaimApplications_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetMediclaimApplicationsListByApprovalStatus(string approvalStatus, bool allOffices = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ApprovalStatus", SqlDbType.VarChar, approvalStatus));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_MediclaimApplications_SelectByApprovalStatus";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetMediclaimApplicationsListByCustomerID(int customerID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, customerID));
                SelectCommand.CommandText = "pCRM_MediclaimApplications_SelectByCustomerID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetMediclaimApplicationByID(int mediclaimApplicationID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@MediclaimApplicationID", SqlDbType.Int, mediclaimApplicationID));
                SelectCommand.CommandText = "pCRM_MediclaimApplications_SelectByMediclaimApplicationID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, theMediclaimApplication.CustomerID));
                InsertCommand.Parameters.Add(GetParameter("@MediclaimApplicationDate", SqlDbType.VarChar, theMediclaimApplication.MediclaimApplicationDate));
                InsertCommand.Parameters.Add(GetParameter("@ReasonForClaim", SqlDbType.VarChar, theMediclaimApplication.ReasonForClaim));
                InsertCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theMediclaimApplication.Remarks));
                InsertCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_MediclaimApplications_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int UpdateMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@MediclaimApplicationID", SqlDbType.Int, theMediclaimApplication.MediclaimApplicationID));
                UpdateCommand.Parameters.Add(GetParameter("@CustomerID", SqlDbType.Int, theMediclaimApplication.CustomerID));
                UpdateCommand.Parameters.Add(GetParameter("@MediclaimApplicationDate", SqlDbType.VarChar, theMediclaimApplication.MediclaimApplicationDate));
                UpdateCommand.Parameters.Add(GetParameter("@ReasonForClaim", SqlDbType.VarChar, theMediclaimApplication.ReasonForClaim));
                UpdateCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theMediclaimApplication.Remarks));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_MediclaimApplications_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int UpdateMediclaimApplicationApprovalStatus(MediclaimApplication theMediclaimApplication)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@MediclaimApplicationID", SqlDbType.Int, theMediclaimApplication.MediclaimApplicationID));
                UpdateCommand.Parameters.Add(GetParameter("@ApprovedByEmployeeID", SqlDbType.Int, theMediclaimApplication.ApprovedByEmployeeID));
                UpdateCommand.Parameters.Add(GetParameter("@ApprovalStatus", SqlDbType.VarChar, theMediclaimApplication.ApprovalStatus));
                UpdateCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theMediclaimApplication.Remarks));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_MediclaimApplications_UpdateApprovalStatus";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int DeleteMediclaimApplication(MediclaimApplication theMediclaimApplication)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@MediclaimApplicationID", SqlDbType.Int, theMediclaimApplication.MediclaimApplicationID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                DeleteCommand.CommandText = "pCRM_MediclaimApplications_Delete";

                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}
