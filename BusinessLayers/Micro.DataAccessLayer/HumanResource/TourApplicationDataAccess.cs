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
    public class TourApplicationDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static TourApplicationDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static TourApplicationDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TourApplicationDataAccess();
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

        public int InsertTourApplication(TourApplication _TourApplication)
        {
            try
            {

                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, _TourApplication.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, _TourApplication.DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, _TourApplication.DateTo));
                SqlCmd.Parameters.Add(GetParameter("@TourPurpose", SqlDbType.VarChar, _TourApplication.TourPurpose));

                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_TourApplications_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;

            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateTourApplication(TourApplication _TourApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@TourApplicationID", SqlDbType.Int, _TourApplication.TourApplicationID));
                SqlCmd.Parameters.Add(GetParameter("@DateFrom", SqlDbType.DateTime, _TourApplication.DateFrom));
                SqlCmd.Parameters.Add(GetParameter("@DateTo", SqlDbType.DateTime, _TourApplication.DateTo));
                SqlCmd.Parameters.Add(GetParameter("@TourPurpose", SqlDbType.VarChar, _TourApplication.TourPurpose));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_TourApplications_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int ApproveOrRejectTourApplication(TourApplication _TourApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("@TourApplicationID", SqlDbType.Int, _TourApplication.TourApplicationID));

                SqlCmd.Parameters.Add(GetParameter("@Status", SqlDbType.VarChar, _TourApplication.Status));

                SqlCmd.Parameters.Add(GetParameter("@ApprovedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));


                SqlCmd.Parameters.Add(GetParameter("@ApprovalOrRejectionReason", SqlDbType.VarChar, _TourApplication.ApprovalOrRejectionReason));

                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_TourApplications_UpdateApprovalStatus";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public int DeleteTourApplication(TourApplication _TourApplication)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@TourApplicationID", SqlDbType.Int, _TourApplication.TourApplicationID));
                SqlCmd.CommandText = "pHRM_TourApplications_Delete";

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

        public DataTable GetTourApplicationsAll(string searchText, bool showDeleted = false)
        {

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SqlCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SqlCmd.CommandText = "pHRM_TourApplications_SelectAll";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetTourApplicationsByEmployee(int EmployeeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));

                SqlCmd.CommandText = "pHRM_TourApplications_SelectByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetPendingTourApplicationsByEmployee(int EmployeeID)
        {
            try
            {

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.CommandText = "pHRM_TourApplications_SelectPendingsByEmployee";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetPendingTourApplicationsAll()
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "pHRM_TourApplications_SelectAllPendings";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetTourApplicationByTourApplicationID(int TourApplicationID)
        {
            try
            {

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@TourApplicationID", SqlDbType.Int, TourApplicationID));

                SqlCmd.CommandText = "pHRM_TourApplications_SelectByTourApplicationID";

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
