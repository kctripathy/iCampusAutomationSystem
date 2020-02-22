using System;
using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class BranchAbstractIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementaion
        public static BranchAbstract DataRowToObject(DataRow dr)
        {
            BranchAbstract TheBranchAbstract = new BranchAbstract();

            TheBranchAbstract.BusinessNew = decimal.Parse( dr["BusinessNew"].ToString());
            TheBranchAbstract.BusinessRenew = decimal.Parse( dr["BusinessRenew"].ToString());
            TheBranchAbstract.BusinessOneTime = decimal.Parse( dr["BusinessOneTime"].ToString());
            TheBranchAbstract.PaymentLoan = decimal.Parse(dr["PaymentLoan"].ToString());
            TheBranchAbstract.RecoveryLoan = decimal.Parse(dr["RecoveryLoan"].ToString());
            TheBranchAbstract.PaymentMaturity = decimal.Parse(dr["PaymentMaturity"].ToString());
            TheBranchAbstract.DateOfTransaction = DateTime.Parse(dr["DateOfTransaction"].ToString()).ToString(MicroConstants.DateFormat);
            TheBranchAbstract.OfficeTypeAbbreviation = dr["OfficeTypeAbbreviation"].ToString();
            TheBranchAbstract.OfficeTypeDescription = dr["OfficeTypeDescription"].ToString();
            TheBranchAbstract.OfficeTypeID = int.Parse(dr["OfficeTypeID"].ToString());
            TheBranchAbstract.OfficeName = dr["OfficeName"].ToString();
            TheBranchAbstract.OfficeCode = dr["OfficeCode"].ToString();
            TheBranchAbstract.OfficeID = int.Parse(dr["OfficeID"].ToString());

            return TheBranchAbstract;
        }

        public static List<BranchAbstract> BranchAbstractList(string DateOfTransaction)
        {
            List<BranchAbstract> BranchAbstractList = new List<BranchAbstract>();

            DataTable GetBranchAbstract = BranchAbstractDataAccess.GetInstance.BranchAbstractList(DateOfTransaction);

            foreach (DataRow dr in GetBranchAbstract.Rows)
            {
                BranchAbstract TheBranchAbstract = DataRowToObject(dr);

                BranchAbstractList.Add(TheBranchAbstract);
            }

            return BranchAbstractList;
        }
        #endregion
    }
}
