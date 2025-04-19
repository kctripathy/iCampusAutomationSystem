using System;
using System.Reflection;

namespace Micro.Objects.ICAS.STUDENT
{
    [Serializable]
    public class Student
    {

        public int StudentID
        {
            get;
            set;
        }

        public string RegistrationNumber
        {
            get;
            set;
        }
        public string StudentCode
        {
            get;
            set;
        }
        public string MRINO
        {
            get;
            set;
        }
        public string ReceiptNo
        {
            get;
            set;
        }
        public string TCNo
        {
            get;
            set;
        }
        public string RollNo
        {
            get;
            set;
        }
        public int ClassID
        {
            get;
            set;
        }
        public int QualID
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public string Salutation
        {
            get;
            set;
        }
		public string StudentName
		{
			get;
			set;
		}


		public string StudentRollNoName
		{
			get
			{
				int padLength = (31 - this.RollNo.Length);
				return String.Format("{0}{1} {2}", "", this.RollNo.ToUpper().PadRight(padLength, '\u00A0'), this.StudentName.ToUpper());
			}
		}
		public string StudentNameRollNo
		{
			get
			{
				int padLength = (50 - this.StudentName.Length);
				return String.Format("{0}{1} {2}", "", this.StudentName.ToUpper().PadRight(padLength, '\u00A0'), this.RollNo);
			}
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
        public string PHStatus
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public string BloodGroup
        {
            get;
            set;
        }
        public string TotalFeesPaid
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

        public int SessionID
        {
            get;
            set;
        }
        //Student Account Pass Varibles
        public string AccountIDs
        {
            get;
            set;
        }

        public string AccountCodes
        {
            get;
            set;
        }

        public string AccountNames
        {
            get;
            set;
        }

        public string AccountFees
        {
            get;
            set;
        }

        public string BalanceTypes
        {
            get;
            set;
        }
        public string Narations
        {
            get;
            set;
        }



        public string AlumniFlag
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
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }
        public string LifeMemberStatus
        {
            get;
            set;
        }
        public int AlumniMembershipFeesPaid
        {
            get;
            set;
        }
        public string AlumniMembershipFeesPaidDetails
        {
            get;
            set;
        }
        public string AlumniPresentOccupation
        {
            get;
            set;
        }
        public string AlumniYearOfPassing
        {
            get;
            set;
        }
        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
    }


    public class StudentViewModel
    {
        public int SessionID { get; set; }
        public int StreamID { get; set; }
        public int ClassID { get; set; }
        public int QualID { get; set; }
        public long StudentID { get; set; }
        public string RollNo { get; set; }


        public string StudentCode { get; set; }
        public string MRINO { get; set; }
        public string Salutation { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }


        //public Address PresentAddress { get; set; }
        //public Address PermanentAddress { get; set; }
        public string PresentAddress_TownCity { get; set; }
        public string PresentAddress_District { get; set; }
        public string PresentAddress_State { get; set; }
        public string PresentAddress_PIN { get; set; }


        public string PermanentAddress_TownCity { get; set; }
        public string PermanentAddress_District { get; set; }
        public string PermanentAddress_State { get; set; }
        public string PermanentAddress_PIN { get; set; }


        public string Gender { get; set; }
        public string Caste { get; set; }
        public string Category { get; set; }
        public string Religion { get; set; }
        public string DateOfAdmission { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string AadhaarNo { get; set; }
        public string BarcodeNo { get; set; }
        public string AdmissionType { get; set; }
        public string FullName { get { return this.Salutation + ' ' + this.StudentName; } }
        public string ClassName { get; set; }
        public string StreamName { get; set; }
        public string QualName { get; set; }
        public string Mobile { get; set; }
        public string EMail{ get; set; }
        public string SLCNo { get; set; }
        public string SLCDate { get; set; }
        public string SubjectName { get; set; }
        public bool isActive { get; set; }
    }

    public class Address
    {
        public string TownOrCity { get; set; }
        public string DistrictName { get; set; }
        public string StateName { get; set; } = "Odisha";
        public string ContryName { get; set; } = "India";
        public string PINCode { get; set; }
    }

    public class StudentSearchPayload
    {
        public long studentId { get; set; } //0 to 4,294,967,295
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public string searchText { get; set; }
    }
} 
