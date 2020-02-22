using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

#region Micro Namespaces
using Micro.Objects.Administration;
#endregion

namespace Micro.DataAccessLayer.Administration
{
    public partial class WebMenuDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static WebMenuDataAccess instance = new WebMenuDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static WebMenuDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Transactional Mathods(Insert,Update,Delete)

        public int InsertWebRolePermission(WebMenu objWebMenu)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand InsertCommand = new SqlCommand();
                InsertCommand.CommandType = CommandType.StoredProcedure;

                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;

                InsertCommand.Parameters.Add(GetParameter("@WebMenuID", SqlDbType.Int,objWebMenu.WebMenuID));
                InsertCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, objWebMenu.RoleID));
                InsertCommand.Parameters.Add(GetParameter("@PermissionID", SqlDbType.Int, objWebMenu.PermissionID));
                InsertCommand.Parameters.Add(GetParameter("@FormOrMenu", SqlDbType.VarChar, objWebMenu.FormOrMenu));

                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserId));

                InsertCommand.CommandText = "pADM_RolePermissionsWeb_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public int UpdateWebRolePermission(WebMenu objWebMenu)
        {
            try
            {
                int ReturnValue = 0;

                SqlCommand UpdateCommand = new SqlCommand();
                UpdateCommand.CommandType = CommandType.StoredProcedure;

                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@WebRolePermissionID", SqlDbType.Int, objWebMenu.WebRolePermissionID));
                UpdateCommand.Parameters.Add(GetParameter("@FormOrMenuID", SqlDbType.Int, objWebMenu.FormOrMenuID));
                UpdateCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, objWebMenu.RoleID));
                UpdateCommand.Parameters.Add(GetParameter("@PermissionID", SqlDbType.Int, objWebMenu.PermissionID));
                UpdateCommand.Parameters.Add(GetParameter("@FormOrMenu", SqlDbType.VarChar, objWebMenu.FormOrMenu));
                

                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserId));

                UpdateCommand.CommandText = "pADM_RolePermissionsWeb_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
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
                int ReturnValue = 0;

                SqlCommand DeleteCommand = new SqlCommand();
                DeleteCommand.CommandType = CommandType.StoredProcedure;

                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@WebRolePermissionID", SqlDbType.Int, objWebMenu.WebRolePermissionID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserId));

                DeleteCommand.CommandText = "pADM_RolePermissionsWeb_Delete";

                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        #endregion

        #region Methods & Implementation

        public DataTable GetWebMenusAll()
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_WebMenuItems_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetParentWebMenuAll()
        {
            try 
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_MenuItems_Parents_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            
            }
        }

        public DataTable GetWebMenuAllByParentWebMenuID(int TheParentWebMenuID)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@ParentWebMenuID", SqlDbType.Int, TheParentWebMenuID));
                SelectCommand.CommandText = "pADM_WebMenuItems_SelectAllByParentWebMenuID";
                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));

            }
        }
        public DataTable GetWebRolePermissionWebAll()
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_RoleMenuPermissionWeb_SelectAll";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetWebMenusByRole(int RoleID = -1, string searchText = null, bool showDeleted = false)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, (RoleID==-1? Micro.Commons.Connection.LoggedOnUser.RoleId :RoleID ) ));
                SelectCommand.Parameters.Add(GetParameter("@SearchText", SqlDbType.VarChar, searchText));
                SelectCommand.Parameters.Add(GetParameter("@ShowDeleted", SqlDbType.Bit, showDeleted));
                SelectCommand.CommandText = "pADM_MenuItemsWeb_SelectAllByRole";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }


		public DataTable SelectAllMenuItemsByRoleId(int roleID)
		{
			try
			{
				SqlCommand SelectCommand = new SqlCommand();

				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, roleID));
				SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8)); //Micro.Commons.Connection.LoggedOnUser.CompanyID));
				SelectCommand.CommandText = "pADM_WebMenuItems_SelectAllByRoleId";

				return ExecuteGetDataTable(SelectCommand);
			}
			catch (Exception ex)
			{
				throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
			}
		}

        public DataTable SelectAllMenuItemsByRoleId(int roleID, int companyId)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand();

                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, roleID));
                SelectCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, companyId));
                SelectCommand.CommandText = "pADM_WebMenuItems_SelectAllByRoleId";

                return ExecuteGetDataTable(SelectCommand);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex));
            }
        }

        public DataTable GetWebMenuByRoleID(int RoleID)
        {
            try
            {
                WebMenu TheWebMenu=new WebMenu();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add(GetParameter("RoleID", SqlDbType.Int, (RoleID == -1 ? Micro.Commons.Connection.LoggedOnUser.RoleId : RoleID)));
                SqlCmd.CommandText = "pADM_MenuItemsPermission_SelectByRoleID";
                return ExecuteGetDataTable(SqlCmd);
            }
            catch (Exception ex)
            {
                throw (new Exception(MethodBase.GetCurrentMethod().DeclaringType.ToString() + "." + (new System.Diagnostics.StackFrame()).GetMethod().Name, ex)); 
            }
        }

       

        public int InsertMenuItems(WebMenu theMenuItem)
        {
            int ReturnValue = 0;

            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@ParentWebMenuID", SqlDbType.Int, theMenuItem.ParentWebMenuID));
                InsertCommand.Parameters.Add(GetParameter("@MenuDisplayText", SqlDbType.VarChar, theMenuItem.MenuDisplayText));
                InsertCommand.Parameters.Add(GetParameter("@MenuValueText", SqlDbType.VarChar, theMenuItem.MenuValueText));
                InsertCommand.Parameters.Add(GetParameter("@MenuToolTip", SqlDbType.VarChar, theMenuItem.MenuToolTip));
                InsertCommand.Parameters.Add(GetParameter("@NavigationURL", SqlDbType.VarChar, theMenuItem.NavigationURL));
                InsertCommand.Parameters.Add(GetParameter("@DisplayOrder", SqlDbType.Int, theMenuItem.DisplayOrder));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));

                InsertCommand.CommandText = "pADM_WebMenuItems_Insert";

                ExecuteStoredProcedure(InsertCommand);

                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }


        public int UpdateMenuItems(WebMenu theMenuItem)
        {
            int ReturnValue = 0;

            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@WebMenuID", SqlDbType.Int, theMenuItem.WebMenuID));
                UpdateCommand.Parameters.Add(GetParameter("@ParentWebMenuID", SqlDbType.Int, theMenuItem.ParentWebMenuID));
                UpdateCommand.Parameters.Add(GetParameter("@MenuDisplayText", SqlDbType.VarChar, theMenuItem.MenuDisplayText));
                UpdateCommand.Parameters.Add(GetParameter("@MenuValueText", SqlDbType.VarChar, theMenuItem.MenuValueText));
                UpdateCommand.Parameters.Add(GetParameter("@MenuToolTip", SqlDbType.VarChar, theMenuItem.MenuToolTip));
                UpdateCommand.Parameters.Add(GetParameter("@NavigationURL", SqlDbType.VarChar, theMenuItem.NavigationURL));
                UpdateCommand.Parameters.Add(GetParameter("@DisplayOrder", SqlDbType.Int, theMenuItem.DisplayOrder));
                //UpdateCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, theMenuItem.IsActive));
                //UpdateCommand.Parameters.Add(GetParameter("@IsDeleted", SqlDbType.Bit, theMenuItem.IsDeleted));
                UpdateCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyCode", SqlDbType.VarChar, Micro.Commons.Connection.LoggedOnUser.CompanyCode));
                UpdateCommand.CommandText = "pADM_WebMenuItems_Update";

                ExecuteStoredProcedure(UpdateCommand);

                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }

        public int DeleteMenuItem(WebMenu theWebMenu)
        {
            int ReturnValue = 0;

            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@WebMenuID", SqlDbType.Int, theWebMenu.WebMenuID));
                DeleteCommand.Parameters.Add(GetParameter("@ModifiedBy", SqlDbType.Int, theWebMenu.ModifiedBy));
                DeleteCommand.CommandText = "pADM_WebMenuItems_Delete";
                ExecuteStoredProcedure(DeleteCommand);

                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());

                return ReturnValue;
            }
        }
        #endregion
        #region Method & Implemenation

        public DataRow GetWebMenuByWebMenuID(int WebMenuID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@WebMenuID", SqlDbType.Int, WebMenuID));
                SelectCommand.CommandText = "pADM_MenuItems_SelectByWebMenuID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public DataRow GetWebMenuByRolePermissionID(int RolePermissionID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@RolePermissionID", SqlDbType.Int, RolePermissionID));
                SelectCommand.CommandText = "pADM_MenuItems_SelectByRolePermissionID";

                return ExecuteGetDataRow(SelectCommand);
            }
        }


		public int UpdateWebRolePermissions(int roleId, string MenuItemIds, int permissionId = 4, string FormOrMenu = "M")
		{
			int ReturnValue = 0;

			using (SqlCommand UpdateCommand = new SqlCommand())
			{
				UpdateCommand.CommandType = CommandType.StoredProcedure;
				UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
				UpdateCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, roleId));
				UpdateCommand.Parameters.Add(GetParameter("@PermissionID", SqlDbType.Int, permissionId));
				UpdateCommand.Parameters.Add(GetParameter("@MenuIDs", SqlDbType.VarChar, MenuItemIds));
				UpdateCommand.Parameters.Add(GetParameter("@FormOrMenu", SqlDbType.VarChar, FormOrMenu));
                UpdateCommand.Parameters.Add(GetParameter("@CompanyID", SqlDbType.Int, 8));
				
				UpdateCommand.CommandText = "pADM_RolePermissions_Web_Update";
				ExecuteStoredProcedure(UpdateCommand);

				ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());

				return ReturnValue;
			}
		}
        #endregion

    }
}
