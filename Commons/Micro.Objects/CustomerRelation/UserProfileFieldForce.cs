using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
 public partial   class UserProfileFieldForce
    {
        public int FieldForceID
        {
            get;
            set;
        }
        public string Salutation
        {
            get;
            set;
        }
        public string FieldForceName
        {
            get;
            set;
        }
        public string FatherName
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
        public string Address_Permanent_TownOrCity
        {
            get;
            set;
        }
        public int Address_Permanent_DistrictID
        {
            get;
            set;
        }
        //public int Address_Present_StateID
        //{
        //    get;
        //    set;
        //}

        //public string Address_Present_StateName
        //{
        //    get;
        //    set;
        //}

        //public int Address_Present_CountryID
        //{
        //    get;
        //    set;
        //}

        //public string Address_Present_CountryName
        //{
        //    get;
        //    set;
        //}

        //public int Address_Permanent_StateID
        //{
        //    get;
        //    set;
        //}

        //public string Address_Permanent_StateName
        //{
        //    get;
        //    set;
        //}

        //public int Address_Permanent_CountryID
        //{
        //    get;
        //    set;
        //}

        //public string Address_Permanent_CountryName
        //{
        //    get;
        //    set;
        //}
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

        //public bool Equals(FieldForce other)
        //{

        //    //Check whether the compared object is null.
        //    if (Object.ReferenceEquals(other, null)) return false;

        //    //Check whether the compared object references the same data.
        //    if (Object.ReferenceEquals(this, other)) return true;

        //    //Check whether the products' properties are equal.
        //    return FieldForceName.Equals(other.FieldForceName);
        //}


        //public override int GetHashCode()
        //{

        //    //Get hash code for the Name field if it is not null.
        //    int hashFFName = FieldForceName == null ? 0 : FieldForceName.GetHashCode();


        //    //Calculate the hash code for the product.
        //    return hashFFName;
        //}
    }
}
