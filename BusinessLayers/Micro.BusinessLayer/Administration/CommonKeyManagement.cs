using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;
using System.Web;

namespace Micro.BusinessLayer.Administration
{
	public partial class CommonKeyManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static CommonKeyManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static CommonKeyManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new CommonKeyManagement();
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
		public string DisplayMember = "CommonKeyValue";
		public string ValueMember ="CommonKeyID";
		#endregion

		#region Methods and Implementation
		public List<CommonKey> GetCommonKeyList(string SearchText = null)
		{
			return CommonKeyIntegration.GetCommonKeyList(SearchText);
		}

		public List<CommonKey> GetCommonKeyListByName(string commonKeyName)
		{
			//return CommonKeyIntegration.GetCommonKeyListByName(commonKeyName);

			//Cache the CommonKey for faster response
			string UniqueKey = string.Concat("CommonKey_",commonKeyName);
			if (HttpRuntime.Cache[UniqueKey] == null)
			{
				List<CommonKey> CommonKeyList = CommonKeyIntegration.GetCommonKeyListByName(commonKeyName);
				HttpRuntime.Cache[UniqueKey] = CommonKeyList;
			}
			return (List<CommonKey>)(HttpRuntime.Cache[UniqueKey]);
		}
		//Used For Commonkey
		public List<CommonKey> GetCommonKeyByName(string commonKeyName)
		{
			return CommonKeyIntegration.GetCommonKeyByName(commonKeyName);
		}

		public CommonKey GetCommonKeyByID(int CommonKeyID)
		{
			return CommonKeyIntegration.GetCommonKeyByID(CommonKeyID);
		}

		public int InsertCommonKey(CommonKey theCommonKey)
		{
			return CommonKeyIntegration.InsertCommonKey(theCommonKey);
		}

		public int UpdateCommonKey(CommonKey theCommonKey)
		{
			return CommonKeyIntegration.UpdateCommonKey(theCommonKey);
		}

		public int DeleteCommonKey(CommonKey theCommonKey)
		{
			return CommonKeyIntegration.DeleteCommonKey(theCommonKey);
		}
		#endregion

		//#region Data Fill Mathods( Fill Data Into DevxDataGrid,DevxLookupEdit)
		//public Boolean FillCommonKeysAll(Control Cnt, string searchText = null)
		//{
		//	try
		//	{
		//		if(Cnt is DevExpress.XtraEditors.LookUpEdit)
		//		{
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetCommonKeyList(searchText);
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "CommonKeyValue";
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "CommonKeyValue";
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
		//		}
		//		else if(Cnt is DevExpress.XtraGrid.GridControl)
		//		{
		//			((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetCommonKeyList(searchText);
		//		}

		//		return true;
		//	}
		//	catch(Exception ex)
		//	{
		//		return false;
		//		throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
		//	}
		//}

		//public Boolean FillCommonKeysByCommonKeyName(Control Cnt, string CommonKeyName)
		//{
		//	try
		//	{
		//		if(Cnt is DevExpress.XtraEditors.LookUpEdit)
		//		{
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = GetCommonKeyListByName(CommonKeyName);
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = "CommonKeyValue";
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = "CommonKeyValue";
		//			((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
		//		}
		//		else if(Cnt is DevExpress.XtraGrid.GridControl)
		//		{
		//			((DevExpress.XtraGrid.GridControl)Cnt).DataSource = GetCommonKeyListByName(CommonKeyName);
		//		}

		//		return true;
		//	}
		//	catch(Exception ex)
		//	{
		//		return false;
		//		throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
		//	}
		//}
		//#endregion
	}
}
