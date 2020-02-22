using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;


namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class DUMMYManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static DUMMYManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static DUMMYManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DUMMYManagement();
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

        #region Method& Implementation
        public DUMMY getstudentbyId(int studid)
        {
            //TODO: Cache the customer being requested for first time
            return DUMMYIntegration.getstudentbyId(studid);
        }

        #endregion
    }
}
