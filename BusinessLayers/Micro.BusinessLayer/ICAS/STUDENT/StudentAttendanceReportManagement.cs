using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public class StudentAttendanceReportManagement
    {
         #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StudentAttendanceReportManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentAttendanceReportManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentAttendanceReportManagement();
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
        public string DisplayMember = "ClassName";
        public string ValueMember = "ClassID";
        #region Methods & Implementation
        #endregion
        //public List<Streams> GetStreamList()
        //{
        //    return StreamIntegration.GetStreamList();
        //}

        public DataTable GetPresentAttnsListByDate(String SearchText)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return StudentAttnsReportIntegration.GetPresentAttnsListByDate(SearchText);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        public DataTable GetAbsentAttnsListByDate(String SearchText)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return StudentAttnsReportIntegration.GetAbsentAttnsListByDate(SearchText);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        public List<StudentAttendance> GetAttnsList()
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return StudentAttnsIntegration.GetAttnsList();
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
        
    }  
}
