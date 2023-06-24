using Micro.BusinessLayer.HumanResource;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.Objects.ICAS.STAFFS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS
{
    public partial class StaffPhotoUpload : BasePage
    {
        string url = string.Concat("http://", ConfigurationManager.AppSettings["webserverip"].ToString(), "/api/staffphoto/");

        public class StaffImage
        {
            public string ImageUrl;
            public byte[] ImageBinaries;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            List<Staff> theList = StaffMasterManagement.GetInstance.GetStaffs();
            gview_Employee.DataSource = theList;
            gview_Employee.DataBind();

            BindDropdown(theList);
        }

        private void BindDropdown(List<Staff> theList)
        {
            ddl_Employees.DataSource = theList;
            ddl_Employees.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
            ddl_Employees.DataValueField = EmployeeManagement.GetInstance.ValueMember;
            ddl_Employees.DataBind();

            ddl_Employees.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
        }
        



        protected void gview_EmployeeProfiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            int RecordID = int.Parse(((Label)gview_Employee.Rows[RowIndex].FindControl("lbl_EmployeeID")).Text);
            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                Session["id"] = RecordID;
                dialogUpload.Show();
            }
            else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
            {
                Micro.Objects.HumanResource.EmployeeProfile empProfile = new Micro.Objects.HumanResource.EmployeeProfile
                {
                    EmployeeID = RecordID,
                };
                int ProcReturnValue = EmployeeProfileManagement.GetInstance.DeleteEmployeeProfile(empProfile);
                if (ProcReturnValue > 0)
                {
                    lit_Message.Text = "Staff photo removed successfully";
                    dialogUpload.Show();

                    BindGridView();
                }
                
            }
             
        }

        protected void gview_EmployeeProfiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblEmpId = (Label)e.Row.FindControl("lbl_EmployeeID");
                    Image lblImage = (Image)e.Row.FindControl("lbl_EmployeeImage");

                    lblImage.ImageUrl = String.Concat(url, lblEmpId.Text);

                    BasePage.GridViewOnDelete(e, 4);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (ddl_Employees.SelectedValue == null || ddl_Employees.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Error :", "alert('please select an employee.');", true);
                return;
            }
            InsertRecord();
        }

        private int InsertRecord()
        {
            int ProcReturnValue = 0;
            byte[] StaffImage = UploadStaffPhoto();
            if (StaffImage == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Error :", "alert('Error while writing image to database.');", true);
                return 0;
            }

            EmployeeProfile TheEmployeeProfile = new EmployeeProfile();
            TheEmployeeProfile.EmployeeID = int.Parse(ddl_Employees.SelectedValue.ToString());
            TheEmployeeProfile.SettingKeyName = MicroEnums.CommonKeyNames.EmployeeProfile.GetStringValue();
            TheEmployeeProfile.SettingKeyID = 81;
            TheEmployeeProfile.SettingKeyReference = "Photo";
            TheEmployeeProfile.SettingKeyValue = StaffImage;

            ProcReturnValue = EmployeeProfileManagement.GetInstance.InsertEmployeeProfile(TheEmployeeProfile);

            return ProcReturnValue;
        }

        private byte[] UploadStaffPhoto()
        {
            byte[] StaffImage = null;
            if (fileUploadEmployee.HasFile)
            {
                if (fileUploadEmployee.PostedFile != null)
                {
                    if (!string.IsNullOrEmpty(fileUploadEmployee.PostedFile.FileName))
                    {
                        HttpPostedFile postedFile = fileUploadEmployee.PostedFile;
                        StaffImage = new byte[fileUploadEmployee.PostedFile.ContentLength];
                        postedFile.InputStream.Read(StaffImage, 0, (int)fileUploadEmployee.PostedFile.ContentLength);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Error :", "alert('Please select a file to upload.');", true);

            }
            return StaffImage;
        }

        protected void gview_Employee_Init(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
        }
    }
}