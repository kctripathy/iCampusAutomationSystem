using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
	public class Customer : IEquatable<Customer>
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

        public string Address_Present_DistrictName
        {
            get;
            set;
        }

        public string  Address_Present_StateName
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

        public string Address_Permanent_StateName
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

        public string OfficeName
        {
            get;
            set;
        }

		public string CustomerNameAndCode
		{
			get
			{
				int padLength = (50 - this.CustomerName.Length);
				return String.Format("{0}{1} {2}", this.CustomerName.ToUpper().PadRight(padLength, '\u00A0'),  " ", this.CustomerCode.ToUpper());
			}
		}



		public bool Equals(Customer other)
		{

			//Check whether the compared object is null.
			if (Object.ReferenceEquals(other, null)) return false;

			//Check whether the compared object references the same data.
			if (Object.ReferenceEquals(this, other)) return true;

			//Check whether the products' properties are equal.
			return CustomerName.Equals(other.CustomerName);
		}

		// If Equals() returns true for a pair of objects 
		// then GetHashCode() must return the same value for these objects.

		public override int GetHashCode()
		{

			//Get hash code for the Name field if it is not null.
			int hashCustomerName = CustomerName == null ? 0 : CustomerName.GetHashCode();

			//Get hash code for the Code field.
			int hashCustomerCode = CustomerName.GetHashCode();

			//Calculate the hash code for the product.
			return hashCustomerName ^ hashCustomerCode;
		}
    }
}
