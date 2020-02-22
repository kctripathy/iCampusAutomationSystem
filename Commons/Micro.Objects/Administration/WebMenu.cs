using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class WebMenu
    {
        public int WebMenuID
        {
            get;
            set;
        }
        public int FormOrMenuID
        {
            get;
            set;
        }
        public int WebRolePermissionID
        {
            get;
            set;
        }
        public string FormOrMenu
        {
            get;
            set;
        }
        public string MenuDisplayText
        {
            get;
            set;
        }

        public string MenuToolTip
        {
            get;
            set;
        }

        public string MenuValueText
        {
            get;
            set;
        }

        public string NavigationURL
        {
            get;
            set;
        }

        public int ParentWebMenuID
        {
            get;
            set;
        }

        public string ImageURL
        {
            get;
            set;
        }

        public int DisplayOrder
        {
            get;
            set;
        }

        public int ModuleID
        {
            get;
            set;
        }

        public int RoleID
        {
            get;
            set;
        }
        public string RoleDescription
        {
            get;
            set;
        }
        
        public int PermissionID
        {
            get;
            set;
        }
        public string PermissionDescription
        {
            get;
            set;
        }

        public string CompanyCode
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
        public int ModifiedBy
        {
            get;
            set;
        }
        public string CanRedirectAfterUserLogin
        {
            get;
            set;
        }
		
    }
}
