using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.IntegrationLayer.ICAS.STUDENT;
using Micro.Objects.ICAS.STUDENT;
using System.Data;
using System.Web;
using Micro.Objects.ICAS.LIBRARY;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public partial class StudentManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static StudentManagement _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentManagement();
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
        public static string DisplayMember = "StudentCode";
        public static string DisplayValue="StudentID";
        #region Methods & Implementation
        public List<Student> GetStudentList()
        {
            return StudentIntegration.GetStudentList();
        }
		public List<Student> GetStudentList_Library()
		{
			//List<Student> StudentList =  this.GetStudentList(true);
			string UniqueKey = "GetStudentList";
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<Student> StudentList = this.GetStudentList(true);
				HttpRuntime.Cache[UniqueKey] = StudentList.OrderBy(a=>a.RollNo).ToList();
			}
			return (List<Student>)(HttpRuntime.Cache[UniqueKey]);
		}
		public List<Student> GetStudentList(bool willRefreshFlag = false)
        {
            if (willRefreshFlag)
            {
                return StudentIntegration.GetStudentList();
            }
            else
            {
                new List<Student>();
                string UniqueKey = "GetStudentList";
                if (HttpRuntime.Cache[UniqueKey] == null)
                {
                    List<Student> StudentList = StudentIntegration.GetStudentList();
                    HttpRuntime.Cache[UniqueKey] = StudentList;
                }
                return (List<Student>)(HttpRuntime.Cache[UniqueKey]);
            }
            
        }
        // overload function for alumni
        public List<Student> GetStudentList(bool allOffices = false, bool showDeleted = false, bool alumniFlag = false)
        {
            return StudentIntegration.GetStudentList(allOffices,showDeleted,alumniFlag);
        }
        
        public DataTable GetStudentListReport(string searchText)
        {
            DataTable StudentTable = StudentIntegration.GetStudentListReport(searchText);
            return StudentTable;
        }
        public Boolean GetStudent_SitStatus_ByQualAndStream(int QualID, int StreamID, int SessionID, string StudentCode)
        {
            bool StudentSitStatus = StudentIntegration.GetStudent_SitStatus_ByQualAndStream(QualID, StreamID, SessionID, StudentCode);
            return StudentSitStatus;
        }
        public List<StudentListBySubject> StudentListBySubject(int SubjectID, int SectionID)
        {
            return StudentIntegration.GetStudentList_BySubject(SubjectID,SectionID);
        }
        public int InsertStudent(Student theStudent ,List<StudentSubjectTaken> StudentSubjects,List<StudentPreviousQual> StudentPreQualList)
        {
            return StudentIntegration.InsertStudent(theStudent, StudentSubjects,StudentPreQualList);
        }

        public int InsertStudent(Student theStudent, List<StudentSubjectTaken> StudentSubjects, List<StudentPreviousQual> StudentPreQualList, bool alumniFlag)
        {
            return StudentIntegration.InsertStudent(theStudent, StudentSubjects, StudentPreQualList, alumniFlag);
        }

        public int UpdateStudent(Student theStudent, List<StudentSubjectTaken> StudentSubjects)
        {
            return StudentIntegration.UpdateStudent(theStudent, StudentSubjects);
        }
        public int UpdateStudent(Student theStudent)
        {
            return StudentIntegration.UpdateStudent(theStudent);
        }
        public int DeleteStudent(Student theStudent)
        {
            return StudentIntegration.DeleteStudent(theStudent);
        }
        #endregion


        public int SaveStudentFeesEntry(string theSettingKey, string theSettingValue)
        {
            //throw new NotImplementedException();
            return 1;
        }

		public List<Student> GetStudentList_Library_Issue()
		{
			//List<Student> StudentList =  this.GetStudentList(true);
			string UniqueKey = "GetStudentList_Library_Issue";
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<Student> StudentList = this.GetStudentList(true);

				List<Student> StudentList_Filtered = new List<Student>();
				List<BookTransaction> issuedBookList = new List<BookTransaction>();

				HttpRuntime.Cache[UniqueKey] = StudentList.OrderBy(a => a.RollNo).ToList();
			}
			return (List<Student>)(HttpRuntime.Cache[UniqueKey]);
		}

		public List<Student> GetStudentList_Library_Receive()
		{
			throw new NotImplementedException();
		}
	}
}
