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
    public partial class HolidayDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static HolidayDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static HolidayDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HolidayDataAccess();
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

        public int InsertHoliday(Holiday  _Holiday)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@Occasion", SqlDbType.VarChar , _Holiday.Occasion));
                SqlCmd.Parameters.Add(GetParameter("@DateOfOccasion", SqlDbType.DateTime, _Holiday.DateOfOccasion));
                SqlCmd.Parameters.Add(GetParameter("@IsDateFixed", SqlDbType.Bit, _Holiday.IsDateFixed));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_Holidays_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateHoliday(Holiday  _Holiday)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@HolidayID", SqlDbType.Int, _Holiday.HolidayID));
                SqlCmd.Parameters.Add(GetParameter("@Occasion", SqlDbType.VarChar, _Holiday.Occasion));
                SqlCmd.Parameters.Add(GetParameter("@DateOfOccasion", SqlDbType.DateTime, _Holiday.DateOfOccasion));
                SqlCmd.Parameters.Add(GetParameter("@IsDateFixed", SqlDbType.Bit, _Holiday.IsDateFixed));
              //  SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, _Holiday.IsActive));
               // SqlCmd.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, _Holiday.IsDeleted));
                SqlCmd.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime, DateTime.Now));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_Holidays_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteHoliday(int HolidayID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@HolidayID", SqlDbType.Int, HolidayID));
                SqlCmd.CommandText = "pHRM_Holidays_Delete";

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

        public DataTable GetAllHolidays(string searchText, bool showDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                //SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
               // SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pHRM_Holidays_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetAllHolidaysByCalenderYear(int CalenderYear, string searchText="a", bool showDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@CalenderYear", SqlDbType.Int, CalenderYear));
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, "a"));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, false));
                SelectCommand.CommandText = "pHRM_Holidays_SelectByCalendarYear";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetHolidayByID(int HolidayID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@HolidayID", SqlDbType.Int, HolidayID));
                SqlCmd.CommandText = "pHRM_Holidays_SelectByHolidayID";

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
