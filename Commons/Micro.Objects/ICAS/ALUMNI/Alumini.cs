using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.ALUMNI
{
    [Serializable]
    public class Alumini
    {
        public int AluminiID
        {
            get;
            set;
        }

        public string AluminiCode
        {
            get;
            set;
        }
     
        public string Salutation
        {
            get;
            set;
        }
        public string AluminiName
        {
            get;
            set;
        }
        public string FatherName
        {
            get;
            set;
        }
        public string MotherName
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public string Caste
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public string DateOfBirth
        {
            get;
            set;
        }
        public string DateOfAdmission
        {
            get;
            set;
        }
        public string DateOfLeaving
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
        public string EMailID
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
        public int CompanyID
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

    }
}
