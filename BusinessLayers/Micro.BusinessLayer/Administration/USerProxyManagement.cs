using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
   public partial  class USerProxyManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static USerProxyManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static USerProxyManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new USerProxyManagement();
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

       public int InsertUserIncharge(UserIncharge theUserIncharge)
       {
           return USerProxyIntegration.InsertUserIncharge(theUserIncharge);
       }
        #endregion
    }
}
