using Micro.Objects.CustomerRelation;
using Micro.DataAccessLayer.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class PassbookPrintIntegration
	{
        public static int InsertPassbookPrint(Passbook thePassbook, PassbookPrint thePassbookPrint)
        {
            return PassbookPrintDataAccess.GetInstance.InsertPassbookPrint(thePassbook, thePassbookPrint);
        }
	}
}
