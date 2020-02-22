using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
   public partial class BrokerageFeeStructureIntegration
   {
       #region Declaration
       #endregion

       #region Methods & Implementations

       public static BrokerageFeeStructure DataRowToObject(DataRow dr)
       {
           BrokerageFeeStructure TheBrokerageFeeStructure = new BrokerageFeeStructure();

           TheBrokerageFeeStructure.BrokerageFeeStructureID = int.Parse(dr["BrokerageFeeStructureID"].ToString());
           TheBrokerageFeeStructure.PolicyTypeID = int.Parse(dr["PolicyTypeID"].ToString());
           TheBrokerageFeeStructure.PolicyTypeDescription = dr["PolicyTypeDescription"].ToString();
           TheBrokerageFeeStructure.BrokerageType = dr["BrokerageType"].ToString();
           TheBrokerageFeeStructure.DatabaseTableName = dr["DatabaseTableName"].ToString();
           TheBrokerageFeeStructure.StoredProcedureName = dr["StoredProcedureName"].ToString();
           TheBrokerageFeeStructure.EffectiveDateFrom = DateTime.Parse(dr["EffectiveDateFrom"].ToString()).ToString(MicroConstants.DateFormat);

           return TheBrokerageFeeStructure;
       }

       public static List<BrokerageFeeStructure> GetBrokerageFeeStructureList(bool allOffices = false, bool showDeleted = false)
       {
           List<BrokerageFeeStructure> BrokerageFeeStructureList = new List<BrokerageFeeStructure>();

           DataTable BrokerageFeeStructureTable = BrokerageFeeStructureDataAccess.GetInstance.GetBrokerageFeeStructureList(allOffices,showDeleted);

           foreach (DataRow dr in BrokerageFeeStructureTable.Rows)
           {
               BrokerageFeeStructure TheBrokerageFeeStructure = DataRowToObject(dr);

               BrokerageFeeStructureList.Add(TheBrokerageFeeStructure);
           }
           return BrokerageFeeStructureList;
       }

       public static BrokerageFeeStructure GetBrokerageFeeStructuresById(int BrokerageFeeStructureID)
       {
           DataRow BrokerageFeeStructureRow = BrokerageFeeStructureDataAccess.GetInstance.GetBrokerageFeeStructuresById(BrokerageFeeStructureID);

           BrokerageFeeStructure TheBrokerageFeeStructure = DataRowToObject(BrokerageFeeStructureRow);

           return TheBrokerageFeeStructure;
       }

       public static int InsertBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructureList)
       {
           return BrokerageFeeStructureDataAccess.GetInstance.InsertBrokerageFeeStructure(theBrokerageFeeStructureList);
       }

       public static int UpdateBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructureList)
       {
           return BrokerageFeeStructureDataAccess.GetInstance.UpdateBrokerageFeeStructure(theBrokerageFeeStructureList);
       }

       public static int DeleteBrokerageFeeStructure(BrokerageFeeStructure theBrokerageFeeStructure)
       {
           return BrokerageFeeStructureDataAccess.GetInstance.DeletBrokerageFeeStructure(theBrokerageFeeStructure);
       }
       #endregion
   }
}

