using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class CrmSettingManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CrmSettingManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CrmSettingManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CrmSettingManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string SettingDefaultColumns = "SettingID , SettingKeyID ,SettingKeyName , SettingValue , EffectiveDateFrom ";
        public string SettingKeyDefaultColumns = "SettingKeyID, SettingKeyName, SettingKeyModuleID";
        public string DisplayMember = "SettingKeyName";
        public string ValueMember = "SettingKeyID";
        #endregion

        #region Methods & Implementation
        public List<CrmSetting> GetCrmSettingList(string SearchText, bool showDeleted = false)
        {
            return CrmSettingIntegration.GetCrmSettingList(SearchText,showDeleted);
        }

        public List<CrmSetting> GetSettingKeyList(string searchText)
        {
            return CrmSettingIntegration.GetSettingKeyList(searchText);
        }

        public CrmSetting GetCrmSettingById(int SettingID)
        {
            return CrmSettingIntegration.GetCrmSettingById(SettingID);
        }

        public int InsertSetting(CrmSetting TheCrmSetting)
        {
            return CrmSettingIntegration.InsertSetting(TheCrmSetting);
        }

        public int UpdateSetting(CrmSetting theCrmSetting)
        {
            return CrmSettingIntegration.UpdateSetting(theCrmSetting);
        }

        public int DeleteSetting(CrmSetting theCrmSetting)
        {
            return CrmSettingIntegration.DeleteSetting(theCrmSetting);
        }

        #endregion
    }
}
