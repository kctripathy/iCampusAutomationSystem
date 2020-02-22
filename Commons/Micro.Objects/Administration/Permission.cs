using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class Permission
    {
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

        public char ForFormOrMenu
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
}
