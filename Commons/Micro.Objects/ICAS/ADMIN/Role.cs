using System;

namespace Micro.Objects.ICAS.ADMIN
{
    [Serializable]
    public class Role
    {
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
