using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
   public class BrokerageFeeStructure
    {
        public int BrokerageFeeStructureID
        {
            get;
            set;
        }
        public int ImplementedBy
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }

        public string OfficeName
        {
            get;
            set;
        }
           public int PolicyTypeID
        {
            get;
            set;
        }

          public string PolicyTypeDescription
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

          public string StoredProcedureName
        {
            get;
            set;
        }

          public string EffectiveDateFrom
        {
            get;
            set;
        }
          public bool IsSelected
          {
              get;
              set;
          }
    }
}
