using System.Collections.Generic;
using Micro.Commons;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class CustomerProfileManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static CustomerProfileManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static CustomerProfileManagement GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new CustomerProfileManagement();
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
		public string DefaultColumns = "SettingKeyName, SettingKeyDescription,SettingKeyReference, SettingKeyValue";
		public string DisplayMember = "CustomerName";
		public string ValueMember = "CustomerProfileID";
		#endregion

		#region Methods & Implementation
		public List<CustomerProfile> GetCustomerProfileList(string searchText)
		{
			return CustomerProfileIntegration.GetCustomerProfileList(searchText);
		}

		public CustomerProfile GetCustomersProfileByID(int customerProfileID)
		{
			return CustomerProfileIntegration.GetCustomerProfileByID(customerProfileID);
		}

		public List<CustomerProfile> GetCustomerProfileByCustomerID(int customerID)
		{
			return CustomerProfileIntegration.GetCustomerProfileByCustomerID(customerID);
		}

		public List<CustomerProfile> GetCustomerProfileImageByCustomerID(int customerID)
		{
			List<CustomerProfile> CustomerProfileList = GetCustomerProfileByCustomerID(customerID);

			foreach (CustomerProfile EachProfile in CustomerProfileList)
			{
				EachProfile.ImageUrl = BasePage.GetProfileImageUrl(EachProfile.CustomerID.ToString(), EachProfile.SettingKeyName, EachProfile.SettingKeyDescription);
			}

			return CustomerProfileList;
		}

		public CustomerProfile GetCustomerProfileBySettingKeyName(int customerID, string settingKeyName, string settingKeyDescription)
		{
			return CustomerProfileIntegration.GetCustomerProfileBySettingKeyName(customerID, settingKeyName, settingKeyDescription);
		}

		public int InsertCustomerProfile(CustomerProfile theCustomerProfile)
		{
			return CustomerProfileIntegration.InsertCustomerProfile(theCustomerProfile);
		}

		public int UpdateCustomerProfile(CustomerProfile theCustomerProfile)
		{
			return CustomerProfileIntegration.UpdateCustomerProfile(theCustomerProfile);
		}

		public int DeleteCustomerProfile(CustomerProfile theCustomerProfile)
		{
			return CustomerProfileIntegration.DeleteCustomerProfile(theCustomerProfile);
		}
		#endregion
	}
}
