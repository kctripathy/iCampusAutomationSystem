using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.Framework.ReadXML;
using System.Web;
namespace Micro.WebApplication.MicroERP.HRMS
{
	/// <summary>
	/// view,add,edit & delete Employee.
	/// </summary>
    public partial class Employees : BasePage
    {

        #region Declaration

        protected static class PageVariables
        {
            public static Employee ThisEmployee
            {
                get
                {
                    Employee TheEmployee = HttpContext.Current.Session["ThisEmployee"] as Employee;
                    return TheEmployee;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisEmployee", value);
                }
            }
            
            public static List<Employee> EmployeeList
             {
             get
                {
                    List<Employee> TheEmployee = HttpContext.Current.Session["EmployeeList"] as List<Employee>;
                    return TheEmployee;
                }
                set
                {
                    HttpContext.Current.Session.Add("EmployeeList", value);
                }
             }
          
            public static int TheEmpID;
          
            public static EmployeeProfile ThisEmployeeProfile
            {
                get
                {
                    EmployeeProfile TheEmployeeProfile = HttpContext.Current.Session["ThisEmployeeProfile"] as EmployeeProfile;
                    return TheEmployeeProfile;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisEmployeeProfile", value);
                }
            }
           
            public static ProfileImage TheProfileImage;
           
            public static string EmployeeName;

            public static string SettingKeyName = MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue();
          
            public static string SettingKeyDescription;
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
			BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
			ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
			

            if (!IsPostBack)
            {
                SetValidationMessages();
                BindDropDownList();
                BindDropdown_AppendSelectToFirst(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
				if (HasAddPermission() && IsDefaultModeAdd())
				{
					multiView_EmployeeDetails.SetActiveView(view_InputControls);
					ResetBackColor(view_InputControls);
				}
				else
				{
					BindGrid_Employees();
					multiView_EmployeeDetails.SetActiveView(view_GridView);
                    BasePage.ShowHidePagePermissions(gview_Employee, btn_AddEmployee, this.Page);

				}
                ctrl_Search.SearchWhat = MicroEnums.SearchForm.Employee.GetStringValue();
            }
            
            UploadImage();
        }
		
        protected void ddl_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeMartialStatus(ddl_Salutation, ddl_Gender, ddl_MaritalStatus, txt_SpouceName);
            EnableValidation();
        }

