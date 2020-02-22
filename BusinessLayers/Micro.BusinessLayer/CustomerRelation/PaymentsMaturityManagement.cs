using System;
using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PaymentsMaturityManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PaymentsMaturityManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PaymentsMaturityManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PaymentsMaturityManagement();
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
        public string DefaultColumns = "MaturityFormNumber, MaturityDate, MaturityPaymentDate, MaturityPrincipalPayable, MaturityPrincipalPaid, MaturityInterestPayable, MaturityInterestPaid, MaturityBonusPayable, MaturityBonusPaid,MaturityTotalPayable,MaturityTotalPaid";
        public string DisplayMember = "MaturityDate";
        public string ValueMember = "MaturityID";
        #endregion

        #region Methods & Implementations
        public List<PaymentsMaturity> GetMaturityPaymentList(bool allOffices = false, bool showDeleted = false)
        {
            return PaymentsMaturityIntegration.GetMaturityPaymentList(allOffices, showDeleted);
        }

        public List<PaymentsMaturity> GetMaturityPaymentList(DateTime maturityPaymentDate, bool allOffices = false, bool showDeleted = false)
        {
            return PaymentsMaturityIntegration.GetMaturityPaymentList(maturityPaymentDate, allOffices, showDeleted);
        }

        public int InsertPaymentMaturity(PaymentsMaturity thePaymentsMaturity)
        {
            return PaymentsMaturityIntegration.InsertPaymentMaturity(thePaymentsMaturity);
        }
        #endregion
    }
}
