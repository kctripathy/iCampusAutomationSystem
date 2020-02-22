using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class CustomerManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CustomerManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CustomerManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerManagement();
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
        public string DefaultColumns = "CustomerName, CustomerCode, FatherName, DateOfBirth, Address_Present_DistrictName";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "CustomerID";
        #endregion

        #region Methods & Implementation
        public List<Customer> GetCustomerList(bool allOffices = false, bool showDeleted = false)
        {
            return CustomerIntegration.GetCustomerList(allOffices, showDeleted);
        }

        public List<Customer> GetDuplicateCustomerList(string customerName, string fatherName, string dateofBirth, bool allOffices = false, bool showDeleted = false)
        {
            return CustomerIntegration.GetDuplicateCustomerList(customerName, fatherName, dateofBirth, allOffices, showDeleted);
        }

        public List<Customer> GetCustomerListByOfficeIDs(bool allOffices, string officeIDs)
        {
            return CustomerIntegration.GetCustomerListByOfficeIDs(allOffices, officeIDs);
        }
        
        public List<Customer> GetCustomerListByCustomerLoans(bool allOffices, string officeIDs)
        {
            return CustomerIntegration.GetCustomerListByCustomerLoans(allOffices, officeIDs);
        }

        public List<Customer> GetCustomerMediclaimEligibilityList(bool allOffices = false)
        {
            return CustomerIntegration.GetCustomerMediclaimEligibilityList(allOffices);
        }

        public Customer GetCustomerByID(int customerID)
        {
			//TODO: Cache the customer being requested for first time
            return CustomerIntegration.GetCustomerByID(customerID);
        }

        public int InsertCustomer(Customer theCustomer)
        {
            return CustomerIntegration.InsertCustomer(theCustomer);
        }

        public int UpdateCustomer(Customer theCustomer)
        {
            return CustomerIntegration.UpdateCustomer(theCustomer);
        }

        public int DeleteCustomer(Customer theCustomer)
        {
            return CustomerIntegration.DeleteCustomer(theCustomer);
        }
        #endregion
    }
}
