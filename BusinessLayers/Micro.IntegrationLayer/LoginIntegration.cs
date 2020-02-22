using System;
using Micro.Objects.Administration;
using System.Data;
using Micro.DataAccessLayer;

namespace Micro.IntegrationLayer
{
    public class LoginIntegration
    {
        public static User CheckLoginCredentials(User UserCredentials)
        {
            string Context = "Micro.IntegrationLayer.HumanResource.LoginIntegration.CheckLoginCredentials";
            try
            {
                User CurrentUser = new User();

                DataRow drowCurrentUser = LoginManagementData.GetInstance.CheckLoginCredentials(UserCredentials);
                if (drowCurrentUser == null)
                {
                    CurrentUser = null;
                }
                else
                {
                    CurrentUser.RoleID = int.Parse(drowCurrentUser["RoleID"].ToString());
                    CurrentUser.UserName = drowCurrentUser["UserName"].ToString();
                    CurrentUser.UserID=int.Parse(drowCurrentUser["UserID"].ToString());
                }

                return CurrentUser;
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }

		public static int InsertUserSessionLog(UserLog usrLog)
		{
			return LoginManagementData.GetInstance.InsertUserSessionLog(usrLog);
		}

		public static void UpdateUserSessionLogout(int currentLogId)
		{
			LoginManagementData.GetInstance.UpdateUserSessionLogout(currentLogId);
		}

		
    }
}
