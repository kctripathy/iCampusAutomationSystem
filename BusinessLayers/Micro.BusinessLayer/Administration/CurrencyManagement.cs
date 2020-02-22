using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;

namespace Micro.BusinessLayer.Administration
{
	public partial class CurrencyManagement
	{
		#region Declaration
		public string DisplayMember = "CurrencyCode";
		public string ValueMember = "CurrencyID";
		#endregion

		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static CurrencyManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static CurrencyManagement GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new CurrencyManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		#region Methods & Implementation
		public List<Currency> GetCurrencyList()
		{
			return CurrencyIntegration.GetCurrencyList();
		}
		#endregion
	}
}
