using System;
using Micro.BusinessLayer.Administration;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;
using System.Net.Mail;
using System.Web.UI;
using System.Net;
using System.Configuration;
using Micro.Commons;
using System.Web;

namespace Micro.WebApplication.MicroERP.ADMIN
{
	/// <summary>
	/// Edit ForgotPassword of  user
	/// </summary>
	/// <Author> Kishor Tripathy; Premananda Routray </Author>
	/// <Date> 24-Jul-2012 </Date>

	public partial class ForgotPassword : Page
	{
		#region Declaration
		protected User ThisUser = new User();
		protected string TheUserPassword;
		public static string EmpCodePrefix;
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                //Micro.WebApplication.MicroERP.Login.SetConnection();
                TCon.iCAS.WebApplication.APPS.UserLogin.SetConnection();
                EmpCodePrefix = ConfigurationManager.AppSettings["EmpCodeInitializer"].ToString();
				txt_EmailID.ReadOnly = true;
				Micro.Commons.LocalPath.XMLFiles = Request.MapPath("..");
				SetFormMessages();
			}
		}

		protected void txt_UserID_OnTextChanged(object sender, EventArgs e)
		{
			try
			{
				int TheDigit = int.Parse(txt_UserID.Text.Trim().ToString());
				txt_UserID.Text = string.Format("{0}{1}", EmpCodePrefix, TheDigit.ToString("000000"));
				GetEmailAddress();
			}
			catch
			{
				txt_UserID.Text = txt_UserID.Text.ToUpper();
				GetEmailAddress();
			}
		}

		private void GetEmailAddress()
		{
			lit_Message.Text = string.Empty;
			txt_EmailID.Text = string.Empty;
			User TheUser = UserManagement.GetInstance.GetUserByLoginName(txt_UserID.Text);
			if (TheUser != null)
			{
				if (TheUser.EmailAddress == null)
				{
					lit_Message.Text = ReadXML.GetGeneralMessage("USER_HAS_NO_EMAIL"); // "This user doesnot have a email address. Please contact administrator to reset your password";
				}
				else
				{
					if (TheUser.EmailAddress.Trim().Length > 0)
					{
						txt_EmailID.Text = TheUser.EmailAddress;
					}
					else
					{
						lit_Message.Text = ReadXML.GetGeneralMessage("USER_HAS_NO_EMAIL"); // "This user doesnot have a email address. Please contact administrator to reset your password";
					}
				}
			}
			else
			{
				lit_Message.Text = ReadXML.GetGeneralMessage("NOT_A_VALID_USER"); // "This user doesnot have a email address. Please contact administrator to reset your password";
				txt_EmailID.Text = string.Empty;
			}
		}

		protected void btn_RetrievePassword_Click(object sender, EventArgs e)
		{

			if (!(this.txtimgcode.Text == HttpContext.Current.Session["CaptchaImageText"].ToString()))
			{
				lit_Message.Text = ReadXML.GetGeneralMessage("IMAGE_VERIFY_FAILED", false); 
				return;
			}
			 
			lit_Message.Text = string.Empty;

			User TheUserToValidate = null;
			if (ValidateUser(ref TheUserToValidate))
			{
			    // Get the password of the user
			    TheUserPassword = TheUserToValidate.Password;//ThisUser.Password;
				
			    //Send an email to the user
			    SendEmailMessage(TheUserToValidate);

			    txt_UserID.Text = string.Empty;
			    txt_EmailID.Text = string.Empty;
			}
		}
		#endregion

		#region Methods & Implemenation

		private void SetFormMessages()
		{
			requiredFieldValidator_UserID.ErrorMessage = Helpers.ToCapitalize(ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", false).Replace("field _code", ""));
			requiredFieldValidator_EmailId.ErrorMessage = Helpers.ToCapitalize(ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", false).Replace("field _code", ""));
			regularExpressionValidator_EmailID.ErrorMessage = Helpers.ToCapitalize(ReadXML.GetGeneralMessage("ONLY_EMAIL_FIELD", false).Replace("field_code", ""));
			SetFormMessageCSSClass("ValidateMessage");
		}

		private void SetFormMessageCSSClass(string theClassName)
		{
			requiredFieldValidator_UserID.CssClass = theClassName;
			requiredFieldValidator_EmailId.CssClass = theClassName;
			regularExpressionValidator_EmailID.CssClass = theClassName;
		}

		private bool ValidateUser(ref User theUser)
		{
			bool ReturnValue = true;
			lit_Message.Text = string.Empty;
			theUser = UserManagement.GetInstance.GetUserByLoginName(txt_UserID.Text);

			if (theUser != null)
			{
				if (theUser.UserID <= 0)
				{
					ReturnValue = true;
					txt_EmailID.Text = theUser.EmailAddress.ToString();
				}
			}
			else
			{
				ReturnValue = false;
				lit_Message.Text = lit_Message.Text = string.Format("<font color='#990000'>'{0}' is not a valid user id.</font>", txt_UserID.Text);
			}
			return ReturnValue;
		}

		private void SendEmailMessage(User theUser)
		{
			try
			{

				//string MailTo = txt_EmailID.Text.ToString();
				string AppNamdAndVersion = Micro.WebApplication.App_MasterPages.Micro_Website.GetAppNameWithVersion();
				string MailSubject = ReadXML.GetGeneralMessage("FORGOT_PWD_MAIL_SUBJECT", false).Replace("#APP#", AppNamdAndVersion.ToUpper());
				string ThePwd = Micro.Commons.MicroSecurity.Decrypt(TheUserPassword);
				string MailBody = string.Format("YOUR FULL NAME : {0}<br/> USER NAME : {1} <br/> PASSWORD : <B>{2}</B>", theUser.UserReferenceName, theUser.UserName, ThePwd);

				MailMessage eMail = new MailMessage();

				eMail.To.Add(new MailAddress(theUser.EmailAddress));
				eMail.Subject = MailSubject;
				eMail.Body = MailBody;

				string emailContent = GetHtmlTemplateCode();

				lit_Message.Text = string.Format("<font color='#003500'>{0} to user '{1}' on his/her email address '{2}'</font>",
								Micro.Commons.SendMail.SendEmail(eMail, emailContent),
								theUser.UserName, theUser.EmailAddress);

			}

			catch (Exception ex)
			{
				//string theFailureMessage = string.Concat(ReadXML.GetFailureMessage("PASSWORD_NOT_SEND"), " </br></br> Reason:", ex.Message.ToString());
				 
				lit_Message.Text = string.Format("<font color='#990000'>Failed to send an email to user '{0}' on his/her email address '{1}'.<br/><br/> Reason: '{2}'</font>",
																	theUser.UserName, 
																	theUser.EmailAddress,
																	ex.Message.ToString());
			}
		}
		private void SendEmailMessage()
		{
			try
			{

				string MailTo = txt_EmailID.Text.ToString();
				 string AppNamdAndVersion = App_MasterPages.Micro_Website.GetAppNameWithVersion();
				string MailSubject = ReadXML.GetGeneralMessage("FORGOT_PWD_MAIL_SUBJECT", false).Replace("#APP#", AppNamdAndVersion.ToUpper());
				string MailBody = Micro.Commons.MicroSecurity.Decrypt(TheUserPassword);


				MailMessage eMail = new MailMessage();

				eMail.To.Add(new MailAddress(MailTo));
				eMail.Subject = MailSubject;
				eMail.Body = MailBody;

				string emailContent = GetHtmlTemplateCode();

				lit_Message.Text = string.Format("<font color='#003500'>{0}</font>", Micro.Commons.SendMail.SendEmail(eMail, emailContent));
				
			}

			catch (Exception ex)
			{
				lit_Message.Text = string.Concat(ReadXML.GetFailureMessage("PASSWORD_NOT_SEND"), " </br></br> Reason:", ex.Message.ToString());
				lit_Message.Text = string.Format("<font color='#990000'>{0}</font>", lit_Message.Text);
			}
		}


		private string GetHtmlTemplateCode()
		{
			string htmlCode = string.Empty;
			string sFileName = Server.MapPath(".") + @"\..\..\MailMessage.htm";
			if (System.IO.File.Exists(sFileName))
			{
				WebClient client = new WebClient();
				htmlCode = client.DownloadString(sFileName);
			}
			return htmlCode;
		}
		#endregion

	}
}