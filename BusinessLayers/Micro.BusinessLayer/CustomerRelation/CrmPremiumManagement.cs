using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class CrmPremiumManagement
    {

        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CrmPremiumManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CrmPremiumManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CrmPremiumManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Methods & Implementation

        public List<CRMPolicy> GetPolicy()
        {
            return CrmPremiumIntegration.GetPolicy();
        }

        public List<CRMPremium> GetPremium()
        {
            return CrmPremiumIntegration.GetPremium();
        }

        public int InsertPremium(CRMPremium theCrmPremium)
        {

            return CrmPremiumIntegration.InsertPremium(theCrmPremium);

        }

        public int UpdatePremium(CRMPremium theCrmPremium)
        {

            return CrmPremiumIntegration.UpdatePremium(theCrmPremium);

        }

        public int DeletePremium(CRMPremium theCrmPremium)
        {

            return CrmPremiumIntegration.DeletePremium(theCrmPremium);

        }

        public CRMPremium GetPremiumById(int recordId)
        {
            return CrmPremiumIntegration.GetPremiumById(recordId);
        }

        #endregion

    }
}
