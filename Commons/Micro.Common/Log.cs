using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Micro.Commons
{
	public static class Log
	{
		#region Declaration Constante
		const string NOTICKET = "no ticket";
		const string NA = "---";
		const string SEVERITY_HIGH = "HIGH";
		const string SEVERITY_ERROR = "ERROR";
		const string SEVERITY_WARNING = "WARNING";
		const string SEVERITY_INFO = "INFORMATION";
		#endregion

		#region Declaration Properties & Class
		private class LogError
		{
			public DateTime DateTime;
			public string Ticket = string.Empty;
			public string Environment = string.Empty;
			public string Page = string.Empty;
			public string Message = string.Empty;
			public string InnerMessage = string.Empty;
			public string Stack = string.Empty;
			public string Class = string.Empty;
			public string TargetSite = string.Empty;
			public string UserDomain = string.Empty;
			public string Language = string.Empty;
			public string UserAgent = string.Empty;
			public string TypeLog = string.Empty;
		}

		private static Dictionary<string, InfosLog> LogList
		{
			get
			{
				if (HttpContext.Current.Application["Logger"] == null)
				{
					HttpContext.Current.Application.Add("Logger", new Dictionary<string, InfosLog>());
				}
				return (Dictionary<string, InfosLog>)HttpContext.Current.Application["Logger"];
			}
		}

		private class InfosLog
		{
			public int CounterGroup;
			public int CounterTotalGroup;
			public DateTime LastDateTime;
			public string Severity;
			public bool IsMailSend;
			public bool IsHighLevel;
			public bool IsDisplayPachetInfo;

			public InfosLog(string p_Severity)
			{
				CounterGroup = 1;
				CounterTotalGroup = 1;
				LastDateTime = DateTime.Now;
				IsMailSend = true;
				IsHighLevel = false;
				IsDisplayPachetInfo = false;
				Severity = p_Severity;
			}
		}
		#endregion Declaration Class Log

		#region Error
		public static void Error(Exception exception)
		{
			Log.Logger(exception, false, false, SEVERITY_ERROR);
			//MicroMessages.ShowDataExceptionErrorMessage(exception);
		}

		public static void Error(Exception exception, bool rethrowError)
		{
			Log.Logger(exception, rethrowError, false, SEVERITY_ERROR);
			////MicroMessages.ShowDataExceptionErrorMessage(exception);
			//if (MicroMessages.ErrorMessages == null)
			//{
			//    MicroMessages.ErrorMessages = new StringBuilder();
			//}
			//if (exception.InnerException != null)
			//{
			//    MicroMessages.ErrorMessages.AppendLine(exception.InnerException.Message);
			//}
			//else
			//{
			//    MicroMessages.ErrorMessages.AppendLine(exception.Message);
			//}
			//if (rethrowError)
			//{
			//    MicroMessages.ShowDataExceptionErrorMessage(exception);
			//}
		}

		public static void Error(Exception exception, bool rethrowError, Exception theException)
		{
			//string MsgErr = String.Format("Procedure: {0}\nMessage : {1}", exception.Message, e.Message);
			//MicroMessages.ShowDataExceptionErrorMessage(exception);
			Log.Logger(theException, rethrowError, false, SEVERITY_ERROR);
		}

		public static void Error(Exception exception, bool rethrowError, bool Ticket)
		{
			Log.Logger(exception, rethrowError, Ticket, SEVERITY_ERROR);
			//MicroMessages.ShowDataExceptionErrorMessage(exception);
		}

		public static void Error(string Message)
		{
			Exception exception = new Exception(Message);
			Log.Logger(exception, false, false, SEVERITY_ERROR);
			MicroMessages.ShowDataExceptionErrorMessage(exception);
		}

		public static void Error(string Message, bool rethrowError)
		{
			Exception exception = new Exception(Message);
			Log.Logger(exception, rethrowError, false, SEVERITY_ERROR);
			//MicroMessages.ShowDataExceptionErrorMessage(exception);
		}
		#endregion

		#region Warning
		public static void Warning(string Message)
		{
			//Log.Logger(exception, false, false, SEVERITY_WARNING);
			Exception exception = new Exception(Message);
		}

		public static void Warning(string PrefixMessage, Exception exception)
		{
			//Log.Logger(exception, false, false, SEVERITY_WARNING, PrefixMessage);
			return;
		}

		public static void Warning(Exception exception)
		{
			//Log.Logger(exception, false, false, SEVERITY_WARNING);
			return;
		}
		#endregion

		#region Info
		public static void Info(string Message)
		{
			Exception exception = new Exception(Message);
			//Log.Logger(exception, false, false, SEVERITY_INFO);
		}

		public static void Info(Exception exception)
		{
			//Log.Logger(exception, false, false, SEVERITY_INFO);
			return;
		}
		#endregion

		#region Logger
		private static void Logger(Exception exception, bool rethrowError, bool Ticket, string Severity)
		{
			Log.Logger(exception, rethrowError, Ticket, Severity, string.Empty);
		}

		///// <summary>
		///// Core Logger
		///// </summary>
		//private static void Logger(Exception exception, bool rethrowError, bool Ticket, string p_Severity, string PrefixMessage)
		//{
		//    // Create Number ExceptionID
		//    string ExceptionID = NOTICKET;
		//    if (Ticket == true)
		//    {
		//        #region Create Number Incident
		//        ExceptionID = DateTime.Now.ToString("yyMMddHHmmss") + DateTime.Now.Millisecond;

		//        string key = string.Empty;
		//        const string Dico = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		//        Random randow = new Random();
		//        for (int i = 0; i < 3; i++)
		//        {
		//            int k = randow.Next(1, 26);
		//            key += Dico[k];
		//        }
		//        ExceptionID += key;
		//        #endregion


		//    }

		//    // Format on Module Format Message
		//    string v_Message = Log.FormatMessage(ExceptionID, p_Severity, exception, PrefixMessage);

		//    // Switch for Log on Module Mail
		//    if ((p_Severity != SEVERITY_WARNING) && (p_Severity != SEVERITY_INFO))
		//    {
		//        //Log.LoggerMail(v_Message, exception.Message, p_Severity);
		//    }

		//    // Switch for Log on Module Application Block
		//    // Log.LoggerApplicationBlock(v_Message, exception, rethrowError, p_Severity);
		//}




		#endregion

		/// <summary>
		/// Core Logger
		/// </summary>
		private static void Logger(Exception exception, bool rethrowError, bool Ticket, string p_Severity, string PrefixMessage)
		{
			try
			{
				LogError v_LogError = Log.LoadError(exception, p_Severity, PrefixMessage);

				// Format on Module Format Message
				string v_Message = Log.FormatMessage(v_LogError);

				// Log in DataBase
				Log.StoreLog(v_LogError);

				// Log on Module Mail
				if (p_Severity == SEVERITY_ERROR)
				{
					Log.LoggerMail(v_Message, exception.Message, p_Severity);
				}

				// Throw Error
				if (rethrowError)
				{
					//throw (exception);
				}
			}
			catch
			{
			}
			
		}


		private static LogError LoadError(Exception exception, string p_Severity, string p_PrefixMessage)
		{
			LogError v_LogError = new LogError();

			// Create Number ExceptionID
			string ExceptionID = NOTICKET;
			#region Create Number Incident
			ExceptionID = DateTime.Now.ToString("yyMMddHHmmss") + DateTime.Now.Millisecond.ToString();

			string key = string.Empty;
			string Dico = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Random randow = new Random();
			for (int i = 0; i < 3; i++)
			{
				int k = randow.Next(1, 26);
				key += Dico[k];
			}
			ExceptionID += key;
			#endregion

			HttpContext.Current.Session["ExceptionID"] = ExceptionID;

			#region Get infos
			string PageName = NA;
			string ClassName = NA;
			string Browser = NA;

			if (HttpContext.Current != null)
			{
				if (HttpContext.Current.Request != null)
				{
					Browser = HttpContext.Current.Request.UserAgent;

					try
					{
						// if context lost
						PageName = HttpContext.Current.Request.Url.AbsoluteUri;
					}
					catch
					{
						try
						{
							PageName = HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
						}
						catch
						{
						}
					}
				}
				if (HttpContext.Current.Handler != null)
				{
					ClassName = HttpContext.Current.Handler.ToString();
				}
			}
			#endregion

			if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length > 0)
			{
				v_LogError.Language = HttpContext.Current.Request.UserLanguages[0];
			}
			v_LogError.Environment = ConfigurationManager.AppSettings["WebServerIP"].ToString();
			v_LogError.Ticket = ExceptionID;
			v_LogError.TypeLog = p_Severity;
			v_LogError.DateTime = DateTime.Now;
			v_LogError.Message = exception.Message;
			if (!string.IsNullOrEmpty(p_PrefixMessage))
			{
				v_LogError.Message = p_PrefixMessage + " : " + v_LogError.Message;
			}
			if (exception.InnerException != null)
			{
				v_LogError.InnerMessage = exception.InnerException.Message;
			}
			//v_LogError.TargetSite = exception.TargetSite.Name;
			v_LogError.Stack = exception.StackTrace;
			v_LogError.Page = PageName;
			v_LogError.UserAgent = Browser;
			v_LogError.Class = ClassName;
			v_LogError.UserDomain = HttpContext.Current.User.Identity.Name;

			return (v_LogError);
		}


		#region Module DataBase
		private static void StoreLog(LogError p_LogError)
		{
			try
			{
				if (Connection.ConnectionString != null)
				{
					int theUserId = -1;
					int theOfficeId = -1;
					if (Connection.LoggedOnUser != null)
					{
						theUserId = Connection.LoggedOnUser.UserID;
						theOfficeId = Connection.LoggedOnUser.OfficeID;
					}


					SqlCommand cmdInsertRecord = new SqlCommand();

					//Connection.ConnectionKeyName = ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"].ToString();
					//Connection.ConnectionKeyValue = ConfigurationManager.ConnectionStrings[Connection.ConnectionKeyName].ToString();
					//Connection.ConnectionString = Micro.Commons.MicroSecurity.Decrypt(Connection.ConnectionKeyValue);

					// 
					SqlConnection _SqlConnection = new SqlConnection(Connection.ConnectionString);
					if (_SqlConnection.State == ConnectionState.Closed)
					{
						_SqlConnection.Open();
					}

					cmdInsertRecord.Connection = _SqlConnection;
					cmdInsertRecord.CommandType = CommandType.StoredProcedure;
					cmdInsertRecord.CommandText = "pADM_ErrorLog_Insert";

					cmdInsertRecord.Parameters.Add("@PDATETIME", SqlDbType.DateTime).Value = p_LogError.DateTime;
					cmdInsertRecord.Parameters.Add("@PTICKET", SqlDbType.VarChar, 30).Value = p_LogError.Ticket;
					cmdInsertRecord.Parameters.Add("@PENVIRONMENT", SqlDbType.VarChar, 10).Value = p_LogError.Environment;
					cmdInsertRecord.Parameters.Add("@PPAGE", SqlDbType.VarChar, 1000).Value = p_LogError.Page;
					cmdInsertRecord.Parameters.Add("@PMESSAGE", SqlDbType.VarChar, 2000).Value = p_LogError.Message;
					cmdInsertRecord.Parameters.Add("@PINNERMESSAGE", SqlDbType.VarChar, 3000).Value = p_LogError.InnerMessage;
					cmdInsertRecord.Parameters.Add("@PSTACK", SqlDbType.VarChar, 3000).Value = (p_LogError.Stack==null? "" : p_LogError.Stack);
					cmdInsertRecord.Parameters.Add("@PUSERDOMAIN", SqlDbType.VarChar, 4000).Value = p_LogError.UserDomain;
					cmdInsertRecord.Parameters.Add("@PLANGUAGE", SqlDbType.VarChar, 4000).Value = p_LogError.Language;
					cmdInsertRecord.Parameters.Add("@PTARGETSITE", SqlDbType.VarChar, 4000).Value = p_LogError.TargetSite;
					cmdInsertRecord.Parameters.Add("@PCLASS", SqlDbType.VarChar, 4000).Value = p_LogError.Class;
					cmdInsertRecord.Parameters.Add("@PUSERAGENT", SqlDbType.VarChar, 1000).Value = p_LogError.UserAgent;
					cmdInsertRecord.Parameters.Add("@PTYPELOG", SqlDbType.VarChar, 30).Value = p_LogError.TypeLog;
					cmdInsertRecord.Parameters.Add("@PUSERID", SqlDbType.Int).Value = theUserId;
					cmdInsertRecord.Parameters.Add("@POFFICEID", SqlDbType.Int).Value = theOfficeId;

					cmdInsertRecord.ExecuteNonQuery();

					// 
					if (_SqlConnection.State == ConnectionState.Open)
						_SqlConnection.Close();
				}
			}
			catch (Exception ex)
			{
				
			}
		}
		#endregion


		#region Module Mail
		private static void LoggerMail(string MessageLog, string KeyMessageException, string p_Severity)
		{
			#region Initialization
			DateTime NewDateTimeNow = DateTime.Now;

			// Get Configuration in web.config
			int LapTimeCritical = Convert.ToInt32(ConfigurationManager.AppSettings["Log_LapTimeCritical"]);
			int CriticalQuantityMail = Convert.ToInt32(ConfigurationManager.AppSettings["Log_CriticalQuantityMail"]);
			int QuantityMailInformBeforeCritical = Convert.ToInt32(ConfigurationManager.AppSettings["Log_QuantityMailInformBeforeCritical"]);
			int FrequenceMailToSend = Convert.ToInt32(ConfigurationManager.AppSettings["Log_CriticalFrequenceMail"]);
			#endregion

			#region Purge Logs stock in Application
			ArrayList v_ArrayListCodeDelete = new ArrayList();
			foreach (string CodeLog in Log.LogList.Keys)
			{
				DateTime v_DateTimeLog = Log.LogList[CodeLog].LastDateTime;

				// If date of Log is out of date
				if (new TimeSpan(NewDateTimeNow.Ticks - v_DateTimeLog.Ticks).TotalSeconds > LapTimeCritical)
				{
					// If Log not send by mail (Purge)
					if (Log.LogList[CodeLog].IsMailSend == false)
					{
						string MessagePurge = MessageLog;
						// Send mail
						Log.SendMailLog(MessagePurge, Log.LogList[CodeLog]);
					}

					// Stock Log to delete
					v_ArrayListCodeDelete.Add(CodeLog);
				}
			}
			// Delete all Log out of date
			foreach (string CodeLog in v_ArrayListCodeDelete)
			{
				Log.LogList.Remove(CodeLog);
			}
			#endregion

			#region Log Error / Warning / Infos Mail
			InfosLog CurrentInfoLog;
			// if MessageLog exist in Application Object 'LogList'
			if (Log.LogList.ContainsKey(KeyMessageException))
			{
				CurrentInfoLog = Log.LogList[KeyMessageException];

				// Update CurrentLog
				CurrentInfoLog.CounterTotalGroup += 1;
				DateTime v_LastDateTime = CurrentInfoLog.LastDateTime;

				// if Date Log is NOT out-of-date 
				if (new TimeSpan(NewDateTimeNow.Ticks - v_LastDateTime.Ticks).TotalSeconds < LapTimeCritical)
				{
					// if Quantity Mail send is equal Critical Quantity Mail -> Start High Level
					if ((CurrentInfoLog.CounterTotalGroup > (CriticalQuantityMail - QuantityMailInformBeforeCritical)) && (CurrentInfoLog.CounterTotalGroup <= CriticalQuantityMail))
					{
						CurrentInfoLog.IsHighLevel = true;
					}

					// if Quantity Mail send is higher  to Critical Quantity 
					if (CurrentInfoLog.CounterTotalGroup > CriticalQuantityMail)
					{
						CurrentInfoLog.CounterGroup += 1;
						CurrentInfoLog.IsHighLevel = true;

						// if Frequency Mail is not reached, don't send 
						if (((CurrentInfoLog.CounterTotalGroup - CriticalQuantityMail) % FrequenceMailToSend) != 0)
						{
							CurrentInfoLog.IsMailSend = false;
							CurrentInfoLog.IsDisplayPachetInfo = true;
						}
						else
						{
							CurrentInfoLog.IsMailSend = true;
						}
					}

					CurrentInfoLog.LastDateTime = NewDateTimeNow;
				}
			}
			else // Add new Log
			{
				CurrentInfoLog = new InfosLog(p_Severity);
				Log.LogList.Add(KeyMessageException, CurrentInfoLog);
			}

			if (CurrentInfoLog.IsMailSend == true)
			{
				Log.SendMailLog(MessageLog, CurrentInfoLog);
				// Reinit CounterGroup Log 
				CurrentInfoLog.CounterGroup = 0;
			}
			#endregion
		}

		private static void SendMailLog(string Body, InfosLog p_InfosLog)
		{
			string Subject = string.Empty;
			MailPriority v_MailPriority = MailPriority.Normal;
			switch (p_InfosLog.Severity)
			{
				case SEVERITY_ERROR:
					Subject = "[ERROR]";
					v_MailPriority = MailPriority.Normal;
					break;
				case SEVERITY_WARNING:
					Subject = "[Warning]";
					v_MailPriority = MailPriority.Low;
					break;
				case SEVERITY_INFO:
					Subject = "[Info]";
					v_MailPriority = MailPriority.Low;
					break;
			}

			if (p_InfosLog.IsHighLevel == true)
			{
				v_MailPriority = MailPriority.High;
			}

			string InfosSubject = string.Empty;
			if (HttpContext.Current.Handler != null)
			{
				TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
				InfosSubject = textInfo.ToTitleCase(HttpContext.Current.Handler.ToString().Replace("ASP.", string.Empty).Replace("_aspx", string.Empty).Replace("_", ">"));
			}
			if (p_InfosLog.IsDisplayPachetInfo == true)
			{
				Subject += " [x" + p_InfosLog.CounterGroup + "] (" + p_InfosLog.CounterTotalGroup + ")";
			}
			if (InfosSubject != string.Empty)
			{
				Subject += " Alert in " + InfosSubject;
			}
			else
			{
				Subject += " Alert in Website";
			}

			#region Send Log Mails
			//TODO: KT : Create the items in web config file
			// Get Config Mail
			string MailFrom = (string)ConfigurationManager.AppSettings["Log_MailFrom"];
			string MailFromDisplayName = (string)ConfigurationManager.AppSettings["Log_MailFromDisplayName"];
			string MailTo = (string)ConfigurationManager.AppSettings["Log_MailTo"];
			string MailBc = (string)ConfigurationManager.AppSettings["Log_MailCc"];

			if (!string.IsNullOrEmpty(MailFrom) && !string.IsNullOrEmpty(MailTo))
			{
				// Get Subject & Body
				string MailSubject = Subject;
				string MailBody = Body;

				// Send Mail
				MailMessage MyMessage = new MailMessage();

				MailAddress MyAddressFrom = new MailAddress(MailFrom, MailFromDisplayName);// + " [" + (string)ConfigurationManager.AppSettings["ServerName"] + "]");
				MyMessage.From = MyAddressFrom;

				Regex v_Regex = new Regex("[;]");
				string[] v_TabEmail = v_Regex.Split(MailTo);
				foreach (string v_Email in v_TabEmail)
				{
					MailAddress MyAddressTo = new MailAddress(v_Email);
					MyMessage.To.Add(MyAddressTo);
				}

				if (!string.IsNullOrEmpty(MailBc))
				{
					string[] v_TabEmailBc = v_Regex.Split(MailBc);
					foreach (string v_EmailBc in v_TabEmailBc)
					{
						MailAddress MyAddressCc = new MailAddress(v_EmailBc);
						MyMessage.CC.Add(MyAddressCc);
					}
				}

				MyMessage.Priority = v_MailPriority;

				MyMessage.Subject = MailSubject;
				MyMessage.Body = MailBody;

				SendMail Sender = new SendMail();
				Sender.Send(MyMessage);
			}
			#endregion
		}
		#endregion

		#region Module Format Message
		private static string FormatMessage(string ExceptionID, string Severity, Exception exception, string PrefixMessage)
		{
			string MessageException = PrefixMessage;
			string MessageInnerException = string.Empty;
			string TargetSite = string.Empty;
			string StackTrace = string.Empty;

			if (exception != null)
			{
				if (exception.Message != null)
				{
					MessageException += " " + exception.Message;
				}
				if (exception.InnerException != null)
				{
					MessageInnerException = String.Format("InnerException: {0}{1}-----------------------------------------------------------------{1}", exception.InnerException.Message, Environment.NewLine);
				}
				if (exception.TargetSite != null)
				{
					TargetSite = exception.TargetSite.ToString();
				}
				if (exception.StackTrace != null)
				{
					StackTrace = exception.StackTrace;
				}
			}


			#region Format Message
			string PageName = string.Empty;
			string ClassName = string.Empty;
			string UserID = string.Empty;
			string Message = String.Format("{0}-----------------------------------------------------------------{0}DateTime: {1:dddd dd/MM/yyyy - HH:mm:ss.fff}{0}-----------------------------------------------------------------{0}Number: {2}{0}-----------------------------------------------------------------{0}Severity: {3}{0}-----------------------------------------------------------------{0}Page: {4}{0}-----------------------------------------------------------------{0}Message: {5}{0}-----------------------------------------------------------------{0}{6}Class: {7}{0}-----------------------------------------------------------------{0}TargetSite: {8}{0}-----------------------------------------------------------------{0}Stack: {0}{0}{9}{0}{0}-----------------------------------------------------------------{0}User ID: {10}{0}-----------------------------------------------------------------{0}", Environment.NewLine, DateTime.Now, ExceptionID, Severity, PageName, MessageException, MessageInnerException, ClassName, TargetSite, StackTrace, UserID);
			#endregion

			return (Message);
		}

		private static string FormatMessage(LogError p_LogError)
		{
			string Message = Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"DateTime: " + p_LogError.DateTime.ToString("dddd dd/MM/yyyy - HH:mm:ss.fff") + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"Number: " + p_LogError.Ticket + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"Severity: " + p_LogError.TypeLog + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"Page: " + p_LogError.Page + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"Message: " + p_LogError.Message + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			p_LogError.InnerMessage +
			"Class: " + p_LogError.Class + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"TargetSite: " + p_LogError.TargetSite + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"Stack: " + Environment.NewLine + Environment.NewLine + p_LogError.Stack + Environment.NewLine + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"UserDomain: " + p_LogError.UserDomain + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"Browser: " + p_LogError.UserAgent + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine +
			"Language: " + p_LogError.Language + Environment.NewLine + "-----------------------------------------------------------------" + Environment.NewLine;

			return (Message);
		}
		#endregion
	}
}
