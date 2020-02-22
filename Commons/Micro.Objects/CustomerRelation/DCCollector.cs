using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
	public class DCCollector : IEquatable<DCCollector>
    {
        public int DCCollectorID
        {
            get;
            set;
        }
        public string DCCollectorCode
        {
            get;
            set;
        }
        public string Salutation
        {
            get;
            set;
        }
        public string DCCollectorName
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
		
		public string Phone
        {
            get;
            set;
        }
        public string Mobile
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Qualification
        {
            get;
            set;
        }
        public string Occupation
        {
            get;
            set;
        }
        public string Nationality
        {
            get;
            set;
        }
        public string Religion
        {
            get;
            set;
        }
        public string Caste
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

        public byte[] Photo
        {
            get;
            set;
        }
        public byte[] Signature
        {
            get;
            set;
        }
        public string DateOfJoining
        {
            get;
            set;
        }
        public string DCCollectorPassword
        {
            get;
            set;
        }
        public decimal MaximumCollectionAmountAllowed
        {
            get;
            set;
        }
        public int MaximumMinutesAllowed
        {
            get;
            set;
        }
        public int MaximumTransactionsAllowed
        {
            get;
            set;
        }
        public bool CanDownloadMaster
        {
            get;
            set;
        }
        public bool CanDoTransactions
        {
            get;
            set;
        }
        public bool CanPrintDuplicateReceipts
        {
            get;
            set;
        }
        public bool CanCancelTransaction
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

		public string DcCollectorNameAndCode
		{
			get
			{
				int padLength = (50 - this.DCCollectorName.Length);
				return String.Format("{0}{1} {2}", this.DCCollectorName.ToUpper().PadRight(padLength, '\u00A0'), " ", this.DCCollectorCode.ToUpper());
			}
		}



		public bool Equals(DCCollector other)
		{

			//Check whether the compared object is null.
			if (Object.ReferenceEquals(other, null)) return false;

			//Check whether the compared object references the same data.
			if (Object.ReferenceEquals(this, other)) return true;

			//Check whether the products' properties are equal.
			return DCCollectorName.Equals(other.DCCollectorName);
		}

		// If Equals() returns true for a pair of objects 
		// then GetHashCode() must return the same value for these objects.

		public override int GetHashCode()
		{

			//Get hash code for the Name field if it is not null.
			int hashDCCollectorName = DCCollectorName == null ? 0 : DCCollectorName.GetHashCode();

			//Get hash code for the Code field.
			int hashDCCollectorCode = DCCollectorName.GetHashCode();

			//Calculate the hash code for the product.
			return hashDCCollectorName ^ hashDCCollectorCode;
		}

    }
}
