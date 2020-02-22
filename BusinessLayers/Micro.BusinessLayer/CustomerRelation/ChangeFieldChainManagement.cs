using System;


namespace Micro.BusinessLayer.CustomerRelation
{
   public partial  class ChangeFieldChainManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static ChangeFieldChainManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static ChangeFieldChainManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangeFieldChainManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Methods & Implementation
        #endregion
    }
}
