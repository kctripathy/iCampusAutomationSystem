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
    public partial class StaffLICPolicies : BasePage
    {

        #region Declaration

        protected static class PageVariables
        {
            public static PolicyApplication ThisPolicyApplication
            {
                get
                {
                    PolicyApplication ThePolicyMaster = HttpContext.Current.Session["ThisPolicyApplication"] as PolicyApplication;
                    return ThePolicyMaster;
                }
                set
                {
                    HttpContext.Current.Session.Add("ThisPolicyApplication", value);
                }
            }

            public static List<PolicyApplication> PolicyApplicationList
            {
                get
                {
                    List<PolicyApplication> ThePolicyApplication = HttpContext.Current.Session["PolicyApplicationList"] as List<PolicyApplication>;
                    return ThePolicyApplication;
                }
                set
                {
                    HttpContext.Current.Session.Add("PolicyApplicationList", value);
                }
            }

            public static int ThePolicyApplicationID;

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
                BindGrid_PolicyEmployees();
                BindDropdown_AppendSelectToFirst(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
                ddl_PolicyType.Focus();
                multiView_PolicyMasters.SetActiveView(view_InputControls);
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
            //        multiView_PolicyMasters.SetActiveView(view_InputControls);
            //        //  multiView_EmployeeDetails.SetActiveView(view_InputControls);
            //        ResetBackColor(view_InputControls);
            //    }
            //    else
            //    {
            //        BindGrid_PolicyEmployees();

            //        multiView_PolicyMasters.SetActiveView(view_GridView);
            //        BasePage.ShowHidePagePermissions(gridview_PolicyMaster, btn_AddApplication, this.Page);

            //    }
            //    //  ctrl_Search.SearchWhat = MicroEnums.SearchForm.Employee.GetStringValue();
            //}
        }
        protected void gridview_PolicyMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridview_PolicyMaster.PageIndex = e.NewPageIndex;
                BindGrid_PolicyEmployees();
                lit_PageCounter.Text = string.Format("Page <b>{0}</b> of {1}", e.NewPageIndex + 1, gridview_PolicyMaster.PageCount);
            }
            catch
            {
            }
        }
        protected void gridview_PolicyMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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

                    RowIndex = gridview_PolicyMaster.PageCount - 1;
                }
                else
                {
                    RowIndex = Convert.ToInt32(e.CommandArgument);
                }
                //int RowIndex = Convert.ToInt32(e.CommandArgument);
                int RecordID = int.Parse(((Label)gridview_PolicyMaster.Rows[RowIndex].FindControl("lbl_PolicyApplicationID")).Text);

                //PageVariables.ThisPolicyApplication = PolicyApplicationManagement.GetInstance.GetEmployeePolicyDetailsByPolicyApplicationID(RecordID);

                if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {                    
                    lbl_DataOperationMode.Text = String.Format("EDIT PolicyApplication : {0} [{1}]", gridview_PolicyMaster.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
                    if (RecordID>0)
                    {
                        btn_Top_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                        Btn_Save.Text = MicroEnums.DataOperation.Update.GetStringValue();
                        multiView_PolicyMasters.SetActiveView(view_InputControls);
                        PageVariables.ThisPolicyApplication = (from xyz in PolicyApplicationManagement.GetInstance.GetPolicyEmployeeList()
                                                                where xyz.PolicyApplicationID == RecordID
                                                                select xyz).Single();
                        PopulatePageFields(PageVariables.ThisPolicyApplication);
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


                        multiView_PolicyMasters.SetActiveView(view_InputControls);

                        PopulatePageFields(PageVariables.ThisPolicyApplication);
                        //lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_LEAVEAPPLICATION_DELETED");
                        //dialog_Message.Show();
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "alert('Policy Stauts of that Employee have been closed');", true);

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
                    lbl_DataOperationMode.Text = String.Format("EDIT Policy Of Employee : {0} [{1}]", gridview_PolicyMaster.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

                    multiView_PolicyMasters.SetActiveView(view_InputControls);
                    PopulatePageFields(PageVariables.ThisPolicyApplication);

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
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Policy Of Employee", MicroEnums.DataOperation.Delete);
                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {

                        BindGrid_PolicyEmployees();
                    }

                    dialog_Message.Show();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
        }
        protected void gridview_PolicyMaster_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void gridview_PolicyMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch
            {
            }
        }

        protected void gridview_PolicyMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
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


            multiView_PolicyMasters.SetActiveView(view_InputControls);
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            if (ValidateFormFieldsEmployee())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = SaveEmployeePolicyDetails();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Policy", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateEmployeePolicyDetails();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Employee Policy", MicroEnums.DataOperation.Edit);
                }
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    //Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
                    //btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
                    BindGrid_PolicyEmployees();
                    ResetTextBoxes();
                    ResetBackColor(view_InputControls);
                }
            }
            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        protected void btn_ViewApplication_Click(object sender, EventArgs e)
        {
            BindGrid_PolicyEmployees();
            multiView_PolicyMasters.SetActiveView(view_GridView);
            //  BasePage.ShowHidePagePermissions(gridview_PolicyMaster, btn_AddApplication, this.Page);
        }

        #endregion

        #region Methods & Implementation

        private bool ValidateFormFieldsEmployee()
        {
            bool ReturnValue = true;
            //PolicyApplication TheEmployeePolicy = PolicyApplicationManagement.GetInstance.GetActiveEmployeePolicyByEmployeeID(int.Parse(ddl_EmployeeName.SelectedValue));
            //if (TheEmployeePolicy.PolicyApplicationID > 0 && TheEmployeePolicy.PolicyID == int.Parse(ddl_PolicyType.SelectedValue))
            //{

            //    PageVariables.ThisPolicyApplication = TheEmployeePolicy;
            //    lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_HAS_ACITVE_Policy");
            //    dialog_Message.Show();
            //    ReturnValue = false;


            //}

            //else if (TheEmployeePolicy.PolicyApplicationID < 0 && TheEmployeePolicy.PolicyStatus == false)
            //{
            //    PageVariables.ThisPolicyApplication = TheEmployeePolicy;
            //    ReturnValue = true;


            //}





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
            txt_Policyamount.Text = string.Empty;
            txt_Policyappdate.Text = string.Empty;
            ddl_PolicyType.SelectedIndex = 0;
            txt_RequiredFor.Text = string.Empty;
            txt_toalnoinstalment.Text = string.Empty;
            PageVariables.ThisPolicyApplication = null;
            lbl_DataOperationMode.Text = "ADD NEW Policy";
            Btn_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();
            btn_Top_Save.Text = MicroEnums.DataOperation.Save.GetStringValue();

            //if (!(BasePage.HasAddPermission(this.Page)))
            //{
            //    multiView_EmployeeDetails.SetActiveView(view_GridView);
            //}
        }

        private static void ResetPageVariables()
        {
            PageVariables.ThisPolicyApplication = null;
            PageVariables.PolicyApplicationList = null;
        }       
        private void SetValidationMessages()
        {
            requiredFieldValidator_PolicyType.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_EmployeeName.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_AcademicYear.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            regularExpressionValidator_Policyappdate.ValidationExpression = MicroConstants.REGEX_DATE;

            requiredFieldValidator_PolicyAmount.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Policy Amount");
            requiredFieldValidator_PolicyType.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "PolicyType");
            requiredFieldValidator_AcademicYear.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "AcademicYear");
            requiredFieldValidator_EmployeeName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "EmployeeName");
            requiredFieldValidator_Policyappdate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "PolicyApplicationDate");


            SetFormMessageCSSClass("ValidateMessage");

        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_PolicyType.CssClass = theClassName;
            requiredFieldValidator_AcademicYear.CssClass = theClassName;
            requiredFieldValidator_PolicyAmount.CssClass = theClassName;
            requiredFieldValidator_Policyappdate.CssClass = theClassName;
        }
        private void BindDropDownList()
        {
            BindDropdown_PolicyType();
            BindDropDown_Employees();
            BindAccountingYear(string.Empty);
        }
        private void BindDropdown_AppendSelectToFirst(string ddlDefaultItem)
        {
            ddl_EmployeeName.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT_DASH);
            ddl_PolicyType.Items.Insert(0, ddlDefaultItem);
            ddl_AcademicYear.Items.Insert(0, ddlDefaultItem);
        }
        public void BindAccountingYear(string SearctText)
        {
            ddl_AcademicYear.DataSource = AccountingYearManagement.GetInstance.GetAccountingYearList(SearctText);
            ddl_AcademicYear.DataTextField = AccountingYearManagement.GetInstance.DisplayMember;
            ddl_AcademicYear.DataValueField = AccountingYearManagement.GetInstance.ValueMember;
            ddl_AcademicYear.DataBind();
        }
        private void BindDropdown_PolicyType()
        {
            //ddl_PolicyType.DataSource = PolicyTypeManagement.GetInstance.GetPolicyTypeList();
            //ddl_PolicyType.DataTextField = PolicyTypeManagement.GetInstance.DisplayMember;
            //ddl_PolicyType.DataValueField = PolicyTypeManagement.GetInstance.ValueMember;
            //ddl_PolicyType.DataBind();


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
        //    if (PageVariables.PolicyMasterList.Count > 0)
        //    {
        //        if (searchField == MicroEnums.SearchEmployee.EmployeeName.ToString())
        //        {
        //            if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
        //            {
        //                SearchList = (from empName in PageVariables.PolicyMasterList
        //                              where empName.EmployeeName.ToUpper().StartsWith(searchText.ToUpper())
        //                              select empName).ToList();
        //            }

        //            if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
        //            {
        //                SearchList = (from empName in PageVariables.PolicyMasterList
        //                              where empName.EmployeeName.ToUpper().Contains(searchText.ToUpper())
        //                              select empName).ToList();
        //            }
        //        }
        //        // Search by code
        //        if (searchField == MicroEnums.SearchEmployee.EmployeeCode.ToString())
        //        {
        //            if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
        //            {
        //                SearchList = (from empCode in PageVariables.PolicyMasterList
        //                              where empCode.EmployeeCode.ToUpper().StartsWith(searchText.ToUpper())
        //                              select empCode).ToList();
        //            }

        //            if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
        //            {
        //                SearchList = (from empCode in PageVariables.PolicyMasterList
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

        public void BindGrid_PolicyEmployees()
        {

            PageVariables.PolicyApplicationList = PolicyApplicationManagement.GetInstance.GetPolicyEmployeeList();

            gridview_PolicyMaster.DataSource = PageVariables.PolicyApplicationList;
            gridview_PolicyMaster.DataBind();
        }


        private void PopulatePageFields(PolicyApplication thePolicyApplication)
        {



            ddl_AcademicYear.SelectedIndex = GetDropDownSelectedIndex(ddl_AcademicYear, Convert.ToString(thePolicyApplication.SessionID));
            ddl_EmployeeName.SelectedIndex = GetDropDownSelectedIndex(ddl_EmployeeName, Convert.ToString(thePolicyApplication.EmployeeID));
            ddl_PolicyType.SelectedIndex = GetDropDownSelectedIndex(ddl_PolicyType, Convert.ToString(thePolicyApplication.PolicyID));
            txt_emi.Text = thePolicyApplication.EMI.ToString();
            txt_Policyamount.Text = thePolicyApplication.PolicyAmount.ToString();
            txt_Policyappdate.Text = thePolicyApplication.PolicyDate;
            txt_RequiredFor.Text = thePolicyApplication.Comment;
            txt_toalnoinstalment.Text = thePolicyApplication.TotalNoInstallment.ToString();





        }


        private int SaveEmployeePolicyDetails()
        {
            int ProcReturnValue = 0;

            PolicyApplication ThePolicyApplications = new PolicyApplication();

            
            ThePolicyApplications.SessionID = int.Parse(ddl_AcademicYear.SelectedValue);
            ThePolicyApplications.EmployeeID = int.Parse(ddl_EmployeeName.SelectedValue);
            ThePolicyApplications.PolicyID = int.Parse(ddl_PolicyType.SelectedValue);
            ThePolicyApplications.PolicyAmount = decimal.Parse(txt_Policyamount.Text);
            ThePolicyApplications.PolicyDate = txt_Policyappdate.Text;
            ThePolicyApplications.PolicyStatus = true;
            ThePolicyApplications.Comment = txt_RequiredFor.Text;
            ThePolicyApplications.TotalNoInstallment = int.Parse(txt_toalnoinstalment.Text);
            ThePolicyApplications.EMI = decimal.Parse(txt_emi.Text);

            ProcReturnValue = PolicyApplicationManagement.GetInstance.InsertPolicyApplication(ThePolicyApplications);
            return ProcReturnValue;



        }


        private int UpdateEmployeePolicyDetails()
        {

            int ProcReturnValue = 0;
            PageVariables.ThisPolicyApplication.EmployeeID = int.Parse(ddl_EmployeeName.SelectedValue);
            PageVariables.ThisPolicyApplication.SessionID = int.Parse(ddl_EmployeeName.SelectedValue);
            PageVariables.ThisPolicyApplication.PolicyID = int.Parse(ddl_PolicyType.SelectedValue);
            PageVariables.ThisPolicyApplication.PolicyAmount = decimal.Parse(txt_Policyamount.Text);

            PageVariables.ThisPolicyApplication.EMI = decimal.Parse(txt_emi.Text);
            PageVariables.ThisPolicyApplication.PolicyDate = txt_Policyappdate.Text;
            //TODO: 
            //  PageVariables.ThisPolicyApplication.PolicyStatus= txt
            PageVariables.ThisPolicyApplication.Comment = txt_RequiredFor.Text;
            PageVariables.ThisPolicyApplication.TotalNoInstallment = int.Parse(txt_toalnoinstalment.Text);



            ProcReturnValue = PolicyApplicationManagement.GetInstance.UpdatePolicyApplication(PageVariables.ThisPolicyApplication);
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