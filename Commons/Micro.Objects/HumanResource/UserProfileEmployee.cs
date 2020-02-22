using System;
using System.Drawing;

namespace Micro.Objects.HumanResource
{ [Serializable]
public 	class UserProfileEmployee
	{
        public int EmployeeID
        {
            get;
            set;
        }
        public string Salutation
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }

        public string EmployeeFirstName
        {
            get;
            set;
        }

        public string EmployeeLastName
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public string SpouseName
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        public string BloodGroup
        {
            get;
            set;
        }

        public string Religion
        {
            get;
            set;
        }

        public string Nationality
        {
            get;
            set;
        }

        public string MaritalStatus
        {
            get;
            set;
        }

        public string IdentificationMark
        {
            get;
            set;
        }

        public string KnownAilments
        {
            get;
            set;
        }

        //-----------------PRESENT ADDRESS

        public string Address_Present_TownOrCity
        {
            get;
            set;
        }

        public string Address_Present_LandMark
        {
            get;
            set;
        }

        public string Address_Present_Pincode
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

        public int Address_Present_StateID
        {
            get;
            set;
        }

        public string Address_Present_StateName
        {
            get;
            set;
        }

        public int Address_Present_CountryID
        {
            get;
            set;
        }

        public string Address_Present_CountryName
        {
            get;
            set;
        }

        //-----------------PERMANENT ADDRESS

        public string Address_Permanent_TownOrCity
        {
            get;
            set;
        }

        public string Address_Permanent_LandMark
        {
            get;
            set;
        }

        public string Address_Permanent_Pincode
        {
            get;
            set;
        }

        public int Address_Permanent_DistrictID
        {
            get;
            set;
        }

        public string Address_Permanent_DistrictName
        {
            get;
            set;
        }

        public int Address_Permanent_StateID
        {
            get;
            set;
        }

        public string Address_Permanent_StateName
        {
            get;
            set;
        }

        public int Address_Permanent_CountryID
        {
            get;
            set;
        }

        public string Address_Permanent_CountryName
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

        public string PersonalEMailID
        {
            get;
            set;
        }

        public string EmergencyContactNumber
        {
            get;
            set;
        }
        public Image SettingKeyValue
        {
            get;
            set;
        }

	}

}
