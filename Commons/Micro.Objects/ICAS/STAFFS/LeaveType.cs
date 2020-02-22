using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]
    public class LeaveType
    {
        public int LeaveTypeID
        {
            get;
            set;
        }
        public string LeaveTypeDescription
        {
            get;
            set;
        }

        public string LeaveTypeAlias
        {
            get;
            set;
        }

        public int AddedBy
        {
            get;
            set;
        }

        public int ModifiedBy
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
