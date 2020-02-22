using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class PreMaturityApproval
    {
        public int PreMaturityApprovalID
        {
            get;
            set;
        }
        public int PreMaturityApplicationID
        {
            get;
            set;
        }
        public int CustomerAccountID
        {
            get;
            set;
        }
        public string CustomerAccountCode
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }
        public string PreMaturityApprovalDate
        {
            get;
            set;
        }
        public decimal PreMaturityPrincipalPayable
        {
            get;
            set;
        }
        public decimal PreMaturityPrincipalApproved
        {
            get;
            set;
        }
        public decimal PreMaturityInterestPayable
        {
            get;
            set;
        }
        public decimal PreMaturityInterestApproved
        {
            get;
            set;
        }

        public decimal PreMaturityBonusPayable
        {
            get;
            set;
        }
        public decimal PreMaturityBonusApproved
        {
            get;
            set;
        }
        public decimal PreMaturityTotalPayable
        {
            get;
            set;
        }
        public decimal PreMaturityTotalPaid
        {
            get;
            set;
        }
        public string PreMaturityApprovalRemark
        {
            get;
            set;
        }
        public int PreMaturityApprovedBy
        {
            get;
            set;
        }
        public string PreMaturityApprovalLetterDate
        {
            get;
            set;
        }
        public string PreMaturityApprovalLetterReference
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

