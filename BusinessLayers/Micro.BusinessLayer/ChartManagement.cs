using System;
using System.Collections.Generic;
using Micro.Objects;
using Micro.IntegrationLayer;
using System.Web;
using System.Data;

namespace Micro.BusinessLayer
{
	public class ChartManagement
	{
		public static DataTable GetStudentStrengthYearWise()
		{

			string UniqueKey = String.Format("GetStudentStrengthYearWise");
			if (HttpRuntime.Cache[UniqueKey] == null )
			{
				DataTable dt = ChartIntegration.GetStudentStrengthYearWise();
				HttpRuntime.Cache[UniqueKey] = dt;
			}
			return (DataTable)(HttpRuntime.Cache[UniqueKey]);
		}

		public static List<YearlyMaturity> GetYearlyMaturity(int officeId, bool willRefresh = false)
		{

			string UniqueKey = String.Format("GetYearlyMaturity_", officeId.ToString());
			if (HttpRuntime.Cache[UniqueKey] == null || willRefresh == true)
			{
				List<YearlyMaturity> YearlyMaturity = ChartIntegration.GetYearlyMaturity(officeId);
				HttpRuntime.Cache[UniqueKey] = YearlyMaturity;
			}
			return (List<YearlyMaturity>)(HttpRuntime.Cache[UniqueKey]);
		}

		public static DataTable GetReceiptPaymentReport(int parentOfficeId, bool willRefresh=false)
		{

			//string UniqueKey = String.Format("GetReceiptPaymentReport", parentOfficeId.ToString());
			//if (HttpRuntime.Cache[UniqueKey] == null)
			//{
			//    DataTable dt = ChartIntegration.GetReceiptPaymentReport(parentOfficeId);
			//    HttpRuntime.Cache[UniqueKey] = dt;
			//}
			//return (DataTable)(HttpRuntime.Cache[UniqueKey]);

			DataTable dt = ChartIntegration.GetReceiptPaymentReport(parentOfficeId);
			return dt;
		}
	}
}
