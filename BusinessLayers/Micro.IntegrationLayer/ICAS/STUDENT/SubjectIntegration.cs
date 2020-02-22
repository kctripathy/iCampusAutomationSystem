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
   public class SubjectIntegration
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

       public static List<Subjects> GetSubjectAllByStream(int StreamID, int CourseID, string SubjTypeName,string searchText = null, bool showDeleted = false)
       {
           try
           {
               DataTable SubjectAllByStreamTable = SubjectDataAccess.GetInstance.GetSubjectAllByStream(StreamID, CourseID,SubjTypeName, searchText, showDeleted);
               List<Subjects> SubjectList = new List<Subjects>();
               foreach (DataRow dr in SubjectAllByStreamTable.Rows)
               {
                   Subjects TheSubjects = new Subjects();
                   TheSubjects.SubjectID = (dr["SubjectID"].ToString());
                   TheSubjects.SubjectName = (dr["SubjectName"].ToString());
                   TheSubjects.SubjectTypeID = (dr["SubjectTypeID"].ToString());
                   TheSubjects.SubjectTypeName = (dr["SubjectTypeName"].ToString());
                   TheSubjects.QualID = (dr["QualID"].ToString());
                   TheSubjects.ClassID = (dr["ClassID"].ToString());
                   TheSubjects.StreamID = (dr["StreamID"].ToString());                   
                   TheSubjects.SubjectFullMark = (dr["SubjectFullMark"].ToString());
                   TheSubjects.StaffID = (dr["StaffID"].ToString());//newly added the staff
                   TheSubjects.SubjectPracticalFlag = bool.Parse(dr["SubjectPracticalFlag"].ToString());
                   TheSubjects.SubjectPracticalMark = (dr["SubjectPracticalMark"].ToString());
                   TheSubjects.SessionID = (dr["SessionID"].ToString());
                  
                  
                   SubjectList.Add(TheSubjects);
               }               
               return SubjectList;
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       public static List<Subjects> GetSubjectListByParent(int StreamID, int CourseID, string SubjTypeName,string searchText = null, bool showDeleted = false)
       {
           try
           {
               DataTable SubjectAllByParentTable = SubjectDataAccess.GetInstance.GetSubjectListByParent(StreamID, CourseID, SubjTypeName, searchText, showDeleted);
               List<Subjects> SubjectList = new List<Subjects>();
               foreach (DataRow dr in SubjectAllByParentTable.Rows)
               {
                   Subjects TheSubjects = new Subjects();
                   TheSubjects.SubjectID = (dr["SubjectID"].ToString());
                   TheSubjects.SubjectName = (dr["SubjectName"].ToString());
                   TheSubjects.SubjectTypeID = (dr["SubjectTypeID"].ToString());
                   TheSubjects.SubjectTypeName = (dr["SubjectTypeName"].ToString());
                   TheSubjects.QualID = (dr["QualID"].ToString());
                   TheSubjects.ClassID = (dr["ClassID"].ToString());
                   TheSubjects.StreamID = (dr["StreamID"].ToString());
                   TheSubjects.SubjectFullMark = (dr["SubjectFullMark"].ToString());
                   TheSubjects.StaffID = (dr["StaffID"].ToString());
                   TheSubjects.SubjectPracticalFlag = bool.Parse(dr["SubjectPracticalFlag"].ToString());
                   TheSubjects.SubjectPracticalMark = (dr["SubjectPracticalMark"].ToString());
                   TheSubjects.SessionID = (dr["SessionID"].ToString());
                   SubjectList.Add(TheSubjects);
               }
               return SubjectList;
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       public static List<Subjects> GetSubjectListByFaculty(int FacultyID)
       {
           try
           {
               DataTable SubjectAllByParentTable = SubjectDataAccess.GetInstance.GetSubjectListByFaculty(FacultyID);
               List<Subjects> SubjectList = new List<Subjects>();
               foreach (DataRow dr in SubjectAllByParentTable.Rows)
               {
                   Subjects TheSubjects = new Subjects();
                   TheSubjects.SubjectID = (dr["SubjectID"].ToString());
                   TheSubjects.SubjectName = (dr["SubjectName"].ToString());                  
                   SubjectList.Add(TheSubjects);
               }
               return SubjectList;
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       public static List<Subjects> GetSubjectAllByCourse(int StreamID, int CourseID,string searchText = null, bool showDeleted = false)
       {
           try
           {
               DataTable SubjectAllByCourseTable = SubjectDataAccess.GetInstance.GetSubjectListByCourse(StreamID, CourseID, searchText, showDeleted);
               List<Subjects> SubjectList = new List<Subjects>();
               foreach (DataRow dr in SubjectAllByCourseTable.Rows)
               {
                   Subjects TheSubjects = new Subjects();
                   TheSubjects.SubjectID = (dr["SubjectID"].ToString());
                   TheSubjects.SubjectName = (dr["SubjectName"].ToString());
                   TheSubjects.SubjectTypeID = (dr["SubjectTypeID"].ToString());
                   TheSubjects.SubjectTypeName = (dr["SubjectTypeName"].ToString());
                   TheSubjects.QualID = (dr["QualID"].ToString());
                   TheSubjects.ClassID = (dr["ClassID"].ToString());
                   TheSubjects.StreamID = (dr["StreamID"].ToString());                  
                   TheSubjects.SubjectFullMark = (dr["SubjectFullMark"].ToString());
                   TheSubjects.StaffID = (dr["StaffID"].ToString());
                   TheSubjects.SubjectPracticalFlag = bool.Parse(dr["SubjectPracticalFlag"].ToString());
                   TheSubjects.SubjectPracticalMark = (dr["SubjectPracticalMark"].ToString());
                   TheSubjects.SessionID = (dr["SessionID"].ToString());
                   SubjectList.Add(TheSubjects);
               }
               return SubjectList;
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       public static List<Subjects> GetSubjectListByCourseStreamClass(Subjects ObjSubjects, string searchText = null, bool showDeleted = false)
       {
           try
           {
               DataTable SubjectListByCourseStreamClassTable = SubjectDataAccess.GetInstance.GetSubjectListByCourseStreamClass(ObjSubjects, searchText, showDeleted);
               List<Subjects> SubjectList = new List<Subjects>();
               foreach (DataRow dr in SubjectListByCourseStreamClassTable.Rows)
               {
                   Subjects TheSubjects = new Subjects();
                   TheSubjects.SubjectID = (dr["SubjectID"].ToString());
                   TheSubjects.SubjectName = (dr["SubjectName"].ToString());
                   TheSubjects.SubjectTypeID = (dr["SubjectTypeID"].ToString());
                   TheSubjects.SubjectTypeName = (dr["SubjectTypeName"].ToString());
                   TheSubjects.QualID = (dr["QualID"].ToString());
                   TheSubjects.ClassID = (dr["ClassID"].ToString());
                   TheSubjects.StreamID = (dr["StreamID"].ToString());                  
                   SubjectList.Add(TheSubjects);
               }
               return SubjectList;
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       public static List<Subjects> GetSubjectAll(string searchText)
       {
           try
           {
               DataTable SubjectAllTable = SubjectDataAccess.GetInstance.GetSubjectList(searchText);
               List<Subjects> SubjectList = new List<Subjects>();
               foreach (DataRow dr in SubjectAllTable.Rows)
               {
                   Subjects TheSubjects = new Subjects();
                   TheSubjects.SubjectID = (dr["SubjectID"].ToString());
                   TheSubjects.SubjectName = (dr["SubjectName"].ToString());
                   TheSubjects.SubjectTypeID = (dr["SubjectTypeID"].ToString());
                   TheSubjects.SubjectTypeName = (dr["SubjectTypeName"].ToString());
                   TheSubjects.QualID = (dr["QualID"].ToString());
                   TheSubjects.ClassID = (dr["ClassID"].ToString());
                   TheSubjects.StreamID = (dr["StreamID"].ToString());
                   TheSubjects.QualCode = (dr["QualCode"].ToString());
                   TheSubjects.ClassName = (dr["ClassName"].ToString());
                   TheSubjects.StreamName = (dr["StreamName"].ToString());
                   TheSubjects.SubjectFullMark = (dr["SubjectFullMark"].ToString());
                   TheSubjects.StaffID = (dr["StaffID"].ToString());
                   TheSubjects.isMain = (dr["isMain"].ToString()) == "Y" ? "1" : "0";
                   TheSubjects.isParent = (dr["isParent"].ToString());
                   TheSubjects.isRoot = (dr["isRoot"].ToString()) == "Y" ? "1" : "0";
                   TheSubjects.SubjectPracticalFlag = bool.Parse(dr["SubjectPracticalFlag"].ToString());
                   TheSubjects.SubjectPracticalMark = (dr["SubjectPracticalMark"].ToString());
                   TheSubjects.SessionID = (dr["SessionID"].ToString());
                   SubjectList.Add(TheSubjects);
               }
               return SubjectList;
           }
           catch (Exception ex)
           {
               throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
           }
       }
       public static int InsertSubjects(Subjects theSubject)
       {
           return SubjectDataAccess.GetInstance.InsertSubjects(theSubject);
       }
       public static int UpdateSubjects(Subjects theSubject)
       {
           return SubjectDataAccess.GetInstance.UpdateSubjects(theSubject);
       }
   }
}
