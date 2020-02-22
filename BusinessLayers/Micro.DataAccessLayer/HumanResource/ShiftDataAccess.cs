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
    public partial class ShiftDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ShiftDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ShiftDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ShiftDataAccess();
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

        public int InsertShift(Shift _Shift)
        {
            try
            {

                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@ShiftDescription", SqlDbType.VarChar, _Shift.ShiftDescription));
                SqlCmd.Parameters.Add(GetParameter("@ShiftAlias", SqlDbType.VarChar, _Shift.ShiftAlias));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_Shifts_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateShift(Shift _Shift)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@ShiftID", SqlDbType.Int, _Shift.ShiftID));
                SqlCmd.Parameters.Add(GetParameter("@ShiftDescription", SqlDbType.VarChar, _Shift.ShiftDescription));
                SqlCmd.Parameters.Add(GetParameter("@ShiftAlias", SqlDbType.VarChar, _Shift.ShiftAlias));
                SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, _Shift.IsActive));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_Shifts_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteShift(Shift theShift)
        {
            try
            {
                int ReturnValue = 0;

                using (SqlCommand DeleteCommand = new SqlCommand())
                {
                    DeleteCommand.CommandType = CommandType.StoredProcedure;
                    DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                    DeleteCommand.Parameters.Add(GetParameter("@ShiftId", SqlDbType.Int, theShift.ShiftID));
                    DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                    DeleteCommand.CommandText = "pHRM_Shifts_Delete";
                    ExecuteStoredProcedure(DeleteCommand);
                    ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                    return ReturnValue;
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


        #endregion

        #region Data Retrive Mathods

        public DataTable GetShiftsList(string searchText, bool showDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pHRM_Shifts_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetShiftByID(int ShiftID)
        {
            try
            {
                SqlCommand GetbyIdCmd = new SqlCommand();
                GetbyIdCmd.CommandType = CommandType.StoredProcedure;

                GetbyIdCmd.Parameters.Add(GetParameter("@ShiftID", SqlDbType.Int, ShiftID));
                GetbyIdCmd.CommandText = "pHRM_Shifts_SelectByShiftID";

                return ExecuteGetDataRow(GetbyIdCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        #endregion

    }
}
