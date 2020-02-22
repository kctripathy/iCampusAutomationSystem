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
    public partial class StudentAttnsIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static int InsertStudentAttns(StudentAttendance theAttns)
        {
            return StudentAttendanceDataAccess.GetInstance.InsertStudentAttns(theAttns);
        }
        public static int UpdateStudentAttns(StudentAttendance theAttns)
        {
            return StudentAttendanceDataAccess.GetInstance.UpdateStudentAttns(theAttns);
        }
        public static List<StudentAttendance> GetStudentListByAttnID(int AttnID)
        {
            try
            {
                DataTable StudentAllTable = StudentAttendanceDataAccess.GetInstance.GetStudentListByAttnID(AttnID);
                List<StudentAttendance> StudentList = new List<StudentAttendance>();
                foreach (DataRow dr in StudentAllTable.Rows)
                {
                    StudentAttendance ObjStudents = new StudentAttendance();
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
        public static List<StudentAttendance> GetAttnsList()
        {
            try
            {
                DataTable AttnAllTable = StudentAttendanceDataAccess.GetInstance.GetAttnsList();
                List<StudentAttendance> AttnList = new List<StudentAttendance>();
                foreach (DataRow dr in AttnAllTable.Rows)
                {
                    StudentAttendance ObjAllAttns = new StudentAttendance();
                    ObjAllAttns.AttenID = int.Parse(dr["AttenID"].ToString());
                    ObjAllAttns.SubjectID = int.Parse(dr["SubjectID"].ToString());
                    ObjAllAttns.SubjectName = dr["SubjectName"].ToString();
                    ObjAllAttns.StudentIDS=(dr["StudentIDS"].ToString());
                    ObjAllAttns.StaffID =  int.Parse(dr["StaffID"].ToString());
                    ObjAllAttns.EmployeeName = dr["EmployeeName"].ToString();
                    ObjAllAttns.Date = dr["Date"].ToString();
                    ObjAllAttns.ClassStartTime = dr["ClassStartTime"].ToString();
                    ObjAllAttns.ClassCloseTime =dr["ClassCloseTime"].ToString();
                    ObjAllAttns.Comment = dr["Comment"].ToString();
                    AttnList.Add(ObjAllAttns);
                }
                return AttnList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        #endregion
    }
}
