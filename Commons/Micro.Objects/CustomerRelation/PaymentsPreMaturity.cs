using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class PaymentsPreMaturity
    {
        public int PreMaturityPaymentID
        {
            get;
            set;
        }
       public int PreMaturityApprovalID
        {
            get;
            set;
        }
       public string PreMaturityFormNumber
        {
            get;
            set;
        }
        public string PreMaturityDate
        {
            get;
            set;
        }
        public string PreMaturityPaymentDate
        {
            get;
            set;
        }
        public decimal PreMaturityPrincipalPaid
        {
            get;
            set;
        }
         public decimal PreMaturityInterestPaid
        {
            get;
            set;
        }
         public decimal PreMaturityBonusPaid
        {
            get;
            set;
        }
         public decimal PreMaturityTotalPaid
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
