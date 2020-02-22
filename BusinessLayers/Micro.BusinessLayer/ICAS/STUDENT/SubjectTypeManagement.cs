using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public partial class SubjectTypeManagement
    {
        #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static SubjectTypeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static SubjectTypeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SubjectTypeManagement();
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
        public string DisplayMember="SubjectTypeName";
        public string ValueMember = "SubjectTypeID";
        #endregion

        #region Methods & Implementation

        public List<SubjectTypes> GetSubjectTypeListByCourseStream(int CourseID,string StreamID)
        {
            try
            {
                return SubjectTypeIntegration.GetSubjectTypeListByCourseStream(CourseID,StreamID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        //public int InsertSubjects(Subjects theSubject)
        //{
        //    return SubjectIntegration.InsertSubjects(theSubject);
        //}
        //public int UpdateSubjects(Subjects theSubject)
        //{
        //    return SubjectIntegration.UpdateSubjects(theSubject);
        //}
        #endregion
    }
}
