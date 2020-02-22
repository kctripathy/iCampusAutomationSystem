using System;
using System.Collections.Generic;
using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
	public partial class RolePermissionManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static RolePermissionManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static RolePermissionManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new RolePermissionManagement();
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
		public string RoleDefaultColumn= "RoleDescription, RolePosition";
		public string RoleDisplayMember = "RoleDescription";
		public string RoleValueMember="RoleId";

		public string PermissionDefaultColumn= "PermissionDescription, BriefDescription, ForFormOrMenu";
		public string PermissionDisplayMember = "PermissionDescription";
		public string PermissionValueMember = "PermissionID";

		public string RolePermissionDefaultColumn = "RoleDescription, PermissionDescription, FormOrMenuDescription, FormOrMenu";
		public string RolePermissionDisplayMember= "PermissionDescription";
		public string RolePermissionValueMember = "RolePermissionID";
		#endregion

		#region Methods and Implementation
		public List<Role> GetRoles()
		{
			return RolePermissionIntegration.GetRoles();
		}

		public List<Permission> GetPermissions()
		{
			return RolePermissionIntegration.GetPermissions();
		}

		public List<Permission> GetFormPermissions()
		{
			return RolePermissionIntegration.GetFormPermissions();
		}

		public List<Permission> GetMenuPermissions()
		{
			return RolePermissionIntegration.GetMenuPermissions();
		}

		public List<RolePermission> GetRolePermissionsByRoleID(int roleID)
		{
			return RolePermissionIntegration.GetRolePermissionsByRoleID(roleID);
		}

		public List<RolePermission> GetFormRolePermissionsByRoleID(int roleID)
		{
			return RolePermissionIntegration.GetFormRolePermissionsByRoleID(roleID);
		}

		public List<RolePermission> GetFormRolePermissionsByFormOrMenuID(List<RolePermission> rolePermissionList, int FormOrMenuID)
		{
			return RolePermissionIntegration.GetFormRolePermissionsByFormOrMenuID(rolePermissionList, FormOrMenuID);
		}

		public List<RolePermission> SelectAllRolePermissionsByRoleID(int roleID)
		{
			return RolePermissionIntegration.SelectAllRolePermissionsByRoleID(roleID);
		}

		public void UpdateRecords(List<RolePermissionUpdate> rolePermissionUpdateList)
		{
			string Context = this.GetType().FullName.ToString();
			try
			{
				RolePermissionIntegration.UpdateRecords(rolePermissionUpdateList);
			}
			catch(Exception ex)
			{
				throw (new Exception(Context, ex));
			}
		}

		public void DeleteRolePermissions_Web(int roleId, string formOrmenu = "F")
		{
			RolePermissionIntegration.DeleteRolePermissions_Web(roleId, formOrmenu);
		}
		#endregion
	}
}
