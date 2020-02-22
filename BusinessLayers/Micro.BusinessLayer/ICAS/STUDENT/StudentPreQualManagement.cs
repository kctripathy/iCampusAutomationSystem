using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.STUDENT;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public class StudentPreQualManagement
    {
         #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static StudentPreQualManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static StudentPreQualManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentPreQualManagement();
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
        #endregion
        //public List<Streams> GetStreamList()
        //{
        //    return StreamIntegration.GetStreamList();
        //}

        public List<StudentPreviousQual> GetPreQualsList(int StudentID)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                return StudentPreQualiIntegration.GetPreQualList(StudentID);
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }

    }  
}
