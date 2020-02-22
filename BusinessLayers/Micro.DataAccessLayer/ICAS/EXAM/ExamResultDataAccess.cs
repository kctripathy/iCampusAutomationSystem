using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using Micro.Objects.ICAS.EXAM;

namespace Micro.DataAccessLayer.ICAS.EXAM
{
    public partial class ExamResultDataAccess : AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static ExamResultDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ExamResultDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExamResultDataAccess();
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

        public DataTable GetExamsResultList(ExamResult ResultObject)
        {
            try
            {
                SqlCommand GetExamcommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "iCAS_Exam_Result_ByExamID_And_StID" };
                GetExamcommand.Parameters.AddWithValue("@ExamID", ResultObject.ExamID);
                GetExamcommand.Parameters.AddWithValue("@StudentID", ResultObject.StudentCode);
                return ExecuteGetDataTable(GetExamcommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }        
        #endregion
    }
}
