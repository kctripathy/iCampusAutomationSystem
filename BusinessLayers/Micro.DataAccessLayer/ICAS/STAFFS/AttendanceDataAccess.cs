using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace Micro.DataAccessLayer.ICAS.STAFFS
{
   public class  AttendanceDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static AttendanceDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static AttendanceDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AttendanceDataAccess();
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

        public void InsertAttendance(int EmployeeID, DateTime PunchDateTime)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                InsertCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                InsertCommand.Parameters.Add(GetParameter("@DateOfAttendance", SqlDbType.DateTime, PunchDateTime));
                InsertCommand.Parameters.Add(GetParameter("@AddedOrModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                InsertCommand.CommandText = "pHRM_Attendances_Insert";

                ExecuteStoredProcedure(InsertCommand);

                //InsertCommand.Parameters[0].Value.ToString();
                //ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                //return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public void InsertAttendance(int EmployeeID, DateTime PunchDateTime, Micro.Commons.MicroEnums.AttendanceType AttendanceType)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                InsertCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                InsertCommand.Parameters.Add(GetParameter("@DateOfAttendance", SqlDbType.DateTime, PunchDateTime));
                InsertCommand.Parameters.Add(GetParameter("@AttendanceType", SqlDbType.Int, (int)AttendanceType));
                InsertCommand.Parameters.Add(GetParameter("@AddedOrModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                InsertCommand.CommandText = "pHRM_Attendances_InsertManual";

                ExecuteStoredProcedure(InsertCommand);

                InsertCommand.Parameters[0].Value.ToString();
                //ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                //return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods

        public DataTable GetEmployeeDetailsAttendanceRegister(int EmployeeID, int _Month, int _Year)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@Month", SqlDbType.Int, _Month));
                SqlCmd.Parameters.Add(GetParameter("@Year", SqlDbType.Int, _Year));

                SqlCmd.CommandText = "pHRM_Attendances_SelectDetailsByEmployee";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetEmployeeAttendanceByDate(int EmployeeID, DateTime DateOfAttendance)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@DateOfAttendance", SqlDbType.DateTime, DateOfAttendance));

                SqlCmd.CommandText = "pHRM_Attendances_SelectByEmployeeIDAndDate";

                return ExecuteGetDataRow(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion


        public DataTable GetEmployeeDetailsAttendanceRegisterSummaryByDepartmentID(int DepartmentID, int _Month, int _Year)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@Month", SqlDbType.Int, _Month));
                SqlCmd.Parameters.Add(GetParameter("@Year", SqlDbType.Int, _Year));

                SqlCmd.CommandText = "pHRM_Attendances_SelectSummaryByDepartmentID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

    }
}
