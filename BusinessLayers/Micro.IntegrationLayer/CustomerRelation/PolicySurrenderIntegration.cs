using System;
using System.Collections.Generic;
using System.Data;
using Micro.Objects.CustomerRelation;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class PolicySurrenderIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static PolicySurrender DataRowToObject(DataRow dr)
        {
            PolicySurrender ThePolicySurrender = new PolicySurrender();

            ThePolicySurrender.SurrenderID = int.Parse(dr["SurrenderID"].ToString());
            ThePolicySurrender.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
            ThePolicySurrender.CustomerAccountCode = dr["CustomerAccountCode"].ToString();
            ThePolicySurrender.CustomerName = dr["CustomerName"].ToString();
            ThePolicySurrender.SurrenderFormNumber = dr["SurrenderFormNumber"].ToString();
            ThePolicySurrender.SurrenderDate = DateTime.Parse(dr["SurrenderDate"].ToString()).ToString(MicroConstants.DateFormat);
            ThePolicySurrender.SurrenderPrincipalPayable = decimal.Parse(dr["SurrenderPrincipalPayable"].ToString());
            ThePolicySurrender.SurrenderPrincipalPaid = decimal.Parse(dr["SurrenderPrincipalPaid"].ToString());
            ThePolicySurrender.SurrenderInterestPayable = decimal.Parse(dr["SurrenderInterestPayable"].ToString());
            ThePolicySurrender.SurrenderInterestPaid = decimal.Parse(dr["SurrenderInterestPaid"].ToString());
            ThePolicySurrender.SurrenderBonusPayable = decimal.Parse(dr["SurrenderBonusPayable"].ToString());
            ThePolicySurrender.SurrenderBonusPaid = decimal.Parse(dr["SurrenderBonusPaid"].ToString());
            ThePolicySurrender.SurrenderPrincipalDeductions = decimal.Parse(dr["SurrenderPrincipalDeductions"].ToString());
            ThePolicySurrender.SurrenderPrincipalDeductionsRemarks = dr["SurrenderPrincipalDeductionsRemarks"].ToString();
            ThePolicySurrender.SurrenderTotalPayable = decimal.Parse(dr["SurrenderTotalPayable"].ToString());
            ThePolicySurrender.SurrenderTotalPaid = decimal.Parse(dr["SurrenderTotalPaid"].ToString());

            return ThePolicySurrender;
        }

        public static List<PolicySurrender> GetPolicySurrenderList(bool allOffices = false, bool showDeleted = false)
        {
            List<PolicySurrender> PolicySurrenderList = new List<PolicySurrender>();
            DataTable SurrenderTable = PolicySurrenderDataAccess.GetInstance.GetPolicySurrenderList(allOffices, showDeleted);

            foreach (DataRow dr in SurrenderTable.Rows)
            {
                PolicySurrender ThePolicySurrender = DataRowToObject(dr);

                PolicySurrenderList.Add(ThePolicySurrender);
            }

            return PolicySurrenderList;
        }

        public static PolicySurrender GetSurrenderChargesbyCustomerAccountID(int customerAccountID)
        {
            DataRow ThePolicySurrenderRow = PolicySurrenderDataAccess.GetInstance.GetSurrenderChargesbyCustomerAccountID(customerAccountID);

            PolicySurrender ThePolicySurrender = new PolicySurrender();

            ThePolicySurrender.SurrenderInterestPaid = decimal.Parse(ThePolicySurrenderRow["SurrenderInterestPaid"].ToString());
            ThePolicySurrender.SurrenderPrincipalDeductions = decimal.Parse(ThePolicySurrenderRow["SurrenderPrincipalDeductions"].ToString());

            return ThePolicySurrender;
        }

        public static int InsertPolicySurrender(PolicySurrender thePolicySurrender)
        {
            return PolicySurrenderDataAccess.GetInstance.InsertPolicySurrender(thePolicySurrender);
        }
        #endregion
    }
}
