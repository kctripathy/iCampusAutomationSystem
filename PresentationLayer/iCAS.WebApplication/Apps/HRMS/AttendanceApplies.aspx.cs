using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.BusinessLayer.HumanResource;
using Micro.Objects.HumanResource;
using Micro.Framework.ReadXML;
using System.Web;
using System.Linq;

namespace Micro.WebApplication.MicroERP.HRMS
{
    public partial class AttendanceApplies : BasePage
	{
        #region Declaration
        protected static class PageVariables
        {
            public static Employee ThisEmployee;
            public static List<AttendanceApplication> AttendanceApplicationList;
            public static List<Employee> EmployeeList;
            //TODO: SUBRAT: Comment to this line because apply the attandance as per own loginid
            public static int TheUserReferenceID;
            public static AttendanceApplication ThisAttendanceApplication
            {
                get
                {
                    AttendanceApplication TheAttendanceApplication = HttpContext.Current.Session["ThisAttendanceApplication"] as AttendanceApplication;
                    return TheAttendanceApplication;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisAttendanceApplication", value);
                }
            }

        }


        static int AttendanceApplicationID;
        #endregion
       
        #region Event
      
        protected void Page_Load(object sender, EventArgs e)
        {
            BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
            ctrl_Search.SearchWhat = MicroEnums.SearchForm.AttendanceAmendment.ToString();
            if (!IsPostBack)
            {
                SetValidationMessages();
                BindDropdown();
                //TODO: SUBRAT: Comment to this line because apply the attandance as per own loginid
                FillGridView();

                multiView_AttandenceApplicationDetails.SetActiveView(view_GridView);
            }

		}


       

