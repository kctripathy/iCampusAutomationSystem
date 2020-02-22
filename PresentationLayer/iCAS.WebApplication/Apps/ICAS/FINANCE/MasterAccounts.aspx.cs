using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.ICAS.FINANCE;
using Micro.Commons;
using Micro.Objects.ICAS.FINANCE;
using Micro.Objects;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.FINANCE
{
	/// <summary>
	/// Manage Master Accounts.
	/// </summary>
	public partial class MasterAccounts : BasePage
	{
		public static List<AccountLedger> AccountsList;
        private AccountMaster ThisAccountMaster;
        private List<AccountMaster> ThisAccountMasterList;
		protected void Page_Load(object sender, EventArgs e)
		{
			ctrl_Search.OnButtonClick += ctrlSearch_ButtonClicked;
			if (!IsPostBack)
			{
				BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
				BasePage.ShowHidePagePermissions(grid_AccountsMaster, btn_AddAccount, this.Page);
				ctrl_Search.SearchWhat = MicroEnums.SearchForm.Accounts.ToString();
				optList_AccountHeads.SelectedIndex = 0;
                FillAccounts(int.Parse(optList_AccountHeads.SelectedValue));
                FillGridView();
				//((UC_Menu)Master.FindControl("ctrl_Menu")).SetActiveIndex = 2;
				BasePage.ChangeBackColor(view_InputControls);
			}
		}
		private void ctrlSearch_ButtonClicked(object sender, System.EventArgs e)
		{
			SearchAccountsBindGridView();
				
		}
        //private void BindDropdownAccountCategory(int groupID)
        //{
        //    ddl_AccountGroup.DataSource = AccountGroupManagement.GetInstance.GetAccountGroupList(groupID);
        //    ddl_AccountGroup.DataTextField = "AccountGroupDescription";
        //    ddl_AccountGroup.DataValueField = "AccountGroupID";
        //    ddl_AccountGroup.DataBind();
        //}
        private void FillAccounts(int accountGroupParentID)
        {
            List<AccountGroup> theAccountGroupList = AccountGroupManagement.GetInstance.GetAccountGroupList();
            var FilterdAccountGroupList = (from mm in theAccountGroupList
                                           where
                                               mm.AccountGroupParentID == accountGroupParentID
                                           select mm).ToList();
            if (FilterdAccountGroupList.Count > 0)
            {
                ddl_AccountGroup.DataSource = FilterdAccountGroupList;
                ddl_AccountGroup.DataTextField = AccountGroupManagement.GetInstance.DisplayMember;
                ddl_AccountGroup.DataValueField = AccountGroupManagement.GetInstance.ValueMember;
                ddl_AccountGroup.DataBind();
                ddl_AccountGroup.Items.Insert(MicroConstants.NUMERIC_VALUE_ZERO, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
            }
        }
		protected void optList_AccountHeads_SelectedIndexChanged(object sender, EventArgs e)
		{
            FillAccounts(int.Parse(optList_AccountHeads.SelectedValue.ToString()));
		}

		protected void btn_ViewTop_Click(object sender, EventArgs e)
        {
            FillGridView();
		}
        public int InsertRecord()
        {
            int ProcReturnValue = 0;
            AccountMaster TheAccount = new AccountMaster();

            TheAccount.AccountGroupID = int.Parse(ddl_AccountGroup.SelectedValue);
            TheAccount.AccountDescription = txt_AccountName.Text;
            //TheAccount.AccountCode = txt_AccountCode.Text;
            ProcReturnValue = AccountMasterManagement.GetInstance.InsertAccountMaster(TheAccount);

            return ProcReturnValue;
        }
        public bool ValidateFormFields()
        {
            return true;
        }
        private void FillGridView(int accountGroupParentID)
        {
            ThisAccountMasterList = AccountMasterManagement.GetInstance.GetAccountMasterList();
            var AccountListByParentAccountList = ThisAccountMasterList.Where(a => a.AccountGroupID.Equals(accountGroupParentID)).ToList();
            if (AccountListByParentAccountList.Count > 0)
            {
                GridAccount.DataSource = AccountListByParentAccountList;
                GridAccount.DataBind();
            }
            else
            {
                GridAccount.DataSource = null;
            }           
        }
		protected void btn_SaveTop_Click(object sender, EventArgs e)
		{
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            try
            {               
                if (ValidateFormFields())
                {
                    if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
                    {
                        ProcReturnValue = InsertRecord();

                        if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                        {
                            lbl_TheMessage.Text = "Account Created Successfully";
                            dialog_Message.Show();                            
                            ResetControls();
                            FillGridView();
                            multiview_AccountsMaster.SetActiveView(view_Grid);
                            //EnableDisableUserInputs(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }                       
		}
        private void FillGridView()
        {
            grid_AccountsMaster.DataSource = AccountMasterManagement.GetInstance.GetAccountMasterList();
            grid_AccountsMaster.DataBind();
            multiview_AccountsMaster.SetActiveView(view_Grid);
        }

        private void ResetControls()
        {
            optList_AccountHeads.SelectedValue = MicroConstants.NUMERIC_ONE.ToString();
            ddl_AccountGroup.SelectedIndex = MicroConstants.NUMERIC_ONE;
            txt_AccountName.Text = string.Empty;
            txt_AccountDesc.Text = string.Empty;            
        }

		protected void btn_CancelTop_Click(object sender, EventArgs e)
		{
            ResetControls();
		}

		protected void btn_AddAccount_Clicked(object sender, EventArgs e)
		{
            ResetControls();
            multiview_AccountsMaster.SetActiveView(view_InputControls);
		}


		private void SearchAccountsBindGridView()
		{
			string searchText = ctrl_Search.SearchText;
			string searchOperator = ctrl_Search.SearchOperator;
			string searchField = ctrl_Search.SearchField;

			List<AccountLedger> SearchList = new List<AccountLedger>();
			// Search by name
			if (searchField == MicroEnums.SearchAccount.AccountName.ToString())
			{
				if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
				{
					SearchList = (from aa in AccountsList
								  where aa.AccountLedgerDescription.ToUpper().StartsWith(searchText.ToUpper())
								  select aa).ToList();
				}
			}

			ctrl_Search.SearchResultCount = SearchList.Count.ToString();
			grid_AccountsMaster.DataSource = SearchList;
			grid_AccountsMaster.DataBind();
		}

        protected void ddl_AccountGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int accountGroupParentID = int.Parse(ddl_AccountGroup.SelectedValue);
                FillGridView(accountGroupParentID);
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridAccount_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lbl_TheMessage.Text = "Modification Not Allowed";
                dialog_Message.Show();
            }
            catch
            {
                lbl_TheMessage.Text = "Modification Not Allowed";
                dialog_Message.Show();
            }
        }

	}
}