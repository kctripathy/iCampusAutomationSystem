using System;


namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class OfficewiseManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static OfficewiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static OfficewiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OfficewiseManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

    }
}
