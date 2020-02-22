using Micro.Objects.CustomerRelation;
using System.Data.SqlClient;
using System.Data;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class MediclaimApprovalDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static MediclaimApprovalDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static MediclaimApprovalDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MediclaimApprovalDataAccess();
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
        public DataTable GetMediClaimApprovalList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_MediclaimApprovals_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetUnPaidMediClaimApprovalList(bool allOffices = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_MediclaimApprovals_Unpaid";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetMediclaimApprovalByID(int mediclaimApprovalID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@MediclaimApprovalID", SqlDbType.Int, mediclaimApprovalID));
                SelectCommand.CommandText = "pCRM_MediclaimApprovals_SelectByMediclaimApprovalID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertMediclaimApproval(MediclaimApproval theMediclaimApproval)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@MediclaimApplicationID", SqlDbType.Int, theMediclaimApproval.MediclaimApplicationID));
                InsertCommand.Parameters.Add(GetParameter("@MediclaimApprovalDate", SqlDbType.VarChar, theMediclaimApproval.MediclaimApprovalDate));
                InsertCommand.Parameters.Add(GetParameter("@MediclaimApprovalAmount", SqlDbType.Decimal, theMediclaimApproval.MediclaimApprovalAmount));
                InsertCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theMediclaimApproval.Remarks));
                InsertCommand.Parameters.Add(GetParameter("@ApprovedByEmployeeID", SqlDbType.Int, theMediclaimApproval.ApprovedByEmployeeID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_MediclaimApprovals_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
    }
}
