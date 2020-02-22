using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class Office
    {
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

        public int OfficeTypeID
        {
            get;
            set;
        }

        public string OfficeTypeDescription
        {
            get;
            set;
        }

        public string OfficeCode
        {
            get;
            set;
        }

        public DateTime EstablishmentDate
        {
            get;
            set;
        }

        public int ParentOfficeID
        {
            get;
            set;
        }

        public string ParentOfficeCode
        {
            get;
            set;
        }

        public string ParentOfficeName
        {
            get;
            set;
        }

        public string Address_TownOrCity
        {
            get;
            set;
        }

        public string Address_Landmark
        {
            get;
            set;
        }

        public string Address_PinCode
        {
            get;
            set;
        }

        public int Address_DistrictID
        {
            get;
            set;
        }

        public string Address_DistrictName
        {
            get;
            set;
        }

        public int Address_StateID
        {
            get;
            set;
        }

        public string Address_StateName
        {
            get;
            set;
        }

        public int Address_CountryID
        {
            get;
            set;
        }

        public int Address_CountryName
        {
            get;
            set;
        }

        public int ManagerEmployeeID
        {
            get;
            set;
        }

        public string ManagerEmployeeName
        {
            get;
            set;
        }

        public string ContactPerson1
        {
            get;
            set;
        }

        public string ContactPerson2
        {
            get;
            set;
        }

        public string ContactPerson3
        {
            get;
            set;
        }

        public string StdCodePhone
        {
            get;
            set;
        }

        public string Phone1
        {
            get;
            set;
        }

        public string Phone2
        {
            get;
            set;
        }

        public string Phone3
        {
            get;
            set;
        }

        public string Extension1
        {
            get;
            set;
        }

        public string Extension2
        {
            get;
            set;
        }

        public string Extension3
        {
            get;
            set;
        }

        public string StdCodeFax
        {
            get;
            set;
        }

        public string Fax1
        {
            get;
            set;
        }

        public string Fax2
        {
            get;
            set;
        }

        public string Fax3
        {
            get;
            set;
        }

        public string Mobile1
        {
            get;
            set;
        }

        public string Mobile2
        {
            get;
            set;
        }

        public string Mobile3
        {
            get;
            set;
        }

        public string Email1
        {
            get;
            set;
        }

        public string Email2
        {
            get;
            set;
        }

        public string Email3
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public string CompanyCode
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public bool IsHavingShift
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
        public int ModifiedBy
        {
            get;
            set;
        }
    }
}