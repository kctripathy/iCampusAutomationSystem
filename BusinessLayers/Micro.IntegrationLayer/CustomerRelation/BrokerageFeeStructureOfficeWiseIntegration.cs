using System;
using System.Collections.Generic;
using Micro.Objects.CustomerRelation;
using Micro.DataAccessLayer.CustomerRelation;
using System.Data;
using Micro.Commons;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class BrokerageFeeStructureOfficeWiseIntegration
   {
       #region Declaration
       #endregion

       #region Methods & Implementation

       public static BrokerageFeeStructureOfficeWise DataRowToObject(DataRow dr)
       {
           BrokerageFeeStructureOfficeWise TheBrokerageFeeStructureOfficeWise = new BrokerageFeeStructureOfficeWise();

           TheBrokerageFeeStructureOfficeWise.BrokerageFeeStructureID = int.Parse(dr["BrokerageFeeStructureID"].ToString());
           TheBrokerageFeeStructureOfficeWise.OfficeID = int.Parse(dr["OfficeID"].ToString());
           TheBrokerageFeeStructureOfficeWise.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);
           TheBrokerageFeeStructureOfficeWise.PolicyName = dr["PolicyName"].ToString();
           TheBrokerageFeeStructureOfficeWise.PolicyFromOrganization = dr["PolicyFromOrganization"].ToString();
           TheBrokerageFeeStructureOfficeWise.PolicyTypeDescription = dr["PolicyTypeDescription"].ToString();
           TheBrokerageFeeStructureOfficeWise.BrokerageType = dr["BrokerageType"].ToString();
           TheBrokerageFeeStructureOfficeWise.DatabaseTableName = dr["DatabaseTableName"].ToString();
           TheBrokerageFeeStructureOfficeWise.OfficeName = dr["OfficeName"].ToString();
           TheBrokerageFeeStructureOfficeWise.PolicyID = int.Parse(dr["PolicyID"].ToString());

           return TheBrokerageFeeStructureOfficeWise;
       } 

       public static List<BrokerageFeeStructureOfficeWise> GetBrokerageFeeStructureOfficeWise(int officeId)
       {
           List<BrokerageFeeStructureOfficeWise> BrokerageFeeStructureOfficeWiseList = new List<BrokerageFeeStructureOfficeWise>();

           DataTable BrokerageFeeStructureOfficeWiseTable = BrokerageFeeStructureOfficeWiseDataAccess.GetInstance.GetBrokerageFeeStructureOfficeWise(officeId);

           foreach (DataRow dr in BrokerageFeeStructureOfficeWiseTable.Rows)
           {
               BrokerageFeeStructureOfficeWise TheBrokerageFeeStructureOfficeWise = DataRowToObject(dr);

               BrokerageFeeStructureOfficeWiseList.Add(TheBrokerageFeeStructureOfficeWise);
           }

           return BrokerageFeeStructureOfficeWiseList;
       }

       public static List<BrokerageFeeStructureOfficeWise> GetBrokerageFeeStructureOfficeWiseList()
       {
           List<BrokerageFeeStructureOfficeWise> BrokerageFeeStructureOfficeWiseList = new List<BrokerageFeeStructureOfficeWise>();

           DataTable BrokerageFeeStructureOfficeWiseTable = BrokerageFeeStructureOfficeWiseDataAccess.GetInstance.GetBrokerageFeeStructureOfficeWiseList();

           foreach (DataRow dr in BrokerageFeeStructureOfficeWiseTable.Rows)
           {
               BrokerageFeeStructureOfficeWise TheBrokerageFeeStructureOfficeWise = DataRowToObject(dr);

               BrokerageFeeStructureOfficeWiseList.Add(TheBrokerageFeeStructureOfficeWise);
           }

           return BrokerageFeeStructureOfficeWiseList;
       }

       public static List<BrokerageFeeStructureOfficeWise> GetBrokerageFeeStructureSelectByOfficeID(bool ShowInOfficewise = false)
       {
           List<BrokerageFeeStructureOfficeWise> BrokerageList = new List<BrokerageFeeStructureOfficeWise>();

           DataTable BrokerageFeeStructureOfficeWiseTable = BrokerageFeeStructureOfficeWiseDataAccess.GetInstance.GetBrokerageFeeStructureSelectByOfficeID(ShowInOfficewise);

           foreach (DataRow dr in BrokerageFeeStructureOfficeWiseTable.Rows)
           {
               BrokerageFeeStructureOfficeWise TheBrokerage = DataRowToObject(dr);

               BrokerageList.Add(TheBrokerage);
           }

           return BrokerageList;
       }

       public static int UpdateBrokerageFeeStructureOfficeWise(List<BrokerageFeeStructureOfficeWise> theBrokerageFeeStructureOfficeWiseList)
       {
           return BrokerageFeeStructureOfficeWiseDataAccess.GetInstance.UpdateBrokerageFeeStructureOfficeWise(theBrokerageFeeStructureOfficeWiseList);
       }

       public static int InsertBrokerageFeeStructureOfficeWise(string BrokerageFeeStructureIDs, string EffectiveDateFrom)
       {
           return BrokerageFeeStructureOfficeWiseDataAccess.GetInstance.InsertBrokerageFeeStructureOfficeWise(BrokerageFeeStructureIDs, EffectiveDateFrom);
       }
       public static int DeleteBrokerageFeeStructureOfficeWise(string BrokerageFeeStructureIDs)
       {
           return BrokerageFeeStructureOfficeWiseDataAccess.GetInstance.DeleteBrokerageFeeStructureOfficeWise(BrokerageFeeStructureIDs);
       }

       #endregion
   }
}
