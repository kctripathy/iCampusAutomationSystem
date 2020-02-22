using System;

namespace Micro.Objects.Administration
{
    [Serializable]
   public class UserProfileGuest
    {
        public int GuestID
        {
            get;
            set;
        }
        public string Salutation
        {
            get;
            set;
        }
        public string GuestName
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Address_Present_TownOrCity
        {
            get;
            set;
        }
        public int Address_Present_DistrictID
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string PersonalEMailID
        {
            get;
            set;
        }

    }
}
