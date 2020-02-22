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
    public partial class HolidayOfficewiseDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static HolidayOfficewiseDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static HolidayOfficewiseDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HolidayOfficewiseDataAccess();
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

        public int InsertHolidayOfficewise(HolidayOfficewise _HolidayOfficewise)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@HolidayID", SqlDbType.Int, _HolidayOfficewise.HolidayID));
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_HolidaysOfficewise_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateHolidayOfficewise(HolidayOfficewise _HolidayOfficewise)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("HolidaysOfficewiseID", SqlDbType.Int, _HolidayOfficewise.HolidayOfficewiseID));
                SqlCmd.Parameters.Add(GetParameter("@HolidayID", SqlDbType.Int, _HolidayOfficewise.HoliDay.HolidayID));
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, (_HolidayOfficewise.IsActive==true?1:0) ));
                SqlCmd.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, (_HolidayOfficewise.IsActive == true ? 0 : 1)));

                SqlCmd.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime, DateTime.Now));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_HolidaysOfficewise_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteHolidayOfficewise(int HolidayOfficeWiseID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand DeleteCommand = new SqlCommand();

                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@HolidaysOfficewiseID", SqlDbType.Int, HolidayOfficeWiseID));
                DeleteCommand.CommandText = "pHRM_HolidaysOfficewise_Delete";

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

        public DataRow GetHolidayOfficewiseByID(int HolidayOfficewiseID)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@HolidaysOfficewiseID", SqlDbType.Int, HolidayOfficewiseID));
                SelectCommand.CommandText = "pHRM_HolidaysOfficewise_SelectByHolidaysOfficewiseID";

                return ExecuteGetDataRow(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetHolidayOfficewiseByOfficeID(int OfficeID)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, OfficeID));
                SelectCommand.CommandText = "pHRM_HolidaysOfficewise_SelectByOfficeID";

                return ExecuteGetDataRow(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetHolidayOfficewiseByOfficeIDandCalenderYear(int CalenderYear, int OfficeID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (OfficeID == -1 ? Micro.Commons.Connection.LoggedOnUser.OfficeID : OfficeID)));
                SqlCmd.Parameters.Add(GetParameter("@CalendarYear", SqlDbType.Int, CalenderYear));
                SqlCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SqlCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SqlCmd.CommandText = "pHRM_HolidaysOfficewise_SelectByOfficeIDAndCalendarYear";

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
