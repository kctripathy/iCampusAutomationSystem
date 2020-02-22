using System.Data;
using System.Data.SqlClient;

namespace Micro.DataAccessLayer.Administration
{
	public partial class MicroReportDataAccess : AbstractData_SQLClient
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Private static member to implement Singleton Desing Pattern
		/// </summary>
		private static MicroReportDataAccess instance = new MicroReportDataAccess();

		/// <summary>
		/// Static property of the class which will provide the singleton instance of it
		/// </summary>
		public static MicroReportDataAccess GetInstance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		public DataRow GetReportByName(string reportDisplayName)
		{
			SqlCommand SelectCommand = new SqlCommand();

			SelectCommand.CommandType = CommandType.StoredProcedure;
			SelectCommand.Parameters.Add(GetParameter("@ReportDisplayName", SqlDbType.VarChar, reportDisplayName));
			SelectCommand.CommandText = "pADM_Reports_SelectByDisplayName";

			return ExecuteGetDataRow(SelectCommand);
		}
	}
}
