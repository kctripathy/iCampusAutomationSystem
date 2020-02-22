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
    public partial class ExamMarkDataAccess:AbstractData_SQLClient
    {
        #region Code to Make This As singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static ExamMarkDataAccess _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ExamMarkDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExamMarkDataAccess();
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

        public DataTable GetExamsMarksAll()
        {
            try
            {
                SqlCommand GetExamMarkscommand = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = "iCAS_ExamMarks_SelectAll" };

                return ExecuteGetDataTable(GetExamMarkscommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int InsertExamMarks(ExamMark TheExamMark)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@ExamScheduleID", SqlDbType.Int, TheExamMark.ExamScheduleID));
                InsertCommand.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, TheExamMark.StudentID));
                InsertCommand.Parameters.Add(GetParameter("@VarifiedBy", SqlDbType.VarChar, TheExamMark.VarifiedBy));
                InsertCommand.Parameters.Add(GetParameter("@MarksObtained", SqlDbType.Int, TheExamMark.MarksObtained));              
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, TheExamMark.AddedBy));
                InsertCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, TheExamMark.OfficeID));
                InsertCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, TheExamMark.CompanyID));
                InsertCommand.CommandText = "pICAS_ExamMarks_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
 
            }
            return ReturnValue;
        }
        public int UpdateExamMarks(ExamMark TheExamMark)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateExamCommand = new SqlCommand())
            {
                UpdateExamCommand.CommandType = CommandType.StoredProcedure;
                //UpdateExamCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;                
                UpdateExamCommand.Parameters.Add(GetParameter("@Exam_Mark_ScheduleID", SqlDbType.Int, TheExamMark.Exam_Mark_ScheduleID));
                UpdateExamCommand.Parameters.Add(GetParameter("@ExamScheduleID", SqlDbType.Int, TheExamMark.ExamScheduleID));
                UpdateExamCommand.Parameters.Add(GetParameter("@StudentID", SqlDbType.Int, TheExamMark.StudentID));
                UpdateExamCommand.Parameters.Add(GetParameter("@MarksObtained", SqlDbType.Int, TheExamMark.MarksObtained));                                               
                UpdateExamCommand.Parameters.Add(GetParameter("@VarifiedBy", SqlDbType.VarChar, TheExamMark.VarifiedBy));
                UpdateExamCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, TheExamMark.AddedBy));
                UpdateExamCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, TheExamMark.OfficeID));
                UpdateExamCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, TheExamMark.CompanyID));
                UpdateExamCommand.CommandText = "pICAS_ExamMarks_Update";
                ExecuteStoredProcedure(UpdateExamCommand);
                ReturnValue = int.Parse(UpdateExamCommand.Parameters[0].Value.ToString());
 
            }
            return ReturnValue;
        }
        public int DeleteExamMarks(ExamMark TheExamMark)
        {
            int ReturnValue = 0;
            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                //DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@Exam_Mark_ScheduleID", SqlDbType.Int, TheExamMark.Exam_Mark_ScheduleID));
                DeleteCommand.Parameters.Add(GetParameter("@ExamScheduleID", SqlDbType.Int, TheExamMark.ExamScheduleID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, TheExamMark.ModifiedBy));
                DeleteCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, TheExamMark.OfficeID));
                DeleteCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, TheExamMark.CompanyID));
                DeleteCommand.CommandText = "pICAS_ExamMarks_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());                
            }
            return ReturnValue;
        }
        #endregion
    }
}
