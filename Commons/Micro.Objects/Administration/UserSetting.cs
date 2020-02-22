using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class UserSetting
    {
        public int UserSettingID
        {
            get;
            set;
        }

        public int UserSettingKeyID
        {
            get;
            set;
        }

        public string UserSettingKeyName
        {
            get;
            set;
        }

        public string UserSettingKeyDescription
        {
            get;
            set;
        }

        public string UserSettingValue
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }
    }
}
