using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Framework.ReadXML;
using System.Linq;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace Micro.WebApplication.MicroERP.HRMS
{
	public partial class LeaveApplications : BasePage
	{

		#region Declaration
		protected static class PageVariables
		{
			public static int TheUserReferenceID;
		}

		static int LeaveApplicationID;
		List<LeaveTypeSettings> LeaveBalanceList = new List<LeaveTypeSettings>();
		#endregion

		#region Event
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				FillGridView();
                SetValidationMessages();
                DataBindDropDownList();
                BindDropdown_AppendSelectToFirst(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
				lblStatus.Text = string.Empty;
			}
			//((UC_Menu)Master.FindControl("ctrl_Menu")).SetActiveIndex = 3;
		}
       
        private void BindDropdown_AppendSelectToFirst(string ddlDefaultItem)
        {

            ddl_LeaveDescription.Items.Insert(0, ddlDefaultItem);
        }
        
		protected void lnkEdit_Click(object sender, EventArgs e)
		{
			
			PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
			Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
			LinkButton TheLinkBtn = (LinkButton)sender;
            btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
			btn_LeaveCancel.Visible = true;

			LeaveApplicationID = int.Parse(TheLinkBtn.CommandArgument);
			LeaveApplication LType = new LeaveApplication();
			LType = LeaveApplicationManagement.GetLeaveApplicationByLeaveApplicationID(LeaveApplicationID);


			if (LType.Status != "Pending")
			{
				ddl_LeaveDescription.Text = LType.LeaveTypeDescription;
				ddl_LeaveDescription.Enabled = false;
				txt_FromDate.Text = LType.DateFrom.ToShortDateString();
				txt_FromDate.Enabled = false;
				txt_Todate.Text = LType.DateTo.ToShortDateString();
				txt_Todate.Enabled = false;
				txt_Reason.Text = LType.ApplicationReason;
				txt_Reason.Enabled = false;
				txt_Status.Text = LType.Status;
				txt_ApprovedBy.Text = LType.ApprovedByEmployeeName;
				txt_RemarksDetails.Text = LType.ApprovalOrRejectionReason;

                btn_Save.Visible = false;

			}
			else
			{
				ddl_LeaveDescription.Text = LType.LeaveTypeDescription;
				txt_FromDate.Text = LType.DateFrom.ToShortDateString();
				txt_Todate.Text = LType.DateTo.ToShortDateString();

				txt_Reason.Text = LType.ApplicationReason;
				txt_Status.Text = LType.Status;
				txt_ApprovedBy.Text = "";
				txt_RemarksDetails.Text = "";
                btn_Save.Visible = true;
                txt_Todate_TextChanged( sender,  e);
			}


		}

        protected void lnkCancel_Click(object sender, EventArgs e)
		{

            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
           
            LeaveBalanceList = LeaveBalanceManagement.GetLeaveBalanceByEmployee(TheEmployee.EmployeeID);
            LinkButton TheLinkBtn = (LinkButton)sender;
            LeaveApplicationID = int.Parse(TheLinkBtn.CommandArgument);
            LeaveApplication LType = new LeaveApplication();

           int ProcReturnValue = 0;

           LType = LeaveApplicationManagement.GetLeaveApplicationByLeaveApplicationID(LeaveApplicationID);
             if (LType.Status == "Pending")
             {
               LeaveApplication LeaveApplicationObject = new LeaveApplication();
                
               LeaveApplicationObject.EmployeeID = TheEmployee.EmployeeID;
               LeaveApplicationObject.ApplicationReason = txt_Reason.Text;
               LeaveApplicationObject.Status = "Pending";
                
                 if (LeaveApplicationID > 0)
                  {
                     LeaveApplicationObject.LeaveApplicationID = LeaveApplicationID;
                     ProcReturnValue = LeaveApplicationManagement.DeletetLeaveApplication(LeaveApplicationObject);
                     lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_LEAVEAPPLICATION_DELETED");
                    
                     dialog_Message.Show();
                    // ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "alert('Leave Application Deleted Successfully');", true);
                     btn_LeaveCancel.Visible = false;
                     FillGridView();
                  }
              }
               else
              {
                  lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_LEAVEAPPLICATION_DELETED");
                  dialog_Message.Show();
                  // ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "alert('Leave Application n't Cancelled Due to Approved/Cancelled');", true);

             }
		}

		protected void gridview_LeaveApplyBalance_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gridview_LeaveApplyBalance.PageIndex = e.NewPageIndex;
			FillGridView();
		}

		protected void gridview_LeaveApplyBalanceShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gridview_LeaveApplyBalanceShow.PageIndex = e.NewPageIndex;
			FillGridView();
		}

        protected void btn_Save_Click(object sender, EventArgs e)
		{
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
         
            if (ValidateFormFields())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = InsertRecord();
                    ResetTextBoxes(string.Empty);
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Leave Application", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateRecord();
                    btn_LeaveCancel_Click(sender, e);
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Leave Application", MicroEnums.DataOperation.Edit);
                }
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    FillGridView();
                    
                }
                
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
		}

		protected void btn_LeaveCancel_Click(object sender, EventArgs e)
		{
			LeaveApplicationID = -1;

            ResetTextBoxes(string.Empty);
			//btn_LeaveCancel.Visible = false;
			txt_RemarksDetails.Text = "";
			txt_ApprovedBy.Text = "";
            txt_Status.Text = string.Empty;
            txt_ApprovedBy.Text = string.Empty;
            txt_RemarksDetails.Text = string.Empty;
			//EnableDisableUserInputs(true);
            btn_Save.Visible = true;
            btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();


         
            ddl_LeaveDescription.Enabled = true;
            txt_FromDate.Enabled = true;
            txt_Todate.Enabled = true;
            txt_Reason.Enabled = true;
          
		}

		protected void ddl_LeaveDescription_SelectedIndexChanged(object sender, EventArgs e)
		{
			return;
		}

		protected void txt_Todate_TextChanged(object sender, EventArgs e)
		{

            try
            {
                DateTime DateFrom = DateTime.Parse(txt_FromDate.Text);
                DateTime DateTo = DateTime.Parse(txt_Todate.Text);
                if (DateFrom > DateTo)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Failure", "alert('Error: Invalid Date :-\n To Date Is greater than From Date');", true);
                    txt_Count.Text = "";
                    txt_Todate.Text = "";
                }
                TimeSpan DateDifference = DateTo.Subtract(DateFrom);

                txt_Count.Text = (DateDifference.TotalDays + 1).ToString();
            }
            catch (Exception ex)
            {
               
            }

		}

		#endregion

		#region Interface Implementation
		private void FillGridView()
		{
			
			PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
			Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);

			txt_From.Text = TheEmployee.EmailID;

			//*******************************//
			//To Get emailAddress his/her supervisor
			List<Employee> ReporttingEmployeeList = new List<Employee>();
			ReporttingEmployeeList = EmployeeManagement.GetInstance.GetReportingEmployeesEmailAllByEmployee(TheEmployee.EmployeeID);


			foreach (Employee emp in ReporttingEmployeeList)
			{
				string email = emp.EmailID;
				txt_To.Text = email;
			}
			
			List<LeaveTypeSettings> LeaveBalanceList;
			LeaveBalanceList = LeaveBalanceManagement.GetLeaveBalanceByEmployee(TheEmployee.EmployeeID);
			gridview_LeaveApplyBalance.DataSource = LeaveBalanceList;
			gridview_LeaveApplyBalance.DataBind();

			List<LeaveApplication> LeaveApplicationLists = new List<LeaveApplication>();
			LeaveApplicationLists = LeaveApplicationManagement.GetEmployeeLeaveApplicationsAll(TheEmployee.EmployeeID);
			gridview_LeaveApplyBalanceShow.DataSource = LeaveApplicationLists;
			gridview_LeaveApplyBalanceShow.DataBind();

		}
		#endregion

		#region Methods & Implementation

        private int InsertRecord()
        {
            int ProcReturnValue = 0;
            LeaveApplication TheLeaveApplication = new LeaveApplication();
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            LeaveBalanceList = LeaveBalanceManagement.GetLeaveBalanceByEmployee(TheEmployee.EmployeeID);
            var LeaveBalance = (from st in LeaveBalanceList
                                where st.LeaveTypeDescription == ddl_LeaveDescription.Text
                                select st.TotalNumberOfLeavesElligibleToAvail).First();

            int TotalLeaveBalance = LeaveBalance;
            LeaveBalance = (from st in LeaveBalanceList
                            where st.LeaveTypeDescription == ddl_LeaveDescription.Text
                            select st.NumberOfConsecutiveDaysAllowed).First();


            LeaveBalance = (from st in LeaveBalanceList
                            where st.LeaveTypeDescription == ddl_LeaveDescription.Text
                            select st.LeaveTypeID).First();
            int LeaveTypeID = LeaveBalance;
            if (txt_Count.Text == "")
            {
                txt_Count.Text = "0";
            }

            TheLeaveApplication.EmployeeID = TheEmployee.EmployeeID;
            TheLeaveApplication.LeaveTypeID = LeaveTypeID;
            TheLeaveApplication.LeaveTypeDescription = ddl_LeaveDescription.SelectedItem.ToString();
            TheLeaveApplication.DateApplied = DateTime.Today.Date;
            TheLeaveApplication.DateFrom = DateTime.Parse(txt_FromDate.Text);
            TheLeaveApplication.DateTo = DateTime.Parse(txt_Todate.Text);
            TheLeaveApplication.ApplicationReason = txt_Reason.Text;
            TheLeaveApplication.Status = "Pending";

            ProcReturnValue = LeaveApplicationManagement.InsertLeaveApplication(TheLeaveApplication);
            if (ProcReturnValue > 0)
            {
                //=========================================================
                // SENDING THE LEAVE REQUEST MAIL TO THE SUPERVISOR
                //=========================================================
                SendLeaveRequestMail(TheEmployee, TheLeaveApplication);
                //==========================================================
            }
            return ProcReturnValue;
        }

        private string GetHtmlTemplateCode()
        {
            string htmlCode = string.Empty;
            string sFileName = Server.MapPath(".") + @"\..\..\MailMessage.htm";
            if (System.IO.File.Exists(sFileName))
            {
                WebClient client = new WebClient();
                htmlCode = client.DownloadString(sFileName);
            }
            return htmlCode;
        }


        private void SendLeaveRequestMail(Employee TheEmployee, LeaveApplication TheLeaveRequest)
        {
            try
            {
                string AppNamdAndVersion = Micro.WebApplication.App_MasterPages.Micro_Website.GetAppNameWithVersion();
                string MailSubject = ReadXML.GetGeneralMessage("LEAVE_APPLICATION_MAIL_SUBJECT", false).Replace("#APP#", AppNamdAndVersion.ToUpper());
                string MailBody = string.Format("YOUR FULL NAME : {0}<br/> EMPLOYEE CODE : {1} <br/> DEPARTMENT DESCRIPTION : {2} <br/> DESIGNATION DESCRIPTION : {3} <br/> LEAVE DESCRIPTION : {4} <br/> DATE FROM : {5} <br/> DATE TO : {6} <br/> REASON: <B>{7}</B>", TheEmployee.EmployeeName, TheEmployee.EmployeeCode, TheEmployee.DepartmentDescription, TheEmployee.DesignationDescription, TheLeaveRequest.LeaveTypeDescription, TheLeaveRequest.DateFrom.ToShortDateString(), TheLeaveRequest.DateTo.ToShortDateString(), txt_Reason.Text);

                MailMessage eMail = new MailMessage();
                eMail.To.Add(new MailAddress(txt_To.Text));
                eMail.Subject = MailSubject;
                eMail.Body = MailBody;

                string emailContent = GetHtmlTemplateCode();

                lit_Message.Text = string.Format("<font color='#003500'>{0} to user '{1}' on his/her email address '{2}'</font>",
                                Micro.Commons.SendMail.SendEmail(eMail, emailContent),
                               TheEmployee.EmployeeName, TheEmployee.EmailID);
            }
            catch (Exception ex)
            {
                //string theFailureMessage = string.Concat(ReadXML.GetFailureMessage("PASSWORD_NOT_SEND"), " </br></br> Reason:", ex.Message.ToString());

                lit_Message.Text = string.Format("<font color='#990000'>Failed to send an email to user '{0}' on his/her email address '{1}'.<br/><br/> Reason: '{2}'</font>",
                                                                    TheEmployee.EmployeeName,
                                                                    TheEmployee.EmailID,
                                                                    ex.Message.ToString());
            }












        }

        private int UpdateRecord()
        {
            int ProcReturnValue = 0;
            LeaveApplication TheLeaveApplication = new LeaveApplication();

            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            LeaveBalanceList = LeaveBalanceManagement.GetLeaveBalanceByEmployee(TheEmployee.EmployeeID);
            var LeaveBalance = (from st in LeaveBalanceList
                                where st.LeaveTypeDescription == ddl_LeaveDescription.Text
                                select st.TotalNumberOfLeavesElligibleToAvail).First();

          
            LeaveBalance = (from st in LeaveBalanceList
                            where st.LeaveTypeDescription == ddl_LeaveDescription.Text
                            select st.NumberOfConsecutiveDaysAllowed).First();


            LeaveBalance = (from st in LeaveBalanceList
                            where st.LeaveTypeDescription == ddl_LeaveDescription.Text
                            select st.LeaveTypeID).First();
            int LeaveTypeID = LeaveBalance;

           TheLeaveApplication.LeaveApplicationID = LeaveApplicationID;
           TheLeaveApplication.LeaveTypeID = LeaveTypeID;
           TheLeaveApplication.LeaveTypeDescription = ddl_LeaveDescription.SelectedItem.ToString();
           TheLeaveApplication.DateApplied = DateTime.Today.Date;
           TheLeaveApplication.DateFrom = DateTime.Parse(txt_FromDate.Text);
           TheLeaveApplication.DateTo = DateTime.Parse(txt_Todate.Text);
           TheLeaveApplication.ApplicationReason = txt_Reason.Text;
           TheLeaveApplication.Status = "Pending";

           ProcReturnValue = LeaveApplicationManagement.UpdateLeaveApplication(TheLeaveApplication);


            return ProcReturnValue;
        }

        private bool ValidateFormFields()
        {
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            bool ReturnValue = true;

            ReturnValue = ValidateFormFieldsLeaveBalance();

            if (ReturnValue)

                ReturnValue = ValidDateRange(TheEmployee.EmployeeID, txt_FromDate.Text);

            return ReturnValue;
        }

        private bool ValidateFormFieldsLeaveBalance()
        {
            bool ReturnValue = true;
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            LeaveBalanceList = LeaveBalanceManagement.GetLeaveBalanceByEmployee(TheEmployee.EmployeeID);
            var LeaveBalance = (from st in LeaveBalanceList
                                where st.LeaveTypeDescription == ddl_LeaveDescription.Text
                                select st.TotalNumberOfLeavesElligibleToAvail).First();

            int TotalLeaveBalance = LeaveBalance;
            LeaveBalance = (from st in LeaveBalanceList
                            where st.LeaveTypeDescription == ddl_LeaveDescription.Text
                            select st.NumberOfConsecutiveDaysAllowed).First();


            if (TotalLeaveBalance < int.Parse(txt_Count.Text))
            {
                lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_INSUFFICIENT_LEAVEBALANCE");
                ReturnValue = false;

            }
            else
            {
                ReturnValue = true;
            }

            return ReturnValue;
        }

        private void EnableDisableUserInputs(bool enableState = false)
        {
            ddl_LeaveDescription.Enabled = enableState;
            txt_FromDate.Enabled = enableState;
            txt_Todate.Enabled = enableState;
            txt_Reason.Enabled = enableState;
        }

		private void ResetTextBoxes(string empty)
		{
            txt_FromDate.Text = empty;
            txt_Todate.Text = empty;
            txt_Count.Text = empty;
            txt_Reason.Text = empty;
            ddl_LeaveDescription.SelectedIndex = 0;
		}

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_FromDate.CssClass = theClassName;
            regularExpressionValidator_FromDate.ValidationExpression = MicroConstants.REGEX_DATE;

            requiredFieldValidator_Todate.CssClass = theClassName;
            regularExpressionValidator_Todate.ValidationExpression = MicroConstants.REGEX_DATE;
            requiredFieldValidator_LeaveDescription.CssClass = theClassName;
        }
       
        private void SetValidationMessages()
        {
            requiredFieldValidator_LeaveDescription.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_FromDate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "FromDate");

            regularExpressionValidator_Todate.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            regularExpressionValidator_Todate.ValidationExpression = MicroConstants.REGEX_DATE;
            requiredFieldValidator_LeaveDescription.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "LeaveDescription");


            requiredFieldValidator_Todate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "ToDate");

            regularExpressionValidator_Todate.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");
            regularExpressionValidator_Todate.ValidationExpression = MicroConstants.REGEX_DATE;

            SetFormMessageCSSClass("ValidateMessage");

        }
      
        private void DataBindDropDownList()
        {
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
            List<LeaveTypeSettings> LeaveBalanceList;
            LeaveBalanceList = LeaveBalanceManagement.GetLeaveBalanceByEmployee(TheEmployee.EmployeeID);
            gridview_LeaveApplyBalance.DataSource = LeaveBalanceList;
            gridview_LeaveApplyBalance.DataBind();


            var LeaveTypeDescriptionList = from st in LeaveBalanceList
                                           select st.LeaveTypeDescription;
            ddl_LeaveDescription.DataSource = LeaveTypeDescriptionList;
            ddl_LeaveDescription.DataMember = "LeaveTypeDescription";
            ddl_LeaveDescription.DataBind();
        }
		
        private bool ValidDateRange(int employeeID, string fromDate)
		{
			bool ReturnValue = true;
			List<LeaveApplication> thisLeaveApplicationList = LeaveApplicationManagement.GetEmployeePendingLeaveApplicationsAll(employeeID);

			if (thisLeaveApplicationList.Count > 0)
			{
				var LastApplication = thisLeaveApplicationList.OrderBy(leave=>leave.DateAdded).LastOrDefault();

				if (LastApplication.Status != MicroEnums.ApprovalStatus.Rejected.GetStringValue())
				{
					if (Convert.ToDateTime(fromDate) <= LastApplication.DateTo)
					{
						ReturnValue = false;
                        string DateRange = string.Concat(LastApplication.DateFrom.ToString(MicroConstants.DateFormat.ToString()), " to ", LastApplication.DateFrom.ToString(MicroConstants.DateFormat.ToString()));
                        if (LastApplication.Status.Equals(MicroEnums.ApprovalStatus.Pending.GetStringValue()))
						{
                            lbl_TheMessage.Text = string.Concat("Already a application avail with Pending status from date ", DateRange);
						}
                        else if (LastApplication.Status.Equals(MicroEnums.ApprovalStatus.Approved.GetStringValue()))
						{
                            lbl_TheMessage.Text = string.Concat("Already a application avail with Approved status from date ", DateRange);
						}


					}
				}
			}
			return ReturnValue;
		}
		#endregion
	
    
    }
}