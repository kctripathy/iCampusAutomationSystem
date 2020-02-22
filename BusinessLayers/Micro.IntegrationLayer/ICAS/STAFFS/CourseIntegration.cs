using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STAFFS;
using System.Data;
using Micro.DataAccessLayer.ICAS.STAFFS;

namespace Micro.IntegrationLayer.ICAS.STAFFS
{
   public partial class CourseIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static Course DataRowToObject(DataRow dr)
        {
            Course TheCourse = new Course();
            TheCourse.CourseID = int.Parse(dr["CourseID"].ToString());
            TheCourse.CourseName = dr["CourseName"].ToString();


            return TheCourse;
        }

        public static List<Course> GetCourseList()
        {
            List<Course> CourseList = new List<Course>();
            DataTable CourseTable = CourseDataAccess.GetInstance.GetCourseList();

            foreach (DataRow dr in CourseTable.Rows)
            {
                Course TheCourse = DataRowToObject(dr);

                CourseList.Add(TheCourse);
            }

            return CourseList;
        }

        #endregion
    }
}
