using System;

namespace Micro.Objects.HumanResource
{
    [Serializable]
     public class OfficeTiming
    {
        public string OfficeId
        {
            get;
            set;
        }

        public DateTime InTime
        {
            get;
            set;
        }

        public DateTime OutTime
        {
            get;
            set;
        }

        public bool IsForAll
        {
            get;
            set;
        }

        public bool IsForSelf
        {
            get;
            set;
        }
        public DateTime EffectiveDate
        {
            get;
            set;
        }

        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
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



    }
}
