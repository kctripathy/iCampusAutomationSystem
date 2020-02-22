using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Micro.DataAccessLayer.Administration
{
    public partial class YearAcademicDataAccess: AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static YearAcademicDataAccess _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static YearAcademicDataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new YearAcademicDataAccess();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion


        #region Methods

        public static void thisClas()
        {
            int x = 0;
        }

        //Select

        //Insert

        //Update

        //Delete




        #endregion

    }
}
