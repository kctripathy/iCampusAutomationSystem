using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]

    public class Department
    {
        public int DepartmentID
        {
            get;
            set;
        }

        public string DepartmentName
        {
            get;
            set;
        }

        public string DepartmentDescription
        {
            get;
            set;
        }

        public int ParentDepartmentId
        {
            get;
            set;
        }

        public string ParentDepartmentDescription
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
