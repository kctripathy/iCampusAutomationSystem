using System;

namespace Micro.Objects.CustomerRelation
{
     [Serializable]
    public class ChangeFieldChain
    {
         public int FieldForceChainID
         {
             get;
             set;
         }
          public int FieldForceID
         {
             get;
             set;
         }
          public string  FieldForceCode
         {
             get;
             set;
         }
           public int FieldForceRankID
         {
             get;
             set;
         }
           public int ReportingToRankID
         {
             get;
             set;
         }
           public string  ChainCode
         {
             get;
             set;
         }
            public int OfficeID
         {
             get;
             set;
         }
            public string  EffectiveDateFrom
         {
             get;
             set;
         }
             public string  EffectiveDateTo
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
             public string  DateAdded
         {
             get;
             set;
         }
          public int AddedBy
         {
             get;
             set;
         }
              public string  DateModified
         {
             get;
             set;
         }
           public int ModifiedBy
         {
             get;
             set;
         }

    }
} 
