using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class CrmPremiumIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static List<CRMPolicy> GetPolicy()
        {
            List<CRMPolicy> CRMPolicyList = new List<CRMPolicy>();

            DataTable GetPolicyTable = CrmPremiumDataAccess.GetInstance.GetPolicy();

            foreach (DataRow dr in GetPolicyTable.Rows)
            {
				CRMPolicy ThePolicy = new CRMPolicy
				{
					PolicyID = int.Parse(dr["PolicyID"].ToString()),
					PolicyName = dr["PolicyName"].ToString(),
					PremiumTableReferenceName = dr["PremiumTableReferenceName"].ToString(),
					PremiumTableDescriptiveName = dr["PremiumTableDescriptiveName"].ToString(),
					TenureInYears = dr["TenureInYears"].ToString(),
					EffectiveDateFrom = dr["EffectiveDateFrom"].ToString()
				};

                

                CRMPolicyList.Add(ThePolicy);
            }
            return CRMPolicyList;
        }

        public static List<CRMPremium> GetPremium()
        {
            List<CRMPremium> CRMPremiumList = new List<CRMPremium>();

            DataTable GetPremiumTable  = CrmPremiumDataAccess.GetInstance.GetPremium();

            foreach (DataRow dr in GetPremiumTable.Rows)
            {
				CRMPremium ThePremium = new CRMPremium
				{
					PremiumTableID = int.Parse(dr["PremiumTableID"].ToString()),
					PolicyID = int.Parse(dr["PolicyID"].ToString()), /*ThePremium.PolicyName = dr["PolicyName"].ToString();*/
					PremiumTableReferenceName = dr["PremiumTableReferenceName"].ToString(),
					PremiumTableDescriptiveName = dr["PremiumTableDescriptiveName"].ToString(),
					TenureInYears = double.Parse(dr["TenureInYears"].ToString()),
					EffectiveDateFrom = dr["EffectiveDateFrom"].ToString()
				};

                CRMPremiumList.Add(ThePremium);
            }
            return CRMPremiumList;
        }

        public static int InsertPremium(CRMPremium theCrmPremium)
        {
            return CrmPremiumDataAccess.GetInstance.InsertPremium(theCrmPremium);
        }

        public static int UpdatePremium(CRMPremium theCrmPremium)
        {
            return CrmPremiumDataAccess.GetInstance.UpdatePremium(theCrmPremium);
        }

        public static int DeletePremium(CRMPremium theCrmPremium)
        {
            return CrmPremiumDataAccess.GetInstance.DeletePremium(theCrmPremium);
        }

        public static CRMPremium GetPremiumById(int recordId)
        {

            DataRow CRMPolicyRow = CrmPremiumDataAccess.GetInstance.GetPremiumById(recordId);

			CRMPremium TheCRMPremium = new CRMPremium
			{
				PremiumTableID = int.Parse(CRMPolicyRow["PremiumTableID"].ToString()),
				PolicyID = int.Parse(CRMPolicyRow["PolicyID"].ToString()),
				PremiumTableReferenceName = CRMPolicyRow["PremiumTableReferenceName"].ToString(),
				PremiumTableDescriptiveName = CRMPolicyRow["PremiumTableDescriptiveName"].ToString(),
				TenureInYears = double.Parse(CRMPolicyRow["TenureInYears"].ToString())
			};

            //TheCRMPremium.EffectiveDateFrom = CRMPolicyRow["EffectiveDateFrom"].ToString();


            return TheCRMPremium;
        }

        #endregion
    }
}
