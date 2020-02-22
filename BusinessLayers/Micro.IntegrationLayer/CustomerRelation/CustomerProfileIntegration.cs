using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class CustomerProfileIntegration
	{
		#region Declaration
		#endregion

		#region Methods & Implementation
		public static CustomerProfile DataRowToObject(DataRow dr)
		{
			CustomerProfile TheCustomerProfile = new CustomerProfile
			{
				CustomerProfileID = int.Parse(dr["CustomerProfileID"].ToString()),
				CustomerID = int.Parse(dr["CustomerID"].ToString()),
                CustomerName = dr["CustomerName"].ToString(),
				SettingKeyName = dr["SettingKeyName"].ToString(),
				SettingKeyDescription = dr["SettingKeyDescription"].ToString(),
				SettingKeyValue = (byte[])dr["SettingKeyValue"],
				SettingKeyReference = dr["SettingKeyReference"].ToString()
			};

			return TheCustomerProfile;
		}

		public static List<CustomerProfile> GetCustomerProfileList(string searchText)
		{
			List<CustomerProfile> CustomerProfileList = new List<CustomerProfile>();

			DataTable CustomerProfileTable = CustomerProfileDataAccess.GetInstance.GetCustomerProfileList(searchText);

			foreach(DataRow dr in CustomerProfileTable.Rows)
			{
				CustomerProfile TheCustomerProfile = DataRowToObject(dr);

				CustomerProfileList.Add(TheCustomerProfile);
			}

			return CustomerProfileList;
		}

		public static CustomerProfile GetCustomerProfileByID(int customerProfileID)
		{
			DataRow CustomerGetCustomerProfileByIdsRow = CustomerProfileDataAccess.GetInstance.GetCustomerProfileByID(customerProfileID); 

			CustomerProfile TheCustomerProfile = DataRowToObject(CustomerGetCustomerProfileByIdsRow);

			return TheCustomerProfile;
		}

		public static List<CustomerProfile> GetCustomerProfileByCustomerID(int customerID)
		{
			List<CustomerProfile> CustomerProfileList = new List<CustomerProfile>();

			DataTable CustomerProfileTable = CustomerProfileDataAccess.GetInstance.GetCustomerProfileByCustomerID(customerID); 

			foreach(DataRow dr in CustomerProfileTable.Rows)
			{
				CustomerProfile TheCustomerProfile = DataRowToObject(dr);

				CustomerProfileList.Add(TheCustomerProfile);
			}

			return CustomerProfileList;
		}

		public static CustomerProfile GetCustomerProfileBySettingKeyName(int customerID, string settingKeyName, string settingKeyDescription)
		{
			CustomerProfile TheCustomerProfile;
			
			try
			{
				List<CustomerProfile> CustomerProfileList = GetCustomerProfileByCustomerID(customerID);

				if(CustomerProfileList.Count > 0)
					TheCustomerProfile = (from CustomerProfileTable in CustomerProfileList
										  where CustomerProfileTable.SettingKeyName == settingKeyName && CustomerProfileTable.SettingKeyDescription == settingKeyDescription
										  select CustomerProfileTable).Last();
				else
					TheCustomerProfile = new CustomerProfile();
			}
			catch
			{
				TheCustomerProfile = new CustomerProfile();
			}

			return TheCustomerProfile;
		}

		public static int InsertCustomerProfile(CustomerProfile theCustomerProfile)
		{
			return CustomerProfileDataAccess.GetInstance.InsertCustomerProfile(theCustomerProfile);
		}

		public static int UpdateCustomerProfile(CustomerProfile theCustomerProfile)
		{
			return CustomerProfileDataAccess.GetInstance.UpdateCustomerProfile(theCustomerProfile);
		}

		public static int DeleteCustomerProfile(CustomerProfile theCustomerProfile)
		{
			return CustomerProfileDataAccess.GetInstance.DeleteCustomerProfile(theCustomerProfile);
		}
		#endregion
	}
}
