using System;

namespace Micro.Objects.Administration
{
    [Serializable]
	public class MicroCalendar
	{
        public int TheDateID
        {
            get;
            set;
        }

        public DateTime CalendarDate
        {
            get;
            set;
        }

        public string CalendarDateDesc
        {
            get;
            set;
        }

        public char IsMicroHoliday
        {
            get;
            set;
        }

        public char IsLocalHoliday
        {
            get;
            set;
        }

        public char IsGovtHoliday
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

        public int AddedBy
        {
            get;
            set;
        }

        public DateTime DateModified
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }



	}
}
