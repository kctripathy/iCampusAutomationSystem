using System.Data;
using System.Data.SqlClient;
using Micro.Objects.Administration;

namespace Micro.DataAccessLayer.Administration
{
    public partial class MicroMenuDataAccess : AbstractData_SQLClient
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Private static member to implement Singleton Desing Pattern
        /// </summary>
        private static MicroMenuDataAccess instance = new MicroMenuDataAccess();

        /// <summary>
        /// Static property of the class which will provide the singleton instance of it
        /// </summary>
        public static MicroMenuDataAccess GetInstance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Methods & Implementation
        public DataTable GetMicroMenus()
        {
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.CommandText = "pADM_MenuItems_SelectAll";
				return ExecuteGetDataTable(SelectCommand);
			}
        }

		public DataTable GetMicroMenusByLoginName()
		{
			using(SqlCommand SelectCommand = new SqlCommand())
			{
				SelectCommand.CommandType = CommandType.StoredProcedure;
				SelectCommand.Parameters.Add(GetParameter("@LoginName", SqlDbType.VarChar, Micro.Commons.Connection.LoggedOnUser.UserName));
				SelectCommand.CommandText = "pADM_MenuItems_SelectByLoginName";
				return ExecuteGetDataTable(SelectCommand);
			}
		}

        public DataRow GetMicroMenuByID(int menuID)
        {
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.Parameters.Add(GetParameter("@MenuID", SqlDbType.Int, menuID));
                SelectCommand.CommandText = "pADM_MenuItems_SelectByMenuId";
                return ExecuteGetDataRow(SelectCommand);
            }
        }

        public int InsertMenu(MicroMenu theMenu)
        {
            int ReturnValue = 0;
            using (SqlCommand InsertCommand = new SqlCommand())
            {
                InsertCommand.CommandType = CommandType.StoredProcedure;
                InsertCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                InsertCommand.Parameters.Add(GetParameter("@ParentMenuID", SqlDbType.Int, theMenu.ParentMenuID));
                InsertCommand.Parameters.Add(GetParameter("@MenuItemName", SqlDbType.VarChar, theMenu.MenuItemName));
                InsertCommand.Parameters.Add(GetParameter("@ShortcutKey", SqlDbType.VarChar, theMenu.ShortCutKey));
                InsertCommand.Parameters.Add(GetParameter("@ShortcutDisplayString", SqlDbType.VarChar, theMenu.ShortCutDisplayString));
                InsertCommand.Parameters.Add(GetParameter("@DisplayOrder", SqlDbType.Int, theMenu.DisplayOrder));
                InsertCommand.Parameters.Add(GetParameter("@ModuleID", SqlDbType.Int, theMenu.ModuleID));
                InsertCommand.Parameters.Add(GetParameter("@FormID", SqlDbType.Int, theMenu.FormID));
                InsertCommand.Parameters.Add(GetParameter("@IsActive", SqlDbType.Bit, theMenu.IsActive));
                InsertCommand.Parameters.Add(GetParameter("@AddedBy", SqlDbType.Int, Micro.Commons.Connection.LoggedOnUser.UserID));
                InsertCommand.CommandText = "pADM_MenuItems_Insert";
                ExecuteStoredProcedure(InsertCommand);
                ReturnValue = int.Parse(InsertCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int UpdateMenu(MicroMenu theMenu)
        {
            int ReturnValue = 0;
            using (SqlCommand UpdateCommand = new SqlCommand())
            {
                UpdateCommand.CommandType = CommandType.StoredProcedure;
                UpdateCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                UpdateCommand.Parameters.Add(GetParameter("@MenuID", SqlDbType.Int, theMenu.MenuID));
                UpdateCommand.Parameters.Add(GetParameter("@ParentMenuID", SqlDbType.Int, theMenu.ParentMenuID));
                UpdateCommand.Parameters.Add(GetParameter("@MenuItemName", SqlDbType.VarChar, theMenu.MenuItemName));
                UpdateCommand.Parameters.Add(GetParameter("@ShortcutKey", SqlDbType.VarChar, theMenu.ShortCutKey));
                UpdateCommand.Parameters.Add(GetParameter("@ShortcutDisplayString", SqlDbType.VarChar, theMenu.ShortCutDisplayString));
                UpdateCommand.Parameters.Add(GetParameter("@DisplayOrder", SqlDbType.Int, theMenu.DisplayOrder));
                UpdateCommand.Parameters.Add(GetParameter("@ModuleID", SqlDbType.Int, theMenu.ModuleID));
                UpdateCommand.Parameters.Add(GetParameter("@FormID", SqlDbType.Int, theMenu.FormID));
                UpdateCommand.Parameters.Add(GetParameter("@isActive", SqlDbType.Bit, theMenu.IsActive));
                UpdateCommand.CommandText = "pADM_MenuItems_Update";
                ExecuteStoredProcedure(UpdateCommand);
                ReturnValue = int.Parse(UpdateCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }

        public int DeleteMenu(int menuID)
        {
            int ReturnValue = 0;
            using (SqlCommand DeleteCommand = new SqlCommand())
            {
                DeleteCommand.CommandType = CommandType.StoredProcedure;
                DeleteCommand.Parameters.Add(GetParameter("@ReturnValue", SqlDbType.Int, ReturnValue)).Direction = ParameterDirection.Output;
                DeleteCommand.Parameters.Add(GetParameter("@MenuID", SqlDbType.Int, menuID));
                DeleteCommand.CommandText = "pADM_MenuItems_Delete";
                ExecuteStoredProcedure(DeleteCommand);
                ReturnValue = int.Parse(DeleteCommand.Parameters[0].Value.ToString());
                return ReturnValue;
            }
        }
        #endregion
    }
}