        protected void ddl_MaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeMartialStatus(ddl_Salutation, ddl_Gender, ddl_MaritalStatus, txt_SpouceName);
                EnableValidation();
                ValidateFatherAndHusbandName();
            }
            catch
            {
            }
        }
        protected void ddl_Qualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateQualification(ddl_Qualification, txt_PassingYear, txt_Institution, txt_Board);
                EnableValidation();
            }
            catch
            {
            }
        }
        protected void ddl_Salutation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeSalutation(ddl_Salutation, ddl_Gender, ddl_MaritalStatus, txt_SpouceName);
                EnableValidation();
                ValidateFatherAndHusbandName();
            }
            catch
            {
            }

        }
		
        protected void txt_DOB_TextChanged(object sender, EventArgs e)
		{
            try
            {
                txt_Age.Text = string.Empty;
                if (IsValidDate(txt_DOB.Text))
                {
                    txt_DOB.Text = DateTime.Parse(txt_DOB.Text).ToString(MicroConstants.DateFormat);
                    txt_Age.Text = CalculateAge(DateTime.Parse(txt_DOB.Text)).ToString();
                }
                if (txt_JoinDate.Text != string.Empty)
                {
                    ValidateJoiningDate();
                }
            }
            catch
            {
            }

		}

        protected void txt_Age_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_DOB.Text = CalculateDateOfBirth(txt_Age.Text).ToString(MicroConstants.DateFormat);
            }
            catch
            {
            }

        }

        protected void txt_JoinDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateJoiningDate();
            }
            catch
            {
            }
        }

        protected void chk_CopyPresentAddress_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool CheckState = chk_CopyPresentAddress.Checked;
                EnableDisablePermanentAddress(CheckState);

                if (CheckState)
                {
                    CopyPresentAddress();
                }
            }
            catch
            {
            }
        }

        protected void ddl_PermanentDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                District theDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(ddl_PermanentDistrict.SelectedValue));
                txt_PermanentState.Text = theDistrict.StateName;
                txt_PermanentCountry.Text = theDistrict.CountryName;
            }
            catch
            {
                txt_PermanentState.Text = string.Empty;
                txt_PermanentCountry.Text = string.Empty;
            }
            
        }

        protected void ddl_PresentDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            District theDistrict = DistrictManagement.GetInstance.GetDistrictStateCountryByDistrictId(int.Parse(ddl_PresentDistrict.SelectedValue));
            txt_PresentState.Text = theDistrict.StateName;
            txt_PresentCountry.Text = theDistrict.CountryName;
             }
        catch
            {
                txt_PresentState.Text = string.Empty;
                txt_PresentCountry.Text = string.Empty;
            }
        }

        protected void gview_Employee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gview_Employee.PageIndex = e.NewPageIndex;
                BindGrid_Employees();

                lit_PageCounter.Text = string.Format("Page <b>{0}</b> of {1}", e.NewPageIndex + 1, gview_Employee.PageCount);

            }
            catch
            {
            }
        }

        protected void gview_Employee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //EnableControls(view_InputControls, true);
                //Enabledisablecheckbox(true);
                int RowIndex;
                if (e.CommandArgument.Equals("First"))
                {
                    RowIndex = 0;
                }
                else if (e.CommandArgument.Equals("Last"))
                {
                    RowIndex = gview_Employee.PageCount - 1;
                }
                else
                {
                    RowIndex = Convert.ToInt32(e.CommandArgument);
                }
                //int RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gview_Employee.Rows[RowIndex].FindControl("lbl_EmployeeID")).Text);

                PageVariables.ThisEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(RecordID);
				
                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {

                    lbl_DataOperationMode.Text = String.Format("EDIT Employee : {0} [{1}]", gview_Employee.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
                    btn_Top_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();

                    multiView_EmployeeDetails.SetActiveView(view_InputControls);

                    PopulatePageFields(PageVariables.ThisEmployee);
                    
                    //if (PageVariables.ThisEmployee.LastQualification.Equals(MicroEnums.Qualifications.UnderMatric.GetStringValue()))
                    //{
                    //    Enabledisabletextboxqualification(false);
                    //}
                    bool EnableFlag = true;
                    EnableControls(view_InputControls, EnableFlag);
                    btn_Top_Save.Visible = EnableFlag;
                    Btn_Save.Visible = EnableFlag;


                    btn_Cancel.Visible = EnableFlag;
                    btn_Reset.Visible = EnableFlag;
                    // ChangeBackColor(view_InputControls);
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {
                    lbl_DataOperationMode.Text = String.Format("EDIT Employee : {0} [{1}]", gview_Employee.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

                    multiView_EmployeeDetails.SetActiveView(view_InputControls);
                    PopulatePageFields(PageVariables.ThisEmployee);

                    bool EnableFlag = false;
                    EnableControls(view_InputControls, EnableFlag);

                    Btn_Save.Visible = EnableFlag;
                    btn_Top_Save.Visible = EnableFlag;
                    btn_Cancel.Visible = EnableFlag;
                    btn_Reset.Visible = EnableFlag;
                }

                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee", MicroEnums.DataOperation.Delete);
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        BindGrid_Employees();
                    }

                    dialog_Message.Show();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
        }

        protected void gview_Employee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 7);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);

                    BasePage.GridViewToolTips(e, 6, 7);

                }
            }
            catch
            {
            }
        }

        protected void gview_Employee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch
            {
            }
        }

        protected void gview_Employee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch
            {
            }
        }
        
        protected void searchCtrl_ButtonClicked(object sender, EventArgs e)
        {
                SearchEmployeetBindGridView();
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {

            ResetTextBoxes();
        }

        protected void btn_AddEmployee_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();

            multiView_EmployeeDetails.SetActiveView(view_InputControls);
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {

            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFieldsEmployee())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = SaveEmployeeDetails();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateEmployeeDetails();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee", MicroEnums.DataOperation.Edit);
                }
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    //Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
                    //btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
                    BindGrid_Employees();
                    ResetTextBoxes();
                    

                    ResetBackColor(view_InputControls);
                }
                
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();


        }

        protected void btn_ViewEmployeeDetails_OnClick(object sender, EventArgs e)
        {
            BindGrid_Employees();
            multiView_EmployeeDetails.SetActiveView(view_GridView);
            BasePage.ShowHidePagePermissions(gview_Employee, btn_AddEmployee, this.Page);	
        }

        #endregion

        #region Methods & Implementation

        private void EnableValidation()
        {
            if (ddl_Qualification.SelectedIndex == GetDropDownSelectedIndex(ddl_Qualification, MicroEnums.Qualifications.UnderMatric.GetStringValue()))
            {

                Enabledisabletextboxqualification(false);
            }
           
        }

        private void Enabledisablecheckbox(bool enableState = true)
        {

            chk_CopyPresentAddress.Enabled = enableState;
            chk_CopyPresentAddress.Enabled = enableState;

            //fileUpload_ProfileImage.Enabled = enableState;
            //fileUpload_ProfileSignature.Enabled = enableState;
            ajaxCalender_DOB.Enabled = enableState;

            btn_Top_Save.Visible = enableState;
            Btn_Save.Visible = enableState;
            btn_Cancel.Visible = enableState;

            Button3.Visible = enableState;

        }

        private void HideGridViewColumns()
        {
            BasePage.ShowHidePagePermissions(gview_Employee, btn_AddEmployee, this.Page);
        }
        
        private void SetValidationMessages()
        {
            requiredFieldValidator_Salutation.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Gender.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Designation.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Department.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Office.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ReportingTo.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ServiceType.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Status.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Present_District.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Permanent_District.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_MaritalStatus.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Nationality.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Qualification.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            regularExpressionValidator_EmergenceNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            regularExpressionValidator_EmergenceNumber.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_NUMBER_FIELD");
            regularExpressionValidator_DOB.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_PassingYear.ValidationExpression = MicroConstants.REGEX_NUMBER_GREATERTHANZERO;
            regularExpressionValidator_ReferencePhone.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_BioDeviceEmpid.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_RefLetterNo.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_SpouceName.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_PersonalEmailID.ValidationExpression = MicroConstants.REGEX_EMAILID;
            regularExpressionValidator_PhoneNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_Present_Pincode.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_Permanent_Pincode.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_MobileNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_ReferenceMobile.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_ReferencePhone.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_JoinDate.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_FatherName.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_EmployeeName.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_ReferenceMobile.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_ReferencePhone.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            //rangeValidator_ReferenceMobile.MinimumValue = "1000000000";
            //rangeValidator_ReferenceMobile.MaximumValue = "999999999999";
            //rangeValidator_Mobile.MinimumValue = "1000000000";
            //rangeValidator_Mobile.MaximumValue = "999999999999";
            //rangeValidator_PassingYear.MinimumValue = "1";
            //rangeValidator_PassingYear.MaximumValue = DateTime.Now.Year.ToString();
            //rangeValidator_PassingYear.ErrorMessage = ReadXML.GetGeneralMessage("PASSINGYEAR_CAN_NOT_GREATER_CURRENTYEAR");
            //rangeValidator_ReferenceMobile.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_MOBILE_NUMBER_RANGE");
            //rangeValidator_Mobile.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_MOBILE_NUMBER_RANGE");


            requiredFieldValidator_Salutation.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Salutation");
            requiredFieldValidator_Gender.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Gender");
            requiredFieldValidator_EmployeeName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "EmployeeName");
            requiredFieldValidator_JoinDate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "JoinDate");
            requiredFieldValidator_PresentAddress.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "PresentAddress");
            requiredFieldValidator_FatherName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "FatherName");
            requiredFieldValidator_EmergenceNumber.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "EmergenceNumber");
            requiredFieldValidator_Qualification.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Qualification");
            requiredFieldValidator_ReportingTo.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "ReportingTo");
            requiredFieldValidator_Present_District.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "PresentDistrict");
            requiredFieldValidator_Permanent_District.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "PermanentDistrict");
            requiredFieldValidator_Office.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Office");
            requiredFieldValidator_Nationality.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Nationality");
            requiredFieldValidator_MaritalStatus.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "MaritalStatus");
            requiredFieldValidator_DOB.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "DateOfBirth");
            requiredFieldValidator_Designation.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Designation");
            requiredFieldValidator_Department.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Department");
            //requiredFieldValidator_PassingYear.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "PassingYear");
            requiredFieldValidator_ServiceType.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "ServiceType");
            requiredFieldValidator_Status.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Status");
            requiredFieldValidator_EmployeeCode.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "EmployeeName");
			RequiredFieldValidator_PermanentAddress.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "PermanentAddress");
            //requiredFieldValidator_SpouceName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "SpouceName");
			


            regularExpressionValidator_DOB.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_DOB.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            regularExpressionValidator_EmployeeName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            regularExpressionValidator_FatherName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            regularExpressionValidator_MobileNumber.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_ReferencePhone.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_ReferenceMobile.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_Permanent_Pincode.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PersonalEmailID.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_EMAILID");
            regularExpressionValidator_PhoneNumber.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_Present_Pincode.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
			regularExpressionValidator_SpouceName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            regularExpressionValidator_BioDeviceEmpid.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_RefLetterNo.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_JoinDate.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            //regularExpressionValidator_ReferenceMobile.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            //regularExpressionValidator_ReferencePhone.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PassingYear.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_GREATERTHANZERO");

            requiredFieldValidator_Profile.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Profile.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Profile Type");





            SetFormMessageCSSClass("ValidateMessage");

        }

        private void SetFormMessageCSSClass(string theClassName)
        {

            requiredFieldValidator_Salutation.CssClass = theClassName;
            requiredFieldValidator_EmployeeName.CssClass = theClassName;
            requiredFieldValidator_Gender.CssClass = theClassName;
            requiredFieldValidator_JoinDate.CssClass = theClassName;
            requiredFieldValidator_PresentAddress.CssClass = theClassName;
			RequiredFieldValidator_PermanentAddress.CssClass = theClassName;
            requiredFieldValidator_FatherName.CssClass = theClassName;
            requiredFieldValidator_EmergenceNumber.CssClass = theClassName;
            requiredFieldValidator_Qualification.CssClass = theClassName;
            requiredFieldValidator_ReportingTo.CssClass = theClassName;
            requiredFieldValidator_Present_District.CssClass = theClassName;
            requiredFieldValidator_Permanent_District.CssClass = theClassName;
            requiredFieldValidator_Office.CssClass = theClassName;
            requiredFieldValidator_Nationality.CssClass = theClassName;
            requiredFieldValidator_MaritalStatus.CssClass = theClassName;
            requiredFieldValidator_DOB.CssClass = theClassName;
            requiredFieldValidator_Designation.CssClass = theClassName;
            requiredFieldValidator_Department.CssClass = theClassName;
            regularExpressionValidator_Present_Pincode.CssClass = theClassName;
            regularExpressionValidator_PhoneNumber.CssClass = theClassName;
            regularExpressionValidator_MobileNumber.CssClass = theClassName;
            regularExpressionValidator_EmergenceNumber.CssClass = theClassName;
            
            regularExpressionValidator_ReferenceMobile.CssClass = theClassName;
            regularExpressionValidator_ReferencePhone.CssClass = theClassName;
            //requiredFieldValidator_SpouceName.CssClass = theClassName;
			regularExpressionValidator_SpouceName.CssClass = theClassName;
           
            requiredFieldValidator_ServiceType.CssClass = theClassName;
            requiredFieldValidator_Status.CssClass = theClassName;
            requiredFieldValidator_EmployeeCode.CssClass = theClassName;
        }

        private void Enabledisabletextboxqualification(bool enablestate=true )
        {
            txt_PassingYear.Enabled = enablestate;
            txt_Institution.Enabled = enablestate;
            txt_Board.Enabled = enablestate;
        }

        private void BindDropDownList()
        {
           
            BindDropdown_Salutation();
            BindDropdown_Gender();
            BindDropdown_MaritalStatus();
            BindDropdown_Nationality();
            BindDropdown_Religion();
            BindDropdown_PermanentDistrict();
            BindDropdown_PresentDistrict();
            BindDropdown_Qualification();
            BindDropdown_Designation();
            BindDropdown_Department();
            BindDropdown_Office();
            BindDropdown_ReportingTo();
            BindDropdown_ServiceStatus();
            BindDropdown_ServiceType();
            BindDropdown_BloodGroup();
            BindEmployees();
            BindProfile();
           
        }
       
        private void BindDropdown_AppendSelectToFirst(string  ddlDefaultItem)
        {
            ddl_Salutation.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT_DASH);
            ddl_Gender.Items.Insert(0, ddlDefaultItem);
            ddl_MaritalStatus.Items.Insert(0, ddlDefaultItem);
            ddl_Nationality.Items.Insert(0, ddlDefaultItem);
            ddl_Religion.Items.Insert(0, ddlDefaultItem);
            ddl_PresentDistrict.Items.Insert(0, ddlDefaultItem);
            ddl_PermanentDistrict.Items.Insert(0, ddlDefaultItem);
            ddl_Qualification.Items.Insert(0, ddlDefaultItem);
            ddl_Designation.Items.Insert(0, ddlDefaultItem);
            ddl_Department.Items.Insert(0, ddlDefaultItem);
            ddl_Office.Items.Insert(0, ddlDefaultItem);
            ddl_ReportingTo.Items.Insert(0, ddlDefaultItem);
            ddl_Status.Items.Insert(0, ddlDefaultItem);
            ddl_ServiceType.Items.Insert(0, ddlDefaultItem);
            ddl_BloodGroup.Items.Insert(0, ddlDefaultItem);
        }
        
        private void BindDropdown_Salutation()
        {
            ddl_Salutation.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Salutation.GetStringValue());
            ddl_Salutation.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Salutation.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Salutation.DataBind();
        }

        private void BindDropdown_Gender()
        {
            ddl_Gender.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Gender.GetStringValue());
            ddl_Gender.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Gender.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Gender.DataBind();
        }

        private void BindDropdown_MaritalStatus()
        {
            ddl_MaritalStatus.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.MaritalStatus.GetStringValue());
            ddl_MaritalStatus.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_MaritalStatus.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_MaritalStatus.DataBind();
        }

        private void BindDropdown_Nationality()
        {
            ddl_Nationality.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Nationality.GetStringValue());
            ddl_Nationality.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Nationality.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Nationality.DataBind();
        }

        private void BindDropdown_Religion()
        {
            ddl_Religion.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Religion.GetStringValue());
            ddl_Religion.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Religion.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Religion.DataBind();
        }

        private void BindDropdown_PermanentDistrict()
        {
            ddl_PermanentDistrict.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
            ddl_PermanentDistrict.DataTextField = DistrictManagement.GetInstance.DisplayMember;
            ddl_PermanentDistrict.DataValueField = DistrictManagement.GetInstance.ValueMember;
            ddl_PermanentDistrict.DataBind();
        }

        private void BindDropdown_PresentDistrict()
        {
            ddl_PresentDistrict.DataSource = DistrictManagement.GetInstance.GetAllDistricts();
            ddl_PresentDistrict.DataTextField = DistrictManagement.GetInstance.DisplayMember;
            ddl_PresentDistrict.DataValueField = DistrictManagement.GetInstance.ValueMember;
            ddl_PresentDistrict.DataBind();
        }

        private void BindDropdown_Qualification()
        {
            ddl_Qualification.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.Qualification.GetStringValue());
            ddl_Qualification.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Qualification.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
            ddl_Qualification.DataBind();
        }

        private void BindDropdown_Designation()
        {
            ddl_Designation.DataSource = DesignationManagement.GetInstance.GetDesignationsListByOffice();
            ddl_Designation.DataTextField = DesignationManagement.GetInstance.DisplayMember;
            ddl_Designation.DataValueField = DesignationManagement.GetInstance.ValueMember;
            ddl_Designation.DataBind();

        }

        private void BindDropdown_Department()
        {
            ddl_Department.DataSource = DepartmentManagement.GetInstance.GetDepartmentsListByOffice();
            ddl_Department.DataTextField = DepartmentManagement.GetInstance.DisplayMember;
            ddl_Department.DataValueField = DepartmentManagement.GetInstance.ValueMember;
            ddl_Department.DataBind();
        }

        private void BindDropdown_Office()
        {
            ddl_Office.DataSource = OfficeManagement.GetInstance.GetOfficeListByReportingOfficeIDs();
            ddl_Office.DataTextField = OfficeManagement.GetInstance.DisplayMember;
            ddl_Office.DataValueField = OfficeManagement.GetInstance.ValueMember;
            ddl_Office.DataBind();
           

        }

        private void BindDropdown_ReportingTo()
        {
            ddl_ReportingTo.DataSource = EmployeeManagement.GetInstance.GetCompanyEmployeeList();
            ddl_ReportingTo.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
            ddl_ReportingTo.DataValueField = EmployeeManagement.GetInstance.ValueMember;
            ddl_ReportingTo.DataBind();
        }

        private void BindDropdown_ServiceStatus()
        {
            
            ddl_Status.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.ServiceStatus.GetStringValue());
            ddl_Status.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Status.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Status.DataBind();

        }

        private void BindDropdown_ServiceType()
        {
            ddl_ServiceType.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.ServiceType.GetStringValue());
            ddl_ServiceType.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_ServiceType.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_ServiceType.DataBind();
        }

        private void BindDropdown_BloodGroup()
        {
            ddl_BloodGroup.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.BloodGroup.GetStringValue());
            ddl_BloodGroup.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_BloodGroup.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_BloodGroup.DataBind();
        }

        private void BindGrid_Employees()
        {

            if ((((User)Session["CurrentUser"]).RoleDescription.Equals("CHAIRMAN")))
            {
                if ((((User)Session["CurrentUser"]).OfficeID.Equals(CurrentLoggedOnUser.TheOffice.OfficeID)))
                    PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
            }
            else if ((((User)Session["CurrentUser"]).RoleDescription.Equals("MANAGING DIRECTOR")))
            {
                if ((((User)Session["CurrentUser"]).OfficeID.Equals(CurrentLoggedOnUser.TheOffice.OfficeID)))
                    PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
            }
            else if ((((User)Session["CurrentUser"]).RoleDescription.Equals("DIRECTOR")))
            {
                if ((((User)Session["CurrentUser"]).OfficeID.Equals(CurrentLoggedOnUser.TheOffice.OfficeID)))
                    PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
            }
            else if ((((User)Session["CurrentUser"]).RoleDescription.Equals("CHIEF EXECUTIVE OFFICER")))
            {
                if ((((User)Session["CurrentUser"]).OfficeID.Equals(CurrentLoggedOnUser.TheOffice.OfficeID)))
                    PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
            }
            else if ((((User)Session["CurrentUser"]).RoleDescription.Equals("GENERAL MANAGER")))
            {
                if ((((User)Session["CurrentUser"]).OfficeID.Equals(CurrentLoggedOnUser.TheOffice.OfficeID)))
                    PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
            }
            else if ((((User)Session["CurrentUser"]).RoleDescription.Equals("HR MANAGER")))
            {
                if ((((User)Session["CurrentUser"]).OfficeID.Equals(CurrentLoggedOnUser.TheOffice.OfficeID)))
                    PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
            }
            else if ((((User)Session["CurrentUser"]).RoleDescription.Equals(" Super Admin")))
            {
                PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetEmployeeList();
            }
           
            else  if ((((User)Session["CurrentUser"]).RoleDescription.Equals("Administrator")))
            {
                PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetEmployeeList();
            }
            else if ((((User)Session["CurrentUser"]).RoleDescription.Equals("MANAGER")))
            {
                int OfficeID = ((User)Session["CurrentUser"]).OfficeID;
                PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetEmployeesListByOfficeID();
            }
            else
            {
                int OfficeID = ((User)Session["CurrentUser"]).OfficeID;
                PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
            }

            //int CompanyID = ((User)Session["CurrentUser"]).CompanyID;
            //PageVariable.TheEmployeeList = EmployeeManagement.GetInstance.GetEmployeeListByCompany(CompanyID);
            gview_Employee.DataSource = PageVariables.EmployeeList;
            gview_Employee.DataBind();

            if (!(Connection.LoggedOnUser.CanAccessAllOffices))
            {
                BasePage.HideGridViewColumn(gview_Employee, "Office");
            }
        }

        private void SearchEmployeetBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<Employee> SearchList = new List<Employee>();
            // Search by name
            if (PageVariables.EmployeeList.Count > 0)
            {
                if (searchField == MicroEnums.SearchEmployee.EmployeeName.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from empName in PageVariables.EmployeeList
                                      where empName.EmployeeName.ToUpper().StartsWith(searchText.ToUpper())
                                      select empName).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from empName in PageVariables.EmployeeList
                                      where empName.EmployeeName.ToUpper().Contains(searchText.ToUpper())
                                      select empName).ToList();
                    }
                }
                // Search by code
                if (searchField == MicroEnums.SearchEmployee.EmployeeCode.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from empCode in PageVariables.EmployeeList
                                      where empCode.EmployeeCode.ToUpper().StartsWith(searchText.ToUpper())
                                      select empCode).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from empCode in PageVariables.EmployeeList
                                      where empCode.EmployeeCode.ToUpper().Contains(searchText.ToUpper())
                                      select empCode).ToList();
                    }
                }

            }
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();
            gview_Employee.DataSource = SearchList;
            gview_Employee.DataBind();
        }

        private void BindSearchFields()
        {
            foreach (MicroEnums.SearchEmployee x in Enum.GetValues(typeof(MicroEnums.SearchEmployee)))
            {
                string xyz = x.ToString();
            }
        }

        private void CopyPresentAddress()
        {
            txt_PermanentAddress.Text = txt_PresentAddress.Text;
            txt_PermanentLandMark.Text = txt_PresentLandMark.Text;
            txt_PermanentPincode.Text = txt_PresentPincode.Text;
            ddl_PermanentDistrict.Text = ddl_PresentDistrict.Text;
            txt_PermanentState.Text = txt_PresentState.Text;
            txt_PermanentCountry.Text = txt_PresentCountry.Text;
        }

        private void EnableDisablePermanentAddress(bool enableState)
        {
            txt_PermanentAddress.ReadOnly = enableState;
            txt_PermanentLandMark.ReadOnly = enableState;
            txt_PermanentPincode.ReadOnly = enableState;
            ddl_PermanentDistrict.Enabled = !enableState;
        }
       

        private void PopulatePageFields(Employee theEmployee)
        {
            ddl_Salutation.SelectedIndex = GetDropDownSelectedIndex(ddl_Salutation, theEmployee.Salutation);
            txt_EmployeeName.Text = theEmployee.EmployeeName;
            txt_FathersName.Text = theEmployee.FatherName;
            txt_SpouceName.Text = theEmployee.SpouseName;
            ddl_Gender.SelectedIndex = GetDropDownSelectedIndex(ddl_Gender, theEmployee.Gender);
            ddl_MaritalStatus.SelectedIndex = GetDropDownSelectedIndex(ddl_MaritalStatus, theEmployee.MaritalStatus);
           
           
            txt_DOB.Text = theEmployee.DateOfBirth;
            ddl_Nationality.SelectedIndex = GetDropDownSelectedIndex(ddl_Nationality, theEmployee.Nationality);
            ddl_Religion.SelectedIndex = GetDropDownSelectedIndex(ddl_Religion, theEmployee.Religion);
            ddl_BloodGroup.SelectedIndex = GetDropDownSelectedIndex(ddl_BloodGroup, theEmployee.BloodGroup);
            txt_KnownAilment.Text = theEmployee.KnownAilments;
            txt_IdentificationMark.Text = theEmployee.IdentificationMark;
            txt_PresentAddress.Text = theEmployee.Address_Present_TownOrCity;
            txt_PresentLandMark.Text = theEmployee.Address_Present_LandMark;
            txt_PresentPincode.Text = theEmployee.Address_Present_Pincode;
            ddl_PresentDistrict.SelectedIndex = GetDropDownSelectedIndex(ddl_PresentDistrict, Convert.ToString(theEmployee.Address_Present_DistrictID));
            txt_PresentState.Text = theEmployee.Address_Present_StateName;
            txt_PresentCountry.Text = theEmployee.Address_Present_CountryName;
            txt_PermanentAddress.Text = theEmployee.Address_Permanent_TownOrCity;
            txt_PermanentLandMark.Text = theEmployee.Address_Permanent_LandMark;
            txt_PermanentPincode.Text = theEmployee.Address_Permanent_Pincode;
            ddl_PermanentDistrict.SelectedIndex = GetDropDownSelectedIndex(ddl_PermanentDistrict,Convert.ToString(theEmployee.Address_Permanent_DistrictID));
            txt_PermanentState.Text = theEmployee.Address_Permanent_StateName;
            txt_PermanentCountry.Text = theEmployee.Address_Permanent_CountryName;
            txt_PhoneNumber.Text = theEmployee.PhoneNumber;
            txt_Mobile.Text = theEmployee.Mobile;
            txt_EmergencyNo.Text = theEmployee.EmergencyContactNumber;
            txt_PersonalEmailID.Text = theEmployee.PersonalEMailID;
            txt_OfficialEmailID.Text = theEmployee.EmailID;
            txt_ReferenceName.Text = theEmployee.ReferenceName;
            txt_ReferencePhone.Text = theEmployee.ReferencePhone;
            txt_ReferenceMobile.Text = theEmployee.ReferenceMobile;
            ddl_Qualification.SelectedIndex = GetDropDownSelectedIndex(ddl_Qualification, theEmployee.LastQualification);
            //if (ddl_Qualification.Text.Equals(MicroEnums.Qualifications.UnderMatric.GetStringValue()))
            //{
            //    Enabledisabletextboxqualification(false);
            //}
            txt_PassingYear.Text = theEmployee.YearOfPassing.ToString();
            txt_Institution.Text = theEmployee.Institution;
            txt_Board.Text = theEmployee.BoardOrUniversity;
            txt_Certificate.Text = theEmployee.ProfessionalQualification;
            txt_ProfessionalInstitution.Text = theEmployee.ProfessionalInstitution;
            txt_EmpCode.Text = theEmployee.EmployeeCode;
            ddl_Designation.SelectedIndex = GetDropDownSelectedIndex(ddl_Designation, Convert.ToString(theEmployee.DesignationID));
            ddl_Department.SelectedIndex = GetDropDownSelectedIndex(ddl_Department,Convert.ToString( theEmployee.DepartmentID));
            ddl_Office.SelectedIndex = GetDropDownSelectedIndex(ddl_Office, Convert.ToString(theEmployee.OfficeID));
            txt_BioDeviceEmpid.Text = theEmployee.BioDeviceEmployeeID;
            txt_JoinDate.Text = theEmployee.PostingDate.ToString(MicroConstants.DateFormat);
            ddl_ReportingTo.SelectedIndex = GetDropDownSelectedIndex(ddl_ReportingTo, Convert.ToString(theEmployee.ReportingToEmployeeID));
            txt_RefLetterNo.Text = theEmployee.ReferenceLetterNumber;
            ddl_ServiceType.SelectedIndex = GetDropDownSelectedIndex(ddl_ServiceType, theEmployee.ServiceType);
            ddl_Status.SelectedIndex = GetDropDownSelectedIndex(ddl_Status, theEmployee.ServiceStatus);
        }

        private bool ValidateFormFieldsEmployee()
        {
            bool ReturnValue = true;


            ReturnValue = ValidateFatherAndHusbandName();

            if (ReturnValue)

                ReturnValue = ValidateDuplicateEmployee();

            return ReturnValue;
        }

        private bool ValidateDuplicateEmployee()
        {
            bool ReturnValue = true;

            string EmployeeName = txt_EmployeeName.Text;
            string FatherName = txt_FathersName.Text;
            string DateOfBirth = txt_DOB.Text;
            List<Employee> TheEmployeeList = EmployeeManagement.GetInstance.GetDuplicateEmployeeList(EmployeeName, FatherName, DateOfBirth);

            if (PageVariables.ThisEmployee != null)
            {
                Employee TheEmployee = PageVariables.ThisEmployee;

                if (TheEmployee.EmployeeName.ToUpper().Equals(EmployeeName.ToUpper()) && TheEmployee.FatherName.ToUpper().Equals(FatherName.ToUpper()) && TheEmployee.DateOfBirth.ToUpper().Equals(DateOfBirth.ToUpper()))
                    TheEmployeeList.Remove(TheEmployee);
            }

            if (TheEmployeeList.Count > 0)
            {
                ReturnValue = false;
                lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_EMPLOYEE_DUPLICATE");
            }

            return ReturnValue;
        }

        private bool ValidateFatherAndHusbandName()
        {
            bool ReturnValue = true;

            requiredFieldValidator_FatherName.Enabled = true;
            //requiredFieldValidator_SpouceName.Enabled = false;

            string TheGender = ddl_Gender.SelectedItem.Text;
            string TheSalutation = ddl_Salutation.SelectedItem.Text;
            string TheMaritalStatus = ddl_MaritalStatus.SelectedItem.Text;

            if (!TheSalutation.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT) && !TheMaritalStatus.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
            {
                if (TheMaritalStatus.Equals(MicroEnums.MaritalStatus.Married.GetStringValue()) && TheGender.Equals(MicroEnums.Gender.Female.GetStringValue()))
                {
                    if (!string.IsNullOrEmpty(txt_SpouceName.Text))
                        ReturnValue = true;
                    else
                    {
                        //requiredFieldValidator_SpouceName.Enabled = true;
                        //requiredFieldValidator_SpouceName.Validate();
                        lbl_TheMessage.Text = string.Empty;
                        ReturnValue = false;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txt_FathersName.Text))
                        ReturnValue = true;
                    else
                    {
                        requiredFieldValidator_FatherName.Enabled = true;
                        requiredFieldValidator_FatherName.Validate();
                        lbl_TheMessage.Text = string.Empty;
                        ReturnValue = false;
                    }
                }
            }

            return ReturnValue;
        }

        private int SaveEmployeeDetails()
        {
            int ProcReturnValue = 0;

            Employee TheEmployees = new Employee();

            TheEmployees.Salutation = ddl_Salutation.Text;
            TheEmployees.EmployeeName = ToProper(txt_EmployeeName.Text);
            TheEmployees.FatherName = ToProper(txt_FathersName.Text);
            TheEmployees.SpouseName = txt_SpouceName.Text;
            TheEmployees.Gender = ddl_Gender.Text;
            TheEmployees.MaritalStatus = ddl_MaritalStatus.Text;
            TheEmployees.DateOfBirth =txt_DOB.Text;
            TheEmployees.Nationality = ddl_Nationality.Text;
            TheEmployees.Religion = ddl_Religion.Text;
            TheEmployees.BloodGroup = ddl_BloodGroup.Text;
            TheEmployees.KnownAilments = txt_KnownAilment.Text;
            TheEmployees.IdentificationMark = txt_IdentificationMark.Text;
            TheEmployees.Address_Present_TownOrCity = txt_PresentAddress.Text;
            TheEmployees.Address_Present_LandMark = txt_PresentLandMark.Text;
            TheEmployees.Address_Present_Pincode = txt_PresentPincode.Text;
            TheEmployees.Address_Present_DistrictID = int.Parse(ddl_PresentDistrict.SelectedValue);
            TheEmployees.Address_Permanent_TownOrCity = txt_PermanentAddress.Text;
            TheEmployees.Address_Permanent_LandMark = txt_PermanentLandMark.Text;
            TheEmployees.Address_Permanent_Pincode = txt_PermanentPincode.Text;
            TheEmployees.Address_Permanent_DistrictID = int.Parse(ddl_PermanentDistrict.SelectedValue);
            TheEmployees.PhoneNumber = txt_PhoneNumber.Text;
            TheEmployees.Mobile = txt_Mobile.Text;
            TheEmployees.EmergencyContactNumber = txt_EmergencyNo.Text;
            TheEmployees.EmailID = txt_OfficialEmailID.Text;
            TheEmployees.PersonalEMailID = txt_PersonalEmailID.Text;
            TheEmployees.ReferenceName = txt_ReferenceName.Text;
            TheEmployees.ReferencePhone = txt_ReferencePhone.Text;
            TheEmployees.ReferenceMobile = txt_ReferenceMobile.Text;
            TheEmployees.LastQualification = ddl_Qualification.SelectedValue;
            if (txt_PassingYear.Text == "")
            {
                TheEmployees.YearOfPassing = 0;
            }
            else
            {
                TheEmployees.YearOfPassing = int.Parse(txt_PassingYear.Text);
            }
            //TheEmployees.YearOfPassing = int.Parse(txt_PassingYear.Text);
            TheEmployees.Institution = txt_Institution.Text;
            TheEmployees.BoardOrUniversity = txt_Board.Text;
            TheEmployees.ProfessionalQualification = txt_Certificate.Text;
            TheEmployees.ProfessionalInstitution = txt_ProfessionalInstitution.Text;
            TheEmployees.EmployeeCode = txt_EmpCode.Text;
            TheEmployees.PostingDate = DateTime.Parse(txt_JoinDate.Text);
            TheEmployees.ReportingToEffectiveDateFrom = DateTime.Today;
            TheEmployees.DesignationID = int.Parse(ddl_Designation.SelectedValue);
            TheEmployees.DepartmentID = int.Parse(ddl_Department.SelectedValue);
            TheEmployees.OfficeID = int.Parse(ddl_Office.SelectedValue);
            TheEmployees.BioDeviceEmployeeID = txt_BioDeviceEmpid.Text;
            TheEmployees.ServiceStatus = ddl_Status.SelectedValue;
            TheEmployees.ServiceType = ddl_ServiceType.SelectedValue;
            TheEmployees.ReferenceLetterNumber = txt_RefLetterNo.Text;
            TheEmployees.ReportingToEmployeeID = int.Parse(ddl_ReportingTo.Text);


            ProcReturnValue = EmployeeManagement.GetInstance.InsertEmployee(TheEmployees);
            return ProcReturnValue;

        }

        private void ResetTextBoxes()
        {
            ddl_Designation.SelectedIndex = 0;
            ddl_Department.SelectedIndex = 0;
            ddl_ReportingTo.SelectedIndex = 0;
            ddl_Office.SelectedIndex = 0;
            ddl_ServiceType.SelectedIndex = 0;
            ddl_Salutation.SelectedIndex = 0;
            ddl_Gender.SelectedIndex = 0;
            ddl_MaritalStatus.SelectedIndex = 0;
            //ddl_Occuption.SelectedIndex = 0;
            ddl_PresentDistrict.SelectedIndex = 0;
            ddl_PermanentDistrict.SelectedIndex = 0;
            // ddl_Caste.SelectedIndex = 0;
            ddl_Nationality.SelectedIndex = 0;
            ddl_Qualification.SelectedIndex = 0;
            ddl_Religion.SelectedIndex = 0;
            ddl_Status.SelectedIndex = 0;
            ddl_BloodGroup.SelectedIndex = 0;
            txt_BioDeviceEmpid.Text = string.Empty;
            txt_EmployeeName.Text = string.Empty;
            txt_FathersName.Text = string.Empty;
            txt_SpouceName.Text = string.Empty;
            txt_DOB.Text = string.Empty;
            txt_Age.Text = string.Empty;
            txt_PresentAddress.Text = string.Empty;
            txt_PresentLandMark.Text = string.Empty;
            txt_PresentPincode.Text = string.Empty;
            txt_PresentState.Text = string.Empty;
            txt_PresentCountry.Text = string.Empty;
            chk_CopyPresentAddress.Checked = false;
            txt_PermanentAddress.Text = string.Empty;
            txt_PermanentLandMark.Text = string.Empty;
            txt_PermanentPincode.Text = string.Empty;
            txt_PermanentState.Text = string.Empty;
            txt_PermanentCountry.Text = string.Empty;

            txt_PhoneNumber.Text = string.Empty;
            txt_Mobile.Text = string.Empty;
            txt_PersonalEmailID.Text = string.Empty;
            txt_OfficialEmailID.Text = string.Empty;
            txt_EmergencyNo.Text = string.Empty;
            txt_EmpCode.Text = string.Empty;
            txt_IdentificationMark.Text = string.Empty;
            txt_Institution.Text = string.Empty;
            txt_JoinDate.Text = string.Empty;
            txt_KnownAilment.Text = string.Empty;
            txt_Notice.Text = string.Empty;
            txt_ProfessionalInstitution.Text = string.Empty;
            txt_Reference.Text = string.Empty;
            txt_ReferenceMobile.Text = string.Empty;
            txt_ReferenceName.Text = string.Empty;
            txt_ReferencePhone.Text = string.Empty;
            txt_RefLetterNo.Text = string.Empty;
            txt_SpouceName.Text = string.Empty;
            txt_PassingYear.Text = string.Empty;

            txt_Board.Text = string.Empty;
            txt_Certificate.Text = string.Empty;

            //lbl_FatherNameValidation.Text = string.Empty;
            //lbl_HusbandValidation.Text = string.Empty;

            requiredFieldValidator_FatherName.Enabled = false;
            //requiredFieldValidator_SpouceName.Enabled = false;
            
            PageVariables.ThisEmployee = null;
            lbl_DataOperationMode.Text = "ADD NEW Employee";
            Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();

            //if (!(BasePage.HasAddPermission(this.Page)))
            //{
            //    multiView_EmployeeDetails.SetActiveView(view_GridView);
            //}
        }

        private static void ResetPageVariables()
        {
            PageVariables.ThisEmployee = null;
            PageVariables.EmployeeList = null;
        }

        private int UpdateEmployeeDetails()
        {
            PageVariables.ThisEmployee.Salutation = ddl_Salutation.Text;
            PageVariables.ThisEmployee.EmployeeName = txt_EmployeeName.Text;
            PageVariables.ThisEmployee.FatherName = txt_FathersName.Text;
            PageVariables.ThisEmployee.SpouseName = txt_SpouceName.Text;
            PageVariables.ThisEmployee.Gender = ddl_Gender.Text;
            PageVariables.ThisEmployee.MaritalStatus = ddl_MaritalStatus.SelectedValue;
            PageVariables.ThisEmployee.DateOfBirth = txt_DOB.Text;
            PageVariables.ThisEmployee.Nationality = ddl_Nationality.Text;
            PageVariables.ThisEmployee.Religion = ddl_Religion.Text;
            PageVariables.ThisEmployee.BloodGroup = ddl_BloodGroup.Text;
            PageVariables.ThisEmployee.KnownAilments = txt_KnownAilment.Text;
            PageVariables.ThisEmployee.IdentificationMark = txt_IdentificationMark.Text;
            PageVariables.ThisEmployee.Address_Present_TownOrCity = txt_PresentAddress.Text;
            PageVariables.ThisEmployee.Address_Present_LandMark = txt_PresentLandMark.Text;
            PageVariables.ThisEmployee.Address_Present_Pincode = txt_PresentPincode.Text;
            PageVariables.ThisEmployee.Address_Present_DistrictID = int.Parse(ddl_PresentDistrict.SelectedValue);
            PageVariables.ThisEmployee.Address_Permanent_TownOrCity = txt_PermanentAddress.Text;
            PageVariables.ThisEmployee.Address_Permanent_LandMark = txt_PermanentLandMark.Text;
            PageVariables.ThisEmployee.Address_Permanent_Pincode = txt_PermanentPincode.Text;
            PageVariables.ThisEmployee.Address_Permanent_DistrictID = int.Parse(ddl_PermanentDistrict.SelectedValue);
            PageVariables.ThisEmployee.PhoneNumber = txt_PhoneNumber.Text;
            PageVariables.ThisEmployee.Mobile = txt_Mobile.Text;
            PageVariables.ThisEmployee.EmergencyContactNumber = txt_EmergencyNo.Text;
            PageVariables.ThisEmployee.EmailID = txt_OfficialEmailID.Text;
            PageVariables.ThisEmployee.PersonalEMailID = txt_PersonalEmailID.Text;
            PageVariables.ThisEmployee.ReferenceName = txt_ReferenceName.Text;
            PageVariables.ThisEmployee.ReferencePhone = txt_ReferencePhone.Text;
            PageVariables.ThisEmployee.ReferenceMobile = txt_ReferenceMobile.Text;
            PageVariables.ThisEmployee.LastQualification = ddl_Qualification.Text;
            if (!string.IsNullOrEmpty(txt_PassingYear.Text))
            {
                PageVariables.ThisEmployee.YearOfPassing = int.Parse(txt_PassingYear.Text.ToString());
            }
            PageVariables.ThisEmployee.Institution = txt_Institution.Text;
            PageVariables.ThisEmployee.BoardOrUniversity = txt_Board.Text;
            PageVariables.ThisEmployee.ProfessionalQualification = txt_Certificate.Text;
            PageVariables.ThisEmployee.ProfessionalInstitution = txt_ProfessionalInstitution.Text;
            PageVariables.ThisEmployee.EmployeeCode = txt_EmpCode.Text;
            PageVariables.ThisEmployee.DesignationID = int.Parse(ddl_Designation.SelectedValue);
            PageVariables.ThisEmployee.DepartmentID = int.Parse(ddl_Department.SelectedValue);
            PageVariables.ThisEmployee.OfficeID = int.Parse(ddl_Office.SelectedValue);
            PageVariables.ThisEmployee.ReportingToEmployeeID = int.Parse(ddl_ReportingTo.SelectedValue);
            PageVariables.ThisEmployee.ReportingToEffectiveDateFrom = DateTime.Today;
            PageVariables.ThisEmployee.BioDeviceEmployeeID = txt_BioDeviceEmpid.Text;
            PageVariables.ThisEmployee.PostingDate = DateTime.Parse(txt_JoinDate.Text);
            PageVariables.ThisEmployee.ServiceStatus = ddl_Status.SelectedValue;
            PageVariables.ThisEmployee.ServiceType = ddl_ServiceType.SelectedValue;
            PageVariables.ThisEmployee.ReferenceLetterNumber = txt_RefLetterNo.Text;


           int ProcReturnValue = EmployeeManagement.GetInstance.UpdateEmployee(PageVariables.ThisEmployee);
            return ProcReturnValue;

        }

        public static int DeleteRecord()
        {
            int ProcReturnValue = EmployeeManagement.GetInstance.DeleteEmployee(PageVariables.ThisEmployee);

            return ProcReturnValue;
        }

        private bool ValidateJoiningDate()
        {
            bool RetValue = true;
            if (txt_DOB.Text == string.Empty)
            {
                RetValue = false;
            }

            else
            {
                if (DateTime.Parse(txt_DOB.Text) > DateTime.Parse(txt_JoinDate.Text))
                {
                    RetValue = false;
                    dialog_Message.Show();
                    lbl_TheMessage.Text = "Joining Date Can't be Smaller than DOB!!";
                    txt_JoinDate.Text = string.Empty;
                    txt_JoinDate.Focus();
                }
            }

            return RetValue;
        }

		private void ValidateQualification(DropDownList ddlQualification, TextBox txtPassingYear, TextBox txtInstitution, TextBox txtBoardOrUniversity)
		{
            if (ddl_Qualification.SelectedItem.Text.Equals(MicroEnums.Qualifications.UnderMatric.GetStringValue()))
            {
                Enabledisabletextboxqualification(false);
            }
            else
            {
                Enabledisabletextboxqualification(true);
            }
		}

        #region EmployeeProfile

        #region Events

        protected void btn_AddEmployeeProfile_Click(object sender, EventArgs e)
        {
            ResetProfilePageFields();
            multiView_EmployeeDetails.SetActiveView(view_Profile);
        }

        protected void btn_EmpProfileView_Click(object sender, EventArgs e)
        {


            if (!ddl_EmployeeCode.SelectedValue.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
            {

                PageVariables.TheEmpID = ddl_EmployeeCode.SelectedRecordID;
                PageVariables.EmployeeName = ddl_EmployeeCode.SelectedValue;

                lbl_GridView_AboutSelectedProfile.Text = "You are viewing profile of " + PageVariables.EmployeeName;
                multiView_EmployeeDetails.SetActiveView(view_GriviewProfile);
                BindProfileGridView();
            }
            else
            {
                dialog_Message.Show();
                lbl_TheMessage.Text = ReadXML.GetFailureMessage("EMPLOYEE_NOT_SELECTED");

            }

        }

        protected void btn_EmpProfileSave_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFields())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = SaveEmployeeProfile();
                    dialog_Message.Show();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Profile", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateEmployeeProfile();
                    dialog_Message.Show();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Profile", MicroEnums.DataOperation.Edit);
                }
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    MoveImageFile(PageVariables.TheProfileImage.ImageUrl);
                    ResetProfilePageFields();
                }
                else
                {
                    RemoveImageFile(PageVariables.TheProfileImage.ImageUrl);
                }
            }
            else
            {
                lbl_TheMessage.Text = ReadXML.GetGeneralMessage("KO_IMAGE_NOT_SELECTED");
                img_ProfileImage.ImageUrl = string.Empty;

                if (PageVariables.TheProfileImage != null)
                    RemoveImageFile(PageVariables.TheProfileImage.ImageUrl);
            }

            dialog_Message.Show();
            EnableDisbleProfiles();
            PageVariables.TheProfileImage = null;
            img_ProfileImage.ImageUrl = string.Empty;
        }

        private bool ValidateFormFields()
        {
            bool ReturnValue;

            if (PageVariables.TheProfileImage == null)
                ReturnValue = false;
            else
                ReturnValue = true;

            if (ReturnValue)
                if (PageVariables.TheProfileImage.ImageBinaries == null)
                    ReturnValue = false;

            if (ReturnValue)
                if (string.IsNullOrEmpty(PageVariables.TheProfileImage.ImageUrl))
                    ReturnValue = false;

            return ReturnValue;
        }

        protected void btn_EmpProfileReset_Click(object sender, EventArgs e)
        {
            ResetProfilePageFields();
            ResetBackColor(view_Profile);
        }

        protected void gview_EmployeeProfiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Page")
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                int EmpProfileId = int.Parse(((Label)gview_EmployeeProfiles.Rows[RowIndex].FindControl("lbl_EmployeeProfileID")).Text);
                PageVariables.ThisEmployeeProfile = EmployeeProfileManagement.GetInstance.GetEmployeeProfileByID(EmpProfileId);
            }
            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                multiView_EmployeeDetails.SetActiveView(view_Profile);
                ChangeBackColor(view_Profile);
                PopulateEmployeeProfileFields(PageVariables.ThisEmployeeProfile);
                btn_EmpProfileSave.Text = String.Format(" {0} ", MicroEnums.DataOperation.Update.GetStringValue());
                btn_EmpProfileBottomSave.Text = String.Format(" {0} ", MicroEnums.DataOperation.Update.GetStringValue());

            }

            else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
            {
                int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                ProcReturnValue = DeleteEmployeeProfile();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Profile", MicroEnums.DataOperation.Delete);

                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    if (PageVariables.TheProfileImage == null)
                        PageVariables.TheProfileImage = new ProfileImage();

                    PageVariables.TheProfileImage.ImageUrl = GetProfileImageUrl(PageVariables.ThisEmployeeProfile.EmployeeID.ToString(), PageVariables.ThisEmployeeProfile.SettingKeyName, PageVariables.ThisEmployeeProfile.CommonKeyValue);
                    RemoveImageFile(PageVariables.TheProfileImage.ImageUrl);
                    PageVariables.TheProfileImage = null;
                    BindProfileGridView();
                }
                dialog_Message.Show();
            }
        }

        protected void gview_EmployeeProfiles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void btn_EmpProfileBottomReset_Click(object sender, EventArgs e)
        {
            ResetProfilePageFields();
            ResetBackColor(view_Profile);
            EnableDisbleProfiles(true);
        }

        protected void gview_EmployeeProfiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_EmployeeProfiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridViewOnDelete(e, 7);
                    GridViewOnClientMouseOver(e);
                    GridViewOnClientMouseOut(e);
                    GridViewToolTips(e, 6, 7);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void gview_EmployeeProfiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Employee.PageIndex = e.NewPageIndex;
            BindProfileGridView();
        }

        //
        #endregion

        #region Methods & Implemenation

       

        private void BindEmployees(List<Employee> employeeList = null)
        {
            PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetEmployeesListByOfficeID();
            employeeList = PageVariables.EmployeeList;
            ddl_EmployeeCode.BindEmployeeList(employeeList);

        }

        private void BindProfile()
        {
            ddl_Profile.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue());
            ddl_Profile.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Profile.DataValueField = CommonKeyManagement.GetInstance.ValueMember;
            ddl_Profile.DataBind();
            ddl_Profile.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void UploadImage()
        {
            if (ValidateEmployeeProfile())
            {

                PageVariables.TheEmpID = ddl_EmployeeCode.SelectedRecordID;
                PageVariables.EmployeeName = ddl_EmployeeCode.SelectedValue;



                PageVariables.SettingKeyDescription = ddl_Profile.SelectedItem.Text;

                string ImageUrl = SetProfileImageUrl(PageVariables.TheEmpID.ToString(), PageVariables.SettingKeyName, PageVariables.SettingKeyDescription, fileUpload_ProfileImage);
                PageVariables.TheProfileImage = UploadImage(PageVariables.TheProfileImage, fileUpload_ProfileImage, img_ProfileImage, ImageUrl);
                EnableDisbleProfiles(false);
            }
        }

        private bool ValidateEmployeeProfile()
        {
            bool ReturnValue;

            if (ddl_EmployeeCode.SelectedValue.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
                ReturnValue = false;
            else
                ReturnValue = true;

            if (ReturnValue)
                if (ddl_Profile.SelectedItem.Text.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
                    ReturnValue = false;

            if (ReturnValue)
                if (PageVariables.SettingKeyName == null)
                    ReturnValue = false;

            if (ReturnValue)
                if (string.IsNullOrEmpty(PageVariables.SettingKeyName))
                    ReturnValue = false;

            return ReturnValue;
        }

        private int SaveEmployeeProfile()
        {
            int ProcReturnValue = 0;

            EmployeeProfile TheEmployeeProfile = new EmployeeProfile();

            TheEmployeeProfile.EmployeeID = int.Parse(ddl_EmployeeCode.SelectedValue);
            TheEmployeeProfile.SettingKeyDescription = PageVariables.SettingKeyDescription;
            TheEmployeeProfile.SettingKeyName = MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue();
            TheEmployeeProfile.SettingKeyID = int.Parse(ddl_Profile.SelectedValue);
            TheEmployeeProfile.SettingKeyReference = txt_Reference.Text;
            TheEmployeeProfile.SettingKeyValue = PageVariables.TheProfileImage.ImageBinaries;

            ProcReturnValue = EmployeeProfileManagement.GetInstance.InsertEmployeeProfile(TheEmployeeProfile);
            return ProcReturnValue;
        }

        private void PopulateEmployeeProfileFields(EmployeeProfile theEmployeeProfile)
        {
            ddl_EmployeeCode.Text = theEmployeeProfile.EmployeeID.ToString();
            //ddl_Profile.SelectedIndex = GetSelectedIndex(ddl_Profile, theEmployeeProfile.SettingKeyID);
            txt_Reference.Text = theEmployeeProfile.SettingKeyReference;
            PageVariables.TheProfileImage = new ProfileImage();
            PageVariables.TheProfileImage.ImageBinaries = PageVariables.ThisEmployeeProfile.SettingKeyValue;
            PageVariables.TheProfileImage.ImageUrl = GetProfileImageUrl(PageVariables.ThisEmployeeProfile.EmployeeID.ToString(), PageVariables.ThisEmployeeProfile.SettingKeyName, PageVariables.ThisEmployeeProfile.CommonKeyValue);

            img_ProfileImage.ImageUrl = PageVariables.TheProfileImage.ImageUrl;
            EnableDisbleProfiles(false);

        }

        private int UpdateEmployeeProfile()
        {
            EmployeeProfile objEmployeeProfile = new EmployeeProfile();
            objEmployeeProfile.EmployeeProfilleID = PageVariables.ThisEmployeeProfile.EmployeeProfilleID;
            objEmployeeProfile.EmployeeID = int.Parse(ddl_EmployeeCode.SelectedValue);
            objEmployeeProfile.SettingKeyDescription = PageVariables.SettingKeyDescription;
            objEmployeeProfile.SettingKeyName = MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue();
            objEmployeeProfile.SettingKeyID = int.Parse(ddl_Profile.SelectedValue);
            objEmployeeProfile.SettingKeyReference = txt_Reference.Text;
            objEmployeeProfile.SettingKeyValue = PageVariables.TheProfileImage.ImageBinaries;
            int ProcReturnValue = EmployeeProfileManagement.GetInstance.UpdateEmployeeProfile(objEmployeeProfile);
            return ProcReturnValue;

        }

        private int DeleteEmployeeProfile()
        {
            int ProcReturnValue = EmployeeProfileManagement.GetInstance.DeleteEmployeeProfile(PageVariables.ThisEmployeeProfile);


            return ProcReturnValue;
        }

        private void EnableDisbleProfiles(bool enableState = true)
        {
            ddl_EmployeeCode.Enabled = enableState;
            ddl_Profile.Enabled = enableState;

            btn_EmpProfileView.Enabled = enableState;
            btn_EmpProfileBottomView.Enabled = enableState;

        }

        private bool ValidateEmployeeProfileFields()
        {
            bool ReturnValue;

            if (PageVariables.TheProfileImage == null)
                ReturnValue = false;
            else
                ReturnValue = true;

            if (ReturnValue)
                if (PageVariables.TheProfileImage.ImageBinaries == null)
                    ReturnValue = false;

            if (ReturnValue)
                if (string.IsNullOrEmpty(PageVariables.TheProfileImage.ImageUrl))
                    ReturnValue = false;

            return ReturnValue;
        }

        private void ResetProfilePageFields()
        {
            EnableDisbleProfiles();

            ddl_EmployeeCode.SelectedIndex = 0;
            ddl_Profile.SelectedIndex = 0;
            txt_Reference.Text = string.Empty;
            img_ProfileImage.ImageUrl = string.Empty;

            btn_EmpProfileSave.Text = String.Format(" {0} ", MicroEnums.DataOperation.Save.GetStringValue());
            btn_EmpProfileBottomSave.Text = String.Format(" {0} ", MicroEnums.DataOperation.Save.GetStringValue());

            PageVariables.TheProfileImage = null;
            PageVariables.ThisEmployeeProfile = null;
        }

        private void BindProfileGridView()
        {
            gview_EmployeeProfiles.DataSource = null;
            gview_EmployeeProfiles.DataBind();
            List<EmployeeProfile> theEmployeeProfileList = EmployeeProfileManagement.GetInstance.GetEmployeeProfileImageByEmployeeID(int.Parse(ddl_EmployeeCode.SelectedValue));
            if (theEmployeeProfileList.Count > 0)
            {
                gview_EmployeeProfiles.DataSource = theEmployeeProfileList;
                gview_EmployeeProfiles.DataBind();
            }

        }

        #endregion

        protected void gview_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void radio_Profile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Int32.Parse(radio_Profile.SelectedValue.ToString());

            if (index == 0)
            {
                ResetTextBoxes();
                //BindDropdown_AppendSelectToFirst(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
                
            }
            else if (index == 1)
            {
                ResetProfilePageFields();
            }
            multiView_EmployeeDetails.ActiveViewIndex = index;
        }

        //
        #endregion

        #endregion
    }
}