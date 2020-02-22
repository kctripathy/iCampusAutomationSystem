using System.Collections.Generic;
using Micro.Objects;
using System.Data;
using Micro.DataAccessLayer;

namespace Micro.IntegrationLayer
{
	public class ChartIntegration
	{
		public static DataTable GetStudentStrengthYearWise()
		{
			//using (SqlCommand SelectCommand = new SqlCommand { CommandType = CommandType.StoredProcedure })
			//{
			//	SelectCommand.CommandText = "sp_Chart_GetStudentStrength";
			//	return ExecuteGetDataTable(SelectCommand);
			//}
			return ChartManagementData.GetInstance.GetStudentStrengthYearWise();
		}

		public static List<YearlyMaturity> GetYearlyMaturity(int officeId)
		{
			List<YearlyMaturity> YearlyMaturityList = new List<YearlyMaturity>();

			// Maturity Payments
			DataTable YearlyMaturityTable = ChartManagementData.GetInstance.GetYearlyMaturity(officeId);
			foreach (DataRow rowMaturity in YearlyMaturityTable.Rows)
			{
				YearlyMaturity y = new YearlyMaturity();
				y.MaturityYear = int.Parse(rowMaturity["MaturityYear"].ToString());
				y.MaturityAmount = double.Parse(rowMaturity["MaturityAmount"].ToString());
				YearlyMaturityList.Add(y);
			}


			// ------------------------
			// LIC Moneyback payments 
			// ------------------------
			DataTable YearlyLICMaturity = ChartManagementData.GetInstance.GetYearlyLICMaturity(officeId);
			foreach (DataRow rowLIC in YearlyLICMaturity.Rows)
			{
				bool IsFound = false;
				for (int x = 0; x < YearlyMaturityList.Count; x++)
				{
					if (rowLIC["MaturityYear"].ToString().Trim().Equals(YearlyMaturityList[x].MaturityYear.ToString().Trim()))
					{
						// Add the yearly maturity amount to the previously got values 
						YearlyMaturityList[x].MaturityAmount += double.Parse(rowLIC["MaturityAmount"].ToString());
						IsFound = true;
						break;
					}
				}
				if (!IsFound)
				{
					// Add a new year, if there is no record found for previous one
					YearlyMaturity ym = new YearlyMaturity 
					{ 
						MaturityYear = int.Parse(rowLIC["MaturityYear"].ToString()), 
						MaturityAmount = double.Parse(rowLIC["MaturityAmount"].ToString()) 
					};
					YearlyMaturityList.Add(ym);
				}

			}



			//// MIS Payments
			DataTable YearlyMISMaturity = ChartManagementData.GetInstance.GetYearlyMISMaturity(officeId);
			foreach (DataRow dRowMIS in YearlyMISMaturity.Rows)
			{
				bool IsFound = false;
				for (int x = 0; x < YearlyMaturityList.Count - 1; x++)
				{
					if (dRowMIS["MaturityYear"].ToString().Trim().Equals(YearlyMaturityList[x].MaturityYear.ToString().Trim()))
					{
						// Add the yearly maturity amount to the previously got values 
						YearlyMaturityList[x].MaturityAmount += double.Parse(dRowMIS["MaturityAmount"].ToString());
						IsFound = true;
						break;
					}
				}
				if (!IsFound)
				{
					// Add a new year, if there is no record found for previous one
					YearlyMaturity y = new YearlyMaturity();
					y.MaturityYear = int.Parse(dRowMIS["MaturityYear"].ToString());
					y.MaturityAmount = double.Parse(dRowMIS["MaturityAmount"].ToString());
					YearlyMaturityList.Add(y);
				}
			}

			return YearlyMaturityList;
		}


		public static DataTable GetReceiptPaymentReport(int parentOfficeId)
		{
			return ChartManagementData.GetInstance.GetReceiptPaymentReport(parentOfficeId);
		}


	}
}
