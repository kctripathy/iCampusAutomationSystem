using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class RolePermissionIntegration
	{
		#region Declaration
		#endregion

		#region Methods and Implementation
		public static Role RoleDataRowToObject(DataRow dr)
		{
			Role TheRole = new Role
			{
				RoleID = int.Parse(dr["RoleId"].ToString()),
				RoleDescription = dr["RoleDescription"].ToString(),
				RolePosition = int.Parse(dr["RolePosition"].ToString()),
				IsActive = bool.Parse(dr["IsActive"].ToString()),
				IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
			};

			return TheRole;
		}

		public static Permission PermissionDataRowToObject(DataRow dr)
		{
			Permission ThePermission = new Permission
			{
				PermissionID = int.Parse(dr["PermissionID"].ToString()),
				PermissionDescription = dr["PermissionDescription"].ToString(),
				BriefDescription = dr["BriefDescription"].ToString(),
				ForFormOrMenu=char.Parse(dr["ForFormOrMenu"].ToString()),
				IsActive = bool.Parse(dr["IsActive"].ToString()),
				IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
			};

			return ThePermission;
		}

		public static RolePermission RolePermissionDataRowToObject(DataRow dr)
		{
			RolePermission TheRolePermission = new RolePermission
			{
				RolePermissionID = int.Parse(dr["RolePermissionID"].ToString()),
				RoleID = int.Parse(dr["RoleID"].ToString()),
				RoleDescription = dr["RoleDescription"].ToString(),
				RolePosition = int.Parse(dr["RolePosition"].ToString()),
				PermissionID = int.Parse(dr["PermissionID"].ToString()),
				PermissionDescription = dr["PermissionDescription"].ToString(),
				BriefDescription = dr["BriefDescription"].ToString(),
				FormOrMenuID = int.Parse(dr["FormOrMenuID"].ToString()),
				FormOrMenuDescription = dr["FormOrMenuDescription"].ToString(),
				FormOrMenu = char.Parse(dr["FormOrMenu"].ToString()),
				IsActive = bool.Parse(dr["IsActive"].ToString()),
				IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
			};



			return TheRolePermission;
		}

		public static RolePermission ConvertDataRowToObject(DataRow dr)
		{
			RolePermission TheRolePermission = new RolePermission
			{
				RolePermissionID = int.Parse(dr["RolePermissionID"].ToString()),
				RoleID = int.Parse(dr["RoleID"].ToString()),
				FormOrMenuID = int.Parse(dr["FormOrMenuID"].ToString()),
				PermissionID = int.Parse(dr["PermissionID"].ToString()),
				NavigationURL = dr["NavigationURL"].ToString().Trim()
			};



			return TheRolePermission;
		}

		public static List<Role> GetRoles()
		{
			List<Role> RoleList = new List<Role>();
			DataTable RoleTable = RolePermissionDataAccess.GetInstance.GetRoles();

			foreach(DataRow dr in RoleTable.Rows)
			{
				Role TheRole = RoleDataRowToObject(dr);

				RoleList.Add(TheRole);
			}

			return RoleList;
		}

		public static List<Permission> GetPermissions()
		{
			List<Permission> PermissionList = new List<Permission>();
			DataTable PermissionTable = RolePermissionDataAccess.GetInstance.GetPermissions();

			foreach(DataRow dr in PermissionTable.Rows)
			{
				Permission ThePermission = PermissionDataRowToObject(dr);

				PermissionList.Add(ThePermission);
			}

			return PermissionList;
		}

		public static List<Permission> GetFormPermissions()
		{
			List<Permission> PermissionList = GetPermissions();
			List<Permission> FormPermissionList;

			if(PermissionList.Count > 0)
			{
				FormPermissionList = (from Permissions in PermissionList
									  where Permissions.ForFormOrMenu == 'B' || Permissions.ForFormOrMenu == 'F'
									  select Permissions).ToList();
			}
			else
				FormPermissionList = new List<Permission>();

			return FormPermissionList;
		}

		public static List<Permission> GetMenuPermissions()
		{
			List<Permission> PermissionList = GetPermissions();
			List<Permission> MenuPermissionList;

			if(PermissionList.Count > 0)
			{
				MenuPermissionList = (from Permissions in PermissionList
									  where Permissions.ForFormOrMenu == 'B' || Permissions.ForFormOrMenu == 'M'
									  select Permissions).ToList();
			}
			else
				MenuPermissionList = new List<Permission>();

			return MenuPermissionList;
		}

		public static List<RolePermission> GetRolePermissionsByRoleID(int roleID)
		{
			List<RolePermission> RolePermissionList = new List<RolePermission>();
			DataTable RolePermissionTable = RolePermissionDataAccess.GetInstance.GetRolePermissionsByRoleID(roleID);

			foreach(DataRow dr in RolePermissionTable.Rows)
			{
				RolePermission TheRolePermission = RolePermissionDataRowToObject(dr);

				RolePermissionList.Add(TheRolePermission);
			}

			return RolePermissionList;
		}


		public static List<RolePermission> SelectAllRolePermissionsByRoleID(int roleID)
		{
			List<RolePermission> RolePermissionList = new List<RolePermission>();
			DataTable RolePermissionTable = RolePermissionDataAccess.GetInstance.SelectAllRolePermissionsByRoleID(roleID);

			foreach (DataRow dr in RolePermissionTable.Rows)
			{
				RolePermission TheRolePermission = ConvertDataRowToObject(dr);

				RolePermissionList.Add(TheRolePermission);
			}

			return RolePermissionList;
		}
		public static List<RolePermission> GetFormRolePermissionsByRoleID(int roleID)
		{
			List<RolePermission> PermissionList = GetRolePermissionsByRoleID(roleID);
			List<RolePermission> FormRolePermissionList;

			if(PermissionList.Count > 0)
			{
				FormRolePermissionList = (from Permissions in PermissionList
										  where Permissions.FormOrMenu == 'B' || Permissions.FormOrMenu == 'F'
										  select Permissions).ToList();
			}
			else
				FormRolePermissionList = new List<RolePermission>();

			return FormRolePermissionList;
		}

		public static List<RolePermission> GetFormRolePermissionsByFormOrMenuID(List<RolePermission> rolePermissionList, int FormOrMenuID)
		{
			List<RolePermission> PermissionList = rolePermissionList;
			List<RolePermission> FormRolePermissionList;

			if(PermissionList.Count > 0)
			{
				FormRolePermissionList = (from Permissions in PermissionList
										  where (Permissions.FormOrMenu == 'B' || Permissions.FormOrMenu == 'F') && Permissions.FormOrMenuID == FormOrMenuID
										  select Permissions).ToList();
			}
			else
				FormRolePermissionList = new List<RolePermission>();

			return FormRolePermissionList;
		}

		public static void UpdateRecords(List<RolePermissionUpdate> rolePermissionUpdateList)
		{
			string Context = "Micro.IntegrationLayer.Administration.RolePermissionIntegration.UpdateRecords";
			try
			{
				RolePermissionDataAccess.GetInstance.UpdateRecords(rolePermissionUpdateList);
			}
			catch(Exception ex)
			{
				throw (new Exception(Context, ex));
			}
		}

		public static void DeleteRolePermissions_Web(int roleId, string formOrmenu = "F")
		{
			RolePermissionDataAccess.GetInstance.DeleteRolePermissions_Web(roleId, formOrmenu);
		}
		#endregion
	}
}
