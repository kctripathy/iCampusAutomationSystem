using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace Micro.ErrorLogger
{
	public static class UserPageVisits
	{
		private static StreamWriter sw = null;
		/// <summary>
		/// Setting LogFile path. If the logfile path is null then it will update error info into LogFile.txt under
		/// application directory.
		/// </summary>
		public static string LogFilePath
		{
			//set
			//{
			//    strLogFilePath = value;
			//}
			get
			{
				try
				{
					return ConfigurationManager.AppSettings["ErrorLogFileName"].ToString();
				}
				catch
				{
					return "ErrorLog.txt";
				}
			}
		}

		public static void Record(string thePageUrl)
		{
			string strException = string.Empty;
			try
			{

				sw = new StreamWriter(@"D:\Log.txt", true);
				//sw.WriteLine("Source		: " + objException.Source.ToString().Trim());
				//sw.WriteLine("Method		: " + objException.TargetSite.Name.ToString());
				//sw.WriteLine("Date		: " + DateTime.Now.ToLongTimeString());
				//sw.WriteLine("Time		: " + DateTime.Now.ToShortDateString());
				//sw.WriteLine("Computer	: " + Dns.GetHostName().ToString());
				//sw.WriteLine("Error		: " + objException.Message.ToString().Trim());
				//sw.WriteLine("Stack Trace	: " + objException.StackTrace.ToString().Trim());
				sw.WriteLine(thePageUrl);
				sw.Flush();
				sw.Close();
			}
			catch (Exception)
			{
				
			}
		}
	}
}
