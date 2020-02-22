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
    public partial class ShiftTimingsDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ShiftTimingsDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ShiftTimingsDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShiftTimingsDataAccess();
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

        public int InsertShiftTimings(ShiftTiming _ShiftTimings)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@ShiftID", SqlDbType.Int, _ShiftTimings.ShiftID));
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, _ShiftTimings.DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@InTime", SqlDbType.DateTime, _ShiftTimings.InTime));
                SqlCmd.Parameters.Add(GetParameter("@OutTime", SqlDbType.DateTime, _ShiftTimings.OutTime));
                SqlCmd.Parameters.Add(GetParameter("@CalculationMode", SqlDbType.VarChar, _ShiftTimings.CalculationMode));
                SqlCmd.Parameters.Add(GetParameter("@WeeklyOffDay", SqlDbType.VarChar, _ShiftTimings.WeeklyOffDay));
                SqlCmd.Parameters.Add(GetParameter("@EffectiveDate", SqlDbType.DateTime, _ShiftTimings.EffectiveDate));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
 
                SqlCmd.CommandText = "pHRM_ShiftTimings_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateShiftTimings(ShiftTiming _ShiftTimings)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("ShiftTimingID", SqlDbType.Int, _ShiftTimings.ShiftTimingID));

                SqlCmd.Parameters.Add(GetParameter("@ShiftID", SqlDbType.Int, _ShiftTimings.ShiftID));
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, _ShiftTimings.DepartmentID));

                string iTime = DateTime.Parse(_ShiftTimings.InTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                string oTime = DateTime.Parse(_ShiftTimings.OutTime.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                string eTime = DateTime.Parse(_ShiftTimings.EffectiveDate.ToString()).ToString("yyyy/MM/dd HH:mm:ss");

                SqlCmd.Parameters.Add(GetParameter("@InTime", SqlDbType.DateTime, iTime));
                SqlCmd.Parameters.Add(GetParameter("@OutTime", SqlDbType.DateTime, oTime));
                SqlCmd.Parameters.Add(GetParameter("@CalculationMode", SqlDbType.VarChar, _ShiftTimings.CalculationMode));
                SqlCmd.Parameters.Add(GetParameter("@WeeklyOffDay", SqlDbType.VarChar, _ShiftTimings.WeeklyOffDay));
                SqlCmd.Parameters.Add(GetParameter("@EffectiveDate", SqlDbType.DateTime, eTime));
                //SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, (_ShiftTimings.IsActive == true) ? 1 : 0));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_ShiftTimings_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteShiftTimings(int ShiftTimingID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand DeleteCommand = new SqlCommand();

                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@ShiftTimingID", SqlDbType.Int, ShiftTimingID));
                DeleteCommand.CommandText = "pHRM_ShiftTimings_Delete";

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

        public DataRow GetShiftTimingByShiftTimingID(int ShiftTiminigID)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ShiftTiminigID", SqlDbType.Int, ShiftTiminigID));
                SelectCommand.CommandText = "pHRM_ShiftTimings_SelectByShiftTimingID";

                return ExecuteGetDataRow(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetShiftTimingsByOfficeID(int OfficeID, string searchText = null, bool showDeleted = false)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, OfficeID));
                SqlCmd.CommandText = "pHRM_ShiftTimings_SelectByOfficeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetShiftTimingsByOfficeIDandDepartmentID(int DepartmentID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.CommandText = "pHRM_ShiftTimings_SelectByOfficeIDandDepartmentID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public DataTable GetShiftTimingsByOfficeIDandDepartmentID(int DepartmentID, int OfficeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                SqlCmd.CommandText = "pHRM_ShiftTimings_SelectByOfficeIDandDepartmentID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public DataTable GetCompanyShiftTimings()
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                SqlCmd.CommandText = "pHRM_ShiftTimings_SelectByOfficeID";

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
