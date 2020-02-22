using System;
using System.Data;
using System.Reflection;

using Micro.DataAccessLayer.ICAS.ADMIN;
using Micro.Objects.ICAS.ADMIN;
using System.Collections.Generic;

namespace Micro.IntegrationLayer.ICAS.ADMIN
{
	public partial class UserIntegration
	{
		#region Methods & Implementation
		public static User DataRowToObject(DataRow dRowUser)
		{
			//User TheUser = new User
			//{
			//    UserID = int.Parse(dr["UserID"].ToString()),
			//    UserName = dr["UserName"].ToString(),
			//    Password = dr["Password"].ToString(),
			//    RoleID = int.Parse(dr["RoleID"].ToString()),
			//    RoleDescription = dr["RoleDescription"].ToString(),
			//    UserType = dr["UserType"].ToString(),
			//    UserReferenceID = int.Parse(dr["UserReferenceID"].ToString()),
			//    UserReferenceName = dr["UserReferenceName"].ToString(),
			//    OfficeID = int.Parse(dr["OfficeID"].ToString()),
			//    OfficeCode = dr["OfficeCode"].ToString(),
			//    OfficeName = dr["OfficeName"].ToString(),
			//    CompanyID = int.Parse(dr["CompanyID"].ToString()),
			//    CompanyCode = dr["CompanyCode"].ToString(),
			//    CompanyName = dr["CompanyName"].ToString()
			//};
			User TheUser = new User();

			TheUser.UserID = int.Parse(dRowUser["UserID"].ToString());
			TheUser.UserName = dRowUser["UserName"].ToString();
			TheUser.Password = dRowUser["Password"].ToString();
			TheUser.RoleID = (dRowUser["RoleID"] != null ? int.Parse(dRowUser["RoleID"].ToString()) : 0);
			TheUser.RoleDescription = dRowUser["RoleDescription"].ToString();
			TheUser.UserType = dRowUser["UserType"].ToString();
			TheUser.UserReferenceID = (((dRowUser["UserReferenceID"] == null) || (string.IsNullOrEmpty(dRowUser["UserReferenceID"].ToString()))) ? 0 : int.Parse(dRowUser["UserReferenceID"].ToString()));
			TheUser.UserReferenceName = dRowUser["UserReferenceName"].ToString();
			TheUser.OfficeID = (((dRowUser["OfficeID"] == null) || (string.IsNullOrEmpty(dRowUser["OfficeID"].ToString()))) ? 0 : int.Parse(dRowUser["OfficeID"].ToString()));
			TheUser.OfficeCode = (dRowUser["OfficeCode"] != null ? dRowUser["OfficeCode"].ToString() : "N/A");
			TheUser.OfficeName = dRowUser["OfficeName"].ToString();
			TheUser.CompanyID = (dRowUser["CompanyID"] != null ? int.Parse(dRowUser["CompanyID"].ToString()) : 0);
			TheUser.CompanyCode = dRowUser["CompanyCode"].ToString();
			TheUser.CompanyName = dRowUser["CompanyName"].ToString();
			TheUser.EmailAddress = ((dRowUser["EmailID"] == null) ? null : dRowUser["EmailID"].ToString().ToLower());
			return TheUser;
		}

		public static List<User> GetUserList()
		{
			List<User> UserList = new List<User>();
			DataTable UserTable = UserDataAccess.GetInstance.GetUserList();

			foreach (DataRow dr in UserTable.Rows)
			{
				User TheUser = DataRowToObject(dr);
				UserList.Add(TheUser);
			}
			return UserList;
		}

		public static User GetUserByID(int userID)
		{
			DataRow UserDataRow = UserDataAccess.GetInstance.GetUserByID(userID);
			//User TheUser = DataRowToObject(UserDataRow);
			User TheUser = new User();

			TheUser.UserID = int.Parse(UserDataRow["UserID"].ToString());
			TheUser.UserName = UserDataRow["UserName"].ToString();
			TheUser.Password = UserDataRow["Password"].ToString();
			TheUser.RoleID = (UserDataRow["RoleID"] != null ? int.Parse(UserDataRow["RoleID"].ToString()) : 0);
			TheUser.RoleDescription = UserDataRow["RoleDescription"].ToString();

			TheUser.UserType = UserDataRow["UserType"].ToString();
            if (!string.IsNullOrEmpty(UserDataRow["UserReferenceID"].ToString()))
			{
				TheUser.UserReferenceID = int.Parse(UserDataRow["UserReferenceID"].ToString());
			}


			TheUser.UserReferenceName = UserDataRow["UserReferenceName"].ToString();
			//TheUser.OfficeID = (UserDataRow["OfficeID"] != null ? int.Parse(UserDataRow["OfficeID"].ToString()) : 0);
			//TheUser.OfficeCode = (UserDataRow["OfficeCode"] != null ? UserDataRow["OfficeCode"].ToString() : "N/A");
			//TheUser.OfficeName = UserDataRow["OfficeName"].ToString();
			TheUser.CompanyID = int.Parse(UserDataRow["CompanyID"].ToString());
			TheUser.CompanyCode = UserDataRow["CompanyCode"].ToString();
			TheUser.CompanyName = UserDataRow["CompanyName"].ToString();

			return TheUser;
		}

