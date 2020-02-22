using System;

namespace Micro.Objects.HumanResource
{
     [Serializable]
    public class HRMSReportParameters
    {
        public int EmployeeID
        {
            get;
            set;
        }
        
         public int DepartmentID
        {
            get;
            set;
        }

        public int DesignationID
        {
            get;
            set;
        }

        public int HolidayID
        {
            get;
            set;
        }

        public int OfficeID
        {
            get;
            set;
        }

        public int ShiftID
        {
            get;
            set;
        }

        public int ShiftTimingID
        {
            get;
            set;
        }

        public DateTime Date1
        {
            get;
            set;
        }

        public DateTime Date2
        {
            get;
            set;
        }

        public int Month
        {
            get;
            set;
        }

        public int Year
        {
            get;
            set;
        }

        public string SearchText
        {
            get;
            set;
        }

        public Boolean ShowDeleted
        {
            get;
            set;
        }
     }
}
