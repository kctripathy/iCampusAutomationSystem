using System;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.Administration;
using System.Web;

namespace Micro.WebApplication.MicroERP.ADMIN
{
	/// <summary>
	/// Edit Password of Logged-in user
	/// </summary>
	/// <Author> Premananda Routray </Author>
	/// <Date> 21-Jul-2012 </Date>

	public partial class ChangePassword : BasePage
	{
		#region Declaration
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SetFormMessages();
			}
			////((UC_Menu)Master.FindControl("ctrl_Menu")).SetActiveIndex = 3;
		}

		protected void btn_ChangePassword_Click(object sender, System.EventArgs e)
		{
			lbl_ErrorMessage.Text = string.Empty;

			if (!(this.txtimgcode.Text == HttpContext.Current.Session["CaptchaImageText"].ToString()))
			{
				lbl_ErrorMessage.Text = ReadXML.GetGeneralMessage("IMAGE_VERIFY_FAILED", false);
				return;
			}


			if (Page.IsValid)
			{
				if (ValidateOldPassword())
				{
					if (ValidateConfirmPassword())
					{
						User ThisUser = Connection.LoggedOnUser;
						ThisUser.Password = MicroSecurity.Encrypt(txt_NewPassword.Text);

						int ProcReturnValue = ChangePasswordManagement.GetInstance.UpdateChangePassword(ThisUser);

						if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
						{
							lbl_ErrorMessage.Text = string.Empty;
							lbl_SuccessMessage.Text = ReadXML.GetSuccessMessage("PASSWORD_CHANGED");
						}
					}

				}
			}
		}

		protected void btn_Cancel_Click(object sender, EventArgs e)
		{
			ResetTextBoxes();
		}
		#endregion

		#region Methods and Implementation
		/// <summary>
		/// This method will populate the user defined messages from an xml file 
		/// It will help to remove hard coding and control over the interactive messages
		/// </summary>
		private void SetFormMessages()
		{
			requiredFieldValidator_OldPassword.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Old Password");
			requiredFieldValidator_NewPassword.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "New Password");
			requiredFieldValidator_ConfirmPassword.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Confirm Password");
			requiredFieldValidatorImageCode.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Image Verification Text");
			compareValidator_ConfirmPassword.ErrorMessage = ReadXML.GetFailureMessage("PASSWORD_MISMATCH");
			SetFormMessageCSSClass("ValidateMessage");
		}

		private void SetFormMessageCSSClass(string theClassName)
		{
			requiredFieldValidator_OldPassword.CssClass = theClassName;
			requiredFieldValidator_NewPassword.CssClass = theClassName;
			requiredFieldValidator_ConfirmPassword.CssClass = theClassName;
			compareValidator_ConfirmPassword.CssClass = theClassName;
			lbl_SuccessMessage.CssClass = theClassName;
			lbl_ErrorMessage.CssClass = theClassName;
		}

		private bool ValidateOldPassword()
		{
			bool ReturnValue = true;

			User ThisUser = Connection.LoggedOnUser;
			string ThisUserPassword = MicroSecurity.Decrypt(ThisUser.Password);

			if (!ThisUserPassword.Equals(txt_OldPassword.Text))
			{
				lbl_ErrorMessage.Text = ReadXML.GetFailureMessage("KO_PWD_MISMATCH");
				txt_OldPassword.Text = string.Empty;
				txt_OldPassword.Focus();
				ReturnValue = false;
			}

			return ReturnValue;
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

		private void ResetTextBoxes()
		{
			txt_OldPassword.Text = string.Empty;
			txt_NewPassword.Text = string.Empty;
			txt_ConfirmPassword.Text = string.Empty;

			lbl_SuccessMessage.Text = string.Empty;
			lbl_ErrorMessage.Text = string.Empty;
		}
		#endregion
	}
}