using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;
using System.Reflection;
using System.Web;

namespace Micro.BusinessLayer.Administration
{
   public partial class WebMenuManagement
   {
       #region Declaration
       public string DisplayMember = "MenuDisplayText";
       public  string ValueMember = "WebMenuID";

       #endregion
       #region Code to make this as Singleton Class
       /// <summary>
        /// Declare a private static variable
        /// </summary>
       private static WebMenuManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
       public static WebMenuManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new WebMenuManagement();
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
        #endregion

        public List<WebMenu> GetWebMenusAll()
        {
            
            try
            {
                return WebMenuIntegration.GetWebMenusAll();
                   
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        /// <summary>
        /// Method For Get all Parent Web Menu
        /// </summary>

        public List<WebMenu> GetParentWebMenuAll()
        {
            try
            {
                return WebMenuIntegration.GetParentMenuAll();
            }
            catch(Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<WebMenu> SelectAllMenuItemsByRoleId(int roleId, int companyId)
        {
            try
            {
                //return WebMenuIntegration.SelectAllMenuItemsByRoleId(roleId,companyId);
                //TODO: cache this menu items
				string UniqueKey = string.Concat("MenuItemsByRole_", roleId.ToString());
				if (HttpRuntime.Cache[UniqueKey] == null)
				{

					List<WebMenu> WebMenuList = WebMenuIntegration.SelectAllMenuItemsByRoleId(roleId);
					HttpRuntime.Cache[UniqueKey] = WebMenuList;
				}
				return (List<WebMenu>)(HttpRuntime.Cache[UniqueKey]);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

		public List<WebMenu> SelectAllMenuItemsByRoleId(int roleId)
		{
			try
			{
                return WebMenuIntegration.SelectAllMenuItemsByRoleId(roleId);
                //TODO: cache this menu items
                //string UniqueKey = string.Concat("MenuItemsByRole__", roleId.ToString());
                //if (HttpRuntime.Cache[UniqueKey] == null)
                //{

                //    List<WebMenu> WebMenuList = WebMenuIntegration.SelectAllMenuItemsByRoleId(roleId);
                //    HttpRuntime.Cache[UniqueKey] = WebMenuList;
                //}
                //return (List<WebMenu>)(HttpRuntime.Cache[UniqueKey]);
            }
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

        public List<WebMenu> GetWebMenuAllByParentWebMenuID(int TheParentWebMenuID)
        {
            try
            {
                return WebMenuIntegration.GetWebMenuItemsAllByParentWebMenuID(TheParentWebMenuID);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<WebMenu> GetRolePermissionWebAll()
        {
            try 
            {
                return WebMenuIntegration.GetWebPermissonWebAll();
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public List<WebMenu> GetWebMenusByRole(int RoleID = -1, string searchText = null, bool showDeleted = false)
        {
			
            try
            {
				string UniqueKey = "MicroMenuList" + RoleID.ToString();
				if (HttpRuntime.Cache[UniqueKey] == null)
				{
					List<WebMenu> WebMenuList = WebMenuIntegration.GetWebMenusByRole(RoleID,searchText,showDeleted);
					HttpRuntime.Cache[UniqueKey] = WebMenuList;
				}
				return (List<WebMenu>)(HttpRuntime.Cache[UniqueKey]);

            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public List<WebMenu> GetWebMenusByRoleID(int RoleID=-1)
        {
            try
            {
                return WebMenuIntegration.GetWebMenuByRoleID(RoleID);
            }
            catch(Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int InsertWebRolePermission(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuIntegration.InsertWebRolePermission(objWebMenu);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int InsertMenuItems(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuIntegration.InsertMenuItems(objWebMenu);
            }
            catch(Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int UpdateMenuItems(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuIntegration.UpdateMenuItems(objWebMenu);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        public int DeleteMenuItems(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuIntegration.DeleteMenuItems(objWebMenu);
            }
            catch(Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateWebRolePermission(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuIntegration.UpdateWebRolePermission(objWebMenu);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int DeleteWebRolePermission(WebMenu objWebMenu)
        {
            try
            {
                return WebMenuIntegration.DeleteWebRolePermission(objWebMenu);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }
        #region Method & Implementation
        public WebMenu GetWebMenuByWebMenuID(int WebMenuID)
        {
            return WebMenuIntegration.GetWebMenuByWebMenuID(WebMenuID);
        }

        public WebMenu GetWebMenuByRolePermissionID(int RolePermissionID)
        {
            return WebMenuIntegration.GetWebMenuByRolePermissionID(RolePermissionID);
        }


		public int UpdateWebRolePermissions(int roleId, string MenuItemIds, int permissionId = 4, string FormOrMenu = "M")
		{
			return WebMenuIntegration.UpdateWebRolePermissions(roleId, MenuItemIds, permissionId, FormOrMenu);
		}
        
        #endregion
    }
}
