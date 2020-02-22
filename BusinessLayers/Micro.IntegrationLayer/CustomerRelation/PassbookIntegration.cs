using Micro.Objects.CustomerRelation;
using System.Data;
using Micro.DataAccessLayer.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class PassbookIntegration
	{
        public static Passbook DataRowToObject(DataRow dr)
        {
            Passbook ThePassbook = new Passbook();

            ThePassbook.PassbookID = int.Parse(dr["PassbookID"].ToString());
            ThePassbook.PassbookCode = dr["PassbookCode"].ToString();
			ThePassbook.PassBookType = dr["PassBookType"].ToString();
			ThePassbook.PassbookTypeReferenceID =int.Parse(dr["PassbookTypeReferenceID"].ToString());
			//ThePassbook.PrintPosition = int.Parse(dr["PassbookTypeReferenceID"].ToString());
            //ThePassbook.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
            ThePassbook.CustomerAccountCode = dr["CustomerAccountCode"].ToString();
            ThePassbook.CustomerName = dr["CustomerName"].ToString();
            ThePassbook.PassbookIssueDate = dr["PassbookIssueDate"].ToString();
            ThePassbook.CoverPageState = bool.Parse(dr["CoverPageState"].ToString());
            ThePassbook.FirstPageState = bool.Parse(dr["FirstPageState"].ToString());
            ThePassbook.PrintPosition = int.Parse(dr["PrintPosition"].ToString());

            return ThePassbook;
        }

        public static Passbook GetPassbooksByCustomerAccountID(int CustomerAccountID)
        {
            DataRow PassbookRow = PassbookDataAccess.GetInstance.GetPassbooksByCustomerAccountID(CustomerAccountID);
            Passbook ThePassbook = new Passbook();
            
            if (PassbookRow != null)
            {
                ThePassbook = DataRowToObject(PassbookRow);
            }

            return ThePassbook;
        }

		public static Passbook GetPassbookByTypeReferenceID(string passbookType, int passbookTypeReferenceID)
		{
			DataRow PassbookRow = PassbookDataAccess.GetInstance.GetPassbookByTypeReferenceID(passbookType, passbookTypeReferenceID);
			Passbook ThePassbook = new Passbook();

			if (PassbookRow != null)
			{
				ThePassbook = DataRowToObject(PassbookRow);
			}

			return ThePassbook;
		}
        public static int InsertPassbook(Passbook thePassbook, PassbookPrint thePassbookPrint)
        {
            return PassbookDataAccess.GetInstance.InsertPassbook(thePassbook, thePassbookPrint);
        }
	}
}
