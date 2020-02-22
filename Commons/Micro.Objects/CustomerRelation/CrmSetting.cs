using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class CrmSetting
    {
        public int SettingID
        {
            get;
            set;
        }

        public int SettingKeyID
        {
            get;
            set;
        }

        public string SettingKeyName
        {
            get;
            set;
        }

        public int SettingKeyModuleID
        {
            get;
            set;
        }

        public string SettingDataType
        {
            get;
            set;
        }
        
        public string SettingValue
        {
            get;
            set;
        }

        public string EffectiveDateFrom
        {
            get;
            set;
        }
         
        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
    }
}
