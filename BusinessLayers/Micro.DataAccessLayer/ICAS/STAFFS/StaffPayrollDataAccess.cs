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
    public class StaffPayrollDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static StaffPayrollDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static StaffPayrollDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StaffPayrollDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertStaffPayRoll(StaffPayRoll Payroll)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@BillNo", SqlDbType.Int, Payroll.BillNo));
                SqlCmd.Parameters.Add(GetParameter("@TvNo", SqlDbType.Int, Payroll.TvNo));
                SqlCmd.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, Payroll.SessionID));

                SqlCmd.Parameters.Add(GetParameter("@Month", SqlDbType.VarChar, Payroll.Month));
                SqlCmd.Parameters.Add(GetParameter("@Year", SqlDbType.VarChar, Payroll.Year));
                SqlCmd.Parameters.Add(GetParameter("@BillDDate", SqlDbType.DateTime,Payroll.BillDate));
                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, Payroll.EmployeeID));

                SqlCmd.Parameters.Add(GetParameter("@GrossPay", SqlDbType.Decimal, Payroll.GrossPay));
                SqlCmd.Parameters.Add(GetParameter("@TotalWorkingDays", SqlDbType.Int,Payroll.TotalWorkingDays));
                SqlCmd.Parameters.Add(GetParameter("@TotalPresentWorkingDays", SqlDbType.Int, Payroll.PresentDay));

                SqlCmd.Parameters.Add(GetParameter("@BankLoanEMI", SqlDbType.Decimal, Payroll.BankLoanEMI));
                SqlCmd.Parameters.Add(GetParameter("@FixedDeduction", SqlDbType.Decimal,Payroll.FixedDeduction));
                SqlCmd.Parameters.Add(GetParameter("@OtherDeduction", SqlDbType.Decimal, Payroll.OtherDeduction));
                SqlCmd.Parameters.Add(GetParameter("@PresentDay", SqlDbType.Int, Payroll.PresentDay));

                SqlCmd.Parameters.Add(GetParameter("@NetPayable", SqlDbType.Decimal, Payroll.NetPayable));               

                SqlCmd.Parameters.Add(GetParameter("@BankLoanEMI", SqlDbType.Decimal, Payroll.BankLoanEMI));

                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_PayRollDetails_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
     
        #endregion

        #region Data Retrive Mathods
        /// <summary>
        /// Officewise Leave Applications
        /// </summary>
        public DataTable GetPayRollAll(int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectAll";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }     

        #endregion

    }
}
