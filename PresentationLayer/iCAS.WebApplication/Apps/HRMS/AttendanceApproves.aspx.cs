using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.HumanResource;
using Micro.BusinessLayer.HumanResource;
using Micro.Framework.ReadXML;
using Micro.BusinessLayer.Administration;

namespace Micro.WebApplication.MicroERP.HRMS
{
    public partial class AttendanceApproves : BasePage
	{
        #region Declaration

        protected static class PageVariables
        {
            public static List<AttendanceApplication> TheAttendanceApplicationList;
            public static string TheEmployeeID;
            public static string TheAttendanceApplicationID;
            public static int TheUserReferenceID;

        }

        static int AttendanceApplicationID;

        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                SetValidationMessages();
                EnableDisableCommandButtons(false);
                BindGridLeaveApplicationsToApproveReject();
                BindDropdown();
            }
		}

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
              
            EnableDisableCommandButtons(true);

                LinkButton lnkBtn = (LinkButton)sender;
                AttendanceApplicationID = int.Parse(lnkBtn.CommandArgument);
                AttendanceApplication objAttendanceApplication = new AttendanceApplication();

                objAttendanceApplication = AttendanceApplicationManagement.GetAttendanceApplicationByAttendanceApplicationID(AttendanceApplicationID);
               // objAttendanceAmendment = AttendanceAmendmentManagement.GetAttendanceAmendmentByAttendanceAmendmentID(AttendanceAmendmentID);


               // lbl_AttandanceApproval.Text = String.Format("{0} details of {1}", objAttendanceApplication.EmployeeName, objAt);

                txt_EmpCode.Text = objAttendanceApplication.EmployeeCode;
                txt_EmpName.Text = objAttendanceApplication.EmployeeName;
                txt_Designation.Text = objAttendanceApplication.DesignationDescription;

                txt_AttendanceDate.Text = objAttendanceApplication.DateOfAttendance.ToShortDateString();
                txt_InTime.Text = objAttendanceApplication.InTime.ToString("HH:mm:ss");
                txt_OutTime.Text = objAttendanceApplication.OutTime.ToString("HH:mm:ss");
                
               
            


        }

        protected void ddl_AttendanceApproval_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Save.Text = " Leave " + ddl_AmmendmentStatus.Text;
        }

        protected void gridview_AttendanceApproves_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_AttendanceApproves.PageIndex = e.NewPageIndex;
            gridview_AttendanceApproves.DataBind();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int ProcReturnValue;
                AttendanceApplication TheAttendanceApplication = new AttendanceApplication();

                TheAttendanceApplication.AttendanceApplicationID = AttendanceApplicationID;

                TheAttendanceApplication.Status = ddl_AmmendmentStatus.SelectedValue;

                TheAttendanceApplication.ApproveDate = DateTime.Now.Date;
                TheAttendanceApplication.ApprovalOrRejectionReason = txt_Reason.Text;

                ProcReturnValue = AttendanceApplicationManagement.ApproveOrRejectAttendanceApplication(TheAttendanceApplication);
                if (ProcReturnValue > 0)
                {
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", String.Format("alert('successfully {0} the leave application.');", TheLeaveApplication.Status), true);
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_ATTENDANCEAPPLICATION_APRPOVED");

                    dialog_Message.Show();
                    BindGridLeaveApplicationsToApproveReject();
                    ResetTextBoxes();
                }
                else if (ProcReturnValue < 0)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_ATTENDANCEAPPLICATION_APRPOVED");
                    BindGridLeaveApplicationsToApproveReject();
                    dialog_Message.Show();
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Sorry! failed to approve / reject the leave application.');", true);
                    ResetTextBoxes();
                }
                EnableDisableCommandButtons(false);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
            EnableDisableCommandButtons(false);
        }

        #endregion

        #region Methods & Implementation

        private void SetValidationMessages()
        {

            RequiredFieldValidator_AttendanceApproval.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Approval Selection");
            RequiredFieldValidator_AttendanceApproval.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            RequiredFieldValidator_AttendanceApproval.CssClass = theClassName;
        }

        private void BindDropdown()
        {
            BindDropdown_ApprovedType();
            BindDropdown_AppendSelectToFirst();
        }

        private void BindDropdown_AppendSelectToFirst()
        {


            ddl_AmmendmentStatus.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void BindDropdown_ApprovedType()
        {
            ddl_AmmendmentStatus.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.ApprovalStatus.GetStringValue());
            ddl_AmmendmentStatus.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_AmmendmentStatus.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_AmmendmentStatus.DataBind();
        }

        private void ResetTextBoxes()
        {
            txt_EmpName.Text = string.Empty;
            txt_EmpCode.Text = string.Empty;
            txt_AttendanceDate.Text = string.Empty;
            txt_Designation.Text = string.Empty;

            txt_OutTime.Text = string.Empty;
            txt_InTime.Text = string.Empty;
            txt_Reason.Text = string.Empty;

            ddl_AmmendmentStatus.SelectedIndex = 0;

        }

        private void BindGridLeaveApplicationsToApproveReject(string searchText = "")
        {
            try
            {

                PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
                Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
                List<AttendanceApplication> theAttendanceApplication = new List<AttendanceApplication>();
                theAttendanceApplication = AttendanceApplicationManagement.GetPeningAttendanceApplicationsByReportingEmployee(TheEmployee.EmployeeID);
                   // AttendanceAmendmentManagement.GetPeningAttendanceAmendmentApplicationsByReportingEmployee(TheEmployee.EmployeeID);

                string TheMessage;

                if (!(theAttendanceApplication.Count.Equals(0)))
                {
                    TheMessage = String.Format("<div id='LeaveCount'>Total No. of Attendance Applications(s) to approve:<b>{0}</b> </div> ", theAttendanceApplication.Count);


                    gridview_AttendanceApproves.DataSource = theAttendanceApplication;
                    gridview_AttendanceApproves.DataBind();
                }
                else
                {
                    TheMessage = "<div id='BiggerTextInformation'>There are no Attendance applications to approve/reject at this moment.<div>";
                }
                lit_Message.Text = TheMessage;

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        private void EnableDisableCommandButtons(bool enableDisableFlag)
        {
            btn_Save.Enabled = enableDisableFlag;
            btn_Cancel.Enabled = enableDisableFlag;

        }
        #endregion
    
    }
}