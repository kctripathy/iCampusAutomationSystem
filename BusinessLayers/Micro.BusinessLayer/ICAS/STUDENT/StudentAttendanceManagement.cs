using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public class StudentAttendanceManagement
    {
         #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StudentAttendanceManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentAttendanceManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentAttendanceManagement();
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

        public List<StudentAttendance> GetStudentListByAttnID(int AttnID)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return StudentAttnsIntegration.GetStudentListByAttnID(AttnID);
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
        public int InsertStudentAttns(StudentAttendance theAttns)
        {
            return StudentAttnsIntegration.InsertStudentAttns(theAttns);
        }
        public int UpdateStudentAttns(StudentAttendance theAttns)
        {
            return StudentAttnsIntegration.UpdateStudentAttns(theAttns);
        }
    }  
}
