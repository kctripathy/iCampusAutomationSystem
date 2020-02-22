using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class FieldForce : IEquatable<FieldForce>
	{
		public int FieldForceID
		{
			get;
			set;
		}

		public string FieldForceCode
		{
			get;
			set;
		}

		public int FieldForceRankID
		{
			get;
			set;
		}

		public string FieldForceRankName
		{
			get;
			set;
		}

		public string FieldForceRankDescription
		{
			get;
			set;
		}
		
		public int ReportingToFieldForceRankID
		{
			get;
			set;
		}

		public string ReportingToFieldForceRankName
		{
			get;
			set;
		}

		public string ReportingToFieldForceRankDescription
		{
			get;
			set;
		}

		public int ReportingToFieldForceID
		{
			get;
			set;
		}

		public string ReportingToFieldForceCode
		{
			get;
			set;
		}

		public string ReportingToFieldForceName
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

		public string FieldForce_Qualification
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

		public string NomineeName
		{
			get;
			set;
		}
		
		public string Nominee_Permanent_TownOrCity
		{
			get;
			set;
		}

		public string Nominee_Permanent_Landmark
		{
			get;
			set;
		}

		public string Nominee_Permanent_PinCode
		{
			get;
			set;
		}

		public int Nominee_Permanent_DistrictID
		{
			get;
			set;
		}

		public string Nominee_Permanent_DistrictName
		{
			get;
			set;
		}

		public string Nominee_Permanent_StateName
		{
			get;
			set;
		}

		public string Nominee_Permanent_CountryName
		{
			get;
			set;
		}

		public string NomineeRelationship
		{
			get;
			set;
		}

		public int NomineeAge
		{
			get;
			set;
		}

		public bool IsNomineeACoWorker
		{
			get;
			set;
		}

		public string Nominee_Qualification
		{
			get;
			set;
		}

		public string BankName
		{
			get;
			set;
		}

		public int BankBranchID
		{
			get;
			set;
		}

		public string BankBranchName
		{
			get;
			set;
		}

		public string BankAccountNumber
		{
			get;
			set;
		}

		public bool HasServiceComplain
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
		//public int FieldForceProfileID
		//{
		//    get;
		//    set;
		//}

		//public int SettingKeyID
		//{
		//    get;
		//    set;
		//}

		//public string SettingKeyName
		//{
		//    get;
		//    set;
		//}

		//public string SettingKeyDescription
		//{
		//    get;
		//    set;
		//}

		//public byte[] SettingKeyValue
		//{
		//    get;
		//    set;
		//}

		//public string SettingKeyReference
		//{
		//    get;
		//    set;
		//}

		//public string PhotoKeyName
		//{
		//    get;
		//    set;
		//}

		//public string PhotoKeyDescription
		//{
		//    get;
		//    set;
		//}

		//public byte[] PhotoKeyValue
		//{
		//    get;
		//    set;
		//}

		//public string PhotoKeyReference
		//{
		//    get;
		//    set;
		//}

		//public string SignatureKeyName
		//{
		//    get;
		//    set;
		//}

		//public string SignatureKeyDescription
		//{
		//    get;
		//    set;
		//}

		//public byte[] SignatureKeyValue
		//{
		//    get;
		//    set;
		//}

		//public string SignatureKeyReference
		//{
		//    get;
		//    set;
		//}


		public bool Equals(FieldForce other)
		{

			//Check whether the compared object is null.
			if (Object.ReferenceEquals(other, null)) return false;

			//Check whether the compared object references the same data.
			if (Object.ReferenceEquals(this, other)) return true;

			//Check whether the products' properties are equal.
			return FieldForceName.Equals(other.FieldForceName);
		}


		public override int GetHashCode()
		{

			//Get hash code for the Name field if it is not null.
			int hashFFName = FieldForceName == null ? 0 : FieldForceName.GetHashCode();

			
			//Calculate the hash code for the product.
			return hashFFName;
		}
	}
}
