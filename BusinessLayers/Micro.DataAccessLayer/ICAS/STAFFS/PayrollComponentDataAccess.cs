using System;
using System.Collections.Generic;
using System.Linq;
using Micro.Objects.ICAS.STAFFS;
using System.Text;
using System.Data;
using System.Reflection;
using System.Configuration;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.ICAS.STAFFS
{
    public class PayrollComponentDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PayrollComponentDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PayrollComponentDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PayrollComponentDataAccess();
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
        void sbc_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            //MessageBox.Show("Number of records affected : " + e.RowsCopied.ToString());
        }
        public int InsertEmployeeComponent(DataTable dt,EmpPayrollcomponent TheComponent)
        {            
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICAS_DEV"].ConnectionString);
                using (SqlBulkCopy sbc = new SqlBulkCopy(con))
                {
                    sbc.DestinationTableName = "HRMS_MST_EmployeesPayComponents";
                    // Number of records to be processed in one go
                    sbc.BatchSize = 5;
                    // Map the Source Column from DataTabel to the Destination Columns in SQL Server 2005 Person Table
                    sbc.ColumnMappings.Add("EmployeeID", "EmployeeID");
                    sbc.ColumnMappings.Add("PayComponentID", "PayComponentID");
                    sbc.ColumnMappings.Add("ComponentValue", "PayAmount");
                    sbc.ColumnMappings.Add("SessionID", "SessionID");
                    sbc.ColumnMappings.Add("AddedBy", "AddedBy");                    
                    // Number of records after which client has to be notified about its status
                    sbc.NotifyAfter = dt.Rows.Count;
                    // Event that gets fired when NotifyAfter number of records are processed.
                    sbc.SqlRowsCopied += new SqlRowsCopiedEventHandler(sbc_SqlRowsCopied);
                    // Finally write to server
                    con.Close();
                    con.Open();
                    sbc.WriteToServer(dt);
                    sbc.Close();
                    con.Close();
                }

                int ReturnValue = 0;

                //SqlCommand SqlCmd = new SqlCommand();
                //SqlCmd.CommandType = CommandType.StoredProcedure;
                ////SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                //SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.VarChar, dt.Columns[0].ColumnName));                
                //SqlCmd.Parameters.Add(GetParameter("@PayComponentID",SqlDbType.VarChar, dt.Columns[1].ColumnName));
                //SqlCmd.Parameters.Add(GetParameter("@PayAmount", SqlDbType.VarChar, dt.Columns[3].ColumnName));
                //SqlCmd.Parameters.Add(GetParameter("@SessionID", SqlDbType.VarChar, dt.Columns[5].ColumnName));
                ////SqlCmd.Parameters.Add(GetParameter("@ReportingToDesignationID", SqlDbType.Int, dt.Columns[2].ColumnName));
                //SqlCmd.Parameters.Add(GetParameter("@AddedBy",SqlDbType.VarChar,dt.Columns[6].ColumnName));
                //SqlCmd.CommandText = "pHRMS_MST_EmployeePayComponents_Insert";
                //SqlDataAdapter adpt = new SqlDataAdapter();
                //adpt.InsertCommand = SqlCmd;
                //// Specify the number of records to be Inserted/Updated in one go. Default is 1.
                //adpt.UpdateBatchSize = 5;
                //ReturnValue = adpt.Update(dt);                               
                ////ExecuteStoredProcedure(SqlCmd);

                ReturnValue = 1;
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int InsertSingleEmployeeComponent(EmpPayrollcomponent TheComponent)
        {
            try
            {                
                int ReturnValue = 0;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, TheComponent.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@PayComponentID", SqlDbType.Int, TheComponent.PayComponentID));
                SqlCmd.Parameters.Add(GetParameter("@PayComponentValue", SqlDbType.VarChar, TheComponent.PayComponentAmount));
                SqlCmd.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int,TheComponent.SessionID));
                //SqlCmd.Parameters.Add(GetParameter("@ReportingToDesignationID", SqlDbType.Int, dt.Columns[2].ColumnName));
                SqlCmd.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, TheComponent.AddedBy));
                SqlCmd.CommandText = "pHRMS_MST_EmployeePayComponents_Insert";              
                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString()); ;
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int UpdateSingleEmployeeComponent(EmpPayrollcomponent TheComponent)
        {
            try
            {
                int ReturnValue = 0;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@RecordNumber", SqlDbType.Int, TheComponent.RecordNo));
                SqlCmd.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, TheComponent.EmployeeID));
                SqlCmd.Parameters.Add(GetParameter("@PayComponentID", SqlDbType.Int, TheComponent.PayComponentID));
                SqlCmd.Parameters.Add(GetParameter("@PayComponentValue", SqlDbType.VarChar, TheComponent.PayComponentAmount));
                SqlCmd.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, TheComponent.SessionID));
                //SqlCmd.Parameters.Add(GetParameter("@ReportingToDesignationID", SqlDbType.Int, dt.Columns[2].ColumnName));
                SqlCmd.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, TheComponent.AddedBy));
                SqlCmd.CommandText = "pHRMS_MST_EmployeePayComponents_Update";
                ExecuteStoredProcedure(SqlCmd);
                ReturnValue = int.Parse(SqlCmd.Parameters[0].Value.ToString()); ;
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int DeleteSingleEmployeeComponent(EmpPayrollcomponent TheComponent)
        {
            try
            {
                int ReturnValue = 0;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //SqlCmd.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(GetParameter("@RecordNumber", SqlDbType.Int, TheComponent.RecordNo));               
                SqlCmd.CommandText = "pHRMS_MST_EmployeePayComponents_Delete";
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

        public DataTable GetPayrollComponentList(string SearchText = "", bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                //TODO
                // SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pICAS_PayrollComponent_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetEmployeePayrollComponentList(int EmployeeID,string SearchText = "", bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.Parameters.Add(GetParameter("@EmployeeID", SqlDbType.Int, EmployeeID));
                //TODO
                // SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pHRMS_MST_Employees_PayrollComponent_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        #endregion
    }
}
