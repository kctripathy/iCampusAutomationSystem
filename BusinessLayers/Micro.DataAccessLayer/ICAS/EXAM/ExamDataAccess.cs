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
    public partial class ExamDataAccess:AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static ExamDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ExamDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExamDataAccess();
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

        public DataTable GetExamsAll()
        {
            try
            {
                SqlCommand GetExamcommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "iCAS_Examintation_SelectAll" };

                return ExecuteGetDataTable(GetExamcommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int InsertExam(Exams TheExam)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@ExamName",SqlDbType.VarChar,TheExam.ExamName));
                InsertCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, TheExam.SessionID));
                InsertCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, TheExam.QualID));
                InsertCommand.Parameters.Add(GetParameter("@DateOfStart", SqlDbType.DateTime, TheExam.DateOfStart));
                InsertCommand.Parameters.Add(GetParameter("@DateOfClose", SqlDbType.DateTime, TheExam.DateOfClose));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, TheExam.AddedBy));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, TheExam.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, TheExam.CompanyID));
                InsertCommand.CommandText = "pICAS_Exam_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
 
            }
            return ReturnValue;
        }
        public int UpdateExam(Exams TheExam)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                //UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.CommandText = "pICAS_Exam_Update";
                UpdateCommand.Parameters.Add(GetParameter("@ExamID", SqlDbType.Int, TheExam.ExamID));
                UpdateCommand.Parameters.Add(GetParameter("@ExamName", SqlDbType.VarChar, TheExam.ExamName));
                UpdateCommand.Parameters.Add(GetParameter("@SessionID", SqlDbType.Int, TheExam.SessionID));
                UpdateCommand.Parameters.Add(GetParameter("@QualID", SqlDbType.Int, TheExam.QualID));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfStart", SqlDbType.DateTime, TheExam.DateOfStart));
                UpdateCommand.Parameters.Add(GetParameter("@DateOfClose", SqlDbType.DateTime, TheExam.DateOfClose));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, TheExam.ModifiedBy));
                UpdateCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, TheExam.OfficeID));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, TheExam.CompanyID));
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
 
            }
            return ReturnValue;
        }
        public int DeleteExam(Exams TheExam)
        {
            int ReturnValue = 0;
            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                //DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@ExamID", SqlDbType.Int, TheExam.ExamID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, TheExam.ModifiedBy));
                DeleteCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, TheExam.OfficeID));
                DeleteCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, TheExam.CompanyID));
                DeleteCommand.CommandText = "pICAS_Exam_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());                
            }
            return ReturnValue;
        }
        #endregion
    }
}
