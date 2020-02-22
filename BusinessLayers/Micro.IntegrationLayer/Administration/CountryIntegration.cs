using System;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class CountryIntegration
	{
		#region Methods & Implementation
		public static Country DataRowToObject(DataRow dr)
		{
			Country TheCountry = new Country
			{
				CountryID = int.Parse(dr["CountryID"].ToString()),
				CountryName = dr["CountryName"].ToString(),
				CapitalName = dr["CapitalName"].ToString(),
				IsActive = bool.Parse(dr["IsActive"].ToString()),
				IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
			};

			return TheCountry;
		}

		public static List<Country> GetCountryList(string searchText, bool showDeleted = false)
		{
			List<Country> CountryList = new List<Country>();
			DataTable CountryTable =CountryDataAccess.GetInstance.GetCountryList(searchText, showDeleted);

			foreach(DataRow dr in CountryTable.Rows)
			{
				Country TheCountry = DataRowToObject(dr);

				CountryList.Add(TheCountry);
			}

			return CountryList;
		}

		public static Country GetCountryById(int countryId)
		{
			DataRow CountryRow = CountryDataAccess.GetInstance.GetCountryById(countryId);
			Country TheCountry = DataRowToObject(CountryRow);

			return TheCountry;
		}

		public static int InsertCountry(Country theCountry)
		{
			return CountryDataAccess.GetInstance.InsertCountry(theCountry);
		}

		public static int UpdateCountry(Country theCountry)
		{
			return CountryDataAccess.GetInstance.UpdateCountry(theCountry);
		}

		public static int DeleteCountry(int countryId)
		{
			return CountryDataAccess.GetInstance.DeleteCountry(countryId);
		}
		#endregion
	}
}
