using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using AjaxControlToolkit;

namespace Micro.WebApplication.MicroERP.ADMIN
{
	/// <summary>
	/// Add Edit & Delete Common Key like Salutation,Religion etc.
	/// </summary>
	public partial class CommonKeys : BasePage
	{
		#region Decalration
		protected static class PageVariables
		{
			public static List<CommonKey> TheCommonKeyList = null;
			public static List<CommonKey> TheDistinctKeyList = null;
			public static CommonKey thisCommonKey;
			public static int parentGridRowIndex;
		}
		#endregion

		#region Events

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindGridCommonKeys();
				EnableDisableButtons(false);
			}
		}

		protected void btn_AddNew_Clicked(object sender, EventArgs e)
		{
			int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

			if (((Button)sender).Text.Trim().Equals(MicroEnums.DataOperation.Save.GetStringValue()))
			{
				ProcReturnValue = InsertRecord();
				FillGridView(ddl_CommonKeyName.SelectedValue);
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "CommonKeys", MicroEnums.DataOperation.AddNew);
				
			}
			else
			{
				ProcReturnValue = UpdateRecord();
				FillGridView(ddl_CommonKeyName.SelectedValue);
				lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "CommonKeys", MicroEnums.DataOperation.Edit);
			}

			if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
			{
				ResetTextBoxesAndButtons();
			}
			
			dialog_Message.Show();
		}

		protected void ddl_CommonKeyName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddl_CommonKeyName.SelectedIndex > 0)
			{
				FillGridView(ddl_CommonKeyName.SelectedValue);
				EnableDisableButtons();
			}
			else
			{
				ResetTextBoxesAndButtons();
				ClearGridView();
				EnableDisableButtons(false);
			}
		}

		protected void gview_CommonKeys_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				int RowIndex = Convert.ToInt32(e.CommandArgument);
				int RecordID = int.Parse(((Label)gview_CommonKeys.Rows[RowIndex].FindControl("lbl_CommonKeyID")).Text);

				PageVariables.thisCommonKey = CommonKeyManagement.GetInstance.GetCommonKeyByID(RecordID);

				if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
				{
					PopulatePageFields(PageVariables.thisCommonKey);
					btn_AddNew.Text = MicroEnums.DataOperation.Update.GetStringValue();

				}
				else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
				{
					int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

					ProcReturnValue = DeleteRecord();
					lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "CommonKeys", MicroEnums.DataOperation.Delete);

					if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
					{
						FillGridView(ddl_CommonKeyName.SelectedValue);
					}

					dialog_Message.Show();
				}
			}
			catch
			{
			}
		}

		protected void gview_CommonKeys_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			e.Cancel = true;
		}

		protected void gview_CommonKeys_RowEditing(object sender, GridViewEditEventArgs e)
		{
			e.Cancel = true;
		}

		protected void gview_CommonKeys_RowDataBound(object sender, GridViewRowEventArgs e)
		{

		}

		protected void gview_CommonKeys_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gview_CommonKeys.PageIndex = e.NewPageIndex;
			FillGridView(ddl_CommonKeyName.SelectedValue);
		}

		protected void btn_Reset_Click(object sender, EventArgs e)
		{
			BindGridCommonKeys();
			ResetTextBoxesAndButtons();
			ClearGridView();
			EnableDisableButtons(false);
		}

		#endregion

		#region Methods & Implementation
		private void BindGridCommonKeys()
		{
			if (PageVariables.TheCommonKeyList == null)
			{
				PageVariables.TheCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList();
				PageVariables.TheDistinctKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList("#DISTINCT#");
			}

			if (PageVariables.TheDistinctKeyList != null)
			{
				ddl_CommonKeyName.DataSource = PageVariables.TheDistinctKeyList;
				ddl_CommonKeyName.DataTextField = "CommonKeyName";
				ddl_CommonKeyName.DataValueField = "CommonKeyName";
				ddl_CommonKeyName.DataBind();
				ddl_CommonKeyName.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
			}
		}

		public List<CommonKey> GetDistinctCommonKey()
		{
			if (PageVariables.TheCommonKeyList == null)
			{
				PageVariables.TheCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList();
			}
			return (from kkk in PageVariables.TheCommonKeyList
					select kkk).Distinct().ToList();
		}

		private void ResetTextBoxesAndButtons()
		{
			txt_AddNew.Text = string.Empty;
			btn_AddNew.Text = MicroEnums.DataOperation.Save.GetStringValue();
		}

		public int InsertRecord()
		{
			int ProcReturnValue = 0;
			CommonKey theCommonKey = new CommonKey();

			theCommonKey.CommonKeyValue = txt_AddNew.Text;
			theCommonKey.CommonKeyName = ddl_CommonKeyName.SelectedValue;
			ProcReturnValue = CommonKeyManagement.GetInstance.InsertCommonKey(theCommonKey);

			return ProcReturnValue;
		}

		private int UpdateRecord()
		{
			PageVariables.thisCommonKey.CommonKeyName = ddl_CommonKeyName.SelectedValue;
			PageVariables.thisCommonKey.CommonKeyValue = txt_AddNew.Text;

			int ProcReturnValue = CommonKeyManagement.GetInstance.UpdateCommonKey(PageVariables.thisCommonKey);

			return ProcReturnValue;
		}

		public static int DeleteRecord()
		{
			int ProcReturnValue = CommonKeyManagement.GetInstance.DeleteCommonKey(PageVariables.thisCommonKey);

			return ProcReturnValue;
		}

		private void PopulatePageFields(CommonKey theCommonkey)
		{
			ddl_CommonKeyName.Text = theCommonkey.CommonKeyName;
			txt_AddNew.Text = theCommonkey.CommonKeyValue;
		}

		private void PopulatePageFields(int commonKeyID)
		{
			CommonKey theCommonkey = CommonKeyManagement.GetInstance.GetCommonKeyByID(commonKeyID);
			ddl_CommonKeyName.Text = theCommonkey.CommonKeyName;
			txt_AddNew.Text = theCommonkey.CommonKeyValue;
		}

		private void FillGridView(string CommonKeyName)
		{
			List<CommonKey> CommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyByName(CommonKeyName);
			if (CommonKeyList != null)
			{
				gview_CommonKeys.DataSource = CommonKeyList;
				gview_CommonKeys.DataBind();
			}
			else
			{
				gview_CommonKeys.DataSource = string.Empty;
				gview_CommonKeys.DataBind();
			}
		}

		private void ClearGridView()
		{
			gview_CommonKeys.DataSource = null;
			gview_CommonKeys.DataBind();

		}

		private void EnableDisableButtons(bool enablestate = true)
		{
			btn_AddNew.Enabled = enablestate;
		}
		#endregion
	}
}