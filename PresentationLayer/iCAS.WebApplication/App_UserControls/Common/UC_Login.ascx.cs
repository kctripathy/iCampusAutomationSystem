using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Commons;
using System.Configuration;
using Micro.Objects.Administration;
using System.Text;
using Micro.BusinessLayer.Administration;
using Micro.Framework.ReadXML;
using System.Net.Mail;
using System.Net;
namespace Micro.WebApplication.App_UserControls.Common
{
	public partial class UC_Login : BaseUserControl
	{
		#region Declaration
		public Company TheUserCompany
		{
			get
			{
				string TheCompanyID = radioButtonListCompanies.SelectedValue.ToString();
				//int theCompanyID = int.Parse(TheCompanyID.ToString());
				Company _theCompany = CompanyManagement.GetInstance.GetCompanyByComapnyID(int.Parse(TheCompanyID));
				return _theCompany;
			}
			set
			{
				Company TheCompany = value;
				radioButtonListCompanies.SelectedIndex = BasePage.GetRadioButtonSelectedIndex(radioButtonListCompanies, TheCompany.CompanyID.ToString());
			}
		}
		public static User CurrentUser
		{
			get
			{
				User CurrentUser = HttpContext.Current.Session["CurrentUser"] as User;
				return CurrentUser;
			}
			set
			{
				HttpContext.Current.Session.Add("CurrentUser", value);
			}
		}
		//public static string EmpCodePrefix
		//{
		//    get
		//    {
		//        string TheEmpCodePrefix=string.Empty;
		//        TheEmpCodePrefix = HttpContext.Current.Session["EmpCodePrefix"].ToString();
		//        return TheEmpCodePrefix;

