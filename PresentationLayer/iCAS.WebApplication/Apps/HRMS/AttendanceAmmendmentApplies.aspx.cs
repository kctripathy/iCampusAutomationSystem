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
    public partial class AttendanceAmmendmentApplies : BasePage
	{
        #region Declaration
        protected static class PageVariables
        {
            public static Employee ThisEmployee;
            public static List<AttendanceAmendment> AttendanceAmendmentList;
            public static List<Employee> EmployeeList;
            //TODO: SUBRAT: Comment to this line because apply the attandance as per own loginid
            public static int TheUserReferenceID;
            public static AttendanceAmendment ThisAttendanceAmendment
            {
                get
                {
                    AttendanceAmendment TheAttendanceAmendment = HttpContext.Current.Session["ThisAttendanceAmendment"] as AttendanceAmendment;
                    return TheAttendanceAmendment;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisAttendanceAmendment", value);
                }
            }
            
        }
       

        static int AttendanceAmendmentApplicationID;
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

                multiView_AttandenceAmmendmentApplicationDetails.SetActiveView(view_GridView);
            }
            
		}

        protected void btn_AddApplication_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();

            multiView_AttandenceAmmendmentApplicationDetails.SetActiveView(view_InputControls);
        }

        protected void btn_ViewApplication_Click(object sender, EventArgs e)
        {
            FillGridView();
            multiView_AttandenceAmmendmentApplicationDetails.SetActiveView(view_GridView);
        }

        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
          SearchAttendanceAmendmentBindGridView();
        }
        
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
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
                        if (ddl_AttendanceType.SelectedIndex == 1)
                        {
                            txt_OldTime.Text = objAttendance.InTime.ToString();
                        }
                        else if (ddl_AttendanceType.SelectedIndex == 2)
                        {
                            txt_OldTime.Text = objAttendance.OutTime.ToString();
                        }

                        if (!txt_OldTime.Text.Contains("00:00:00") && txt_OldTime.Text != "")
                        {
                            txt_OldTime.Text = DateTime.Parse(txt_OldTime.Text).ToString("h:mm tt");

                            txt_NewTime.Enabled = true;
                            txt_Reason.Enabled = true;
                            txt_NewTime.Focus();
                        }

                    }

                    else
                    {

                        dialog_Message.Show();
                        lbl_TheMessage.Text = "Employee did not punch for!!" + ddl_AttendanceType.Text + "Time";
                    }
            }

        }

        //protected void lnkEdit_Click(object sender, EventArgs e)
        //{


        //    LinkButton TheLinkBtn = (LinkButton)sender;
        //    Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
        //    AttendanceAmendmentApplicationID = int.Parse(TheLinkBtn.CommandArgument);

        //    AttendanceAmendment theAttendanceAmendment = new AttendanceAmendment();
        //    theAttendanceAmendment = AttendanceAmendmentManagement.GetAttendanceAmendmentByAttendanceAmendmentID(AttendanceAmendmentApplicationID);
               
        //    if (theAttendanceAmendment.Status != "Pending")
        //    {
        //        txt_AttendanceDate.Text = theAttendanceAmendment.DateOfAttendance.ToShortDateString();

        //        txt_OldTime.Text = theAttendanceAmendment.OldTime.ToString("HH:mm:ss");
        //        txt_NewTime.Text = theAttendanceAmendment.NewTime.ToString("HH:mm:ss");
        //        txt_Reason.Text = theAttendanceAmendment.Reason;
        //        txt_AttendanceDate.Enabled = false;

        //        txt_NewTime.Enabled = false;
        //        txt_Reason.Enabled = false;
        //        txt_Status.Text = theAttendanceAmendment.Status;
        //        txt_ApprovedBy.Text = theAttendanceAmendment.ApprovedByEmployeeName;
        //        txt_Remarks.Text = theAttendanceAmendment.ApprovalOrRejectionReason;

        //        Btn_Save.Visible = false;

        //    }
        //    else
        //    {
        //        //(tmEditInTime.Text == "01-01-0001 00:00:00" ? "" : DateTime.Parse(tmEditInTime.Text).ToString("HH:mm:ss"));
        //        txt_AttendanceDate.Text = theAttendanceAmendment.DateOfAttendance.ToShortDateString();
        //        ddl_AttendanceType.Text = theAttendanceAmendment.AttendanceType;
        //        txt_OldTime.Text = theAttendanceAmendment.OldTime.ToString("HH:mm:ss");
        //        txt_NewTime.Text = theAttendanceAmendment.NewTime.ToString("HH:mm:ss");
        //        txt_Reason.Text = theAttendanceAmendment.Reason;
        //        txt_Status.Text = theAttendanceAmendment.Status;

        //        txt_ApprovedBy.Text = "";
        //        txt_Remarks.Text = "";
        //        Btn_Save.Visible = true;

        //    }


        //}

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFields())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = InsertRecord();
                    
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Attendance Ammendment Applicaion", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateRecord();
                    
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Attendance Ammendment Application", MicroEnums.DataOperation.Edit);
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

        protected void gridview_AttendanceAmmendmentApply_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                gridview_AttendanceAmmendmentApply.PageIndex = e.NewPageIndex;
                FillGridView();
            }
            catch
            {
            }
        }

       

        protected void gridview_AttendanceAmmendmentApply_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
               // EnabledisableButtons(true);
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_AttendanceAmmendmentApply.Rows[RowIndex].FindControl("lbl_AttendanceAmendmentID")).Text);
                lbl_DataOperationMode.Text = String.Format("EDIT APPLICATION : {0} [{1}]", gridview_AttendanceAmmendmentApply.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
               
                PageVariables.ThisAttendanceAmendment = AttendanceAmendmentManagement.GetAttendanceAmendmentByAttendanceAmendmentID(RecordID);
                if (e.CommandArgument.Equals("First"))
                {
                    RowIndex = 0;
                }
                else if (e.CommandArgument.Equals("Last"))
                {
                    RowIndex = gridview_AttendanceAmmendmentApply.PageCount - 1;
                }
                else
                {
                    RowIndex = Convert.ToInt32(e.CommandArgument);
                }

                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    
                    Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();

                    multiView_AttandenceAmmendmentApplicationDetails.SetActiveView(view_InputControls);
                    PopulatePageFields(PageVariables.ThisAttendanceAmendment);
                    EnableControls(view_InputControls, true);
                    ChangeBackColor(view_InputControls);
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = 0;

                    ProcReturnValue = DeleteRecord(PageVariables.ThisAttendanceAmendment);
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

        protected void gridview_AttendanceAmmendmentApply_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_AttendanceAmmendmentApply_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gridview_AttendanceAmmendmentApply_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 7);
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
          
            requiredFieldValidator_AttendanceType.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_AttendanceType.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Attendance Type");
            requiredFieldValidator_Reason.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Reason");
            requiredFieldValidator_AttendanceDate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Attandance Date");
            regularExpressionValidator_AttendanceDate.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");

            regularExpressionValidator_NewTime.ValidationExpression = MicroConstants.REGEX_TIME;
            regularExpressionValidator_NewTime.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_12_HOURS_FORMAT");
            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_AttendanceType.CssClass = theClassName;
            requiredFieldValidator_Reason.CssClass = theClassName;
            requiredFieldValidator_AttendanceDate.CssClass = theClassName;
            regularExpressionValidator_AttendanceDate.ValidationExpression = MicroConstants.REGEX_DATE;
            requiredFieldValidator_NewTime.CssClass = theClassName;
            regularExpressionValidator_NewTime.ValidationExpression = MicroConstants.REGEX_TIME;
        }

        private void FillGridView()
        {
            PageVariables.TheUserReferenceID = Connection.LoggedOnUser.UserReferenceID;
            Employee TheEmployee = EmployeeManagement.GetInstance.GetEmployeeByID(PageVariables.TheUserReferenceID);
           
            PageVariables.AttendanceAmendmentList = AttendanceAmendmentManagement.GetAttendanceAmendmentsByEmployee(TheEmployee.EmployeeID);

            gridview_AttendanceAmmendmentApply.DataSource = PageVariables.AttendanceAmendmentList;
            gridview_AttendanceAmmendmentApply.DataBind();

        }

        private void BindDropdown()
        {
            BindDropdown_AttendanceType();
            BindDropdown_AppendSelectToFirst();
        }
        
        private void BindDropdown_AppendSelectToFirst()
        {
            ddl_AttendanceType.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void BindDropdown_AttendanceType()
        {

            ddl_AttendanceType.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.AttendanceType.GetStringValue());
            ddl_AttendanceType.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_AttendanceType.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_AttendanceType.DataBind();
        }

        private void SearchAttendanceAmendmentBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<AttendanceAmendment> SearchList = new List<AttendanceAmendment>();
            // Search by name
            if (PageVariables.AttendanceAmendmentList.Count > 0)
            {
                if (searchField == MicroEnums.SearchAttendanceAmmendment.DateOfAttendance.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from attammend in PageVariables.AttendanceAmendmentList
                                      where attammend.DateOfAttendance.ToString("dd-MMM-yyyy").Equals(searchText)
                                      select attammend).ToList();
                    }
                }
            }

            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();
            gridview_AttendanceAmmendmentApply.DataSource = SearchList;
            gridview_AttendanceAmmendmentApply.DataBind();
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
            AttendanceAmendment TheAttendanceAmendment = new AttendanceAmendment();
            TheAttendanceAmendment.EmployeeID = TheEmployee.EmployeeID;
            TheAttendanceAmendment.DateOfAttendance = DateTime.Parse(txt_AttendanceDate.Text);
            TheAttendanceAmendment.AttendanceType = ddl_AttendanceType.SelectedValue;
            TheAttendanceAmendment.OldTime =DateTime.Parse(txt_OldTime.Text);
            TheAttendanceAmendment.Reason = txt_Reason.Text;
            TheAttendanceAmendment.NewTime = DateTime.Parse(txt_NewTime.Text);

            ProcReturnValue = AttendanceAmendmentManagement.InsertAttendanceAmendment(TheAttendanceAmendment);

            return ProcReturnValue;

        }

        private int UpdateRecord()
        {
            int ProcReturnValue = 0;

           
           
            PageVariables.ThisAttendanceAmendment.DateOfAttendance = DateTime.Parse(txt_AttendanceDate.Text);
            PageVariables.ThisAttendanceAmendment.AttendanceType = ddl_AttendanceType.SelectedValue;
            PageVariables.ThisAttendanceAmendment.OldTime = DateTime.Parse(txt_OldTime.Text);
            PageVariables.ThisAttendanceAmendment.NewTime = DateTime.Parse(txt_NewTime.Text);
            PageVariables.ThisAttendanceAmendment.Reason = txt_Reason.Text;

            ProcReturnValue = AttendanceAmendmentManagement.UpdateAttendanceAmendment(PageVariables.ThisAttendanceAmendment);

            return ProcReturnValue;
        }

        private void ResetTextBoxes()
        {

            txt_AttendanceDate.Text = string.Empty;
            ddl_AttendanceType.SelectedIndex = 0;
            txt_OldTime.Text = string.Empty;
            txt_NewTime.Text = string.Empty;
            txt_Reason.Text = string.Empty;
            AttendanceAmendmentApplicationID = -1;
            txt_ApprovedBy.Text = "";
            txt_Status.Text = string.Empty;
            txt_ApprovedBy.Text = string.Empty;
            txt_Remarks.Text = string.Empty;
            Btn_Save.Visible = true;
            Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
        }

        private void PopulatePageFields(AttendanceAmendment theAttendanceAmendment)
        {
            if (theAttendanceAmendment.Status != "Pending")
            {
                txt_AttendanceDate.Text = theAttendanceAmendment.DateOfAttendance.ToShortDateString();

                txt_OldTime.Text = theAttendanceAmendment.OldTime.ToString("h:mm tt");
                txt_NewTime.Text = theAttendanceAmendment.NewTime.ToString("h:mm tt");
                txt_Reason.Text = theAttendanceAmendment.Reason;
                txt_AttendanceDate.Enabled = false;

                txt_NewTime.Enabled = false;
                txt_Reason.Enabled = false;
                txt_Status.Text = theAttendanceAmendment.Status;
                txt_ApprovedBy.Text = theAttendanceAmendment.ApprovedByEmployeeName;
                txt_Remarks.Text = theAttendanceAmendment.ApprovalOrRejectionReason;

               Btn_Save.Visible = false;

            }
            else
            {
                //(tmEditInTime.Text == "01-01-0001 00:00:00" ? "" : DateTime.Parse(tmEditInTime.Text).ToString("HH:mm:ss"));
                txt_AttendanceDate.Text = theAttendanceAmendment.DateOfAttendance.ToShortDateString();
                ddl_AttendanceType.Text = theAttendanceAmendment.AttendanceType;
                txt_OldTime.Text = theAttendanceAmendment.OldTime.ToString("h:mm tt");
                txt_NewTime.Text = theAttendanceAmendment.NewTime.ToString("h:mm tt");
                txt_Reason.Text = theAttendanceAmendment.Reason;
                txt_Status.Text = theAttendanceAmendment.Status;

                txt_ApprovedBy.Text = "";
                txt_Remarks.Text = "";
                Btn_Save.Visible = true;

            }


            //txt_DepartmentDescription.Text = theDepartment.DepartmentDescription;
            //ddl_ParentDepartment.SelectedIndex = GetDropDownSelectedIndex(ddl_ParentDepartment, Convert.ToString(theDepartment.ParentDepartmentId));
        }


        public static int DeleteRecord(AttendanceAmendment theAttendanceAmendment)
        {
            int ProcReturnValue = AttendanceAmendmentManagement.DeletetAttendanceAmendment(theAttendanceAmendment);
                
            return ProcReturnValue;
        }
        #endregion

       
	}
}