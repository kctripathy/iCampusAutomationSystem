using System;
using System.Net.Mail;
using System.Configuration;
using System.Net;

namespace Micro.WebApplication.MicroERP.ADMIN
{
    /// <summary>
    /// Support
    /// </summary>
	public partial class Support : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btn_SendMail_Click(object sender, EventArgs e)
		{
			
			string MailTo = ConfigurationManager.AppSettings["MailAddressesTo"] as string;
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

		}

		private string GetHtmlTemplateCode()
		{
			string htmlCode = string.Empty;
			string sFileName = Server.MapPath("../..") + @"\MailMessage.htm";
			if (System.IO.File.Exists(sFileName))
			{
				WebClient client = new WebClient();
				htmlCode = client.DownloadString(sFileName);
				//htmlCode = htmlCode.Substring(5, htmlCode.Length-1);
			}
			return htmlCode;
		}

	}
}