using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.STUDENT;
using Micro.IntegrationLayer.ICAS.EXAM;

namespace Micro.BusinessLayer.ICAS.STUDENT
{
    public partial class ClassManagement
    {
        #region code to Make this as Singleton class


        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static ClassManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static ClassManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ClassManagement();
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
        public string DisplayMember = "ClassName";
        public String ValuMember = "ClassID";
        #endregion

        #region Methods & Implementation
        public List<Qualification> GetClassList()
        {
            return null;//ClassIntegration.GetClassList();
        }
        #endregion

        
    }
}
