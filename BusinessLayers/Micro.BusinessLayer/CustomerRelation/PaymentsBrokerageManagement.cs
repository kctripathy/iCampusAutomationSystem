using System.Collections.Generic;
using System.Linq;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PaymentsBrokerageManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsBrokerageManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsBrokerageManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsBrokerageManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string DefaultColumns = "FromDate, ToDate, FieldForceCode, FieldForceName, ForMonth, ForYear ";
        public string DisplayMember = "FieldForceName";
        public string ValueMember = "PaymentsBrokerageID";
        #endregion

        #region Methods & Implementations
        public List<PaymentsBrokerage> GetBrokeragePaybleDetails(int fieldForceId, string brokerageType)
        {
            return PaymentsBrokerageIntegration.GetBrokeragePaybleDetails(fieldForceId, brokerageType);
        }

        public decimal GetAmountPayble(List<PaymentsBrokerage> paymentsBrokerageList)
        {
            var PaymentsBrokerageList = (from FieldForces in paymentsBrokerageList
                                         select FieldForces.BrokerageAmount).Sum();

            return PaymentsBrokerageList;
        }

        public int CalculateAndInsertCommissionPayable(PaymentsBrokerage thePaymentsBrokerage)
        {
            return PaymentsBrokerageIntegration.CalculateAndInsertCommissionPayable(thePaymentsBrokerage);
        }

        public int InsertPaymentBrokerage(PaymentsBrokerage thePaymentsBrokerage)
        {
            return PaymentsBrokerageIntegration.InsertPaymentBrokerage(thePaymentsBrokerage);
        }

        public int CalculateAndInsertIncentiveMonthly(int Month, int Year)
        {
            return PaymentsBrokerageIntegration.CalculateAndInsertIncentiveMonthly(Month,Year);
        }
        public int CalculateAndInsertIncentiveYearly(string DateFrom,string DateTo)
        {
            return PaymentsBrokerageIntegration.CalculateAndInsertIncentiveYearly(DateFrom,DateTo);
        }
        #endregion
    }
}
