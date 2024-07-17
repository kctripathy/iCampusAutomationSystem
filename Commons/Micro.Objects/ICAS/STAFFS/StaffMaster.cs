﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Micro.Objects.ICAS.STAFFS
{

    [Serializable]
    public class Staff
    {
        public int EmployeeID { get; set; }
        public int DesignationID { get; set; }
        public int DepartmentID { get; set; }

        public string EmployeeCode { get; set; }
        public string Salutation { get; set; }
        public string EmployeeName { get; set; }
        public string EMailID { get; set; }
        public string Mobile { get; set; }
        public string TeachingOrNonTeaching { get; set; }

        public string DepartmentDescription { get; set; }
        public string DesignationDescription { get; set; }

        public DateTime DateOfJoin { get; set; }
        public string PresentAddress { get; set; }



        public int IsActive { get; set; }
    }

    public class Staff2Save
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public int DesignationID { get; set; }
        public int DepartmentID { get; set; }
        public string Salutation { get; set; }
        public string EmployeeName { get; set; }
        public string EMailID { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string PresentAddress { get; set; }
        public int SavedByUserId { get; set; }

    }

    [Serializable]
    public class StaffMaster : IEquatable<StaffMaster>
    {
        public int EmployeeID
        {
            get;
            set;
        }

        public string EmployeeCode
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

        public string DateOfBirth
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

        public string ReferenceName
        {
            get;
            set;
        }

        public string ReferencePhone
        {
            get;
            set;
        }

        public string ReferenceMobile
        {
            get;
            set;
        }

        public int IsMatriculate
        {
            get;
            set;
        }

        public string LastQualification
        {
            get;
            set;
        }

        public int YearOfPassing
        {
            get;
            set;
        }

        public string Institution
        {
            get;
            set;
        }

        public string BoardOrUniversity
        {
            get;
            set;
        }

        public string ProfessionalQualification
        {
            get;
            set;
        }

        public string ProfessionalInstitution
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public int DesignationID
        {
            get;
            set;
        }

        public string DesignationDescription
        {
            get;
            set;
        }

        public DateTime PostingDate
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }

        public string DepartmentDescription
        {
            get;
            set;
        }

        public string ServiceType
        {
            get;
            set;
        }

        public string ServiceStatus
        {
            get;
            set;
        }

        public string ReferenceLetterNumber
        {
            get;
            set;
        }

        public int EmployeeServiceDetailsID
        {
            get;
            set;
        }

        public string Remarks
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

        public byte[] Picture
        {
            get;
            set;
        }

        public byte[] Signature
        {
            get;
            set;
        }

        public string PANDescription
        {
            get;
            set;
        }

        public Image PANImage
        {
            get;
            set;
        }

        public int ReportingToEmployeeID
        {
            get;
            set;
        }
        public string ReportingToEmployeeName
        {
            get;
            set;
        }

        public string ReportingToEffectiveDateFrom
        {
            get;
            set;
        }

        public int IsActive
        {
            get;
            set;
        }

        public int IsDeleted
        {
            get;
            set;
        }

        public DateTime DateOfCreate
        {
            get;
            set;
        }

        public int AddedBy
        {
            get;
            set;
        }

        public DateTime DateOfModify
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public string ModifyPersonName
        {
            get;
            set;
        }

        //-------------New object

         public string JoiningDateInOffice
        {
            get;
            set;
        }
         public string JoiningDateInService
        {
            get;
            set;
        }
         public string Employeetype1
        {
            get;
            set;
         }

        public string Employeetype2
        {
            get;
            set;
         }
        public string Employeetype3
        {
            get;
            set;
         }
        public string Employeetype4
        {
            get;
            set;
         }
        public string ServiceStatusChangeRequestDate
        {
            get;
            set;
        }
        public string ServiceStatusLastWorkingDate
        {
            get;
            set;
        }
        public string CourseID
        {
            get;
            set;
        }
        public string CourseName
        {
            get;
            set;
        }
		 public string PassingYear
        {
            get;
            set;
        }											
		public string Board
        {
            get;
            set;
        }
												 						
		public string Division
        {
			get;
			set;
        }

        public string PercentageMark
        {
            get;
            set;
        }
	     public string PHStatus
          {
                 get;
                 set;
           }
        public  string EPAndGPFAcNo
        {
            get;
            set;
        }
		public string PanNo
        {
            get;
            set;
        }
		public string SbiAccountNo
        {
            get;
            set;
        }
        public string ScaleOfPay
        {
            get;    
            set;
        }
        public string GpOrAGP
        {
            get;
            set;
        }
												
		public	string DateOfNextIncrement
        {
            get;
            set;
        }
        public string ChseRegdNo
        {
            get;
            set;
        }
        public string UnivRegdNo	
        {
            get;
            set;
        }
												
																									
												


        //-------------ROLE ID

        public int RoleID
        {
            get;
            set;
        }

        public string RoleDescription
        {
            get;
            set;
        }

        public string BioDeviceEmployeeID
        {
            get;
            set;
        }

        public string CompanyCode
        {
            get;
            set;
        }

        public Image EmployeePhoto
        {
            get;
            set;
        }

        public string DesignationAndRole
        {
            get
            {
                return this.DesignationDescription + "(" + this.RoleDescription + ")";
            }
        }

        public string EmpoyeeNameAndCode
        {
            get
            {
                int padLength = (80 - this.EmployeeName.Length);
                return String.Format("{0}{1} ({2})", this.EmployeeName.ToUpper().PadRight(padLength, '\u00A0'), " ", this.EmployeeCode.ToUpper());
            }
        }



        public bool Equals(StaffMaster other)
        {

            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return EmployeeName.Equals(other.EmployeeName);
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null.
            int hashEmployeeName = EmployeeName == null ? 0 : EmployeeName.GetHashCode();

            //Get hash code for the Code field.
            int hashEmployeeCode = EmployeeName.GetHashCode();

            //Calculate the hash code for the product.
            return hashEmployeeName ^ hashEmployeeCode;
        }

        public string TeachingOrNonTeaching
        {
            get;
            set;
        }
    }
}
