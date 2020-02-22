using System.Data;
using Micro.DataAccessLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.IntegrationLayer.Administration
{
	public partial class MicroReportIntegration
	{
		public static MicroReport GetReportByName(string reportDisplayName)
		{
			MicroReport TheMicroReport = new MicroReport();

			DataRow TheMicroReportRow = MicroReportDataAccess.GetInstance.GetReportByName(reportDisplayName);

			TheMicroReport.ReportID = int.Parse(TheMicroReportRow["ReportID"].ToString());
			TheMicroReport.ReportDisplayName = TheMicroReportRow["ReportDisplayName"].ToString();
			TheMicroReport.ReportFileName = TheMicroReportRow["ReportFileName"].ToString();
			TheMicroReport.ReportFilePath = TheMicroReportRow["ReportFilePath"].ToString();
			TheMicroReport.ReportTitle = TheMicroReportRow["ReportTitle"].ToString();
			TheMicroReport.ModuleID=int.Parse(TheMicroReportRow["ModuleID"].ToString());
			TheMicroReport.ModuleName = TheMicroReportRow["ModuleName"].ToString();

			return TheMicroReport;
		}
	}
}
