using System;
using Micro.Commons;
using Micro.BusinessLayer.Administration;
//using SmsClient;
namespace Micro.WebApplication.MicroERP.ADMIN
{
	public partial class SendSMS : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnSend_OnClick(object sender, EventArgs e)
		{
			try
			{
				SendTheSMS();
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw (new Exception(ex.Message.ToString()));
			}

		}

		public void SendTheSMS()
		{

			string ToPhoneNumber = txtToPhoneNo.Text;
			string TheBodyMessage = txtSmsBodyText.Text;

			//UriBuilder urlBuilder = new UriBuilder();
			//urlBuilder.Host = "127.0.0.1";
			//urlBuilder.Port = 8800;
			
			//urlBuilder.Query = string.Format("PhoneNumber=%2B" + PhoneNumber + "&Text=" + message);

			//HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(urlBuilder.ToString(), false));
			//HttpWebResponse httpResponse = (HttpWebResponse)(httpReq.GetResponse());

			////string url = "http://www.sendandreceivesms.com/api/";
			////string FromNumber = "9437522845";
			////string ToNumber = txtToPhoneNo.ToString();

			////HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			////request.Method = "POST";
			////string postData = "FromNumber=" + FromNumber;
			////postData += "&";
			////postData += "ToNumber=" + ToNumber;
			////postData += "&";
			////postData += "SMS=" + txtSmsBodyText.Text;

			////byte[] byteArray = Encoding.UTF8.GetBytes(postData);
			////request.ContentType = "application/x-www-form-urlencoded";
			////request.Headers.Add("APIToken", "GET API TOKEN BY REGISTERING");
			////request.ContentLength = byteArray.Length;

			////Stream dataStream = request.GetRequestStream();
			////dataStream.Write(byteArray, 0, byteArray.Length);
			////dataStream.Close();

			////WebResponse response = request.GetResponse();
			////dataStream = response.GetResponseStream();

			////StreamReader reader = new StreamReader(dataStream);
			////string responseFromServer = reader.ReadToEnd();

			////if ((string.IsNullOrEmpty(responseFromServer)))
			////{

			////    lit_Message.Text += "Nothing returned";

			////}
			////else
			////{
			////    lit_Message.Text += responseFromServer;
			////}

			////reader.Close();

			////dataStream.Close();

			////response.Close();

			//////////SendSms sms = new SendSms();
			//////////string status = sms.send("+919437522845", "maa1234", TheBodyMessage, ToPhoneNumber);
			//////////if (status == "1")
			//////////{
			//////////    lit_Message.Text = "Message Send";
			//////////}
			//////////else if (status == "2")
			//////////{
			//////////    lit_Message.Text = "No Internet Connection";
			//////////}
			//////////else
			//////////{
			//////////    lit_Message.Text = "Invalid Login Or No Internet Connection";
			//////////}
		}

        public void SendMicroSMS()
        {

        }

        protected void btnSendSMS_OnClick(object sender, EventArgs e)
        {
            string phoneNo = "9437522845";
            string messgTxt = "Thank you for being a part of MICRO family. Your Policy No. 002613000008 of Mly Rs. 1000.00 for 3Yrs is commenced from Feb 25 2013 12:00AM. BRANCH: KUKADAKHANDI";
            string response = RolesManagement.GetInstance.SendMicroSMS(phoneNo, messgTxt);
        }
	}
}