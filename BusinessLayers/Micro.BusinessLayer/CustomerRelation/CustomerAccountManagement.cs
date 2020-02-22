using System;
using System.Linq;
using System.Collections.Generic;
using Micro.IntegrationLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.BusinessLayer.CustomerRelation
{
    public partial class CustomerAccountManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static CustomerAccountManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static CustomerAccountManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CustomerAccountManagement();
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
        public string DefaultColumns = "CustomerName, CustomerAccountCode";
        public string DisplayMember = "CustomerName";
        public string ValueMember = "CustomerAccountID";
        #endregion

        #region Methods & Imlpementation
        public List<CustomerAccount> GetCustomerAccountList(bool allOffices = false, bool showDeleted = false)
        {
            return CustomerAccountIntegration.GetCustomerAccountList(allOffices, showDeleted);
        }

        public List<CustomerAccount> GetImmatureCustomerAccountList(bool allOffices = false, bool showDeleted = false)
        {
            return CustomerAccountIntegration.GetImmatureCustomerAccountList(allOffices, showDeleted);
        }

        /// <summary>
        /// Returns only immature customer accounts by given PolicyTypeDescription
        /// </summary>
        /// <param name="policyTypeDescription"></param>
        /// <param name="allOffices"></param>
        /// <param name="showDeleted"></param>
        /// <returns></returns>
        public List<CustomerAccount> GetCustomerAccountListByPolicyType(string policyTypeDescription, bool allOffices = false, bool showDeleted = false)
        {
            return CustomerAccountIntegration.GetCustomerAccountListByPolicyType(policyTypeDescription, allOffices, showDeleted);
        }

        public List<CustomerAccount> GetCustomerAccountListByInstallmentMode(string InstallmentMode, bool allOffices = false, bool showDeleted = false)
        {
            return CustomerAccountIntegration.GetCustomerAccountListByInstallmentMode(InstallmentMode, allOffices, showDeleted);
        }

        public List<CustomerAccount> GetDiscontinuedCustomerAccountList(DateTime transactionDate, bool allOffices = false)
        {
            return CustomerAccountIntegration.GetDiscontinuedCustomerAccountList(transactionDate, allOffices);
        }

        public List<CustomerAccount> GetCustomerAccountCertificateList()
        {
            return CustomerAccountIntegration.GetCustomerAccountCertificateList();
        }

        public CustomerAccount GetCustomerAccountByID(int CustomerAccountID)
        {
            return CustomerAccountIntegration.GetCustomerAccountByID(CustomerAccountID);
        }

        public CustomerAccount GetCustomerAccountByDCAccountId(int DCAccountID)
        {
            return CustomerAccountIntegration.GetCustomerAccountByDCAccountId(DCAccountID);
        }

        public CustomerAccount GetPayByCompany(int policyTypeID, decimal installmentAmount, string policyMode, int customerAge = 0)
        {
            return CustomerAccountIntegration.GetPayByCompany(policyTypeID, installmentAmount, policyMode, customerAge);
        }

        public List<CustomerAccount> GetCustomerAccountListByOfficeIDs(bool allOffices, string officeIDs)
        {
            return CustomerAccountIntegration.GetCustomerAccountListByOfficeIDs(allOffices, officeIDs);
        }

        public List<CustomerAccount> GetEligibleCustomerAccountListByCustomerID(int customerID, bool isProcessingApproval = false)
        {
            return CustomerAccountIntegration.GetEligibleCustomerAccountListByCustomerID(customerID, isProcessingApproval);
        }

        public List<CustomerAccount> GetContinuedCustomerAccountListByCustomerID(int customerID)
        {
            return CustomerAccountIntegration.GetContinuedCustomerAccountListByCustomerID(customerID);
        }

        public List<CustomerAccount> GetCustomerAccountListByApplicationFormNumber(string applicationFormNumber)
        {
            List<CustomerAccount> CustomerAccountList = GetCustomerAccountList();
            List<CustomerAccount> FilteredCustomerAccountList;

            if (CustomerAccountList.Count > 0)
                FilteredCustomerAccountList = (from AccountList in CustomerAccountList
                                               where AccountList.ApplicationFormNumber.Trim().Equals(applicationFormNumber.Trim())
                                               select AccountList).ToList();
            else
                FilteredCustomerAccountList = new List<CustomerAccount>();

            return FilteredCustomerAccountList;
        }

        public int InsertCustomerAccount(CustomerAccount theCustomerAccount, CustomerAccountReceipt theCustomerAccountReceipt)
        {
            return CustomerAccountIntegration.InsertCustomerAccount(theCustomerAccount, theCustomerAccountReceipt);
        }

        public int UpdateCustomerAccount(CustomerAccount theCustomerAccount)
        {
            return CustomerAccountIntegration.UpdateCustomerAccount(theCustomerAccount);
        }

        public int DeleteCustomerAccount(CustomerAccount theCustomerAccount)
        {
            return CustomerAccountIntegration.DeleteCustomerAccount(theCustomerAccount);
        }
        #endregion
    }
}
