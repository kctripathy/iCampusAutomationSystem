using System;

using Micro.Objects.Administration;

namespace Micro.Objects.HumanResource
{
    [Serializable]

    public class ShiftSchedule
    {
        public ShiftTiming ShiftTiming = new ShiftTiming();
        //public Department Department = new Department();
        public Office Office = new Office();
        //public Employee Employee = new Employee();

        public int ShiftScheduleID
        {
            get;
            set;
        }

        public int ShiftScheduleForWeekDay
        {
            get;
            set;
        }

        public string ShiftScheduleForWeekDayName
        {
            get;
            set;
        }

        public DateTime ShiftScheduleForDate
        {
            get;
            set;
        }


        public int EmployeeID
        {
            get;
            set;
        }

        public int ShiftTimingID
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }

        public string DepartmentDescription
        {
            get;
            set;
        }

        public int DesignationID
        {
            get;
            set;
        }

        public string DesignationDescription
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
