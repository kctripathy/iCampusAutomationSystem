using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]
   
    public class StaffPayRoll
    {
        public int LeaveTypeID
        {
            get;
            set;
        }
        public int BillNo
        {
            get;
            set;
        }
        public DateTime BillDate
        {
            get;
            set;
        }
        public int TvNo
        {
            get;
            set;
        }
        public string Month
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public string Year
        {
            get;
            set;
        }        
         public int EmployeeID
        {
            get;
            set;
        } public decimal GrossPay
        {
            get;
            set;
        } public int TotalWorkingDays
        {
            get;
            set;
        } public int TotalPresentWorkingDays
        {
            get;
            set;
        } public decimal BankLoanEMI
        {
            get;
            set;
        } public decimal FixedDeduction
        {
            get;
            set;
        } public decimal OtherDeduction
        {
            get;
            set;
        } public int PresentDay
        {
            get;
            set;
        } public decimal NetPayable
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
