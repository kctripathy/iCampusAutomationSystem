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
    public partial class LeaveTypeOfficewiseDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LeaveTypeOfficewiseDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LeaveTypeOfficewiseDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LeaveTypeOfficewiseDataAccess();
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

        public int InsertLeaveTypeOfficewise(LeaveTypeOfficewise _LeaveTypeOfficewise)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeID", SqlDbType.Int, _LeaveTypeOfficewise.LeaveTypeID));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_LeaveTypesOfficewise_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateLeaveTypeOfficewise(LeaveTypeOfficewise _LeaveTypeOfficewise)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("LeaveTypeOfficewiseID", SqlDbType.Int, _LeaveTypeOfficewise.LeaveTypeOfficewiseID));
                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeID", SqlDbType.Int, _LeaveTypeOfficewise.LeaveTypeID));
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, (_LeaveTypeOfficewise.IsActive == true ? 1 : 0)));

                SqlCmd.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime, DateTime.Now));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_LeaveTypesOfficewise_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteLeaveTypeOfficewise(int LeaveTypeOfficewiseID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand DeleteCommand = new SqlCommand();

                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@LeaveTypeOfficewiseID", SqlDbType.Int, LeaveTypeOfficewiseID));
                DeleteCommand.CommandText = "pHRM_LeaveTypesOfficewise_Delete";

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

        public DataRow GetLeaveTypeOfficewiseByID(int LeaveTypeOfficewiseID)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@LeaveTypeOfficewiseID", SqlDbType.Int, LeaveTypeOfficewiseID));
                SelectCommand.CommandText = "pHRM_LeaveTypesOfficewise_SelectByLeaveTypeID";

                return ExecuteGetDataRow(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetLeaveTypeOfficewiseByOfficeID(int CompanyID = -1)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, (CompanyID == -1 ? Micro.Commons.Connection.LoggedOnUser.CompanyID : CompanyID)));

                SelectCommand.CommandText = "pHRM_LeaveTypesOfficewise_SelectByOfficeID";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetLeaveTypeOfficewiseByOfficeIDandDeparmentID(int CompanyID, int LeaveTypeID, string searchText = null, bool showDeleted = false)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, CompanyID));
                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeID", SqlDbType.Int, LeaveTypeID));
                SqlCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SqlCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SqlCmd.CommandText = "pHRM_LeaveTypesOfficewise_SelectByOfficeIDAndLeaveTypeID";

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
