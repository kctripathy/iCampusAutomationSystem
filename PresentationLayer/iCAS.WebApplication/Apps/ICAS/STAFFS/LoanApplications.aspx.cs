using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.Objects.FinancialAccounts;
using Micro.BusinessLayer.FinancialAccounts;
using Micro.BusinessLayer.HumanResource;
using Micro.Framework.ReadXML;
using Micro.Objects.HumanResource;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS
{
    public partial class LoanApplications : BasePage
    {
        
        #region Declaration

        protected static class PageVariables
        {
            public static LoanApplication ThisLoanApplication
            {
                get
                {
                    LoanApplication TheLoanMaster = HttpContext.Current.Session["ThisLoanApplication"] as LoanApplication;
                    return TheLoanMaster;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisLoanApplication", value);
                }
            }

            public static List<LoanApplication> LoanApplicationList
            {
                get
                {
                    List<LoanApplication> TheLoanApplication = HttpContext.Current.Session["LoanApplicationList"] as List<LoanApplication>;
                    return TheLoanApplication;
                }
                set
                {
                    HttpContext.Current.Session.Add("LoanApplicationList", value);
                }
            }

            public static int TheLoanApplicationID;

            public static List<Employee> EmployeeList;

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
                ddl_LoanType.Focus();

                multiView_LoanMasters.SetActiveView(view_InputControls);

            }




            //BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
            ////ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;


            //if (!IsPostBack)
            //{
            //    SetValidationMessages();
            //    BindDropDownList();
            //    BindDropdown_AppendSelectToFirst(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            //    if (HasAddPermission() && IsDefaultModeAdd())
            //    {
            //        multiView_LoanMasters.SetActiveView(view_InputControls);
            //        //  multiView_EmployeeDetails.SetActiveView(view_InputControls);
            //        ResetBackColor(view_InputControls);
            //    }
            //    else
            //    {
            //        BindGrid_LoanEmployees();

            //        multiView_LoanMasters.SetActiveView(view_GridView);
            //        BasePage.ShowHidePagePermissions(gridview_LoanMaster, btn_AddApplication, this.Page);

            //    }
            //    //  ctrl_Search.SearchWhat = MicroEnums.SearchForm.Employee.GetStringValue();
            //}


        }


        protected void gridview_LoanMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridview_LoanMaster.PageIndex = e.NewPageIndex;
               BindGrid_LoanEmployees();


                lit_PageCounter.Text = string.Format("Page <b>{0}</b> of {1}", e.NewPageIndex + 1, gridview_LoanMaster.PageCount);

            }
            catch
            {
            }
        }

        protected void gridview_LoanMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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

                    RowIndex = gridview_LoanMaster.PageCount - 1;
                }
                else
                {
                    RowIndex = Convert.ToInt32(e.CommandArgument);
                }
                //int RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_LoanMaster.Rows[RowIndex].FindControl("lbl_LoanApplicationID")).Text);

                PageVariables.ThisLoanApplication = LoanApplicationManagement.GetInstance.GetEmployeeLoanDetailsByLoanApplicationID(RecordID);

                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {

                    lbl_DataOperationMode.Text = String.Format("EDIT LoanApplication : {0} [{1}]", gridview_LoanMaster.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
                    if (PageVariables.ThisLoanApplication.LoanStatus == true)
                    {
                        btn_Top_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                        Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();


                        multiView_LoanMasters.SetActiveView(view_InputControls);

                        PopulatePageFields(PageVariables.ThisLoanApplication);

                        //if (PageVariables.ThisEmployee.LastQualification.Equals(MicroEnums.Qualifications.UnderMatric.GetStringValue()))
                        //{
                        //    Enabledisabletextboxqualification(false);
                        //}
                        bool EnableFlag = true;
                        EnableControls(view_InputControls, EnableFlag);
                        btn_Top_Save.Visible = EnableFlag;
                        Btn_Save.Visible = EnableFlag;

                        btn_Top_Save.Enabled = EnableFlag;
                        Btn_Save.Enabled = EnableFlag;


                        btn_Cancel.Visible = EnableFlag;
                        btn_Cancel_Top.Visible = EnableFlag;
                    }
                    else
                    {

                        btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
                        Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();


                        multiView_LoanMasters.SetActiveView(view_InputControls);

                        PopulatePageFields(PageVariables.ThisLoanApplication);
                        //lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_LEAVEAPPLICATION_DELETED");
                        //dialog_Message.Show();
                         ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "alert('Loan Stauts of that Employee have been closed');", true);

                        bool EnableFlag = true;
                        EnableControls(view_InputControls, EnableFlag);
                        //btn_Top_Save.Visible = EnableFlag;
                        //Btn_Save.Visible = EnableFlag;
                        btn_Top_Save.Enabled = false;
                        Btn_Save.Enabled = false;

                        btn_Cancel.Visible = EnableFlag;
                        btn_Cancel_Top.Visible = EnableFlag;
                    }
                    // ChangeBackColor(view_InputControls);
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {
                    lbl_DataOperationMode.Text = String.Format("EDIT Loan Of Employee : {0} [{1}]", gridview_LoanMaster.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

                    multiView_LoanMasters.SetActiveView(view_InputControls);
                    PopulatePageFields(PageVariables.ThisLoanApplication);

                    bool EnableFlag = false;
                    EnableControls(view_InputControls, EnableFlag);

                    Btn_Save.Visible = EnableFlag;
                    btn_Top_Save.Visible = EnableFlag;
                    btn_Cancel.Visible = EnableFlag;

                    btn_Cancel_Top.Visible = EnableFlag;
                }

                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    ProcReturnValue = DeleteRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Loan Of Employee", MicroEnums.DataOperation.Delete);
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {

                        BindGrid_LoanEmployees();
                    }

                    dialog_Message.Show();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
        }

        protected void gridview_LoanMaster_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gridview_LoanMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch
            {
            }
        }

        protected void gridview_LoanMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch
            {
            }
        }

        //protected void searchCtrl_ButtonClicked(object sender, EventArgs e)
        //{
        //    SearchEmployeetBindGridView();
        //}

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {

            ResetTextBoxes();
        }

        protected void btn_AddApplication_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();


            multiView_LoanMasters.SetActiveView(view_InputControls);
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {

            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFieldsEmployee())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = SaveEmployeeLoanDetails();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Loan", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateEmployeeLoanDetails();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Loan", MicroEnums.DataOperation.Edit);
                }
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    //Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
                    //btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
                   BindGrid_LoanEmployees();
                    ResetTextBoxes();


                    ResetBackColor(view_InputControls);
                }

            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();


        }

        protected void btn_ViewApplication_Click(object sender, EventArgs e)
        {
           BindGrid_LoanEmployees();

            multiView_LoanMasters.SetActiveView(view_GridView);
          //  BasePage.ShowHidePagePermissions(gridview_LoanMaster, btn_AddApplication, this.Page);
        }

        #endregion

        #region Methods & Implementation

        private bool ValidateFormFieldsEmployee()
        {
            bool ReturnValue= true;
            LoanApplication TheEmployeeLoan = LoanApplicationManagement.GetInstance.GetActiveEmployeeLoanByEmployeeID(int.Parse(ddl_EmployeeName.SelectedValue));
            if (TheEmployeeLoan.LoanApplicationID > 0 && TheEmployeeLoan.LoanID==int.Parse(ddl_LoanType.SelectedValue))
            {

                PageVariables.ThisLoanApplication = TheEmployeeLoan;
                lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_HAS_ACITVE_LOAN");
                dialog_Message.Show();
                ReturnValue = false;


            }

            else if (TheEmployeeLoan.LoanApplicationID < 0 && TheEmployeeLoan.LoanStatus == false)
            {
                PageVariables.ThisLoanApplication = TheEmployeeLoan;
                ReturnValue = true;


            }
           
           



            return ReturnValue;
        }

        private void BindDropDown_Employees(List<Employee> employeeList = null)
        {

            ddl_EmployeeName.DataSource = null;
            ddl_EmployeeName.DataBind();

            if (employeeList == null)
            {
                PageVariables.EmployeeList = EmployeeManagement.GetInstance.GetOfficeEmployeeList();
                employeeList = PageVariables.EmployeeList;
            }

            if (employeeList.Count > 0)
            {
                ddl_EmployeeName.DataSource = employeeList;
                ddl_EmployeeName.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
                ddl_EmployeeName.DataValueField = EmployeeManagement.GetInstance.ValueMember;
                ddl_EmployeeName.DataBind();

                ddl_EmployeeName.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
            }
             }

        private void ResetTextBoxes()
        {
            ddl_AcademicYear.SelectedIndex = 0;
            ddl_EmployeeName.SelectedIndex = 0;
            txt_emi.Text = string.Empty;
            txt_loanamount.Text = string.Empty;
            txt_loanappdate.Text = string.Empty;
            ddl_LoanType.SelectedIndex = 0;
            txt_RequiredFor.Text = string.Empty;
            txt_toalnoinstalment.Text = string.Empty;


            PageVariables.ThisLoanApplication = null;
            lbl_DataOperationMode.Text = "ADD NEW Loan";
            Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();

            //if (!(BasePage.HasAddPermission(this.Page)))
            //{
            //    multiView_EmployeeDetails.SetActiveView(view_GridView);
            //}
        }

        private static void ResetPageVariables()
        {
            PageVariables.ThisLoanApplication = null;
            PageVariables.LoanApplicationList = null;
        }



        //private void HideGridViewColumns()
        //{
        //    BasePage.ShowHidePagePermissions(gridview_LoanMaster, btn_AddApplication, this.Page);
        //}

        private void SetValidationMessages()
        {
            requiredFieldValidator_LoanType.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_EmployeeName.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_AcademicYear.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            regularExpressionValidator_loanappdate.ValidationExpression = MicroConstants.REGEX_DATE;
            
            requiredFieldValidator_LoanAmount.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Loan Amount");
            requiredFieldValidator_LoanType.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "LoanType");
            requiredFieldValidator_AcademicYear.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "AcademicYear");
            requiredFieldValidator_EmployeeName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "EmployeeName");
            requiredFieldValidator_loanappdate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "LoanApplicationDate");
            
            
            SetFormMessageCSSClass("ValidateMessage");

        }

        private void SetFormMessageCSSClass(string theClassName)
        {

            requiredFieldValidator_LoanType.CssClass = theClassName;
            requiredFieldValidator_AcademicYear.CssClass = theClassName;
            requiredFieldValidator_LoanAmount.CssClass = theClassName;
           requiredFieldValidator_loanappdate.CssClass = theClassName;
           
        }


        private void BindDropDownList()
        {

            BindDropdown_LoanType();
            BindDropDown_Employees();
            BindAccountingYear(string.Empty);


        }

        private void BindDropdown_AppendSelectToFirst(string ddlDefaultItem)
        {

            ddl_EmployeeName.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT_DASH);
            ddl_LoanType.Items.Insert(0, ddlDefaultItem);
            ddl_AcademicYear.Items.Insert(0, ddlDefaultItem);

        }

        public void BindAccountingYear(string SearctText)
        {
            ddl_AcademicYear.DataSource = AccountingYearManagement.GetInstance.GetAccountingYearList(SearctText);
            ddl_AcademicYear.DataTextField = AccountingYearManagement.GetInstance.DisplayMember;
            ddl_AcademicYear.DataValueField = AccountingYearManagement.GetInstance.ValueMember;
            ddl_AcademicYear.DataBind();
        }


        private void BindDropdown_LoanType()
        {

            ddl_LoanType.DataSource = LoanTypeManagement.GetInstance.GetLoanTypeList();
            ddl_LoanType.DataTextField = LoanTypeManagement.GetInstance.DisplayMember;
            ddl_LoanType.DataValueField = LoanTypeManagement.GetInstance.ValueMember;
            ddl_LoanType.DataBind();


        }

        //private void BindDropDown_Employees()
        //{

        //    ddl_EmployeeName.DataSource = EmployeeManagement.GetInstance.GetCompanyEmployeeList();
        //    ddl_EmployeeName.DataTextField = EmployeeManagement.GetInstance.DisplayMember;
        //    ddl_EmployeeName.DataValueField = EmployeeManagement.GetInstance.ValueMember;
        //    ddl_EmployeeName.DataBind();
        //}



        //private void SearchEmployeetBindGridView()
        //{
        //    string searchText = ctrl_Search.SearchText;
        //    string searchOperator = ctrl_Search.SearchOperator;
        //    string searchField = ctrl_Search.SearchField;

        //    List<Employee> SearchList = new List<Employee>();
        //    // Search by name
        //    if (PageVariables.LoanMasterList.Count > 0)
        //    {
        //        if (searchField == MicroEnums.SearchEmployee.EmployeeName.ToString())
        //        {
        //            if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
        //            {
        //                SearchList = (from empName in PageVariables.LoanMasterList
        //                              where empName.EmployeeName.ToUpper().StartsWith(searchText.ToUpper())
        //                              select empName).ToList();
        //            }

        //            if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
        //            {
        //                SearchList = (from empName in PageVariables.LoanMasterList
        //                              where empName.EmployeeName.ToUpper().Contains(searchText.ToUpper())
        //                              select empName).ToList();
        //            }
        //        }
        //        // Search by code
        //        if (searchField == MicroEnums.SearchEmployee.EmployeeCode.ToString())
        //        {
        //            if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
        //            {
        //                SearchList = (from empCode in PageVariables.LoanMasterList
        //                              where empCode.EmployeeCode.ToUpper().StartsWith(searchText.ToUpper())
        //                              select empCode).ToList();
        //            }

        //            if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
        //            {
        //                SearchList = (from empCode in PageVariables.LoanMasterList
        //                              where empCode.EmployeeCode.ToUpper().Contains(searchText.ToUpper())
        //                              select empCode).ToList();
        //            }
        //        }

        //    }
        //    // Dispaly the search result
        //    ctrl_Search.SearchResultCount = SearchList.Count.ToString();
        //    gview_Employee.DataSource = SearchList;
        //    gview_Employee.DataBind();
        //}

        //private void BindSearchFields()
        //{
        //    foreach (MicroEnums.SearchEmployee x in Enum.GetValues(typeof(MicroEnums.SearchEmployee)))
        //    {
        //        string xyz = x.ToString();
        //    }
        //}

        public void BindGrid_LoanEmployees()
        {
            // int OfficeID = 44;
            // int OfficeID = ((User)Session["CurrentUser"]).OfficeID;
            PageVariables.LoanApplicationList = LoanApplicationManagement.GetInstance.GetLoanEmployeeList();

            gridview_LoanMaster.DataSource = PageVariables.LoanApplicationList;
            gridview_LoanMaster.DataBind();
        }


        private void PopulatePageFields(LoanApplication theLoanApplication)
        {
            


            ddl_AcademicYear.SelectedIndex = GetDropDownSelectedIndex(ddl_AcademicYear, Convert.ToString(theLoanApplication.SessionID));
            ddl_EmployeeName.SelectedIndex = GetDropDownSelectedIndex(ddl_EmployeeName, Convert.ToString(theLoanApplication.EmployeeID));
            ddl_LoanType.SelectedIndex = GetDropDownSelectedIndex(ddl_LoanType, Convert.ToString(theLoanApplication.LoanID));
            txt_emi.Text = theLoanApplication.EMI.ToString();
            txt_loanamount.Text = theLoanApplication.LoanAmount.ToString();
            txt_loanappdate.Text = theLoanApplication.LoanApplicationDate;
            txt_RequiredFor.Text = theLoanApplication.RequiredFor;
            txt_toalnoinstalment.Text =theLoanApplication.TotalNoInstallment.ToString();
           

            


        }


        private int SaveEmployeeLoanDetails()
        {
            int ProcReturnValue = 0;
            
            LoanApplication TheLoanApplications = new LoanApplication();

            //PageVariables.ThisLoanApplication = LoanApplicationManagement.GetInstance.GetEmployeeLoanDetailsByEmployeeID(int.Parse(ddl_EmployeeName.SelectedValue));
            //LeaveBalanceList = LeaveBalanceManagement.GetLeaveBalanceByEmployee(TheStaffMaster.EmployeeID);
           // var employeeloan= (from el in PageVariables.ThisLoanApplication where el.
            //var LeaveBalance = (from st in LeaveBalanceList
            //                    where st.LeaveTypeDescription == ddl_LeaveDescription.Text
            //                    select st.TotalNumberOfLeavesElligibleToAvail).First();

            //int TotalLeaveBalance = LeaveBalance;
            //LeaveBalance = (from st in LeaveBalanceList
            //                where st.LeaveTypeDescription == ddl_LeaveDescription.Text
            //                select st.NumberOfConsecutiveDaysAllowed).First();


            //LeaveBalance = (from st in LeaveBalanceList
            //                where st.LeaveTypeDescription == ddl_LeaveDescription.Text
            //                select st.LeaveTypeID).First();
            TheLoanApplications.SessionID = int.Parse(ddl_AcademicYear.SelectedValue);
            TheLoanApplications.EmployeeID= int.Parse(ddl_EmployeeName.SelectedValue);
            TheLoanApplications.LoanID=int.Parse(ddl_LoanType.SelectedValue);
            TheLoanApplications.LoanAmount= decimal.Parse(txt_loanamount.Text);
            TheLoanApplications.LoanApplicationDate= txt_loanappdate.Text;
            TheLoanApplications.LoanStatus = true;
            TheLoanApplications.RequiredFor= txt_RequiredFor.Text;
            TheLoanApplications.TotalNoInstallment=int.Parse(txt_toalnoinstalment.Text);
            TheLoanApplications.EMI= decimal.Parse(txt_emi.Text);

            ProcReturnValue = LoanApplicationManagement.GetInstance.InsertLoanApplication(TheLoanApplications);
            return ProcReturnValue;

            

        }


        private int UpdateEmployeeLoanDetails()
        {
            
            int ProcReturnValue = 0;
            PageVariables.ThisLoanApplication.EmployeeID = int.Parse(ddl_EmployeeName.SelectedValue);
            PageVariables.ThisLoanApplication.SessionID = int.Parse(ddl_EmployeeName.SelectedValue);
            PageVariables.ThisLoanApplication.LoanID = int.Parse(ddl_LoanType.SelectedValue);
            PageVariables.ThisLoanApplication.LoanAmount = decimal.Parse(txt_loanamount.Text);

            PageVariables.ThisLoanApplication.EMI = decimal.Parse(txt_emi.Text);
            PageVariables.ThisLoanApplication.LoanApplicationDate = txt_loanappdate.Text;
            //TODO: 
          //  PageVariables.ThisLoanApplication.LoanStatus= txt
            PageVariables.ThisLoanApplication.RequiredFor = txt_RequiredFor.Text;
            PageVariables.ThisLoanApplication.TotalNoInstallment = int.Parse(txt_toalnoinstalment.Text);
            


            ProcReturnValue = LoanApplicationManagement.GetInstance.UpdateLoanApplication(PageVariables.ThisLoanApplication);
            return ProcReturnValue;
        
            

        }

        public static int DeleteRecord()
        {
            int ProcReturnValue = 0;

            return ProcReturnValue;
        }


        #endregion
   

    }
}