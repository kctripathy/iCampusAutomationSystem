#region System Namespace
using System;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
#endregion

#region Micro Namespaces
using Micro.Objects.HumanResource;
using Micro.Commons;
#endregion

namespace Micro.DataAccessLayer.HumanResource
{
    public class DesignationDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DesignationDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DesignationDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DesignationDataAccess();
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

        public int InsertDesignation(Designation Desg)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@DesignationDescription", SqlDbType.VarChar, Desg.DesignationDescription));
                SqlCmd.Parameters.Add(GetParameter("@RoleId", SqlDbType.Int, Desg.RoleID));
                SqlCmd.Parameters.Add(GetParameter("@ReportingToDesignationID", SqlDbType.Int, Desg.ReportingToDesignationID));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_Designation_Insert";

                ExecuteStoredProcedure(SqlCmd);

                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateDesignation(Designation Desg)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@DesignationID", SqlDbType.Int, Desg.DesignationID));
                SqlCmd.Parameters.Add(GetParameter("@DesignationDescription", SqlDbType.VarChar, Desg.DesignationDescription));
                SqlCmd.Parameters.Add(GetParameter("@RoleId", SqlDbType.Int, Desg.RoleID));
                SqlCmd.Parameters.Add(GetParameter("@ReportingToDesignationID", SqlDbType.Int, Desg.ReportingToDesignationID));
				//SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Int, Desg.IsActive));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
				SqlCmd.CommandText = "pHRM_Designations_Update";

                ExecuteStoredProcedure(SqlCmd);

                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteDesignation(int DesignationID)
        {
            try
            {
                int ReturnValue = 0;
				
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@DesignationId", SqlDbType.Int, DesignationID));
				SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_Designation_Delete";

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

        public DataTable GetDesignationsAll(string searchText=null, bool showDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                //SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                //SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pHRM_Designation_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetDesignationsAllByOffice(int OfficeID = -1, string searchText=null, bool showDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int,
                    (OfficeID == -1 ? Micro.Commons.Connection.LoggedOnUser.OfficeID : OfficeID)));
                SelectCommand.CommandText = "pHRM_DesignationsOfficewise_SelectByOfficeID";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetDesignationByDesignationID(int DesignationID)
        {
            try
            {
                SqlCommand GetbyIdCmd = new SqlCommand();
                GetbyIdCmd.CommandType = CommandType.StoredProcedure;

                GetbyIdCmd.Parameters.Add(GetParameter("@DesignationId", SqlDbType.Int, DesignationID));
                GetbyIdCmd.CommandText = "pHRM_Designation_SelectByID";

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
