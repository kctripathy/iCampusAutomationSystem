using System.Xml;

namespace Micro.DataAccessLayer
{
    public partial class XMLDataAccess
    {
        public static XmlDocument ReadMicroMessages()
        {
            XmlDocument Document = new XmlDocument();

            // Retrive path of XML document from app.config by name 
            string DocumentPath=System.Configuration.ConfigurationManager.AppSettings["Micro Messages"].ToString();
            
            //Load the XML Document and send it to integration layer
            Document.Load(DocumentPath);

            return Document;
        }
    }
}
