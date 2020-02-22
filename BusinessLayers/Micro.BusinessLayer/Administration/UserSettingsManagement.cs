using System.Collections.Generic;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
    public partial class UserManagement
    {
        public List<UserSetting> GetUserSettingList()
        {
			return UserIntegration.GetUserSettingList();
        }

        public List<UserSetting> GetUserSettingListByUserID()
		{
			return UserIntegration.GetUserSettingListByUserID();
		}

		public List<UserSetting> GetUserSettingListByUserID(int userId)
		{
			return UserIntegration.GetUserSettingListByUserID(userId);
		}

        public int SaveUserSettings(string settingKey, string settingValue)
        {
            return UserIntegration.SaveUserSettings(settingKey, settingValue);
        }

        public void SaveUserSettings(List<UserSetting> userSettingList)
        {
            UserIntegration.SaveUserSettings(userSettingList);
        }

        public void DeleteAllUserSettings()
        {
            UserIntegration.DeleteAllUserSettings();
        }
    }
}
