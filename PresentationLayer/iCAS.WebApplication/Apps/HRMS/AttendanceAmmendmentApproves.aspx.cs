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
    public partial class AttendanceAmmendmentApproves : BasePage
	{
        #region Declaration

        protected static class PageVariables
        {
            public static List<AttendanceAmendment> TheAttendanceAmendmentList;
            public static string TheEmployeeID;
            public static string TheAttendanceAmendmentID;
            public static int TheUserReferenceID;

        }

        static int AttendanceAmendmentID;

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
            try
            {
                EnableDisableCommandButtons(true);

                LinkButton lnkBtn = (LinkButton)sender;
                AttendanceAmendmentID = int.Parse(lnkBtn.CommandArgument);
                AttendanceAmendment objAttendanceAmendment = new AttendanceAmendment();

                objAttendanceAmendment = AttendanceAmendmentManagement.GetAttendanceAmendmentByAttendanceAmendmentID(AttendanceAmendmentID);


                lbl_AttendanceAmmendmentApproval.Text = String.Format("{0} details of {1}",objAttendanceAmendment.EmployeeName,objAttendanceAmendment.AttendanceType);

                txt_EmpCode.Text = objAttendanceAmendment.EmployeeCode;
                txt_EmpName.Text = objAttendanceAmendment.EmployeeName;
                txt_Designation.Text = objAttendanceAmendment.DesignationDescription;

                txt_AttendanceDate.Text = objAttendanceAmendment.DateOfAttendance.ToShortDateString();
                txt_OldTime.Text = objAttendanceAmendment.OldTime.ToString("HH:mm:ss");
                txt_NewTime.Text = objAttendanceAmendment.NewTime.ToString("HH:mm:ss");
                txt_Reason.Text = objAttendanceAmendment.Reason;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            
        }

        protected void ddl_AttendanceApproval_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Save.Text = " Leave " + ddl_AttendanceApproval.Text;
        }

        protected void gridview_AttendanceAmmendmentApproves_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_AttendanceAmmendmentApproves.PageIndex = e.NewPageIndex;
            BindGridLeaveApplicationsToApproveReject();

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int ProcReturnValue;
                AttendanceAmendment TheAttendanceAmendment = new AttendanceAmendment();

                TheAttendanceAmendment.AttendanceAmendmentID = AttendanceAmendmentID;

                TheAttendanceAmendment.Status = ddl_AttendanceApproval.SelectedValue;
               
                TheAttendanceAmendment.ApproveDate = DateTime.Now.Date;
                TheAttendanceAmendment.ApprovalOrRejectionReason = txt_Reason.Text;

                ProcReturnValue = AttendanceAmendmentManagement.ApproveOrRejectAttendanceAmendment(TheAttendanceAmendment);
                if (ProcReturnValue > 0)
                {
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", String.Format("alert('successfully {0} the leave application.');", TheLeaveApplication.Status), true);
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_ATTENDANCEAMMENDMENTAPPLICATION_APRPOVED");

                    dialog_Message.Show();
                    BindGridLeaveApplicationsToApproveReject();
                    ResetTextBoxes();
                }
                else if (ProcReturnValue < 0)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_ATTENDANCEAMMENDMENTAPPLICATION_APRPOVED");
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

            ddl_AttendanceApproval.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void BindDropdown_ApprovedType()
        {
            ddl_AttendanceApproval.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.ApprovalStatus.GetStringValue());
            ddl_AttendanceApproval.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_AttendanceApproval.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_AttendanceApproval.DataBind();
        }

        private void ResetTextBoxes()
        {
            txt_EmpName.Text = string.Empty;
            txt_EmpCode.Text = string.Empty;
            txt_AttendanceDate.Text = string.Empty;
            txt_Designation.Text = string.Empty;
            txt_NewTime.Text = string.Empty;
            txt_OldTime.Text = string.Empty;
            txt_Reason.Text = string.Empty;

            ddl_AttendanceApproval.SelectedIndex = 0;

        }

        private void BindGridLeaveApplicationsToApproveReject(string searchText = "")
        {
            try
            {

                PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
                Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
                List<AttendanceAmendment> theAttendanceAmendment = new List<AttendanceAmendment>();
                theAttendanceAmendment = AttendanceAmendmentManagement.GetPeningAttendanceAmendmentApplicationsByReportingEmployee(TheEmployee.EmployeeID);
                    
                string TheMessage;

                if (!(theAttendanceAmendment.Count.Equals(0)))
                {
                    TheMessage = String.Format("<div id='LeaveCount'>Total No. of Attendance Ammendment(s) to approve:<b>{0}</b> </div> ", theAttendanceAmendment.Count);

                    gridview_AttendanceAmmendmentApproves.DataSource = theAttendanceAmendment;
                    gridview_AttendanceAmmendmentApproves.DataBind();
                }
                else
                {
                    TheMessage = "<div id='BiggerTextInformation'>There are no leave applications to approve/reject at this moment.<div>";
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