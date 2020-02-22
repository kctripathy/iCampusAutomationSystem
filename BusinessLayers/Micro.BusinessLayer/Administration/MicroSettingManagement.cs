using System.Collections.Generic;
using Micro.Commons;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
	public partial class MicroSettingManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static MicroSettingManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static MicroSettingManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new MicroSettingManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		#region Methods & Implementation
		public List<MicroSetting> GetSettingList()
		{
			return MicroSettingIntegration.GetSettingList();
		}

		public MicroSetting GetSettingByName(string settingKeyName, int moduleID)
		{
			return MicroSettingIntegration.GetSettingByName(settingKeyName, moduleID);
		}

		public decimal GetSettingValue(string settingKeyName, int moduleID)
		{
			decimal ReturnValue = 0;

			MicroSetting TheSetting = GetSettingByName(settingKeyName, moduleID);

			if(TheSetting.SettingID > 0)
			{
				if(TheSetting.SettingDataType == MicroEnums.GetStringValue(MicroEnums.SettingDataType.Decimal))
					ReturnValue = decimal.Parse(TheSetting.SettingValue);

				else if(TheSetting.SettingDataType == MicroEnums.GetStringValue(MicroEnums.SettingDataType.Percentage))
					ReturnValue = (decimal.Parse(TheSetting.SettingValue) / 100);
			}

			return ReturnValue;
		}
		#endregion
	}
}