		public static User GetUserByLoginName(string loginName)
		{
			User TheUser = new User();
			DataRow dRowUser = UserDataAccess.GetInstance.GetUserByLoginName(loginName);
			if (dRowUser != null)
			{
				TheUser.UserID = int.Parse(dRowUser["UserID"].ToString());
				TheUser.UserName = dRowUser["UserName"].ToString();
				TheUser.Password = dRowUser["Password"].ToString();
				TheUser.RoleID = (dRowUser["RoleID"] != null ? int.Parse(dRowUser["RoleID"].ToString()) : 0);
				TheUser.RoleDescription = dRowUser["RoleDescription"].ToString();
				TheUser.UserType = dRowUser["UserType"].ToString();
				TheUser.UserReferenceID = (((dRowUser["UserReferenceID"] == null) || (string.IsNullOrEmpty(dRowUser["UserReferenceID"].ToString()))) ? 0 : int.Parse(dRowUser["UserReferenceID"].ToString()));
				TheUser.UserReferenceName = dRowUser["UserReferenceName"].ToString();
				TheUser.OfficeID = (((dRowUser["OfficeID"] == null) || (string.IsNullOrEmpty(dRowUser["OfficeID"].ToString()))) ? 0 : int.Parse(dRowUser["OfficeID"].ToString()));
				TheUser.OfficeCode = (dRowUser["OfficeCode"] != null ? dRowUser["OfficeCode"].ToString() : "N/A");
				TheUser.OfficeName = dRowUser["OfficeName"].ToString();
				TheUser.CompanyID = (dRowUser["CompanyID"] != null ? int.Parse(dRowUser["CompanyID"].ToString()) : 0);
				TheUser.CompanyCode = dRowUser["CompanyCode"].ToString();
				TheUser.CompanyName = dRowUser["CompanyName"].ToString();
				TheUser.CompanyAliasName = dRowUser["CompanyAliasName"].ToString();
				TheUser.EmailAddress = ((dRowUser["EmailID"] == null) ? null : dRowUser["EmailID"].ToString().ToLower());

                TheUser.UserPhoto_SmallSize = ((dRowUser["UserPhoto_SmallSize"] == null) ? null : dRowUser["UserPhoto_SmallSize"].ToString());
                TheUser.UserPhoto_MediumSize = ((dRowUser["UserPhoto_MediumSize"] == null) ? null : dRowUser["UserPhoto_MediumSize"].ToString());
                //Company c = Micro.DataAccessLayer.Administration.CompanyDataAccess.GetInstance.GetCompanyByComapnyID(TheUser.CompanyID);
			}

			return TheUser;
		}

		public static User GetUserByLoginNameGuset(string loginName)
		{
			User TheUser = new User();
			DataRow dRowUser = UserDataAccess.GetInstance.GetUserByLoginNameGuset(loginName);
			if (dRowUser != null)
			{
				TheUser.UserID = int.Parse(dRowUser["UserID"].ToString());
				TheUser.UserName = dRowUser["UserName"].ToString();
				TheUser.Password = dRowUser["Password"].ToString();
				TheUser.RoleID = (dRowUser["RoleID"] != null ? int.Parse(dRowUser["RoleID"].ToString()) : 0);
				TheUser.RoleDescription = dRowUser["RoleDescription"].ToString();
				TheUser.UserType = dRowUser["UserType"].ToString();
				TheUser.UserReferenceID = (((dRowUser["UserReferenceID"] == null) || (string.IsNullOrEmpty(dRowUser["UserReferenceID"].ToString()))) ? 0 : int.Parse(dRowUser["UserReferenceID"].ToString()));
				TheUser.UserReferenceName = dRowUser["UserReferenceName"].ToString();
				TheUser.OfficeID = (((dRowUser["OfficeID"] == null) || (string.IsNullOrEmpty(dRowUser["OfficeID"].ToString()))) ? 0 : int.Parse(dRowUser["OfficeID"].ToString()));
				TheUser.OfficeCode = (dRowUser["OfficeCode"] != null ? dRowUser["OfficeCode"].ToString() : "N/A");
				TheUser.OfficeName = dRowUser["OfficeName"].ToString();
				TheUser.CompanyID = (dRowUser["CompanyID"] != null ? int.Parse(dRowUser["CompanyID"].ToString()) : 0);
				TheUser.CompanyCode = dRowUser["CompanyCode"].ToString();
				TheUser.CompanyName = dRowUser["CompanyName"].ToString();
				TheUser.CompanyAliasName = dRowUser["CompanyAliasName"].ToString();
			}

			return TheUser;
		}

