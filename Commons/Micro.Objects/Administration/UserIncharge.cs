using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class UserIncharge
    {
        public int UserInchargeID
        {
            get;
            set;
        }
        public int ParentUserID
        {
            get;
            set;
        }
        public int InChargeUserID
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
        public string ReferenceLetterNumber
        {
            get;
            set;
        }
        public string ReferenceLetterDate
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
