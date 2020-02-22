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
    public partial class ExamResultIntegration
    {
        #region Declaration
        #endregion

        public static List<ExamResult> GetExamsResultList(ExamResult ExamResultObj)
        {
            try
            {
                return ConvertDatarowToObject(ExamResultDataAccess.GetInstance.GetExamsResultList(ExamResultObj));
            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
            }
        }
        private static List<ExamResult> ConvertDatarowToObject(DataTable ExamResultListTable)
        {            
            List<ExamResult> ExamResultList = new List<ExamResult>();
            foreach (DataRow dr in ExamResultListTable.Rows)
            {
                ExamResult TheExamResult = new ExamResult();
                TheExamResult.ExamID = int.Parse(dr["ExamID"].ToString());
                TheExamResult.ExamName = dr["ExamName"].ToString();
                TheExamResult.StudentCode = dr["StudentCode"].ToString();
                TheExamResult.StudentID =int.Parse(dr["StudentID"].ToString());
                TheExamResult.StudentName = dr["StudentName"].ToString();
                TheExamResult.SubjectFullMark = int.Parse(dr["FullMark"].ToString());
                TheExamResult.SubjectName = dr["SubjectName"].ToString();                
                //TheExamResult.SubjectPassMark = int.Parse(dr["PassMark"].ToString());
                TheExamResult.MarksObtained = int.Parse(dr["MarksObtained"].ToString());
                TheExamResult.ExamDate = DateTime.Parse(dr["ExamDate"].ToString()).ToString(MicroConstants.DateFormat);
                //TheExamResult.OfficeID = (string.IsNullOrEmpty(dr["OfficeID"].ToString()) ? 0 : int.Parse(dr["OfficeID"].ToString()));
                //TheExamResult.CompanyID = (string.IsNullOrEmpty(dr["CompanyID"].ToString()) ? 0 : int.Parse(dr["CompanyID"].ToString()));
                ExamResultList.Add(TheExamResult);
            }
            return ExamResultList;
        }
        
    }
}
