using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.Administration
{
    public partial class CollegeDataAccess: AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CollegeDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CollegeDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CollegeDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion


        public DataTable GetCollegeList()
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "SelectAllColleges";
                return ExecuteGetDataTable(SelectCommand);
            }
        }
    
    }
}
