using System;
using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PaymentsLICMoneybackManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsLICMoneybackManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsLICMoneybackManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsLICMoneybackManagement();
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
        public string DefaultColumns = "CustomerAccountCode, CustomerName, DueDateOfPayment, MoneyBackPayable, MoneyBackDescription, ActualDateOfPayment, ActualMoneyBackAmountPaid, PaymentStatus";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "LICMoneyBackID";
        #endregion

        #region Methods & Implementations
        public List<PaymentsLICMoneyback> GetLICMoneybackPaymentsStatusListByCustomerAccountID(string paymentStatus,int customerAccountID)
        {
            return PaymentsLICMoneybackIntegration.GetLICMoneybackPaymentsStatusListByCustomerAccountID(paymentStatus, customerAccountID);
        }
        
        public List<PaymentsLICMoneyback> GetLICMoneybackPaymentsDueListByCustomerAccountID(DateTime dueDateOfPayment,int customerAccountID)
        {
            return PaymentsLICMoneybackIntegration.GetLICMoneybackPaymentsDueListByCustomerAccountID(dueDateOfPayment, customerAccountID);
        }

        public int UpdateLICMoneyBackPayment(List<PaymentsLICMoneyback> paymentsLICMoneyBackList)
        {
            return PaymentsLICMoneybackIntegration.UpdateLICMoneyBackPayment(paymentsLICMoneyBackList);
        }
        #endregion
    }
}
