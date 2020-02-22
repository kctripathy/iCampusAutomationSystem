using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class PaymentsMaturityIntegration
	{
		#region Declaration
		#endregion

		#region Methods & Implementations
		public static PaymentsMaturity DataRowToObject(DataRow dr)
		{
			PaymentsMaturity TheMaturityPayment = new PaymentsMaturity
			{
				MaturityID = int.Parse(dr["MaturityID"].ToString()),
				CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString()),
				MaturityFormNumber = dr["MaturityFormNumber"].ToString(),
				MaturityDate = DateTime.Parse(dr["MaturityDate"].ToString()).ToString(MicroConstants.DateFormat),
				MaturityPaymentDate = DateTime.Parse(dr["MaturityPaymentDate"].ToString()).ToString(MicroConstants.DateFormat),
				MaturityPrincipalPayable = decimal.Parse(dr["MaturityPrincipalPayable"].ToString()),
				MaturityPrincipalPaid = decimal.Parse(dr["MaturityPrincipalPaid"].ToString()),
				MaturityInterestPayable = decimal.Parse(dr["MaturityInterestPayable"].ToString()),
				MaturityInterestPaid = decimal.Parse(dr["MaturityInterestPaid"].ToString()),
				MaturityBonusPayable = decimal.Parse(dr["MaturityBonusPayable"].ToString()),
				MaturityBonusPaid = decimal.Parse(dr["MaturityBonusPaid"].ToString()),
				MaturityPrincipalDeductions = decimal.Parse(dr["MaturityPrincipalDeductions"].ToString()),
				MaturityPrincipalDeductionsRemarks = dr["MaturityPrincipalDeductionsRemarks"].ToString(),
				MaturityTotalPayable = decimal.Parse(dr["MaturityTotalPayable"].ToString()),
				MaturityTotalPaid = decimal.Parse(dr["MaturityTotalPaid"].ToString()),
			};

			return TheMaturityPayment;
		}

		public static List<PaymentsMaturity> GetMaturityPaymentList(bool allOffices = false, bool showDeleted = false)
		{
			List<PaymentsMaturity> MaturityPaymentList = new List<PaymentsMaturity>();
			DataTable MaturityPaymentTable =  PaymentsMaturityDataAccess.GetInstance.GetMaturityPaymentList(allOffices, showDeleted);

			foreach(DataRow dr in MaturityPaymentTable.Rows)
			{
				PaymentsMaturity TheMaturityPayment = DataRowToObject(dr);

				MaturityPaymentList.Add(TheMaturityPayment);
			}

			return MaturityPaymentList;
		}

		public static List<PaymentsMaturity> GetMaturityPaymentList(DateTime maturityPaymentDate, bool allOffices = false, bool showDeleted = false)
		{
			List<PaymentsMaturity> TheMaturityPaymentList = GetMaturityPaymentList(allOffices, showDeleted);

			if(TheMaturityPaymentList.Count > 0)
			{

				var MaturityPaymentList = (from MaturityPayments in TheMaturityPaymentList
										   where DateTime.Parse(MaturityPayments.MaturityPaymentDate) == maturityPaymentDate
										   select MaturityPayments).ToList();

				foreach(PaymentsMaturity TheMaturityPayments in MaturityPaymentList)
				{
					PaymentsMaturity ThePaymentsMaturity = (PaymentsMaturity)TheMaturityPayments;

					TheMaturityPaymentList.Add(ThePaymentsMaturity);
				}
			}

			return TheMaturityPaymentList;
		}

		public static int InsertPaymentMaturity(PaymentsMaturity thePaymentsMaturity)
		{
			return PaymentsMaturityDataAccess.GetInstance.InsertPaymentMaturity(thePaymentsMaturity);
		}
		#endregion
	}
}
