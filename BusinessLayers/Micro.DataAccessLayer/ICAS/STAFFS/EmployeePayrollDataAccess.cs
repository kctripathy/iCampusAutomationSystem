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
    public class EmployeePayrollDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static EmployeePayrollDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static EmployeePayrollDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EmployeePayrollDataAccess();
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
        
        #endregion

        #region Data Retrive Mathods

        public DataTable GetEmployeePayrollList(string SearchText = "", bool showDeleted = false)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@MonthName", SqlDbType.VarChar, SearchText));
                SelectCommand.Parameters.Add(GetParameter("@YearName", SqlDbType.Bit, showDeleted));
                //TODO
                // SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
                SelectCommand.CommandText = "pICAS_HR_PayRollGenerate";

                return ExecuteGetDataTable(SelectCommand);
            }
        }        
        #endregion
    }
}
