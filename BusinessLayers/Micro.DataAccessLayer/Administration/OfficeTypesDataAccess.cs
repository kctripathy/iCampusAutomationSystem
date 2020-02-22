using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

using Micro.Objects.Administration;


namespace Micro.DataAccessLayer.Administration
{
    public class OfficeTypesDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        /// 
        private static OfficeTypesDataAccess _Instance;

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        /// 
        public static OfficeTypesDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OfficeTypesDataAccess();
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

        public int InsertOfficeType(OfficeType officeType)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeName", SqlDbType.VarChar, officeType.OfficeTypeName));
                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeDescription", SqlDbType.VarChar, officeType.OfficeTypeDescription));
                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeAbbreviation", SqlDbType.VarChar, officeType.OfficeTypeAbbreviation));

                if (officeType.ParentOfficeTypeID > 0)
                {
                    sqlCmd.Parameters.Add(GetParameter("@ParentOfficeTypeID", SqlDbType.Int, officeType.ParentOfficeTypeID));
                }
                sqlCmd.Parameters.Add(GetParameter("@HierarchyIndex", SqlDbType.Int, officeType.HierarchyIndex));

                sqlCmd.Parameters.Add(GetParameter("@ComapnyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                sqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                sqlCmd.CommandText = "pADM_OfficeTypes_Insert";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateOfficeType(OfficeType officeType)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.Int, officeType.OfficeTypeID));
                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeName", SqlDbType.VarChar, officeType.OfficeTypeName));
                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeDescription", SqlDbType.VarChar, officeType.OfficeTypeDescription));
                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeAbbreviation", SqlDbType.VarChar, officeType.OfficeTypeAbbreviation));

                if (officeType.ParentOfficeTypeID > 0)
                {
                    sqlCmd.Parameters.Add(GetParameter("@ParentOfficeTypeID", SqlDbType.Int, officeType.ParentOfficeTypeID));
                }

                sqlCmd.Parameters.Add(GetParameter("@HierarchyIndex", SqlDbType.Int, officeType.HierarchyIndex));

                //sqlCmd.Parameters.Add(GetParameter("@ComapnyID", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.CompanyID));
                sqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                sqlCmd.CommandText = "pADM_OfficeTypes_Update";

                ExecuteStoredProcedure(sqlCmd);

                return int.Parse(sqlCmd.Parameters[0].Value.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteOfficeType(int OfficeTypeID)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                sqlCmd.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.Int, OfficeTypeID));

                sqlCmd.CommandText = "pADM_OfficeTypes_Delete";

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

        public DataTable GetOfficeTypesAll(bool ShowDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, ShowDeleted));

                SelectCommand.CommandText = "pADM_OfficeTypes_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficeTypeList(bool ShowDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;

                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, ShowDeleted));

                SelectCommand.CommandText = "pADM_OfficeTypes_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficeTypeListByUserID(int userID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@UserID", SqlDbType.Int, userID));
                SelectCommand.CommandText = "pADM_OfficeTypes_SelectByUserID";
                return ExecuteGetDataTable(SelectCommand);
            }
        }

        public DataRow GetOfficeTypesByOfficeTypeID(int OfficeTypeID)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();
                SelectCmd.CommandType = CommandType.StoredProcedure;

                SelectCmd.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.Int, OfficeTypeID));

                SelectCmd.CommandText = "pADM_OfficeTypes_SelectByOfficeTypeID";

                return ExecuteGetDataRow(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataRow GetOfficeTypesByAbbreviation(string OfficeTypeAbbreviation)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();
                SelectCmd.CommandType = CommandType.StoredProcedure;

                SelectCmd.Parameters.Add(GetParameter("@OfficeTypeID", SqlDbType.VarChar, OfficeTypeAbbreviation));

                SelectCmd.CommandText = "pADM_OfficeTypes_SelectByOfficeTypeAbbreviation";

                return ExecuteGetDataRow(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficeTypesByHierarchyIndex(int HierarchyIndex)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();
                SelectCmd.CommandType = CommandType.StoredProcedure;

                SelectCmd.Parameters.Add(GetParameter("@HierarchyIndex", SqlDbType.Int, HierarchyIndex));

                SelectCmd.CommandText = "pADM_OfficeTypes_SelectByHierarchyIndex";

                return ExecuteGetDataTable(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficeTypesByParentOfficeTypeID(int ParentOfficeTypeID)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();
                SelectCmd.CommandType = CommandType.StoredProcedure;

                SelectCmd.Parameters.Add(GetParameter("@ParentOfficeTypeID", SqlDbType.Int, ParentOfficeTypeID));

                SelectCmd.CommandText = "pADM_OfficeTypes_SelectByParentOfficeTypeID";

                return ExecuteGetDataTable(SelectCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetOfficeTypesByCompanyID(int CompanyID = -1)
        {
            try
            {
                SqlCommand SelectCmd = new SqlCommand();
                SelectCmd.CommandType = CommandType.StoredProcedure;


                SelectCmd.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, (CompanyID == -1 ? Micro.Commons.Connection.LoggedOnUser.UserID : CompanyID)));

                SelectCmd.CommandText = "pADM_OfficeTypes_SelectByCompanyID";

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
