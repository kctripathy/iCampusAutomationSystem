using System;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.HumanResource;
using Micro.Objects.HumanResource;
using System.Linq;


namespace Micro.IntegrationLayer.HumanResource
{
    public partial class EmployeeProfileIntegration
    {
        #region Declaration
        #endregion

		#region Methods & Implementation

		public static List<EmployeeProfile> GetEmployeeProfilesList()
		{
			List<EmployeeProfile> EmployeeProfileList = new List<EmployeeProfile>();

			DataTable EmployeeProfileTable = EmployeeProfileDataAccess.GetInstance.GetEmployeeProfilesList();

			foreach (DataRow dr in EmployeeProfileTable.Rows)
			{
				EmployeeProfile TheEmployeeProfile = DataRowToObject(dr);

				EmployeeProfileList.Add(TheEmployeeProfile);
			}

			return EmployeeProfileList;
		}

		public static EmployeeProfile GetEmployeeProfileByID(int employeeProfileID)
		{
			DataRow EmployeeProfileRow = EmployeeProfileDataAccess.GetInstance.GetEmployeeProfileByID(employeeProfileID);

			EmployeeProfile TheEmployeeProfile = DataRowToObject(EmployeeProfileRow);

			return TheEmployeeProfile;
		}
	
		public static EmployeeProfile DataRowToObject(DataRow dr)
		{
			EmployeeProfile TheEmployeeProfile = new EmployeeProfile();

			TheEmployeeProfile.EmployeeProfilleID = int.Parse(dr["EmployeeProfileID"].ToString());

			TheEmployeeProfile.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
			TheEmployeeProfile.EmployeeCode = dr["EmployeeCode"].ToString();
			TheEmployeeProfile.EmployeeName = dr["EmployeeName"].ToString();
			TheEmployeeProfile.SettingKeyName = dr["SettingKeyName"].ToString();
			TheEmployeeProfile.SettingKeyID = int.Parse(dr["SettingKeyID"].ToString());

			TheEmployeeProfile.CommonKeyValue = dr["CommonKeyValue"].ToString();

			if (dr["SettingKeyValue"].ToString() != "")
			{
				TheEmployeeProfile.SettingKeyValue = (byte[])dr["SettingKeyValue"];
				//ImageFunctions.ByteToImage((Byte[])(DtRow["SettingKeyValue"]));
			}

			TheEmployeeProfile.SettingKeyDescription = dr["SettingKeyDescription"].ToString();

			TheEmployeeProfile.IsActive = Boolean.Parse(dr["IsActive"].ToString());
			TheEmployeeProfile.IsDeleted = Boolean.Parse(dr["IsDeleted"].ToString());

			return TheEmployeeProfile;
		}

		public static List<EmployeeProfile> GetEmployeeProfileByEmployeeID(int employeeID)
		{
			List<EmployeeProfile> EmployeeProfileList = new List<EmployeeProfile>();

			DataTable EmployeeProfileTable = EmployeeProfileDataAccess.GetInstance.GetEmployeeProfileByEmployeeID(employeeID);

			foreach (DataRow dr in EmployeeProfileTable.Rows)
			{
				EmployeeProfile TheEmployeeProfile = DataRowToObject(dr);

				EmployeeProfileList.Add(TheEmployeeProfile);
			}

			return EmployeeProfileList;
		}

		public static EmployeeProfile GetEmployeeProfileBySettingKeyID(int employeeId, int settingKeyID)
		{
			EmployeeProfile TheEmployeeProfile;
			try
			{
				List<EmployeeProfile> EmployeeProfileList = GetEmployeeProfileByEmployeeID(employeeId);

				if (EmployeeProfileList.Count > 0)
					TheEmployeeProfile = (from EmployeeProfileTable in EmployeeProfileList
										  where EmployeeProfileTable.SettingKeyID == settingKeyID 
										  select EmployeeProfileTable).Last();
				else
					TheEmployeeProfile = new EmployeeProfile();
			}
			catch
			{
				TheEmployeeProfile = new EmployeeProfile();
			}

			return TheEmployeeProfile;
		}

		public static int InsertEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			return EmployeeProfileDataAccess.GetInstance.InsertEmployeeProfile(theEmployeeProfile);
		}

		public static int UpdateEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			return EmployeeProfileDataAccess.GetInstance.UpdateEmployeeProfile(theEmployeeProfile);
		}

		public static int DeleteEmployeeProfile(EmployeeProfile theEmployeeProfile)
		{
			return EmployeeProfileDataAccess.GetInstance.DeleteEmployeeProfile(theEmployeeProfile);
		}

		#endregion
    }
}
