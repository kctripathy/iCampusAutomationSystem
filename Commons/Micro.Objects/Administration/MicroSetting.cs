using System;

namespace Micro.Objects.Administration
{
	[Serializable]
	public class MicroSetting
	{
		public int SettingID
		{
			get;set;
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

		public string SettingKeyModuleName
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
	}
}
