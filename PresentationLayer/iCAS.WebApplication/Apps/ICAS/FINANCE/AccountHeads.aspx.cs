using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.FinancialAccounts;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;
using Micro.Objects.FinancialAccounts;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.FINANCE
{
	/// <summary>
	/// Manages Account Heads
	/// </summary>
	/// <author> Deepak Kumar Biswal </author>
	/// <date> 10-Oct-2012 </date>
	public partial class AccountHeads : BasePage
	{
		#region Declaration
		protected static class PageVariables
		{
			public static AccountHead ThisAccountHead;
			public static List<AccountHead> ThisAccountHeadList;
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
            //BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
			
            //ctrl_Search.OnButtonClick += ctrl_Search_ButtonClick;
            //BasePage.ShowHidePagePermissions(gview_AccountHead, btn_New, this.Page);
			if (!IsPostBack && !IsCallback)
			{
				SetValidationMessages();
				ResetPageVariables();
				BindDropDown();
                //multiView_AccountHeads.SetActiveView(view_InputControls);
                //if (HasAddPermission() && IsDefaultModeAdd())
                //{
					multiView_AccountHeads.SetActiveView(view_InputControls);
                    //ResetBackColor(view_InputControls);
					EnableDisableParentAccountHead(false);
                //}
                //else
                //{
					BindGridView();
					gview_AccountHead.AutoGenerateEditButton = false;
                    //BasePage.ShowHidePagePermissions(gview_AccountHead, btn_New, this.Page);
					//HideGridViewColumns();
					multiView_AccountHeads.SetActiveView(view_GridView);
                //}
                ctrl_Search.SearchWhat = MicroEnums.SearchForm.AccountHead.ToString();
			}
		}

		protected void ddl_AccountHeadType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (chk_TreatAsSubHead.Checked)
				BindDropdown_AccountHeads(ddl_AccountHeadType.SelectedItem.Text);
		}

		protected void chk_TreatAsSubHead_CheckedChanged(object sender, EventArgs e)
		{
			bool CheckState = chk_TreatAsSubHead.Checked;

			if (CheckState)
				BindDropdown_AccountHeads(ddl_AccountHeadType.SelectedItem.Text);

			EnableDisableParentAccountHead(CheckState);
		}

		protected void gview_AccountHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gview_AccountHead.PageIndex = e.NewPageIndex;
			BindGridView(PageVariables.ThisAccountHeadList);
		}

		protected void gview_AccountHead_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int RowIndex = Convert.ToInt32(e.CommandArgument);
			int RecordID = int.Parse(((Label)gview_AccountHead.Rows[RowIndex].FindControl("lbl_AccountHeadID")).Text);
			lbl_DataOperationMode.Text = String.Format("EDIT ACCOUNT HEAD : {0} [{1}]", gview_AccountHead.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

			PageVariables.ThisAccountHead = AccountHeadManagement.GetInstance.GetAccountHeadByID(RecordID);

			if (e.CommandArgument.Equals("First"))
			{
				RowIndex = 0;
			}
			else if (e.CommandArgument.Equals("Last"))
			{
				RowIndex = gview_AccountHead.PageCount - 1;
			}
			else
			{
				RowIndex = Convert.ToInt32(e.CommandArgument);
			}

			if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
			{
				if (PageVariables.ThisAccountHead.IsPrimary.Equals(false))
				{
					btn_Submit.Text = String.Format(" {0} ", MicroEnums.DataOperation.Update.GetStringValue());
					multiView_AccountHeads.SetActiveView(view_InputControls);
					EnableControls(view_InputControls, true);
					PopulateFormFields();
					EnableDisableButtons();
				}
				else
				{
					lbl_TheMessage.Text = GetDataOperationResult(-4, "", MicroEnums.DataOperation.Edit);
					dialog_Message.Show();
				}
			}
			else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
			{
				int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

				if (PageVariables.ThisAccountHead.IsPrimary.Equals(false))
				{
					ProcReturnValue = DeleteRecord();
					lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Account Head", MicroEnums.DataOperation.Delete);

					if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
						BindGridView();
				}
				else
				{
					lbl_TheMessage.Text = GetDataOperationResult(-4, "AccountHead", MicroEnums.DataOperation.Delete);
				}

				dialog_Message.Show();
			}

			else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
			{

				lbl_DataOperationMode.Text = String.Format("VIEW ACCOUNT HEAD : {0} [{1}]", gview_AccountHead.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);

				multiView_AccountHeads.SetActiveView(view_InputControls);
				PopulateFormFields();
				EnableControls(view_InputControls, false);
				EnableDisableButtons(false);
			}
		}

		protected void gview_AccountHead_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					BasePage.GridViewOnDelete(e, 6);
					BasePage.GridViewOnClientMouseOver(e);
					BasePage.GridViewOnClientMouseOut(e);
					BasePage.GridViewToolTips(e, 5, 6);
				}
			}
			catch (Exception ex)
			{
				string msg = ex.Message.ToString();
			}
		}

		protected void gview_AccountHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			e.Cancel = true;
		}

		protected void gview_AccountHead_RowEditing(object sender, GridViewEditEventArgs e)
		{
			e.Cancel = true;
		}

		private void ctrl_Search_ButtonClick(object sender, System.EventArgs e)
		{
			List<AccountHead> AccountHeadList = GetSearchAccountHeadList();

			BindGridView(AccountHeadList);
			ctrl_Search.SearchResultCount = AccountHeadList.Count.ToString();
		}

		protected void btn_Cancel_Click(object sender, EventArgs e)
		{
			ResetTextBoxes();
			EnableDisableButtons();
		}

		protected void btn_Delete_CheckedItem_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow EachRow in gview_AccountHead.Rows)
			{
				CheckBox EachCheckBox = (CheckBox)EachRow.FindControl("chk_AccountHeadID");

				if (EachCheckBox.Checked)
				{
					int RecordID = int.Parse(((Label)EachRow.FindControl("lbl_AccountHeadID")).Text);

					AccountHead TheAccountHead = new AccountHead();
					TheAccountHead.AccountHeadID = RecordID;

					int ProcReturnValue = AccountHeadManagement.GetInstance.DeleteAccountHead(TheAccountHead);
				}

				BindGridView();
			}
		}

		protected void btn_New_Click(object sender, EventArgs e)
		{
			multiView_AccountHeads.SetActiveView(view_InputControls);
			EnableControls(view_InputControls, true);
			EnableDisableButtons();
			ResetTextBoxes();
            //if (!(BasePage.HasAddPermission(this.Page)))//TO DO
            //{
                //multiView_AccountHeads.SetActiveView(view_GridView);
            //}
		}

		protected void btn_Submit_Click(object sender, EventArgs e)
		{
			int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

			if (ValidateFormFields())
			{
				if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
				{
					ProcReturnValue = InsertRecord();
					lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Account Head", MicroEnums.DataOperation.AddNew);
				}
				else
				{
					ProcReturnValue = UpdateRecord();
					lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Account Head", MicroEnums.DataOperation.Edit);
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
			if (PageVariables.ThisAccountHeadList != null)
				BindGridView(PageVariables.ThisAccountHeadList);
			else
				BindGridView();
            //BasePage.ShowHidePagePermissions(gview_AccountHead, btn_New, this.Page);
			multiView_AccountHeads.SetActiveView(view_GridView);
		}
		#endregion

		#region Methods & Implementation
		private void SetValidationMessages()
		{
			requiredFieldValidator_AccountHeadType.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
			requiredFieldValidator_ParentAccountHeadName.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;

			requiredFieldValidator_AccountHeadName.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Account Head Name");
			requiredFieldValidator_AccountHeadType.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Account Head Type");
			requiredFieldValidator_ParentAccountHeadName.ErrorMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Account Head Name");

			SetFormMessageCSSClass("ValidateMessage");
		}

		private void SetFormMessageCSSClass(string theClassName)
		{
			requiredFieldValidator_AccountHeadName.CssClass = theClassName;
			requiredFieldValidator_AccountHeadType.CssClass = theClassName;
			requiredFieldValidator_ParentAccountHeadName.CssClass = theClassName;
		}

		private void BindDropDown()
		{
			BindDropdown_AccountHeadTypes();
			BindDropdown_AccountHeads(ddl_AccountHeadType.SelectedItem.Text);
		}

		private void BindDropdown_AccountHeadTypes()
		{
			ddl_AccountHeadType.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.AccountHeadType.GetStringValue());
			ddl_AccountHeadType.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_AccountHeadType.DataValueField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_AccountHeadType.DataBind();

			ddl_AccountHeadType.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);
		}

		private void BindDropdown_AccountHeads(string accountHeadType)
		{
			ClearListItems(ddl_ParentAccountHeadName, false);

			if (!accountHeadType.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
			{
				List<AccountHead> AccountHeadList;

				if (PageVariables.ThisAccountHeadList != null)
					AccountHeadList = AccountHeadManagement.GetInstance.GetAccountHeadListByType(PageVariables.ThisAccountHeadList, accountHeadType);
				else
					AccountHeadList = AccountHeadManagement.GetInstance.GetAccountHeadListByType(accountHeadType);

				ddl_ParentAccountHeadName.DataSource = AccountHeadList;
				ddl_ParentAccountHeadName.DataTextField = AccountHeadManagement.GetInstance.DisplayMember;
				ddl_ParentAccountHeadName.DataValueField = AccountHeadManagement.GetInstance.ValueMember;
				ddl_ParentAccountHeadName.DataBind();
			}

			ddl_ParentAccountHeadName.Items.Insert(0, MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT);

			SetDefaultItemText(ddl_ParentAccountHeadName);
		}

		public void BindGridView(List<AccountHead> accountHeadList = null)
		{
			gview_AccountHead.DataSource = null;
			gview_AccountHead.DataBind();

			if (accountHeadList == null)
			{
				PageVariables.ThisAccountHeadList = AccountHeadManagement.GetInstance.GetAccountHeadList();
				accountHeadList = PageVariables.ThisAccountHeadList;
			}

			if (accountHeadList.Count > 0)
			{
				gview_AccountHead.DataSource = accountHeadList;
				gview_AccountHead.DataBind();
			}
		}

		private List<AccountHead> GetSearchAccountHeadList()
		{
			List<AccountHead> SearchList = new List<AccountHead>();

			string searchText = ctrl_Search.SearchText;
			string searchOperator = ctrl_Search.SearchOperator;
			string searchField = ctrl_Search.SearchField;

			//Search By - Account Head Name
			if (searchField.Equals(MicroEnums.SearchAccountHead.Name.ToString()))
			{
				if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
				{
					SearchList = (from AccountHeads in PageVariables.ThisAccountHeadList
								  where AccountHeads.AccountHeadDescription.ToUpper().StartsWith(searchText.ToUpper())
								  select AccountHeads).ToList();
				}

				if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
				{
					SearchList = (from AccountHeads in PageVariables.ThisAccountHeadList
								  where AccountHeads.AccountHeadDescription.ToUpper().Contains(searchText.ToUpper())
								  select AccountHeads).ToList();
				}
			}

			//Search By - Account Head Type
			if (searchField.Equals(MicroEnums.SearchAccountHead.Type.ToString()))
			{
				if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
				{
					SearchList = (from AccountHeads in PageVariables.ThisAccountHeadList
								  where AccountHeads.AccountHeadType.ToUpper().StartsWith(searchText.ToUpper())
								  select AccountHeads).ToList();
				}

				if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
				{
					SearchList = (from AccountHeads in PageVariables.ThisAccountHeadList
								  where AccountHeads.AccountHeadType.ToUpper().Contains(searchText.ToUpper())
								  select AccountHeads).ToList();
				}
			}

			//Search By - Is Primary
			if (searchField.Equals(MicroEnums.SearchAccountHead.IsPrimary.ToString()))
			{
				if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
				{
					SearchList = (from AccountHeads in PageVariables.ThisAccountHeadList
								  where AccountHeads.IsPrimary.Equals(Convert.ToBoolean(searchText))
								  select AccountHeads).ToList();
				}

				if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
				{
					SearchList = (from AccountHeads in PageVariables.ThisAccountHeadList
								  where AccountHeads.IsPrimary.Equals(Convert.ToBoolean(searchText))
								  select AccountHeads).ToList();
				}
			}

			return SearchList;
		}

		private void EnableDisableParentAccountHead(bool enableState = true)
		{
			chk_TreatAsSubHead.Checked = enableState;
			ddl_ParentAccountHeadName.Enabled = enableState;
			requiredFieldValidator_ParentAccountHeadName.Enabled = enableState;

			if (enableState)
				SetDefaultItemText(ddl_ParentAccountHeadName);
		}

		private void PopulateFormFields()
		{
			txt_AccountHeadName.Text = PageVariables.ThisAccountHead.AccountHeadDescription;
			ddl_AccountHeadType.Text = PageVariables.ThisAccountHead.AccountHeadType;
			BindDropdown_AccountHeads(ddl_AccountHeadType.SelectedItem.Text);
            chk_isPrimary.Checked = PageVariables.ThisAccountHead.IsPrimary;

			if (PageVariables.ThisAccountHead.ParentAccountHeadID > 0)
			{
				EnableDisableParentAccountHead();
				ddl_ParentAccountHeadName.SelectedValue = PageVariables.ThisAccountHead.ParentAccountHeadID.ToString();
			}
			else
			{
				EnableDisableParentAccountHead(false);
			}

			ChangeBackColor(view_InputControls);
		}

		private void HideGridViewColumns()
		{
			if (((User)Session["CurrentUser"]).RoleDescription.Equals("User"))
			{
				int[] theArray = { 5, 6 };
				BasePage.HideGridViewColumns(gview_AccountHead, theArray);
			}
			else if (((User)Session["CurrentUser"]).RoleDescription.Equals("Manager"))
			{
				int[] theArray = { 6 };
				BasePage.HideGridViewColumns(gview_AccountHead, theArray);
			}
		}

		public bool ValidateFormFields()
		{
			return true;
		}

		private int InsertRecord()
		{
			int ProcReturnValue = 0;

			AccountHead TheAccountHead = new AccountHead();

			TheAccountHead.AccountHeadDescription = ToProper(txt_AccountHeadName.Text);
			TheAccountHead.AccountHeadType = ddl_AccountHeadType.SelectedItem.Text;
            if (chk_isPrimary.Checked)
                TheAccountHead.IsPrimary = true;
            else
                TheAccountHead.IsPrimary = false;
            //if (chk_TreatAsSubHead.Checked)
            //    TheAccountHead.ParentAccountHeadID = int.Parse(ddl_ParentAccountHeadName.SelectedItem.Value);

			ProcReturnValue = AccountHeadManagement.GetInstance.InsertAccountHead(TheAccountHead);

			return ProcReturnValue;
		}

		private int UpdateRecord()
		{
			PageVariables.ThisAccountHead.AccountHeadDescription = ToProper(txt_AccountHeadName.Text);
			PageVariables.ThisAccountHead.AccountHeadType = ddl_AccountHeadType.SelectedItem.Text;
			if (chk_TreatAsSubHead.Checked)
				PageVariables.ThisAccountHead.ParentAccountHeadID = int.Parse(ddl_ParentAccountHeadName.SelectedItem.Value);
			else
				PageVariables.ThisAccountHead.ParentAccountHeadID = 0;

			int ProcReturnValue = AccountHeadManagement.GetInstance.UpdatetAccountHead(PageVariables.ThisAccountHead);

			return ProcReturnValue;
		}

		private int DeleteRecord()
		{
			int ProcReturnValue = AccountHeadManagement.GetInstance.DeleteAccountHead(PageVariables.ThisAccountHead);

			return ProcReturnValue;
		}

		private static void ResetPageVariables()
		{
			PageVariables.ThisAccountHead = null;
			PageVariables.ThisAccountHeadList = null;
		}

		private void ResetTextBoxes()
		{
			txt_AccountHeadName.Text = string.Empty;
			SetDefaultItemText(ddl_AccountHeadType);
            chk_isPrimary.Checked = false;
			EnableDisableParentAccountHead(false);

			PageVariables.ThisAccountHead = null;

			ResetBackColor(view_InputControls);
			lbl_DataOperationMode.Text = "ADD NEW ACCOUNT HEAD";
			btn_Submit.Text = String.Format(" {0} ", MicroEnums.DataOperation.Save.GetStringValue());
		}
		private void EnableDisableButtons(bool EnableSate = true)
		{
            chk_TreatAsSubHead.Visible = true;
			btn_Submit.Visible = EnableSate;
		}
		#endregion
	}
}