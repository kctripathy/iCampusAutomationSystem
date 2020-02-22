using Micro.Objects.CustomerRelation;
using Micro.IntegrationLayer.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class PassbookPrintManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static PassbookPrintManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static PassbookPrintManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new PassbookPrintManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

        public int InsertPassbookPrint(Passbook thePassbook, PassbookPrint thePassbookPrint)
        {
            return PassbookPrintIntegration.InsertPassbookPrint(thePassbook, thePassbookPrint);
        }
	}
}
