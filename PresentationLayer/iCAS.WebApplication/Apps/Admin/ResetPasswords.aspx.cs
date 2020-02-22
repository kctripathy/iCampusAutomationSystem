using System;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using System.Configuration;
using System.Web;

namespace Micro.WebApplication.MicroERP.ADMIN
{
	/// <summary>
	/// Reset Login Password
	/// </summary>
	/// <author> Premananda Routray </author>
	/// <date> 24-Jul-2012 </date>
	public partial class ResetPasswords : BasePage
	{
		#region Declaration
		private User ThisUser = new User();
		public static string EmpCodePrefix;
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				EmpCodePrefix = ConfigurationManager.AppSettings["EmpCodeInitializer"].ToString();
				
				SetFormMessage();

			}
		}

		protected void txt_UserName_Leave(object sender, EventArgs e)
		{
			try
			{
				int TheDigit = int.Parse(txt_UserID.Text.Trim().ToString());
				lbl_DisplayUserName.Text = string.Format("{0}{1}", EmpCodePrefix, TheDigit.ToString("000000"));
				 
			}
			catch
			{
				lbl_DisplayUserName.Text = txt_UserID.Text.ToUpper();
			}

			txt_UserID.Text = lbl_DisplayUserName.Text;

			try
			{
				User ThisUser = UserManagement.GetInstance.GetUserByLoginName(txt_UserID.Text);
				if (ValidateUser())
				{
					lbl_DisplayUserName.Text = ThisUser.UserName;
					if (ThisUser.UserType != "")
					{
						lbl_DisplayUserType.Text = ThisUser.UserType;
					}
					else
					{
						lbl_DisplayUserType.Text = "N/A";
					}

					lbl_EmployeeName.Text = string.Format("{0} Name :", ThisUser.UserType);
					if (ThisUser.UserReferenceName != "")
					{
						lbl_DisplayEmployeeName.Text = ThisUser.UserReferenceName;
					}
					else
					{
						lbl_DisplayEmployeeName.Text = "N/A";
					}

				}
			}
			catch
			{
			}
		}

		protected void btn_GeneratePassword_Click(object sender, EventArgs e)
		{
			if (!(this.txtimgcode.Text == HttpContext.Current.Session["CaptchaImageText"].ToString()))
			{
				lit_ErrorMessage.Text = ReadXML.GetGeneralMessage("IMAGE_VERIFY_FAILED", false);
				return;
			}

			User objUser = UserManagement.GetInstance.GetUserByLoginName(txt_UserID.Text);
			lbl_UserMessage.Text = string.Empty;
			lit_ErrorMessage.Text = string.Empty;
			try
			{

				if (ValidateUser())
				{
					objUser.Password = ResetPasswordManagement.GetInstance.GeneratePassword();
					lbl_DisplayNewPassword.Text = objUser.Password;

					int ProcReturnValue = ResetPasswordManagement.GetInstance.ChangePassword(objUser);

					if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
					{
					}
					else
						lit_ErrorMessage.Text = ReadXML.GetFailureMessage("PASSWORD_NOT_RESET");

					objUser.Password = MicroSecurity.Encrypt(lbl_DisplayNewPassword.Text);

					int ProcReturnValueUpdate = ChangePasswordManagement.GetInstance.UpdateChangePassword(objUser);

					if (ProcReturnValueUpdate > (int)MicroEnums.DataOperationResult.Success)
					{

						lit_ErrorMessage.Text = ReadXML.GetSuccessMessage("PASSWORD_RESET");
					}
				}
			}
			catch
			{

			}

		}

		protected void btn_Cancel_Click(object sender, EventArgs e)
		{
			RestTextBoxesLabels();
			//Server.Transfer("~/Default.aspx");
		}

		//protected void btn_Yes_Click(object sender, EventArgs e)
		//{
		//    //panel_Message.Visible = false;
		//    txt_UserID.Focus();
		//}

		//protected void btn_No_Click(object sender, EventArgs e)
		//{
		//    btn_GeneratePassword.Enabled = false;
		//    txt_UserID.ReadOnly = true;
		//    Server.Transfer("~/Default.aspx");
		//}

		#endregion

		#region Methods & Implemenation

		private void SetFormMessage()
		{
			requiredFieldValidator_UserID.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "User ID");
			SetFormMessageCSSClass("ValidateMessage");
		}

		private void SetFormMessageCSSClass(string theClassName)
		{
			requiredFieldValidator_UserID.CssClass = theClassName;
			lbl_UserMessage.CssClass = theClassName;
			
		}

		private bool ValidateUser()
		{
			bool ReturnValue = true;

			User ThisUser = new User();
			ThisUser = UserManagement.GetInstance.GetUserByLoginName(txt_UserID.Text);
			if (ThisUser != null)
				if (ThisUser.UserID <= 0)
				{
					lbl_UserMessage.Text = ReadXML.GetFailureMessage("FORGOT_USERID");
					ReturnValue = false;
				}

			return ReturnValue;
		}

		private void RestTextBoxesLabels()
		{
			txt_UserID.Text = string.Empty;
			lit_ErrorMessage.Text = string.Empty;
			lbl_UserMessage.Text = string.Empty;
			lbl_DisplayUserName.Text = "N/A";
			lbl_DisplayUserType.Text = "N/A";
			lbl_DisplayEmployeeName.Text = "N/A";
			lbl_DisplayNewPassword.Text = "N/A";
		}

		#endregion
	}
}