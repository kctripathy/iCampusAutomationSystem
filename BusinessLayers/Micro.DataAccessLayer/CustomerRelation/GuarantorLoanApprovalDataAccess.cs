using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class GuarantorLoanApprovalDataAccess : AbstractData_SQLClient
    {
        #region Declaration
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static GuarantorLoanApprovalDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static GuarantorLoanApprovalDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GuarantorLoanApprovalDataAccess();
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

        public DataTable GetAllUnpaidApproveLoanList(bool allOffices = true)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
            SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
            SelectCommand.CommandText = "pCRM_GuarantorLoanApprovals_Unpaid";

            return ExecuteGetDataTable(SelectCommand);
        }

        public DataRow GetAllApproveLoanDetailByID(int GuarantorLoanApprovalID)
        {
            SqlCommand SelectCommand = new SqlCommand();

            SelectCommand.CommandType = CommandType.StoredProcedure;
            SelectCommand.Parameters.Add(GetParameter("@GuarantorLoanApprovalID", SqlDbType.Int, GuarantorLoanApprovalID));
            SelectCommand.CommandText = "pCRM_GuarantorLoanApprovals_SelectByGuarantorLoanApprovalID";

            return ExecuteGetDataRow(SelectCommand);
        }

        public int InsertGuarantorLoanApproval(GuarantorLoanApproval theLoanApproval)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;

            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@GuarantorLoanApplicationID", SqlDbType.Int, theLoanApproval.GuarantorLoanApplicationID));
            InsertCommand.Parameters.Add(GetParameter("@LoanApplicationNumber", SqlDbType.VarChar, theLoanApproval.LoanApplicationNumber));
            InsertCommand.Parameters.Add(GetParameter("@LoanApprovalDate", SqlDbType.VarChar, theLoanApproval.LoanApprovalDate));
            InsertCommand.Parameters.Add(GetParameter("@LoanApprovalAmount", SqlDbType.Decimal, theLoanApproval.LoanApprovalAmount));
            InsertCommand.Parameters.Add(GetParameter("@LoanApprovedTenureInMonths", SqlDbType.Int, theLoanApproval.LoanApprovedTenureInMonths));
            InsertCommand.Parameters.Add(GetParameter("@LoanApprovedRateOfInterest", SqlDbType.Decimal, theLoanApproval.LoanApprovedRateOfInterest));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

            InsertCommand.CommandText = "pCRM_GuarantorLoanApprovals_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        #endregion
    }
}
