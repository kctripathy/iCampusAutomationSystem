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
    public partial class EmployeeServiceDetailsDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static EmployeeServiceDetailsDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EmployeeServiceDetailsDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EmployeeServiceDetailsDataAccess();
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

        public int InsertEmployeeServiceDetails(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {

                int ReturnValue = 0;
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("EmployeeID", SqlDbType.Int, _EmployeeServiceDetails.Employee.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("PostingDate", SqlDbType.DateTime, _EmployeeServiceDetails.PostingDate));
                SqlCmd.Parameters.Add(GetParameter("PostingOfficeID", SqlDbType.Int, _EmployeeServiceDetails.PostingOffice.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("DesignationID", SqlDbType.Int, _EmployeeServiceDetails.Designation.DesignationID));
                SqlCmd.Parameters.Add(GetParameter("DepartmentID", SqlDbType.Int, _EmployeeServiceDetails.Deparment.DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("ServiceType", SqlDbType.VarChar, _EmployeeServiceDetails.ServiceType));
                SqlCmd.Parameters.Add(GetParameter("ServiceStatus", SqlDbType.VarChar, _EmployeeServiceDetails.ServiceStatus));
                SqlCmd.Parameters.Add(GetParameter("ReferenceLetterNumber", SqlDbType.VarChar, _EmployeeServiceDetails.ReferenceLetterNumber));
                SqlCmd.Parameters.Add(GetParameter("Remarks", SqlDbType.VarChar, _EmployeeServiceDetails.Remarks));

                if (_EmployeeServiceDetails.ReportingToEmployee.EmployeeID > -1)
                {
                    SqlCmd.Parameters.Add(GetParameter("ReportingToEmployeeID", SqlDbType.Int, _EmployeeServiceDetails.ReportingToEmployee.EmployeeID));
                    //SqlCmd.Parameters.Add(GetParameter("ReportingToEffectiveDateFrom", SqlDbType.Date, _EmployeeServiceDetails.ReportingToEffectiveDateFrom));
                    SqlCmd.Parameters.Add(GetParameter("ReportingToEffectiveDateFrom", SqlDbType.Date, DateTime.Today));
                }

                SqlCmd.Parameters.Add(GetParameter("AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_EmployeeServiceDetails_Insert";
                ExecuteStoredProcedure(SqlCmd);

                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateEmployeeServiceDetails(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {
                int ReturnValue = 0;
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("EmployeeServiceDetailsID", SqlDbType.Int, _EmployeeServiceDetails.EmployeeServiceDetailsID));

                SqlCmd.Parameters.Add(GetParameter("EmployeeID", SqlDbType.Int, _EmployeeServiceDetails.Employee.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("PostingDate", SqlDbType.DateTime, DateTime.Parse(_EmployeeServiceDetails.PostingDate.ToString()).ToString("yyyy/MM/dd")));
                SqlCmd.Parameters.Add(GetParameter("PostingOfficeID", SqlDbType.Int, _EmployeeServiceDetails.PostingOffice.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("DesignationID", SqlDbType.Int, _EmployeeServiceDetails.Designation.DesignationID));
                SqlCmd.Parameters.Add(GetParameter("DepartmentID", SqlDbType.Int, _EmployeeServiceDetails.Deparment.DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("ServiceType", SqlDbType.VarChar, _EmployeeServiceDetails.ServiceType));
                
                SqlCmd.Parameters.Add(GetParameter("ServiceStatusChangeRequestDate", SqlDbType.DateTime, DateTime.Parse(_EmployeeServiceDetails.ServiceStatusChangeRequestDate.ToString()).ToString("yyyy/MM/dd")));
                SqlCmd.Parameters.Add(GetParameter("ServiceStatusLastWorkingDate", SqlDbType.DateTime, DateTime.Parse(_EmployeeServiceDetails.ServiceStatusLastWorkingDate.ToString()).ToString("yyyy/MM/dd")));
                
                SqlCmd.Parameters.Add(GetParameter("ServiceStatus", SqlDbType.VarChar, _EmployeeServiceDetails.ServiceStatus));
                SqlCmd.Parameters.Add(GetParameter("ReferenceLetterNumber", SqlDbType.VarChar, _EmployeeServiceDetails.ReferenceLetterNumber));
                SqlCmd.Parameters.Add(GetParameter("Remarks", SqlDbType.VarChar, _EmployeeServiceDetails.Remarks));

                if (_EmployeeServiceDetails.ReportingToEmployee.EmployeeID > -1)
                {
                    SqlCmd.Parameters.Add(GetParameter("ReportingToEmployeeID", SqlDbType.Int, _EmployeeServiceDetails.ReportingToEmployee.EmployeeID));
                    //SqlCmd.Parameters.Add(GetParameter("ReportingToEffectiveDateFrom", SqlDbType.Date, _EmployeeServiceDetails.ReportingToEffectiveDateFrom));
                    SqlCmd.Parameters.Add(GetParameter("ReportingToEffectiveDateFrom", SqlDbType.Date, DateTime.Today));
                }

                SqlCmd.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_EmployeeServiceDetails_Update";
                ExecuteStoredProcedure(SqlCmd);

                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteEmployeeServiceDetails(EmployeeServiceDetails _EmployeeServiceDetails)
        {
            try
            {
                int ReturnValue = 0;
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("EmployeeServiceDetailsID", SqlDbType.Int, _EmployeeServiceDetails.EmployeeServiceDetailsID));
                SqlCmd.Parameters.Add(GetParameter("ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_EmployeeServiceDetails_Delete";
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

        public DataTable GetEmployeeSeviceDetailsAll(string searchText, bool showDeleted = false)
        {
            try
            {
            DataTable EmployeeList = new DataTable();
            SqlCommand SqlCmd = new SqlCommand();

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
            SqlCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
            SqlCmd.CommandText = "pHRM_EmployeeServiceDetails_SelectAll";
            EmployeeList = ExecuteGetDataTable(SqlCmd);

            return EmployeeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetEmployeeSeviceDetailsByEmployee(int EmployeeID)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                SqlCmd.CommandText = "pHRM_EmployeeServiceDetails_SelectByEmployeeID";

                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetEmployeeListByReportingToEmployee(int EmployeeID)
        {
            try
            {
            DataTable EmployeeList = new DataTable();
            SqlCommand SqlCmd = new SqlCommand();

            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
            SqlCmd.CommandText = "pHRM_EmployeeServiceDetails_SelectReportingEmployeeDetailsByEmployeeID";
            EmployeeList = ExecuteGetDataTable(SqlCmd);

            return EmployeeList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
