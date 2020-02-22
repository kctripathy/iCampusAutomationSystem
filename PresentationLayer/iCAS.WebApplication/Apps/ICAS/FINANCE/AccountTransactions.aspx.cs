using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.ICAS.FINANCE;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;
using Micro.Objects.ICAS.FINANCE;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.FINANCE
{
    /// <summary>
    /// Manage Day-To-Day Transactions such as Income, Expenses, Receipt and Payments
    /// </summary>
    /// <author> Syed Ameer </author>
    /// <date> 12-Oct-2012 </date>

    public partial class AccountTransactions : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static decimal OpeningBalance;
            public static AccountTransaction ThisAccountTransaction;
            public static MicroEnums.VoucherEntryType VoucherEntryType;
            public static List<AccountTransaction> ThisAccountTransactionList;
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
            //ctrl_Search.OnButtonClick += ctrl_Search_ButtonClick;

            if (!IsPostBack && !IsCallback)
            {
                lbl_OpeningBalance.Text = "Transaction Details";
                SetValidationMessages();
                BindDropDown();
                //if (HasAddPermission() && IsDefaultModeAdd())
                //{
                    //multiView_AccountTransaction.SetActiveView(view_InputControls);
                    ResetBackColor(view_InputControls);
                    txt_TransactionDate.Text = DateTime.Today.ToShortDateString();
                    //ShowCashBalances();
                //}
                //else
                //{
                    BindGridView();
                    //BasePage.ShowHidePagePermissions(gview_AccountTransaction, btn_New, this.Page);
                    //HideGridViewColumns();
                    multiView_AccountTransaction.SetActiveView(view_GridView);
                //}
                ctrl_Search.SearchWhat = MicroEnums.SearchForm.AccountTransaction.ToString();
            }
        }

        protected void radio_PaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetVoucherType();
            Bind_Accounts();
        }

        protected void gview_AccountTransaction_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_AccountTransaction.PageIndex = e.NewPageIndex;
            BindGridView(PageVariables.ThisAccountTransactionList);
        }

        protected void gview_AccountTransaction_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            int RecordID = int.Parse(((Label)gview_AccountTransaction.Rows[RowIndex].FindControl("lbl_TransactionID")).Text);
            PageVariables.ThisAccountTransaction = AccountTransactionManagement.GetInstance.GetAccountTransactionByID(RecordID);

            if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
            {
                int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
                ProcReturnValue = DeleteRecord(RecordID);

                if (ProcReturnValue > 0)
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_ACCOUNT_TRANSACTION_DELETED");
                    BindGridView();
                }
                else
                {
                    lbl_TheMessage.Text = ReadXML.GetSuccessMessage("KO_ACCOUNT_TRANSACTION_DELETED");
                }
                dialog_Message.Show();
            }
        }

        protected void gview_AccountTransaction_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 7);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                    BasePage.GridViewToolTips(e, 0, 7);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
            }
        }

        protected void gview_AccountTransaction_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        private void ctrl_Search_ButtonClick(object sender, System.EventArgs e)
        {
            List<AccountTransaction> AccountTransactionList = GetSearchAccountTransactionList();

            BindGridView(AccountTransactionList);
            ctrl_Search.SearchResultCount = AccountTransactionList.Count.ToString();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void btn_Delete_CheckedItem_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow EachRow in gview_AccountTransaction.Rows)
            {
                CheckBox EachCheckBox = (CheckBox)EachRow.FindControl("chk_TransactionID");

                if (EachCheckBox.Checked)
                {
                    int RecordID = int.Parse(((Label)EachRow.FindControl("lbl_TransactionID")).Text);

                    AccountTransaction TheAccountTransaction = new AccountTransaction();
                    TheAccountTransaction.TransactionID = RecordID;

                    int ProcReturnValue = AccountTransactionManagement.GetInstance.DeleteAccountTransaction(TheAccountTransaction, RecordID);
                }
                BindGridView();
            }
        }

        protected void btn_New_Click(object sender, EventArgs e)
        {
            txt_TransactionDate.Text = DateTime.Today.ToShortDateString();
            //ShowCashBalances();

            if (PageVariables.OpeningBalance >= 0)
                ResetTextBoxes();
            multiView_AccountTransaction.SetActiveView(view_InputControls);
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            //if (ValidateFormFields())
            //{
                if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                {
                    ProcReturnValue = InsertRecord();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Transaction", MicroEnums.DataOperation.AddNew);
                }

                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    ResetTextBoxes();
                   // ShowCashBalances();
                    ResetBackColor(view_InputControls);
                }
            //}

            if (!string.IsNullOrEmpty(lbl_TheMessage.Text))
                dialog_Message.Show();
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            BindGridView();
            //BasePage.ShowHidePagePermissions(gview_AccountTransaction, btn_New, this.Page); //TO DO :KP
            multiView_AccountTransaction.SetActiveView(view_GridView);
        }
        #endregion

        #region Methods & Implementation
        private void SetValidationMessages()
        {
            ajaxFilteredTextBox_ThirdParty.ValidChars = MicroConstants.VALID_CHAR_NAME;

            regularExpressionValidator_ThirdParty.ValidationExpression = MicroConstants.REGEX_NAME;
            regularExpressionValidator_Amount.ValidationExpression = MicroConstants.REGEX_NUMBER_GREATERTHANZERO;

            requiredFieldValidator_Accounts.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_PaymentMode.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

            requiredFieldValidator_Accounts.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Account");
            requiredFieldValidator_ThirdParty.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Third Party Description");
            regularExpressionValidator_ThirdParty.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NAME");
            requiredFieldValidator_Amount.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Transaction Amount");
            regularExpressionValidator_Amount.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_GREATERTHANZERO");
            requiredFieldValidator_PaymentMode.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Payment mode");

            SetFormMessageCSSClass("ValidateMessage");
        }

        private void SetFormMessageCSSClass(string theClassName)
        {
            regularExpressionValidator_ThirdParty.CssClass = theClassName;
            regularExpressionValidator_Amount.CssClass = theClassName;

            requiredFieldValidator_Accounts.CssClass = theClassName;
            requiredFieldValidator_ThirdParty.CssClass = theClassName;
            requiredFieldValidator_Amount.CssClass = theClassName;
            requiredFieldValidator_PaymentMode.CssClass = theClassName;
        }

        private void BindDropDown()
        {
            Bind_Accounts();
            Bind_PaymentMode();
        }

        private void Bind_Accounts()
        {
            List<AccountHead> AccountHeadList = AccountHeadManagement.GetInstance.GetAccountHeadList();
            List<AccountHead> FilteredAccountHeadList;
            if (radio_PaymentType.Text.Equals(MicroEnums.VoucherType.DebitVoucher.GetStringValue()))
                FilteredAccountHeadList = (from AccountNameRow in AccountHeadList
                                           where AccountNameRow.AccountHeadType.Equals("Expenses") || AccountNameRow.AccountHeadType.Equals("Payment")
                                           select AccountNameRow).ToList();
            else if (radio_PaymentType.Text.Equals(MicroEnums.VoucherType.CreditVoucher.GetStringValue()))
                FilteredAccountHeadList = (from AccountNameRow in AccountHeadList
                                           where AccountNameRow.AccountHeadType.Equals("Receipt") || AccountNameRow.AccountHeadType.Equals("Income")
                                           select AccountNameRow).ToList();
            else
                FilteredAccountHeadList = null;
            ddl_AccountHeads.Items.Clear();
            ddl_AccountHeads.DataSource = FilteredAccountHeadList;
            ddl_AccountHeads.DataTextField = AccountHeadManagement.GetInstance.DisplayMember;
            ddl_AccountHeads.DataValueField = AccountHeadManagement.GetInstance.ValueMember;
            ddl_AccountHeads.DataBind();


            //List<AccountName> AccountNameList = AccountNameManagement.GetInstance.GetAccountListByAccessType(MicroEnums.AccountAccessType.Manual.GetStringValue());
            //List<AccountName> FilteredAccountNameList;

            //if (radio_PaymentType.Text.Equals(MicroEnums.VoucherType.DebitVoucher.GetStringValue()))
            //    FilteredAccountNameList = (from AccountNameRow in AccountNameList
            //                               where AccountNameRow.AnalysisFlag.Equals("Expenses") || AccountNameRow.AnalysisFlag.Equals("Payment")
            //                               select AccountNameRow).ToList();
            //else if (radio_PaymentType.Text.Equals(MicroEnums.VoucherType.CreditVoucher.GetStringValue()))
            //    FilteredAccountNameList = (from AccountNameRow in AccountNameList
            //                               where AccountNameRow.AnalysisFlag.Equals("Receipt") || AccountNameRow.AnalysisFlag.Equals("Income")
            //                               select AccountNameRow).ToList();
            //else
            //    FilteredAccountNameList = null;

            //ddl_Accounts.DataSource = FilteredAccountNameList;
            //ddl_Accounts.DataTextField = AccountNameManagement.GetInstance.DisplayMember;
            //ddl_Accounts.DataValueField = AccountNameManagement.GetInstance.ValueMember;
            //ddl_Accounts.DataBind();

            ddl_AccountHeads.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        private void Bind_PaymentMode()
        {
            ddl_PaymentMode.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.PaymentMode.GetStringValue());
            ddl_PaymentMode.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
            ddl_PaymentMode.DataBind();

            ddl_PaymentMode.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
        }

        public void BindGridView(List<AccountTransaction> accountTransactionList = null)
        {
            gview_AccountTransaction.DataSource = null;

            if (accountTransactionList == null)
            {
                PageVariables.ThisAccountTransactionList = AccountTransactionManagement.GetInstance.GetAccountTransactionList();
                accountTransactionList = PageVariables.ThisAccountTransactionList;
            }

            if (accountTransactionList.Count > 0)
            {
                gview_AccountTransaction.DataSource = accountTransactionList;
            }

            gview_AccountTransaction.DataBind();
        }

        private List<AccountTransaction> GetSearchAccountTransactionList()
        {
            List<AccountTransaction> SearchList = new List<AccountTransaction>();

            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            //Search By - Account Description
            if (searchField.Equals(MicroEnums.SearchAccountTransaction.AccountName.ToString()))
            {
                if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                {
                    SearchList = (from AccountTransactionRow in PageVariables.ThisAccountTransactionList
                                  where AccountTransactionRow.AccountDescription.ToUpper().StartsWith(searchText.ToUpper())
                                  select AccountTransactionRow).ToList();
                }

                if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                {
                    SearchList = (from AccountTransactionRow in PageVariables.ThisAccountTransactionList
                                  where AccountTransactionRow.AccountDescription.ToUpper().Contains(searchText.ToUpper())
                                  select AccountTransactionRow).ToList();
                }
            }

            //Search By - Head Type
            if (searchField.Equals(MicroEnums.SearchAccountTransaction.HeadType.ToString()))
            {
                if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                {
                    SearchList = (from AccountTransactionRow in PageVariables.ThisAccountTransactionList
                                  where AccountTransactionRow.AccountHeadType.ToUpper().StartsWith(searchText.ToUpper())
                                  select AccountTransactionRow).ToList();
                }

                if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                {
                    SearchList = (from AccountTransactionRow in PageVariables.ThisAccountTransactionList
                                  where AccountTransactionRow.AccountHeadType.ToUpper().Contains(searchText.ToUpper())
                                  select AccountTransactionRow).ToList();
                }
            }

            //Search By - ThirdParty
            if (searchField.Equals(MicroEnums.SearchAccountTransaction.ThirdParty.ToString()))
            {
                if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                {
                    SearchList = (from AccountTransactionRow in PageVariables.ThisAccountTransactionList
                                  where AccountTransactionRow.ThirdPartyDescription.ToUpper().StartsWith(searchText.ToUpper())
                                  select AccountTransactionRow).ToList();
                }

                if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                {
                    SearchList = (from AccountTransactionRow in PageVariables.ThisAccountTransactionList
                                  where AccountTransactionRow.ThirdPartyDescription.ToUpper().Contains(searchText.ToUpper())
                                  select AccountTransactionRow).ToList();
                }
            }
            return SearchList;
        }

        private void ShowCashBalances()
        {
            PageVariables.OpeningBalance = AccountTransactionManagement.GetInstance.GetCashBalances();

            if (PageVariables.OpeningBalance >= 0)
                lbl_OpeningBalance.Text = string.Format("Cash Balance as on {0} : Rs. {1}", txt_TransactionDate.Text, PageVariables.OpeningBalance);
            else
            {
                lbl_OpeningBalance.Text = "Opening Balance not set yet. Set Opening Balance first.";
                ResetOpeningBalanceInfo();
            }
        }

        private void HideGridViewColumns()
        {
            if (((User)Session["CurrentUser"]).RoleDescription.Equals("User"))
            {
                int[] theArray = { 7 };
                BasePage.HideGridViewColumns(gview_AccountTransaction, theArray);
            }
            else if (((User)Session["CurrentUser"]).RoleDescription.Equals("Manager"))
            {
                int[] theArray = { 7 };
                BasePage.HideGridViewColumns(gview_AccountTransaction, theArray);
            }
        }

        private bool ValidateOpeningBalance()
        {
            bool ReturnValue = true;
            regularExpressionValidator_Amount.ValidationExpression = MicroConstants.REGEX_NUMBER_GREATERTHANZERO;

            if (PageVariables.OpeningBalance < 0 && !ddl_AccountHeads.SelectedItem.Text.Equals("Opening Balance"))
            {
                ResetOpeningBalanceInfo();
                lbl_TheMessage.Text = "Opening Balance is not set yet. Set Opening Balance first.";

                ReturnValue = false;
            }

            if (ReturnValue)
            {
                if (PageVariables.OpeningBalance >= 0 && ddl_AccountHeads.SelectedItem.Text.Equals("Opening Balance"))
                {
                    lbl_TheMessage.Text = "You can't set Opening Balance twice.";
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }

        private bool ValidateNegativeBalance()
        {
            bool ReturnValue = true;

            if (radio_PaymentType.Text.Equals(MicroEnums.VoucherType.DebitVoucher.GetStringValue()))
            {
                if (PageVariables.OpeningBalance < decimal.Parse(txt_Amount.Text))
                {
                    lbl_TheMessage.Text = "Excess payment than available Cash Balance.";
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }

        public bool ValidateFormFields()
        {
            bool ReturnValue = true;

            if (ReturnValue)
            {
                ReturnValue = ValidateOpeningBalance();
            }

            if (ReturnValue)
            {
                ReturnValue = ValidateNegativeBalance();
            }

            return ReturnValue;
        }

        private int InsertRecord()
        {
            int ProcReturnValue = 0;

            AccountTransaction TheAccountTransaction = new AccountTransaction();

            TheAccountTransaction.TransactionDate = txt_TransactionDate.Text;
            TheAccountTransaction.AccountID = int.Parse(ddl_AccountHeads.SelectedValue);
            TheAccountTransaction.AccountHeadID = int.Parse(ddl_AccountHeads.SelectedValue);
            TheAccountTransaction.TransactionToCategory = radio_Trans_Category.SelectedValue;
            TheAccountTransaction.TransactionToID = DropDown_TrsndID.SelectedItem.Text;
            TheAccountTransaction.ThirdPartyDescription = ToProper(txt_ThirdParty.Text);
            TheAccountTransaction.TransactionAmount = decimal.Parse(txt_Amount.Text);
            TheAccountTransaction.TransactionMode = ddl_PaymentMode.Text;
            TheAccountTransaction.TransactionReference = txt_Reference.Text;
            TheAccountTransaction.BankName = txt_BankName.Text;
            TheAccountTransaction.ChqDate = txt_ChqDAte.Text;
            TheAccountTransaction.ChqNumber = txt_ChqNo.Text;
            TheAccountTransaction.EntrySide = PageVariables.VoucherEntryType.GetStringValue();
            TheAccountTransaction.Remarks = ToProper(txt_Remark.Text);

            ProcReturnValue = AccountTransactionManagement.GetInstance.InsertAccountTransaction(TheAccountTransaction);

            return ProcReturnValue;
        }

        public static int DeleteRecord(int Record)
        {
            int ProcReturnValue = 0;

            ProcReturnValue = AccountTransactionManagement.GetInstance.DeleteAccountTransaction(PageVariables.ThisAccountTransaction, Record);
            return ProcReturnValue;
        }

        private void ResetOpeningBalanceInfo()
        {
            radio_PaymentType.Text = MicroEnums.VoucherType.CreditVoucher.GetStringValue();

            regularExpressionValidator_Amount.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
            txt_Remark.Text = string.Format("Opening Balance as on {0}", txt_TransactionDate.Text);
            ddl_PaymentMode.Text = MicroEnums.PaymentMode.Cash.GetStringValue();
            txt_ThirdParty.Text = "Self";
            txt_Reference.Text = "-";
            txt_Amount.Text = "0";
            txt_Amount.Focus();

            ResetVoucherType();
            Bind_Accounts();

            ddl_AccountHeads.SelectedValue = ddl_AccountHeads.Items.FindByText("Opening Balance").Value;
        }

        private void ResetVoucherType()
        {
            if (radio_PaymentType.Text.Equals(MicroEnums.VoucherType.DebitVoucher.GetStringValue()))
            {
                lbl_ThirdParty.Text = "Paid To";
                lbl_PaymentMode.Text = "Payment Mode";
                PageVariables.VoucherEntryType = MicroEnums.VoucherEntryType.DebitSide;
            }
            else
            {
                lbl_ThirdParty.Text = "Received From";
                lbl_PaymentMode.Text = "Receipt Mode";
                PageVariables.VoucherEntryType = MicroEnums.VoucherEntryType.CreditSide;
            }
        }

        private void ResetTextBoxes()
        {
            radio_PaymentType.SelectedValue = "Debit Voucher";            
            txt_ThirdParty.Text = string.Empty;
            DropDown_TrsndID.ClearSelection();
            DropDown_TrsndID.Items.Insert(0,MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            txt_BankName.Text = string.Empty;
            txt_ChqDAte.Text = string.Empty;
            txt_ChqNo.Text = string.Empty;
            radio_Trans_Category.SelectedValue = "Guest";
            txt_Amount.Text = string.Empty;
            txt_Reference.Text = string.Empty;
            txt_Remark.Text = string.Empty;

            BindDropDown();
            ResetVoucherType();
        }
        #endregion

        protected void DropDown_TrsndID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_ThirdParty.Text = DropDown_TrsndID.SelectedValue;
        }

        protected void radio_Trans_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDown_TrsndID.Items.Clear();
            if (radio_Trans_Category.SelectedValue == "Employee")
            {
               DropDown_TrsndID.DataSource= StaffMasterManagement.GetInstance.GetCompanyEmployeeList();
               DropDown_TrsndID.DataMember = StaffMasterManagement.GetInstance.ValueMember;
               DropDown_TrsndID.DataTextField = StaffMasterManagement.GetInstance.DisplayMember;
               DropDown_TrsndID.DataBind();
               DropDown_TrsndID.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            }
            else if (radio_Trans_Category.SelectedValue == "Student")
            {
                DropDown_TrsndID.DataSource = StudentManagement.GetInstance.GetStudentList();
                DropDown_TrsndID.DataMember = StudentManagement.DisplayValue;
                DropDown_TrsndID.DataTextField = StudentManagement.DisplayMember;
                DropDown_TrsndID.DataBind();
                DropDown_TrsndID.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            }
            else
            {                
                DropDown_TrsndID.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            
            }
        }

        protected void ddl_Accounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_PaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_PaymentMode.SelectedItem.Text == "Cash")
            {
                txt_ChqDAte.Enabled = false;
                txt_BankName.Enabled = false;
                txt_ChqNo.Enabled = false;
            }
            else
            {
                txt_ChqDAte.Enabled = true;
                txt_BankName.Enabled = true;
                txt_ChqNo.Enabled = true;
            }
        }
    }
}
