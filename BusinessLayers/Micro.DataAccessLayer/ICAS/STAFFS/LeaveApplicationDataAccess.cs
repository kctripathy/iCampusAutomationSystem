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
   public  class LeaveApplicationDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static LeaveApplicationDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static LeaveApplicationDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LeaveApplicationDataAccess();
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

        public int InsertLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, _LeaveApplication.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeID", SqlDbType.Int, _LeaveApplication.LeaveTypeID));

                SqlCmd.Parameters.Add(GetParameter("@DateApplied", SqlDbType.DateTime, _LeaveApplication.DateApplied));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, _LeaveApplication.DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, _LeaveApplication.DateTo));

                SqlCmd.Parameters.Add(GetParameter("@LeaveApplicationReason", SqlDbType.VarChar, _LeaveApplication.ApplicationReason));

                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_LeaveApplications_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@LeaveApplicationID", SqlDbType.Int, _LeaveApplication.LeaveApplicationID));

                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeID", SqlDbType.Int, _LeaveApplication.LeaveTypeID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, _LeaveApplication.DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, _LeaveApplication.DateTo));
                SqlCmd.Parameters.Add(GetParameter("@LeaveApplicationReason", SqlDbType.VarChar, _LeaveApplication.ApplicationReason));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_LeaveApplications_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public int ApproveOrRejectLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@LeaveApplicationID", SqlDbType.Int, _LeaveApplication.LeaveApplicationID));
                SqlCmd.Parameters.Add(GetParameter("@ApprovedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserReferenceID));
                SqlCmd.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, _LeaveApplication.Status));
                SqlCmd.Parameters.Add(GetParameter("@ApprovalOrRejectionReason", SqlDbType.VarChar, _LeaveApplication.ApprovalOrRejectionReason));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_LeaveApplications_UpdateApprovalStatus";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteLeaveApplication(LeaveApplication _LeaveApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@LeaveApplicationID", SqlDbType.Int, _LeaveApplication.LeaveApplicationID));
                SqlCmd.CommandText = "pHRM_LeaveApplications_Delete";

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
        public DataTable GetOfficeLeaveApplicationsAll(int OfficeID = -1)
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

        public DataTable GetOfficeLeaveApplicationsAll(DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectAll";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficeLeaveApplicationsAll(DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, DateTo));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectAll";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Officewise Pending Leave Applications
        /// </summary>
        public DataTable GetOfficePeningLeaveApplicationsAll(int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplications";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficePeningLeaveApplicationsAll(DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplications";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficePeningLeaveApplicationsAll(DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, DateTo));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplications";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// DEPARTMENTWISE
        /// </summary>

        public DataTable GetDepartmentLeaveApplicationsAll(int DepartmentID, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectByDepartment";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetDepartmentLeaveApplicationsAll(int DepartmentID, DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectByDepartment";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetDepartmentLeaveApplicationsAll(int DepartmentID, DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, DateTo));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectByDepartment";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// Deparmentwise Pending Leave Applications
        /// </summary>

        public DataTable GetDepartmentPendingLeaveApplicationsAll(int DepartmentID, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplications_ByDepartment";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetDepartmentPendingLeaveApplicationsAll(int DepartmentID, DateTime DateFrom, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplications";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetDepartmentPendingLeaveApplicationsAll(int DepartmentID, DateTime DateFrom, DateTime DateTo, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID != -1 ? OfficeID : Micro.Commons.Connection.LoggedOnUser.OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, DateTo));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplications";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// EmployeeWise Applications
        /// </summary>

        public DataTable GetEmployeeLeaveApplicationsAll(int EmployeeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetEmployeeLeaveApplicationsAll(int EmployeeID, DateTime DateFrom)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));

                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetEmployeeLeaveApplicationsAll(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, DateTo));

                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// EmployeeWise Pending Applications
        /// </summary>

        public DataTable GetEmployeePendingLeaveApplicationsAll(int EmployeeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplicationsByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetEmployeePendingLeaveApplicationsAll(int EmployeeID, DateTime DateFrom)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));

                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplicationsByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetEmployeePendingLeaveApplicationsAll(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, DateTo));

                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplicationsByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// ReportingOfficerWise
        /// </summary>
        public DataTable GetPendingLeaveApplicationsByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, (EmployeeID == -1 ? Micro.Commons.Connection.LoggedOnUser.UserReferenceID : EmployeeID)));
                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectPendingApplicationsByReportingEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// APPLICATIONWISE
        /// </summary>
        public DataRow GetLeaveApplicationByLeaveApplicationID(int LeaveApplicationID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@LeaveApplicationID", SqlDbType.Int, LeaveApplicationID));

                SqlCmd.CommandText = "pHRM_LeaveApplications_SelectByLeaveApplicationID";

                return ExecuteGetDataRow(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

    }
}
