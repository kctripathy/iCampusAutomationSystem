using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;

namespace Micro.BusinessLayer.Administration
{
   public partial class ChangePasswordManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static ChangePasswordManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static ChangePasswordManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChangePasswordManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion.

       #region Methods & Implementation
      
       public User GetUserByName(string UserName)
       {
           return ChangePasswordIntegration.GetUserByName(UserName);
       }

       public int UpdateChangePassword(User theUser)
       {
           return ChangePasswordIntegration.UpdateChangePassword(theUser);
       }

       #endregion
    }
}
