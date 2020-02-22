using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class PreMaturityApplication
    {
        public int PreMaturityApplicationID
        {
            get;
            set;
        }
        public string PreMaturityApplicationDate
        {
            get;
            set;
        }
        public int CustomerAccountID
        {
            get;
            set;
        }
        public byte[] DeathCertificate
        {
            get;
            set;
        }
        public string PreMaturityRemark
        {
            get;
            set;
        }
        public string PreMaturityApplicationLetterDate
        {
            get;
            set;
        }
        public string PreMaturityApplicationLetterReference
        {
            get;
            set;
        }
        public string PreMaturityApprovalStatus
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
        public string CustomerName
        {
            get;
            set;
        }
        public string CustomerAccountCode
        {
            get;
            set;

        }
        public int CustomerID
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
    }
}
