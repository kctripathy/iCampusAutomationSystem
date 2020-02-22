using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.STAFFS
{
    [Serializable]
    public class Attendance
    {
        public int AttendanceID
        {
            get;
            set;
        }

        public string DateOfAttendance
        {
            get;
            set;
        }

        public string ShiftAlias
        {
            get;
            set;
        }

        public string InTime
        {
            get;
            set;
        }

        public int InSource
        {
            get;
            set;
        }

        public string OutTime
        {
            get;
            set;
        }

        public int OutSource
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
        public bool IsPresent
        {
            get;
            set;
        }
        public bool IsAbsent
        {
            get;
            set;
        }

        public bool IsWeeklyOff
        {
            get;
            set;
        }

        public bool IsPresentOnWeeklyOff
        {
            get;
            set;
        }

        public bool IsHoliday
        {
            get;
            set;
        }
        public bool IsPresentOnHoliday
        {
            get;
            set;
        }
        public bool IsLate
        {
            get;
            set;
        }

        public bool IsLeave
        {
            get;
            set;
        }

        public int TotalPresent
        {
            get;
            set;
        }
        public int TotalOverTime
        {
            get;
            set;
        }
        public int TotalAbsent
        {
            get;
            set;
        }
        public int TotalWeeklyOff
        {
            get;
            set;
        }

        public int TotalPresentonWeeklyOff
        {
            get;
            set;
        }
        public int TotalHoliday
        {
            get;
            set;
        }
        public int TotalPresentonHoliday
        {
            get;
            set;
        }
        public int TotalLeave
        {
            get;
            set;
        }
        public int TotalLate
        {
            get;
            set;
        }



    }
}
