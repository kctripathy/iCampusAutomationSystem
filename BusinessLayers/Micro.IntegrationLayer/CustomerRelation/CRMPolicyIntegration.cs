using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class CRMPolicyIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static CRMPolicy PolicyDataRowToObject(DataRow dr)
        {
            CRMPolicy TheCRMPolicy = new CRMPolicy
            {
                PolicyID = int.Parse(dr["PolicyID"].ToString()),
                PolicyName = dr["PolicyName"].ToString(),
                PolicyFromOrganization = dr["PolicyFromOrganization"].ToString(),
                TenureInYears = dr["TenureInYears"].ToString(),
                TenureInMonths = int.Parse(dr["TenureInMonths"].ToString()),
                AllowDeathCompensation = bool.Parse(dr["AllowDeathCompensation"].ToString()),
                AllowMediclaim = bool.Parse(dr["AllowMediclaim"].ToString()),
                AllowPolicySurrender = bool.Parse(dr["AllowPolicySurrender"].ToString()),
                AllowPreMaturity = bool.Parse(dr["AllowPreMaturity"].ToString()),
                AllowRevival = bool.Parse(dr["AllowRevival"].ToString()),
                DatabaseTableName = dr["DatabaseTableName"].ToString(),
                StoredProcedureName = dr["StoredProcedureName"].ToString(),
                EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat),
                OfficeID = int.Parse(dr["OfficeID"].ToString()), /*CompanyID*/
                OfficeName = dr["OfficeName"].ToString()
            };

            return TheCRMPolicy;
        }

        public static CRMPolicy PolicyTypeDataRowToObject(DataRow dr)
        {
            CRMPolicy TheCRMPolicyType = new CRMPolicy
            {
                PolicyID = int.Parse(dr["PolicyID"].ToString()),
                PolicyName = dr["PolicyName"].ToString(),
                PolicyFromOrganization = dr["PolicyFromOrganization"].ToString(),
                TenureInYears = dr["TenureInYears"].ToString(),
                TenureInMonths = int.Parse(dr["TenureInMonths"].ToString()),
                AllowDeathCompensation = bool.Parse(dr["AllowDeathCompensation"].ToString()),
                AllowMediclaim = bool.Parse(dr["AllowMediclaim"].ToString()),
                AllowPolicySurrender = bool.Parse(dr["AllowPolicySurrender"].ToString()),
                AllowPreMaturity = bool.Parse(dr["AllowPreMaturity"].ToString()),
                AllowRevival = bool.Parse(dr["AllowRevival"].ToString()),
                DatabaseTableName = dr["DatabaseTableName"].ToString(),
                StoredProcedureName = dr["StoredProcedureName"].ToString(),
                EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat),
                OfficeID = int.Parse(dr["OfficeID"].ToString()),
                OfficeName = dr["OfficeName"].ToString(),
                PolicyTypeID = int.Parse(dr["PolicyTypeID"].ToString()),
                PolicyTypeDescription = dr["PolicyTypeDescription"].ToString(),
                PolicySubType = dr["PolicySubType"].ToString()
            };

            return TheCRMPolicyType;
        }

        public static List<CRMPolicy> GetCRMPolicyList()
        {
            List<CRMPolicy> CRMPolicyList = new List<CRMPolicy>();
            DataTable CRMPolicyTable = CRMPolicyDataAccess.GetInstance.GetCRMPolicyList();

            foreach (DataRow dr in CRMPolicyTable.Rows)
            {
                CRMPolicy TheCRMPolicy = PolicyDataRowToObject(dr);

                CRMPolicyList.Add(TheCRMPolicy);
            }

            return CRMPolicyList;
        }

        public static List<CRMPolicy> GetCRMPolicyListByID(int policyID)
        {
            List<CRMPolicy> CRMPolicyList = new List<CRMPolicy>();
            DataTable CRMPolicyTable = CRMPolicyDataAccess.GetInstance.GetCRMPolicyListByID(policyID);

            foreach (DataRow dr in CRMPolicyTable.Rows)
            {
                CRMPolicy TheCRMPolicy = PolicyTypeDataRowToObject(dr);

                CRMPolicyList.Add(TheCRMPolicy);
            }

            return CRMPolicyList;
        }

        public static List<CRMPolicy> GetCRMPolicyTypeList()
        {
            List<CRMPolicy> CRMPolicyList = new List<CRMPolicy>();
            DataTable CRMPolicyTypeTable = CRMPolicyDataAccess.GetInstance.GetCRMPolicyTypeList();

            foreach (DataRow dr in CRMPolicyTypeTable.Rows)
            {
                CRMPolicy TheCRMPolicy = PolicyTypeDataRowToObject(dr);

                CRMPolicyList.Add(TheCRMPolicy);
            }

            return CRMPolicyList;
        }

        public static CRMPolicy GetCRMPolicyTypeByID(int policyTypeID)
        {
            CRMPolicy TheCRMPolicyType;
            DataRow CRMPolicyTypeRow = CRMPolicyDataAccess.GetInstance.GetCRMPolicyTypeByID(policyTypeID);

            if (CRMPolicyTypeRow != null)
                TheCRMPolicyType = PolicyTypeDataRowToObject(CRMPolicyTypeRow);
            else
                TheCRMPolicyType = new CRMPolicy();

            return TheCRMPolicyType;
        }

        public static List<CRMPolicy> GetCRMPolicyTypeListByOfficeID(bool showInOfficewise = false)
        {
            List<CRMPolicy> CRMPolicyList = new List<CRMPolicy>();
            DataTable CRMPolicyTableType = CRMPolicyDataAccess.GetInstance.GetCRMPolicyTypeListByOfficeID(showInOfficewise);

            foreach (DataRow dr in CRMPolicyTableType.Rows)
            {
                CRMPolicy TheCRMPolicy = PolicyTypeDataRowToObject(dr);

                CRMPolicyList.Add(TheCRMPolicy);
            }

            return CRMPolicyList;
        }

        public static List<CRMPolicy> GetCRMPolicyTypeOfficewiseList(bool allOffices = false, bool showDeleted = false)
        {
            List<CRMPolicy> CRMPolicyList = new List<CRMPolicy>();
            DataTable CRMPolicyTableType = CRMPolicyDataAccess.GetInstance.GetCRMPolicyTypeOfficewiseList(allOffices, showDeleted);

            foreach (DataRow dr in CRMPolicyTableType.Rows)
            {
                CRMPolicy TheCRMPolicy = PolicyTypeDataRowToObject(dr);

                CRMPolicyList.Add(TheCRMPolicy);
            }

            return CRMPolicyList;
        }

        public static int InsertCRMPolicy(CRMPolicy theCRMPolicy)
        {
            return CRMPolicyDataAccess.GetInstance.InsertCRMPolicy(theCRMPolicy);
        }

        public static int InsertCRMPolicyTypes(List<CRMPolicy> theCrmPolicyList)
        {
            return CRMPolicyDataAccess.GetInstance.InsertCRMPolicyTypes(theCrmPolicyList);
        }

        public static int UpdateCRMPolicy(CRMPolicy theCRMPolicy)
        {
            return CRMPolicyDataAccess.GetInstance.UpdateCRMPolicy(theCRMPolicy);
        }

        public static int UpdateCRMPolicyTypes(List<CRMPolicy> theCRMPolicyList)
        {
            return CRMPolicyDataAccess.GetInstance.UpdateCRMPolicyTypes(theCRMPolicyList);
        }

        public static int DeleteCRMPolicy(CRMPolicy theCRMPolicy)
        {
            return CRMPolicyDataAccess.GetInstance.DeleteCRMPolicy(theCRMPolicy);
        }
        #endregion
    }
}
