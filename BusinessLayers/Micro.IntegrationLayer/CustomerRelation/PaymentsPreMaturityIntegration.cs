using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class PaymentsPreMaturityIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static PaymentsPreMaturity DataRowToObjectPaymentmaturity(DataRow dr)
        {
            PaymentsPreMaturity ThePaymentsPreMaturity = new PaymentsPreMaturity();

            ThePaymentsPreMaturity.PreMaturityApprovalID = int.Parse(dr["PreMaturityApprovalID"].ToString());
            ThePaymentsPreMaturity.PreMaturityPaymentID = int.Parse(dr["PreMaturityPaymentID"].ToString());
            ThePaymentsPreMaturity.PreMaturityPaymentDate = DateTime.Parse(dr["PreMaturityPaymentDate"].ToString()).ToString(MicroConstants.DateFormat);
            ThePaymentsPreMaturity.PreMaturityPrincipalPaid = decimal.Parse(dr["PreMaturityPrincipalPaid"].ToString());
            ThePaymentsPreMaturity.PreMaturityInterestPaid = decimal.Parse(dr["PreMaturityInterestPaid"].ToString());
            ThePaymentsPreMaturity.PreMaturityBonusPaid = decimal.Parse(dr["PreMaturityBonusPaid"].ToString());
            ThePaymentsPreMaturity.PreMaturityTotalPaid = decimal.Parse(dr["PreMaturityTotalPaid"].ToString());
			ThePaymentsPreMaturity.PreMaturityFormNumber = dr["PreMaturityFormNumber"].ToString();

            return ThePaymentsPreMaturity;
        }

        public static List<PaymentsPreMaturity> GetPaymentsPrematurityList(bool allOffices = false, bool showDeleted = false)
        {
            List<PaymentsPreMaturity> GetPaymentsPrematurityList = new List<PaymentsPreMaturity>();

            DataTable GetPaymentsPrematurityTable = PaymentsPreMaturityDataAccess.GetInstance.GetPaymentsPrematurityList(allOffices,showDeleted);

            foreach (DataRow dr in GetPaymentsPrematurityTable.Rows)
            {
                PaymentsPreMaturity ThePaymentsPreMaturity = DataRowToObjectPaymentmaturity(dr);
                GetPaymentsPrematurityList.Add(ThePaymentsPreMaturity);
            }
            return GetPaymentsPrematurityList;
        }

        public static int InsertPaymentPreMaturity(PaymentsPreMaturity thePaymentsPreMaturity)
        {
            return PaymentsPreMaturityDataAccess.GetInstance.InsertPaymentPreMaturity(thePaymentsPreMaturity);
        }
        #endregion
    }
}
