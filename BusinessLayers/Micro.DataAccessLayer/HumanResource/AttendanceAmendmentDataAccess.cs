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
    public class AttendanceAmendmentDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static AttendanceAmendmentDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static AttendanceAmendmentDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AttendanceAmendmentDataAccess();
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

        public int InsertAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {

                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, _AttendanceAmendment.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@DateOfAttendance", SqlDbType.DateTime, _AttendanceAmendment.DateOfAttendance));
                SqlCmd.Parameters.Add(GetParameter("@AttendanceType", SqlDbType.VarChar, _AttendanceAmendment.AttendanceType));
                SqlCmd.Parameters.Add(GetParameter("@OldTime", SqlDbType.DateTime, _AttendanceAmendment.OldTime));
                SqlCmd.Parameters.Add(GetParameter("@NewTime", SqlDbType.DateTime, _AttendanceAmendment.NewTime));
                SqlCmd.Parameters.Add(GetParameter("@Reason", SqlDbType.VarChar, _AttendanceAmendment.Reason));

                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
               
                SqlCmd.CommandText = "pHRM_AttendanceAmendments_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;

            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@AttendanceAmendmentID", SqlDbType.Int, _AttendanceAmendment.AttendanceAmendmentID));
                SqlCmd.Parameters.Add(GetParameter("@DateOfAttendance", SqlDbType.DateTime, _AttendanceAmendment.DateOfAttendance));
                SqlCmd.Parameters.Add(GetParameter("@AttendanceType", SqlDbType.VarChar, _AttendanceAmendment.AttendanceType));
                SqlCmd.Parameters.Add(GetParameter("@OldTime", SqlDbType.DateTime, _AttendanceAmendment.OldTime));
                SqlCmd.Parameters.Add(GetParameter("@NewTime", SqlDbType.DateTime, _AttendanceAmendment.NewTime));
                SqlCmd.Parameters.Add(GetParameter("@Reason", SqlDbType.VarChar, _AttendanceAmendment.Reason));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                
                SqlCmd.CommandText = "pHRM_AttendanceAmendments_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int ApproveOrRejectAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@AttendanceAmendmentID", SqlDbType.Int, _AttendanceAmendment.AttendanceAmendmentID));
                SqlCmd.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, _AttendanceAmendment.Status));
                SqlCmd.Parameters.Add(GetParameter("@ApprovedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.Parameters.Add(GetParameter("@ApprovalOrRejectionReason", SqlDbType.VarChar, _AttendanceAmendment.ApprovalOrRejectionReason));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                
                SqlCmd.CommandText = "pHRM_AttendanceAmendments_UpdateApprovalStatus";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteAttendanceAmendment(AttendanceAmendment _AttendanceAmendment)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@AttendanceAmendmentID", SqlDbType.Int, _AttendanceAmendment.AttendanceAmendmentID));
                SqlCmd.CommandText = "pHRM_AttendanceAmendments_Delete";

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

        public DataTable GetAttendanceAmendmentsAll(string searchText, bool showDeleted = false)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SqlCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));

                SqlCmd.CommandText = "pHRM_AttendanceAmendments_SelectAll";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetAttendanceAmendmentsByEmployee(int EmployeeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

                SqlCmd.CommandText = "pHRM_AttendanceAmendments_SelectByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetPendingAttendanceAmendmentsByEmployee(int EmployeeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

                SqlCmd.CommandText = "pHRM_AttendanceAmendments_SelectAllPendingsByEmployee";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public DataRow GetAttendanceAmendmentByAttendanceAmendmentID(int AttendanceAmendmentID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@AttendanceAmendmentID", SqlDbType.Int, AttendanceAmendmentID));

                SqlCmd.CommandText = "pHRM_AttendanceAmendments_SelectByAttendanceAmendmentID";

                return ExecuteGetDataRow(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetPendingAttendanceAmendmentsAll()
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.CommandText = "pHRM_AttendanceAmendments_SelectAllPendings";

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
        public DataTable GetPendingAttendanceAmendmentApplicationsByReportingEmployee(int EmployeeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, (EmployeeID == -1 ? Micro.Commons.Connection.LoggedOnUser.UserReferenceID : EmployeeID)));
                SqlCmd.CommandText = "pHRM_AttendanceAmendments_SelectPendingAttendanceAmendmentsByReportingEmployeeID";

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
