using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class MicroSettingIntegration
	{
		#region Method & Implementation
		private static MicroSetting DataRowToObject(DataRow dr)
		{
			MicroSetting TheSetting;

			if(dr != null)
			{
				TheSetting = new MicroSetting
				{
					SettingID = int.Parse(dr["SettingID"].ToString()),
					SettingKeyID = int.Parse(dr["SettingKeyID"].ToString()),
					SettingKeyName = dr["SettingKeyName"].ToString(),
					SettingKeyModuleID = int.Parse(dr["SettingKeyModuleID"].ToString()),
					SettingKeyModuleName = dr["SettingKeyModuleName"].ToString(),
					SettingDataType = dr["SettingDataType"].ToString(),
					SettingValue = dr["SettingValue"].ToString(),
					EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat)
				};
			}
			else
				TheSetting = new MicroSetting();

			return TheSetting;
		}

		public static List<MicroSetting> GetSettingList()
		{
			List<MicroSetting> TheSettingList = new List<MicroSetting>();
			DataTable TheSettingTable = MicroSettingDataAccess.GetInstance.GetSettingList();

			foreach(DataRow dr in TheSettingTable.Rows)
			{
				MicroSetting TheSetting = DataRowToObject(dr);

				TheSettingList.Add(TheSetting);
			}

			return TheSettingList;
		}

		public static MicroSetting GetSettingByName(string settingKeyName, int moduleID)
		{
			MicroSetting TheSetting;
			List<MicroSetting> TheSettingList = GetSettingList();

			if(TheSettingList.Count > 0)
			{
				TheSetting = (from MicroSettings in TheSettingList
							  where MicroSettings.SettingKeyName == settingKeyName && MicroSettings.SettingKeyModuleID == moduleID
							  orderby MicroSettings.EffectiveDateFrom
							  select MicroSettings).Last();
			}
			else
			{
				TheSetting = new MicroSetting();
			}

			return TheSetting;
		}
		#endregion
	}
}
