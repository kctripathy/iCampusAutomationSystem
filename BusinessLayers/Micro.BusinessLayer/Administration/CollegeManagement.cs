using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
    public partial class CollegeManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CollegeManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CollegeManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CollegeManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion


        #region "Methods"

        //public List<College> GetCollegeList()
        //{
        //    return Micro.IntegrationLayer.Administration.CollegeIntegration.GetCollgeList();
        //}
#endregion
    }
}
