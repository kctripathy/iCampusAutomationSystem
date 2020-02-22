using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using System.Data;
using System.Reflection;
using Micro.DataAccessLayer.ICAS.STUDENT;

namespace Micro.IntegrationLayer.ICAS.STUDENT
{
    public class StudentSubjectIntegration
    {
            
        //public static List<Subjects> GetSubjectAllByStream()
        //{ 


        //    try
        //    {
        //        return ConvertDatarowToObject(SubjectDataAccess.GetInstance.GetSubjectAllByStream(int StreamID, string searchText=null, bool showDeleted = false));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (new Exception(String.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType, (new System.Diagnostics.StackFrame()).GetMethod().Name), ex));
        //    }
        //}

        //public static List<Subjects> ConvertDatarowToObject(DataTable SubjectListTable)
        //{
        //    Subjects TheSubject = new Subjects();
        //    List<Subjects> SubjectList = new List<Subjects>();

        //    foreach (DataRow dr in SubjectListTable.Rows)
        //    {

        //        TheSubject.SubjectID = int.Parse(dr["SubjectID"].ToString());
        //        TheSubject.SubjectName = dr["SubjectName"].ToString();
        //        SubjectList.Add(TheSubject);
        //    }
        //    return SubjectList;
        //}

        public static List<StudentSubjectTaken> GetStudentSubjectAll()
       {
           try
           {
               DataTable StudentSubjectAllTable = StudentSubjectDataAccess.GetInstance.GetStudentSubjectAll();
               List<StudentSubjectTaken> StudentSubjectList = new List<StudentSubjectTaken>();
               foreach (DataRow dr in StudentSubjectAllTable.Rows)
               {
                   StudentSubjectTaken ObjStudentSubjects = new StudentSubjectTaken();
                   ObjStudentSubjects.StudentSubjectsTakenID = int.Parse(dr["StudentSubjectsTakenID"].ToString());
                   ObjStudentSubjects.SubjectID = int.Parse(dr["SubjectID"].ToString());
                   ObjStudentSubjects.SubjectName = dr["SubjectName"].ToString();
                   ObjStudentSubjects.SubjectType = dr["SubjectType"].ToString();
                   ObjStudentSubjects.StudentID = int.Parse(dr["StudentID"].ToString());
                   ObjStudentSubjects.SessionID = int.Parse(dr["SessionID"].ToString());                 
                   StudentSubjectList.Add(ObjStudentSubjects);
               }               
               return StudentSubjectList;
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
     
   }
}
