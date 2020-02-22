using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class FieldForceProfileIntegration
	{
		#region Methods & Implementation
		public static FieldForceProfile DataRowToObject(DataRow dr)
		{
			FieldForceProfile TheFieldForceProfile = new FieldForceProfile();

			TheFieldForceProfile.FieldForceProfileID = int.Parse(dr["FieldForceProfileID"].ToString());
			TheFieldForceProfile.FieldForceID = int.Parse(dr["FieldForceID"].ToString());
			TheFieldForceProfile.FieldForceCode = dr["FieldForceCode"].ToString();
			TheFieldForceProfile.FieldForceName = dr["FieldForceName"].ToString();
			TheFieldForceProfile.SettingKeyName = dr["SettingKeyName"].ToString();
			TheFieldForceProfile.SettingKeyDescription = dr["SettingKeyDescription"].ToString();
			if(!string.IsNullOrEmpty(dr["SettingKeyValue"].ToString()))
			{
				TheFieldForceProfile.SettingKeyValue = (byte[])dr["SettingKeyValue"];
			}
			TheFieldForceProfile.SettingKeyReference = dr["SettingKeyReference"].ToString();

			return TheFieldForceProfile;
		}

		public static List<FieldForceProfile> GetFieldForceProfileList()
		{
			List<FieldForceProfile> FieldForceProfileList = new List<FieldForceProfile>();

			DataTable FieldForceProfileTable = FieldForceProfileDataAccess.GetInstance.GetFieldForceProfileList();

			foreach(DataRow dr in FieldForceProfileTable.Rows)
			{
				FieldForceProfile TheFieldForceProfile = DataRowToObject(dr);

				FieldForceProfileList.Add(TheFieldForceProfile);
			}

			return FieldForceProfileList;
		}

		public static FieldForceProfile GetFieldForceProfileByID(int fieldForceProfileID)
		{
			DataRow FieldForceProfileRow = FieldForceProfileDataAccess.GetInstance.GetFieldForceProfileByID(fieldForceProfileID);

			FieldForceProfile TheFieldForceProfile = DataRowToObject(FieldForceProfileRow);

			return TheFieldForceProfile;
		}

		public static List<FieldForceProfile> GetFieldForceProfileByFieldForceID(int fieldForceID)
		{
			List<FieldForceProfile> FieldForceProfileList = new List<FieldForceProfile>();

			DataTable FieldForceProfileTable = FieldForceProfileDataAccess.GetInstance.GetFieldForceProfileByFieldForceID(fieldForceID);

			foreach(DataRow dr in FieldForceProfileTable.Rows)
			{
				FieldForceProfile TheFieldForceProfile = DataRowToObject(dr);

				FieldForceProfileList.Add(TheFieldForceProfile);
			}

			return FieldForceProfileList;
		}

		public static FieldForceProfile GetFieldForceProfileBySettingKeyName(int fieldForceId, string settingKeyName, string settingKeyDescription)
		{
			FieldForceProfile TheFieldForceProfile;
            try
            {
                List<FieldForceProfile> FieldForceProfileList = GetFieldForceProfileByFieldForceID(fieldForceId);

                if (FieldForceProfileList.Count > 0)
                    TheFieldForceProfile = (from FieldForceProfileTable in FieldForceProfileList
                                            where FieldForceProfileTable.SettingKeyName == settingKeyName && FieldForceProfileTable.SettingKeyDescription == settingKeyDescription
                                            select FieldForceProfileTable).Last();
                else
                    TheFieldForceProfile = new FieldForceProfile();
            }
            catch
            {
                TheFieldForceProfile = new FieldForceProfile();
            }

			return TheFieldForceProfile;
		}

		public static int InsertFieldForceProfile(FieldForceProfile theFieldForceProfile)
		{
			return FieldForceProfileDataAccess.GetInstance.InsertFieldForceProfile(theFieldForceProfile);
		}

		public static int UpdateFieldForceProfile(FieldForceProfile theFieldForceProfile)
		{
			return FieldForceProfileDataAccess.GetInstance.UpdateFieldForceProfile(theFieldForceProfile);
		}

		public static int DeleteFieldForceProfile(FieldForceProfile theFieldForceProfile)
		{
			return FieldForceProfileDataAccess.GetInstance.DeleteFieldForceProfile(theFieldForceProfile);
		}
		#endregion
	}
}
