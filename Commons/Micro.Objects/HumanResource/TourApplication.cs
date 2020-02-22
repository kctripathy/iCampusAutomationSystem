using System;

namespace Micro.Objects.HumanResource
{
     [Serializable]
    public class TourApplication
    {
        public Employee ApprovedBy = new Employee();

        public int TourApplicationID
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public string EmployeeCode
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }

        public string DesignationDescription
        {
            get;
            set;
        }

        public string DepartmentDescription
        {
            get;
            set;
        }

        public DateTime DateFrom
        {
            get;
            set;
        }

        public DateTime DateTo
        {
            get;
            set;
        }

        public string TourPurpose
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public int ApprovedByEmployeeID
        {
            get;
            set;
        }

        public string ApprovedByEmployeeName
        {
            get;
            set;
        }

        public DateTime ApproveDate
        {
            get;
            set;
        }

        public string ApprovalOrRejectionReason
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

        public DateTime DateAdded
        {
            get;
            set;
        }

        public DateTime DateModified
        {
            get;
            set;
        }
    }
}
