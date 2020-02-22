using System;
using Micro.Objects.Administration;

namespace Micro.Objects.HumanResource
{
     [Serializable]

    public class ShiftTiming
    {
        public Department Department= new Department();
        
        public Office Office = new Office();

        public int ShiftOfficewiseID
        {
            get;
            set;
        }
        public int ShiftTimingID
        {
            get;
            set;
        }

        public int ShiftID
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }
        public string ShiftDescription
        {
            get;
            set;
        }

        public string ShiftAlias
        {
            get;
            set;
        }

        public DateTime InTime
        {
            get;
            set;
        }

        public DateTime OutTime
        {
            get;
            set;
        }

        public string WeeklyOffDay
        {
            get;
            set;
        }

        public string CalculationMode
        {
            get;
            set;
        }        

        public DateTime EffectiveDate
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
        public int OfficeID
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
