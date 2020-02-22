#region System Namespaces
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
    public class DepartmentOfficewiseDataAccess:AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DepartmentOfficewiseDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DepartmentOfficewiseDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DepartmentOfficewiseDataAccess();
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

        public int InsertDepartmentOfficewise(DepartmentOfficewise _DepartmentOfficewise)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, _DepartmentOfficewise.DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_DepartmentsOfficewise_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public int UpdateDepartmentOfficewise(DepartmentOfficewise _DepartmentOfficewise)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("DepartmentOfficewiseID", SqlDbType.Int, _DepartmentOfficewise.DepartmentOfficewiseID));
                SqlCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, _DepartmentOfficewise.DEPARTMENT.DepartmentID));
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
               

                if (_DepartmentOfficewise.IsActive == true)
                {
                    SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, 1));
                }
                else
                {
                    SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, 0));
                }

                SqlCmd.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime, DateTime.Now));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_DepartmentsOfficewise_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public int DeleteDepartmentOfficewise(int DepartmentOfficewiseID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand DeleteCommand = new SqlCommand();

                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@DepartmentOfficewiseID", SqlDbType.Int, DepartmentOfficewiseID));
                DeleteCommand.CommandText = "pHRM_DepartmentsOfficewise_Delete";

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

        public DataRow GetDepartmentOfficewiseByDepartmentOfficewiseID(int DepartmentOfficewiseID)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();

                SelectCmd.CommandType = CommandType.StoredProcedure;
                SelectCmd.Parameters.Add(GetParameter("@DepartmentOfficewiseID", SqlDbType.Int, DepartmentOfficewiseID));
                SelectCmd.CommandText = "pHRM_DepartmentsOfficewise_SelectByDepartmentID";

                return ExecuteGetDataRow(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetDepartmentOfficewiseByOffice(int  OfficeID = -1)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();

                SelectCmd.CommandType = CommandType.StoredProcedure;
                SelectCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int,
                                             (OfficeID == -1 ? Micro.Commons.Connection.LoggedOnUser.OfficeID : OfficeID)));
                SelectCmd.CommandText = "pHRM_DepartmentsOfficewise_SelectByOfficeID";

                return ExecuteGetDataTable(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetDepartmentOfficewiseByDepartment(int DepartmentID, int CompanyID=-1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();

                SelectCmd.CommandType = CommandType.StoredProcedure;
                SelectCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int,
                    (CompanyID == -1 ? Micro.Commons.Connection.LoggedOnUser.CompanyID : CompanyID)));
                SelectCmd.Parameters.Add(GetParameter("@DepartmentID", SqlDbType.Int, DepartmentID));
                //SelectCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                //SelectCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCmd.CommandText = "pHRM_DepartmentsOfficewise_SelectByOfficeIDAndDepartmentID";

                return ExecuteGetDataTable(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
    }
}
