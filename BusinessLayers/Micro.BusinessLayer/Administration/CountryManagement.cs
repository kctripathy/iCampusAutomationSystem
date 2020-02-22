using System.Collections.Generic;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;
using System.Web;

namespace Micro.BusinessLayer.Administration
{
	public partial class CountryManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static CountryManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static CountryManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new CountryManagement();
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
		public string DefaultColumns = "CountryName, CapitalName, IsDeleted";
		public string DisplayMember = "CountryName";
		public string ValueMember="CountryID";
		#endregion

		#region Methods & Implementation
		public List<Country> GetCountryList(string searchText = "", bool showDeleted = false)
		{
			//return CountryIntegration.GetCountryList(searchText, showDeleted);
            string UniqueKey = "CountryList";
            if (HttpRuntime.Cache[UniqueKey] == null)
            {
                List<Country> CountryList = CountryIntegration.GetCountryList(searchText, showDeleted);
                HttpRuntime.Cache[UniqueKey] = CountryList;
            }
            return (List<Country>)(HttpRuntime.Cache[UniqueKey]);
		
		}

		public Country GetCountryById(int countryId)
		{
			return CountryIntegration.GetCountryById(countryId);
		}

		public int InsertCountry(Country theCountry)
		{
			return CountryIntegration.InsertCountry(theCountry);
		}

		public int UpdateCountry(Country countryObject)
		{
			return CountryIntegration.UpdateCountry(countryObject);
		}

		public int DeleteCountry(int countryId)
		{
			return CountryIntegration.DeleteCountry(countryId);
		}
		#endregion
	}
}
