using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Micro.Commons;
using System.Reflection;
using Micro.Objects.ICAS.EXAM;
using Micro.DataAccessLayer.ICAS.EXAM;

namespace Micro.IntegrationLayer.ICAS.EXAM
{
    public class ExamScheduleIntegration
    {

        public static ObjExamSehedules DataRowToObject(DataRow dr)
        {
            ObjExamSehedules examobj = new ObjExamSehedules();
            examobj.ExamScheduleID = int.Parse(dr["ExamScheduleID"].ToString());
            examobj.ExamScheduleName = dr["ExamScheduleName"].ToString();
            examobj.StreamID = int.Parse(dr["StreamID"].ToString());
            examobj.ExamID = int.Parse(dr["ExamID"].ToString());
            examobj.SubjectID = int.Parse(dr["SubjectID"].ToString());
            examobj.FullMark = int.Parse(dr["FullMark"].ToString());
            examobj.PassMark = int.Parse(dr["PassMark"].ToString());
            examobj.ClassID = int.Parse(dr["ClassID"].ToString());
            examobj.QualID = int.Parse(dr["QualID"].ToString());
            //examobj.SubjectFullMark = int.Parse(dr["SubjectFullMark"].ToString());
            examobj.ExamDate = DateTime.Parse(dr["ExamDate"].ToString()).ToString(MicroConstants.DateFormat);
            examobj.StartTime=dr["StartTime"].ToString();
            examobj.CloseTime=dr["CloseTime"].ToString();
            examobj.RoomNo=int.Parse(dr["RoomNo"].ToString());
            examobj.InvisilatorUserID = int.Parse(dr["InvisilatorUserID"].ToString());
            examobj.IsActive = bool.Parse(dr["IsActive"].ToString());
            examobj.OfficeID= (string.IsNullOrEmpty(dr["OfficeID"].ToString()) ? 0 : int.Parse(dr["OfficeID"].ToString()));
            examobj.CompanyID = (string.IsNullOrEmpty(dr["CompanyID"].ToString()) ? 0 : int.Parse(dr["CompanyID"].ToString()));

            return examobj;
        }
        public static ExamSecludeStudentList RowToObject(DataRow dr)
        {
            ExamSecludeStudentList objStudent = new ExamSecludeStudentList();
            objStudent.StudentID = int.Parse(dr["StudentID"].ToString());
            objStudent.StudentName = dr["StudentName"].ToString();
            return objStudent;
        }
        public static List<ObjExamSehedules> GetExamSeduleList()
        {
            List<ObjExamSehedules> ExamSeduleList = new List<ObjExamSehedules>();
            DataTable ExamSeduleTable = ExamScheduleDataAccess.GetInstance.GetExamSeduleList();
            foreach (DataRow dr in ExamSeduleTable.Rows)
            {
                ObjExamSehedules TheExamSehedules = DataRowToObject(dr);
                ExamSeduleList.Add(TheExamSehedules);
            }
            return ExamSeduleList;
        }
        public static List<ExamSecludeStudentList> GetSeduleStudentList(int SecludeID, bool alloffices , bool showDeleted)
        {
            List<ExamSecludeStudentList> SeduleStudentList = new List<ExamSecludeStudentList>();
            DataTable SeduleStudentListTable = ExamScheduleDataAccess.GetInstance.GetStudentList_ByExamSedule(false,false,SecludeID);
            foreach (DataRow dr in SeduleStudentListTable.Rows)
            {
                ExamSecludeStudentList TheExamSeheduleStudent = RowToObject(dr);
                SeduleStudentList.Add(TheExamSeheduleStudent);
            }
            return SeduleStudentList;
        }
        public static int InsertExamSedhule(ObjExamSehedules theSedhule)
        {
            return ExamScheduleDataAccess.GetInstance.InsertExamSedhule(theSedhule);
        }
        public static int UpdateExamSedhule(ObjExamSehedules theSedhule)
        {
            return ExamScheduleDataAccess.GetInstance.UpdateExamSedhule(theSedhule);
        }
        public static int DeleteExamSedhule(ObjExamSehedules theSedhule)
        {
            return ExamScheduleDataAccess.GetInstance.DeleteExamSedhule(theSedhule);
        }
    }
}
