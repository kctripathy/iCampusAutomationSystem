using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class CustomerAccount
	{
		public int CustomerAccountID
		{
			get;
			set;
		}

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

		public string CustomerAccountCode
		{
			get;
			set;
		}

		public string ApplicationFormNumber
		{
			get;
			set;
		}

		public string ApplicationDate
		{
			get;
			set;
		}

		public bool IsJointApplication
		{
			get;
			set;
		}

		public string SecondApplicantName
		{
			get;
			set;
		}

		public int SecondApplicantAge
		{
			get;
			set;
		}

		public byte[] SecondApplicantSignature
		{
			get;
			set;
		}

		public string SecondApplicantPANGIR
		{
			get;
			set;
		}

		public string ThirdApplicantName
		{
			get;
			set;
		}

		public int ThirdApplicantAge
		{
			get;
			set;
		}

		public byte[] ThirdApplicantSignature
		{
			get;
			set;
		}

		public string ThirdApplicantPANGIR
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

		public string PolicyName
		{
			get;
			set;
		}

		public int PolicyTypeID
		{
			get;
			set;
		}

		public string PolicyTypeDescription
		{
			get;
			set;
		}

		public string InstallmentMode
		{
			get;
			set;
		}

		public int TermInMonths
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

		public int NumberOfInstallmentsPaid
		{
			get;
			set;
		}

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

		public string FieldForceName
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

		public decimal PayToCompany
		{
			get;
			set;
		}

		public decimal GuaranteedDividend
		{
			get;
			set;
		}

		public decimal BonusAmount
		{
			get;
			set;
		}

		public decimal PayByCompany
		{
			get;
			set;
		}

		public decimal MoneybackPayable
		{
			get;
			set;
		}

		public bool RevivalState
		{
			get;
			set;
		}

		public bool SellingState
		{
			get;
			set;
		}

		public bool MaturityState
		{
			get;
			set;
		}

		public int DCAccountID
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
	}
}