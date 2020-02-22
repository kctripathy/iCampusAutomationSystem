using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Framework.ReadXML;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS
{
    public partial class LeaveApprovals : BasePage
    {
        #region Declaration
       
        protected static class PageVariables
        {
            public static List<LeaveApplication> TheLeaveApplicationList;
            public static string TheEmployeeID;
            public static string TheLEaveApplicationID;
            public static int TheUserReferenceID;

        }
        
        static int LeaveApplicationID;
       
        #endregion 
       
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                EnableDisableCommandButtons(false);
                BindGridLeaveApplicationsToApproveReject();
            }
        }
        
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisableCommandButtons(true);

                LinkButton lnkBtn = (LinkButton)sender;
                LeaveApplicationID = int.Parse(lnkBtn.CommandArgument);
                LeaveApplication objLeaveAppln = new LeaveApplication();
                objLeaveAppln = LeaveApplicationManagement.GetLeaveApplicationByLeaveApplicationID(LeaveApplicationID);

                lbl_LeaveShowHistoyrDetails.Text = String.Format("{0} details of {1}", objLeaveAppln.LeaveTypeDescription, objLeaveAppln.EmployeeName);

                txt_LeaveDescription.Text = objLeaveAppln.LeaveTypeDescription;
                txt_FromDate.Text = objLeaveAppln.DateFrom.ToShortDateString();
                txt_ToDate.Text = objLeaveAppln.DateTo.ToShortDateString();
                txt_Reason.Text = objLeaveAppln.ApplicationReason;

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddl_LeaveStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Save.Text = " Leave " + ddl_LeaveStatus.Text;
        }

        protected void gridview_LeaveApproveBalanceShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_LeaveApproveBalanceShow.PageIndex = e.NewPageIndex;
            BindGridLeaveApplicationsToApproveReject();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int ProcReturnValue;
                LeaveApplication TheLeaveApplication = new LeaveApplication();
              
                   TheLeaveApplication. LeaveApplicationID = LeaveApplicationID;
                    TheLeaveApplication.Status = ddl_LeaveStatus.SelectedValue;
                    TheLeaveApplication.ApproveDate = DateTime.Now.Date;
                    TheLeaveApplication.ApprovalOrRejectionReason = txt_Remarks.Text;

                    ProcReturnValue = LeaveApplicationManagement.ApproveOrRejectLeaveApplication(TheLeaveApplication);
                    if (ProcReturnValue > 0)
                {
                   // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", String.Format("alert('successfully {0} the leave application.');", TheLeaveApplication.Status), true);
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_LEAVEAPPLICATION_APRPOVED");

                    dialog_Message.Show();
                     BindGridLeaveApplicationsToApproveReject();
                    ResetTextBoxes();
                }
                    else if (ProcReturnValue < 0)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_LEAVEAPPLICATION_APRPOVED");
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
        private void ResetTextBoxes()
        {
            txt_LeaveDescription.Text = "";
            txt_FromDate.Text = "";
            txt_ToDate.Text = "";
            txt_Remarks.Text = "";
            txt_Reason.Text = "";
            ddl_LeaveStatus.SelectedValue = "--Select--";

        }

        private void BindGridLeaveApplicationsToApproveReject(string searchText = "")
        {
            try
            {

                PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
                Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
                List<LeaveApplication> LeaveApplications = new List<LeaveApplication>();
                LeaveApplications = LeaveApplicationManagement.GetPeningApplicationsAllByReportingEmployee(TheEmployee.EmployeeID);
                string TheMessage;

                if (!(LeaveApplications.Count.Equals(0)))
                {
                    TheMessage = String.Format("<div id='LeaveCount'>Total No. of Leaves(s) to approve:<b>{0}</b> </div> ", LeaveApplications.Count);
                    gridview_LeaveApproveBalanceShow.DataSource = LeaveApplications;
                    gridview_LeaveApproveBalanceShow.DataBind();
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