using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Micro.DataAccessLayer.Administration
{
	public partial class CalendarDataAccess:AbstractData_SQLClient
	{
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CalendarDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CalendarDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CalendarDataAccess();
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

        #region Methods & implementation

        public DataTable GetAllDates()
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_Calendar_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch(Exception ex)
            { 
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetAllByDate(int TheDate)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@TheDate", SqlDbType.Int, TheDate));
                SelectCommand.CommandText = "pADM_Calendar_SelectAllByDate";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetAllDateByID(int TheDateID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@TheDateID", SqlDbType.Int, TheDateID));
                SqlCmd.CommandText = "pADM_Calendar_SelectAllByID";

                return ExecuteGetDataRow(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetAllGovtHoliday()
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                //SelectCommand.Parameters.Add(GetParameter("@IsGovtHoliday", SqlDbType.Char, IsGovtHoliday));
                SelectCommand.CommandText = "pADM_Calendar_SelectAllGovtHolidays";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetAllLocalHoliday()
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                //SelectCommand.Parameters.Add(GetParameter("@IsLocalHoliday", SqlDbType.Char, IsLocalHoliday));
                SelectCommand.CommandText = "pADM_Calendar_SelectAllLocalHolidays";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetAllMicroHoliday()
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                //SelectCommand.Parameters.Add(GetParameter("@IsMicroHoliday", SqlDbType.Char, IsMicroHoliday));
                SelectCommand.CommandText = "pADM_Calendar_SelectAllMicroHolidays";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }




        #endregion

    }
}
