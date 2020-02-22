using System;
using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class RebatesOfficeWiseIntegration
   {
       #region Methods & Implementation

       public static RebatesOfficeWise RebateDataRowToObject(DataRow dr)
       {
           RebatesOfficeWise TheRebate = new RebatesOfficeWise();

           //TheRebate.RebateOfficewiseID = int.Parse(dr["RebateOfficewiseID"].ToString());
           TheRebate.RebateID = int.Parse(dr["RebateID"].ToString());
           TheRebate.PolicyTypeDescription=dr["PolicyTypeDescription"].ToString();
           TheRebate.PolicyName = dr["PolicyName"].ToString();
           TheRebate.RebatePer = dr["RebatePer"].ToString();
           TheRebate.RebateValue = dr["RebateValue"].ToString();
           TheRebate.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
           TheRebate.OfficeID = int.Parse(dr["OfficeID"].ToString());
           TheRebate.OfficeName = dr["OfficeName"].ToString();
           //TheRebate.PolicyID = int.Parse(dr["PolicyID"].ToString());
           //TheRebate.PolicyFromOrganization = dr["PolicyFromOrganization"].ToString();
           //TheRebate.OfficeCode = dr["OfficeCode"].ToString();
           //TheRebate.EffectiveDateTo = DateTime.Parse(dr["EffectiveDateTo"].ToString()).ToString(MicroConstants.DateFormat);
           return TheRebate;
       }

       public static List<RebatesOfficeWise> GetRebateOfficeWiseList(bool allOffices = false, bool showDeleted = false)
       {
           List<RebatesOfficeWise> CRMPolicyList = new List<RebatesOfficeWise>();

           DataTable RebatesOfficeWiseTableType = RebatesOfficeWiseDataAccess.GetInstance.GetRebateOfficeWiseList(allOffices, showDeleted);

           foreach (DataRow dr in RebatesOfficeWiseTableType.Rows)
           {
               RebatesOfficeWise TheRebatesOfficeWise = RebateDataRowToObject(dr);

               CRMPolicyList.Add(TheRebatesOfficeWise);
           }

           return CRMPolicyList;
       }

       public static List<RebatesOfficeWise> GetRebatesSelectByOfficeID(bool ShowInOfficewise = false)
       {
           List<RebatesOfficeWise> RebatesOfficeWiseList = new List<RebatesOfficeWise>();

           DataTable RebatesOfficeWiseTableType = RebatesOfficeWiseDataAccess.GetInstance.GetRebatesSelectByOfficeID(ShowInOfficewise);

           foreach (DataRow dr in RebatesOfficeWiseTableType.Rows)
           {
               RebatesOfficeWise TheRebatesOfficeWise = RebateDataRowToObject(dr);

               RebatesOfficeWiseList.Add(TheRebatesOfficeWise);
           }

           return RebatesOfficeWiseList;
       }

       public static int InsertOfficeWiseRebates(string RebateIDs, string EffectiveDateFrom)
       {
           return RebatesOfficeWiseDataAccess.GetInstance.InsertOfficeWiseRebates(RebateIDs, EffectiveDateFrom);
       }
       public static int DeleteOfficeWiseRebates(string RebateIDs)
       {
           return RebatesOfficeWiseDataAccess.GetInstance.DeleteOfficeWiseRebates(RebateIDs);
       }
       #endregion
   }
}
