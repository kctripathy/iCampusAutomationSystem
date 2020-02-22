using System;
using System.Collections.Generic;
using Micro.DataAccessLayer.Administration;

using System.Data;
using System.Reflection;

#region Micro Namespaces

using Micro.Objects.Administration;


#endregion

namespace Micro.IntegrationLayer.Administration
{
	public partial class WebMenuIntegration
	{
		#region Declaration
		#endregion

		public static int InsertWebRolePermission(WebMenu objWebMenu)
		{
			try
			{
				return WebMenuDataAccess.GetInstance.InsertWebRolePermission(objWebMenu);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}
        public static int InsertMenuItems(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuDataAccess.GetInstance.InsertMenuItems(objWebMenu);
            }
            catch(Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static int UpdateMenuItems(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuDataAccess.GetInstance.UpdateMenuItems(objWebMenu);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public static int DeleteMenuItems(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuDataAccess.GetInstance.DeleteMenuItem(objWebMenu);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

		public static int UpdateWebRolePermission(WebMenu objWebMenu)
		{
			try
			{
				return WebMenuDataAccess.GetInstance.UpdateWebRolePermission(objWebMenu);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		public static int DeleteWebRolePermission(WebMenu objWebMenu)
		{
			try
			{
				return WebMenuDataAccess.GetInstance.DeleteWebRolePermission(objWebMenu);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

		#region Methods & Implementation

		public static List<WebMenu> GetWebMenusAll()
		{
			try
			{

				return SetWebMenuList(WebMenuDataAccess.GetInstance.GetWebMenusAll());
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}
        public static List<WebMenu> GetWebPermissonWebAll()
        {
            try 
            {
                return SetWebMenuPermissonList(WebMenuDataAccess.GetInstance.GetWebRolePermissionWebAll());
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

		public static List<WebMenu> GetWebMenusByRole(int RoleID = -1, string searchText = null, bool showDeleted = false)
		{
			try
			{
				return SetWebRolePermissionList(WebMenuDataAccess.GetInstance.GetWebMenusByRole(RoleID, searchText, showDeleted));
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

        public static List<WebMenu> GetWebMenuByRoleID(int RoleID=-1)
        {
            try
            {
                return SetWebRolePermissionListByRole(WebMenuDataAccess.GetInstance.GetWebMenuByRoleID(RoleID));
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
		private static List<WebMenu> SetWebMenuList(DataTable WebModuleTable)
		{
			try
			{
				List<WebMenu> WebMenuList = new List<WebMenu>();

				foreach (DataRow dr in WebModuleTable.Rows)
				{
					WebMenu theWebMenu = new WebMenu();

					theWebMenu.WebMenuID = int.Parse(dr["WebMenuID"].ToString());
					theWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
					theWebMenu.MenuToolTip = dr["MenuToolTip"].ToString();
					theWebMenu.MenuValueText = dr["MenuValueText"].ToString();
					theWebMenu.NavigationURL = dr["NavigationURL"].ToString();
					theWebMenu.ParentWebMenuID = (dr["ParentWebMenuID"].ToString() == string.Empty)? -1 : int.Parse(dr["ParentWebMenuID"].ToString());
					theWebMenu.ImageURL = dr["ImageURL"].ToString();
					theWebMenu.DisplayOrder = (dr["DisplayOrder"].ToString() == string.Empty) ? -1 : int.Parse(dr["DisplayOrder"].ToString());
                    theWebMenu.CanRedirectAfterUserLogin = (dr["CH_FIELD1"].ToString() == "Y" ? "YES" : "NO");
					WebMenuList.Add(theWebMenu);
				}

				return WebMenuList;
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}
      /// <summary>
      /// Method For Get all Parent Web Menu
      /// </summary>

      public static List<WebMenu> GetParentMenuAll()
        {
            try
            {
                List<WebMenu> ParentaWebMenuList = new List<WebMenu>();
                DataTable ParentMenuDataTable = WebMenuDataAccess.GetInstance.GetParentWebMenuAll();
                foreach (DataRow dr in ParentMenuDataTable.Rows)
                {
                    WebMenu objWebMenu = new WebMenu();
                    if (!string.IsNullOrEmpty(dr["WebMenuID"].ToString()))
                    {
                        objWebMenu.WebMenuID = int.Parse(dr["WebMenuID"].ToString());
                    }
                    objWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
                    if (!string.IsNullOrEmpty(dr["ParentWebMenuID"].ToString()))
                    {
                        objWebMenu.ParentWebMenuID = int.Parse(dr["ParentWebMenuID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["ModuleID"].ToString()))
                    {
                        objWebMenu.ModuleID = int.Parse(dr["ModuleID"].ToString());
                    }
                    objWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
                    objWebMenu.MenuValueText = dr["MenuValueText"].ToString();
                    objWebMenu.MenuToolTip = dr["MenuToolTip"].ToString();
                    objWebMenu.NavigationURL = dr["NavigationURL"].ToString();
                    if (!string.IsNullOrEmpty(dr["DisplayOrder"].ToString()))
                    {
                        objWebMenu.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());
                    }
                    ParentaWebMenuList.Add(objWebMenu);


                }
                return ParentaWebMenuList;
            }
            catch(Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

      public static List<WebMenu> SelectAllMenuItemsByRoleId(int roleId, int companyId)
      {
          try
          {

              return SetWebMenuList(WebMenuDataAccess.GetInstance.SelectAllMenuItemsByRoleId(roleId, companyId));
          }
          catch (Exception ex)
          {
              throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
          }
      }

	  public static List<WebMenu> SelectAllMenuItemsByRoleId(int roleId)
	  {
		  try
		  {

			  return SetWebMenuList(WebMenuDataAccess.GetInstance.SelectAllMenuItemsByRoleId(roleId));
		  }
		  catch (Exception ex)
		  {
			  throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
		  }
	  }
        public static List<WebMenu> GetWebMenuItemsAllByParentWebMenuID(int TheParentWebMenuID)
        {
        
             try
            {
                List<WebMenu> ParentaWebMenuList = new List<WebMenu>();
                DataTable MenuDataTable = WebMenuDataAccess.GetInstance.GetWebMenuAllByParentWebMenuID(TheParentWebMenuID);
                foreach (DataRow dr in MenuDataTable.Rows)
                {
                    WebMenu objWebMenu = new WebMenu();
                    if (!string.IsNullOrEmpty(dr["WebMenuID"].ToString()))
                    {
                        objWebMenu.WebMenuID = int.Parse(dr["WebMenuID"].ToString());
                    }
                    objWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
                    if (!string.IsNullOrEmpty(dr["ParentWebMenuID"].ToString()))
                    {
                        objWebMenu.ParentWebMenuID = int.Parse(dr["ParentWebMenuID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["ModuleID"].ToString()))
                    {
                        objWebMenu.ModuleID = int.Parse(dr["ModuleID"].ToString());
                    }
                    objWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
                    objWebMenu.MenuValueText = dr["MenuValueText"].ToString();
                    objWebMenu.MenuToolTip = dr["MenuToolTip"].ToString();
                    objWebMenu.NavigationURL = dr["NavigationURL"].ToString();
                    if (!string.IsNullOrEmpty(dr["DisplayOrder"].ToString()))
                    {
                        objWebMenu.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());
                    }
                    ParentaWebMenuList.Add(objWebMenu);


                }
                return ParentaWebMenuList;
            }
            catch(Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        private static List<WebMenu> SetWebMenuPermissonList(DataTable WebModuleTable)
        {

            try
            {
                List<WebMenu> RoleWebMenuList = new List<WebMenu>();

                foreach (DataRow dr in WebModuleTable.Rows)
                {
                    WebMenu objWebMenu = new WebMenu();

                    objWebMenu.WebRolePermissionID = int.Parse(dr["RolePermissionID"].ToString());
                    objWebMenu.FormOrMenuID = int.Parse(dr["FormOrMenuID"].ToString());
                    objWebMenu.WebMenuID = int.Parse(dr["FormOrMenuID"].ToString());
                    objWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
                    objWebMenu.PermissionID = int.Parse(dr["PermissionID"].ToString());
                    objWebMenu.RoleID = int.Parse(dr["RoleID"].ToString());
                    objWebMenu.RoleDescription = dr["RoleDescription"].ToString();
                    objWebMenu.PermissionDescription = dr["PermissionDescription"].ToString();
                    objWebMenu.FormOrMenu = dr["FormOrMenu"].ToString();
                
                    RoleWebMenuList.Add(objWebMenu);
                }
                return RoleWebMenuList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }

        }

		private static List<WebMenu> SetWebRolePermissionList(DataTable WebModuleTable)
		{
			try
			{
				List<WebMenu> WebMenuList = new List<WebMenu>();

				foreach (DataRow dr in WebModuleTable.Rows)
				{
					WebMenu theWebMenu = new WebMenu();
                    theWebMenu.ModuleID = int.Parse(dr["ModuleID"].ToString());
					theWebMenu.WebMenuID = int.Parse(dr["WebMenuID"].ToString());
					theWebMenu.WebRolePermissionID = int.Parse(dr["WebRolePermissionID"].ToString());
					theWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
					theWebMenu.MenuToolTip = dr["MenuToolTip"].ToString();
					theWebMenu.MenuValueText = dr["MenuValueText"].ToString();
					theWebMenu.NavigationURL = dr["NavigationURL"].ToString();
					theWebMenu.ParentWebMenuID = int.Parse(dr["ParentWebMenuID"].ToString());
					theWebMenu.ImageURL = dr["ImageURL"].ToString();
					theWebMenu.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());
					theWebMenu.IsActive = Boolean.Parse(dr["IsActive"].ToString());
					WebMenuList.Add(theWebMenu);
				}

				return WebMenuList;
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

        private static List<WebMenu> SetWebRolePermissionListByRole(DataTable WebModuleTable)
        {
            try
            {
                List<WebMenu> WebMenuList = new List<WebMenu>();

                foreach (DataRow dr in WebModuleTable.Rows)
                {
                    WebMenu theWebMenu = new WebMenu();
                    //theWebMenu.ModuleID = int.Parse(dr["ModuleID"].ToString());
                    theWebMenu.WebRolePermissionID = int.Parse(dr["RolePermissionID"].ToString());
                    theWebMenu.FormOrMenuID = int.Parse(dr["FormOrMenuID"].ToString());
                    theWebMenu.WebMenuID = int.Parse(dr["WebMenuID"].ToString());
                    theWebMenu.PermissionID = int.Parse(dr["PermissionID"].ToString());
                    theWebMenu.RoleID = int.Parse(dr["RoleID"].ToString());
                    theWebMenu.PermissionDescription = dr["PermissionDescription"].ToString();
                    theWebMenu.FormOrMenu = dr["FormOrMenu"].ToString();
                    theWebMenu.RoleDescription = dr["RoleDescription"].ToString();
                    //theWebMenu.WebRolePermissionID = int.Parse(dr["WebRolePermissionID"].ToString());
                    theWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
                    theWebMenu.MenuToolTip = dr["MenuToolTip"].ToString();
                    //theWebMenu.MenuValueText = dr["MenuValueText"].ToString();
                    theWebMenu.NavigationURL = dr["NavigationURL"].ToString();
                    theWebMenu.ParentWebMenuID = int.Parse(dr["ParentWebMenuID"].ToString());
                    //theWebMenu.ImageURL = dr["ImageURL"].ToString();
                    //theWebMenu.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());
                    theWebMenu.IsActive = Boolean.Parse(dr["IsActive"].ToString());
                    WebMenuList.Add(theWebMenu);
                }

                return WebMenuList;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
		#endregion

        #region Methods & Implementation
        public static WebMenu DataRowToObject(DataRow dr)
        {
            WebMenu TheWebMenu = new WebMenu();
            TheWebMenu.WebMenuID = int.Parse(dr["WebMenuID"].ToString());
            
            TheWebMenu.ParentWebMenuID = int.Parse(dr["ParentWebMenuID"].ToString());
            
            //TheWebMenu.ModuleID = int.Parse(dr["ModuleID"].ToString());
            TheWebMenu.MenuDisplayText = dr["MenuDisplayText"].ToString();
            TheWebMenu.MenuValueText = dr["MenuValueText"].ToString();
            TheWebMenu.MenuToolTip = dr["MenuToolTip"].ToString();
            TheWebMenu.NavigationURL = dr["NavigationURL"].ToString();
            if (!string.IsNullOrEmpty(dr["DisplayOrder"].ToString()))
            {
                TheWebMenu.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());
            }
            return TheWebMenu;
        }
        public static WebMenu DataRowToTheObject(DataRow dRow)
        {
            WebMenu objMenu ;

                if(dRow!=null)
                {
                   
                    objMenu = new WebMenu();
                    
                     objMenu.WebRolePermissionID = int.Parse(dRow["RolePermissionID"].ToString());
                     objMenu.FormOrMenuID = int.Parse(dRow["FormOrMenuID"].ToString());
                     objMenu.PermissionID = int.Parse(dRow["PermissionID"].ToString());
                     objMenu.PermissionDescription = dRow["PermissionDescription"].ToString();
                     objMenu.RoleID = int.Parse(dRow["RoleID"].ToString());
                     objMenu.RoleDescription = dRow["RoleDescription"].ToString();
                   
                    
                     objMenu.FormOrMenu = dRow["FormOrMenu"].ToString();
                    
                }
                else
                    objMenu=new WebMenu();
            return objMenu;
        }

        public static WebMenu GetWebMenuByWebMenuID(int WebMenuID)
        {
            DataRow TheWebMenuRow = WebMenuDataAccess.GetInstance.GetWebMenuByWebMenuID(WebMenuID);

            WebMenu TheWebMenu = DataRowToObject(TheWebMenuRow);

            return TheWebMenu;
        }

        public static WebMenu GetWebMenuByRolePermissionID(int RolePermissionID)
        {
            DataRow TheWebMenuRow = WebMenuDataAccess.GetInstance.GetWebMenuByRolePermissionID(RolePermissionID);
            WebMenu TheWebMenu = DataRowToTheObject(TheWebMenuRow);
            return TheWebMenu;
        }


		public static int UpdateWebRolePermissions(int roleId, string MenuItemIds, int permissionId = 4, string FormOrMenu = "M")
		{
			return WebMenuDataAccess.GetInstance.UpdateWebRolePermissions(roleId, MenuItemIds, permissionId, FormOrMenu);
		}
        #endregion
    }
}
