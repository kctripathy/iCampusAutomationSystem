using System;

namespace Micro.Objects.ICAS.ADMIN
{
    [Serializable]
    public class Guest
    {
        public int GuestID
        {
            get;
            set;
        }
        public string GuestCode
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
        public int Age
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public string Address_Present_TownOrCity
        {
            get;
            set;
        }
        public string Address_Present_Landmark
        {
            get;
            set;
        }
        public string Address_Present_PinCode
        {
            get;
            set;
        }
        public int Address_Present_DistrictID
        {
            get;
            set;
        }
        public string Address_Present_DistrictName
        {
            get;
            set;
        }
        public string Address_Present_StateName
        {
            get;
            set;
        }
        public string Address_Present_CountryName
        {
            get;
            set;
        }


        public string PhoneNumber
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string OfficialEMailID
        {
            get;
            set;
        }
        public string PersonalEMailID
        {
            get;
            set;
        }
        public string EffectiveDateFrom
        {
            get;
            set;
        }
        public string EffectiveDateTo
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
        public string OfficeName
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public int AddedBy
        {
            get;
            set;
        }
        public string DateModified
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
