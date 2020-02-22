using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.ICAS.STAFFS
{
  public partial  class CourseDataAccess :AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
      private static CourseDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
      public static CourseDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CourseDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)



        #endregion

        #region Data Retrive Mathods

      public DataTable GetCourseList(string SearchText = "", bool showDeleted = false)
      {
          using (SqlCommand SelectCommand = new SqlCommand())
          {
              SelectCommand.CommandType = CommandType.StoredProcedure;
              SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, SearchText));
              SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
              //TODO
            
             // SelectCommand.Parameters.Add(GetParameter("@OfficeId", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.OfficeID));
              SelectCommand.CommandText = "pHRM_Courses_SelectAll";

              return ExecuteGetDataTable(SelectCommand);
          }
      }
        #endregion
    }
}
