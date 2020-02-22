using System;
using Micro.Objects.Administration; 

namespace Micro.Objects.HumanResource
{
    [Serializable]
    public partial class EmployeeServiceDetails
    {
        public Employee Employee=new Employee();
        public Office PostingOffice=new Office();
        public Department Deparment=new Department();
        public Designation Designation=new Designation();
        public Employee ReportingToEmployee=new Employee();

        public int EmployeeServiceDetailsID
        {
            get;
            set;
        }

        public DateTime PostingDate
        {
            get;
            set;
        }

        public string ServiceType
        {
            get;
            set;
        }

        public string ServiceStatus
        {
            get;
            set;
        }
        public DateTime ServiceStatusChangeRequestDate
        {
            get;
            set;
        }
        public DateTime ServiceStatusLastWorkingDate
        {
            get;
            set;
        }
        public string ReferenceLetterNumber
        {
            get;
            set;
        }

        public DateTime ReportingToEffectiveDateFrom
        {
            get;
            set;
        }

        public string Remarks
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
