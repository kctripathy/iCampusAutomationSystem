#region System Namespace
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
#endregion

#region Micro Namespaces
using Micro.Objects.HumanResource;

#endregion

namespace Micro.DataAccessLayer.HumanResource
{
    public class AttendanceApplicationDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static AttendanceApplicationDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static AttendanceApplicationDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AttendanceApplicationDataAccess();
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

        public int InsertAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, _AttendanceApplication.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@DateOfAttendance", SqlDbType.DateTime, _AttendanceApplication.DateOfAttendance));
                SqlCmd.Parameters.Add(GetParameter("@InTime", SqlDbType.DateTime, _AttendanceApplication.InTime));
                SqlCmd.Parameters.Add(GetParameter("@OutTime", SqlDbType.DateTime, _AttendanceApplication.OutTime));
                SqlCmd.Parameters.Add(GetParameter("@Reason", SqlDbType.VarChar, _AttendanceApplication.ApplicationReason));

                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                
                SqlCmd.CommandText = "pHRM_AttendanceApplications_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@AttendanceApplicationID", SqlDbType.Int, _AttendanceApplication.AttendanceApplicationID));

                SqlCmd.Parameters.Add(GetParameter("@DateOfAttendance", SqlDbType.DateTime, _AttendanceApplication.DateOfAttendance));
                SqlCmd.Parameters.Add(GetParameter("@InTime", SqlDbType.DateTime, _AttendanceApplication.InTime));
                SqlCmd.Parameters.Add(GetParameter("@OutTime", SqlDbType.DateTime, _AttendanceApplication.OutTime));
                SqlCmd.Parameters.Add(GetParameter("@Reason", SqlDbType.VarChar, _AttendanceApplication.ApplicationReason));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_AttendanceApplications_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int ApproveOrRejectAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@AttendanceApplicationID", SqlDbType.Int, _AttendanceApplication.AttendanceApplicationID));
                SqlCmd.Parameters.Add(GetParameter("@ApprovedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, _AttendanceApplication.Status));
                SqlCmd.Parameters.Add(GetParameter("@ApprovalOrRejectionReason", SqlDbType.VarChar, _AttendanceApplication.ApprovalOrRejectionReason));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_AttendanceApplications_UpdateApprovalStatus";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteAttendanceApplication(AttendanceApplication _AttendanceApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@AttendanceApplicationID", SqlDbType.Int, _AttendanceApplication.AttendanceApplicationID));

                SqlCmd.CommandText = "pHRM_AttendanceApplications_Delete";

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

        public DataTable GetAttendanceApplicationsAll(string searchText, bool showDeleted = false)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SqlCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));

                SqlCmd.CommandText = "pHRM_AttendanceApplications_SelectAll";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetAttendanceApplicationsByEmployee(int EmployeeID, string searchText = "", bool showDeleted = false)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SqlCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));

                SqlCmd.CommandText = "pHRM_AttendanceApplications_SelectByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetPeningApplicationsByEmployee(int EmployeeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

                SqlCmd.CommandText = "pHRM_AttendanceApplications_SelectByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetPeningApplicationsAll()
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.CommandText = "pHRM_AttendanceApplications_SelectAllPendings";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetAttendanceApplicationByAttendanceApplicationID(int AttendanceApplicationID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@AttendanceApplicationID", SqlDbType.Int, AttendanceApplicationID));

                SqlCmd.CommandText = "pHRM_AttendanceApplications_SelectByAttendanceApplicationID";

                return ExecuteGetDataRow(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        /// <summary>
        /// ReportingOfficerWise
        /// </summary>
        public DataTable GetPendingAttendanceApplicationsByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, (EmployeeID == -1 ? Micro.Commons.Connection.LoggedOnUser.UserReferenceID : EmployeeID)));
                SqlCmd.CommandText = "pHRM_AttendanceApplications_SelectPendingAttendanceApplicationsByReportingEmployeeID";

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
