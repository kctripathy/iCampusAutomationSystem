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
    public partial class ExamIntegration
    {
        #region Declaration
        #endregion

        public static List<Exams> GetExamsList()
        {
            try
            {
                return ConvertDatarowToObject(ExamDataAccess.GetInstance.GetExamsAll());
            }
            catch (Exception ex)
            {
                throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
            }
        }
        private static List<Exams> ConvertDatarowToObject(DataTable ExamListTable)
        {            
            List<Exams> ExamList = new List<Exams>();
            foreach (DataRow dr in ExamListTable.Rows)
            {
                Exams TheExam = new Exams();
                TheExam.ExamID = int.Parse(dr["ExamID"].ToString());
                TheExam.ExamName = dr["ExamName"].ToString();
                TheExam.SessionID = int.Parse(dr["SessionID"].ToString());
                TheExam.QualID = int.Parse(dr["QualID"].ToString());
                TheExam.DateOfStart = DateTime.Parse(dr["DateOfStart"].ToString()).ToString(MicroConstants.DateFormat);
                TheExam.DateOfClose = DateTime.Parse(dr["DateOfClose"].ToString()).ToString(MicroConstants.DateFormat);
                TheExam.IsActive = bool.Parse(dr["IsActive"].ToString());
                //TheExam.ModifiedBy = int.Parse(dr["ModifiedBy"].ToString());
                //TheExam.DateModified = dr["DateModified"].ToString();
                TheExam.AddedBy = int.Parse(dr["AddedBy"].ToString());
                TheExam.OfficeID = (string.IsNullOrEmpty(dr["OfficeID"].ToString()) ? 0 : int.Parse(dr["OfficeID"].ToString()));
                TheExam.CompanyID = (string.IsNullOrEmpty(dr["CompanyID"].ToString()) ? 0 : int.Parse(dr["CompanyID"].ToString()));
                ExamList.Add(TheExam);
            }

            return ExamList;

        }
        public static int InsertExam(Exams theExam)
        {
            return ExamDataAccess.GetInstance.InsertExam(theExam);
        }
        public static int UpdateExam(Exams theExam)
        {
            return ExamDataAccess.GetInstance.UpdateExam(theExam);
        }
        public static int DeleteExam(Exams theExam)
        {
            return ExamDataAccess.GetInstance.DeleteExam(theExam);
        }
    }
}
