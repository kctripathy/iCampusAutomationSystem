using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
	public partial class CustomerAccountReceiptManagement
	{
		#region Code to make this as Singleton Class
		/// <summary>
		/// Declare a private static variable
		/// </summary>
		private static CustomerAccountReceiptManagement _Instance;

		/// <summary>
		/// Return the instance of the application by initialising once only.
		/// </summary>
		public static CustomerAccountReceiptManagement GetInstance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new CustomerAccountReceiptManagement();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
		}
		#endregion

		#region Declaration
		public string DefaultColumn = "CustomerName, CustomerAccountCode, ReceiptDate, InstallmentNumberFrom, InstallmentNumberTo, AdmissionOrFineAmount, InstallmentAmountPaid";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "ReceiptID";
		#endregion

		#region Methods & Implementation
		public List<CustomerAccountReceipt> GetCustomerAccountReceiptsByScrollID(int scrollID)
		{
			return CustomerAccountReceiptIntegration.GetCustomerAccountReceiptsByScrollID(scrollID);
		}

		public List<CustomerAccountReceipt> GetCustomerAccountReceiptsByCustomerAccountID(int customerAccountID)
		{
			return CustomerAccountReceiptIntegration.GetCustomerAccountReceiptsByCustomerAccountID(customerAccountID);
		}

		public List<CustomerAccountReceipt> GetCustomerAccountReceiptsByDCAccountID(int DCAccountID)
		{
			return CustomerAccountReceiptIntegration.GetCustomerAccountReceiptsByDCAccountID(DCAccountID);
		}

		public CustomerAccountReceipt GetFirstReceiptByDCAccountID(int DCAccountID)
		{
			return CustomerAccountReceiptIntegration.GetFirstReceiptByDCAccountID(DCAccountID);
		}

		public decimal GetCustomerAccountBalanceByDCAccountID(int DCAccountID)
		{
			return CustomerAccountReceiptIntegration.GetCustomerAccountBalanceByDCAccountID(DCAccountID);
		}

        public CustomerAccountReceipt GetFirstReceiptByCustomerAccountID(int customerAccountID)
        {
            return CustomerAccountReceiptIntegration.GetFirstReceiptByCustomerAccountID(customerAccountID);
        }

		public decimal GetCustomerAccountBalance(int customerAccountID)
		{
			return CustomerAccountReceiptIntegration.GetCustomerAccountBalance(customerAccountID);
		}

		public int CancelCustomerAccountReceipt(CustomerAccountReceipt theCustomerAccountReceipt)
		{
			return CustomerAccountReceiptIntegration.CancelCustomerAccountReceipt(theCustomerAccountReceipt);
		}

		public int InsertCustomerAccountReceipt(CustomerAccountReceipt theCustomerAccountReceipt)
		{
			return CustomerAccountReceiptIntegration.InsertCustomerAccountReceipt(theCustomerAccountReceipt);
		}
		#endregion
	}
}

