using System.Collections.Generic;
using Micro.Commons;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class FieldForceProfileManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static FieldForceProfileManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static FieldForceProfileManagement GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new FieldForceProfileManagement();
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
		public string DefaultColumns = "FieldForceCode, FieldForceName, SettingKeyName, SettingKeyDescription, SettingKeyReference,SettingKeyValue";
		public string DisplayMember = "FieldForceName";
		public string ValueMember = "FieldForceProfileID";
		#endregion

		#region Methods & Implementation
		public List<FieldForceProfile> GetFieldForceProfileList()
		{
			return FieldForceProfileIntegration.GetFieldForceProfileList();
		}

		public FieldForceProfile GetFieldForceProfileByID(int fieldForceProfileID)
		{
			return FieldForceProfileIntegration.GetFieldForceProfileByID(fieldForceProfileID);
		}

		public List<FieldForceProfile> GetFieldForceProfileByFieldForceID(int fieldForceID)
		{
			return FieldForceProfileIntegration.GetFieldForceProfileByFieldForceID(fieldForceID);
		}

		public List<FieldForceProfile> GetFieldForceProfileImageByFieldForceID(int fieldForceID)
		{
			List<FieldForceProfile> FieldForceProfileList = GetFieldForceProfileByFieldForceID(fieldForceID);

			foreach (FieldForceProfile EachProfile in FieldForceProfileList)
			{
				EachProfile.ImageUrl = BasePage.GetProfileImageUrl(EachProfile.FieldForceID.ToString(), EachProfile.SettingKeyName, EachProfile.SettingKeyDescription);
			}

			return FieldForceProfileList;
		}

		public FieldForceProfile GetFieldForceProfileBySettingKeyName(int fieldForceId, string settingKeyName, string settingKeyDescription)
		{
			return FieldForceProfileIntegration.GetFieldForceProfileBySettingKeyName(fieldForceId, settingKeyName, settingKeyDescription);
		}

		public int InsertFieldForceProfile(FieldForceProfile theFieldForceProfile)
		{
			return FieldForceProfileIntegration.InsertFieldForceProfile(theFieldForceProfile);
		}

		public int UpdateFieldForceProfile(FieldForceProfile theFieldForceProfile)
		{
			return FieldForceProfileIntegration.UpdateFieldForceProfile(theFieldForceProfile);
		}

		public int DeleteFieldForceProfile(FieldForceProfile theFieldForceProfile)
		{
			return FieldForceProfileIntegration.DeleteFieldForceProfile(theFieldForceProfile);
		}
		#endregion
	}
}
