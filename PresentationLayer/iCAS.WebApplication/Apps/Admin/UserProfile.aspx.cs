using System;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.CustomerRelation;
using Micro.BusinessLayer.HumanResource;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Objects.CustomerRelation;
using Micro.Objects.HumanResource;
using Micro.Framework.ReadXML;
using System.IO;

namespace Micro.WebApplication.MicroERP.ADMIN
{
	/// <summary>
	/// Edits Logged on user's profile
	/// <author>
	/// Premananda Routray
	/// </author>
	/// </summary>
	public partial class UserProfile : BasePage
	{
		#region Declaration
		
		protected static class PageVariables
		{
			

		}
		#endregion

		#region Events

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindDropdown();

				PopulateFormFields();
				GetViewUserWise();
				SetFormMessage();
                GetUserType();

			}

		}

		protected void ddl_EmployeePresentDistrict_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				District TheDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(ddl_EmployeePresentDistrict.SelectedValue));
				txt_EmployeePresentState.Text = TheDistrict.StateName;
				txt_EmployeePresentCountry.Text = TheDistrict.CountryName;
			}
			catch
			{
				txt_EmployeePresentState.Text = string.Empty;
				txt_EmployeePresentCountry.Text = string.Empty;
			}
		}

       

		protected void ddl_FieldForcePresentDistrict_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				District TheDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(ddl_FieldForcePresentDistrict.SelectedValue));
				txt_FieldForcePresentState.Text = TheDistrict.StateName;
				txt_FieldForcePresentCountry.Text = TheDistrict.CountryName;
			}
			catch
			{
				txt_FieldForcePresentState.Text = string.Empty;
				txt_FieldForcePresentCountry.Text = string.Empty;
			}
		}

		protected void ddl_FieldForcePermanentDistrict_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				District ThisDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(ddl_FieldForcePermanentDistrict.SelectedValue));
				txt_FieldForcePermanentState.Text = ThisDistrict.StateName;
				txt_FieldForcePermanentCountry.Text = ThisDistrict.CountryName;
			}
			catch
			{
				txt_FieldForcePermanentState.Text = string.Empty;
				txt_FieldForcePermanentCountry.Text = string.Empty;
			}
		}

		protected void ddl_GuestPresentDistrict_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				District TheDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(ddl_GuestPresentDistrict.SelectedValue));
				txt_GuestState.Text = TheDistrict.StateName;
				txt_GuestCountry.Text = TheDistrict.CountryName;
			}
			catch
			{
				txt_GuestState.Text = string.Empty;
				txt_GuestCountry.Text = string.Empty;
			}
		}

        
        protected void ddl_FieldForceSalutation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeSalutation(ddl_FieldForceSalutation,ddl_FieldForceGender,ddl_FieldForceMaritalStatus);
            }
            catch
            {
                return;
            }
        }

        protected void ddl_GuestSalutation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeSalutationGuest(ddl_GuestSalutation, ddl_GuestGender);
            }
            catch
            {
                return;
            }
        }

		protected void btn_FieldForceUpload_Click(object sender, EventArgs e)
		{
			FileUpload(flup_FieldForcePhoto, Img_FieldForcePhoto);
		}

		protected void btn_EmployeeUpdate_Click(object sender, EventArgs e)
		{
			int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

			if (ValidateFormFields())
			{
				ProcReturnValue = UpdateRecord();
				

				if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
				{
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "User", MicroEnums.DataOperation.Edit);
                    dialog_EmployeeMessage.Show();
				}
			}
            
		}

		protected void btn_GuestUpdate_Click(object sender, EventArgs e)
		{
			int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

			if (ValidateFormFields())
			{
				ProcReturnValue = UpdateRecord();
				
				if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
				{
					//dialog_GuestMessage.Show();
				}
			}
            dialog_GuestMessage.Show();

		}

		protected void btn_FieldForceUpdate_Click(object sender, EventArgs e)
		{
			int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

			if (ValidateFormFields())
			{
				ProcReturnValue = UpdateRecord();
				

				if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
				{
					//dialog_FieldForceMessage.Show();
				}
			}
            dialog_FieldForceMessage.Show();

		}

		#endregion

		#region Methods & Implementations


		private void SetFormMessage()
		{
            
			requiredFieldValidator_EmployeePresentPinCode.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Pin Code");
			requiredFieldValidator_EmployeePresentTownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Town Or City");
			requiredFieldValidator_PresentDistrict.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "District");
			requiredFieldValidator_FieldForceName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Name");
			requiredFieldValidator_fieldForceDateOfBirth.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Date Of Birth");
			requiredFieldValidator_FieldForcePresentTownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY");
			requiredFieldValidator_FieldForcePresentDistrict.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Town Or City");
			requiredFieldValidator_GuestName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Name");
			requiredFieldValidator_GuestAge.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Age");
			requiredFieldValidator_GuestPresentDistrict.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "District");
			requiredFieldValidator__GuestPresentTownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Town Or City");

            //regulalExpressionVlidator_EmployeeIdentficationMark.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_ALPHANUMERIC_SPACE_DOT");
            //regulalExpressionVlidator_EmployeeKnownAliments.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_ALPHANUMERIC_SPACE_DOT");
            
			regulalExpressionVlidator_EmployeePresentLandMark.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
			regulalExpressionVlidator_EmployeePresentPinCode.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_NUMBER_FIELD");
			regulalExpressionVlidator_EmployeePresentTownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
            //regulalExpressionVlidator_EmailId.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_EMAIL_FIELD");
			regularExpression_EmployeePersonalEmailId.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_EMAIL_FIELD");
            
            regularExpressionValidator_FieldForceName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            regularExpressionValidator_FieldForceFatherName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
			regulalExpressionVlidator_FieldForcePermanentTownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
			regularExpressionValidator_FieldForcePresentTownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
			regularExpressionValidator_GuestName.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");
			regularExpressionValidator_GuestPresentTownOrCity.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_ALPHABET_FIELD");

            rangevalidator_EmployeeEmergencycontactNumber.ErrorMessage = ReadXML.GetGeneralMessage("INVALID_PHONE");
            rangeValidator_EmployeeMobile.ErrorMessage = ReadXML.GetGeneralMessage("INVALID_MOBILE");
            rangeValidator_EmployeePhoneNumber.ErrorMessage = ReadXML.GetGeneralMessage("INVALID_PHONE");
            rangeValidator_FieldForceMobile.ErrorMessage = ReadXML.GetGeneralMessage("INVALID_MOBILE");
            rangeValidator_FieldForcePhoneNumber.ErrorMessage = ReadXML.GetGeneralMessage("INVALID_PHONE");
			rangeValidator_GuestAge.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_GREATERTHANZERO");
            rangeValidator_GuestPhone.ErrorMessage = ReadXML.GetGeneralMessage("INVALID_PHONE");

			SetFormMessageCSSClass("ValidateMessage");
		}

		private void SetFormMessageCSSClass(string theClassName)
		{
           
			requiredFieldValidator_EmployeePresentPinCode.CssClass = theClassName;
			requiredFieldValidator_EmployeePresentTownOrCity.CssClass = theClassName;
			requiredFieldValidator_PresentDistrict.CssClass = theClassName;
			requiredFieldValidator_FieldForceName.CssClass = theClassName;
			requiredFieldValidator_fieldForceDateOfBirth.CssClass = theClassName;
			requiredFieldValidator_FieldForcePresentTownOrCity.CssClass = theClassName;
			requiredFieldValidator_FieldForcePresentDistrict.CssClass = theClassName;
			requiredFieldValidator_GuestName.CssClass = theClassName;
			requiredFieldValidator_GuestPresentDistrict.CssClass = theClassName;
			requiredFieldValidator__GuestPresentTownOrCity.CssClass = theClassName;
			requiredFieldValidator_GuestAge.CssClass = theClassName;

            //regulalExpressionVlidator_EmployeeIdentficationMark.CssClass = theClassName;
            //regulalExpressionVlidator_EmployeeKnownAliments.CssClass = theClassName;
          
			regulalExpressionVlidator_EmployeePresentLandMark.CssClass = theClassName;
			regulalExpressionVlidator_EmployeePresentPinCode.CssClass = theClassName;
			regulalExpressionVlidator_EmployeePresentTownOrCity.CssClass = theClassName;
            //regulalExpressionVlidator_EmailId.CssClass = theClassName;
			regularExpression_EmployeePersonalEmailId.CssClass = theClassName;
			regularExpressionValidator_FieldForceName.CssClass = theClassName;
			regularExpressionValidator_FieldForceFatherName.CssClass = theClassName;
			regulalExpressionVlidator_FieldForcePermanentTownOrCity.CssClass = theClassName;
			regularExpressionValidator_FieldForcePresentTownOrCity.CssClass = theClassName;
			regularExpressionValidator_GuestName.CssClass = theClassName;
			regularExpressionValidator_GuestPresentTownOrCity.CssClass = theClassName;

			rangevalidator_EmployeeEmergencycontactNumber.CssClass = theClassName;
			rangeValidator_EmployeeMobile.CssClass = theClassName;
			rangeValidator_EmployeePhoneNumber.CssClass = theClassName;
			rangeValidator_FieldForceMobile.CssClass = theClassName;
			rangeValidator_FieldForcePhoneNumber.CssClass = theClassName;
			rangeValidator_GuestPhone.CssClass = theClassName;
			rangeValidator_GuestAge.ErrorMessage = theClassName;
		}

		private void BindDropdown()
		{
            

			ddl_EmployeePresentDistrict.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
			ddl_EmployeePresentDistrict.DataTextField = DistrictManagement.GetInstance.DisplayMember;
			ddl_EmployeePresentDistrict.DataValueField = DistrictManagement.GetInstance.ValueMember;
			ddl_EmployeePresentDistrict.DataBind();

          
			ddl_GuestSalutation.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Salutation.GetStringValue());
			ddl_GuestSalutation.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_GuestSalutation.DataBind();

			ddl_GuestGender.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Gender.GetStringValue());
			ddl_GuestGender.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_GuestGender.DataBind();

			ddl_GuestPresentDistrict.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
			ddl_GuestPresentDistrict.DataTextField = DistrictManagement.GetInstance.DisplayMember;
			ddl_GuestPresentDistrict.DataValueField = DistrictManagement.GetInstance.ValueMember;
			ddl_GuestPresentDistrict.DataBind();

			ddl_FieldForceGender.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Gender.GetStringValue());
			ddl_FieldForceGender.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_FieldForceGender.DataBind();

			ddl_FieldForceMaritalStatus.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.MaritalStatus.GetStringValue());
			ddl_FieldForceMaritalStatus.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_FieldForceMaritalStatus.DataBind();


			ddl_FieldForceSalutation.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Salutation.GetStringValue());
			ddl_FieldForceSalutation.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_FieldForceSalutation.DataBind();

			ddl_FieldForceReligion.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Religion.GetStringValue());
			ddl_FieldForceReligion.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_FieldForceReligion.DataBind();

			ddl_FieldForceNationality.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Nationality.GetStringValue());
			ddl_FieldForceNationality.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_FieldForceNationality.DataBind();

			ddl_FieldForcePresentDistrict.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
			ddl_FieldForcePresentDistrict.DataTextField = DistrictManagement.GetInstance.DisplayMember;
			ddl_FieldForcePresentDistrict.DataValueField = DistrictManagement.GetInstance.ValueMember;
			ddl_FieldForcePresentDistrict.DataBind();

			ddl_FieldForcePermanentDistrict.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
			ddl_FieldForcePermanentDistrict.DataTextField = DistrictManagement.GetInstance.DisplayMember;
			ddl_FieldForcePermanentDistrict.DataValueField = DistrictManagement.GetInstance.ValueMember;
			ddl_FieldForcePermanentDistrict.DataBind();

			ddl_GuestSalutation.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Salutation.GetStringValue());
			ddl_GuestSalutation.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_GuestSalutation.DataBind();

			ddl_GuestGender.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Gender.GetStringValue());
			ddl_GuestGender.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_GuestGender.DataBind();

			ddl_GuestPresentDistrict.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
			ddl_GuestPresentDistrict.DataTextField = DistrictManagement.GetInstance.DisplayMember;
			ddl_GuestPresentDistrict.DataValueField = DistrictManagement.GetInstance.ValueMember;
			ddl_GuestPresentDistrict.DataBind();

		}
		private byte[] ConvertImageToByteArray(FileUpload fuImage)
		{
			byte[] ImageByteArray;
			try
			{
				MemoryStream ms = new MemoryStream(fuImage.FileBytes);
				ImageByteArray = ms.ToArray();
				return ImageByteArray;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		private void FileUpload(FileUpload upLoadControl, Image imageControl)
		{
			if (upLoadControl.HasFile)
			{
				string FilePath = @"C:\Temp\";
				if (!Directory.Exists(FilePath))
				{
					Directory.CreateDirectory(FilePath);
				}

				lbl_FileName.Text = Path.Combine(@"C:\Temp\", upLoadControl.FileName);
				upLoadControl.SaveAs(lbl_FileName.Text);

				string virtualPath = "~/Themes/Default/Images/" + upLoadControl.FileName;
				upLoadControl.SaveAs(MapPath(virtualPath));
				imageControl.ImageUrl = virtualPath;

			}
		}




		public static void ChangeSalutation(DropDownList theSalutation, DropDownList theGender, DropDownList theMaritalStatus)
		{
			string TheGender = MicroEnums.Gender.Male.GetStringValue();


			string TheSalutation = theSalutation.Text;

			if (TheSalutation.Equals(MicroEnums.Salutations.Dr.GetStringValue()))
			{
				theGender.Text = TheGender;
				theGender.Enabled = true;
			}
			else
			{
				if (TheSalutation.Equals(MicroEnums.Salutations.Mr.GetStringValue()))
				{
					TheGender = MicroEnums.Gender.Male.GetStringValue();
				}
				else
				{
					TheGender = MicroEnums.Gender.Female.GetStringValue();

					if (TheSalutation.Equals(MicroEnums.Salutations.Miss.GetStringValue()))
					{
						theMaritalStatus.Text = MicroEnums.MaritalStatus.Unmarried.GetStringValue();
					}
					else
					{
						theMaritalStatus.Text = MicroEnums.MaritalStatus.Married.GetStringValue();
					}
				}

				theGender.Text = TheGender;
				theGender.Enabled = false;
			}
		}
        private void ChangeSalutationGuest(DropDownList theSalutation, DropDownList theGender)
        {
            string ThisGender = MicroEnums.Gender.Male.GetStringValue();
            string ThisSalutation = theSalutation.Text;
            if (ThisSalutation.Equals(MicroEnums.Salutations.Dr.GetStringValue()))
            {
                theGender.Text = ThisGender;
                theGender.Enabled = true;
            }
          
               else
			{
				if (ThisSalutation.Equals(MicroEnums.Salutations.Mr.GetStringValue()))
				{
					ThisGender = MicroEnums.Gender.Male.GetStringValue();
				}
				else
				{
					ThisGender = MicroEnums.Gender.Female.GetStringValue();
				}

				theGender.Text = ThisGender;
				theGender.Enabled = false;
			}
		}
               
           
		private void PopulateFormFields()
		{
			string UserReferenceType = Connection.LoggedOnUser.UserType;
			int UserReferenceID = Connection.LoggedOnUser.UserReferenceID;

			if (UserReferenceType.Equals(MicroEnums.UserType.Employee.GetStringValue()))
				PopulateEmployee(UserReferenceID);
			//PopulateEmployeeProfilePhoto(UserReferenceID);


			if (UserReferenceType.Equals(MicroEnums.UserType.FieldForce.GetStringValue()))
				PopulateFieldForce(UserReferenceID);

			if (UserReferenceType.Equals(MicroEnums.UserType.Guest.GetStringValue()))
				PopulateGuest(UserReferenceID);
		}

		private void PopulateEmployee(int employeeID)
		{
			Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(employeeID);

			txt_EmployeeName.Text =String.Format("{0} {1}",TheEmployee.Salutation, TheEmployee.EmployeeName);
			txt_EmployeeFatherName.Text = TheEmployee.FatherName;
			txt_EmployeeSpouseName.Text = TheEmployee.SpouseName;
            txt_EmployeeDateOfBirth.Text = TheEmployee.DateOfBirth;
			txt_EmployeeGender.Text = TheEmployee.Gender;
			txt_EmployeeBloodGroup.Text = TheEmployee.BloodGroup;
			txt_EmployeeReligion.Text = TheEmployee.Religion;
			txt_EmployeeNationality.Text = TheEmployee.Nationality;
			txt_EmployeeMaritalStatus.Text = TheEmployee.MaritalStatus;
			txt_EmployeeKnownAliments.Text = TheEmployee.KnownAilments;
			txt_EmployeeIdentificationMark.Text = TheEmployee.IdentificationMark;
			txt_EmployeePresentTownOrCity.Text = TheEmployee.Address_Present_TownOrCity;
			txt_EmployeePresentLandMark.Text = TheEmployee.Address_Present_LandMark;
			txt_EmployeePresentPinCode.Text = TheEmployee.Address_Present_Pincode;
			ddl_EmployeePresentDistrict.Text = TheEmployee.Address_Present_DistrictID.ToString();
			txt_EmployeePresentState.Text = TheEmployee.Address_Present_StateName;
			txt_EmployeePresentCountry.Text = TheEmployee.Address_Present_CountryName;
			txt_EmployeePhoneNumber.Text = TheEmployee.PhoneNumber;
			txt_EmployeeMobile.Text = TheEmployee.Mobile;
            //txt_EmployeeEmailId.Text = TheEmployee.EmailID;
			txt_EmployeePersonalEmailId.Text = TheEmployee.PersonalEMailID;
			txt_EmployeeEmergencyContactNumber.Text = TheEmployee.EmergencyContactNumber;
            txt_Designation.Text = TheEmployee.DesignationDescription;
            txt_Department.Text = TheEmployee.DepartmentDescription;
            txt_ReportingOffice.Text = TheEmployee.OfficeName;
            txt_ReportingEmployee.Text = TheEmployee.ReportingToEmployeeName;
            txt_ServiceType.Text = TheEmployee.ServiceType;
            txt_Status.Text = TheEmployee.ServiceStatus;
            txt_JoinDate.Text = TheEmployee.PostingDate.ToString(MicroConstants.DateFormat);
            txt_OfficeEmail.Text = TheEmployee.EmailID;

			
		}
       
		private void PopulateFieldForce(int fieldForceID)
		{
			FieldForce TheFieldForce = FieldForceManagement.GetInstance.GetFieldForceById(fieldForceID);

			ddl_FieldForceSalutation.Text = TheFieldForce.Salutation;
			txt_FieldForceName.Text = TheFieldForce.FieldForceName;
			txt_FieldForceFatherName.Text = TheFieldForce.FatherName;
            txt_fieldForceDateOfBirth.Text = DateTime.Parse(TheFieldForce.DateOfBirth).ToString(MicroConstants.DateFormat);
			ddl_FieldForceGender.Text = TheFieldForce.Gender;
			ddl_FieldForceReligion.Text = TheFieldForce.Religion;
			ddl_FieldForceNationality.Text = TheFieldForce.Nationality;
			ddl_FieldForceMaritalStatus.Text = TheFieldForce.MaritalStatus;
			txt_FieldForcePresentTownOrCity.Text = TheFieldForce.Address_Present_TownOrCity;
			ddl_FieldForcePresentDistrict.SelectedValue = TheFieldForce.Address_Present_DistrictID.ToString();
			txt_FieldForcePresentState.Text = TheFieldForce.Address_Present_StateName;
			txt_FieldForcePresentCountry.Text = TheFieldForce.Address_Present_CountryName;
			txt_FieldForcePermanentTownOrCity.Text = TheFieldForce.Address_Permanent_TownOrCity;
			ddl_FieldForcePermanentDistrict.SelectedValue = TheFieldForce.Address_Permanent_DistrictID.ToString();
			txt_FieldForcePermanentState.Text = TheFieldForce.Address_Permanent_StateName;
			txt_FieldForcePermanentCountry.Text = TheFieldForce.Address_Permanent_CountryName;
			txt_FieldForcePhoneNumber.Text = TheFieldForce.PhoneNumber;
			txt_FieldForceMobile.Text = TheFieldForce.Mobile;
			
		}

		private void PopulateGuest(int guestID)
		{
			Guest TheGuest = GuestManagement.GetInstance.GetGuestByID(guestID);

			ddl_GuestSalutation.Text = TheGuest.Salutation;
			txt_GuestName.Text = TheGuest.GuestName;
			ddl_GuestGender.Text = TheGuest.Gender;
			txt_GuestAge.Text = TheGuest.Age.ToString();
			txt_GuestPresentTownOrCity.Text = TheGuest.Address_Present_TownOrCity;
			ddl_GuestPresentDistrict.Text = TheGuest.Address_Present_DistrictID.ToString();
			txt_GuestState.Text = TheGuest.Address_Present_StateName;
			txt_GuestCountry.Text = TheGuest.Address_Present_CountryName;
			txt_GuestPhone.Text = TheGuest.PhoneNumber;
			txt_GuestEmailId.Text = TheGuest.PersonalEMailID;

		}

		private bool ValidateFormFields()
		{

			return true;
		}

		private int UpdateRecord()
		{
			int ProcReturnValue = 0;

			string UserReferenceType = Connection.LoggedOnUser.UserType;
			int UserReferenceID = Connection.LoggedOnUser.UserReferenceID;

			if (UserReferenceType.Equals(MicroEnums.UserType.Employee.GetStringValue()))
                ProcReturnValue = UpdateEmployees(UserReferenceID);
			

			if (UserReferenceType.Equals(MicroEnums.UserType.FieldForce.GetStringValue()))
				UpdateFieldForce(UserReferenceID);
            UpdateFieldForceProfile(UserReferenceID);

			if (UserReferenceType.Equals(MicroEnums.UserType.Guest.GetStringValue()))
              UpdateGuest(UserReferenceID);
			return ProcReturnValue;
		}

		private int UpdateEmployees(int employeeid)
		{
			int ProcReturnValue = 0;

			UserProfileEmployee theEmployee = new UserProfileEmployee();

			theEmployee.EmployeeID = Connection.LoggedOnUser.UserReferenceID;
			
			//theEmployee.EmployeeCode = lbl_EmployeeCode.Text;
            //theEmployee.Salutation = txt_EmployeeSalutation.SelectedValue;
            //theEmployee.EmployeeName = txt_EmployeeName.Text;
            //theEmployee.FatherName = txt_EmployeeFatherName.Text;
            //theEmployee.SpouseName = txt_EmployeeSpouseName.Text;
            //theEmployee.DateOfBirth = DateTime.Parse(txt_EmployeeDateOfBirth.Text);
            //theEmployee.Gender = ddl_EmployeeGender.SelectedValue;
            //theEmployee.BloodGroup = ddl_EmployeeBloodGroup.SelectedValue;
            //theEmployee.Religion = ddl_EmployeeReligion.SelectedValue;
            //theEmployee.Nationality = ddl_EmployeeNationality.SelectedValue;
            //theEmployee.MaritalStatus = ddl_EmployeeMaritalStatus.SelectedValue;
            theEmployee.DateOfBirth = DateTime.Parse(txt_EmployeeDateOfBirth.Text);
            //theEmployee.KnownAilments = txt_EmployeeKnownAliments.Text;
            //theEmployee.IdentificationMark = txt_EmployeeIdentificationMark.Text;
			theEmployee.Address_Present_TownOrCity = txt_EmployeePresentTownOrCity.Text;
			theEmployee.Address_Present_LandMark = txt_EmployeePresentLandMark.Text;
			theEmployee.Address_Present_Pincode = txt_EmployeePresentPinCode.Text;
			theEmployee.Address_Present_DistrictID = int.Parse(ddl_EmployeePresentDistrict.SelectedValue);
            //theEmployee.Address_Permanent_TownOrCity = txt_EmployeePermanentTownOrCity.Text;
            //theEmployee.Address_Permanent_LandMark = txt_EmployeePermanentLandmark.Text;
            //theEmployee.Address_Permanent_Pincode = txt_EmployeePermanentPinCode.Text;
            //theEmployee.Address_Permanent_DistrictID = int.Parse(ddl_EmployeePermanentDistrict.SelectedValue);
			theEmployee.PhoneNumber = txt_EmployeePhoneNumber.Text;
			theEmployee.Mobile = txt_EmployeeMobile.Text;
            //theEmployee.EmailID = txt_EmployeeEmailId.Text;
			theEmployee.PersonalEMailID = txt_EmployeePersonalEmailId.Text;
			theEmployee.EmergencyContactNumber = txt_EmployeeEmergencyContactNumber.Text;
			//TODO Image 
			ProcReturnValue = UserProfileEmployeeManagement.GetInstance.UpdateUserProfileEmployee(theEmployee);

			return ProcReturnValue;
		}


		public int UpdateFieldForce(int fieldForceId)
		{
			int ProcReturnValue = 0;

			UserProfileFieldForce TheFieldForce = new UserProfileFieldForce();
			TheFieldForce.FieldForceID = Connection.LoggedOnUser.UserReferenceID;

			TheFieldForce.Salutation = ddl_FieldForceSalutation.SelectedValue;
			TheFieldForce.FieldForceName = txt_FieldForceName.Text;
			TheFieldForce.FatherName = txt_FieldForceFatherName.Text;
			TheFieldForce.DateOfBirth = DateTime.Parse(txt_fieldForceDateOfBirth.Text);
			TheFieldForce.Gender = ddl_FieldForceGender.SelectedValue;
			TheFieldForce.Religion = ddl_FieldForceReligion.SelectedValue;
			TheFieldForce.Nationality = ddl_FieldForceNationality.SelectedValue;
			TheFieldForce.MaritalStatus = ddl_FieldForceMaritalStatus.SelectedValue;
			TheFieldForce.Address_Present_TownOrCity = txt_FieldForcePresentTownOrCity.Text;
			TheFieldForce.Address_Present_DistrictID = int.Parse(ddl_FieldForcePresentDistrict.SelectedValue);
			TheFieldForce.Address_Permanent_TownOrCity = txt_FieldForcePermanentTownOrCity.Text;
			TheFieldForce.Address_Permanent_DistrictID = int.Parse(ddl_FieldForcePermanentDistrict.SelectedValue);
			TheFieldForce.PhoneNumber = txt_FieldForcePhoneNumber.Text;
			TheFieldForce.Mobile = txt_FieldForceMobile.Text;

			//TODO: Add ProfilePhote & ProfileSignature
			ProcReturnValue = UserProfileFieldForceManagement.GetInstance.UpdateUserProfileFieldForce(TheFieldForce);

			return ProcReturnValue;
		}

		public int UpdateFieldForceProfile(int theFieldForceId)
		{
            byte[] data=null;
			if (lbl_FileName.Text.Trim().Length > 0)
			{
				data = File.ReadAllBytes(lbl_FileName.Text);
			}
			int ProcReturnValue = 0;
			if (data != null)
			{
				UserProfileFieldForceProfile TheFieldForceProfile = new UserProfileFieldForceProfile();
				TheFieldForceProfile.FieldForceID = Connection.LoggedOnUser.UserReferenceID;
				TheFieldForceProfile.SettingKeyValue = ImageFunctions.ByteToImage(data);
				ProcReturnValue = UserProfileFieldForceProfileManagement.GetInstance.UpdateUserProfileFieldForceProfile(TheFieldForceProfile);
			}

			return ProcReturnValue;
		}
       

		public int UpdateGuest(int guestid)
		{
			int ProcReturnValue = 0;
			UserProfileGuest TheGuest = new UserProfileGuest();
			TheGuest.GuestID = Connection.LoggedOnUser.UserReferenceID;
			TheGuest.Salutation = ddl_GuestSalutation.SelectedValue;
			TheGuest.GuestName = txt_GuestName.Text;
			TheGuest.Gender = ddl_GuestGender.SelectedValue;
			TheGuest.Age = int.Parse(txt_GuestAge.Text);
			TheGuest.Address_Present_TownOrCity = txt_GuestPresentTownOrCity.Text;
			TheGuest.Address_Present_DistrictID = int.Parse(ddl_GuestPresentDistrict.SelectedValue);
			TheGuest.PhoneNumber = txt_GuestPhone.Text;
			TheGuest.PersonalEMailID = txt_GuestEmailId.Text;
			
			ProcReturnValue = UserProfileGuestManagement.GetInstance.UpdateUserProfileGuest(TheGuest);

			return ProcReturnValue;

		}

		private void GetViewUserWise()
		{
			string UserReferenceType = Connection.LoggedOnUser.UserType;
			int UserReferenceID = Connection.LoggedOnUser.UserReferenceID;

			if (UserReferenceType.Equals(MicroEnums.UserType.Employee.GetStringValue()))
				multiView_UserProfile.SetActiveView(view_Employee);

			if (UserReferenceType.Equals(MicroEnums.UserType.FieldForce.GetStringValue()))
				multiView_UserProfile.SetActiveView(view_FieldForce);

			if (UserReferenceType.Equals(MicroEnums.UserType.Guest.GetStringValue()))
				multiView_UserProfile.SetActiveView(view_Guest);
		}


        //private void PopulatePageFields()
        //{
        //    PageVariables.TheProfileImage = new ProfileImage();
        //    PageVariables.TheProfileImage.ImageBinaries = PageVariables.ThisEmployeeProfile.SettingKeyValue;
        //    PageVariables.TheProfileImage.ImageUrl = BasePage.GetProfileImageUrl(PageVariables.ThisEmployeeProfile.EmployeeProfilleID.ToString(), PageVariables.ThisEmployeeProfile.SettingKeyName, PageVariables.ThisEmployeeProfile.SettingKeyDescription);
        //    Img_EmployeePhoto.ImageUrl = PageVariables.TheProfileImage.ImageUrl;

        //}

        private void GetUserType()
        {
            string theUser = Connection.LoggedOnUser.UserType;
            lit_UserType.Text = string.Format("User Type({0})", theUser);
            
        }

		#endregion

       
        
	}
}