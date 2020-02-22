using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;
using System.Windows.Forms;
using System.Web;

namespace Micro.BusinessLayer.Administration
{
	public class DistrictManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static DistrictManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static DistrictManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new DistrictManagement();
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
		public string DefaultColumn="DistrictName, CountryName, StateName";
		public string DisplayMember="DistrictName";
		public string ValueMember="DistrictID";
		#endregion

		#region Methods and Implementations
		public List<District> GetDistrictListByStateId(int stateId, bool showDeleted = false)
		{
			return DistrictIntegration.GetDistrictListByStateId(stateId);
		}

		public List<District> GetAllDistricts()
		{

            // string someObject = "FooBar";  
  
            ////Cache the value  
            //HttpRuntime.Cache.Add("somekey", someObject, null,  
            //  DateTime.UtcNow.AddMinutes(1.0),  
            //  System.Web.Caching.Cache.NoSlidingExpiration,  
            //  System.Web.Caching.CacheItemPriority.Normal, null);  
  
            //someObject = null;        
  
            ////Access the cached value  
            //someObject = (string) HttpRuntime.Cache.Get( "somekey" );  

			//return DistrictIntegration.GetAllDistricts();

			//Cache the districts for faster response
			const string UniqueKey = "GetAllDistricts";
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<District> DistrictList = DistrictIntegration.GetAllDistricts();
				//HttpRuntime.Cache[UniqueKey] = DistrictList;
                HttpRuntime.Cache.Add(UniqueKey, DistrictList, null,
                                            DateTime.UtcNow.AddYears(1),
                                            System.Web.Caching.Cache.NoSlidingExpiration,
                                            System.Web.Caching.CacheItemPriority.High, null);
			}
            return (List<District>)HttpRuntime.Cache.Get(UniqueKey); //(HttpRuntime.Cache[UniqueKey]);
		
		}

		public List<District> GetDistrictStateCountryByDistrictId()
		{
			return DistrictIntegration.GetDistrictStateCountryByDistrictId();
		}

		public District GetDistrictStateCountryByDistrictId(int districtId)
		{
			return DistrictIntegration.GetDistrictStateCountryByDistrictId(districtId);
		}

		//public Boolean FillDistrictStateCountryByDistrictId(Control Cnt)
		//{
		//	string Context = this.GetType().FullName.ToString();
		//	try
		//	{
		//		if(Cnt is DevExpress.XtraEditors.LookUpEdit)
		//		{
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId();
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "DistrictName";
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "DistrictName";
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
		//		}
		//		else if(Cnt is DevExpress.XtraGrid.GridControl)
		//		{
		//			((DevExpress.XtraGrid.GridControl)Cnt).DataSource = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId();
		//		}

		//		return true;
		//	}
		//	catch(Exception ex)
		//	{
		//		return false;
		//		throw (new Exception(Context, ex));
		//	}
		//}
		#endregion
	}
}
