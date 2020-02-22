using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class ChangeIntroducer
    {
        public int ChangeIntroducerID
        {
            get;
            set;
        }
        public int CustomerAccountID
        {
            get;
            set;
        }
        public int NewFieldForceID
        {
            get;
            set;
        }
        public int FieldForceID
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
        public string TodaysDate
        {
            get;
            set;
        }
    }
}
