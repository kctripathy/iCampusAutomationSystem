using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;
using Micro.Commons;

namespace Micro.IntegrationLayer.Administration
{
	public partial class UserIntegration
	{
		public static UserSetting UserSettingKeyDataRowToObject(DataRow dr)
		{
			UserSetting TheUserSetting = new UserSetting
			{
				UserSettingKeyID = int.Parse(dr["UserSettingKeyID"].ToString()),
				UserSettingKeyName = dr["UserSettingKeyName"].ToString(),
				UserSettingKeyDescription = dr["UserSettingKeyDescription"].ToString(),
			};

			return TheUserSetting;
		}

		public static UserSetting UserSettingDataRowToObject(DataRow dr)
		{
			UserSetting TheUserSetting = new UserSetting
			{
				UserSettingKeyID = int.Parse(dr["UserSettingKeyID"].ToString()),
				UserSettingKeyName = dr["UserSettingKeyName"].ToString(),
				UserSettingKeyDescription = dr["UserSettingKeyDescription"].ToString(),
				UserSettingID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["UserSettingID"].ToString())),
				UserSettingValue = dr["UserSettingValue"].ToString(),
				UserID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["UserID"].ToString())),
			};

			return TheUserSetting;
		}

		public static List<UserSetting> GetUserSettingKeyList()
		{
			List<UserSetting> UserSettingList = new List<UserSetting>();
			DataTable UserSettingTable = UserDataAccess.GetInstance.GetUserSettingKeyList();

			foreach (DataRow dr in UserSettingTable.Rows)
			{
				UserSetting TheUserSetting = UserSettingKeyDataRowToObject(dr);

				UserSettingList.Add(TheUserSetting);
			}

			return UserSettingList;
		}

		public static List<UserSetting> GetUserSettingList()
		{
			List<UserSetting> UserSettingList = new List<UserSetting>();
			DataTable UserSettingTable = UserDataAccess.GetInstance.GetUserSettingList();

			foreach (DataRow dr in UserSettingTable.Rows)
			{
				UserSetting TheUserSetting = UserSettingDataRowToObject(dr);

				UserSettingList.Add(TheUserSetting);
			}

			return UserSettingList;
		}

		public static List<UserSetting> GetUserSettingListByUserID()
		{
			List<UserSetting> UserSettingList = new List<UserSetting>();
			DataTable UserSettingTable = UserDataAccess.GetInstance.GetUserSettingListByUserID();

			foreach (DataRow dr in UserSettingTable.Rows)
			{
				UserSetting TheUserSetting = UserSettingDataRowToObject(dr);

				UserSettingList.Add(TheUserSetting);
			}

			return UserSettingList;
		}

		public static List<UserSetting> GetUserSettingListByUserID(int userId)
		{
			List<UserSetting> UserSettingList = new List<UserSetting>(userId);
			DataTable UserSettingTable = UserDataAccess.GetInstance.GetUserSettingListByUserID(userId);

			foreach (DataRow dr in UserSettingTable.Rows)
			{
				UserSetting TheUserSetting = UserSettingDataRowToObject(dr);

				UserSettingList.Add(TheUserSetting);
			}

			return UserSettingList;
		}

		public static int SaveUserSettings(string settingKey, string settingValue)
		{
			return UserDataAccess.GetInstance.SaveUserSettings(settingKey, settingValue);
		}

		public static void SaveUserSettings(List<UserSetting> UserSettingList)
		{
			UserDataAccess.GetInstance.SaveUserSettings(UserSettingList);
		}

		public static void DeleteAllUserSettings()
		{
			UserDataAccess.GetInstance.DeleteAllUserSettings();
		}
	}
}
