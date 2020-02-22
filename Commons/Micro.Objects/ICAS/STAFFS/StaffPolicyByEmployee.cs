using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]
    public class StaffPolicyByEmployee
    {
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

        public string Salutation
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }        
        public string FatherName
        {
            get;
            set;
        }

        public string SpouseName
        {
            get;
            set;
        }

        public string DateOfBirth
        {
            get;
            set;
        }

        public string Mobile
        {
            get;
            set;
        }

        public string EMailID
        {
            get;
            set;
        }

        public int PolicyApplicationID
        {
            get;
            set;
        }

        public int PolicyID
        {
            get;
            set;
        }

        public decimal PolicyAmount
        {
            get;
            set;
        }

        public string PolicyDate
        {
            get;
            set;
        }

        public string PolicyStatus
        {
            get;
            set;
        }
        public string Comment
        {
            get;
            set;
        }

        public string EMI
        {
            get;
            set;
        }

        public int SanctionedByID
        {
            get;
            set;
        }
    }
}
