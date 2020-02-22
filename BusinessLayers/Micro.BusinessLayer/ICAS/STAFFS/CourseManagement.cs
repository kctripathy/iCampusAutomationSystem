using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using Micro.IntegrationLayer.ICAS.STAFFS;

namespace Micro.BusinessLayer.ICAS.STAFFS
{
   public partial class CourseManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static CourseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static CourseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CourseManagement();
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
        public string DefaultColumns = "CourseName";
        public string DisplayMember = "CourseName";
        public string ValueMember = "CourseID";
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)



        #endregion

        #region Data Retrive Mathods
        public List<Course> GetCourseList()
        {
            return CourseIntegration.GetCourseList();
        }

        #endregion
    }
}
