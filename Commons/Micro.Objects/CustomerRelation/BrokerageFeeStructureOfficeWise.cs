using System;

namespace Micro.Objects.CustomerRelation
{
     [Serializable]
   public class BrokerageFeeStructureOfficeWise
    {
         public int BrokerageFeeStructureOfficewiseID
         {
             get;
             set;
         }

         public int BrokerageFeeStructureID
         {
             get;
             set;
         }

         public int OfficeID
         {
             get;
             set;
         }

         public string EffectiveDateFrom
         {
             get;
             set;
         }
         public string EffectiveDateTo
         {
             get;
             set;
         }

         public bool IsActive
         {
             get;
             set;
         }

         public bool IsDeleted
         {
             get;
             set;
         }
         public string PolicyTypeDescription
         {
             get;
             set;
         }
         public string PolicyName
         {
             get;
             set;
         }
         public string PolicyFromOrganization
         {
             get;
             set;
         }
         public string OfficeName
         {
             get;
             set;
         }
         public string OfficeCode
         {
             get;
             set;
         }
         public string BrokerageType
         {
             get;
             set;
         }
          public string DatabaseTableName
         {
             get;
             set;
         }
          public int PolicyID
          {
              get;
              set;
          }
    }
}
