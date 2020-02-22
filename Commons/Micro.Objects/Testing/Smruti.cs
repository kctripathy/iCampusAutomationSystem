using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.Testing
{
    [Serializable]
    public class Smruti
    {
        public int CustomerID
        {
            get;
            set;
        }

        public string CustomerCode
        {
            get;
            set;
        }

        public string Salutation
        {
            get;
            set;
        }

        public string CustomerName
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

        public string Gender
        {
            get;
            set;
        }

        public string MaritalStatus
        {
            get;
            set;
        }

        public string DateOfBirth
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

        public int Address_Present_StateID
        {
            get;
            set;
        }

        public int Address_Present_CountryID
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

        public int Address_Permanent_StateID
        {
            get;
            set;
        }

        public int Address_Permanent_CountryID
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

        public string Occupation
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

        public int CustomerAccountID
        {
            get;
            set;
        }
        //object for Customer Account
        public string AccountID
        {
            get;
            set;
        }
        public int PolicyTypeID
        {
            get;
            set;
        }
        public string ApplicationDate
        {
            get;
            set;
        }
        public string DueDateOfLastPayment
        {
            get;
            set;
        }
        public string DueDateOfMaturity
        {
            get;
            set;
        }
        public decimal InstallmentAmount
        {
            get;
            set;
        }
        public int NumberOfInstallmentsToBePaid
        {
            get;
            set;
        }
    }
}
