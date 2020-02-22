using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class CRMPremium
    {
        public int PremiumTableID
        {
            get;
            set;
        }
        public string PremiumTableReferenceName
        {
            get;
            set;
        }
         public string PremiumTableDescriptiveName
        {
            get;
            set;
        }
         public double TenureInYears
        {
            get;
            set;
        }
         public int TenureInMonths
        {
            get;
            set;
        }
        public string EffectiveDateFrom
        {
            get;
            set;
        }

          public int PolicyID
        {
            get;
            set;
        }

          public int OfficeID
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
         public string DateAdded
        {
            get;
            set;
        }
         public int AddedBy
        {
            get;
            set;
        }
        public string DateModified
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
      