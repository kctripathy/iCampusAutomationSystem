using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Hotel
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
        public string FirstName
        {
            get;
            set;
        }
        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }

        public string GuestName
        {
            get
            {
                return this.FirstName + " "+this.MiddleName+ " " + this.LastName;
            } 
        }
        public string Gender
        {
            get;
            set;
        }
        public DateTime DateOfBirth
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }
        public string HusbandName
        {
            get;
            set;
        }
        public string CompanyName
        {
            get;
            set;
        }

        public string CorporateName
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string Mobile
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }
        public DateTime DateOfAnniversary
        {
            get;
            set;
        }
        public string MaritalStatus
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
        public string Address_Present_State
        {
            get;
            set;
        }
        public string Address_Present_Country
        {
            get;
            set;
        }
        public string Address_Permanent_TownOrCity
        {
            get;
            set;
        }
        public string Address_Permanent_Landmark
        {
            get;
            set;
        }
        public string Address_Permanent_PinCode
        {
            get;
            set;
        }
        public int Address_Permanent_DistrictID
        {
            get;
            set;
        }

        public string Address_Permanent_State
        {
            get;
            set;
        }
        public string Address_Permanent_Country
        {
            get;
            set;
        }
        public string Occupation
        {
            get;
            set;
        }
        public string Identity
        {
            get;
            set;
        }

        public int IdentityID
        {
            get;
            set;
        }
        public string IdentityNumber
        {
            get;
            set;
        }
        public string AdditionalRequirements
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
        public int DateModified
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }

        public string RoomTypeDesc
        {
            get;
            set;
        }

        public string RoomNumber
        {
            get;
            set;
        }

    }
}
