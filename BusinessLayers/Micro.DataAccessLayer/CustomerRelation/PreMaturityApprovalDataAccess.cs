using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class PreMaturityApprovalDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static PreMaturityApprovalDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static PreMaturityApprovalDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PreMaturityApprovalDataAccess();
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
       public DataTable GetPrematurityApprovalUnpaidList(bool allOffices = false)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;
               SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
               SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Connection.LoggedOnUser.OfficeID));
               SelectCommand.CommandText = "pCRM_PreMaturityApprovals_Unpaid";
               return ExecuteGetDataTable(SelectCommand);
           }
       }

       public DataRow GetPrematurityApprovalDetailsById(int PreMaturityApprovalID)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;
               SelectCommand.Parameters.Add(GetParameter("@PreMaturityApprovalID", SqlDbType.Int, PreMaturityApprovalID));
               SelectCommand.CommandText = "pCRM_PreMaturityApprovals_SelectByPreMaturityApprovalID";
               return ExecuteGetDataRow(SelectCommand);
           }
       }

       public int InsertPreMaturityApproval(PreMaturityApproval thePreMaturityApprovals)
       {
           int ReturnValue = 0;

           using (SqlCommand InsertCommand = new SqlCommand())
           {
               InsertCommand.CommandType = CommandType.StoredProcedure;
               InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityApplicationID", SqlDbType.Int, thePreMaturityApprovals.PreMaturityApplicationID));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityApprovalDate", SqlDbType.VarChar, thePreMaturityApprovals.PreMaturityApprovalDate));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityPrincipalPayable", SqlDbType.Decimal, thePreMaturityApprovals.PreMaturityPrincipalPayable));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityPrincipalApproved", SqlDbType.Decimal, thePreMaturityApprovals.PreMaturityPrincipalApproved));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityInterestPayable", SqlDbType.Decimal, thePreMaturityApprovals.PreMaturityInterestPayable));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityInterestApproved", SqlDbType.Decimal, thePreMaturityApprovals.PreMaturityInterestApproved));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityBonusPayable", SqlDbType.Decimal, thePreMaturityApprovals.PreMaturityBonusPayable));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityBonusApproved", SqlDbType.Decimal, thePreMaturityApprovals.PreMaturityBonusApproved));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityTotalPayable", SqlDbType.Decimal, thePreMaturityApprovals.PreMaturityTotalPayable));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityTotalPaid", SqlDbType.Decimal, thePreMaturityApprovals.PreMaturityTotalPaid));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityApprovalRemark", SqlDbType.VarChar, thePreMaturityApprovals.PreMaturityApprovalRemark));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityApprovedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityApprovalLetterDate", SqlDbType.VarChar, thePreMaturityApprovals.PreMaturityApprovalLetterDate));
               InsertCommand.Parameters.Add(GetParameter("@PreMaturityApprovalLetterReference", SqlDbType.VarChar, thePreMaturityApprovals.PreMaturityApprovalLetterReference));
               InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               InsertCommand.CommandText = "pCRM_PreMaturityApprovals_Insert";
               ExecuteStoredProcedure(InsertCommand);
               ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
               return ReturnValue;
           }
       }

       public int RejectPreMaturityApplication(PreMaturityApplication thePreMaturityApplication)
       {
           int ReturnValue = 0;

           using (SqlCommand UpdateCommand = new SqlCommand())
           {
               UpdateCommand.CommandType = CommandType.StoredProcedure;
               UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
               UpdateCommand.Parameters.Add(GetParameter("@PreMaturityApplicationID", SqlDbType.Int, thePreMaturityApplication.PreMaturityApplicationID));
               UpdateCommand.Parameters.Add(GetParameter("@PreMaturityApprovalStatus", SqlDbType.VarChar, thePreMaturityApplication.PreMaturityApprovalStatus));
               UpdateCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, thePreMaturityApplication.Remarks));
               UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               UpdateCommand.CommandText = "pCRM_PreMaturityApplications_UpdateApprovalStatus";
               ExecuteStoredProcedure(UpdateCommand);
               ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
               return ReturnValue;
           }
       }
        #endregion

    }
}
