using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.Administration
{
	public partial class MicroSettingDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Private static member to implement Singleton Desing Pattern
		/// </summary>
		private static MicroSettingDataAccess instance = new MicroSettingDataAccess();

		/// <summary>
		/// Static property of the class which will provide the singleton instance of it
		/// </summary>
		public static MicroSettingDataAccess GetInstance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		#region Methods & Implementation
		public DataTable GetSettingList()
		{
			SqlCommand SelectCommand = new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.CommandText = "pADM_Settings_SelectAll";

			return ExecuteGetDataTable(SelectCommand);
		}
		#endregion
	}
}
