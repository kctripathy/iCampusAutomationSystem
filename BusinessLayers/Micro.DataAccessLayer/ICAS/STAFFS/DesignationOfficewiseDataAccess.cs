using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using Micro.Objects.ICAS.STAFFS;
using System.Data;

namespace Micro.DataAccessLayer.ICAS.STAFFS
{
   public partial class DesignationOfficewiseDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DesignationOfficewiseDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DesignationOfficewiseDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DesignationOfficewiseDataAccess();
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

        //public int InsertDesignationOfficewise( string DesignationIds)
        //{
        //    try
        //    {
        //        int ReturnValue = 0;

        //        SqlCommand SqlCmd = new SqlCommand();

        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
        //        SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
        //        SqlCmd.Parameters.Add(GetParameter("@DesignationIDs", SqlDbType.VarChar, DesignationIds));
        //        SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

        //        SqlCmd.CommandText = "pHRM_DesignationsOfficewise_Insert";

        //        ExecuteStoredProcedure(SqlCmd);
        //        ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

        //        return ReturnValue;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
        //    }

        //}
        public int InsertDesignationOfficewise(DesignationOfficewise _DesignationOfficewise)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SqlCmd.Parameters.Add(GetParameter("@DesignationID", SqlDbType.Int, _DesignationOfficewise.DesignationID));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                SqlCmd.CommandText = "pHRM_DesignationsOfficewise_Insert";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public int UpdateDesignationOfficewise(DesignationOfficewise _DesignationOfficewise)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(GetParameter("DesignationOfficewiseID", SqlDbType.Int, _DesignationOfficewise.DesignationOfficewiseID));
                SqlCmd.Parameters.Add(GetParameter("@DesignationID", SqlDbType.Int, _DesignationOfficewise.DESIGNATION.DesignationID));
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                if (_DesignationOfficewise.IsActive == true)
                {
                    SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, 1));
                }
                else
                {
                    SqlCmd.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, 0));
                }
                SqlCmd.Parameters.Add(GetParameter("@DateModified", SqlDbType.DateTime, DateTime.Now));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                SqlCmd.CommandText = "pHRM_DesignationsOfficewise_Update";

                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString());

                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

        public int DeleteDesignationOfficewise(int DesignationOfficewiseID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand DeleteCommand = new SqlCommand();

                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@DesignationOfficewiseID", SqlDbType.Int, DesignationOfficewiseID));
                DeleteCommand.CommandText = "pHRM_DesignationsOfficewise_Delete";

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

        public DataRow GetDesignationOfficewiseByDesignationOfficewiseID(int DesignationOfficewiseID)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@DesignationOfficewiseID", SqlDbType.Int, DesignationOfficewiseID));
                SelectCommand.CommandText = "pHRM_DesignationsOfficewise_SelectByDesignationID";

                return ExecuteGetDataRow(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetDesignationOfficewiseByOffice(int OfficeID = -1)
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

        public DataTable GetDesignationOfficewiseByDeparment(int DesignationID, int CompanyID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int,
                    (CompanyID == -1 ? Micro.Commons.Connection.LoggedOnUser.CompanyID : CompanyID)));
                SqlCmd.Parameters.Add(GetParameter("@DesignationID", SqlDbType.Int, DesignationID));
                SqlCmd.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SqlCmd.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SqlCmd.CommandText = "pHRM_DesignationsOfficewise_SelectByOfficeIDAndDesignationID";

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
