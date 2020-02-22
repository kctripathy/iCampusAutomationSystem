using System;
using System.Collections.Generic;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class RebateIntegration
    {
        #region Declaraion
        #endregion

        #region Methods & Implementation
        public static Rebate DataRowToObject(DataRow dr)
        {
            Rebate TheRebate = new Rebate();
            TheRebate.RebateID = int.Parse(dr["RebateID"].ToString());
            TheRebate.PolicyTypeID = int.Parse(dr["PolicyTypeID"].ToString());
            TheRebate.PolicyName = dr["PolicyName"].ToString();
            TheRebate.PolicyTypeDescription = dr["PolicyTypeDescription"].ToString();
            TheRebate.InstallmentMode=dr["InstallmentMode"].ToString();
            TheRebate.RebatePer = decimal.Parse(dr["RebatePer"].ToString());
            TheRebate.RebateValue = decimal.Parse(dr["RebateValue"].ToString());
            TheRebate.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);

            return TheRebate;
        }

        public static List<Rebate> GetRebateList()
        {
            List<Rebate> RebateList = new List<Rebate>();
            DataTable RebateTable = RebateDataAccess.GetInstance.GetRebateList();

            foreach (DataRow dr in RebateTable.Rows)
            {
                Rebate TheRebate = DataRowToObject(dr);

                RebateList.Add(TheRebate);
            }

            return RebateList;
        }

        public static Rebate GetRebateByID(int RebateID)
        {
            DataRow TheRebateRow = RebateDataAccess.GetInstance.GetRebateByID(RebateID);

            Rebate TheRebate = DataRowToObject(TheRebateRow);

            return TheRebate;
        }

        public static int InsertRebate(Rebate theRebate)
        {
            return RebateDataAccess.GetInstance.InsertRebate(theRebate);
        }

        public static int UpdateRebate(Rebate theRebate)
        {
            return RebateDataAccess.GetInstance.UpdateRebate(theRebate);
        }

        public static int DeleteRebate(Rebate theRebate)
        {
            return RebateDataAccess.GetInstance.DeleteRebate(theRebate);
        }

		public static decimal GetRebateAmount(int policyTypeID, string installmentMode, decimal installmentAmount)
		{
			return RebateDataAccess.GetInstance.GetRebateAmount(policyTypeID, installmentMode, installmentAmount);
        }
        #endregion
    }
}
