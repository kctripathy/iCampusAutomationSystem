using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using System.Reflection;
using Micro.Objects.ICAS.EXAM;
using Micro.DataAccessLayer.ICAS.EXAM;


namespace Micro.IntegrationLayer.ICAS.EXAM
{
    public partial class ExamMarkIntegration
    {
        #region Declaration
        #endregion

        public static List<ExamMark> GetExamsMarkList()
        {
            try
            {
                return ConvertDatarowToObject(ExamMarkDataAccess.GetInstance.GetExamsMarksAll());
            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
            }
        }
        private static List<ExamMark> ConvertDatarowToObject(DataTable ExamListTable)
        {            
            List<ExamMark> ExamList = new List<ExamMark>();
            foreach (DataRow dr in ExamListTable.Rows)
            {
                ExamMark theExamMark = new ExamMark();
                theExamMark.Exam_Mark_ScheduleID = int.Parse(dr["Exam_Mark_ScheduleID"].ToString());
                theExamMark.ExamScheduleID = int.Parse(dr["ExamScheduleID"].ToString());                
                theExamMark.StudentID = dr["StudentID"].ToString();
                theExamMark.MarksObtained = int.Parse(dr["MarksObtained"].ToString());
                theExamMark.VarifiedBy = dr["VarifiedBy"].ToString();
                theExamMark.IsActive = bool.Parse(dr["IsActive"].ToString());
                //theExamMark.ModifiedBy = int.Parse(dr["ModifiedBy"].ToString());
                //theExamMark.DateModified = dr["DateModified"].ToString();
                theExamMark.AddedBy = int.Parse(dr["AddedBy"].ToString());
                theExamMark.OfficeID = (string.IsNullOrEmpty(dr["OfficeID"].ToString()) ? 0 : int.Parse(dr["OfficeID"].ToString()));
                theExamMark.CompanyID = (string.IsNullOrEmpty(dr["CompanyID"].ToString()) ? 0 : int.Parse(dr["CompanyID"].ToString()));
                ExamList.Add(theExamMark);
            }

            return ExamList;

        }
        public static int InsertExamMark(ExamMark theExamMark)
        {
            return ExamMarkDataAccess.GetInstance.InsertExamMarks(theExamMark);
        }
        public static int UpdateExamMark(ExamMark theExamMark)
        {
            return ExamMarkDataAccess.GetInstance.UpdateExamMarks(theExamMark);
        }
        public static int DeleteExamMark(ExamMark theExamMark)
        {
            return ExamMarkDataAccess.GetInstance.DeleteExamMarks(theExamMark);
        }
    }
}
