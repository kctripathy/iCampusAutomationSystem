using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;


using Micro.Framework.ReadXML;
using Micro.Objects.Administration;
using Micro.Commons;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.HumanResource;


namespace Micro.WebApplication.APPS.ICAS.STAFFS
{
    public partial class StaffMasters : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {


            public static StaffMaster ThisStaffMaster
            {
                get
                {
                    StaffMaster TheStaffMaster = HttpContext.Current.Session["ThisStaffMaster"] as StaffMaster;
                    return TheStaffMaster;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisStaffMaster", value);
                }
            }

            //TODO--CustomerList in Customer
            public static List<StaffMaster> StaffMasterList
            {
                get
                {
                    List<StaffMaster> TheStaffMasterList = HttpContext.Current.Session["StaffMasterList"] as List<StaffMaster>;
                    return TheStaffMasterList;
                }
                set
                {
                    HttpContext.Current.Session.Add("StaffMasterList", value);
                }
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                SetValidationMessages();
                BindDropDownList();
                BindDropdown_AppendSelectToFirst(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
                ddl_Salutation.Focus();
                multiView_EmployeeDetails.SetActiveView(view_InputControls);
            }
        }

        protected void ddl_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeMartialStatus(ddl_Salutation, ddl_Gender, ddl_MaritalStatus, txt_SpouceName);           
        }

        protected void ddl_MaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeMartialStatus(ddl_Salutation, ddl_Gender, ddl_MaritalStatus, txt_SpouceName);
                
                ValidateFatherAndHusbandName();
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

