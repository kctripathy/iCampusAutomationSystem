using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;
using Micro.Commons;

namespace Micro.IntegrationLayer.Administration
{
	public partial class MicroMenuIntegration
	{
		#region Declaration
		#endregion

		#region Methods & Implementation
		public static MicroMenu DataRowToObject(DataRow dr)
		{
			MicroMenu TheMicroMenu = new MicroMenu
			{
				MenuID = int.Parse(dr["MenuID"].ToString()),
				MenuItemName = dr["MenuItemName"].ToString(),
				ShortCutKey = dr["ShortCutKey"].ToString(),
				ShortCutDisplayString = dr["ShortCutDisplayString"].ToString(),
				ParentMenuID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ParentMenuID"].ToString())),
				ModuleID = int.Parse(dr["ModuleID"].ToString()),
				FormID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["FormID"].ToString())),
				FormName = dr["FormName"].ToString(),
				ActualFormName = dr["ActualFormName"].ToString(),
				ActualFormClassName = dr["ActualFormClassName"].ToString(),
				DisplayOrder = int.Parse(dr["DisplayOrder"].ToString()),
				IsActive = bool.Parse(dr["IsActive"].ToString()),
				IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
			};

			return TheMicroMenu;
		}

		public static List<MicroMenu> GetMicroMenus(bool showOnlyPermitted)
		{
			List<MicroMenu> MicroMenuList;

			if(showOnlyPermitted)
				MicroMenuList = GetMicroMenusByLoginName();
			else
				MicroMenuList = GetMicroMenus();

			return MicroMenuList;
		}

		private static List<MicroMenu> GetMicroMenus()
		{
			List<MicroMenu> MicroMenuList = new List<MicroMenu>();
			DataTable MicroMenuTable = MicroMenuDataAccess.GetInstance.GetMicroMenus();

			foreach(DataRow dr in MicroMenuTable.Rows)
			{
				MicroMenu TheMicroMenu = DataRowToObject(dr);

				MicroMenuList.Add(TheMicroMenu);
			}

			return MicroMenuList;
		}

		private static List<MicroMenu> GetMicroMenusByLoginName()
		{
			List<MicroMenu> MicroMenuList = new List<MicroMenu>();
			DataTable MicroMenuTable = MicroMenuDataAccess.GetInstance.GetMicroMenusByLoginName();

			foreach(DataRow dr in MicroMenuTable.Rows)
			{
				MicroMenu TheMicroMenu = DataRowToObject(dr);

				MicroMenuList.Add(TheMicroMenu);
			}

			return MicroMenuList;
		}

		public static MicroMenu GetMicroMenuByID(int menuID)
		{
			MicroMenu TheMicroMenu;
			DataRow MicroMenuDataRow = MicroMenuDataAccess.GetInstance.GetMicroMenuByID(menuID);

			if(MicroMenuDataRow != null)
				TheMicroMenu = DataRowToObject(MicroMenuDataRow);
			else
				TheMicroMenu = new MicroMenu();

			return TheMicroMenu;
		}

		public static List<MicroMenu> GetMicroMenusByParentID(int parentMenuID, bool showOnlyPermitted = true)
		{
			List<MicroMenu> MicroMenuList=GetMicroMenus(showOnlyPermitted);
			List<MicroMenu> FilteredMicroMenuList;

			if(MicroMenuList.Count > 0)
			{
				FilteredMicroMenuList = (from MicroMenus in MicroMenuList
										 where MicroMenus.ParentMenuID == parentMenuID
										 select MicroMenus).ToList();
			}
			else
				FilteredMicroMenuList = new List<MicroMenu>();

			return FilteredMicroMenuList;
		}

		public static int InsertMenu(MicroMenu theMenu)
		{
			return MicroMenuDataAccess.GetInstance.InsertMenu(theMenu);
		}

		public static int UpdateMenu(MicroMenu theMenu)
		{
			return MicroMenuDataAccess.GetInstance.UpdateMenu(theMenu);
		}

		public static int DeleteMenu(int menuID)
		{
			return MicroMenuDataAccess.GetInstance.DeleteMenu(menuID);
		}
		#endregion
	}
}
