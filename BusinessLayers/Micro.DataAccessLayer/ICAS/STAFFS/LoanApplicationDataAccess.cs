using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace Micro.DataAccessLayer.ICAS.STAFFS
{
    public partial class LoanApplicationDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LoanApplicationDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LoanApplicationDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoanApplicationDataAccess();
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

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertLoanApplication(LoanApplication TheLoanMaster)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();

                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@LoanID", SqlDbType.Int, TheLoanMaster.LoanID));
                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, TheLoanMaster.SessionID));
                InsertCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, TheLoanMaster.EmployeeID));
                InsertCommand.Parameters.Add(GetParameter("@LoanApplicationDate", SqlDbType.VarChar, TheLoanMaster.LoanApplicationDate));
                InsertCommand.Parameters.Add(GetParameter("@LoanAmount", SqlDbType.Decimal, TheLoanMaster.LoanAmount));
                InsertCommand.Parameters.Add(GetParameter("@TotalNoInstallment", SqlDbType.Int, TheLoanMaster.TotalNoInstallment));
                InsertCommand.Parameters.Add(GetParameter("@EMI", SqlDbType.Decimal, TheLoanMaster.EMI));

                InsertCommand.Parameters.Add(GetParameter("@LoanStatus", SqlDbType.Bit, TheLoanMaster.LoanStatus));

                InsertCommand.Parameters.Add(GetParameter("@RequiredFor", SqlDbType.VarChar, TheLoanMaster.RequiredFor));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@SanctionedByID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pHRM_LoanPayments_Insert";

                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateLoanApplication(LoanApplication TheLoanMaster)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand UpdateCommand = new SqlCommand();
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationID", SqlDbType.Int, TheLoanMaster.LoanApplicationID));
                UpdateCommand.Parameters.Add(GetParameter("@LoanID", SqlDbType.Int, TheLoanMaster.LoanID));
                UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, TheLoanMaster.SessionID));
                UpdateCommand.Parameters.Add(GetParameter("@LoanApplicationDate", SqlDbType.VarChar, TheLoanMaster.LoanApplicationDate));
                UpdateCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, TheLoanMaster.EmployeeID));
                UpdateCommand.Parameters.Add(GetParameter("@LoanAmount", SqlDbType.Decimal, TheLoanMaster.LoanAmount));
                UpdateCommand.Parameters.Add(GetParameter("@TotalNoInstallment", SqlDbType.Int, TheLoanMaster.TotalNoInstallment));
                UpdateCommand.Parameters.Add(GetParameter("@EMI", SqlDbType.Decimal, TheLoanMaster.EMI));

                UpdateCommand.Parameters.Add(GetParameter("@RequiredFor", SqlDbType.VarChar, TheLoanMaster.RequiredFor));
                UpdateCommand.Parameters.Add(GetParameter("@SanctionedByID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                //SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Int, Desg.IsActive));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.CommandText = "pHRM_LoanPayments_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public DataTable GetLoanEmployeeList(bool allOffices = false, bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.Parameters.Add(GetParameter("@AllOffices", SqlDbType.Bit, allOffices));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pHRM_LoanPayments_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetEmployeeLoanDetailsByLoanApplicationID(int LoanApplicationID)
        {
            try
            {
                SqlCommand SelectCommandd = new SqlCommand();
                SelectCommandd.CommandType = CommandType.StoredProcedure;

                SelectCommandd.Parameters.Add(GetParameter("@LoanApplicationID", SqlDbType.Int, LoanApplicationID));

                SelectCommandd.CommandText = "pHRM_LoanPayments_SelectByLoanApplicationID";

                return ExecuteGetDataRow(SelectCommandd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        //public DataRow GetEmployeeLoanDetailsByEmployeeID(int EmployeeID)
        //{
        //    try
        //    {
        //        SqlCommand SelectCommandd = new SqlCommand();
        //        SelectCommandd.CommandType = CommandType.StoredProcedure;

        //        SelectCommandd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

        //        SelectCommandd.CommandText = "pHRM_LoanPayments_SelectByEmployeeID";

        //        return ExecuteGetDataRow(SelectCommandd);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }
        //}



        public DataTable GetEmployeeLoanListByEmployeeID(int EmployeeID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SelectCommand.CommandText = "pHRM_LoanPayments_SelectByEmployeeID";

                return ExecuteGetDataTable(SelectCommand);
            }
        }


        #endregion
    }
}