		//    }
		//    set
		//    {
		//        HttpContext.Current.Session.Add("EmpCodePrefix", value);
		//    }
		//}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Session.Remove("EmpCodePrefix");
				BindCompanyList();
			}
		}

		protected void txt_UserName_TextChanged(object sender, EventArgs e)
		{
			lit_Message.Text = string.Empty;
			try
			{
				SetDefaultValues();
				int TheDigit = int.Parse(txt_UserName.Text.Trim().ToString());
				txt_UserName.Text = string.Format("{0}{1}", Session["EmpCodePrefix"], TheDigit.ToString("000000"));
				txt_Password.Focus();
			}
			catch
			{
				txt_UserName.Text = txt_UserName.Text.ToUpper();
			}
		}

		protected void btn_Go_Click(object sender, EventArgs e)
		{
			lit_Message.Text = string.Empty;
			Session.Remove("EmpCodePrefix");
			if (CheckLoginCredentials().Equals(true))
			{
				RedirectLoggedOnUser();
			}

		}

		protected void btn_Link_Click(object sender, EventArgs e)
		{
			Modal_SignUp.Show();
		}

		protected void ButtonOK_Click(object sender, EventArgs e)
		{
			lit_Message.Text = string.Empty;
			try
			{
				int ProcReturnValue = 0;
				ProcReturnValue = InsertLogInGuset();

				if (ProcReturnValue > (0))
				{
					SendEmailMessage(ProcReturnValue);
					lit_Message.Text = ReadXML.GetSuccessMessage("OK_SIGNUPSUCCESS");
				}
				else
				{
					lit_Message.Text = ReadXML.GetFailureMessage("KO_SIGNUPSUCCESS");
				}
				ResettextBox();
			}
			catch
			{

			}
		}

		protected void ButtonCancel_Click(object sender, EventArgs e)
		{

		}
		#endregion

		#region Methods & Implementaion
		public void SetDefaultValues()
		{
			string EmpCodePrefix = string.Empty;
			//EmpCodePrefix = ConfigurationManager.AppSettings["EmpCodeInitializer"].ToString();
			EmpCodePrefix = radioButtonListCompanies.SelectedItem.ToString();
			Session["EmpCodePrefix"] = EmpCodePrefix;

			Micro.Commons.LocalPath.XMLFiles = Request.MapPath(".");
			Micro.Commons.LocalPath.XMLFileChartData = Server.MapPath("~") + ConfigurationManager.AppSettings["XMLFilePath_ChartData"].ToString();
		}

		private bool CheckLoginCredentials()
		{
			bool ReturnValue = false;
			bool LoginSuccess = true;
			User UserInfo = new User();
			StringBuilder FormMessage;

			try
			{

				UserInfo.UserName = txt_UserName.Text;
				UserInfo.Password = txt_Password.Text;
				UserInfo.UserType = ddl_UserTye.SelectedItem.ToString();

				//UserInfo.CompanyID = ctrl_SelectDatabase.SelectedCompanyID;
				UserInfo.CompanyCode = ConfigurationManager.AppSettings["DefaultCompanyCode"].ToString();// "HO0001";

				// Get the record of the user from the database to validate against supplied data
				CurrentUser = UserManagement.GetInstance.GetUserByLoginNameGuset(UserInfo.UserName);
				//ThisUserOfficeTree = OfficeManagement.GetInstance.GetOfficeTreeByUserID(CurrentUser.UserID);

				// Show a message to the user after generating and HTML code in div, ul, li tag
				FormMessage = new StringBuilder("<div id='LoginErrors'><ul class='LoginFormMessage'>");

				// -----------------------------------------------------------------------------------------------
				if (CurrentUser.UserID.Equals(0) || CurrentUser == null)
				//"Login Failed! The user name doesn't exists.";
				{
					Exception exp = Server.GetLastError();

					LoginSuccess = false;
					FormMessage.Append("<li>");
					FormMessage.Append(string.Format(ReadXML.GetFailureMessage("KO_USER_NOT_EXIST"), UserInfo.UserName));
					if (exp != null)
					{
						FormMessage.Append(" or ");
						FormMessage.Append(exp.ToString());
					}
					FormMessage.Append("</li>");
				}
				else if (!CurrentUser.Password.Equals(MicroSecurity.Encrypt(UserInfo.Password)))
				//"Login Failed! Incorrect password.";
				{
					LoginSuccess = false;
					FormMessage.Append("<li>");
					FormMessage.Append(ReadXML.GetFailureMessage("KO_PWD_MISMATCH"));
					FormMessage.Append("</li>");
				}
				else if (!CurrentUser.UserType.Equals(UserInfo.UserType))
				{
					//"Login Failed! UserType MisMatch.";
					LoginSuccess = false;
					FormMessage.Append("<li>");
					FormMessage.Append(string.Format(ReadXML.GetFailureMessage("KO_USER_NOT_EXIST"), UserInfo.UserName));
					FormMessage.Append("</li>");
				}
				else if (string.IsNullOrEmpty(CurrentUser.CompanyID.ToString()))
				//"This user doesn't havae a company code";
				{
					LoginSuccess = false;
					FormMessage.Append("<li>");
					FormMessage.Append(ReadXML.GetFailureMessage("KO_USER_NO_COMP_CODE"));
					FormMessage.Append("</li>");
				}
				else if (CurrentUser.CompanyID.Equals(0))
				//"This user doesn't belongs to any company.";
				{
					LoginSuccess = false;
					FormMessage.Append("<li>");
					FormMessage.Append(ReadXML.GetFailureMessage("KO_USER_NO_COMPANY"));
					FormMessage.Append("</li>");
				}
				// -----------------------------------------------------------------------------------------------
				else
				{
					// A VALID USER : RETURN TRUE FOR SUCCESS
					LoginSuccess = true; ReturnValue = true;

					// MAINTAIN THE USERS INFORMATION 
					SetLoggedOnUserDetails(CurrentUser);

				}
				FormMessage.Append("</ul></div>");

				//Show the reason 
				if (!LoginSuccess)
				{
					lit_Message.Text = FormMessage.ToString();
				}
				return ReturnValue;
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message.ToString());
				lit_Message.Text = ex.Message.ToString();
				throw (new Exception("Login Error" + ex.Message.ToString()));
				return false;
			}
			finally
			{

			}
		}

		private static void SetLoggedOnUserDetails(User currentUser)
		{
			Connection.LoggedOnUser = null;
			Connection.LoggedOnUser = currentUser;

			BasePage.CurrentLoggedOnUser.TheUser = currentUser;
			BasePage.CurrentLoggedOnUser.TheCompany = Micro.BusinessLayer.Administration.CompanyManagement.GetInstance.GetCompanyByComapnyID(currentUser.CompanyID);
			//BasePage.CurrentLoggedOnUser.TheOffice = Micro.BusinessLayer.Administration.OfficeManagement.GetInstance.GetOfficeByID(currentUser.OfficeID);
		}

		private void RedirectLoggedOnUser()
		{
			string RedirectToPageURL;
			var TheDefaultPage = new UserSetting();
			string TheCompanyAliasName = TheUserCompany.CompanyAliasName;
			if (BasePage.CurrentLoggedOnUser.UserSettings != null)
			{
				TheDefaultPage = BasePage.CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.Equals(MicroEnums.UserSettingKey.USER_DEFAULT_PAGE.ToString()));

				if (TheDefaultPage != null)
				{
					if (((UserSetting)TheDefaultPage).UserSettingValue.Trim() != "")
					{
						RedirectToPageURL = string.Concat("/", TheDefaultPage.UserSettingValue);
					}
					else
					{
						RedirectToPageURL = string.Format("MicroGroup/{0}/Index.aspx", TheCompanyAliasName);
					}
				}
				else
				{
					RedirectToPageURL = string.Format("MicroGroup/{0}/Index.aspx", TheCompanyAliasName);
				}
			}
			else
			{
				RedirectToPageURL = string.Format("MicroGroup/{0}/Index.aspx", TheCompanyAliasName);
			}

			string helpersRedirectURL = Helpers.RedirectURL(RedirectToPageURL);

			Server.Transfer(helpersRedirectURL);
		}

		private void BindCompanyList()
		{
			List<Company> ComapyList = CompanyManagement.GetInstance.GetMicroCompanyList();
			radioButtonListCompanies.DataSource = ComapyList;
			radioButtonListCompanies.DataValueField = "CompanyID";
			radioButtonListCompanies.DataTextField = "CompanyAliasName";
			radioButtonListCompanies.DataBind();
			radioButtonListCompanies.SelectedIndex = 0;
		}

		private int InsertLogInGuset()
		{
			int CompanyID = 0;
			int ProcReturnValue = 0;
			Guest TheGuest = new Guest();
			TheGuest.GuestName = txt_signupUserName.Text;
			TheGuest.MobileNumber = txt_signupPhoneNumber.Text;
			TheGuest.PersonalEMailID = txt_signupEmailID.Text;
			CompanyID = int.Parse(radioButtonListCompanies.SelectedValue.ToString());
			ProcReturnValue = GuestManagement.GetInstance.InsertLoginGuest(TheGuest, CompanyID);

			return ProcReturnValue;

		}

		private void ResettextBox()
		{
			txt_signupUserName.Text = string.Empty;
			txt_signupEmailID.Text = string.Empty;
			txt_signupPhoneNumber.Text = string.Empty;
		}

		private void SendEmailMessage(int ReffrenceID)
		{
			try
			{
				User CurrentUser = UserManagement.GetInstance.GetUserByUserReferenceID(ReffrenceID);
				string AppNamdAndVersion = Micro.WebApplication.App_MasterPages.Micro_Website.GetAppNameWithVersion();
				string MailSubject = ReadXML.GetGeneralMessage("OK_SIGNUPSUCCESS", false).Replace("#APP#", AppNamdAndVersion.ToUpper());
				string ThePwd = Micro.Commons.MicroSecurity.Decrypt(CurrentUser.Password);
				string MailBody = string.Format("YOUR FULL NAME : {0}<br/> USER NAME : {1} <br/> PASSWORD : <B>{2}</B>", txt_signupUserName.Text, CurrentUser.UserName, ThePwd);

				MailMessage eMail = new MailMessage();

				eMail.To.Add(new MailAddress(txt_signupEmailID.Text));
				eMail.Subject = MailSubject;
				eMail.Body = MailBody;

				string emailContent = GetHtmlTemplateCode();

				lit_Message.Text = string.Format("<font color='#003500'>{0} to user '{1}' on his/her email address '{2}'</font>",
								Micro.Commons.SendMail.SendEmail(eMail, emailContent),
								txt_signupUserName.Text, txt_signupEmailID.Text);

			}

			catch (Exception ex)
			{
				lit_Message.Text = string.Format("<font color='#990000'>Failed to send an email to user '{0}' on his/her email address '{1}'.<br/><br/> Reason: '{2}'</font>",
																	txt_signupUserName.Text,
																	txt_signupEmailID.Text,
																	ex.Message.ToString());
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