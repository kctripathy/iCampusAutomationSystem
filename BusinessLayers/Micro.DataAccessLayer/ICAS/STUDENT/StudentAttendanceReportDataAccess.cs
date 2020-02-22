using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using Micro.Objects.ICAS.STUDENT;

namespace Micro.DataAccessLayer.ICAS.STUDENT
{
    public partial class StudentAttendanceReportDataAccess : AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static StudentAttendanceReportDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentAttendanceReportDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentAttendanceReportDataAccess();
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

        #region Methods & Implementation

        public DataTable GetPresentAttnsListByDate(String SearchText)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
                SelectCommand.CommandText = "pICAS_Student_AttendanceReport_Present";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
        public DataTable GetAbsentAttnsListByDate(String SearchText)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
                SelectCommand.CommandText = "pICAS_Student_AttendanceReport_Abscent";
                return ExecuteGetDataTable(SelectCommand);
            }
        }                
    }
}
        #endregion