        protected void txt_JoinDateinService_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (IsValidDate(txt_JoinDate.Text))
                {
                    txt_JoinDate.Text = DateTime.Parse(txt_JoinDate.Text).ToString(MicroConstants.DateFormat);
                   
                }
                if (txt_JoinDate.Text != string.Empty)
                {
                    ValidateJoiningDateinService();
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

        protected void btn_ViewEmployeeDetails_OnClick(object sender, EventArgs e)
        {
            multiView_EmployeeDetails.SetActiveView(view_GridView);
            BindGridView();
        }

        protected void btn_AddNew_Click(object sender, EventArgs e)
        {
            multiView_EmployeeDetails.SetActiveView(view_InputControls);
            ResetTextBoxes();
        }
        public bool ValidateQualification()
        {
            bool Retval = true;
            if (ddl_Qualification.SelectedIndex == 0)
                Retval = false;
            else if (txt_PassingYear.Text == string.Empty)
                Retval = false;
            else if (txt_Board.Text == string.Empty)
                Retval = false;
            else if (txt_Division.Text == string.Empty)
                Retval = false;
            else if (txt_Percentage.Text == string.Empty)
                Retval = false;
            if (Retval == false)
            {
                lbl_TheMessage.Text = "!!! Please Check The Previous Qualifaication Fields are not Left Blank";
                dialog_Message.Show();
            }
            return Retval;                
        }
        protected void btn_AddSample_Click(object sender, EventArgs e)
        {
            if (ValidateQualification())
            {

                if (ViewState["Data"] == null)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("CourseName");
                    dt.Columns.Add("PassingYear");
                    dt.Columns.Add("Board");
                    dt.Columns.Add("Division");
                    dt.Columns.Add("Percentage");
                    ViewState["Data"] = dt;
                    createrow(dt, ddl_Qualification.SelectedValue, txt_PassingYear.Text, txt_Board.Text, txt_Division.Text, txt_Percentage.Text);

                    gview_Course.DataSource = (DataTable)ViewState["Data"];
                    gview_Course.DataBind();
                    ResetQualificationValues();
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    dt1 = (DataTable)ViewState["Data"];
                    createrow(dt1, ddl_Qualification.SelectedValue, txt_PassingYear.Text, txt_Board.Text, txt_Division.Text, txt_Percentage.Text);

                    gview_Course.DataSource = (DataTable)ViewState["Data"];
                    gview_Course.DataBind();
                    ResetQualificationValues();
                }
            }            
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            lbl_TheMessage.Text = string.Empty;
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
            {
                ProcReturnValue = InsertEmployee();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_ADDED");
                    ResetTextBoxes();
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_ADDED");
                }
            }
            else
            {
                ProcReturnValue = UpdateEmployee();
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_DATA_UPDATED");
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_DATA_UPDATED");                   
                }
            }            
            if(!string.IsNullOrEmpty(lbl_TheMessage.Text))
            dialog_Message.Show();
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void gview_Employee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gview_Employee.PageIndex = e.NewPageIndex;
                BindGridView();


                //lit_PageCounter.Text = string.Format("Page <b>{0}</b> of {1}", e.NewPageIndex + 1, gview_Employee.PageCount);

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

                PageVariables.ThisStaffMaster = StaffMasterManagement.GetInstance.GetEmployeeByID(RecordID);

                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {

                    ////////lbl_DataOperationMode.Text = String.Format("EDIT Employee : {0} [{1}]", gview_Employee.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
                    btn_Top_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                    btn_Saveupdate.Text = MicroEnums.DataOperation.Update.GetStringValue();
                  //////// // Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                   
                   multiView_EmployeeDetails.SetActiveView(view_InputControls);

                    PopulatePageFields(PageVariables.ThisStaffMaster);

                    //if (PageVariables.ThisEmployee.LastQualification.Equals(MicroEnums.Qualifications.UnderMatric.GetStringValue()))
                    //{
                    //    Enabledisabletextboxqualification(false);
                    //}
                    bool EnableFlag = true;
                    EnableControls(view_InputControls, EnableFlag);
                    btn_Top_Save.Visible = EnableFlag;
                    btn_Saveupdate.Visible = EnableFlag;
                   //////// Btn_Save.Visible = EnableFlag;


                    ////////btn_Cancel.Visible = EnableFlag;
                    btn_Reset.Visible = EnableFlag;
                    // ChangeBackColor(view_InputControls);
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {
                    /////lbl_DataOperationMode.Text = String.Format("EDIT Employee : {0} [{1}]", gview_Employee.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

                    multiView_EmployeeDetails.SetActiveView(view_InputControls);
                    PopulatePageFields(PageVariables.ThisStaffMaster);

                    bool EnableFlag = false;
                    EnableControls(view_InputControls, EnableFlag);

                    ///////////////Btn_Save.Visible = EnableFlag;
                    btn_Top_Save.Visible = EnableFlag;
                    btn_Saveupdate.Visible = EnableFlag;
                  ///////////  btn_Cancel.Visible = EnableFlag;
                    btn_Reset.Visible = EnableFlag;
                }

                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee", MicroEnums.DataOperation.Delete);
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        BindGridView();
                       /// BindGrid_Employees();
                    }

                    dialog_Message.Show();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
 
        }

        protected void gview_Employee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Employee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
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
             
        #endregion

        #region Methods & Implementation

        void createrow(DataTable dt, string s1, string s2, string s3, string s4, string s5)
        {


            DataTable dt1 = (DataTable)ViewState["Data"];
            DataRow dr1 = dt1.NewRow();
            dr1["CourseName"] = s1;
            dr1["PassingYear"] = s2;
            dr1["Board"] = s3;
            dr1["Division"] = s4;
            dr1["Percentage"] = s5;
            dt1.Rows.Add(dr1);

        }
        
        private void SetValidationMessages()
        {
            requiredFieldValidator_Salutation.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Gender.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Designation.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Department.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            //requiredFieldValidator_Office.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ReportingTo.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            requiredFieldValidator_Employeetyp1.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Employeetyp2.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Employeetyp3.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Employeetyp4.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            //requiredFieldValidator_Status.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Present_District.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_Permanent_District.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            //requiredFieldValidator_MaritalStatus.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            //requiredFieldValidator_Nationality.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            //--------requiredFieldValidator_Qualification.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            //regularExpressionValidator_EmergenceNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            //regularExpressionValidator_EmergenceNumber.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_NUMBER_FIELD");            
            regularExpressionValidator_MobileLength.ValidationExpression = MicroConstants.REGEX_MOBILE_LENGTH;
            regularExpressionValidator_PhoneNumberLength.ValidationExpression = MicroConstants.REGEX_MOBILE_LENGTH;
            regularExpressionValidator_DOB.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_PassingYear.ValidationExpression = MicroConstants.REGEX_NUMBER_GREATERTHANZERO;
            regularExpressionValidator_ReferencePhone.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            //regularExpressionValidator_BioDeviceEmpid.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_RefLetterNo.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            //regularExpressionValidator_SpouceName.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_PersonalEmailID.ValidationExpression = MicroConstants.REGEX_EMAILID;
            regularExpressionValidator_PhoneNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_Present_Pincode.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_Permanent_Pincode.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_MobileNumber.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_ReferenceMobile.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_ReferencePhone.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;
            regularExpressionValidator_JoinDate.ValidationExpression = MicroConstants.REGEX_DATE;
            //regularExpressionValidator_FatherName.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_EmployeeName.ValidationExpression = MicroConstants.REGEX_NAME;

            regularExpressionValidator_Reference_Mobile_length.ValidationExpression = MicroConstants.REGEX_MOBILE_LENGTH;
            regularExpressionValidator_ReferenceMobile.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;

            regularExpressionValidator_ReferencephoneLength.ValidationExpression = MicroConstants.REGEX_MOBILE_LENGTH;            
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


            requiredFieldValidator_Salutation.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_Gender.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_EmployeeName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_JoinDate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_JoinDateinService.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_PresentAddress.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            //requiredFieldValidator_FatherName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            //requiredFieldValidator_EmergenceNumber.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "EmergenceNumber");
            //--------requiredFieldValidator_Qualification.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_ReportingTo.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_Present_District.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_Permanent_District.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            //requiredFieldValidator_Office.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Office");
            //requiredFieldValidator_Nationality.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            //requiredFieldValidator_MaritalStatus.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_DOB.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_Designation.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_Department.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "*");
            //requiredFieldValidator_PassingYear.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "PassingYear");

            requiredFieldValidator_Employeetyp1.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "* ");
            requiredFieldValidator_Employeetyp2.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_Employeetyp3.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            requiredFieldValidator_Employeetyp4.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            //requiredFieldValidator_Status.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Status");
            // requiredFieldValidator_EmployeeCode.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "EmployeeName");
            RequiredFieldValidator_PermanentAddress.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "*");
            //requiredFieldValidator_SpouceName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "SpouceName");


            regularExpressionValidator_ReferencephoneLength.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_MOBILE_LENGTH");
            regularExpressionValidator_Reference_Mobile_length.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_MOBILE_LENGTH");
            regularExpressionValidator_DOB.ValidationExpression = MicroConstants.REGEX_DATE;
            regularExpressionValidator_DOB.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            regularExpressionValidator_EmployeeName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            //regularExpressionValidator_FatherName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            regularExpressionValidator_MobileNumber.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_MobileLength.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_MOBILE_LENGTH");
            regularExpressionValidator_PhoneNumberLength.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_MOBILE_LENGTH");
            regularExpressionValidator_ReferencePhone.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_ReferenceMobile.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_Permanent_Pincode.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PersonalEmailID.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_EMAILID");
            regularExpressionValidator_PhoneNumber.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_Present_Pincode.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            //regularExpressionValidator_SpouceName.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            //regularExpressionValidator_BioDeviceEmpid.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_RefLetterNo.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_JoinDate.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            //regularExpressionValidator_ReferenceMobile.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            //regularExpressionValidator_ReferencePhone.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_PassingYear.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_GREATERTHANZERO");

            // requiredFieldValidator_Profile.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            // requiredFieldValidator_Profile.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Profile Type");

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
            //requiredFieldValidator_FatherName.CssClass = theClassName;
            //requiredFieldValidator_EmergenceNumber.CssClass = theClassName;
            //---------requiredFieldValidator_Qualification.CssClass = theClassName;
            requiredFieldValidator_ReportingTo.CssClass = theClassName;
            requiredFieldValidator_Present_District.CssClass = theClassName;
            requiredFieldValidator_Permanent_District.CssClass = theClassName;
            //requiredFieldValidator_Office.CssClass = theClassName;
            //requiredFieldValidator_Nationality.CssClass = theClassName;
            //requiredFieldValidator_MaritalStatus.CssClass = theClassName;
            requiredFieldValidator_DOB.CssClass = theClassName;
            requiredFieldValidator_Designation.CssClass = theClassName;
            requiredFieldValidator_Department.CssClass = theClassName;
            regularExpressionValidator_Present_Pincode.CssClass = theClassName;
            regularExpressionValidator_PhoneNumber.CssClass = theClassName;
            regularExpressionValidator_MobileNumber.CssClass = theClassName;
            //regularExpressionValidator_EmergenceNumber.CssClass = theClassName;

            regularExpressionValidator_ReferenceMobile.CssClass = theClassName;
            regularExpressionValidator_ReferencePhone.CssClass = theClassName;
            //requiredFieldValidator_SpouceName.CssClass = theClassName;
            //regularExpressionValidator_SpouceName.CssClass = theClassName;


            requiredFieldValidator_Employeetyp1.CssClass = theClassName;
            requiredFieldValidator_Employeetyp2.CssClass = theClassName;
            requiredFieldValidator_Employeetyp3.CssClass = theClassName;
            requiredFieldValidator_Employeetyp4.CssClass = theClassName;
            
        }      

        private bool ValidateFatherAndHusbandName()
        {
            bool ReturnValue = true;

            //requiredFieldValidator_FatherName.Enabled = true;
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
                        //requiredFieldValidator_FatherName.Enabled = true;
                        //requiredFieldValidator_FatherName.Validate();
                        lbl_TheMessage.Text = string.Empty;
                        ReturnValue = false;
                    }
                }
            }

            return ReturnValue;
        }

       
        private void BindDropDownList()
        {
            BindDropdown_Course();
            BindDropdown_EmployeeType1();
            BindDropdown_EmployeeType2();
            BindDropdown_EmployeeType3();
            BindDropdown_EmployeeType4();

            BindDropdown_Salutation();
            BindDropdown_Gender();
            BindDropdown_MaritalStatus();
            BindDropdown_Nationality();
            BindDropdown_Religion();
            BindDropdown_PermanentDistrict();
            BindDropdown_PresentDistrict();
            BindDropdown_Designation();
            BindDropdown_Department();
            BindDropdown_Office();
            BindDropdown_ReportingTo();
           // BindDropdown_ServiceStatus();
           
            BindDropdown_BloodGroup();


        }

        private bool ValidateJoiningDateinService()
        {
            bool RetValue = true;
            if (txt_JoinDate.Text== string.Empty)
            {
                RetValue = false;
            }

            else
            {
                if (DateTime.Parse(txt_JoinDate.Text) > DateTime.Parse(txt_JoinDateinService.Text))
                {
                    RetValue = false;
                    dialog_Message.Show();
                    lbl_TheMessage.Text = "Joining Date In Service Can't be Smaller than Joining Date!!";
                    txt_JoinDateinService.Text = string.Empty;
                    txt_JoinDateinService.Focus();
                }
                else
                {                   
                    txt_ServiceStatusLastWorkingDate.Text = DateTime.Parse(txt_DOB.Text).AddMonths(60).ToString(MicroConstants.DateTimeFormat);
                    txt_ServiceStatusLastWorkingDate.Enabled = false;
                }
            }

            return RetValue;
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

        private void EnableDisablePermanentAddress(bool enableState)
        {
            txt_PermanentAddress.ReadOnly = enableState;
            txt_PermanentLandMark.ReadOnly = enableState;
            txt_PermanentPincode.ReadOnly = enableState;
            ddl_PermanentDistrict.Enabled = !enableState;
        }

        private void BindDropdown_AppendSelectToFirst(string ddlDefaultItem)

        {
            ddl_Salutation.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT_DASH);
           
            ddl_Employeetyp1.Items.Insert(0, ddlDefaultItem);
            ddl_Employeetyp2.Items.Insert(0, ddlDefaultItem);
            ddl_Employeetyp3.Items.Insert(0, ddlDefaultItem);
            ddl_Employeetyp4.Items.Insert(0, ddlDefaultItem);
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
           // ddl_Status.Items.Insert(0, ddlDefaultItem);
           
            ddl_BloodGroup.Items.Insert(0, ddlDefaultItem);
        }

        private void BindDropdown_Course()
        {

            ddl_Qualification.DataSource = CourseManagement.GetInstance.GetCourseList();
            ddl_Qualification.DataTextField = CourseManagement.GetInstance.DisplayMember;
            ddl_Qualification.DataValueField = CourseManagement.GetInstance.ValueMember;
            ddl_Qualification.DataBind();
        }

        private void BindDropdown_EmployeeType1()
        {
            
            ddl_Employeetyp1.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.EmployeeType1.GetStringValue());
            ddl_Employeetyp1.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Employeetyp1.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Employeetyp1.DataBind();
        }
      
        private void BindDropdown_EmployeeType2()
        {

            ddl_Employeetyp2.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.EmployeeType2.GetStringValue());
            ddl_Employeetyp2.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Employeetyp2.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Employeetyp2.DataBind();
        }
       
        private void BindDropdown_EmployeeType3()
        {

            ddl_Employeetyp3.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.EmployeeType3.GetStringValue());
            ddl_Employeetyp3.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Employeetyp3.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Employeetyp3.DataBind();
        }
       
        private void BindDropdown_EmployeeType4()
        {

            ddl_Employeetyp4.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.EmployeeType4.GetStringValue());
            ddl_Employeetyp4.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Employeetyp4.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Employeetyp4.DataBind();
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

        private void BindDropdown_Designation()
        {
            ddl_Designation.DataSource = Micro.BusinessLayer.ICAS.STAFFS.DesignationManagement.GetInstance.GetDesignationsListByOffice();
            ddl_Designation.DataTextField = Micro.BusinessLayer.ICAS.STAFFS.DesignationManagement.GetInstance.DisplayMember;
            ddl_Designation.DataValueField = Micro.BusinessLayer.ICAS.STAFFS.DesignationManagement.GetInstance.ValueMember;
            ddl_Designation.DataBind();

        }

        private void BindDropdown_Department()
        {
            ddl_Department.DataSource = Micro.BusinessLayer.ICAS.STAFFS.DepartmentManagement.GetInstance.GetDepartmentsListByOffice();
            ddl_Department.DataTextField = Micro.BusinessLayer.ICAS.STAFFS.DepartmentManagement.GetInstance.DisplayMember;
            ddl_Department.DataValueField = Micro.BusinessLayer.ICAS.STAFFS.DepartmentManagement.GetInstance.ValueMember;
            ddl_Department.DataBind();
        }

        private void BindDropdown_Office()
        {
            ddl_Office.Enabled = true;
            ddl_Office.DataSource = OfficeManagement.GetInstance.GetOfficeListByReportingOfficeIDs();
            ddl_Office.DataTextField = OfficeManagement.GetInstance.DisplayMember;
            ddl_Office.DataValueField = OfficeManagement.GetInstance.ValueMember;
            ddl_Office.DataBind();
            ddl_Office.SelectedIndex = 0;
            ddl_Office.Enabled = false;
        }

        private void BindDropdown_ReportingTo()
        {
            ddl_ReportingTo.DataSource = EmployeeManagement.GetInstance.GetCompanyEmployeeList();
            ddl_ReportingTo.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
            ddl_ReportingTo.DataValueField = EmployeeManagement.GetInstance.ValueMember;
            ddl_ReportingTo.DataBind();
        }

       
        private void BindDropdown_BloodGroup()
        {
            ddl_BloodGroup.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.BloodGroup.GetStringValue());
            ddl_BloodGroup.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_BloodGroup.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_BloodGroup.DataBind();
        }

        private void ResetTextBoxes()
        {
            ddl_Designation.SelectedIndex = 0;
            ddl_Department.SelectedIndex = 0;
            ddl_ReportingTo.SelectedIndex = 0;
            ddl_Office.SelectedIndex = 0;
           
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
           // ddl_Status.SelectedIndex = 0;
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
            //txt_EmergencyNo.Text = string.Empty;
            txt_EmpCode.Text = string.Empty;
            txt_IdentificationMark.Text = string.Empty;
           // txt_Institution.Text = string.Empty;
            txt_JoinDate.Text = string.Empty;
            txt_KnownAilment.Text = string.Empty;
            txt_Notice.Text = string.Empty;
            //txt_ProfessionalInstitution.Text = string.Empty;
            // txt_Reference.Text = string.Empty;
            txt_ReferenceMobile.Text = string.Empty;
            txt_ReferenceName.Text = string.Empty;
            txt_ReferencePhone.Text = string.Empty;
            txt_RefLetterNo.Text = string.Empty;
            txt_SpouceName.Text = string.Empty;
            txt_EpfAndGpfAccNo.Text = string.Empty;
            txt_PanNo.Text = string.Empty;
            txt_SbiAccountNo.Text = string.Empty;
            txt_ScaleOfPay.Text = string.Empty;
            txt_GporAgp.Text = string.Empty;
            txt_ChseRegdno.Text = string.Empty;
            txt_UniverRegdNo.Text = string.Empty;
            txt_DateofNextIncrement.Text = string.Empty;
            txt_JoinDate.Text = string.Empty;
            txt_JoinDateinService.Text = string.Empty;
            ddl_Employeetyp1.SelectedIndex = 0;
            ddl_Employeetyp2.SelectedIndex = 0;
            ddl_Employeetyp3.SelectedIndex = 0;
            ddl_Employeetyp4.SelectedIndex = 0;
            txt_ServiceStatusChangeRequestDate.Text = string.Empty;
            txt_ServiceStatusLastWorkingDate.Text = string.Empty;
            txt_PhStatus.Text = string.Empty;
            //txt_Certificate.Text = string.Empty;

            gview_Course.DataSource = null;
            gview_Course.DataBind();


            //lbl_FatherNameValidation.Text = string.Empty;
            //lbl_HusbandValidation.Text = string.Empty;

            //requiredFieldValidator_FatherName.Enabled = false;
            //requiredFieldValidator_SpouceName.Enabled = false;

            PageVariables.ThisStaffMaster = null;
            // lbl_DataOperationMode.Text = "ADD NEW Employee";


            btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Saveupdate.Text = MicroEnums.DataOperation.Save.GetStringValue();

            //if (!(BasePage.HasAddPermission(this.Page)))
            //{
            //    multiView_EmployeeDetails.SetActiveView(view_GridView);
            //}
        }

        private void ResetQualificationValues()
        {
            ddl_Qualification.SelectedIndex = 0;
            txt_PassingYear.Text = string.Empty;
            txt_Percentage.Text = string.Empty;
            txt_Board.Text = string.Empty;
            txt_Division.Text = string.Empty;
        }

        private static void ResetPageVariables()
        {
            PageVariables.ThisStaffMaster = null;
            PageVariables.StaffMasterList = null;
        }

        public void BindGridView()
        {
            // int OfficeID = 44;
            // int OfficeID = ((User)Session["CurrentUser"]).OfficeID;
            PageVariables.StaffMasterList = StaffMasterManagement.GetInstance.GetOfficeEmployeeList();

            gview_Employee.DataSource = PageVariables.StaffMasterList;
            gview_Employee.DataBind();
        }

        private int InsertEmployee()
        {
            int ProcReturnValue = 0;


            StaffMaster TheStaffMasters = new StaffMaster();

            TheStaffMasters.Salutation = ddl_Salutation.Text;
            TheStaffMasters.EmployeeName = ToProper(txt_EmployeeName.Text);
            TheStaffMasters.FatherName = ToProper(txt_FathersName.Text);
            TheStaffMasters.SpouseName = txt_SpouceName.Text;
            TheStaffMasters.Gender = ddl_Gender.Text;
            TheStaffMasters.MaritalStatus = ddl_MaritalStatus.Text;
            TheStaffMasters.DateOfBirth = txt_DOB.Text;
            TheStaffMasters.Nationality = ddl_Nationality.Text;
            TheStaffMasters.Religion = ddl_Religion.Text;
            TheStaffMasters.BloodGroup = ddl_BloodGroup.Text;
            TheStaffMasters.KnownAilments = txt_KnownAilment.Text;
            TheStaffMasters.IdentificationMark = txt_IdentificationMark.Text;
            TheStaffMasters.Address_Present_TownOrCity = txt_PresentAddress.Text;
            TheStaffMasters.Address_Present_LandMark = txt_PresentLandMark.Text;
            TheStaffMasters.Address_Present_Pincode = txt_PresentPincode.Text;            
            TheStaffMasters.Address_Present_DistrictID = int.Parse(ddl_PresentDistrict.SelectedValue);
            TheStaffMasters.Address_Permanent_TownOrCity = txt_PermanentAddress.Text;
            TheStaffMasters.Address_Permanent_LandMark = txt_PermanentLandMark.Text;
            TheStaffMasters.Address_Permanent_Pincode = txt_PermanentPincode.Text;
            TheStaffMasters.Address_Permanent_DistrictID = int.Parse(ddl_PermanentDistrict.SelectedValue);
            TheStaffMasters.PhoneNumber = txt_PhoneNumber.Text;
            TheStaffMasters.Mobile = txt_Mobile.Text;
            //TheStaffMasters.EmergencyContactNumber = txt_EmergencyNo.Text;
            TheStaffMasters.EmailID = txt_OfficialEmailID.Text;

            TheStaffMasters.PersonalEMailID = txt_PersonalEmailID.Text;
            TheStaffMasters.ReferenceMobile = txt_ReferenceMobile.Text;
            TheStaffMasters.ReferenceName = txt_ReferenceName.Text;
            TheStaffMasters.ReferencePhone = txt_ReferencePhone.Text;

            TheStaffMasters.PHStatus = txt_PhStatus.Text;
            TheStaffMasters.EPAndGPFAcNo = txt_EpfAndGpfAccNo.Text;
            TheStaffMasters.PanNo = txt_PanNo.Text;
            TheStaffMasters.SbiAccountNo = txt_SbiAccountNo.Text;
            TheStaffMasters.ScaleOfPay = txt_ScaleOfPay.Text;
            TheStaffMasters.GpOrAGP = txt_GporAgp.Text;
            TheStaffMasters.DateOfNextIncrement = txt_DateofNextIncrement.Text;
            TheStaffMasters.ChseRegdNo = txt_ChseRegdno.Text;
            TheStaffMasters.UnivRegdNo = txt_UniverRegdNo.Text;

            TheStaffMasters.JoiningDateInOffice = txt_JoinDate.Text;
            TheStaffMasters.JoiningDateInService=txt_JoinDateinService.Text;

            string CourseIDs = GetCheckedItemsValue(gview_Course);
            string Boards = GetCheckedItemsValue2(gview_Course);
            string PassingYears = GetCheckedItemsValue3(gview_Course);
            string Divisions = GetCheckedItemsValue4(gview_Course);
            string PercentageMarks = GetCheckedItemsValue5(gview_Course);

          
            TheStaffMasters.PersonalEMailID = txt_PersonalEmailID.Text;
            TheStaffMasters.ReferenceName = txt_ReferenceName.Text;
            TheStaffMasters.ReferencePhone = txt_ReferencePhone.Text;
            TheStaffMasters.ReferenceMobile = txt_ReferenceMobile.Text;
            
            TheStaffMasters.BoardOrUniversity = txt_Board.Text;
            //TheStaffMasters.ProfessionalQualification = txt_Certificate.Text;
            //TheStaffMasters.ProfessionalInstitution = txt_ProfessionalInstitution.Text;
            TheStaffMasters.EmployeeCode = txt_EmpCode.Text;
            TheStaffMasters.PostingDate = DateTime.Parse(txt_JoinDate.Text);
            TheStaffMasters.ReportingToEffectiveDateFrom = txt_JoinDate.Text;
            TheStaffMasters.DesignationID = int.Parse(ddl_Designation.SelectedValue);
            TheStaffMasters.DepartmentID = int.Parse(ddl_Department.SelectedValue);
            TheStaffMasters.OfficeID = int.Parse(ddl_Office.SelectedValue);
            TheStaffMasters.BioDeviceEmployeeID = txt_BioDeviceEmpid.Text;
            
           // TheStaffMasters.ServiceType = ddl_ServiceType.SelectedValue;
            TheStaffMasters.ReferenceLetterNumber = txt_RefLetterNo.Text;
            TheStaffMasters.ReportingToEmployeeID = int.Parse(ddl_ReportingTo.Text);


            TheStaffMasters.Employeetype1 = ddl_Employeetyp1.Text;
            TheStaffMasters.Employeetype2 = ddl_Employeetyp2.Text;
            TheStaffMasters.Employeetype3 = ddl_Employeetyp3.Text;
            TheStaffMasters.Employeetype4 = ddl_Employeetyp4.Text;
            TheStaffMasters.ServiceStatusChangeRequestDate = txt_ServiceStatusChangeRequestDate.Text;
            TheStaffMasters.ServiceStatusLastWorkingDate = txt_ServiceStatusLastWorkingDate.Text;
            //TheStaffMasters.TeachingOrNonTeaching = optCategory.SelectedValue.ToString();

            ProcReturnValue = StaffMasterManagement.GetInstance.InsertEmployee(TheStaffMasters, CourseIDs, Boards, PassingYears, Divisions, PercentageMarks);
            return ProcReturnValue;
        }
       
        public static string GetCheckedItemsValue(GridView parentControl)
        {

            string CheckedItemsValue = string.Empty;
            //string CheckedItemsValue2 = string.Empty;
            //string CheckedItemsValue3 = string.Empty;
            //string CheckedItemsValue4 = string.Empty;
            //string CheckedItemsValue5 = string.Empty;


            int Counter = 0;
            for (int i = 0; i < parentControl.Rows.Count; i++)
            {

                GridViewRow row = parentControl.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_SubjectID");
                if (chkb.Checked)
                {
                    if (Counter.Equals(0))
                    {
                        CheckedItemsValue = parentControl.Rows[i].Cells[1].Text;
                        //CheckedItemsValue2 = parentControl.Rows[i].Cells[2].Text;
                        //CheckedItemsValue3 = parentControl.Rows[i].Cells[3].Text;
                        //CheckedItemsValue4 = parentControl.Rows[i].Cells[4].Text;
                        //CheckedItemsValue5 = parentControl.Rows[i].Cells[5].Text;
                       


                        CheckedItemsValue = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[1].Text);
                        //CheckedItemsValue2 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[2].Text);
                        //CheckedItemsValue3 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[3].Text);
                        //CheckedItemsValue4 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[4].Text);
                    
                        //CheckedItemsValue5 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[5].Text);
                    }
                    else
                    {
                        CheckedItemsValue = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[1].Text);
                        //CheckedItemsValue2 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[2].Text);
                        //CheckedItemsValue3 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[3].Text);
                        //CheckedItemsValue4 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[4].Text);

                        //CheckedItemsValue5 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[5].Text);
                    
                    
                    
                    }
                    // string name = gview_OldDisplay.Rows[i].Cells[2].Text;
                    Counter = Counter + 1;
                }
            }

            return CheckedItemsValue;


        }

        public static string GetCheckedItemsValue2(GridView parentControl)
        {

            //string CheckedItemsValue = string.Empty;
           string CheckedItemsValue2 = string.Empty;
            //string CheckedItemsValue3 = string.Empty;
            //string CheckedItemsValue4 = string.Empty;
            //string CheckedItemsValue5 = string.Empty;


            int Counter = 0;
            for (int i = 0; i < parentControl.Rows.Count; i++)
            {

                GridViewRow row = parentControl.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_SubjectID");
                if (chkb.Checked)
                {
                    if (Counter.Equals(0))
                    {
                       
                        CheckedItemsValue2 = parentControl.Rows[i].Cells[2].Text;
                        //CheckedItemsValue3 = parentControl.Rows[i].Cells[3].Text;
                        //CheckedItemsValue4 = parentControl.Rows[i].Cells[4].Text;
                        //CheckedItemsValue5 = parentControl.Rows[i].Cells[5].Text;



                       
                        CheckedItemsValue2 = string.Format("{0}, {1}", CheckedItemsValue2, parentControl.Rows[i].Cells[2].Text);
                        //CheckedItemsValue3 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[3].Text);
                        //CheckedItemsValue4 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[4].Text);

                        //CheckedItemsValue5 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[5].Text);
                    }
                    else
                    {
                        
                        CheckedItemsValue2 = string.Format("{0}, {1}", CheckedItemsValue2, parentControl.Rows[i].Cells[2].Text);
                        //CheckedItemsValue3 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[3].Text);
                        //CheckedItemsValue4 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[4].Text);

                        //CheckedItemsValue5 = string.Format("{0}, {1}", CheckedItemsValue, parentControl.Rows[i].Cells[5].Text);



                    }
                    // string name = gview_OldDisplay.Rows[i].Cells[2].Text;
                    Counter = Counter + 1;
                }
            }

            return CheckedItemsValue2;


        }

        public static string GetCheckedItemsValue3(GridView parentControl)
        {

          
            string CheckedItemsValue3 = string.Empty;
           


            int Counter = 0;
            for (int i = 0; i < parentControl.Rows.Count; i++)
            {

                GridViewRow row = parentControl.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_SubjectID");
                if (chkb.Checked)
                {
                    if (Counter.Equals(0))
                    {

                       
                        CheckedItemsValue3 = parentControl.Rows[i].Cells[3].Text;
                       
                       
                        CheckedItemsValue3 = string.Format("{0}, {1}", CheckedItemsValue3, parentControl.Rows[i].Cells[3].Text);
                      
                    }
                    else
                    {

                        
                        CheckedItemsValue3 = string.Format("{0}, {1}", CheckedItemsValue3, parentControl.Rows[i].Cells[3].Text);
                        


                    }
                    // string name = gview_OldDisplay.Rows[i].Cells[2].Text;
                    Counter = Counter + 1;
                }
            }

            return CheckedItemsValue3;


        }
        
        public static string GetCheckedItemsValue4(GridView parentControl)
        {

           
            string CheckedItemsValue4 = string.Empty;
           


            int Counter = 0;
            for (int i = 0; i < parentControl.Rows.Count; i++)
            {

                GridViewRow row = parentControl.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_SubjectID");
                if (chkb.Checked)
                {
                    if (Counter.Equals(0))
                    {

                       
                        CheckedItemsValue4 = parentControl.Rows[i].Cells[4].Text;
                       




                        CheckedItemsValue4 = string.Format("{0}, {1}", CheckedItemsValue4, parentControl.Rows[i].Cells[4].Text);

                       
                    }
                    else
                    {

                       CheckedItemsValue4 = string.Format("{0}, {1}", CheckedItemsValue4, parentControl.Rows[i].Cells[4].Text);

                       



                    }
                    // string name = gview_OldDisplay.Rows[i].Cells[2].Text;
                    Counter = Counter + 1;
                }
            }

            return CheckedItemsValue4;


        }
        
        public static string GetCheckedItemsValue5(GridView parentControl)
        {

           
            string CheckedItemsValue5 = string.Empty;


            int Counter = 0;
            for (int i = 0; i < parentControl.Rows.Count; i++)
            {

                GridViewRow row = parentControl.Rows[i];
                CheckBox chkb = (CheckBox)row.FindControl("chk_SubjectID");
                if (chkb.Checked)
                {
                    if (Counter.Equals(0))
                    {

                       
                        CheckedItemsValue5 = parentControl.Rows[i].Cells[5].Text;




                        CheckedItemsValue5 = string.Format("{0}, {1}", CheckedItemsValue5, parentControl.Rows[i].Cells[5].Text);
                    }
                    else
                    {

                       
                        CheckedItemsValue5 = string.Format("{0}, {1}", CheckedItemsValue5, parentControl.Rows[i].Cells[5].Text);



                    }
                    // string name = gview_OldDisplay.Rows[i].Cells[2].Text;
                    Counter = Counter + 1;
                }
            }

            return CheckedItemsValue5;


        }
        
        private int UpdateEmployee()
        {
            int ProcReturnValue = 0;
            PageVariables.ThisStaffMaster.Salutation = ddl_Salutation.Text;
            PageVariables.ThisStaffMaster.EmployeeName = txt_EmployeeName.Text;
            PageVariables.ThisStaffMaster.FatherName = txt_FathersName.Text;
            PageVariables.ThisStaffMaster.SpouseName = txt_SpouceName.Text;
            PageVariables.ThisStaffMaster.Gender = ddl_Gender.Text;
            PageVariables.ThisStaffMaster.MaritalStatus = ddl_MaritalStatus.SelectedValue;
            PageVariables.ThisStaffMaster.DateOfBirth = txt_DOB.Text;
            PageVariables.ThisStaffMaster.Nationality = ddl_Nationality.Text;
            PageVariables.ThisStaffMaster.Religion = ddl_Religion.Text;
            PageVariables.ThisStaffMaster.BloodGroup = ddl_BloodGroup.Text;
            PageVariables.ThisStaffMaster.KnownAilments = txt_KnownAilment.Text;
            PageVariables.ThisStaffMaster.IdentificationMark = txt_IdentificationMark.Text;
            PageVariables.ThisStaffMaster.Address_Present_TownOrCity = txt_PresentAddress.Text;
            PageVariables.ThisStaffMaster.Address_Present_LandMark = txt_PresentLandMark.Text;
            PageVariables.ThisStaffMaster.Address_Present_Pincode = txt_PresentPincode.Text;
            PageVariables.ThisStaffMaster.Address_Present_DistrictID = int.Parse(ddl_PresentDistrict.SelectedValue);
            PageVariables.ThisStaffMaster.Address_Permanent_TownOrCity = txt_PermanentAddress.Text;
            PageVariables.ThisStaffMaster.Address_Permanent_LandMark = txt_PermanentLandMark.Text;
            PageVariables.ThisStaffMaster.Address_Permanent_Pincode = txt_PermanentPincode.Text;
            PageVariables.ThisStaffMaster.Address_Permanent_DistrictID = int.Parse(ddl_PermanentDistrict.SelectedValue);
            PageVariables.ThisStaffMaster.PhoneNumber = txt_PhoneNumber.Text;
            PageVariables.ThisStaffMaster.Mobile = txt_Mobile.Text;
            //PageVariables.ThisStaffMaster.EmergencyContactNumber = txt_EmergencyNo.Text;
            PageVariables.ThisStaffMaster.EmailID = txt_OfficialEmailID.Text;
            PageVariables.ThisStaffMaster.PersonalEMailID = txt_PersonalEmailID.Text;
            PageVariables.ThisStaffMaster.ReferenceMobile = txt_ReferenceMobile.Text;
            PageVariables.ThisStaffMaster.ReferenceName = txt_ReferenceName.Text;
            PageVariables.ThisStaffMaster.ReferencePhone = txt_ReferencePhone.Text;

            PageVariables.ThisStaffMaster.PHStatus = txt_PhStatus.Text;
            PageVariables.ThisStaffMaster.EPAndGPFAcNo = txt_EpfAndGpfAccNo.Text;
            PageVariables.ThisStaffMaster.PanNo = txt_PanNo.Text;
            PageVariables.ThisStaffMaster.SbiAccountNo = txt_SbiAccountNo.Text;
            PageVariables.ThisStaffMaster.ScaleOfPay = txt_ScaleOfPay.Text;
            PageVariables.ThisStaffMaster.GpOrAGP = txt_GporAgp.Text;
            PageVariables.ThisStaffMaster.DateOfNextIncrement = txt_DateofNextIncrement.Text;
            PageVariables.ThisStaffMaster.ChseRegdNo = txt_ChseRegdno.Text;
            PageVariables.ThisStaffMaster.UnivRegdNo = txt_UniverRegdNo.Text;
            PageVariables.ThisStaffMaster.JoiningDateInOffice = txt_JoinDate.Text;
            PageVariables.ThisStaffMaster.JoiningDateInService = txt_JoinDateinService.Text;
            PageVariables.ThisStaffMaster.Employeetype1 = ddl_Employeetyp1.SelectedValue;
            PageVariables.ThisStaffMaster.Employeetype2 = ddl_Employeetyp2.SelectedValue;
            PageVariables.ThisStaffMaster.Employeetype3 = ddl_Employeetyp3.SelectedValue;
            PageVariables.ThisStaffMaster.Employeetype4 = ddl_Employeetyp4.SelectedValue;
            PageVariables.ThisStaffMaster.ServiceStatusChangeRequestDate = txt_ServiceStatusChangeRequestDate.Text;
            PageVariables.ThisStaffMaster.ServiceStatusLastWorkingDate = txt_ServiceStatusLastWorkingDate.Text;
          
           



            PageVariables.ThisStaffMaster.EmployeeCode = txt_EmpCode.Text;
            PageVariables.ThisStaffMaster.DesignationID = int.Parse(ddl_Designation.SelectedValue);
            PageVariables.ThisStaffMaster.DepartmentID = int.Parse(ddl_Department.SelectedValue);
            PageVariables.ThisStaffMaster.OfficeID = int.Parse(ddl_Office.SelectedValue);
            PageVariables.ThisStaffMaster.ReportingToEmployeeID = int.Parse(ddl_ReportingTo.SelectedValue);
            PageVariables.ThisStaffMaster.ReportingToEffectiveDateFrom = txt_JoinDate.Text;
            PageVariables.ThisStaffMaster.BioDeviceEmployeeID = txt_BioDeviceEmpid.Text;
            PageVariables.ThisStaffMaster.JoiningDateInOffice = txt_JoinDate.Text;
            PageVariables.ThisStaffMaster.JoiningDateInService = txt_JoinDateinService.Text;

           // PageVariables.ThisStaffMaster.ServiceStatus = ddl_Status.SelectedValue;
           
            PageVariables.ThisStaffMaster.ReferenceLetterNumber = txt_RefLetterNo.Text;




            string CourseIDs = GetCheckedItemsValue(gview_Course);
            string Boards = GetCheckedItemsValue2(gview_Course);
            string PassingYears = GetCheckedItemsValue3(gview_Course);
            string Divisions = GetCheckedItemsValue4(gview_Course);
            string PercentageMarks = GetCheckedItemsValue5(gview_Course);





            ProcReturnValue = StaffMasterManagement.GetInstance.UpdateEmployee(PageVariables.ThisStaffMaster, CourseIDs, Boards, PassingYears, Divisions, PercentageMarks);
            return ProcReturnValue;
        }

        public static int DeleteRecord()
        {
            int ProcReturnValue = StaffMasterManagement.GetInstance.DeleteEmployee(PageVariables.ThisStaffMaster);

            return ProcReturnValue;
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

        private void PopulatePageFields(StaffMaster theStaffMaster)
        {
            ddl_Salutation.SelectedIndex = GetDropDownSelectedIndex(ddl_Salutation, theStaffMaster.Salutation);
            txt_EmployeeName.Text = theStaffMaster.EmployeeName;
            txt_FathersName.Text = theStaffMaster.FatherName;
            txt_SpouceName.Text = theStaffMaster.SpouseName;
            ddl_Gender.SelectedIndex = GetDropDownSelectedIndex(ddl_Gender, theStaffMaster.Gender);
            ddl_MaritalStatus.SelectedIndex = GetDropDownSelectedIndex(ddl_MaritalStatus, theStaffMaster.MaritalStatus);


            txt_DOB.Text = theStaffMaster.DateOfBirth;
            ddl_Nationality.SelectedIndex = GetDropDownSelectedIndex(ddl_Nationality, theStaffMaster.Nationality);
            ddl_Religion.SelectedIndex = GetDropDownSelectedIndex(ddl_Religion, theStaffMaster.Religion);
            ddl_BloodGroup.SelectedIndex = GetDropDownSelectedIndex(ddl_BloodGroup, theStaffMaster.BloodGroup);
            txt_KnownAilment.Text = theStaffMaster.KnownAilments;
            txt_IdentificationMark.Text = theStaffMaster.IdentificationMark;
            txt_PresentAddress.Text = theStaffMaster.Address_Present_TownOrCity;
            txt_PresentLandMark.Text = theStaffMaster.Address_Present_LandMark;
            txt_PresentPincode.Text = theStaffMaster.Address_Present_Pincode;
            ddl_PresentDistrict.SelectedIndex = GetDropDownSelectedIndex(ddl_PresentDistrict, Convert.ToString(theStaffMaster.Address_Present_DistrictID));
            txt_PresentState.Text = theStaffMaster.Address_Present_StateName;
            txt_PresentCountry.Text = theStaffMaster.Address_Present_CountryName;
            txt_PermanentAddress.Text = theStaffMaster.Address_Permanent_TownOrCity;
            txt_PermanentLandMark.Text = theStaffMaster.Address_Permanent_LandMark;
            txt_PermanentPincode.Text = theStaffMaster.Address_Permanent_Pincode;
            ddl_PermanentDistrict.SelectedIndex = GetDropDownSelectedIndex(ddl_PermanentDistrict, Convert.ToString(theStaffMaster.Address_Permanent_DistrictID));
                
               
            txt_PermanentState.Text = theStaffMaster.Address_Permanent_StateName;
            txt_PermanentCountry.Text = theStaffMaster.Address_Permanent_CountryName;
            txt_PhoneNumber.Text = theStaffMaster.PhoneNumber;
            txt_Mobile.Text = theStaffMaster.Mobile;
            //txt_EmergencyNo.Text = theStaffMaster.EmergencyContactNumber;
            txt_PersonalEmailID.Text = theStaffMaster.PersonalEMailID;
            txt_ReferenceMobile.Text = theStaffMaster.ReferenceMobile;
            txt_ReferenceName.Text = theStaffMaster.ReferenceName;
            txt_ReferencePhone.Text = theStaffMaster.ReferencePhone;
            txt_OfficialEmailID.Text = theStaffMaster.EmailID;
            txt_EpfAndGpfAccNo.Text = theStaffMaster.EPAndGPFAcNo;
            txt_PanNo.Text = theStaffMaster.PanNo;
            txt_SbiAccountNo.Text = theStaffMaster.SbiAccountNo;
            txt_ScaleOfPay.Text = theStaffMaster.ScaleOfPay;
            txt_GporAgp.Text = theStaffMaster.GpOrAGP;
            txt_ChseRegdno.Text = theStaffMaster.ChseRegdNo;
            txt_UniverRegdNo.Text = theStaffMaster.UnivRegdNo;
            txt_DateofNextIncrement.Text = theStaffMaster.DateOfNextIncrement;
            txt_JoinDate.Text = theStaffMaster.JoiningDateInOffice;
            txt_JoinDateinService.Text = theStaffMaster.JoiningDateInService;
            ddl_Employeetyp1.SelectedIndex = GetDropDownSelectedIndex(ddl_Employeetyp1, theStaffMaster.Employeetype1);
            ddl_Employeetyp2.SelectedIndex = GetDropDownSelectedIndex(ddl_Employeetyp2, theStaffMaster.Employeetype2);
            ddl_Employeetyp3.SelectedIndex = GetDropDownSelectedIndex(ddl_Employeetyp3, theStaffMaster.Employeetype3);
            ddl_Employeetyp4.SelectedIndex = GetDropDownSelectedIndex(ddl_Employeetyp4, theStaffMaster.Employeetype4);
            txt_ServiceStatusChangeRequestDate.Text = theStaffMaster.ServiceStatusChangeRequestDate;
            txt_ServiceStatusLastWorkingDate.Text = theStaffMaster.ServiceStatusLastWorkingDate;
            txt_RefLetterNo.Text = theStaffMaster.ReferenceLetterNumber;
            txt_PhStatus.Text = theStaffMaster.PHStatus;
          

            
          
            txt_EmpCode.Text = theStaffMaster.EmployeeCode;
            ddl_Designation.SelectedIndex = GetDropDownSelectedIndex(ddl_Designation, Convert.ToString(theStaffMaster.DesignationID));


            ddl_Department.SelectedIndex = GetDropDownSelectedIndex(ddl_Department, Convert.ToString(theStaffMaster.DepartmentID));
            ddl_Office.SelectedIndex = GetDropDownSelectedIndex(ddl_Office, Convert.ToString(theStaffMaster.OfficeID));
            txt_BioDeviceEmpid.Text = theStaffMaster.BioDeviceEmployeeID;
            txt_JoinDate.Text = theStaffMaster.JoiningDateInOffice;
            txt_JoinDateinService.Text = theStaffMaster.JoiningDateInService;
            ddl_ReportingTo.SelectedIndex = GetDropDownSelectedIndex(ddl_ReportingTo, Convert.ToString(theStaffMaster.ReportingToEmployeeID));
            
           // ddl_ServiceType.SelectedIndex = GetDropDownSelectedIndex(ddl_ServiceType, theStaffMaster.ServiceType);
            //ddl_Status.SelectedIndex = GetDropDownSelectedIndex(ddl_Status, theStaffMaster.ServiceStatus);
        }

        #endregion

      
        
    }
}