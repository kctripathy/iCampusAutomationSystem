using System;
using Micro.Objects.Administration;
namespace Micro.BusinessLayer
{
    public partial class LoginManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static LoginManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static LoginManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoginManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        public User CheckLoginCredentials(User userInfo)
        {
            string Context = this.GetType().FullName.ToString();
            try
            {
                User theUser = new User();
                theUser = Micro.IntegrationLayer.LoginIntegration.CheckLoginCredentials(userInfo);
                return theUser;
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }

		public int InsertUserSessionLog(UserLog usrLog)
		{
			return Micro.IntegrationLayer.LoginIntegration.InsertUserSessionLog(usrLog);
		}

		public void UpdateUserSessionLogout(int currentLogId)
		{
			Micro.IntegrationLayer.LoginIntegration.UpdateUserSessionLogout(currentLogId);
		}
    }
}
