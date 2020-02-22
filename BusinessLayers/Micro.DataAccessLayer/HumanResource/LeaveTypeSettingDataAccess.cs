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
    public partial class LeaveTypeSettingDataAccess:AbstractData_SQLClient 
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LeaveTypeSettingDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LeaveTypeSettingDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LeaveTypeSettingDataAccess();
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

        public int InsertLeaveTypeSettings(LeaveTypeSettings _LeaveTypeSettings)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeID", SqlDbType.Int, _LeaveTypeSettings.LeaveTypeID ));
                SqlCmd.Parameters.Add(GetParameter("@NumberOfDaysAllowed", SqlDbType.Int, _LeaveTypeSettings.NumberOfDaysAllowed));
                SqlCmd.Parameters.Add(GetParameter("@NumberOfConsecutiveDaysAllowed", SqlDbType.Int, _LeaveTypeSettings.NumberOfConsecutiveDaysAllowed ));
                SqlCmd.Parameters.Add(GetParameter("@ForGender", SqlDbType.VarChar, _LeaveTypeSettings.ForGender));
                SqlCmd.Parameters.Add(GetParameter("@CreditPeriodInMonths", SqlDbType.Int, _LeaveTypeSettings.CreditPeriodInMonths));
                SqlCmd.Parameters.Add(GetParameter("@MaximumAccumulatedDays", SqlDbType.Int, _LeaveTypeSettings.MaximumAccumulatedDays));
                SqlCmd.Parameters.Add(GetParameter("@CalculationMode", SqlDbType.Int, _LeaveTypeSettings.CalculationMode));
                SqlCmd.Parameters.Add(GetParameter("@IsTransferrable", SqlDbType.Bit, _LeaveTypeSettings.IsTransferrable));
                SqlCmd.Parameters.Add(GetParameter("@IsEncashable", SqlDbType.Int, _LeaveTypeSettings.IsEncashable));
                SqlCmd.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.DateTime, _LeaveTypeSettings.EffectiveDate));

                SqlCmd.Parameters.Add(GetParameter("@LeaveCreditInterval", SqlDbType.VarChar, _LeaveTypeSettings.CreditInterval));
                SqlCmd.Parameters.Add(GetParameter("@Quarter1", SqlDbType.Int, _LeaveTypeSettings.Quarter1));
                SqlCmd.Parameters.Add(GetParameter("@Quarter2", SqlDbType.Int, _LeaveTypeSettings.Quarter2));
                SqlCmd.Parameters.Add(GetParameter("@Quarter3", SqlDbType.Int, _LeaveTypeSettings.Quarter3));
                SqlCmd.Parameters.Add(GetParameter("@Quarter4", SqlDbType.Int, _LeaveTypeSettings.Quarter4));

                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_LeaveTypeSettings_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateLeaveTypeSettings(LeaveTypeSettings _LeaveTypeSettings)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeSettingID", SqlDbType.Int, _LeaveTypeSettings.LeaveTypeSettingID));
                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeID", SqlDbType.Int, _LeaveTypeSettings.LeaveTypeID));
                SqlCmd.Parameters.Add(GetParameter("@NumberOfDaysAllowed", SqlDbType.Int, _LeaveTypeSettings.NumberOfDaysAllowed));
                SqlCmd.Parameters.Add(GetParameter("@NumberOfConsecutiveDaysAllowed", SqlDbType.Int, _LeaveTypeSettings.NumberOfConsecutiveDaysAllowed));
                SqlCmd.Parameters.Add(GetParameter("@ForGender", SqlDbType.VarChar, _LeaveTypeSettings.ForGender));
                SqlCmd.Parameters.Add(GetParameter("@CreditPeriodInMonths", SqlDbType.Int, _LeaveTypeSettings.CreditPeriodInMonths));
                SqlCmd.Parameters.Add(GetParameter("@MaximumAccumulatedDays", SqlDbType.Int, _LeaveTypeSettings.MaximumAccumulatedDays));
                SqlCmd.Parameters.Add(GetParameter("@CalculationMode", SqlDbType.Int, _LeaveTypeSettings.CalculationMode));
                SqlCmd.Parameters.Add(GetParameter("@IsTransferrable", SqlDbType.Bit, _LeaveTypeSettings.IsTransferrable));
                SqlCmd.Parameters.Add(GetParameter("@IsEncashable", SqlDbType.Int, _LeaveTypeSettings.IsEncashable));
                SqlCmd.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.DateTime, _LeaveTypeSettings.EffectiveDate));

                SqlCmd.Parameters.Add(GetParameter("@LeaveCreditInterval", SqlDbType.VarChar, _LeaveTypeSettings.CreditInterval));
                SqlCmd.Parameters.Add(GetParameter("@Quarter1", SqlDbType.Int, _LeaveTypeSettings.Quarter1));
                SqlCmd.Parameters.Add(GetParameter("@Quarter2", SqlDbType.Int, _LeaveTypeSettings.Quarter2));
                SqlCmd.Parameters.Add(GetParameter("@Quarter3", SqlDbType.Int, _LeaveTypeSettings.Quarter3));
                SqlCmd.Parameters.Add(GetParameter("@Quarter4", SqlDbType.Int, _LeaveTypeSettings.Quarter4));

                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));

                SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, _LeaveTypeSettings.IsActive));
                SqlCmd.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, _LeaveTypeSettings.IsDeleted));
                SqlCmd.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime , DateTime.Now));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_LeaveTypeSettings_Update";

                 ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteLeaveTypeSettings(int LeaveTypeSettingID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeSettingID", SqlDbType.Int, LeaveTypeSettingID));

                SqlCmd.CommandText = "pHRM_LeaveTypeSettings_Delete";

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

        public DataTable GetLeaveTypeSettingsList(string searchText, bool showDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pHRM_LeaveTypeSettings_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetLeaveTypeSettingsByLeaveTypeSettingID(int LeaveTypeSettingID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeSettingID", SqlDbType.Int, LeaveTypeSettingID));
                SqlCmd.CommandText = "pHRM_LeaveTypeSettings_SelectByLeaveTypeSettingID";

                return ExecuteGetDataRow(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetLeaveTypeSettingsByOfficeIDandLeaveTypeID(int LeaveTypeID, int OfficeID = -1)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@LeaveTypeID", SqlDbType.Int, LeaveTypeID));
                if (OfficeID == -1)
                {
                    SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                }
                else
                {
                    SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, OfficeID));
                }
                SqlCmd.CommandText = "pHRM_LeaveTypeSettings_SelectByOfficeIDandLeaveTypeID";

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
