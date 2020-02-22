using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class RolePermission
    {
        public int RolePermissionID
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

		public int RolePosition
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

		public string BriefDescription
		{
			get;
			set;
		}

        public int FormOrMenuID
        {
            get;
            set;
        }

		public string FormOrMenuDescription
		{
			get;
			set;
		}

		public string NavigationURL
		{
			get;
			set;
		}

        public char FormOrMenu
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
    }

    [Serializable]
    public class RolePermissionUpdate
    {
        public int RoleID
        {
            get;
            set;
        }

        public int FormOrMenuID
        {
            get;
            set;
        }

        public char FormOrMenu
        {
            get;
            set;
        }

        public int PermissionID
        {
            get;
            set;
        }

        public bool CheckState
        {
            get;
            set;
        }
    }
}
