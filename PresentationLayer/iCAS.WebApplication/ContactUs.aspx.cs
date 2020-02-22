using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace LTPL.ICAS.WebApplication
{
	public partial class ContactUs : System.Web.UI.Page
	{

		#region "Events"
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (!(Micro.Commons.Connection.LoggedOnUser == null))
				{
					txt_Name.Text = Micro.Commons.Connection.LoggedOnUser.UserReferenceName;
					txt_Email.Text = Micro.Commons.Connection.LoggedOnUser.EmailAddress;
				}

			}
		}

		protected void btn_SendMail_Click(object sender, EventArgs e)
		{


			
			string MailTo = GetToEmailAddress();
			string MailCC = ConfigurationManager.AppSettings["MailAddressesCC"] as string;
			string MailBCC = ConfigurationManager.AppSettings["MailAddressBCC"] as string;

			string MailSubjectPrefix = ConfigurationManager.AppSettings["MailSubjectPrefix"] as string;
			string MailSubject = string.Format("<<{0}>> {1}", MailSubjectPrefix, txt_Subject.Text);
			string MailBody = txt_SupportBody.Text;


			MailMessage eMail = new MailMessage();

			eMail.To.Add(new MailAddress(MailTo));
			eMail.CC.Add(MailCC);
			eMail.Subject = MailSubject;
			eMail.Body = MailBody;

			string emailContent = GetHtmlTemplateCode();
			// SEND THE MAIL
			lit_Message.Text = Micro.Commons.SendMail.SendEmail(eMail, emailContent);
            lbl_TheMessage.Text = lit_Message.Text;
            dialog_Message.Show();
		}


		protected void ddl_SupportType_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
#endregion

		#region Methods

		private string GetToEmailAddress()
		{
			string ContactKey =  ddl_ContactReason.SelectedItem.Value.ToString();
			return ConfigurationManager.AppSettings[ContactKey] as string;
		}
		
		private string GetHtmlTemplateCode()
		{
			string htmlCode = string.Empty;
			string sFileName = Server.MapPath(".") + @"\MailMessage.htm";
			if (System.IO.File.Exists(sFileName))
			{
				WebClient client = new WebClient();
				htmlCode = client.DownloadString(sFileName);
				//htmlCode = htmlCode.Substring(5, htmlCode.Length-1);
			}
			return htmlCode;
		}

		#endregion

	}
}