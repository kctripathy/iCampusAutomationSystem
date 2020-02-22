using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PaymentsPreMaturityManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsPreMaturityManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsPreMaturityManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsPreMaturityManagement();
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
        public string DefaultColumns = "PreMaturityFormNumber, PreMaturityDate, PreMaturityPaymentDate, PreMaturityPrincipalPaid, PreMaturityInterestPaid, PreMaturityBonusPaid, PreMaturityTotalPaid";
        public string DisplayMember = "PreMaturityFormNumber";
        public string ValueMember = "PreMaturityPaymentID";
        #endregion

        #region Methods & Implementations
        public List<PaymentsPreMaturity> GetPaymentsPrematurityList(bool allOffices = false, bool showDeleted = false)
        {
            return PaymentsPreMaturityIntegration.GetPaymentsPrematurityList(allOffices,showDeleted);
        }

        public  int InsertPaymentPreMaturity(PaymentsPreMaturity thePaymentsPreMaturity)
        {
            return PaymentsPreMaturityIntegration.InsertPaymentPreMaturity(thePaymentsPreMaturity);
        }
        #endregion
    }
}
