using System;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class CrmSettingIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static List<CrmSetting> GetCrmSettingList(string SearchText, bool showDeleted = false)
        {
            List<CrmSetting> CrmSettingList = new List<CrmSetting>();

            DataTable CrmSettingTable = new DataTable();
            CrmSettingTable = CrmSettingDataAccess.GetInstance.GetCrmSettingList(SearchText, showDeleted);
            
            foreach (DataRow dr in CrmSettingTable.Rows)
            {
                CrmSetting TheCrmSetting = new CrmSetting();

                TheCrmSetting.SettingID = int.Parse(dr["SettingID"].ToString());
                TheCrmSetting.SettingKeyName = dr["SettingKeyName"].ToString();
                TheCrmSetting.SettingValue = dr["SettingValue"].ToString();
                TheCrmSetting.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(Micro.Commons.MicroConstants.DateFormat);

                CrmSettingList.Add(TheCrmSetting);
            }

            return CrmSettingList;
        }

        public static List<CrmSetting> GetSettingKeyList(string searchText)
        {
            List<CrmSetting> CrmSettingKeyList = new List<CrmSetting>();

            DataTable GetCrmSettingKeyTable = new DataTable();
            GetCrmSettingKeyTable = CrmSettingDataAccess.GetInstance.GetSettingKeyList(searchText);

            foreach (DataRow dr in GetCrmSettingKeyTable.Rows)
            {
                CrmSetting TheCrmSettingKey = new CrmSetting();

                TheCrmSettingKey.SettingKeyID = int.Parse(dr["SettingKeyID"].ToString());
                TheCrmSettingKey.SettingKeyName = dr["SettingKeyName"].ToString();

                CrmSettingKeyList.Add(TheCrmSettingKey);
            }

            return CrmSettingKeyList;
        }

        public static CrmSetting GetCrmSettingById(int SettingID)
        {
            DataRow CrmSettingRow = CrmSettingDataAccess.GetInstance.GetCrmSettingById(SettingID);

            CrmSetting TheCrmSetting = new CrmSetting();
            TheCrmSetting.SettingID = int.Parse(CrmSettingRow["SettingID"].ToString());
            TheCrmSetting.SettingDataType = CrmSettingRow["SettingDataType"].ToString();
            TheCrmSetting.SettingKeyID = int.Parse(CrmSettingRow["SettingKeyID"].ToString());
            TheCrmSetting.SettingValue = CrmSettingRow["SettingValue"].ToString();
            TheCrmSetting.EffectiveDateFrom = DateTime.Parse(CrmSettingRow["EffectiveDateFrom"].ToString()).ToString(Micro.Commons.MicroConstants.DateFormat);

            return TheCrmSetting;
        }

        public static int InsertSetting(CrmSetting TheCrmSetting)
        {
            return (CrmSettingDataAccess.GetInstance.InsertSetting(TheCrmSetting));
        }

        public static int UpdateSetting(CrmSetting theCrmSetting)
        {
            return CrmSettingDataAccess.GetInstance.UpdateSetting(theCrmSetting);
        }

        public static int DeleteSetting(CrmSetting theCrmSetting)
        {
            return CrmSettingDataAccess.GetInstance.DeleteSetting(theCrmSetting);
        }
        #endregion
    }
   
}
