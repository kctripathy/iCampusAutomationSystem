using System;

namespace Micro.Objects.HumanResource
{
    [Serializable]
    public class LeaveApplication
    {
       public Employee ApprovedBy = new Employee();
        public Employee ApprovedByName = new Employee();

        public int LeaveApplicationID
        {
            get;
            set;
        }

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

        public DateTime DateApplied
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

        public string ApplicationReason
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

		public int NoOfDays
		{
			get
			{
				return (DateTo - DateFrom).Days;
			}
		}
        //public int ApprovedByEmployeeID
        //{
        //    get;
        //    set;
        //}
        public int ApprovedByUserID
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
