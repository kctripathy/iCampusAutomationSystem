using System;
using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class CRMScrollManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CRMScrollManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CRMScrollManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CRMScrollManagement();
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
		public string DefaultColumns = "ScrollNumber, DepositorName, ScrollAmountPayable, ScrollAmountPaid, ScrollStatus";
        public string DisplayMember = "ScrollNumber";
        public string ValueMember = "ScrollID";
        #endregion

        #region Methods & Implementation
        public List<CRMScroll> GetCRMScrollListByDate(DateTime scrollDate)
        {
            return CRMScrollIntegration.GetCRMScrollListByDate(scrollDate);
        }

        public CRMScroll GetCRMScrollByID(int recordId)
        {
            return CRMScrollIntegration.GetCRMScrollByID(recordId);
        }

        public CRMScroll GetLastCRMScrollByOfficeID()
        {
            return CRMScrollIntegration.GetLastCRMScrollByOfficeID();
        }

        public int InsertCRMScroll(CRMScroll theCRMScroll)
        {
            return CRMScrollIntegration.InsertCRMScroll(theCRMScroll);
        }

        public int UpdateCRMScroll(CRMScroll theCRMScroll)
        {
            return CRMScrollIntegration.UpdateCRMScroll(theCRMScroll);
        }

		public int UpdateCRMScrollStatus(int theCRMScrollID, decimal theCRMScrollAmountPaid, string theCRMScrollStatus)
		{
			return CRMScrollIntegration.UpdateCRMScrollStatus(theCRMScrollID, theCRMScrollAmountPaid, theCRMScrollStatus);
		}

        public int DeleteCRMScroll(CRMScroll theCRMScroll)
        {
            return CRMScrollIntegration.DeleteCRMScroll(theCRMScroll);
        }
        #endregion
    }
}
