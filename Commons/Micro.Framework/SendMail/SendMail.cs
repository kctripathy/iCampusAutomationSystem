using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Micro.Framework
{
    /// <summary>
    /// <p>Class SendMail</p>
    /// </summary>
    public class SendMail
    {
        #region Methods and Implementation
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="strConnection">ConnectionString to use to save the mail in the database</param>
        public SendMail()
        {
        }

        public delegate void SendDelegate(MailMessage eMail);

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

        /// <summary>
        /// Send the mail message
        /// </summary>
        /// <param name="eMail">MailMessage to send</param>
        public static void SendEmail(MailMessage eMail)
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

        private void finishSend(IAsyncResult ar) { }
        #endregion Methods and Implementation
    }
}
