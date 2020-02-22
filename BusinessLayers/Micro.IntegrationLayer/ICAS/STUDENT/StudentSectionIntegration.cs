using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.DataAccessLayer.ICAS.STUDENT;
using System.Data;
using System.Reflection;
using Micro.DataAccessLayer.ICAS.EXAM;

namespace Micro.IntegrationLayer.ICAS.STUDENT
{
    public partial class StudentSectionIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static int InsertStudentSection(StudentSection theSection)
        {
            return StudentSectionDataAccess.GetInstance.InsertStudentSection(theSection);
        }
        public static int UpdateStudentSection(StudentSection theSection)
        {
            return StudentSectionDataAccess.GetInstance.UpdateStudentSection(theSection);
        }
        public static List<StudentSection> GetStudentListBySectionID(int SectionID)
        {
            try
            {
                DataTable StudentAllTable = StudentSectionDataAccess.GetInstance.GetStudentListBySectionID(SectionID);
                List<StudentSection> StudentList = new List<StudentSection>();
                foreach (DataRow dr in StudentAllTable.Rows)
                {
                    StudentSection ObjStudents = new StudentSection();
                    //ObjStudents.CourseID = int.Parse(dr["CourseID"].ToString());
                    //ObjStudents.StreamID = int.Parse(dr["StreamID"].ToString());
                    //ObjStudents.ClassID = int.Parse(dr["ClassID"].ToString());
                    ObjStudents.StudentID = int.Parse(dr["StudentID"].ToString());
                    ObjStudents.StudentCode = dr["StudentCode"].ToString();
                    ObjStudents.StudentName = dr["StudentName"].ToString();
                    ObjStudents.ROLLNo = dr["ROLLNo"].ToString();
                    ObjStudents.QualID = int.Parse(dr["QualID"].ToString());
                    StudentList.Add(ObjStudents);
                }
                return StudentList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static List<StudentSection> GetSectionList(string searchText)
        {
            try
            {
                DataTable SectionAllTable = StudentSectionDataAccess.GetInstance.GetSectionList(searchText);
                List<StudentSection> SectionList = new List<StudentSection>();
                foreach (DataRow dr in SectionAllTable.Rows)
                {
                    StudentSection ObjAllSection = new StudentSection();
                    ObjAllSection.SectionGroupID = int.Parse(dr["SectionGroupID"].ToString());
                    ObjAllSection.CourseID = int.Parse(dr["CourseID"].ToString());
                    ObjAllSection.StreamID = int.Parse(dr["StreamID"].ToString());
                    ObjAllSection.ClassID = int.Parse(dr["ClassID"].ToString());
                    ObjAllSection.SubjectID = int.Parse(dr["SubjectID"].ToString());
                    ObjAllSection.SubjectName = dr["SubjectName"].ToString();
                    ObjAllSection.StudentIDS=(dr["StudentIDS"].ToString());
                    ObjAllSection.SectionID = int.Parse(dr["SectionID"].ToString());
                    ObjAllSection.SectionName = dr["SectionName"].ToString();                   
                    ObjAllSection.Comment = dr["Comment"].ToString();
                    SectionList.Add(ObjAllSection);
                }
                return SectionList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        #endregion
    }
}
