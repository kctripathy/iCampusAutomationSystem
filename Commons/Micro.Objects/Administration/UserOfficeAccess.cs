using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class UserOfficeAccess
    {
        public int UserOfficewiseID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public bool CanAccessAllOffices
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
        public string UserName
        {
            get;
            set;
        }
        public string UserType
        {
            get;
            set;
        }
        public int UserReferenceID
        {
            get;
            set;
        }
        public string UserReferenceName
        {
            get;
            set;
        }
        public string OfficeName
        {
            get;
            set;
        }
        public string CompanyName
        {
            get;
            set;
        }
        public string CompanyAliasName
        {
            get;
            set;
        }

    }
}
