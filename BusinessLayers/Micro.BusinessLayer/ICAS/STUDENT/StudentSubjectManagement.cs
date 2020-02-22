using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Micro.IntegrationLayer.ICAS.STUDENT;
using Micro.Objects.ICAS.STUDENT;
using System.Data;
using System.Web;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public partial class StudentSubjectManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static StudentSubjectManagement _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentSubjectManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentSubjectManagement();
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

        #region Methods & Implementation
        
        public List<StudentSubjectTaken> GetStudentSubjectAll()
        {
            try
            {
                return StudentSubjectIntegration.GetStudentSubjectAll();
                //string UniqueKey = "GetStudentSubjectAll";
                //if (HttpRuntime.Cache[UniqueKey] == null)
                //{
                //    List<StudentSubjectTaken> StudentSubjectList = StudentSubjectIntegration.GetStudentSubjectAll(); //CountryIntegration.GetCountryList(searchText, showDeleted);
                //    HttpRuntime.Cache[UniqueKey] = StudentSubjectList;
                //}
                //return (List<StudentSubjectTaken>)(HttpRuntime.Cache[UniqueKey]);

            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
               #endregion

    }
}