        protected void btn_ViewApplication_Click(object sender, EventArgs e)
        {
            FillGridView();
            multiView_AttandenceApplicationDetails.SetActiveView(view_GridView);
        }

        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
            SearchAttendanceApplicationBindGridView();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

     

        

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFields())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = InsertRecord();

                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Attendance Applicaion", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateRecord();

                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Attendance  Application", MicroEnums.DataOperation.Edit);
                }
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    FillGridView();
                    ResetTextBoxes();

                }


            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))

                dialog_Message.Show();

        }

        protected void gridview_AttendanceApply_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                gridview_AttendanceApply.PageIndex = e.NewPageIndex;
                FillGridView();
            }
            catch
            {
            }
        }

        protected void gridview_AttendanceApply_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                // EnabledisableButtons(true);
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_AttendanceApply.Rows[RowIndex].FindControl("lbl_AttendanceApplicationID")).Text);
                lbl_DataOperationMode.Text = String.Format("EDIT APPLICATION : {0} [{1}]", gridview_AttendanceApply.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

                PageVariables.ThisAttendanceApplication = AttendanceApplicationManagement.GetAttendanceApplicationByAttendanceApplicationID(RecordID);
                   
                if (e.CommandArgument.Equals("First"))
                {
                    RowIndex = 0;
                }
                else if (e.CommandArgument.Equals("Last"))
                {
                    RowIndex = gridview_AttendanceApply.PageCount - 1;
                }
                else
                {
                    RowIndex = Convert.ToInt32(e.CommandArgument);
                }

                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {

                    Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();

                    multiView_AttandenceApplicationDetails.SetActiveView(view_InputControls);
                    PopulatePageFields(PageVariables.ThisAttendanceApplication);
                    EnableControls(view_InputControls, true);
                    //ChangeBackColor(view_InputControls);
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = 0;

                    ProcReturnValue = DeleteRecord(PageVariables.ThisAttendanceApplication);
                    if (ProcReturnValue > 0)
                    {
                        lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_ATTENDANCEAMMENDMENT_DELETED");
                        FillGridView();
                        dialog_Message.Show();
                    }
                    else
                    {
                        lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_ATTENDANCEAMMENDMENT_DELETED");
                        dialog_Message.Show();
                    }
                }

                //else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                //{
                //    lbl_DataOperationMode.Text = String.Format("VIEW DCACCOUNT : {0} [{1}]", gridview_AttendanceAmmendmentApply.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
                //    multiView_DCAccounts.SetActiveView(view_InputControls);
                //    EnableControls(view_InputControls, false);
                //    PopulateFormFields(PageVariables.ThisDCAccount);
                //    EnabledisableButtons(false);

                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void gridview_AttendanceApply_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_AttendanceApply_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_AttendanceApply_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 8);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                    BasePage.GridViewToolTips(e, 7, 8);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
        }

        #endregion

        #region Methods & Implementations

        private void SetValidationMessages()
        {

           
            requiredFieldValidator_Reason.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Reason");
            requiredFieldValidator_AttendanceDate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Attandance Date");
            regularExpressionValidator_AttendanceDate.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");

            regularExpressionValidator_InTime.ValidationExpression = MicroConstants.REGEX_TIME;
            regularExpressionValidator_InTime.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_12_HOURS_FORMAT");


           
            regularExpressionValidator_OutTime.ValidationExpression = MicroConstants.REGEX_TIME;
            regularExpressionValidator_OutTime.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_12_HOURS_FORMAT");


            requiredFieldValidator_InTime.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "InTime");
            requiredFieldValidator_OutTime.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "OutTime");
               
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
        
            requiredFieldValidator_Reason.CssClass = theClassName;
            requiredFieldValidator_AttendanceDate.CssClass = theClassName;
            regularExpressionValidator_AttendanceDate.ValidationExpression = MicroConstants.REGEX_DATE;
            //regularExpressionValidator_InTime.CssClass = theClassName;
            requiredFieldValidator_InTime.CssClass = theClassName;
            
            
            regularExpressionValidator_OutTime.CssClass = theClassName;
            requiredFieldValidator_OutTime.CssClass = theClassName;
         
        }

        private void FillGridView()
        {
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);

            PageVariables.AttendanceApplicationList = AttendanceApplicationManagement.GetAttendanceApplicationsByEmployee(TheEmployee.EmployeeID);


            gridview_AttendanceApply.DataSource = PageVariables.AttendanceApplicationList;
            gridview_AttendanceApply.DataBind();

        }

        private void BindDropdown()
        {
            BindDropdown_AttendanceType();
            //BindDropdown_AppendSelectToFirst();
        }

       

        private void BindDropdown_AttendanceType()
        {

           
        }

        private void SearchAttendanceApplicationBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<AttendanceApplication> SearchList = new List<AttendanceApplication>();
            // Search by date
            if (PageVariables.AttendanceApplicationList.Count > 0)
            {
                if (searchField == MicroEnums.SearchAttendanceApplication.DateOfAttendance.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from attammend in PageVariables.AttendanceApplicationList
                                      where attammend.DateOfAttendance.ToString("dd-MMM-yyyy").Equals(searchText)
                                      select attammend).ToList();
                    }
                }
            }

            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();

            gridview_AttendanceApply.DataSource = SearchList;
            gridview_AttendanceApply.DataBind();
        }

        private bool ValidateFormFields()
        {
            bool ReturnValue = true;

            if (txt_AttendanceDate.Text == string.Empty)
            {
                dialog_Message.Show();
                lbl_TheMessage.Text = "Attendance Date can't left blank";
                txt_AttendanceDate.Focus();
                ReturnValue = false;
            }
            else if (DateTime.Parse(txt_AttendanceDate.Text) == DateTime.Today.Date)
            {
                dialog_Message.Show();
                lbl_TheMessage.Text = "Application Not Allowed For Running Day/Today!!";
                txt_AttendanceDate.Focus();
                ReturnValue = false;

            }
            return ReturnValue;
        }

        private int InsertRecord()
        {
            int ProcReturnValue = 0;
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
           // AttendanceAmendment TheAttendanceAmendment = new AttendanceAmendment();
            AttendanceApplication TheAttendanceApplication = new AttendanceApplication();
            TheAttendanceApplication.EmployeeID = TheEmployee.EmployeeID;
            TheAttendanceApplication.DateOfAttendance = DateTime.Parse(txt_AttendanceDate.Text);
            TheAttendanceApplication.InTime = DateTime.Parse(txt_InTime.Text);
            TheAttendanceApplication.OutTime = DateTime.Parse(txt_OutTime.Text);

            TheAttendanceApplication.ApplicationReason = txt_Reason.Text;

            ProcReturnValue = AttendanceApplicationManagement.InsertAttendanceApplication(TheAttendanceApplication);
              

            return ProcReturnValue;

        }

        private int UpdateRecord()
        {
            int ProcReturnValue = 0;



            PageVariables.ThisAttendanceApplication.DateOfAttendance = DateTime.Parse(txt_AttendanceDate.Text);
           
            PageVariables.ThisAttendanceApplication.InTime = DateTime.Parse(txt_InTime.Text);
            PageVariables.ThisAttendanceApplication.OutTime = DateTime.Parse(txt_OutTime.Text);
            PageVariables.ThisAttendanceApplication.ApplicationReason = txt_Reason.Text;

            ProcReturnValue = AttendanceApplicationManagement.UpdateAttendanceApplication(PageVariables.ThisAttendanceApplication);
                

            return ProcReturnValue;
        }

        private void ResetTextBoxes()
        {

            txt_AttendanceDate.Text = string.Empty;
            txt_AttendanceDate.Text = string.Empty;
            txt_InTime.Text = string.Empty;
            txt_OutTime.Text = string.Empty;
            AttendanceApplicationID = -1;
            txt_Reason.Text = string.Empty;
            txt_ApprovedBy.Text = "";
        txt_Status.Text = string.Empty;
        txt_ApprovedBy.Text = string.Empty;
         txt_Remarks.Text = string.Empty;

            Btn_Save.Visible = true;
            Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
        }

        private void PopulatePageFields(AttendanceApplication theAttendanceApplication)
        {
            if (theAttendanceApplication.Status != "Pending")
            {
                txt_AttendanceDate.Text = theAttendanceApplication.DateOfAttendance.ToShortDateString();

                txt_InTime.Text = theAttendanceApplication.InTime.ToString("h:mm tt"); ;
                txt_OutTime.Text = theAttendanceApplication.OutTime.ToString("h:mm tt"); ;
                txt_Reason.Text = theAttendanceApplication.ApplicationReason;
                txt_AttendanceDate.Enabled = false;
                txt_OutTime.Enabled = false;
                txt_InTime.Enabled = false;
                txt_Reason.Enabled = false;
              txt_Status.Text = theAttendanceApplication.Status;
                txt_ApprovedBy.Text = theAttendanceApplication.ApprovedByEmployeeName;
              txt_Remarks.Text = theAttendanceApplication.ApprovalOrRejectionReason;

                Btn_Save.Visible = false;

            }
            else
            {
                //(tmEditInTime.Text == "01-01-0001 00:00:00" ? "" : DateTime.Parse(tmEditInTime.Text).ToString("HH:mm:ss"));
                txt_AttendanceDate.Text = theAttendanceApplication.DateOfAttendance.ToShortDateString();
               
                txt_InTime.Text = theAttendanceApplication.InTime.ToString("h:mm tt");
                txt_OutTime.Text = theAttendanceApplication.OutTime.ToString("h:mm tt");
                txt_Reason.Text = theAttendanceApplication.ApplicationReason;
                //txt_Status.Text = theAttendanceApplication.Status;

              //  txt_ApprovedBy.Text = "";
                //txt_Remarks.Text = "";
                Btn_Save.Visible = true;

            }


            //txt_DepartmentDescription.Text = theDepartment.DepartmentDescription;
            //ddl_ParentDepartment.SelectedIndex = GetDropDownSelectedIndex(ddl_ParentDepartment, Convert.ToString(theDepartment.ParentDepartmentId));
        }


        public static int DeleteRecord(AttendanceApplication theAttendanceApplication)
        {
            int ProcReturnValue = AttendanceApplicationManagement.DeletetAttendanceApplication(theAttendanceApplication);
                

            return ProcReturnValue;
        }
        #endregion

        protected void btn_AddApplication_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();

            multiView_AttandenceApplicationDetails.SetActiveView(view_InputControls);
        }

        protected void btn_GetAttandance_Click(object sender, EventArgs e)
        {
            if (ValidateFormFields())
            {
                PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
                Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);

                Attendance objAttendance = new Attendance();
                objAttendance = AttendanceManagement.GetInstance.GetEmployeeAttendanceByDate(TheEmployee.EmployeeID, DateTime.Parse(txt_AttendanceDate.Text));

                if (objAttendance != null)
                {
                    txt_InTime.Text = objAttendance.InTime.ToString();
                    txt_OutTime.Text = objAttendance.OutTime.ToString();
                    if (!txt_InTime.Text.Contains("00:00:00") && txt_InTime.Text != "")
                    {
                        
                        txt_InTime.Text = DateTime.Parse(txt_InTime.Text).ToString("HH:mm");
                    }
                    if (!txt_OutTime.Text.Contains("00:00:00") && txt_OutTime.Text != "")
                    {
                        txt_OutTime.Text = DateTime.Parse(txt_OutTime.Text).ToString("HH:mm");
                    }
                    
                   

                }

                else
                {

                    dialog_Message.Show();
                    lbl_TheMessage.Text = "Employee did not punch for on !!" + txt_AttendanceDate.Text;
                }
            }

        }
       
    }
}