using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.Administration;
using System.Data;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class CurrencyIntegration
	{
		#region Declaration
		#endregion

		#region Methods & Implementation

		public static Currency DataRowToObject(DataRow dr)
		{
			Currency TheCurrency = new Currency();

			TheCurrency.CurrencyID = int.Parse(dr["CurrencyID"].ToString());
			TheCurrency.CountryName = dr["CountryName"].ToString();
			TheCurrency.CountryCapital=dr["CountryCapital"].ToString();
			TheCurrency.CurrencyName = dr["CurrencyName"].ToString();
			TheCurrency.CurrencyCode=dr["CurrencyCode"].ToString();
			TheCurrency.CompanyID = int.Parse(dr["CompanyID"].ToString());

			return TheCurrency;
		}

		public static List<Currency> GetCurrencyList()
		{
			List<Currency> CurrencyList = new List<Currency>();

			DataTable CurrencyTable = CurrencyDataAccess.GetInstance.GetCurrencyList();

			foreach (DataRow dr in CurrencyTable.Rows)
			{
				Currency TheCurrency = DataRowToObject(dr);

				CurrencyList.Add(TheCurrency);
			}

			return CurrencyList;
		}
		#endregion
	}
}
