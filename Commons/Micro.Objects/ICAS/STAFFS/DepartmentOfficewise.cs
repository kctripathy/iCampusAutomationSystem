using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro.Objects.Administration;


namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]

   public partial class DepartmentOfficewise
    {
        public Department DEPARTMENT = new Department();
        public Office Office = new Office();

        public int DepartmentOfficewiseID
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get { return DEPARTMENT.DepartmentID; }
            set { DEPARTMENT.DepartmentID = value; }
        }

        public int OfficeID
        {
            get { return Office.OfficeID; }
            set { Office.OfficeID = value; }
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
