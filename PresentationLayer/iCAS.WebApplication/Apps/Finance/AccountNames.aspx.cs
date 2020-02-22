using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.FinancialAccounts;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;
using Micro.Objects.FinancialAccounts;

namespace Micro.WebApplication.MicroERP.FINANCE
{
    /// <summary>
    /// Manages Accounts
    /// </summary>
    /// <Author> Deepak Kumar Biswal </Author>
    /// <Date> 10-Oct-2011 </Date>
    public partial class AccountNames : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static AccountName ThisAccountName;
            public static List<AccountName> ThisAccountNameList;
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
			BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
			ctrl_Search.OnButtonClick += ctrl_Search_ButtonClick;
			
            if (!IsPostBack && !IsCallback)
            {
                SetValidationMessages();
                ResetPageVariables();
                BindDropDown();
				if (HasAddPermission() && IsDefaultModeAdd())
				{
					mview_Accounts.SetActiveView(view_InputControls);
					ResetBackColor(view_InputControls);
					EnableDisableParentAccount(false);
				}
				else
				{
					BindGridView();
					HideGridViewColumns();
					BasePage.ShowHidePagePermissions(gview_AccountName, btn_New, this.Page);
					gview_AccountName.AutoGenerateEditButton = false;
					mview_Accounts.SetActiveView(view_GridView);
				}
                ctrl_Search.SearchWhat = MicroEnums.SearchForm.AccountName.ToString();
            }
        }

        protected void ddl_AccountHeads_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearListItems(ddl_AnalysisFlag);

            if (!IsDefaultItemText(ddl_AccountHeads))
            {
                AccountHead ThisAccountHead = AccountHeadManagement.GetInstance.GetAccountHeadByID(int.Parse(ddl_AccountHeads.SelectedItem.Value));
                BindDropdown_AnalysisFlag(ThisAccountHead.AccountHeadType);
            }

            if (chk_TreatAsSubAccount.Checked)
            {
                ClearListItems(ddl_ParentAccountName);
            }
        }

        protected void ddl_AnalysisFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_TreatAsSubAccount.Checked)
            {
                if (!IsDefaultItemText(ddl_AnalysisFlag))
                {
                    ClearListItems(ddl_ParentAccountName);
                    BindDropdown_AccounNames(ddl_AnalysisFlag.SelectedItem.Text);
                }
            }
        }

        protected void chk_TreatAsSubAccount_CheckedChanged(object sender, EventArgs e)
        {
            bool CheckState = chk_TreatAsSubAccount.Checked;

            if (CheckState)
                BindDropdown_AccounNames(ddl_AnalysisFlag.SelectedItem.Text);

            EnableDisableParentAccount(CheckState);
        }

        protected void gview_AccountName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_AccountName.PageIndex = e.NewPageIndex;
            BindGridView(PageVariables.ThisAccountNameList);
        }

        protected void gview_AccountName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            int RecordID = int.Parse(((Label)gview_AccountName.Rows[RowIndex].FindControl("lbl_AccountID")).Text);
            lbl_DataOperationMode.Text = String.Format("EDIT ACCOUNT : {0} [{1}]", gview_AccountName.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

            PageVariables.ThisAccountName = AccountNameManagement.GetInstance.GetAccountByID(RecordID);

            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                if (PageVariables.ThisAccountName.IsPrimary.Equals(false))
                {
                    btn_Submit.Text = String.Format(" {0} ", MicroEnums.DataOperation.Update.GetStringValue());
                    mview_Accounts.SetActiveView(view_InputControls);
                    PopulateFormFields();
					EnableControls(view_InputControls, true);
					ChangeBackColor(view_InputControls);
					btn_Submit.Visible = true;
                }
                else
                {
                    lbl_TheMessage.Text = GetDataOperationResult(-4, "AccountName", MicroEnums.DataOperation.Edit);
                    dialog_Message.Show();
                }
            }
            else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
            {
                int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                if (PageVariables.ThisAccountName.IsPrimary.Equals(false))
                {
                    ProcReturnValue = DeleteRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Account", MicroEnums.DataOperation.Delete);

                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                        BindGridView();
                }
                else
                {
                    lbl_TheMessage.Text = GetDataOperationResult(-4, "AccountName", MicroEnums.DataOperation.Delete);
                }

                dialog_Message.Show();
            }

			else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
			{

				lbl_DataOperationMode.Text = String.Format("VIEW ACCOUNT : {0} [{1}]", gview_AccountName.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

				mview_Accounts.SetActiveView(view_InputControls);
				PopulateFormFields();
				EnableControls(view_InputControls, false);
				btn_Submit.Visible = false;
			}
        }

        protected void gview_AccountName_RowDataBound(object sender, GridViewRowEventArgs e)
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
                string msg = ex.Message.ToString();
            }
        }

        protected void gview_AccountName_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_AccountName_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        private void ctrl_Search_ButtonClick(object sender, System.EventArgs e)
        {
            List<AccountName> AccountNameList = GetSearchAccountNameList();

            BindGridView(AccountNameList);
            ctrl_Search.SearchResultCount = AccountNameList.Count.ToString();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void btn_Delete_CheckedItem_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow EachRow in gview_AccountName.Rows)
            {
                CheckBox EachCheckBox = (CheckBox)EachRow.FindControl("chk_AccountID");

                if (EachCheckBox.Checked)
                {
                    int RecordID = int.Parse(((Label)EachRow.FindControl("lbl_AccountID")).Text);

                    AccountName TheAccountName = new AccountName();
                    TheAccountName.AccountID = RecordID;

                    int ProcReturnValue = AccountNameManagement.GetInstance.DeleteAccount(TheAccountName);
                }

                BindGridView();
            }
        }

        protected void btn_New_Click(object sender, EventArgs e)
        {
            mview_Accounts.SetActiveView(view_InputControls);
			ResetTextBoxes();
			if (!(BasePage.HasAddPermission(this.Page)))
			{
				mview_Accounts.SetActiveView(view_GridView);
			}
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            if (ValidateFormFields())
            {
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = InsertRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Account", MicroEnums.DataOperation.AddNew);
                }
                else
                {
                    ProcReturnValue = UpdateRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Account", MicroEnums.DataOperation.Edit);
                }

                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    BindGridView();
                    ResetTextBoxes();
                }
            }

            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            if (PageVariables.ThisAccountNameList != null)
                BindGridView(PageVariables.ThisAccountNameList);
            else
                BindGridView();
			BasePage.ShowHidePagePermissions(gview_AccountName, btn_New, this.Page);
            mview_Accounts.SetActiveView(view_GridView);
        }
        #endregion

        #region Methods & Implementation
        private void SetValidationMessages()
        {
            requiredFieldValidator_AccountHeads.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_AccessType.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_AnalysisFlag.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_ParentAccountName.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            requiredFieldValidator_AccountName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Account Name");
            requiredFieldValidator_AccountHeads.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Access Head");
            requiredFieldValidator_AccessType.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Access Type");
            requiredFieldValidator_AnalysisFlag.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Analysis Flag");
            requiredFieldValidator_ParentAccountName.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Account Name");

            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            requiredFieldValidator_AccountName.CssClass = theClassName;
            requiredFieldValidator_AccountHeads.CssClass = theClassName;
            requiredFieldValidator_AccessType.CssClass = theClassName;
            requiredFieldValidator_AnalysisFlag.CssClass = theClassName;
            requiredFieldValidator_ParentAccountName.CssClass = theClassName;
        }

        private void BindDropDown()
        {
            BindDropdown_AccountHeads();
            BindDropdown_AccessType();
            BindDropdown_AnalysisFlag("");
            BindDropdown_AccounNames(ddl_AnalysisFlag.Text);
        }

        private void BindDropdown_AccountHeads()
        {
            ClearListItems(ddl_ParentAccountName, false);

            List<AccountHead> AccountHeadList = AccountHeadManagement.GetInstance.GetAccountHeadList();

            ddl_AccountHeads.DataSource = AccountHeadList;
            ddl_AccountHeads.DataTextField = AccountHeadManagement.GetInstance.DisplayMember;
            ddl_AccountHeads.DataValueField = AccountHeadManagement.GetInstance.ValueMember;
            ddl_AccountHeads.DataBind();

            ddl_AccountHeads.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

            SetDefaultItemText(ddl_ParentAccountName);
        }

        private void BindDropdown_AccessType()
        {
            foreach (MicroEnums.AccountAccessType theString in Enum.GetValues(typeof(MicroEnums.AccountAccessType)))
            {
                ddl_AccessType.Items.Add(new ListItem(theString.GetStringValue(), theString.ToString()));
            }

            ddl_AccessType.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void BindDropdown_AnalysisFlag(string accountHeadType)
        {
            ClearListItems(ddl_AnalysisFlag, false);

            if (accountHeadType.Equals(MicroEnums.AccountHeadType.Receipt.GetStringValue()))
            {
                foreach (MicroEnums.AnalysisFlagReceipt theString in Enum.GetValues(typeof(MicroEnums.AnalysisFlagReceipt)))
                {
                    ddl_AnalysisFlag.Items.Add(new ListItem(theString.GetStringValue(), theString.ToString()));
                }
            }
            else if (accountHeadType.Equals(MicroEnums.AccountHeadType.Payment.GetStringValue()))
            {
                foreach (MicroEnums.AnalysisFlagPayment theString in Enum.GetValues(typeof(MicroEnums.AnalysisFlagPayment)))
                {
                    ddl_AnalysisFlag.Items.Add(new ListItem(theString.GetStringValue(), theString.ToString()));
                }
            }

            ddl_AnalysisFlag.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

            SetDefaultItemText(ddl_AnalysisFlag);
        }

        private void BindDropdown_AccounNames(string analysisFlag)
        {
            ClearListItems(ddl_ParentAccountName, false);

            if (!analysisFlag.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
            {
                List<AccountName> AccountNameList;

                if (PageVariables.ThisAccountNameList != null)
                    AccountNameList = AccountNameManagement.GetInstance.GetAccountListByAnalysisFlag(PageVariables.ThisAccountNameList, analysisFlag);
                else
                    AccountNameList = AccountNameManagement.GetInstance.GetAccountListByAnalysisFlag(analysisFlag);

                ddl_ParentAccountName.DataSource = AccountNameList;
                ddl_ParentAccountName.DataTextField = AccountNameManagement.GetInstance.DisplayMember;
                ddl_ParentAccountName.DataValueField = AccountNameManagement.GetInstance.ValueMember;
                ddl_ParentAccountName.DataBind();
            }

            ddl_ParentAccountName.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

            SetDefaultItemText(ddl_ParentAccountName);
        }

        public void BindGridView(List<AccountName> accountNameList = null)
        {
            gview_AccountName.DataSource = null;
            gview_AccountName.DataBind();

            if (accountNameList == null)
            {
                PageVariables.ThisAccountNameList = AccountNameManagement.GetInstance.GetAccountList();
                accountNameList = PageVariables.ThisAccountNameList;
            }
            if (accountNameList.Count > 0)
            {
                gview_AccountName.DataSource = accountNameList;
                gview_AccountName.DataBind();
            }
        }

        private List<AccountName> GetSearchAccountNameList()
        {
            List<AccountName> SearchList = new List<AccountName>();

            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            //Search By - Account Name
            if (searchField.Equals(MicroEnums.SearchAccountName.Name.ToString()))
            {
                if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                {
                    SearchList = (from AccountNames in PageVariables.ThisAccountNameList
                                  where AccountNames.AccountDescription.ToUpper().StartsWith(searchText.ToUpper())
                                  select AccountNames).ToList();
                }

                if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                {
                    SearchList = (from AccountNames in PageVariables.ThisAccountNameList
                                  where AccountNames.AccountDescription.ToUpper().Contains(searchText.ToUpper())
                                  select AccountNames).ToList();
                }
            }

            //Search By - Account Head
            if (searchField.Equals(MicroEnums.SearchAccountName.AccountHead.ToString()))
            {
                if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                {
                    SearchList = (from AccountNames in PageVariables.ThisAccountNameList
                                  where AccountNames.AccountHeadDescription.ToUpper().StartsWith(searchText.ToUpper())
                                  select AccountNames).ToList();
                }

                if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                {
                    SearchList = (from AccountNames in PageVariables.ThisAccountNameList
                                  where AccountNames.AccountHeadDescription.ToUpper().Contains(searchText.ToUpper())
                                  select AccountNames).ToList();
                }
            }

            //Search By - Access Type
            if (searchField.Equals(MicroEnums.SearchAccountName.AccessType.ToString()))
            {
                if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                {
                    SearchList = (from AccountNames in PageVariables.ThisAccountNameList
                                  where AccountNames.AccessType.ToUpper().StartsWith(searchText.ToUpper())
                                  select AccountNames).ToList();
                }

                if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                {
                    SearchList = (from AccountNames in PageVariables.ThisAccountNameList
                                  where AccountNames.AccessType.ToUpper().Contains(searchText.ToUpper())
                                  select AccountNames).ToList();
                }
            }

            //Search By - Analysis Flag
            if (searchField.Equals(MicroEnums.SearchAccountName.AnalysisFlag.ToString()))
            {
                if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                {
                    SearchList = (from AccountNames in PageVariables.ThisAccountNameList
                                  where AccountNames.AnalysisFlag.ToUpper().StartsWith(searchText.ToUpper())
                                  select AccountNames).ToList();
                }

                if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                {
                    SearchList = (from AccountNames in PageVariables.ThisAccountNameList
                                  where AccountNames.AnalysisFlag.ToUpper().Contains(searchText.ToUpper())
                                  select AccountNames).ToList();
                }
            }

            return SearchList;
        }

        private void EnableDisableParentAccount(bool enableState = true)
        {
            chk_TreatAsSubAccount.Checked = enableState;
            ddl_ParentAccountName.Enabled = enableState;
            requiredFieldValidator_ParentAccountName.Enabled = enableState;

            if (enableState)
                SetDefaultItemText(ddl_ParentAccountName);
        }

        private void PopulateFormFields()
        {
            BindDropdown_AccountHeads();
            BindDropdown_AnalysisFlag(PageVariables.ThisAccountName.AccountHeadType);
            BindDropdown_AccounNames(PageVariables.ThisAccountName.AnalysisFlag);

            txt_AccountName.Text = PageVariables.ThisAccountName.AccountDescription;
            ddl_AccountHeads.Text = PageVariables.ThisAccountName.AccountHeadID.ToString();
            ddl_AccessType.Text = PageVariables.ThisAccountName.AccessType;
            ddl_AnalysisFlag.Text = PageVariables.ThisAccountName.AnalysisFlag;

            if (PageVariables.ThisAccountName.ParentAccountID > 0)
            {
                EnableDisableParentAccount();
                ddl_ParentAccountName.Text = PageVariables.ThisAccountName.ParentAccountID.ToString();
            }
            else
            {
                EnableDisableParentAccount(false);
            }

            ChangeBackColor(view_InputControls);
        }

        private void HideGridViewColumns()
        {
            if (((User)Session["CurrentUser"]).RoleDescription.Equals("User"))
            {
                int[] theArray = { 6, 7 };
                BasePage.HideGridViewColumns(gview_AccountName, theArray);
            }
            else if (((User)Session["CurrentUser"]).RoleDescription.Equals("Manager"))
            {
                int[] theArray = { 7 };
                BasePage.HideGridViewColumns(gview_AccountName, theArray);
            }
        }

        public bool ValidateFormFields()
        {
            bool ReturnValue = true;

            return ReturnValue;
        }

        private int InsertRecord()
        {
            int ProcReturnValue = 0;

            AccountName TheAccountName = new AccountName();

            TheAccountName.AccountDescription = ToProper(txt_AccountName.Text);
            TheAccountName.AccountHeadID = int.Parse(ddl_AccountHeads.SelectedValue);
            TheAccountName.AccessType = ddl_AccessType.Text;
            TheAccountName.AnalysisFlag = ddl_AnalysisFlag.Text;
            if (chk_TreatAsSubAccount.Checked)
            {
                TheAccountName.ParentAccountID = int.Parse(ddl_ParentAccountName.SelectedValue);
            }

            ProcReturnValue = AccountNameManagement.GetInstance.InsertAccount(TheAccountName);

            return ProcReturnValue;
        }

        private int UpdateRecord()
        {
            int ProcReturnValue = 0;

            PageVariables.ThisAccountName.AccountDescription = ToProper(txt_AccountName.Text);
            PageVariables.ThisAccountName.AccountHeadID = int.Parse(ddl_AccountHeads.SelectedValue);
            PageVariables.ThisAccountName.AccessType = ddl_AccessType.Text;
            PageVariables.ThisAccountName.AnalysisFlag = ddl_AnalysisFlag.Text;
            if (chk_TreatAsSubAccount.Checked)
                PageVariables.ThisAccountName.ParentAccountID = int.Parse(ddl_ParentAccountName.SelectedValue);
            else
                PageVariables.ThisAccountName.ParentAccountID = 0;

            ProcReturnValue = AccountNameManagement.GetInstance.UpdateAccount(PageVariables.ThisAccountName);

            return ProcReturnValue;
        }

        private int DeleteRecord()
        {
            int ProcReturnValue = 0;

            ProcReturnValue = AccountNameManagement.GetInstance.DeleteAccount(PageVariables.ThisAccountName);
            return ProcReturnValue;
        }

        private static void ResetPageVariables()
        {
            PageVariables.ThisAccountName = null;
            PageVariables.ThisAccountNameList = null;
        }

        private void ResetTextBoxes()
        {
            txt_AccountName.Text = string.Empty;
            SetDefaultItemText(ddl_AccountHeads);
            SetDefaultItemText(ddl_AccessType);
            SetDefaultItemText(ddl_AnalysisFlag);
            SetDefaultItemText(ddl_ParentAccountName);
            EnableDisableParentAccount(false);

			ResetBackColor(view_InputControls);

            PageVariables.ThisAccountName = null;

            ResetBackColor(view_InputControls);
            lbl_DataOperationMode.Text = "ADD NEW ACCOUNT";
            btn_Submit.Text = String.Format(" {0} ", MicroEnums.DataOperation.Save.GetStringValue());
			btn_Submit.Visible = true;
        }
        #endregion
    }
}