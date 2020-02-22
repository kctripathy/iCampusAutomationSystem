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
    public class SubjectTypeIntegration
    {
        public static List<SubjectTypes> GetSubjectTypeListByCourseStream(int CourseID,string StreamID)
       {
           try
           {
               DataTable SubjectAllByQualStreamTable = SubjectTypeDataAccess.GetInstance.GetSubjectTypeListByCourseStream(CourseID,StreamID);
               List<SubjectTypes> SubjectTypeList = new List<SubjectTypes>();
               foreach (DataRow dr in SubjectAllByQualStreamTable.Rows)
               {
                   SubjectTypes TheSubjectType = new SubjectTypes();
                   TheSubjectType.SubjectTypeID = int.Parse(dr["SubjectTypeID"].ToString());
                   TheSubjectType.SubjectTypeName = (dr["SubjectTypeName"].ToString());
                   TheSubjectType.QualID = int.Parse(dr["QualID"].ToString());
                   TheSubjectType.StreamID = (dr["StreamID"].ToString());
                   SubjectTypeList.Add(TheSubjectType);
               }
               return SubjectTypeList;
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       //public static List<Subjects> GetSubjectAllByCourse(int StreamID, int CourseID,string searchText = null, bool showDeleted = false)
       //{
       //    try
       //    {
       //        DataTable SubjectAllByCourseTable = SubjectDataAccess.GetInstance.GetSubjectListByCourse(StreamID, CourseID, searchText, showDeleted);
       //        List<Subjects> SubjectList = new List<Subjects>();
       //        foreach (DataRow dr in SubjectAllByCourseTable.Rows)
       //        {
       //            Subjects TheSubjects = new Subjects();
       //            TheSubjects.SubjectID = (dr["SubjectID"].ToString());
       //            TheSubjects.SubjectName = (dr["SubjectName"].ToString());
       //            TheSubjects.SubjectTypeID = (dr["SubjectTypeID"].ToString());
       //            TheSubjects.SubjectTypeName = (dr["SubjectTypeName"].ToString());
       //            TheSubjects.QualID = int.Parse(dr["QualID"].ToString());
       //            TheSubjects.ClassID = (dr["ClassID"].ToString());
       //            TheSubjects.StreamID = (dr["StreamID"].ToString());
       //            TheSubjects.SubjectFullMark = (dr["SubjectFullMark"].ToString());
       //            TheSubjects.SubjectPassMark = (dr["SubjectPassMark"].ToString());
       //            TheSubjects.SubjectPracticalFlag = (dr["SubjectPracticalFlag"].ToString());
       //            TheSubjects.SubjectPracticalMark = (dr["SubjectPracticalMark"].ToString());
       //            TheSubjects.SessionID = (dr["SessionID"].ToString());
       //            SubjectList.Add(TheSubjects);
       //        }
       //        return SubjectList;
       //    }
       //    catch (Exception ex)
       //    {
       //        throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
       //    }
       //}
       //public static int InsertSubjects(Subjects theSubject)
       //{
       //    return SubjectDataAccess.GetInstance.InsertSubjects(theSubject);
       //}
       //public static int UpdateSubjects(Subjects theSubject)
       //{
       //    return SubjectDataAccess.GetInstance.UpdateSubjects(theSubject);
       //}
   }
}
