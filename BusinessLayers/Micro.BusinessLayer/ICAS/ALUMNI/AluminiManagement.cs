using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.ICAS.ALUMNI;
using Micro.IntegrationLayer.ICAS.ALUMNI;

namespace Micro.BusinessLayer.ICAS.ALUMNI
{
    public partial class AluminiManagement
    {
        #region Declaration
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>

        private static AluminiManagement _Instance;
        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AluminiManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AluminiManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Metthods & Implementation
        public List<Alumini> GetAluminiList()
        {
            return AluminiIntegration.GetAluminiList();
        }

        public int InsertAlumini(Alumini theAlumini)
        {
            return AluminiIntegration.InsertAlumini(theAlumini);
        }
        public int UpdateAlumini(Alumini theAlumini)
        {
            return AluminiIntegration.UpdateAlumini(theAlumini);
        }
        public int DeleteAlumini(Alumini theAlumini)
        {
            return AluminiIntegration.DeleteAlumini(theAlumini);
        }
#endregion
    }
}
