using System;

namespace Micro.Objects.CustomerRelation
{[Serializable]
   public  class RebatesOfficeWise
    {
        public int RebateOfficewiseID
        {
            get;
            set;
        }
        public int RebateID
        {
            get;
            set;
        }
        public int OfficeID
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
        public string PolicyName
        {
            get;
            set;
        }
        public string InstallmentMode
        {
            get;
            set;
        }
        public string RebatePer
        {
            get;
            set;
        }
        public string RebateValue
        {
            get;
            set;
        }
        public string OfficeName
        {
            get;
            set;
        }
        public int PolicyID
        {
            get;
            set;
        }
        public string PolicyFromOrganization
        {
            get;
            set;
        }
        public string OfficeCode
        {
            get;
            set;
        }


    }
}
