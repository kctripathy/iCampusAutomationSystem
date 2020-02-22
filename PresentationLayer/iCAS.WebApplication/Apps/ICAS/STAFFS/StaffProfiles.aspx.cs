using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.Administration;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS
{
    public partial class StaffProfiles : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static EmployeeProfile ThisEmployeeProfile;
            public static List<Employee> EmployeeList;
            public static ProfileImage TheProfileImage;

            public static int EmployeeID;
            public static string EmployeeName;
            public static string SettingKeyName = MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue();
            public static string SettingKeyDescription;
        }
        #endregion

        #region Events
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
                BasePage.ShowHidePagePermissions(gview_EmployeeProfiles, btn_New, this.Page);
                ResetPageVariables();
                SetValidationMessages();

                BindDropDown();

                multiView_EmployeeProfiles.SetActiveView(view_InputControls);
            }

            UploadImage();


        }


        protected void gview_EmployeeProfiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_EmployeeProfiles.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gview_EmployeeProfiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            int RecordID = int.Parse(((Label)gview_EmployeeProfiles.Rows[RowIndex].FindControl("lbl_EmployeeProfileID")).Text);

            PageVariables.ThisEmployeeProfile = EmployeeProfileManagement.GetInstance.GetEmployeeProfileByID(RecordID);
            //GetEmployeeProfileByEmployeeProfileID(RecordID);

            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                btn_Submit_Bottom.Text = String.Format(" {0} ", MicroEnums.DataOperation.Update.GetStringValue());
                btn_Submit_Top.Text = String.Format(" {0} ", MicroEnums.DataOperation.Update.GetStringValue());

                multiView_EmployeeProfiles.SetActiveView(view_InputControls);
                EnableControls(view_InputControls, true);
                PopulatePageFields(PageVariables.ThisEmployeeProfile);
                EnableDisableButtons();
            }
            else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
            {
                int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                ProcReturnValue = DeleteRecord();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Profile", MicroEnums.DataOperation.Delete);

                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    if (PageVariables.TheProfileImage == null)
                        PageVariables.TheProfileImage = new ProfileImage();

                    PageVariables.TheProfileImage.ImageUrl = GetProfileImageUrl(PageVariables.ThisEmployeeProfile.EmployeeID.ToString(), PageVariables.ThisEmployeeProfile.SettingKeyName, PageVariables.ThisEmployeeProfile.CommonKeyValue);
                    RemoveImageFile(PageVariables.TheProfileImage.ImageUrl);
                    PageVariables.TheProfileImage = null;
                    BindGridView();
                }

                dialog_Message.Show();
            }
            else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
            {

                multiView_EmployeeProfiles.SetActiveView(view_InputControls);
                PopulatePageFields(PageVariables.ThisEmployeeProfile);

                EnableControls(view_InputControls, false);
                EnableDisableButtons(false);
            }
        }

        protected void gview_EmployeeProfiles_RowDataBound(object sender, GridViewRowEventArgs e)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void gview_EmployeeProfiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_EmployeeProfiles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                PageVariables.TheProfileImage = null;
                ResetTextBoxes();
                EnableControls(view_InputControls, true);
                EnableDisableButtons();
                if (!string.IsNullOrEmpty(PageVariables.TheProfileImage.ImageUrl))
                {
                    if (PageVariables.TheProfileImage.ImageUrl.Contains("Temp"))
                    {
                        if (PageVariables.TheProfileImage != null)
                            RemoveImageFile(PageVariables.TheProfileImage.ImageUrl);

                    }
                }

            }
            catch
            {
            }
        }

        protected void btn_New_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();

            multiView_EmployeeProfiles.SetActiveView(view_InputControls);
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFields())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = InsertRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Profile", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Profile", MicroEnums.DataOperation.Edit);
                }

                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    MoveImageFile(PageVariables.TheProfileImage.ImageUrl);
                    ResetTextBoxes();
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

        protected void btn_View_Click(object sender, EventArgs e)
        {
            requiredFieldValidator_EmployeeCode.Validate();

            if (requiredFieldValidator_EmployeeCode.IsValid)
            {
                if (!IsDefaultItemText(ddl_Employees))
                {
                    PageVariables.EmployeeID = int.Parse(ddl_Employees.SelectedItem.Value);
                    PageVariables.EmployeeName = ddl_Employees.SelectedItem.Text;

                    lbl_GridView_AboutEmployee.Text = "You are viewing profile of " + PageVariables.EmployeeName;
                    multiView_EmployeeProfiles.SetActiveView(view_GridView);
                    BindGridView();
                }
            }
        }
        #endregion


        #region Methods & Implementation

        private void SetValidationMessages()
        {
            requiredFieldValidator_EmployeeCode.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_EmployeeProfile.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            requiredFieldValidator_EmployeeCode.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Employee");
            requiredFieldValidator_EmployeeProfile.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Profile Name");

            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_EmployeeCode.CssClass = theClassName;
            requiredFieldValidator_EmployeeProfile.CssClass = theClassName;
        }

        private void EnableDisbleProfiles(bool enableState = true)
        {
            ddl_Employees.Enabled = enableState;
            ddl_Profile.Enabled = enableState;

            btn_View_Top.Enabled = enableState;
            btn_View_Bottom.Enabled = enableState;
        }

        private void BindDropDown()
        {
            BindEmployees();
            BindProfiles();
        }

        private void BindEmployees(List<Employee> employeeList = null)
        {
            ddl_Employees.DataSource = null;
            ddl_Employees.DataBind();

            if (employeeList == null)
            {
                PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
                employeeList = PageVariables.EmployeeList;
            }

            if (employeeList.Count > 0)
            {
                ddl_Employees.DataSource = employeeList;
                ddl_Employees.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
                ddl_Employees.DataValueField = EmployeeManagement.GetInstance.ValueMember;
                ddl_Employees.DataBind();

                ddl_Employees.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
            }
        }

        private void BindProfiles()
        {
            ddl_Profile.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue());

            ddl_Profile.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_Profile.DataValueField = CommonKeyManagement.GetInstance.ValueMember;
            ddl_Profile.DataBind();

            ddl_Profile.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }

        private void BindGridView()
        {
            gview_EmployeeProfiles.DataSource = null;
            gview_EmployeeProfiles.DataBind();

            List<EmployeeProfile> EmployeeProfileList = EmployeeProfileManagement.GetInstance.GetEmployeeProfileImageByEmployeeID(int.Parse(ddl_Employees.SelectedItem.Value));

            if (EmployeeProfileList.Count > 0)
            {
                gview_EmployeeProfiles.DataSource = EmployeeProfileList;
                gview_EmployeeProfiles.DataBind();
            }
        }

        private void PopulatePageFields(EmployeeProfile theEmployeeProfile)
        {
            ddl_Employees.SelectedValue = theEmployeeProfile.EmployeeID.ToString();
            ddl_Profile.Text = theEmployeeProfile.SettingKeyID.ToString();
            txt_Reference.Text = theEmployeeProfile.SettingKeyDescription;

            PageVariables.TheProfileImage = new ProfileImage();
            PageVariables.TheProfileImage.ImageBinaries = PageVariables.ThisEmployeeProfile.SettingKeyValue;
            PageVariables.TheProfileImage.ImageUrl = GetProfileImageUrl(PageVariables.ThisEmployeeProfile.EmployeeID.ToString(), PageVariables.ThisEmployeeProfile.SettingKeyName, PageVariables.ThisEmployeeProfile.CommonKeyValue);

            img_ProfileImage.ImageUrl = PageVariables.TheProfileImage.ImageUrl;

            EnableDisbleProfiles(false);
        }

        private void UploadImage()
        {
            if (ValidateCustomerProfile())
            {
                PageVariables.EmployeeID = int.Parse(ddl_Employees.SelectedItem.Value);
                PageVariables.EmployeeName = ddl_Employees.SelectedItem.Text;
                PageVariables.SettingKeyDescription = ddl_Profile.SelectedItem.Text;

                string ImageUrl = SetProfileImageUrl(PageVariables.EmployeeID.ToString(), PageVariables.SettingKeyName, PageVariables.SettingKeyDescription, fileUpload_ProfileImage);
                PageVariables.TheProfileImage = UploadImage(PageVariables.TheProfileImage, fileUpload_ProfileImage, img_ProfileImage, ImageUrl);
                EnableDisbleProfiles(false);
            }
        }

        private int InsertRecord()
        {
            int ProcReturnValue = 0;

            EmployeeProfile TheEmployeeProfile = new EmployeeProfile();

            TheEmployeeProfile.EmployeeID = int.Parse(ddl_Employees.SelectedItem.Value);
            TheEmployeeProfile.SettingKeyName = MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue();
            TheEmployeeProfile.SettingKeyID = int.Parse(ddl_Profile.SelectedValue);
            TheEmployeeProfile.SettingKeyReference = txt_Reference.Text;
            TheEmployeeProfile.SettingKeyValue = PageVariables.TheProfileImage.ImageBinaries;


            ProcReturnValue = EmployeeProfileManagement.GetInstance.InsertEmployeeProfile(TheEmployeeProfile);

            return ProcReturnValue;
        }

        private int UpdateRecord()
        {
            int ProcReturnValue = 0;

            PageVariables.ThisEmployeeProfile.SettingKeyReference = txt_Reference.Text;
            PageVariables.ThisEmployeeProfile.SettingKeyValue = PageVariables.TheProfileImage.ImageBinaries;
            PageVariables.ThisEmployeeProfile.IsActive = true;

            ProcReturnValue = EmployeeProfileManagement.GetInstance.UpdateEmployeeProfile(PageVariables.ThisEmployeeProfile);

            return ProcReturnValue;
        }

        private int DeleteRecord()
        {
            int ProcReturnValue = EmployeeProfileManagement.GetInstance.DeleteEmployeeProfile(PageVariables.ThisEmployeeProfile);


            return ProcReturnValue;
        }

        private bool ValidateCustomerProfile()
        {
            bool ReturnValue;

            if (ddl_Employees.SelectedItem.Text.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
                ReturnValue = false;
            else
                ReturnValue = true;

            if (ReturnValue)
                if (ddl_Profile.Items.Count <= 0)
                    ReturnValue = false;

            if (ReturnValue)
                if (ddl_Profile.SelectedItem.Text.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
                    ReturnValue = false;

            return ReturnValue;
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

        private static void ResetPageVariables()
        {
            PageVariables.ThisEmployeeProfile = null;
            PageVariables.TheProfileImage = null;
            PageVariables.EmployeeList = null;
        }

        private void ResetTextBoxes()
        {
            EnableDisbleProfiles();

            ddl_Employees.SelectedIndex = 0;
            ddl_Profile.SelectedIndex = 0;
            txt_Reference.Text = string.Empty;
            img_ProfileImage.ImageUrl = string.Empty;

            btn_Submit_Top.Text = String.Format(" {0} ", MicroEnums.DataOperation.Save.GetStringValue());
            btn_Submit_Bottom.Text = String.Format(" {0} ", MicroEnums.DataOperation.Save.GetStringValue());

            PageVariables.TheProfileImage = null;
            PageVariables.ThisEmployeeProfile = null;
        }
        #endregion


        private void EnableDisableButtons(bool Enablestate = true)
        {
            btn_Submit_Bottom.Visible = Enablestate;
            btn_Submit_Top.Visible = Enablestate;

            fileUpload_ProfileImage.Enabled = Enablestate;
        }
    }
}