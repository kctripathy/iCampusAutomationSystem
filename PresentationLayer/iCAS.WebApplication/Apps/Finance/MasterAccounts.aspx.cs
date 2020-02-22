using System;
using System.Collections.Generic;
using System.Linq;
using Micro.BusinessLayer.FinancialAccounts;
using Micro.Commons;
using Micro.Objects;

namespace Micro.WebApplication.MicroERP.FINANCE
{
	/// <summary>
	/// Manage Master Accounts.
	/// </summary>
	public partial class MasterAccounts : BasePage
	{
		public static List<AccountLedger> AccountsList;
		
		protected void Page_Load(object sender, EventArgs e)
		{
			ctrl_Search.OnButtonClick += ctrlSearch_ButtonClicked;
			if (!IsPostBack)
			{
				BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
				BasePage.ShowHidePagePermissions(grid_AccountsMaster, btn_AddAccount, this.Page);
				ctrl_Search.SearchWhat = MicroEnums.SearchForm.Accounts.ToString();
				optList_AccountHeads.SelectedIndex = 0;
				BindDropdownAccountCategory(int.Parse(optList_AccountHeads.SelectedValue.ToString()));
				//((UC_Menu)Master.FindControl("ctrl_Menu")).SetActiveIndex = 2;
				BasePage.ChangeBackColor(view_InputControls);
			}

		}

		private void ctrlSearch_ButtonClicked(object sender, System.EventArgs e)
		{
			SearchAccountsBindGridView();
				
		}

		private void BindDropdownAccountCategory(int groupID)
		{
			ddl_AccountGroup.DataSource = AccountGroupManagement.GetInstance.GetAccountGroupList(groupID);
			ddl_AccountGroup.DataTextField = "AccountGroupDescription";
			ddl_AccountGroup.DataValueField = "AccountGroupID";
			ddl_AccountGroup.DataBind();
		}

		protected void optList_AccountHeads_SelectedIndexChanged(object sender, EventArgs e)
		{
			BindDropdownAccountCategory(int.Parse(optList_AccountHeads.SelectedValue.ToString()));
		}

		protected void btn_ViewTop_Click(object sender, EventArgs e)
		{
			multiview_AccountsMaster.ActiveViewIndex = 1;

			AccountsList = AccountLedgerManagement.GetInstance.GetAccountLedgerList(string.Empty);
			
			grid_AccountsMaster.DataSource = AccountsList;
			grid_AccountsMaster.DataBind();

		}

		protected void btn_SaveTop_Click(object sender, EventArgs e)
		{
			multiview_AccountsMaster.ActiveViewIndex = 0;
		}

		protected void btn_CancelTop_Click(object sender, EventArgs e)
		{
			multiview_AccountsMaster.ActiveViewIndex = 0;
		}

		protected void btn_AddAccount_Clicked(object sender, EventArgs e)
		{
			multiview_AccountsMaster.ActiveViewIndex = 0;
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

	}
}