using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class CustomerLoanReceiptManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CustomerLoanReceiptManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CustomerLoanReceiptManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerLoanReceiptManagement();
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
		public string DefaultColumns = "CustomerName, CustomerLoanCode, CustomerLoanReceiptNumber, DateOfRecovery, InstallmentNumber, AmountPaidAsPrincipal, AmountPaidAsInterest, AmountPaid";
		public string DisplayMember = "CustomerLoanReceiptNumber";
        public string ValueMember = "CustomerLoanReceiptID";
        #endregion

        #region Methods & Implementation
		public List<CustomerLoanReceipt> GetCustomerLoanReceiptList()
        {
			return CustomerLoanReceiptIntegration.GetCustomerLoanReceiptList();
        }

		public List<CustomerLoanReceipt> GetCustomerLoanReceiptListByCustomerLoanID(int customerLoanID)
		{
			return CustomerLoanReceiptIntegration.GetCustomerLoanReceiptListByCustomerLoanID(customerLoanID);
		}

		public CustomerLoanReceipt GetCustomerLoanReceiptByID(int loanReceiptID)
		{
			return CustomerLoanReceiptIntegration.GetCustomerLoanReceiptByID(loanReceiptID);
		}

		public int InsertCustomerLoanReceipt(CustomerLoanReceipt theCustomerLoanReceipt)
        {
            return CustomerLoanReceiptIntegration.InsertCustomerLoanReceipt(theCustomerLoanReceipt);
        }

		public int UpdateCustomerLoanReceipt()
        {
            return CustomerLoanReceiptIntegration.UpdateCustomerLoanReceipt();
        }

		public int DeleteCustomerLoanReceipt()
        {
            return CustomerLoanReceiptIntegration.DeleteCustomerLoanReceipt();
        }
        #endregion
    }
}
