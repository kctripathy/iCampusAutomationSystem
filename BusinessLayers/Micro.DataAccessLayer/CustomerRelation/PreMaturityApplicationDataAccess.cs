using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class PreMaturityApplicationDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PreMaturityApplicationDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PreMaturityApplicationDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PreMaturityApplicationDataAccess();
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
        public DataTable GetPrematurityApplicationList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pCRM_PreMaturityApplications_SelectAll";
               
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetPreMaturityApplicationByID(int preMaturityApplicationID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@PreMaturityApplicationID", SqlDbType.Int, preMaturityApplicationID));
                SelectCommand.CommandText = "pCRM_PreMaturityApplications_SelectByPreMaturityApplicationID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataTable GetPreMaturityApplicationListByCustomerAccountID(int customerAccountID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, customerAccountID));
                SelectCommand.CommandText = "pCRM_PreMaturityApplications_SelectByCustomerAccountID";
                
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetPreMaturityApplicationListByApprovalStatus(string approvalStatus, bool allOffices = true)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.Parameters.Add(GetParameter("@ApprovalStatus", SqlDbType.VarChar, approvalStatus));
                SelectCommand.CommandText = "pCRM_PreMaturityApplications_SelectByApprovalStatus";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public int InsertPrematurityApplication(PreMaturityApplication thePreMaturityApplications)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityApplicationDate", SqlDbType.VarChar, thePreMaturityApplications.PreMaturityApplicationDate));
                InsertCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, thePreMaturityApplications.CustomerAccountID));
                InsertCommand.Parameters.Add(GetParameter("@DeathCertificate", SqlDbType.VarBinary, thePreMaturityApplications.DeathCertificate));
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityRemark", SqlDbType.VarChar, thePreMaturityApplications.PreMaturityRemark));
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityApplicationLetterDate", SqlDbType.VarChar, thePreMaturityApplications.PreMaturityApplicationLetterDate));
                InsertCommand.Parameters.Add(GetParameter("@PreMaturityApplicationLetterReference", SqlDbType.VarChar, thePreMaturityApplications.PreMaturityApplicationLetterReference));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pCRM_PreMaturityApplications_Insert";
                
                ExecuteStoredProcedure(InsertCommand);
                
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                
                return ReturnValue;
            }
        }

        public int UpdatePrematurityApplication(PreMaturityApplication thePreMaturityApplications)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@PreMaturityApplicationID", SqlDbType.Int, thePreMaturityApplications.PreMaturityApplicationID));
                UpdateCommand.Parameters.Add(GetParameter("@PreMaturityApplicationDate", SqlDbType.VarChar, thePreMaturityApplications.PreMaturityApplicationDate));
                UpdateCommand.Parameters.Add(GetParameter("@CustomerAccountID", SqlDbType.Int, thePreMaturityApplications.CustomerAccountID));
                UpdateCommand.Parameters.Add(GetParameter("@DeathCertificate", SqlDbType.VarBinary, thePreMaturityApplications.DeathCertificate));
                UpdateCommand.Parameters.Add(GetParameter("@PreMaturityRemark", SqlDbType.VarChar, thePreMaturityApplications.PreMaturityRemark));
                UpdateCommand.Parameters.Add(GetParameter("@PreMaturityApplicationLetterDate", SqlDbType.VarChar, thePreMaturityApplications.PreMaturityApplicationLetterDate));
                UpdateCommand.Parameters.Add(GetParameter("@PreMaturityApplicationLetterReference", SqlDbType.VarChar, thePreMaturityApplications.PreMaturityApplicationLetterReference));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pCRM_PreMaturityApplications_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
