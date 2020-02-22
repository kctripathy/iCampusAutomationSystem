using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;
using System;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class CustomerLoanManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CustomerLoanManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CustomerLoanManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerLoanManagement();
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
        public string DefaultColumns = "CustomerName, CustomerLoanCode, LoanApplicationDate, LoanAmount";
        public string DisplayMember = "CustomerLoanCode";
        public string ValueMember = "CustomerLoanID";
        #endregion

        #region Methods & Implementation
        public List<CustomerLoan> GetCustomerLoanList(bool allOffices = false, bool showDeleted = false)
        {
            return CustomerLoanIntegration.GetCustomerLoanList(allOffices, showDeleted);
        }

        public List<CustomerLoan> GetCustomerActiveLoanList(bool allOffices = false, bool showDeleted = false)
        {
            return CustomerLoanIntegration.GetCustomerActiveLoanList(allOffices, showDeleted);
        }

        public List<CustomerLoan> GetCustomerLoanListByCustomerAccountID(int customerAccountID)
        {
            return CustomerLoanIntegration.GetCustomerLoanListByCustomerAccountID(customerAccountID);
        }

		public CustomerLoan GetCustomerLoanByCustomerLoanID(int customerLoanID)
		{
			return CustomerLoanIntegration.GetCustomerLoanByCustomerLoanID(customerLoanID);
		}

        public CustomerLoan GetActiveCustomerLoanByCustomerAccountID(int customerAccountID)
        {
            return CustomerLoanIntegration.GetActiveCustomerLoanByCustomerAccountID(customerAccountID);
        }

        public List<CustomerLoan> GetCustomerLoanListByOfficeIDs(string officeIds, bool allOffices)
        {
            return CustomerLoanIntegration.GetCustomerLoanListByOfficeIDs(officeIds, allOffices);
        }

        public decimal GetMaxLoanCanAvailByCustomerAccountID(int customerAccountID)
        {
            return CustomerLoanIntegration.GetMaxLoanCanAvailByCustomerAccountID(customerAccountID);
        }

        public decimal GetInterestAmount(int customerLoanID, DateTime recoveryDate)
        {
            return CustomerLoanIntegration.GetInterestAmount(customerLoanID, recoveryDate);
        }

        public int InsertCustomerLoan(CustomerLoan theCustomerLoan)
        {
            return CustomerLoanIntegration.InsertCustomerLoan(theCustomerLoan);
        }

        public int UpdateCustomerLoan(CustomerLoan theCustomerLoan)
        {
            return CustomerLoanIntegration.UpdateCustomerLoan(theCustomerLoan);
        }

        public int DeleteCustomerLoan(CustomerLoan theCustomerLoan)
        {
            return CustomerLoanIntegration.DeleteCustomerLoan(theCustomerLoan);
        }

        public List<CustomerLoan> GetCustomerLoanListByCustomerID(int customerID)
        {
            return CustomerLoanIntegration.GetCustomerLoanListByCustomerID(customerID);
        }
        #endregion
    }
}
