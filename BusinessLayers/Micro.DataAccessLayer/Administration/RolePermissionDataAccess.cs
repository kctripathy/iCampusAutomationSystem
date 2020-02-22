using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
    public partial class RolePermissionDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static RolePermissionDataAccess instance = new RolePermissionDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static RolePermissionDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Declaration
        #endregion

        #region Methods and Implementation
        public DataTable GetRoles()
        {
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.CommandText = "pADM_Roles_SelectAll";
				return ExecuteGetDataTable(SelectCommand);
			}
        }

		public DataTable GetPermissions()
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.CommandText = "pADM_Permissions_SelectAll";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable GetRolePermissionsByRoleID(int roleID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, roleID));
				SelectCommand.CommandText = "pADM_RolePermissions_SelectByRoleId";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

		public DataTable SelectAllRolePermissionsByRoleID(int roleID)
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, roleID));
				SelectCommand.CommandText = "pADM_RolePermissions_SelectAllByRoleId";
				return ExecuteGetDataTable(SelectCommand);
			}
		}
		

        public void UpdateRecords(List<RolePermissionUpdate> rolePermissionUpdateList)
        {
            int ListCount = rolePermissionUpdateList.Count;
            int ListCounter = 0;

            SqlCommand[] UpdateCommand = new SqlCommand[ListCount];

            foreach (RolePermissionUpdate rpu in rolePermissionUpdateList)
            {
                UpdateCommand[ListCounter] = new SqlCommand();

                UpdateCommand[ListCounter].CommandType = CommandType.StoredProcedure;
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, rpu.RoleID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@FormOrMenuID", SqlDbType.Int, rpu.FormOrMenuID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@FormOrMenu", SqlDbType.Char, rpu.FormOrMenu));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@PermissionID", SqlDbType.Int, rpu.PermissionID));
                UpdateCommand[ListCounter].Parameters.Add(GetParameter("@CheckState", SqlDbType.Bit, rpu.CheckState));
                UpdateCommand[ListCounter].CommandText = "pADM_RolePermissions_Update";

                ListCounter++;
            }

            ExecuteStoredProcedure(UpdateCommand);
        }


		public void DeleteRolePermissions_Web(int roleId, string formOrmenu = "F")
		{
			using (SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@RoleID", SqlDbType.Int, roleId));
				SelectCommand.Parameters.Add(GetParameter("@FormOrMenu", SqlDbType.VarChar, formOrmenu));
				SelectCommand.CommandText = "pADM_RolePermissions_Web_Delete";
				ExecuteStoredProcedure(SelectCommand);
			}
		}
        #endregion
    }
}
