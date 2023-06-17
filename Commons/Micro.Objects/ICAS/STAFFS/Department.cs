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

        public string DepartmentContent1
        {
            get;
            set;
        }

        public string DepartmentContent2
        {
            get;
            set;
        }

        public string DepartmentContent3
        {
            get;
            set;
        }

        public int DepartmentHeadId
        {
            get;
            set;
        }

        public string DepartmentHeadName
        {
            get;
            set;
        }

        public string DepartmentImage
        {
            get
            {
                return string.Concat(this.DepartmentName.Replace(" ","_").Trim(), ".jpg").ToLower();
            }
        }

        public List<Staff> Staffs
        {
            get;
            set;
        }
    }
}
