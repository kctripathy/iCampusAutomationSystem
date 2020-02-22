using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class PolicyTypeOfficeWiseManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static PolicyTypeOfficeWiseManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static PolicyTypeOfficeWiseManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PolicyTypeOfficeWiseManagement();
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
        public string DefaultColumn = "PolicyName,PolicyFromOrganization,EffectiveDateFrom,EffectiveDateTo";
        public string DisplayMember = "PolicyName";
        public string ValueMember = "PolicyTypeOfficewiseID";
        #endregion

        #region Methods & Implementation

        public int InsertPolicyTypes(string PolicyTypeIds, string EffectiveDateFrom)
        {
            return PolicyTypeOfficeWiseIntegration.InsertPolicyTypes(PolicyTypeIds, EffectiveDateFrom);
        }

        public int DeletePolicyTypes(string PolicyTypeIds)
        {
            return PolicyTypeOfficeWiseIntegration.DeletePolicyTypes(PolicyTypeIds);
        }
        #endregion
    }
}
