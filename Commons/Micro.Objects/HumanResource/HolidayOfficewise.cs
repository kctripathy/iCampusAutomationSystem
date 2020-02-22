using System;
using Micro.Objects.Administration;

namespace Micro.Objects.HumanResource
{
    [Serializable]
    public class HolidayOfficewise
    {

        public Holiday HoliDay = new Holiday();
        public Office Office = new Office();

        public int HolidayOfficewiseID
        {
            get;
            set;
        }

        public int HolidayID
        {
            get{ return HoliDay.HolidayID;}
            set{ HoliDay.HolidayID=value; }
        }

        public string Occasion
        {
            get;
            set;
        }

        public DateTime DateOfOccasion
        {
            get;
            set;
        }

        public string WeekDayOfOccasion
        {
            get;
            set;
        }

        public int OfficeID
        {
            get { return Office.OfficeID; }
            set { Office.OfficeID = value; }
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
