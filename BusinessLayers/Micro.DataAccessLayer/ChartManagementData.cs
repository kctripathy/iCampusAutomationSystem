using System.Data;
using System.Data.SqlClient;
using System;

namespace Micro.DataAccessLayer
{
	public class ChartManagementData : AbstractData_SQLClient
	{
		#region Code to make it singleton class
		/// Private static member to implement Singleton Desing Pattern
		/// </summary>
		private static ChartManagementData instance = new ChartManagementData();

		/// <summary>
		/// Static property of the class which will provide the singleton instance of it
		/// </summary>
		public static ChartManagementData GetInstance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		#region Methods
		public DataTable GetYearlyMaturity(int officeId)
		{
			using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
			{
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeId));
				SelectCommand.CommandText = "GetYearlyMaturityPaymentByOffice";
				return ExecuteGetDataTable(SelectCommand);
			}
		}


		public DataTable GetYearlyMISMaturity(int officeId)
		{
			using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
			{
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeId));
				SelectCommand.CommandText = "GetYearlyMISPaymentByOffice";
				return ExecuteGetDataTable(SelectCommand);
			}
		}


		public DataTable GetYearlyLICMaturity(int officeId)
		{
			using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
			{
				SelectCommand.Parameters.Add(GetParameter("@OfficeID", SqlDbType.Int, officeId));
				SelectCommand.CommandText = "GetYearlyLICPaymentByOffice";
				return ExecuteGetDataTable(SelectCommand);
			}
		}


		public DataTable GetStudentStrengthYearWise()
		{
			using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
			{
				SelectCommand.CommandText = "sp_Chart_GetStudentStrength";
				return ExecuteGetDataTable(SelectCommand);
			}
		}
		#endregion

		#region Methods for reading from XML file

		public DataTable GetReceiptPaymentReport(int parentOfficeId)
		{
			DataTable dtData = new DataTable();
			DataSet dSetData = new DataSet();
			dSetData.ReadXml(Micro.Commons.LocalPath.XMLFileChartData);
			dtData = dSetData.Tables[0];
			return dtData;
		}
#endregion
	}
}
