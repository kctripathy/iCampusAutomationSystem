using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class PreMaturityApprovalIntegration
   {

       #region Methods & Implementation
       public static PreMaturityApproval DataRowToObject(DataRow dr)
       {
           PreMaturityApproval ThePreMaturityApprovals = new PreMaturityApproval();

           ThePreMaturityApprovals.PreMaturityApprovalID = int.Parse(dr["PreMaturityApprovalID"].ToString());
           ThePreMaturityApprovals.PreMaturityApplicationID = int.Parse(dr["PreMaturityApplicationID"].ToString());
           ThePreMaturityApprovals.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
           ThePreMaturityApprovals.CustomerAccountCode = dr["CustomerAccountCode"].ToString();
           ThePreMaturityApprovals.CustomerName = dr["CustomerName"].ToString();
           ThePreMaturityApprovals.PreMaturityApprovalDate = DateTime.Parse(dr["PreMaturityApprovalDate"].ToString()).ToString(MicroConstants.DateFormat);
           ThePreMaturityApprovals.PreMaturityPrincipalPayable = decimal.Parse(dr["PreMaturityPrincipalPayable"].ToString());
           ThePreMaturityApprovals.PreMaturityPrincipalApproved = decimal.Parse(dr["PreMaturityPrincipalApproved"].ToString());
           ThePreMaturityApprovals.PreMaturityInterestPayable = decimal.Parse(dr["PreMaturityInterestPayable"].ToString());
           ThePreMaturityApprovals.PreMaturityInterestApproved = decimal.Parse(dr["PreMaturityInterestApproved"].ToString());
           ThePreMaturityApprovals.PreMaturityBonusPayable = decimal.Parse(dr["PreMaturityBonusPayable"].ToString());
           ThePreMaturityApprovals.PreMaturityBonusApproved = decimal.Parse(dr["PreMaturityBonusApproved"].ToString());
           ThePreMaturityApprovals.PreMaturityTotalPayable = decimal.Parse(dr["PreMaturityTotalPayable"].ToString());
           ThePreMaturityApprovals.PreMaturityTotalPaid = decimal.Parse(dr["PreMaturityTotalPaid"].ToString());
           ThePreMaturityApprovals.PreMaturityApprovalRemark = dr["PreMaturityApprovalRemark"].ToString();
           ThePreMaturityApprovals.PreMaturityApprovedBy = int.Parse(dr["PreMaturityApprovedBy"].ToString());
           ThePreMaturityApprovals.PreMaturityApprovalLetterDate = DateTime.Parse(dr["PreMaturityApprovalLetterDate"].ToString()).ToString(MicroConstants.DateFormat);
           ThePreMaturityApprovals.PreMaturityApprovalLetterReference = dr["PreMaturityApprovalLetterReference"].ToString();

           return ThePreMaturityApprovals;
       }

       public static List<PreMaturityApproval> GetPrematurityApprovalUnpaidList(bool allOffices = false)
       {
           List<PreMaturityApproval> ApprovalUnpaidList = new List<PreMaturityApproval>();

           DataTable GetApprovalUnpaidTable = PreMaturityApprovalDataAccess.GetInstance.GetPrematurityApprovalUnpaidList(allOffices);

           foreach (DataRow dr in GetApprovalUnpaidTable.Rows)
           {
               PreMaturityApproval TheApprovalUnpaid = DataRowToObject(dr);

               ApprovalUnpaidList.Add(TheApprovalUnpaid);

           }
           return ApprovalUnpaidList;
       }

       public static PreMaturityApproval GetPrematurityApprovalDetailsById(int PreMaturityApprovalID)
       {
           DataRow PreMaturityApprovalsRow = PreMaturityApprovalDataAccess.GetInstance.GetPrematurityApprovalDetailsById(PreMaturityApprovalID);

           PreMaturityApproval ThePreMaturityApprovals = DataRowToObject(PreMaturityApprovalsRow);

           return ThePreMaturityApprovals;
       }

       public static int InsertPreMaturityApproval(PreMaturityApproval thePreMaturityApprovals)
       {
           return PreMaturityApprovalDataAccess.GetInstance.InsertPreMaturityApproval(thePreMaturityApprovals);
       }

       public static int RejectPreMaturityApplication(PreMaturityApplication thePreMaturityApplication)
       {
           return PreMaturityApprovalDataAccess.GetInstance.RejectPreMaturityApplication(thePreMaturityApplication);
       }
       #endregion
   }
}
