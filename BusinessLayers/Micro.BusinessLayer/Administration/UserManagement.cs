﻿using System;
using System.Reflection;

using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;
using System.Collections.Generic;
using System.Web;

namespace Micro.BusinessLayer.Administration
{
    public partial class UserManagement
    {
        #region Declaration
        public string DefaultColumns = "UserName,RoleDescription,UserType,UserReferenceName,OfficeName,CompanyName";
        public string DisplayMember = "UserName";
        public string ValueMember = "UserID";
        #endregion

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static UserManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static UserManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Methods & Implementations
        public List<User> GetUserList()
        {
            return UserIntegration.GetUserList();
        }

        public User GetUserByID(int userID)
        {
            return UserIntegration.GetUserByID(userID);
        }

        public User Login(string loginName, string willGenerateToken = "NO")
        {
            return UserIntegration.Login(loginName, willGenerateToken);
        }

        public UserLoginRespsonse LoginFromAPI(string loginName)
        {
            return UserIntegration.LoginFromAPI(loginName);
        }

        public User GetUserByLoginName(string loginName)
        {
            //User TheUser = null;
            //string UniqueKey = string.Concat("loginName_", loginName);
            //if (HttpRuntime.Cache[UniqueKey] == null)
            //{
            //    TheUser = UserIntegration.GetUserByLoginNameOrPhone(loginName);
            //    HttpRuntime.Cache[UniqueKey] = TheUser;
            //}
            //return ((User)(HttpRuntime.Cache[UniqueKey]));
            return UserIntegration.GetUserByLoginNameOrPhone(loginName);
        }
		public User GetUserByLoginNameGuset(string loginName)
		{
			return UserIntegration.GetUserByLoginNameGuset(loginName);
		}

		public User GetUserByUserReferenceID(int UserReferenceID)
		{
			return UserIntegration.GetUserByUserReferenceID(UserReferenceID);
		}

        public User GetUserByLoginCredentials(User theUser)
        {
            return UserIntegration.GetUserByLoginCredentials(theUser);
        }

        public string GeneratePassword()
        {
            try
            {
                return UserIntegration.GeneratePassword();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateUserPassword(User theUser)
        {
            return UserIntegration.UpdateUserPassword(theUser);
        }

        public int UpdateUserRole(User theUser)
        {
            return UserIntegration.UpdateUserRole(theUser);
        }

        public  int DeleteUser(int UserID)
        {
            try
            {
                return UserIntegration.DeleteUser(UserID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
 
        public int InsertUser(User theUser)
        {
            return UserIntegration.InsertUser(theUser);
        }
        public int Insert4Registration(User theUser)
        {
            return UserIntegration.Insert4Registration(theUser);
        }
        public int UpdateUser(User theUser)
        {
            return UserIntegration.UpdateUser(theUser);
        }

		public int InsertUserPageVisit(int logId, int pageId)
		{
			return UserIntegration.InsertUserPageVisit(logId, pageId);
		}

		public void UpdateUserPageVisit(int recordId)
		{
			UserIntegration.UpdateUserPageVisit(recordId);
		}

        public List<ErrorLog> GetErrorLogs()
        {
            return UserIntegration.GetErrorLogs();
        }

        public bool ValidateToken(int userId, string token)
        {
            string userToken =  UserIntegration.GetUserToken(userId);
            return token.ToUpper().Contains(userToken.ToUpper());
        }

        public int UpdatePassword(UpdatePasswordModel payload)
        {
            return UserIntegration.UpdatePassword(payload);
        }

        #endregion
    }
}
