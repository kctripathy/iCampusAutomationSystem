using System;

namespace Micro.Objects.HumanResource
{
   [Serializable]
   public class Holiday
    {
       public int HolidayID
        {
            get;
            set;
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

       public bool IsDateFixed
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
