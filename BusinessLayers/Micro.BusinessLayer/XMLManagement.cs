using Micro.IntegrationLayer;
using System.Xml;

namespace Micro.BusinessLayer
{
    public partial class XMLManagement
    {
        public enum MicroMessages
        {
            MessageTitle,
            RecordsNotFound,
            RecordsNotSelected,
            InputIsInvalid,
            InputIsBlank,
            RecordsInserted,
            RecordsUpdated,
            RecordsDeleted,
            PromptBeforeDelete,
            PromptBeforeRestore,
            Waiting
        }

        public enum MicroMessagesType
        {
            Error,
            Exception,
            Information,
            PromptYesNo,
            PromptYesNoCancel
        }

        public static string ReadMicroMessages(MicroMessages messageId)
        {
            string MicroMessageText=string.Empty;
            string DocumentURL= XMLIntegration.ReadMicroMessages().BaseURI;

            XmlTextReader DocumentReader = new XmlTextReader(DocumentURL);
            DocumentReader.WhitespaceHandling = WhitespaceHandling.None;

            while(DocumentReader.Read())
            {
                if(string.IsNullOrEmpty(MicroMessageText))
                {
                    if(DocumentReader.NodeType.Equals(XmlNodeType.Element))
                    {
                        while(DocumentReader.MoveToNextAttribute())
                        {
                            if(DocumentReader.Value.Equals(messageId.ToString()))
                            {
                                DocumentReader.MoveToAttribute("Text");
                                MicroMessageText = DocumentReader.Value.ToString();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return MicroMessageText;
        }
    }
}
