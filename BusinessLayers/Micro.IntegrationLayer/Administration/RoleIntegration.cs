using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;
using Micro.Commons;
using System;

namespace Micro.IntegrationLayer.Administration
{
	public partial class RoleIntegration
	{
		#region Declaration

		public static int InsertRoles(Role TheRole)
		{
			string Context = "Micro.IntegrationLayer.Administration.RoleIntegration.InsertRoles";
			try
			{
				return (RoleDataAccess.GetInstance.InsertRole(TheRole));
			}
			catch (Exception ex)
			{
				Micro.Commons.MicroMessages.ShowDataExceptionErrorMessage(new Exception(Context, ex));
				return (int)(MicroEnums.DataOperationResult.Failure);
			}
		}

		public static int UpdateRole(Role TheRole)
		{
			string Context = "Micro.IntegrationLayer.Administration.RoleIntegration.UpdateRole";
			try
			{
				return (RoleDataAccess.GetInstance.UpdateRole(TheRole));
			}
			catch (Exception ex)
			{
				Micro.Commons.MicroMessages.ShowDataExceptionErrorMessage(new Exception(Context, ex));
				return 0;
			}
		}

		public static List<Role> GetRolesList(System.String searchText = null, bool showDeleted = false)
		{
			string Context = "Micro.IntegrationLayer.Administration.RoleIntegration.GetRolesList";
			List<Role> RolesList = new List<Role>();
			try
			{
				DataTable RolesTable = RoleDataAccess.GetInstance.GetAllRoles(searchText, showDeleted);
				foreach (DataRow dr in RolesTable.Rows)
				{
					Role r = new Role();
					r.RoleID = int.Parse(dr["RoleId"].ToString());
					r.RoleDescription = dr["RoleDescription"].ToString();
					RolesList.Add(r);
				}
			}
			catch (Exception ex)
			{
				Micro.Commons.MicroMessages.ShowDataExceptionErrorMessage(new Exception(Context, ex));
			}
			return RolesList;

		}


		public static Role DataRowToObject(DataRow dr)
		{
			Role TheRole = new Role
			{
				RoleID = int.Parse(dr["RoleID"].ToString()),
				RoleDescription = dr["RoleDescription"].ToString(),
				RolePosition = int.Parse(dr["RolePosition"].ToString()),
				IsActive = bool.Parse(dr["IsActive"].ToString()),
				IsDeleted = bool.Parse(dr["IsDeleted"].ToString())
			};

			return TheRole;
		}

		public static List<Role> GetRoleList(bool showDeleted = false)
		{
			List<Role> RoleList = new List<Role>();
			DataTable RoleTable = RoleDataAccess.GetInstance.GetRoleList(showDeleted);

			foreach(DataRow dr in RoleTable.Rows)
			{
				Role TheRole = DataRowToObject(dr);

				RoleList.Add(TheRole);
			}

			return RoleList;
		}

		public static Role GetRoleById(int roleId)
		{
			DataRow RoleRow = RoleDataAccess.GetInstance.GetRoleById(roleId);
			Role TheRole = DataRowToObject(RoleRow);

			return TheRole;
		}

		//public static int InsertRoles(Role theRole)
		//{
		//    return RoleDataAccess.GetInstance.InsertRole(theRole);
		//}

		//public static int UpdateRole(Role theRole)
		//{
		//    return RoleDataAccess.GetInstance.UpdateRole(theRole);
		//}

		public static int DeleteRoles(int roleId)
		{
			return RoleDataAccess.GetInstance.DeleteRole(roleId);
		}
		#endregion

        public static string SendMicroSMS(string phoneNumber, string messageText)
        {
            return RoleDataAccess.GetInstance.SendMicroSMS(phoneNumber, messageText);
        }
	}
}
