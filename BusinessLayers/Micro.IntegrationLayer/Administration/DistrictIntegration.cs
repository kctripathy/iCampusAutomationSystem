using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using System.Data;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public class DistrictIntegration
	{
		public static List<District> GetDistrictListByStateId(int stateId, bool showDeleted = false)
		{
			string Context = "Micro.IntegrationLayer.Administration.DistrictIntegration.GetDistrictListByStateId";
			try
			{
				List<District> DistrictList = new List<District>();
				DataTable DistrictDataTable = DistrictDataAccess.GetInstance.GetDistrictListByStateId(stateId);
				foreach(DataRow dRow in DistrictDataTable.Rows)
				{
					District s = new District();
					s.DistrictID = int.Parse(dRow["DistrictID"].ToString());
					s.CountryName = dRow["DistrictName"].ToString();
					DistrictList.Add(s);
				}
				return DistrictList;
			}
			catch(Exception ex)
			{
				throw (new Exception(Context, ex));
			}
		}

		public static District GetDistrictStateCountryByDistrictId(int districtId)
		{
			District TheDistrict = new District();
			DataRow TheDistrictRow = DistrictDataAccess.GetInstance.GetDistrictStateCountryByDistrictId(districtId);

			TheDistrict.DistrictID = int.Parse(TheDistrictRow["DistrictID"].ToString());
			TheDistrict.DistrictName = TheDistrictRow["DistrictName"].ToString();
			TheDistrict.StateID = int.Parse(TheDistrictRow["StateID"].ToString());
			TheDistrict.StateName = TheDistrictRow["StateName"].ToString();
			TheDistrict.CountryID = int.Parse(TheDistrictRow["CountryID"].ToString());
			TheDistrict.CountryName = TheDistrictRow["CountryName"].ToString();

			return TheDistrict;
		}

		public static List<District> GetAllDistricts()
		{
			List<District> DistrictList = new List<District>();

			DataTable DistrictTable =new DataTable();
			DistrictTable = DistrictDataAccess.GetInstance.GetAllDistricts();

			foreach(DataRow dr in DistrictTable.Rows)
			{
				District TheDistrict = new District();

				TheDistrict.DistrictID = int.Parse(dr["DistrictID"].ToString());
                TheDistrict.DistrictName = string.Format("{0}, {1}, {2}", dr["DistrictName"].ToString(), dr["StateName"].ToString(), dr["CountryCode"].ToString());
				TheDistrict.StateID = int.Parse(dr["StateID"].ToString());
				TheDistrict.StateName = dr["StateName"].ToString();
				TheDistrict.CountryID = int.Parse(dr["CountryID"].ToString());
				TheDistrict.CountryName = dr["CountryName"].ToString();
                TheDistrict.CountryName = dr["CountryCode"].ToString();
                
				DistrictList.Add(TheDistrict);
			}

			return DistrictList;
		}


		public static List<District> GetDistrictStateCountryByDistrictId()
		{
			List<District> DistrictList = new List<District>();
			DataTable DistrictTable = DistrictDataAccess.GetInstance.GetDistrictStateCountryByDistrictId();

			foreach(DataRow dr in DistrictTable.Rows)
			{
				District TheDistrict = new District();

				TheDistrict.DistrictID = int.Parse(dr["DistrictID"].ToString());
				TheDistrict.DistrictName = dr["DistrictName"].ToString();
				TheDistrict.StateID = int.Parse(dr["StateID"].ToString());
				TheDistrict.StateName = dr["StateName"].ToString();
				TheDistrict.CountryID = int.Parse(dr["CountryID"].ToString());
				TheDistrict.CountryName = dr["CountryName"].ToString();

				DistrictList.Add(TheDistrict);
			}


			return DistrictList;
		}
	}
}
