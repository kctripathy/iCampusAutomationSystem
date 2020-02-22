using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.BusinessLayer.Administration
{
    class YearAcademicManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static YearAcademicManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static YearAcademicManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new YearAcademicManagement();
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





        #endregion
    }
}
