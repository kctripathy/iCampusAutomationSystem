using System;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;

namespace Micro.WebApplication.MicroERP.ADMIN
{
	/// <summary>
	/// Logged-in user manages his transaction passwords
	/// </summary>
	/// <author>Premananda Routray </author>
	/// <date>28-07-2012</date>
	public partial class TransactionPasswords : BasePage
	{
		#region Declaration
		protected User ThisUser;
		protected TransactionPassword ThisTransactionPassword;
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SetFormMessage();
				LaodMessageBox();
			}
			////((UC_Menu)Master.FindControl("ctrl_Menu")).SetActiveIndex = 3;
		}

		protected void btn_Save_Click(object sender, EventArgs e)
		{
			lbl_MessageTransactionPassword.Text = string.Empty;
			try
			{
				ThisUser = Connection.LoggedOnUser;
				string UserReferenceType = Connection.LoggedOnUser.UserType;
				int UserReferenceID = Connection.LoggedOnUser.UserReferenceID;
				//UserReferenceType.Equals(MicroEnums.UserType.Employee.ToString());
				ThisTransactionPassword = TransactionPasswordManagement.GetInstance.GetTransactionPasswordByEmployeeID(ThisUser.UserReferenceID);

				ThisTransactionPassword.EmployeeID.Equals(UserReferenceID);
				ThisTransactionPassword.TransactionsPassword = MicroSecurity.Encrypt(txt_NewPassword.Text);
				TransactionPassword theTransactionPassword = new TransactionPassword();
				if (Page.IsValid)
				{
					if (ValidateConfirmPassword())
					{
						theTransactionPassword = TransactionPasswordManagement.GetInstance.GetTransactionPasswordByEmployeeID(ThisUser.UserReferenceID);
						if (theTransactionPassword.EmployeeID != ThisUser.UserReferenceID)
							theTransactionPassword.EmployeeID = ThisUser.UserReferenceID;
						theTransactionPassword.TransactionsPassword = ThisTransactionPassword.TransactionsPassword;
						int ProcReturnValue = TransactionPasswordManagement.GetInstance.InsertTransactionPassword(theTransactionPassword);

						if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
						{
                            dialog_Message.Show();
                            lbl_TheMessage.Text = ReadXML.GetSuccessMessage("PASSWORD_SAVED");
						}

						else
						{
							theTransactionPassword.EmployeeID = ThisUser.UserReferenceID;
							theTransactionPassword.TransactionsPassword = ThisTransactionPassword.TransactionsPassword;
							int ProcReturnValue1 = TransactionPasswordManagement.GetInstance.InsertTransactionPassword(theTransactionPassword);
							if (ProcReturnValue1 > (int)MicroEnums.DataOperationResult.Success)
							{
                                dialog_Message.Show();
                                lbl_TheMessage.Text = "Password Reset Successfully";
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
                dialog_Message.Show();
				lbl_TheMessage.Text = ReadXML.GetGeneralMessage("PASSWORD_NOT_SAVE");
			}
		}

		protected void btn_Yes_Click(object sender, EventArgs e)
		{
			panel_Message.Visible = false;
		}

		protected void btn_No_Click(object sender, EventArgs e)
		{
			btn_Save.Enabled = false;
            Response.Redirect("~/MicroERP/Default.aspx");
		}

		protected void btn_Cancel_Click(object sender, EventArgs e)
		{
			ResetTexBoxes();
            Response.Redirect("~/MicroERP/Default.aspx");
		}
		#endregion

		#region Methods & Implemenation
		private void SetFormMessage()
		{
			requiredfieldValidator_NewPassword.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "New Password");
			requiredfieldValidator_ConfirmPassword.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Confirm Message");
			compareValidator_ConfirmPassword.ErrorMessage = ReadXML.GetFailureMessage("PASSWORD_MISMATCH");
		
			SetFormMessageCSSClass("ValidateMessage");

		}
		
		private void SetFormMessageCSSClass(string theClassName)
		{
			requiredfieldValidator_NewPassword.CssClass= theClassName;
			requiredfieldValidator_ConfirmPassword.CssClass= theClassName;
			compareValidator_ConfirmPassword.CssClass = theClassName;
			lbl_MessageTransactionPassword.CssClass = theClassName;

		}

		private bool ValidateConfirmPassword()
		{

			bool ReturnValue = true;

			if (txt_NewPassword.Text.Trim().Length <= 0 || txt_ConfirmPassword.Text.Trim().Length <= 0)
			{
				ReturnValue = false;
				
			}
			if (!txt_NewPassword.Text.Equals(txt_ConfirmPassword.Text))
			{
				ReturnValue = false;
				
			}

			return ReturnValue;
		}

		private void LaodMessageBox()
		{
			ThisUser = Connection.LoggedOnUser;

			ThisTransactionPassword  = TransactionPasswordManagement.GetInstance.GetTransactionPasswordByEmployeeID(ThisUser.UserReferenceID);
			if (ThisTransactionPassword.EmployeeID.Equals(ThisUser.UserReferenceID))
			{
				ajaxModalPopup_Message.Show();
				btn_Save.Text = "Reset";
				btn_Save.Enabled = true;
				txt_NewPassword.Focus();
				lbl_MessageTransactionPassword.Text = string.Empty;
			}

			else
			{
				ajaxModalPopup_Message.Hide();
				panel_Message.Visible = false;
				txt_NewPassword.Focus();
				
			}
			
		}

		private void ResetTexBoxes()
		{
			txt_NewPassword.Text = string.Empty;
			txt_ConfirmPassword.Text = string.Empty;
			lbl_MessageTransactionPassword.Text = string.Empty;
			txt_NewPassword.Focus();
		}
		#endregion
	}
}