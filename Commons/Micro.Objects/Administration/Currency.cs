using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Administration
{
	[Serializable]
	public  class Currency
	{
		public int CurrencyID
		{
			get;
			set;
		}
		public string CountryName
		{
			get;
			set;
		}
		public string CountryCapital
		{
			get;
			set;
		}
		public string CurrencyName
		{
			get;
			set;
		}
		public string CurrencyCode
		{
			get;
			set;
		}
		public int CompanyID
		{
			get;
			set;
		}
		public string DateAdded
		{
			get;
			set;
		}
		public string DateModified
		{
			get;
			set;
		}
		public int AddedBy
		{
			get;
			set;
		}
		public int ModifiedBy
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
