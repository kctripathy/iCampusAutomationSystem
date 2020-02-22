using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class PolicyTypesOfficeWise
    {
        public int PolicyTypeOfficewiseID
        {
            get;
            set;
        }
        public int PolicyTypeID
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
        public string PolicyFromOrganization
        {
            get;
            set;
        }
        public string OfficeName
        {
            get;
            set;
        }
        public string OfficeCode
        {
            get;
            set;
        }
        //public bool IsActive
        //{
        //    get;
        //    set;
        //}
        //public bool IsDeleted
        //{
        //    get;
        //    set;
        //}
 
    }
}
