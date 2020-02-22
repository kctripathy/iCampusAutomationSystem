using System;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class PolicyTypeOfficeWiseIntegration
    {
        #region Methods & Implementation
        public static PolicyTypesOfficeWise PolicyTypesDataRowToObject(DataRow dr)
        {
            PolicyTypesOfficeWise TheCRMPolicyType = new PolicyTypesOfficeWise();

            TheCRMPolicyType.PolicyTypeOfficewiseID = int.Parse(dr["PolicyTypeOfficewiseID"].ToString());
            TheCRMPolicyType.PolicyTypeID = int.Parse(dr["PolicyTypeID"].ToString());
            TheCRMPolicyType.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheCRMPolicyType.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
            if (!string.IsNullOrEmpty(dr["EffectiveDateTo"].ToString()))
                TheCRMPolicyType.EffectiveDateTo = DateTime.Parse(dr["EffectiveDateTo"].ToString()).ToString(MicroConstants.DateFormat);
            TheCRMPolicyType.PolicyTypeDescription = dr["PolicyTypeDescription"].ToString();
            TheCRMPolicyType.PolicyName = dr["PolicyName"].ToString();
            TheCRMPolicyType.PolicyFromOrganization = dr["PolicyFromOrganization"].ToString();
            TheCRMPolicyType.OfficeName = dr["OfficeName"].ToString();
            TheCRMPolicyType.OfficeCode = dr["OfficeCode"].ToString();

            return TheCRMPolicyType;
        }

        public static int InsertPolicyTypes(string PolicyTypeIds, string EffectiveDateFrom)
        {
            return PolicyTypeOfficeWiseDataAccess.GetInstance.InsertPolicyTypes(PolicyTypeIds, EffectiveDateFrom);
        }

        public static int DeletePolicyTypes(string PolicyTypeIds)
        {
            return PolicyTypeOfficeWiseDataAccess.GetInstance.DeletePolicyTypes(PolicyTypeIds);
        }
        #endregion
    }
}
