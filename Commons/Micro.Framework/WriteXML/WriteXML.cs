using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Micro.Commons;
using System.Xml.Linq;

namespace Micro.Framework.WriteXML
{
	public class WriteXML
	{
		public static readonly string XMLFilePath_Message;
		public static XElement xmlMessages;
		static WriteXML()
		{
			string theXMLfilePath = ConfigurationManager.AppSettings["XMLFilePath_Message"].ToString();
			if (System.IO.File.Exists(theXMLfilePath))
			{
				XMLFilePath_Message = theXMLfilePath;
				xmlMessages = XElement.Load(XMLFilePath_Message);
			}
			else
			{
				XMLFilePath_Message = "Not found";
			}
		}

		public static string WriteErrorMessage(string errorCode, MicroEnums.Message messageType)
		{
			string theMessage = string.Empty;
			string theMessageType = string.Empty;
			if (messageType.Equals(MicroEnums.Message.Success))
			{
				theMessageType = "SuccessMessage";
			}
			else if (messageType.Equals(MicroEnums.Message.Failure))
			{
				theMessageType = "FailureMessage";
			}
			if (messageType.Equals(MicroEnums.Message.Other))
			{
				theMessageType = "OtherMessage";
			}

			IEnumerable<XElement> elementMessage =
										from ee in xmlMessages.Elements(theMessageType)
										select ee;

			int iCounter = 0;
			foreach (var msgText in elementMessage)
			{
				iCounter++;
				if (msgText.Attribute("code").Value.Equals(errorCode.ToString().ToUpper().Trim()))
				{
					theMessage = msgText.Attribute("text").Value;
				}
			}
			return theMessage;
		}

		public static string WriteFailureMessage(string messageCode)
		{
			string theMessage = string.Empty;
			IEnumerable<XElement> elementMessage =
								from ee in
									xmlMessages.Elements("FailureMessage")
								select ee;

			int iCounter = 0;
			foreach (var msgText in elementMessage)
			{
				iCounter++;
				if (msgText.Attribute("code").Value.Equals(messageCode.ToUpper().Trim()))
				{
					theMessage = msgText.Attribute("text").Value;
				}
			}
			return theMessage;
		}

		public static string WriteSuccessMessage(string messageCode)
		{
			string theMessage = string.Empty;
			IEnumerable<XElement> elementMessage =
								from ee in
									xmlMessages.Elements("SuccessMessage")
								select ee;

			int iCounter = 0;
			foreach (var msgText in elementMessage)
			{
				iCounter++;
				if (msgText.Attribute("code").Value.Equals(messageCode.ToUpper().Trim()))
				{
					theMessage = msgText.Attribute("text").Value;
				}
			}
			return theMessage;
		}

		public static string WriteToolTipMessage(string messageCode)
		{
			string theMessage = string.Empty;
			IEnumerable<XElement> elementMessage =
								from ee in
									xmlMessages.Elements("ToolTipMessage")
								select ee;

			int iCounter = 0;
			foreach (var msgText in elementMessage)
			{
				iCounter++;
				if (msgText.Attribute("code").Value.Equals(messageCode.ToUpper().Trim()))
				{
					theMessage = msgText.Attribute("text").Value;
				}
			}
			return theMessage;
		}

		public static string WriteOtherMessage(string messageCode)
		{
			string theMessage = string.Empty;
			IEnumerable<XElement> elementMessage =
								from ee in
									xmlMessages.Elements("OtherMessage")
								select ee;

			int iCounter = 0;
			foreach (var msgText in elementMessage)
			{
				iCounter++;
				if (msgText.Attribute("code").Value.Equals(messageCode.ToUpper().Trim()))
				{
					theMessage = msgText.Attribute("text").Value;
				}
			}
			return theMessage;
		}
	}
}
