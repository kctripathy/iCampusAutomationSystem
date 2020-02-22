using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

using Micro.Objects.Administration;


namespace Micro.DataAccessLayer.Administration
{
    public class OfficeGroupsDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static OfficeGroupsDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static OfficeGroupsDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OfficeGroupsDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        #endregion

        #region Office Groups

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertOfficeGroup(OfficeGroup OfficeGroup)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupName", SqlDbType.VarChar, OfficeGroup.OfficeGroupName));
                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupDescription", SqlDbType.VarChar, OfficeGroup.OfficeGroupDescription));
                sqlCmd.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                sqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                sqlCmd.CommandText = "pADM_OfficeGroups_Insert";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateOfficeGroup(OfficeGroup OfficeGroup)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupID", SqlDbType.Int, OfficeGroup.OfficeGroupID));
                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupName", SqlDbType.VarChar, OfficeGroup.OfficeGroupName));
                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupDescription", SqlDbType.VarChar, OfficeGroup.OfficeGroupDescription));
                sqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                sqlCmd.CommandText = "pADM_OfficeGroups_Update";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteOfficeGroup(int OfficeGroupID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupID", SqlDbType.Int, OfficeGroupID));

                sqlCmd.CommandText = "pADM_OfficeGroups_Delete";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion
        #region Data Retrive Mathods

        public DataTable GetOfficeGroupsAll(bool ShowDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, ShowDeleted));

                SelectCommand.CommandText = "pADM_OfficeGroups_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficeGroupList(bool ShowDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, ShowDeleted));

                SelectCommand.CommandText = "pADM_OfficeGroups_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetOfficeGroupsByOfficeGroupID(int OfficeGroupID)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();
                SelectCmd.CommandType = CommandType.StoredProcedure;

                SelectCmd.Parameters.Add(GetParameter("@OfficeGroupID", SqlDbType.Int, OfficeGroupID));

                SelectCmd.CommandText = "pADM_OfficeGroups_SelectByOfficeGroupID";

                return ExecuteGetDataRow(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficeGroupsByCompanyID(int CompanyID = -1)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();
                SelectCmd.CommandType = CommandType.StoredProcedure;


                SelectCmd.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, (CompanyID == -1 ? Micro.Commons.Connection.LoggedOnUser.CompanyID : CompanyID)));

                SelectCmd.CommandText = "pADM_OfficeGroups_SelectByCompanyID";

                return ExecuteGetDataTable(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #endregion

        #region Office Group Templates

        #region Transactional Mathods(Insert,Update,Delete)
       
        public int InsertOfficeGroupTemplate( OfficeGroupTemplate groupOffices)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupID", SqlDbType.Int, groupOffices.OfficeGroupID));
                sqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, groupOffices.office.OfficeID));
                sqlCmd.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.DateTime, groupOffices.EffectiveDateFrom));
                sqlCmd.Parameters.Add(GetParameter("@EffectiveDateTo", SqlDbType.DateTime, groupOffices.EffectiveDateTo));
                sqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                sqlCmd.CommandText = "pADM_OfficeGroupTemplates_Insert";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateOfficeGroupTemplate(OfficeGroupTemplate groupOffices)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupTemplateID", SqlDbType.VarChar, groupOffices.OfficeGroupTemplateID));
                sqlCmd.Parameters.Add(GetParameter("@OfficeID", SqlDbType.VarChar, groupOffices.office.OfficeID));
                sqlCmd.Parameters.Add(GetParameter("@EffectiveDateFrom", SqlDbType.DateTime, groupOffices.EffectiveDateFrom));
                sqlCmd.Parameters.Add(GetParameter("@EffectiveDateTo", SqlDbType.DateTime, groupOffices.EffectiveDateTo));
                sqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                sqlCmd.CommandText = "pADM_OfficeGroupTemplates_Update";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteOfficeGroupTemplate(int OfficeGroupTemplateID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeGroupTemplateID", SqlDbType.VarChar, OfficeGroupTemplateID));
                sqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                sqlCmd.CommandText = "pADM_OfficeGroupTemplates_Delete";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Data Retrive Mathods
        /// <summary>
        /// Office Group Templates
        /// 
        /// </summary>
        /// <param name="OfficeGroupID"></param>
        /// <returns></returns>
        public DataTable GetOfficeGroupTemplatesByOfficeGroupID(int OfficeGroupID)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@OfficeGroupID", SqlDbType.Int, OfficeGroupID));

                SelectCommand.CommandText = "pADM_OfficeGroupTemplates_SelectByOfficeGroupID";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetOfficeGroupTemplateByOfficeGroupTemplateID(int OfficeGroupTemplateID)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@OfficeGroupTemplateID", SqlDbType.Int, OfficeGroupTemplateID));

                SelectCommand.CommandText = "pADM_OfficeGroupTemplates_SelectByOfficeGroupTemplateID";

                return ExecuteGetDataRow(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

#endregion
#endregion
    }
}
