using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace Micro.Commons
{
    /// <summary>
    /// <p>Class SendMail</p>
    /// </summary>
    /// <summary>
    /// <p>Class SendMail</p>
    /// </summary>
    public class SendMail
    {
        #region Methods and Implementation
        public delegate void SendDelegate(MailMessage eMail);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="strConnection">ConnectionString to use to save the mail in the database</param>
        public SendMail()
        {
        }


        /// <summary>
        /// Send the mail message
        /// </summary>
        /// <param name="eMail">MailMessage to send</param>
        public void SendEmail(MailMessage eMail)
        {
            SmtpClient smtpClient = new SmtpClient();
            string MailServer = ConfigurationManager.AppSettings["MailServerName"] as string;
            smtpClient.Host = MailServer;
            try
            {
                smtpClient.Send(eMail);
            }
            catch
            {

            }
        }

        public static string SendEmail(MailMessage eMail, string emailTemplate = "")
        {
            try
            {
                string MailCompanyPrefix = ConfigurationManager.AppSettings["DefaultCompanyAlias"] as string;
                string MailServerName = ConfigurationManager.AppSettings["MailServerName"] as string;
                string MailSendingFromUser = ConfigurationManager.AppSettings["MailSendingFromUser"] as string;

                //string MailSendingFromPWD = Micro.Commons.MicroSecurity.Decrypt(ConfigurationManager.AppSettings["MailSendingFromPawd"] as string);
				string MailSendingFromPWD = ConfigurationManager.AppSettings["MailSendingFromPassword"] as string; //Micro.Commons.MicroSecuritty.Decrypt(ConfigurationManager.AppSettings["MailSendingFromPawd"] as string);
                string EmailContent;
                if (emailTemplate == "")
                {
                    EmailContent = ReadEmailTemplate();
                }
                else
                {
                    EmailContent = emailTemplate;
                }
                EmailContent = string.Concat("&nbsp;", EmailContent.Replace("SUBJECT", eMail.Subject));
                EmailContent = string.Concat("&nbsp;", EmailContent.Replace("BODY", eMail.Body));

                using (SmtpClient smtpClient = new SmtpClient
                {
                    Host = MailServerName,
                    UseDefaultCredentials = false,
					Port = 587,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential(MailSendingFromUser, MailSendingFromPWD)
                })
                {
                    try
                    {

						
            
                        eMail.From = (new MailAddress(MailSendingFromUser, MailCompanyPrefix));
                        eMail.IsBodyHtml = true;
                        eMail.Body = EmailContent;


						//var client = new SmtpClient("smtp.gmail.com", 587)
						//{
						//	Credentials = new NetworkCredential("myusername@gmail.com", "mypwd"),
						//	EnableSsl = true
						//};
						//client.Send("myusername@gmail.com", "myusername@gmail.com", "test", "testbody");

                        // SEND THE MAIL
                        smtpClient.Send(eMail);

                        return ("Mail Sent Successfully");
                    }
                    catch (Exception ex)
                    {
                        return ("Mail Can't sent because " + ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return ("Mail Can't sent because " + ex.Message.ToString());
            }
        }


        public static string ReadEmailTemplate()
        {

            string htmlCode =
            @"
			<html>
				<head>
					<style type='text/css'>
					.TableMain
					{
						width: 100%;
						border: solid 2px #DCDCDC;
					}
					.RowHeader
					{
						height: 80px;
						width: 100%;
						text-align: center;
					}
					.RowSubject
					{
						border-top: solid 1px #A9A9A9;
						border-bottom: solid 1px #A9A9A9;
						background-color: #F5F5F5;
						padding: 12px;
margin: 2px 0px;
						font-size: small;
						font-weight: bold;
					}
		
		
					.RowBody
					{
margin: 12px 0px;
						background-color: #F5F5F5;
						padding: 10px;
						font-size: small;
					}
					.RowFooter
					{
margin: 12px 0px;
						font-size: smaller;
						text-align: center;
					}
				</style>
			</head>
				<body>
					<table class='TableMain'>
					<tr class='RowHeader'>
						<td>
                            <img alt='TSD College'src='http://www.tsdcollege.in/Themes/Common/Images/TsdcHeader.png' />
						</td>
					</tr>
					
                    <tr >
						<td class='RowBody'>
							<hr />
						</td>
					</tr>
					<tr >
						<td class='RowBody'>
							BODY
						</td>
					</tr>
					 <tr >
						<td class='RowBody'>
							<hr />
						</td>
					</tr>
                    <tr >
						<td class='RowFooter'>
							Copyright @ tsdcollege.in || All Rights Reserved
						</td>
					</tr>
				</table>
				</body>
			</html>

			";
            return htmlCode;
        }

        /// <summary>
        /// Send the MailMessage
        /// </summary>
        /// <param name="eMail">MailMessage to send</param>
        public void Send(MailMessage eMail)
        {
            SendDelegate sd = new SendDelegate(SendEmail);
            AsyncCallback cb = new AsyncCallback(finishSend);
            IAsyncResult ar = sd.BeginInvoke(eMail, cb, sd);
        }

        private void finishSend(IAsyncResult ar) { }
        #endregion Methods and Implementation
    }
}