		public static User GetUserByUserReferenceID(int UserReferenceID)
		{
			DataRow UserDataRow = UserDataAccess.GetInstance.GetUserByUserReferenceID(UserReferenceID);
			//User TheUser = DataRowToObject(UserDataRow);
			User TheUser = new User();

			TheUser.UserID = int.Parse(UserDataRow["UserID"].ToString());
			TheUser.UserName = UserDataRow["UserName"].ToString();
			TheUser.Password = UserDataRow["Password"].ToString();
			TheUser.RoleID = (UserDataRow["RoleID"] != null ? int.Parse(UserDataRow["RoleID"].ToString()) : 0);
			TheUser.RoleDescription = UserDataRow["RoleDescription"].ToString();

			TheUser.UserType = UserDataRow["UserType"].ToString();
			if (!string.IsNullOrEmpty(UserDataRow["UserReferenceID"].ToString()))
			{
				TheUser.UserReferenceID = int.Parse(UserDataRow["UserReferenceID"].ToString());
			}
            if (!string.IsNullOrEmpty(UserDataRow["ImageUrl_Smallest"].ToString()))
			{
                TheUser.ImageUrl_Smallest = UserDataRow["ImageUrl_Smallest"].ToString();
			}
            

			//TheUser.UserReferenceName = UserDataRow["UserReferenceName"].ToString();
            TheUser.CompanyID = int.Parse(UserDataRow["CompanyID"].ToString());
			TheUser.CompanyCode = UserDataRow["CompanyCode"].ToString();
			TheUser.CompanyName = UserDataRow["CompanyName"].ToString();

			return TheUser;
		}

		public static User GetUserByLoginCredentials(User theUser)
		{
			DataRow UserDataRow = UserDataAccess.GetInstance.GetUserByLoginCredentials(theUser);
			User TheUser = DataRowToObject(UserDataRow);

			return TheUser;
		}

		public static string GeneratePassword()
		{
			try
			{
				return UserDataAccess.GetInstance.GeneratePassword()[0].ToString();
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public static int UpdateUserPassword(User theUser)
		{
			return UserDataAccess.GetInstance.UpdateUserPassword(theUser);
		}

		public static int UpdateUserRole(User theUser)
		{
			return UserDataAccess.GetInstance.UpdateUserRole(theUser);
		}

		public static int InsertUser(User theUser)
		{
			return UserDataAccess.GetInstance.InsertUser(theUser);
		}

        public static int UpdateUser(User theUser)
        {
            return UserDataAccess.GetInstance.UpdateUser(theUser);
        }
		public static int DeleteUser(int UserID)
		{
			try
			{
				return UserDataAccess.GetInstance.DeleteUser(UserID);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}


		public static int InsertUserPageVisit(int logId, int pageId)
		{
			return UserDataAccess.GetInstance.InsertUserPageVisit(logId, pageId);
		}

		public static void UpdateUserPageVisit(int recordId)
		{
			UserDataAccess.GetInstance.UpdateUserPageVisit(recordId);
		}

        //public static List<ErrorLog> GetErrorLogs()
        //{
        //    DataTable TheErrorLogTable = UserDataAccess.GetInstance.GetErrorLogs();
        //    List<ErrorLog> TheErrorLogList = new List<ErrorLog>();
        //    foreach (DataRow dr in TheErrorLogTable.Rows)
        //    {
        //        ErrorLog objErroLog = new ErrorLog();

                
        //        objErroLog.ErrorRecordID = Int64.Parse(dr["ErrorRecordID"].ToString());
        //        if (!string.IsNullOrEmpty(dr["ErrorDate"].ToString()))
        //        {
        //            objErroLog.ErrorDate = DateTime.Parse(dr["ErrorDate"].ToString());
        //        }
        //        objErroLog.Ticket = dr["Ticket"].ToString();
        //        objErroLog.Environment = dr["Environment"].ToString();
        //        objErroLog.ThePage = dr["ThePage"].ToString();
        //        objErroLog.TheMessage = dr["TheMessage"].ToString();
        //        objErroLog.TheInnerMessage = dr["TheInnerMessage"].ToString();
        //        objErroLog.ErrorStack = dr["ErrorStack"].ToString();
        //        objErroLog.UserDomain = dr["UserDomain"].ToString();
        //        objErroLog.Language = dr["Language"].ToString();
        //        objErroLog.TargetSite = dr["TargetSite"].ToString();
        //        objErroLog.TheClass = dr["TheClass"].ToString();
        //        objErroLog.TheUserAgent = dr["TheUserAgent"].ToString();
        //        objErroLog.TypeLog = dr["TypeLog"].ToString();
        //        if (!string.IsNullOrEmpty(dr["UserId"].ToString()))
        //        {
        //            objErroLog.UserID = int.Parse(dr["UserId"].ToString());
        //        }
        //        if (!string.IsNullOrEmpty(dr["OfficeId"].ToString()))
        //        {
        //            objErroLog.OfficeID = int.Parse(dr["OfficeId"].ToString());
        //        }

        //        TheErrorLogList.Add(objErroLog);
        //    }
        //    return TheErrorLogList;
        //}
		#endregion
	}
}
