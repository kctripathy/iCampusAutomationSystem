using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class CustomerProfile
	{
		public int CustomerProfileID
		{
			get;
			set;
		}

		public int CustomerID
		{
			get;
			set;
		}

		public string CustomerName
		{
			get;
			set;
		}

		public string SettingKeyName
		{
			get;
			set;
		}

		public string SettingKeyDescription
		{
			get;
			set;
		}

		public byte[] SettingKeyValue
		{
			get;
			set;
		}

		public string SettingKeyReference
		{
			get;
			set;
		}

		public string ImageUrl
		{
			get;
			set;
		}

		public int OfficeID
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
