using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Micro.Commons;

namespace Micro.Framework.ReadXML
{
    public static class ReadXML
    {
        #region Declaration
        public static XElement xmlMessages;
        #endregion

        #region Event
        static ReadXML()
        {
            string PathType = ConfigurationManager.AppSettings[MicroEnums.appSettings.XMLPathType.GetStringValue()];
            string FilePath = ConfigurationManager.AppSettings[MicroEnums.appSettings.XMLFilePath_Message.GetStringValue()];
            string theXMLFileNameAndPath = MicroGlobals.GetFilePath(PathType, FilePath);

            if (System.IO.File.Exists(theXMLFileNameAndPath))
            {
                // Load the messages to an XML element once for re use across application
                xmlMessages = XElement.Load(theXMLFileNameAndPath);
            }
            else
            {
                // File doesn't exists
                throw (new Exception("XML file not found : " + theXMLFileNameAndPath));
            }
        }
        #endregion

        #region Methods & Implementation
        /// <summary>
        /// Please don't use this, instead use 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        [Obsolete]
        public static string GetErrorMessage(string errorCode, MicroEnums.Message messageType)
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
                if (msgText.Attribute("code").Value.Equals(errorCode.ToUpper().Trim()))
                {
                    theMessage = msgText.Attribute("text").Value;
                }
            }
            return Helpers.SplitCamelCase(theMessage);
        }

        public static string GetFailureMessage(string messageCode)
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
                    theMessage = Helpers.SplitCamelCase(msgText.Attribute("text").Value);
                }
            }

			// Replace the new line character with html code
			if (theMessage.Length > 0)
			{
				theMessage = theMessage.Replace("\\n", "<br />");
				theMessage = theMessage.Replace("#B #", "<b>");
				theMessage = theMessage.Replace("#B#", "<b>");
				theMessage = theMessage.Replace("#/B#", "</b>");
			}
            theMessage = string.Format("<div class='FailureDialogBox'>&nbsp;{0}</div>", theMessage);
            return theMessage;
        }

        public static string GetSuccessMessage(string messageCode)
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
			if (theMessage.Length > 0)
			{
				theMessage = theMessage.Replace("\n", "<br />");
			}

			// Replace the new line character with html code
			if (theMessage.Length > 0)
			{
				theMessage = theMessage.Replace("\\n", "<br />");
				theMessage = theMessage.Replace("#B #", "<b>");
				theMessage = theMessage.Replace("#B#", "<b>");
				theMessage = theMessage.Replace("#/B#", "</b>");
			}
			theMessage = string.Format("<div class='SuccessDialogBox'>&nbsp;{0}</div>", theMessage);
             
			return theMessage;
        }

        public static string GetToolTipMessage(string messageCode)
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

        public static string GetOtherMessage(string messageCode)
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

			if (theMessage.Length > 0)
			{
				theMessage = "<span class='OtherMessageDialogBox' />" + theMessage;
				theMessage = theMessage.Replace("\n", "<br />");
				theMessage = theMessage.Replace("#B #", "<b>");
				theMessage = theMessage.Replace("#/B#", "</b>");

			}
            return theMessage;
        }

		public static string GetGeneralMessage(string messageCode, bool useDivTag = true)
		{
			string theMessage = string.Empty;
			IEnumerable<XElement> elementMessage =
								from ee in
									xmlMessages.Elements("GeneralMessage")
								select ee;

			int iCounter = 0;
			foreach (var msgText in elementMessage)
			{
				iCounter++;
				if (msgText.Attribute("code").Value.Equals(messageCode.ToUpper().Trim()))
				{
					theMessage = Helpers.SplitCamelCase(msgText.Attribute("text").Value);
				}
			}

			// Replace the new line character with html code
			if (theMessage.Length > 0)
			{
				theMessage = theMessage.Replace("\\n", "<br />");
				theMessage = theMessage.Replace("#B #", "<b>");
				theMessage = theMessage.Replace("#B#", "<b>");
				theMessage = theMessage.Replace("#/B#", "</b>");
			}
			if (useDivTag)
				theMessage = string.Format("<div class='GeneralDialogBox'>&nbsp;{0}</div>", theMessage);
			 

			return theMessage;
		}
        public static string GetGeneralMessage(string messageCode)
        {
            string theMessage = string.Empty;
            IEnumerable<XElement> elementMessage =
                                from ee in
                                    xmlMessages.Elements("GeneralMessage")
                                select ee;

            int iCounter = 0;
            foreach (var msgText in elementMessage)
            {
                iCounter++;
                if (msgText.Attribute("code").Value.Equals(messageCode.ToUpper().Trim()))
                {
                    theMessage = Helpers.SplitCamelCase(msgText.Attribute("text").Value);
                }
            }

			// Replace the new line character with html code
			if (theMessage.Length > 0)
			{
				theMessage = theMessage.Replace("\\n", "<br />");
				theMessage = theMessage.Replace("#B #", "<b>");
				theMessage = theMessage.Replace("#B#", "<b>");
				theMessage = theMessage.Replace("#/B#", "</b>");
			}
			theMessage = string.Format("<div class='GeneralDialogBox'>&nbsp;{0}</div>", theMessage);
             
            return theMessage;
        }

        public static string GetGeneralMessage(string messageCode, string fieldName)
        {
            string theMessage = string.Empty;
            IEnumerable<XElement> elementMessage =
                                from ee in
                                    xmlMessages.Elements("GeneralMessage")
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

            theMessage= Helpers.SplitCamelCase(theMessage.Replace("field_code", fieldName));

			// Replace the new line character with html code
			if (theMessage.Length > 0)
			{
				theMessage = theMessage.Replace("\\n", "<br />");
				theMessage = theMessage.Replace("#B #", "<b>");
				theMessage = theMessage.Replace("#B#", "<b>");
				theMessage = theMessage.Replace("#/B#", "</b>");
			}
			theMessage = string.Format("<div class='GeneralDialogBox'> {0}</div>", theMessage);
			
			return theMessage;
        }
        #endregion
    }
}
