using System;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.CustomerRelation;

namespace Micro.DataAccessLayer.CustomerRelation
{
    public partial class GuarantorLoanDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static GuarantorLoanDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static GuarantorLoanDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GuarantorLoanDataAccess();
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

        public DataTable GetGuarantorLoanList(bool allOffices = true, bool showDeleted = false, bool showClosed=false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@showClosed", SqlDbType.Bit, showClosed));
                SelectCommand.CommandText = "pCRM_GuarantorLoans_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetAllPreviousLoanDetailByID(int LoanApplicantID, string LoanAppliedBy)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@LoanApplicantID", SqlDbType.Int, LoanApplicantID));
                SelectCommand.Parameters.Add(GetParameter("@LoanAppliedBy", SqlDbType.VarChar, LoanAppliedBy));
                SelectCommand.CommandText = "pCRM_GuarantorLoans_SelectByLoanApplicantID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataTable GetGuarantorLoansByOfficeID(bool allOffices, string officeIds)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, officeIds));
                SelectCommand.CommandText = "pRPT_GuarantorLoans_SelectByOfficeID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetPreviousLoanDetails(int LoanApplicantID, string RecordValue)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@LoanApplicantID", SqlDbType.Int, LoanApplicantID));
                SelectCommand.Parameters.Add(GetParameter("@LoanAppliedBy", SqlDbType.VarChar, RecordValue));
                SelectCommand.CommandText = "pCRM_GuarantorLoans_SelectActiveLoanByLoanApplicantID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetEMIChartDetails(int LoanApplicantID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@LoanApplicantID", SqlDbType.Int, LoanApplicantID));
                SelectCommand.CommandText = "pCRM_GuarantorLoans_SelectByLoanApplicantID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataTable EMITable(double RateOfInterest, double Tenure, double PrincipalAmount,double Emiamount)
        {
            double EMIAmount = 0;
            double EMIInterest = 0;
            double EMIPrincipal = 0;
            double EMIOutstandings = 0;

            RateOfInterest = ((RateOfInterest / 100) / 12);

            EMIAmount = Emiamount;//Math.Round(Financial.Pmt(RateOfInterest, Tenure, -PrincipalAmount), 0);
            EMIOutstandings = PrincipalAmount;

            DataTable dbDataTable = new DataTable();

            dbDataTable.Columns.Add("EMISr", typeof(int));
            dbDataTable.Columns.Add("EMIAmount", typeof(double));
            dbDataTable.Columns.Add("EMIInterest", typeof(double));
            dbDataTable.Columns.Add("EMIPrincipal", typeof(double));
            dbDataTable.Columns.Add("EMIOutstandings", typeof(double));

            for (int Counter = 1; Counter <= Tenure; Counter++)
            {
                EMIInterest = Math.Round((EMIOutstandings * RateOfInterest), 0);
                EMIPrincipal = EMIAmount - EMIInterest;
                EMIOutstandings = Math.Round((EMIOutstandings - EMIPrincipal), 0);

                dbDataTable.Rows.Add(Counter, EMIAmount, EMIInterest, EMIPrincipal, EMIOutstandings);
            }

            return dbDataTable;
        }

        //Procedure For Reports
        public DataTable GetGuarantorLoansByLoanAppliedBy(string loanAppliedBy, bool allOffices, string officeIds)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@LoanAppliedBy", SqlDbType.VarChar, loanAppliedBy));
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@OfficeIDs", SqlDbType.VarChar, officeIds));
                SelectCommand.CommandText = "pRPT_GuarantorLoans_SelectByLoanAppliedBy";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetGuarantorLoanDetails(int GuarantorLoanID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@GuarantorLoanID", SqlDbType.Int, GuarantorLoanID));
                SelectCommand.CommandText = "pCRM_GuarantorLoans_SelectByGuarantorLoanID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetGuarantorLoansById(int GuarantorLoanID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@GuarantorLoanID", SqlDbType.Int, GuarantorLoanID));
                SelectCommand.CommandText = "pCRM_GuarantorLoans_SelectByGuarantorLoanID";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertGuarantorLoan(GuarantorLoan theGuarantorLoan)
        {
            int ReturnValue = 0;

            SqlCommand InsertCommand = new SqlCommand();

            InsertCommand.CommandType = CommandType.StoredProcedure;

            InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            InsertCommand.Parameters.Add(GetParameter("@GuarantorLoanApplicationID", SqlDbType.Int, theGuarantorLoan.GuarantorLoanApplicationID));
            InsertCommand.Parameters.Add(GetParameter("@LoanIssueDate", SqlDbType.VarChar, theGuarantorLoan.LoanIssueDate));
            InsertCommand.Parameters.Add(GetParameter("@LoanAmount", SqlDbType.Decimal, theGuarantorLoan.LoanAmount));
            InsertCommand.Parameters.Add(GetParameter("@TenureInMonths", SqlDbType.Int, theGuarantorLoan.TenureInMonths));
            InsertCommand.Parameters.Add(GetParameter("@EMIStartsFromDate", SqlDbType.VarChar, theGuarantorLoan.EMIStartsFromDate));
            InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

            InsertCommand.CommandText = "pCRM_GuarantorLoans_Insert";

            ExecuteStoredProcedure(InsertCommand);
            ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int UpdateGuarantorLoan(GuarantorLoan theGuarantorLoan)
        {
            int ReturnValue = 0;

            SqlCommand UpdateCommand = new SqlCommand();

            UpdateCommand.CommandType = CommandType.StoredProcedure;

            UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            UpdateCommand.Parameters.Add(GetParameter("@GuarantorLoanID", SqlDbType.Int, theGuarantorLoan.GuarantorLoanID));
            UpdateCommand.Parameters.Add(GetParameter("@GuarantorLoanApplicationID", SqlDbType.Int, theGuarantorLoan.GuarantorLoanApplicationID));
            UpdateCommand.Parameters.Add(GetParameter("@LoanIssueDate", SqlDbType.VarChar, theGuarantorLoan.LoanIssueDate));
            UpdateCommand.Parameters.Add(GetParameter("@LoanAmount", SqlDbType.Decimal, theGuarantorLoan.LoanAmount));
            UpdateCommand.Parameters.Add(GetParameter("@RateOfInterest", SqlDbType.Decimal, theGuarantorLoan.RateOfInterest));
            UpdateCommand.Parameters.Add(GetParameter("@InstallmentType", SqlDbType.VarChar, theGuarantorLoan.InstallmentType));
            UpdateCommand.Parameters.Add(GetParameter("@TenureInMonths", SqlDbType.Int, theGuarantorLoan.TenureInMonths));
            UpdateCommand.Parameters.Add(GetParameter("@EMIStartsFromDate", SqlDbType.VarChar, theGuarantorLoan.EMIStartsFromDate));
            UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

            UpdateCommand.CommandText = "pCRM_GuarantorLoans_Update";

            ExecuteStoredProcedure(UpdateCommand);
            ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }

        public int DeleteGuarantorLoan(GuarantorLoan theGuarantorLoan)
        {
            int ReturnValue = 0;

            SqlCommand DeleteCommand = new SqlCommand();

            DeleteCommand.CommandType = CommandType.StoredProcedure;

            DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
            DeleteCommand.Parameters.Add(GetParameter("@GuarantorLoanID", SqlDbType.Int, theGuarantorLoan.GuarantorLoanID));
            DeleteCommand.CommandText = "pCRM_GuarantorLoans_Delete";

            ExecuteStoredProcedure(DeleteCommand);
            ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

            return ReturnValue;
        }
        #endregion
    }
}
