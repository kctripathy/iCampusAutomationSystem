using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class PassbookManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static PassbookManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static PassbookManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new PassbookManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

        public Passbook GetPassbooksByCustomerAccountID(int CustomerAccountID)
        {
            return PassbookIntegration.GetPassbooksByCustomerAccountID(CustomerAccountID);
        }

		public Passbook GetPassbookByTypeReferenceID(string passbookType, int passbookTypeReferenceID)
		{
			return PassbookIntegration.GetPassbookByTypeReferenceID(passbookType, passbookTypeReferenceID);
		}
        public int InsertPassbook(Passbook thePassbook, PassbookPrint thePassbookPrint)
        {
            return PassbookIntegration.InsertPassbook(thePassbook, thePassbookPrint);
        }
	}
}
