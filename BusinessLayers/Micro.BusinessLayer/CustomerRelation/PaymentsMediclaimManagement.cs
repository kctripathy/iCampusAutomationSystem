using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PaymentsMediclaimManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsMediclaimManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsMediclaimManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsMediclaimManagement();
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
        public string DefaultColumn = "CustomerName, CustomerCode, PaymentDate, AmountPaid";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "PaymentDate";
        #endregion

        #region Methods & Implementations
        public List<MediclaimPayment> GetMediClaimPaymentList(bool allOffices = false, bool showDeleted = false)
        {
            return PaymentsMediclaimIntegration.GetMediClaimPaymentList(allOffices, showDeleted);
        }

        public MediclaimPayment GetMediclaimPaymentByMediClaimApplicationID(int mediclaimApplicationID)
        {
            return PaymentsMediclaimIntegration.GetMediclaimPaymentByMediClaimApplicationID(mediclaimApplicationID);
        }

        public int InsertMediclaimPayment(MediclaimPayment theMediclaimPayment)
        {
            return PaymentsMediclaimIntegration.InsertMediclaimPayment(theMediclaimPayment);
        }
        #endregion
    }
}
