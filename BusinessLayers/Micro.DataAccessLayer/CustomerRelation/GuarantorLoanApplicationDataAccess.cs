using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class GuarantorLoanApplicationDataAccess : AbstractData_SQLClient
   {
       #region Code to make this as Singleton Class
       /// <summary>
       /// Declare a private static variable
       /// </summary>
       private static GuarantorLoanApplicationDataAccess _Instance;

       /// <summary>
       /// Return the instance of the application by initialising once only.
       /// </summary>
       public static GuarantorLoanApplicationDataAccess GetInstance
       {
           get
           {
               if (_Instance == null)
               {
                   _Instance = new GuarantorLoanApplicationDataAccess();
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
       public DataTable GetGuarantorLoanApplicationList(bool allOffices = false, bool showDeleted = false)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;
               SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
               SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
			   SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
               SelectCommand.CommandText = "pCRM_GuarantorLoanApplications_SelectAll";
               return ExecuteGetDataTable(SelectCommand);
           }
       }

       public DataRow GetGuarantorLoanApplicationByID(int guarantorLoanApplicationID)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;
               SelectCommand.Parameters.Add(GetParameter("@GuarantorLoanApplicationID", SqlDbType.Int, guarantorLoanApplicationID));
               SelectCommand.CommandText = "pCRM_GuarantorLoanApplications_SelectByGuarantorLoanApplicationID";
               return ExecuteGetDataRow(SelectCommand);
           }
       }

       public DataTable GetGuarantorLoanApplicationListByApprovalStatus(string approvalStatus, bool allOffices=false)
	   {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;
               SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
               SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
               SelectCommand.Parameters.Add(GetParameter("@ApprovalStatus", SqlDbType.VarChar, approvalStatus));
               SelectCommand.CommandText = "pCRM_GuarantorLoanApplications_SelectByApprovalStatus";
               return ExecuteGetDataTable(SelectCommand);
           }
	   }

       public DataTable GetGuarantorLoanApplicationListByApplicantID(int loanApplicantID)
       {
           using (SqlCommand SelectCommand = new SqlCommand())
           {
               SelectCommand.CommandType = CommandType.StoredProcedure;
               SelectCommand.Parameters.Add(GetParameter("@LoanApplicantID", SqlDbType.Int, loanApplicantID));
               SelectCommand.CommandText = "pCRM_GuarantorLoanApplications_SelectByLoanApplicantID";
               return ExecuteGetDataTable(SelectCommand);
           }
       }

       public int InsertGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
       {
           int ReturnValue = 0;

           using (SqlCommand InsertCommand = new SqlCommand())
           {
               InsertCommand.CommandType = CommandType.StoredProcedure;
               InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
               InsertCommand.Parameters.Add(GetParameter("@LoanAppliedBy", SqlDbType.VarChar, theGuarantorLoanApplication.LoanAppliedBy));
               InsertCommand.Parameters.Add(GetParameter("@LoanApplicantID", SqlDbType.Int, theGuarantorLoanApplication.LoanApplicantID));
               InsertCommand.Parameters.Add(GetParameter("@LoanApplicationDate", SqlDbType.VarChar, theGuarantorLoanApplication.LoanApplicationDate));
               InsertCommand.Parameters.Add(GetParameter("@RequiredFor", SqlDbType.VarChar, theGuarantorLoanApplication.RequiredFor));
               InsertCommand.Parameters.Add(GetParameter("@LoanAmountApplied", SqlDbType.Decimal, theGuarantorLoanApplication.LoanAmountApplied));
			   InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
			   InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               InsertCommand.CommandText = "pCRM_GuarantorLoanApplications_Insert";
               ExecuteStoredProcedure(InsertCommand);
               ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
               return ReturnValue;
           }
       }

       public int UpdateGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
       {
           int ReturnValue = 0;

           using (SqlCommand UpdateCommand = new SqlCommand())
           {
               UpdateCommand.CommandType = CommandType.StoredProcedure;
               UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
               UpdateCommand.Parameters.Add(GetParameter("@GuarantorLoanApplicationID", SqlDbType.Int, theGuarantorLoanApplication.GuarantorLoanApplicationID));
               UpdateCommand.Parameters.Add(GetParameter("@LoanAppliedBy", SqlDbType.VarChar, theGuarantorLoanApplication.LoanAppliedBy));
               UpdateCommand.Parameters.Add(GetParameter("@LoanApplicantID", SqlDbType.Int, theGuarantorLoanApplication.LoanApplicantID));
               UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationDate", SqlDbType.VarChar, theGuarantorLoanApplication.LoanApplicationDate));
               UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationFee", SqlDbType.Decimal, theGuarantorLoanApplication.LoanApplicationFee));
               UpdateCommand.Parameters.Add(GetParameter("@RequiredFor", SqlDbType.VarChar, theGuarantorLoanApplication.RequiredFor));
               UpdateCommand.Parameters.Add(GetParameter("@LoanAmountApplied", SqlDbType.Decimal, theGuarantorLoanApplication.LoanAmountApplied));
               UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
               UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               UpdateCommand.CommandText = "pCRM_GuarantorLoanApplications_Update";
               ExecuteStoredProcedure(UpdateCommand);
               ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
               return ReturnValue;
           }
       }

       public int DeleteGuarantorLoanApplication(GuarantorLoanApplication theGuarantorLoanApplication)
       {
           int ReturnValue = 0;

           using (SqlCommand DeleteCommand = new SqlCommand())
           {
               DeleteCommand.CommandType = CommandType.StoredProcedure;
               DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
               DeleteCommand.Parameters.Add(GetParameter("@GuarantorLoanApplicationID", SqlDbType.Int, theGuarantorLoanApplication.GuarantorLoanApplicationID));
               DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               DeleteCommand.CommandText = "pCRM_GuarantorLoanApplications_Delete";
               ExecuteStoredProcedure(DeleteCommand);
               ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
               return ReturnValue;
           }
       }

       public int RejectGuarantorLoanApplication(GuarantorLoanApplication theLoanReject)
       {
           int ReturnValue = 0;

           using (SqlCommand UpdateCommand = new SqlCommand())
           {
               UpdateCommand.CommandType = CommandType.StoredProcedure;
               UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
               UpdateCommand.Parameters.Add(GetParameter("@GuarantorLoanApplicationID", SqlDbType.Int, theLoanReject.GuarantorLoanApplicationID));
               UpdateCommand.Parameters.Add(GetParameter("@LoanAppliedBy", SqlDbType.VarChar, theLoanReject.LoanAppliedBy));
               UpdateCommand.Parameters.Add(GetParameter("@LoanApplicantID", SqlDbType.Int, theLoanReject.LoanApplicantID));
               UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationDate", SqlDbType.VarChar, theLoanReject.LoanApplicationDate));
               UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationFee", SqlDbType.Decimal, theLoanReject.LoanApplicationFee));
               UpdateCommand.Parameters.Add(GetParameter("@RequiredFor", SqlDbType.VarChar, theLoanReject.RequiredFor));
               UpdateCommand.Parameters.Add(GetParameter("@LoanAmountApplied", SqlDbType.Decimal, theLoanReject.LoanAmountApplied));
               UpdateCommand.Parameters.Add(GetParameter("@ApprovalStatus", SqlDbType.VarChar, theLoanReject.ApprovalStatus));
               UpdateCommand.Parameters.Add(GetParameter("@Remarks", SqlDbType.VarChar, theLoanReject.Remarks));
               UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
               UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               UpdateCommand.CommandText = "pCRM_GuarantorLoanApplications_Update";
               ExecuteStoredProcedure(UpdateCommand);
               ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
               return ReturnValue;
           }
       }
       #endregion
   }
}
