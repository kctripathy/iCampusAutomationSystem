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
    public partial class ShiftScheduleDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ShiftScheduleDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ShiftScheduleDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShiftScheduleDataAccess();
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

        public int InsertShiftSchedule(ShiftSchedule _ShiftSchedule, Boolean AllowRescheduleOfPastShiftSchedules = false)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, _ShiftSchedule.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@ShiftTimingID", SqlDbType.Int, _ShiftSchedule.ShiftTimingID));
                SqlCmd.Parameters.Add(GetParameter("@ShiftScheduleForWeekDay", SqlDbType.Int, _ShiftSchedule.ShiftScheduleForWeekDay));
                SqlCmd.Parameters.Add(GetParameter("@ShiftScheduleForDate", SqlDbType.DateTime, _ShiftSchedule.ShiftScheduleForDate));
                SqlCmd.Parameters.Add(GetParameter("@AllowRescheduleOfPastShiftSchedules", SqlDbType.Bit, 1));

                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_ShiftSchedules_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateShiftSchedule(ShiftSchedule _ShiftSchedule, Boolean AllowRescheduleOfPastShiftSchedules = false)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("ShiftScheduleID", SqlDbType.Int, _ShiftSchedule.ShiftScheduleID));

                SqlCmd.Parameters.Add(GetParameter("@ShiftScheduleForWeekDay", SqlDbType.VarChar, _ShiftSchedule.ShiftScheduleForWeekDay.ToString()));
                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, _ShiftSchedule.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@ShiftTimingID", SqlDbType.Int, _ShiftSchedule.ShiftTimingID));
                //SqlCmd.Parameters.Add(GetParameter("@AllowRescheduleOfPastShiftSchedules", SqlDbType.Bit, (AllowRescheduleOfPastShiftSchedules == true ? 1 : 0)));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_ShiftSchedules_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteShiftSchedule(ShiftSchedule _ShiftSchedule)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand DeleteCommand = new SqlCommand();

                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@ShiftScheduleID", SqlDbType.Int, _ShiftSchedule.ShiftScheduleID));
                DeleteCommand.CommandText = "pHRM_ShiftSchedules_Delete";

                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public DataTable GetShiftScheduledsAll(int OfficeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.CommandText = "pHRM_ShiftSchedules_SelectByOfficeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetShiftScheduledsByDeparment(int DepartmentID, string Date, int OfficeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@Date", SqlDbType.VarChar, Date));

                SqlCmd.CommandText = "pHRM_ShiftSchedules_SelectByDepartmentIDOfficeID";

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
