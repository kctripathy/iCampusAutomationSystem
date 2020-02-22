using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;
using System.Web;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public partial class SubjectManagement
    {
        #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static SubjectManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static SubjectManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SubjectManagement();
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
        public string DisplayMember="SubjectName";
        public string ValueMember = "SubjectID";
        #endregion

        #region Methods & Implementation
        public List<Subjects> GetSubjectAll(string searchText)
        {
            try
            {
                return SubjectIntegration.GetSubjectAll(searchText);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public List<Subjects> GetSubjectListByFaculty(int FacultyID)
        {
            try
            {
                return SubjectIntegration.GetSubjectListByFaculty(FacultyID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public List<Subjects> GetSubjectListByParent(int StreamID, int CourseID, string SubjTypeName, string searchText, bool showDeleted)
        {
            try
            {
                return SubjectIntegration.GetSubjectListByParent(StreamID, CourseID, SubjTypeName, searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public List<Subjects> GetSubjectAllByStream(int StreamID, int CourseID, string SubjTypeName, string searchText, bool showDeleted)
        {
            try
            {
                //return SubjectIntegration.GetSubjectAllByStream(StreamID, CourseID, SubjTypeName, searchText, showDeleted);

                string UniqueKey = string.Format("CountryList_{0}_{1}_{2}", CourseID, StreamID, SubjTypeName);
                if (HttpRuntime.Cache[UniqueKey] == null)
                {
                    List<Subjects> subjectList =  SubjectIntegration.GetSubjectAllByStream(StreamID, CourseID, SubjTypeName, searchText, showDeleted);
                    HttpRuntime.Cache[UniqueKey] = subjectList;
                }

                return (List<Subjects>)(HttpRuntime.Cache[UniqueKey]);

            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public List<Subjects> GetSubjectAllByCourse(int StreamID, int CourseID,string searchText, bool showDeleted)
        {
            try
            {
                return SubjectIntegration.GetSubjectAllByCourse(StreamID, CourseID, searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public List<Subjects> GetSubjectListByCourseStreamClass(Subjects ObjSubjects, string searchText, bool showDeleted)
        {
            try
            {
                return SubjectIntegration.GetSubjectListByCourseStreamClass(ObjSubjects, searchText, showDeleted);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int InsertSubjects(Subjects theSubject)
        {
            return SubjectIntegration.InsertSubjects(theSubject);
        }
        public int UpdateSubjects(Subjects theSubject)
        {
            return SubjectIntegration.UpdateSubjects(theSubject);
        }
        #endregion
    }
}
