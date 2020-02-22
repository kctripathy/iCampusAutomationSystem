using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.Administration;
using Micro.BusinessLayer.ICAS.FINANCE;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;
using Micro.Objects.ICAS.FINANCE;

namespace LTPL.ICAS.WebApplication.APPS.ICAS.FINANCE
{
	public partial class AccountGroups : BasePage
	{
        #region Declaration
        public AccountGroup ThisAccountGroup;
        public List<AccountGroup> ThisAccountGroupList;
        public MicroEnums.DataOperation DataOperationMode;
        #endregion
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack && !IsCallback)
            {
                EnableDisableUserInputs(false);
                FillPrimaryGroup();
                FillGridView();               
            }
		}
        #region Interface Implementation
        public void FillGridView(string searchText = "")
        {
            ThisAccountGroupList = AccountGroupManagement.GetInstance.GetAccountGroupList();
            grid_AccountsMaster.DataSource = ThisAccountGroupList;
            grid_AccountsMaster.DataBind();
            multiview_AccountsMaster.SetActiveView(view_Grid);
        }
        
        public bool ValidateFormFields()
        {
            //return IsLeftBlank(txt_AccountGroupName, txt_AliasName);
            return true;
        }
        public void FillPrimaryGroup()
        {
            List<AccountGroup> TheAccountGroupList = AccountGroupManagement.GetInstance.GetMasterAccountGroupList();

            if (TheAccountGroupList.Count > 0)

            ddl_ParentAccountGroup.DataSource = TheAccountGroupList;            
            ddl_ParentAccountGroup.DataTextField= AccountGroupManagement.GetInstance.DisplayMember;
            ddl_ParentAccountGroup.DataValueField = AccountGroupManagement.GetInstance.ValueMember;
            ddl_ParentAccountGroup.DataBind();
        }
        public int InsertRecord()
        {
            int ProcReturnValue = 0;
            AccountGroup ThisAccountGroup = new AccountGroup();

            ThisAccountGroup.AccountGroupDescription = txt_AccountGroupName.Text;
            //ThisAccountGroup.AccountGroupAlias = txt_AliasName.Text;
            ThisAccountGroup.AccountGroupParentID = int.Parse(ddl_ParentAccountGroup.SelectedValue);

            ProcReturnValue = AccountGroupManagement.GetInstance.InsertAccountGroup(ThisAccountGroup);
            return ProcReturnValue;
        }
        private void PopulateFormFields(int accountGroupID)
        {
            ThisAccountGroup = AccountGroupManagement.GetInstance.GetAccountGroupByID(accountGroupID);

            if (ThisAccountGroup.IsUserDefined == false)
            {
                lbl_TheMessage.Text = "You Are Unabe To Edit the Data";
                dialog_Message.Show();
                //ShowInfoMessage("You Are Unabe To Edit the Data");
                
            }
            else
            {
                txt_AccountGroupName.Text = ThisAccountGroup.AccountGroupDescription;
                //txt_AliasName.Text = ThisAccountGroup.AccountGroupAlias;
                ddl_ParentAccountGroup.SelectedValue = ThisAccountGroup.AccountGroupID.ToString();
            }
        }

        private void ResetTextBoxes()
        {
            txt_AccountGroupName.Text = string.Empty;            
            ddl_ParentAccountGroup.DataSource = null;
        }
        public int UpdateRecord()
        {
            int ProcReturnValue = 0;

            ThisAccountGroup.AccountGroupDescription = txt_AccountGroupName.Text;
            //ThisAccountGroup.AccountGroupAlias = txt_AliasName.Text;
            ThisAccountGroup.AccountGroupParentID = int.Parse(ddl_ParentAccountGroup.SelectedValue);

            ProcReturnValue = AccountGroupManagement.GetInstance.UpdateAccountGroup(ThisAccountGroup);

            return ProcReturnValue;
        }

        public int DeleteRecord(int AccountGroupID)
        {
            int ProcReturnValue = 0;

            ThisAccountGroup.AccountGroupID = AccountGroupID;

            ProcReturnValue = AccountGroupManagement.GetInstance.DeleteAccountGroup(ThisAccountGroup);

            return ProcReturnValue;
        }
        #endregion

        protected void btn_Submit_Click(object sender, EventArgs e)
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
                            EnableDisableUserInputs(false);
                            ResetTextBoxes();
                            FillGridView();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                
            }            
        }
        private void EnableDisableUserInputs(bool enableState = true)
        {
            lbl_AccountGroup.Enabled = enableState;
            txt_AccountGroupName.Enabled = enableState;
            //lbl_AliasName.Enabled = enableState;
            //txt_AliasName.Enabled = enableState;
            lbl_ParentAccountGroup.Enabled = enableState;
            ddl_ParentAccountGroup.Enabled = enableState;            
            if (enableState == true)
            {
                txt_AccountGroupName.Focus();
            }
        }
        
        protected void btn_View_Click(object sender, EventArgs e)
        {
            FillGridView(string.Empty);
            multiview_AccountsMaster.SetActiveView(view_Grid);
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        protected void btn_AddAccount_Clicked(object sender, EventArgs e)
        {
            multiview_AccountsMaster.SetActiveView(view_InputControls);
            try
            {                
                DataOperationMode = MicroEnums.DataOperation.AddNew;
                EnableDisableUserInputs(true);
                FillPrimaryGroup();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
               
            }
        }
        public static void EnableControls(View theView, bool enableFlag = true)
        {
            Color theSelectModeColor = Color.White;
            Color Fontcolor = Color.Black;
            foreach (Control ctrl in theView.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).BackColor = theSelectModeColor;
                    ((TextBox)ctrl).Enabled = enableFlag;
                    ((TextBox)ctrl).ForeColor = Fontcolor;
                    ((TextBox)ctrl).Style.Add("border", "solid 1px #ccc;");
                }
                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).BackColor = theSelectModeColor;
                    ((DropDownList)ctrl).Enabled = enableFlag;
                    ((DropDownList)ctrl).ForeColor = Fontcolor;
                    ((DropDownList)ctrl).Style.Add("border", "solid 1px #ccc;");
                }
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).BackColor = theSelectModeColor;
                    ((CheckBox)ctrl).Enabled = enableFlag;
                    ((CheckBox)ctrl).ForeColor = Fontcolor;
                }
                if (ctrl is AjaxControlToolkit.CalendarExtender)
                {
                    ((AjaxControlToolkit.CalendarExtender)ctrl).Enabled = enableFlag;
                }
            }
        }
        
        protected void grid_AccountsMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            int RecordID = int.Parse(((Label)grid_AccountsMaster.Rows[RowIndex].FindControl("lbl_AccountGroupID")).Text);
            int RowIndexNo = Convert.ToInt32(e.CommandArgument);
			lbl_DataOperationMode.Text = String.Format("EDIT ACCOUNT HEAD : {0} [{1}]", grid_AccountsMaster.Rows[RowIndexNo].Cells[2].Text.ToUpper(), RecordID);

            //PageVariables.ThisAccountHead = AccountHeadManagement.GetInstance.GetAccountHeadByID(RecordID);

			if (e.CommandArgument.Equals("First"))
			{
				RowIndex = 0;
			}
			else if (e.CommandArgument.Equals("Last"))
			{
				RowIndex = grid_AccountsMaster.PageCount - 1;
			}
			else
			{
				RowIndex = Convert.ToInt32(e.CommandArgument);
			}
			if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
			{
				btn_Submit.Text = String.Format(" {0} ", MicroEnums.DataOperation.Update.GetStringValue());
			    multiview_AccountsMaster.SetActiveView(view_InputControls);
				EnableControls(view_InputControls, true);
				PopulateFormFields(RecordID);
				EnableDisableUserInputs();
                lbl_DataOperationMode.Text = String.Format("EDIT ACCOUNT GROUP : {0} [{1}]", grid_AccountsMaster.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
			}
			else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
			{
				int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                //if (PageVariables.ThisAccountHead.IsPrimary.Equals(false))
                //{
					ProcReturnValue = DeleteRecord(RecordID);
					lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Account Group", MicroEnums.DataOperation.Delete);

					if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
						FillGridView();				
				    else
				    {
					    lbl_TheMessage.Text = GetDataOperationResult(-4, "AccountGroup", MicroEnums.DataOperation.Delete);
				    }
                    //dialog_Message.Show();
			}
			else if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
			{
				lbl_DataOperationMode.Text = String.Format("VIEW ACCOUNT GROUP : {0} [{1}]", grid_AccountsMaster.Rows[RowIndex].Cells[2].Text.ToUpper(), RecordID);
			    multiview_AccountsMaster.SetActiveView(view_InputControls);
				EnableControls(view_InputControls, true);
				PopulateFormFields(RecordID);
				EnableDisableUserInputs();
			}                                             
        }
	}
}