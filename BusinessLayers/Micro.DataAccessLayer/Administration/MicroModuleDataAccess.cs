using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.Administration
{
	public partial class MicroModuleDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Private static member to implement Singleton Desing Pattern
		/// </summary>
		private static MicroModuleDataAccess instance = new MicroModuleDataAccess();

		/// <summary>
		/// Static property of the class which will provide the singleton instance of it
		/// </summary>
		public static MicroModuleDataAccess GetInstance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		#region Declaration
		#endregion

		#region Methods & Implementation
		public DataTable GetMicroModules()
		{
            using (SqlCommand SelectCommand = new SqlCommand())
            {
                SelectCommand.CommandType = CommandType.StoredProcedure;
                SelectCommand.CommandText = "pADM_Modules_SelectAll";
                return ExecuteGetDataTable(SelectCommand);
            }
		}
		#endregion
	}
}
