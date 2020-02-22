using System;
using Micro.Commons;
using System.Net;
using System.Net.Mail;
using Micro.Framework.ReadXML;


namespace Micro.WebApplication.MicroERP.ADMIN
{
	/// <summary>
	/// Edit ContactUS
	/// </summary>
	/// <Author> Premananda Routray </Author>
	/// <Date> 29-Jul-2012 </Date>
	public partial class ContactUs : BasePage
		
	{
		#region Declaration

		//SmtpClient smtpClient = new SmtpClient();
		#endregion

		#region Events

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SetFormMessage();
			}
		}

		protected void btn_Submit_Click(object sender, EventArgs e)
		{

			SendEmailMessage();
		
		}

		#endregion
		
		#region Methods
		private void SendEmailMessage()
		{
			
			try
			{
			    MailMessage mail = new MailMessage();
			    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");//define smpt client server
			    mail.From = new MailAddress("routray.ayushman@gmail.com");//From Address
			    mail.To.Add("routray.ayushman@gmail.com");//to_address
			    if (mail.To.Count > 0)
			        mail.Subject =  txt_Subject.Text;//subject here
			    mail.Body ="Name:"+txt_Name.Text +","+"Address:"+txt_Address.Text+","+"Phone:"+txt_Phone.Text+","+"Email:"+" "+txt_FromEmail.Text+","+"Body:" + txt_MessageBody.Text;//write your message to be send.

				//Attachment attachment;
				//attachment = new Attachment(file_Upload.FileName);//your attachment filename with path
				//mail.Attachments.Add(attachment);

			    SmtpServer.Port = 587;//define port number of smtpserver
			    SmtpServer.Credentials = new NetworkCredential("routray.ayushman@gmail.com", "jisu@3078");//(username,password) of From Email Account
			    SmtpServer.EnableSsl = true;

			    SmtpServer.Send(mail);
			    lbl_Message.Text = ReadXML.GetSuccessMessage("EMAIL_SEND");
			}

			catch (Exception ex)
			{
			    lbl_Message.Text = ReadXML.GetFailureMessage("EMAIL_SEND_FAIL");
			}
		}

		
		private void SetFormMessage()
		{
			requiredFieldValidator_Name.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY","Name");
			requiredFieldValidator_Email.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY","Email id");
			regularExpressionValidator_Email.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_EMAIL_FIELD");
			regulalExpressionVlidator_Phone.ErrorMessage = ReadXML.GetGeneralMessage("ONLY_NUMBER_FIELD");
			lbl_MicroAddress.Text = ReadXML.GetOtherMessage("MICRO_ADDRESS");
			lbl_MicroEmailAddress.Text = ReadXML.GetOtherMessage("MICRO_EMAIL_ADDRESS");
			lbl_PhoneDetils.Text = ReadXML.GetOtherMessage("MICRO_PHONE");

			SetFormMessageCSSClass("ValidateMessage");
		}

		private void SetFormMessageCSSClass(string theClassName)
		{
			requiredFieldValidator_Name.CssClass = theClassName;
			requiredFieldValidator_Email.CssClass = theClassName;
			regularExpressionValidator_Email.CssClass = theClassName;
			regulalExpressionVlidator_Phone.CssClass = theClassName;
			lbl_Message.CssClass = theClassName;
		}

		#endregion

		
    }
}