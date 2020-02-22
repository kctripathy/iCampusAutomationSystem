using System;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class PaymentsBrokerageIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static List<PaymentsBrokerage> GetBrokeragePaybleDetails(int fieldForceId, string brokerageType)
        {
            List<PaymentsBrokerage> PaymentsBrokerageList = new List<PaymentsBrokerage>();

            DataTable PaymentsBrokerageTable = new DataTable();
            PaymentsBrokerageTable = PaymentsBrokerageDataAccess.GetInstance.GetBrokeragePaybleDetails(fieldForceId, brokerageType);

            foreach (DataRow dr in PaymentsBrokerageTable.Rows)
            {
                PaymentsBrokerage ThePaymentsBrokerage = new PaymentsBrokerage();
                if (!string.IsNullOrEmpty(dr["ForMonth"].ToString()))
                {
                    ThePaymentsBrokerage.ForMonth = int.Parse(dr["ForMonth"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ForYear"].ToString()))
                {
                    ThePaymentsBrokerage.ForYear = int.Parse(dr["ForYear"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FieldForceID"].ToString()))
                {
                    ThePaymentsBrokerage.FieldForceID = int.Parse(dr["FieldForceID"].ToString());
                }
                ThePaymentsBrokerage.FieldForceCode = dr["FieldForceCode"].ToString();
                ThePaymentsBrokerage.FieldForceName = dr["FieldForceName"].ToString();
                if (!string.IsNullOrEmpty(dr["BrokerageAmount"].ToString()))
                {
                    ThePaymentsBrokerage.BrokerageAmount = Decimal.Parse(dr["BrokerageAmount"].ToString());
                }
                ThePaymentsBrokerage.BrokerageType = dr["BrokerageType"].ToString();
                ThePaymentsBrokerage.BusinessType = dr["BusinessType"].ToString();
                if (!string.IsNullOrEmpty(dr["BusinessAmount"].ToString()))
                {
                    ThePaymentsBrokerage.BusinessAmount = Decimal.Parse(dr["BusinessAmount"].ToString());
                }

                PaymentsBrokerageList.Add(ThePaymentsBrokerage);
            }
            return PaymentsBrokerageList;
        }

        public static int CalculateAndInsertCommissionPayable(PaymentsBrokerage thePaymentsBrokerage)
        {
            return PaymentsBrokerageDataAccess.GetInstance.CalculateAndInsertCommissionPayable(thePaymentsBrokerage);
        }

        public static int InsertPaymentBrokerage(PaymentsBrokerage thePaymentsBrokerage)
        {
            return PaymentsBrokerageDataAccess.GetInstance.InsertPaymentBrokerage(thePaymentsBrokerage);
        }

        public static int CalculateAndInsertIncentiveMonthly(int Month, int Year)
        {
            return PaymentsBrokerageDataAccess.GetInstance.CalculateAndInsertIncentiveMonthly(Month,Year);
        }
        public static int CalculateAndInsertIncentiveYearly(string DateFrom,string DateTo)
        {
            return PaymentsBrokerageDataAccess.GetInstance.CalculateAndInsertIncentiveYearly(DateFrom,DateTo);
        }
        #endregion
    }
}
