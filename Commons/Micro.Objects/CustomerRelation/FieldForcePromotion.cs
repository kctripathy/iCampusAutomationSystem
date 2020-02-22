using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class FieldForcePromotion
    {
        public int FieldForcePromotionID
        {
            get;
            set;
        }
        public int FieldForceID
        {
            get;
            set;
        }
        public string BusinessFromDate
        {
            get;
            set;
        }
        public string BusinessToDate
        {
            get;
            set;
        }
        public decimal BusinessNew
        {
            get;
            set;
        }
        public decimal BusinessRenew
        {
            get;
            set;
        }
        public decimal BusinessOneTime
        {
            get;
            set;
        }
        public int ExistingRankID
        {
            get;
            set;
        }
        public string ExistingRankDescription
        {
            get;
            set;
        }
        public int PromotedToRankID
        {
            get;
            set;
        }
        public string PromotedToRankDescription
        {
            get;
            set;
        }
        public string PromotionStatus
        {
            get;
            set;
        }
        public bool HasAccepted
        {
            get;
            set;
        }
        public string StatusChangeDate
        {
            get;
            set;
        }
        public int StatusChangedByEmployeeID
        {
            get;
            set;
        }
        public string Remarks
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
        public int OfficeID
        {
            get;
            set;
        }

        public int RejectedBy
        {
            get;
            set;
        }
        public string ReasonOfRejection
        {
            get;
            set;
        }
        public string FieldForceName
        {
            get;
            set;
        }
        public string FieldForceCode
        {
            get;
            set;
        }

    }
}
