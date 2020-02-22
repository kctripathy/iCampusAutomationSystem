using System;
using System.Xml;
using Micro.DataAccessLayer;

namespace Micro.IntegrationLayer
{
    public partial class XMLIntegration
    {
        public static XmlDocument ReadMicroMessages()
        {
            string Context = "Micro.IntegrationLayer.HumanResource.XMLIntegration.ReadMicroMessages";
            try
            {
                return (XMLDataAccess.ReadMicroMessages());
            }
            catch (Exception ex)
            {
                throw (new Exception(Context, ex));
            }
        }
    }
}
