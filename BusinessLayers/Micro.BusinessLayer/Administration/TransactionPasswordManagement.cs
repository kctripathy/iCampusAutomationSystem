using Micro.IntegrationLayer.Administration;
using Micro.Objects.Administration;

namespace Micro.BusinessLayer.Administration
{
	public partial class TransactionPasswordManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static TransactionPasswordManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static TransactionPasswordManagement GetInstance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new TransactionPasswordManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion.

		#region Methods & Implementation
		public TransactionPassword GetTransactionPasswordByEmployeeID(int EmployeeID)
		{
			return TransactionPasswordIntegration.GetTransactionPasswordByEmployeeID(EmployeeID);
		}

		public int InsertTransactionPassword(TransactionPassword theTransactionPassword)
		{
			return TransactionPasswordIntegration.InsertTransactionPassword(theTransactionPassword);
		}
		#endregion
	}
}
