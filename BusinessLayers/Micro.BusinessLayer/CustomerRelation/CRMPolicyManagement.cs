using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class CRMPolicyManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CRMPolicyManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CRMPolicyManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CRMPolicyManagement();
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
		public string PolicyDefaultColumns = "PolicyName, PolicyFromOrganization, TenureInYears, EffectiveDateFrom, OfficeName";
        public string PolicyTypeDefaultColumns = "PolicyName, PolicyTypeDescription, PolicyFromOrganization, TenureInYears, EffectiveDateFrom, OfficeName,PolicyTypeID";
        public string PolicyDisplayMember = "PolicyName";
        public string PolicyValueMember = "PolicyID";
        public string PolicyTypeDisplayMember = "PolicyName";
        public string PolicyTypeValueMember = "PolicyTypeID";
		#endregion

		#region Methods & Implementation
        public List<CRMPolicy> GetCRMPolicyList()
        {
            return CRMPolicyIntegration.GetCRMPolicyList();
        }

        public List<CRMPolicy> GetCRMPolicyListByID(int policyID)
        {
            return CRMPolicyIntegration.GetCRMPolicyListByID(policyID);
        }

		public List<CRMPolicy> GetCRMPolicyTypeList()
		{
			return CRMPolicyIntegration.GetCRMPolicyTypeList();
		}

        public CRMPolicy GetCRMPolicyTypeByID(int policyTypeID)
        {
            return CRMPolicyIntegration.GetCRMPolicyTypeByID(policyTypeID);
        }

        /// <summary>
        /// Show PolicyTypes useing INNER JOIN on CRM_MST_PolicyTypeOfficewise)
        /// </summary>
        /// <param name="ShowInOfficewise">If false show only those PolicyTypes that are not in CRM_MST_PolicyTypeOfficewise</param>
        /// <returns></returns>
        public List<CRMPolicy> GetCRMPolicyTypeListByOfficeID(bool showInOfficewise = false)
        {
            return CRMPolicyIntegration.GetCRMPolicyTypeListByOfficeID(showInOfficewise);
        }

        public List<CRMPolicy> GetCRMPolicyTypeOfficewiseList(bool allOffices = false, bool showDeleted = false)
        {
            return CRMPolicyIntegration.GetCRMPolicyTypeOfficewiseList(allOffices, showDeleted);
        }

		public int InsertCRMPolicy(CRMPolicy theCRMPolicy)
        {
            return CRMPolicyIntegration.InsertCRMPolicy(theCRMPolicy);
        }

		public int InsertCRMPolicyTypes(List<CRMPolicy> theCrmPolicyList)
        {
            return CRMPolicyIntegration.InsertCRMPolicyTypes(theCrmPolicyList);
        }

        public int UpdateCRMPolicy(CRMPolicy theCRMPolicy)
        {
            return CRMPolicyIntegration.UpdateCRMPolicy(theCRMPolicy);
        }

		public int UpdateCRMPolicyTypes(List<CRMPolicy> theCRMPolicyList)
        {
			return CRMPolicyIntegration.UpdateCRMPolicyTypes(theCRMPolicyList);
        }

		public int DeleteCRMPolicy(CRMPolicy theCRMPolicy)
        {
            return CRMPolicyIntegration.DeleteCRMPolicy(theCRMPolicy);
        }
        #endregion
    }
}
