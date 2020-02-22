using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class CustomerAccountIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static CustomerAccount DataRowToObject(DataRow dr)
        {
            CustomerAccount TheCustomerAccount = new CustomerAccount();

            TheCustomerAccount.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
            TheCustomerAccount.CustomerID = int.Parse(dr["CustomerID"].ToString());
			TheCustomerAccount.CustomerCode= dr["CustomerCode"].ToString();
            TheCustomerAccount.CustomerName = dr["CustomerName"].ToString();
            TheCustomerAccount.CustomerAccountCode = dr["CustomerAccountCode"].ToString();
            TheCustomerAccount.IsJointApplication = bool.Parse(dr["IsJointApplication"].ToString());
            TheCustomerAccount.ApplicationFormNumber = dr["ApplicationFormNumber"].ToString();
            TheCustomerAccount.ApplicationDate = DateTime.Parse(dr["ApplicationDate"].ToString()).ToString(MicroConstants.DateFormat);

            if (TheCustomerAccount.IsJointApplication)
            {
                TheCustomerAccount.SecondApplicantName = dr["SecondApplicantName"].ToString();
                TheCustomerAccount.SecondApplicantAge = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["SecondApplicantAge"].ToString()));
                if (!string.IsNullOrEmpty(dr["SecondApplicantSignature"].ToString()))
                {
                    TheCustomerAccount.SecondApplicantSignature = (byte[])dr["SecondApplicantSignature"];
                }
                TheCustomerAccount.SecondApplicantPANGIR = dr["SecondApplicantPANGIR"].ToString();
                TheCustomerAccount.ThirdApplicantName = dr["ThirdApplicantName"].ToString();
                TheCustomerAccount.ThirdApplicantAge = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ThirdApplicantAge"].ToString()));
                if (!string.IsNullOrEmpty(dr["ThirdApplicantSignature"].ToString()))
                {
                    TheCustomerAccount.ThirdApplicantSignature = (byte[])dr["ThirdApplicantSignature"];
                }
                TheCustomerAccount.ThirdApplicantPANGIR = dr["ThirdApplicantPANGIR"].ToString();
            }

            TheCustomerAccount.NomineeName = dr["NomineeName"].ToString();
            TheCustomerAccount.Nominee_Permanent_TownOrCity = dr["Nominee_Permanent_TownOrCity"].ToString();
            TheCustomerAccount.Nominee_Permanent_Landmark = dr["Nominee_Permanent_Landmark"].ToString();
            TheCustomerAccount.Nominee_Permanent_PinCode = dr["Nominee_Permanent_PinCode"].ToString();
            TheCustomerAccount.Nominee_Permanent_DistrictID = int.Parse(dr["Nominee_Permanent_DistrictID"].ToString());
            TheCustomerAccount.Nominee_Permanent_DistrictName = dr["Nominee_Permanent_DistrictName"].ToString();
            TheCustomerAccount.Nominee_Permanent_StateName = dr["Nominee_Permanent_StateName"].ToString();
            TheCustomerAccount.Nominee_Permanent_CountryName = dr["Nominee_Permanent_CountryName"].ToString();
            TheCustomerAccount.NomineeRelationship = dr["NomineeRelationship"].ToString();
            TheCustomerAccount.NomineeAge = int.Parse(dr["NomineeAge"].ToString());
            TheCustomerAccount.PolicyName = dr["PolicyName"].ToString();
            TheCustomerAccount.PolicyTypeID = int.Parse(dr["PolicyTypeID"].ToString());
            TheCustomerAccount.PolicyTypeDescription = dr["PolicyTypeDescription"].ToString();
            TheCustomerAccount.InstallmentMode = dr["InstallmentMode"].ToString();
            TheCustomerAccount.TermInMonths = int.Parse(dr["TermInMonths"].ToString());
            TheCustomerAccount.InstallmentAmount = decimal.Parse(dr["InstallmentAmount"].ToString());
            TheCustomerAccount.NumberOfInstallmentsToBePaid = int.Parse(dr["NumberOfInstallmentsToBePaid"].ToString());
            TheCustomerAccount.NumberOfInstallmentsPaid = int.Parse(dr["NumberOfInstallmentsPaid"].ToString());
			TheCustomerAccount.FieldForceRankID = int.Parse(dr["FieldForceRankID"].ToString());
            TheCustomerAccount.FieldForceID = int.Parse(dr["FieldForceID"].ToString());
            TheCustomerAccount.FieldForceCode = dr["FieldForceCode"].ToString();
            TheCustomerAccount.FieldForceName = dr["FieldForceName"].ToString();
            TheCustomerAccount.DueDateOfLastPayment = DateTime.Parse(dr["DueDateOfLastPayment"].ToString()).ToString(MicroConstants.DateFormat);
            TheCustomerAccount.DueDateOfMaturity = DateTime.Parse(dr["DueDateOfMaturity"].ToString()).ToString(MicroConstants.DateFormat);
            TheCustomerAccount.PayToCompany = decimal.Parse(dr["PayToCompany"].ToString());
            TheCustomerAccount.GuaranteedDividend = decimal.Parse(dr["GuaranteedDividend"].ToString());
            TheCustomerAccount.BonusAmount = decimal.Parse(dr["BonusAmount"].ToString());
            TheCustomerAccount.PayByCompany = decimal.Parse(dr["PayByCompany"].ToString());
            TheCustomerAccount.MoneybackPayable = decimal.Parse(dr["MoneybackPayable"].ToString());
            TheCustomerAccount.RevivalState = bool.Parse(dr["RevivalState"].ToString());
            TheCustomerAccount.SellingState = bool.Parse(dr["SellingState"].ToString());
            TheCustomerAccount.MaturityState = bool.Parse(dr["MaturityState"].ToString());
            TheCustomerAccount.DCAccountID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["DCAccountID"].ToString()));
            TheCustomerAccount.OfficeID = int.Parse(dr["OfficeID"].ToString());

            return TheCustomerAccount;
        }

        public static List<CustomerAccount> GetCustomerAccountList(bool allOffices = false, bool showDeleted = false)
        {
            List<CustomerAccount> CustomerAccountList = new List<CustomerAccount>();

            DataTable CustomerAccountTable = CustomerAccountDataAccess.GetInstance.GetCustomerAccountList(allOffices, showDeleted);

            foreach (DataRow dr in CustomerAccountTable.Rows)
            {
                CustomerAccount TheCustomerAccount = DataRowToObject(dr);

                CustomerAccountList.Add(TheCustomerAccount);
            }

            return CustomerAccountList;
        }

        public static List<CustomerAccount> GetImmatureCustomerAccountList(bool allOffices = false, bool showDeleted = false)
        {
            List<CustomerAccount> ImmatureCustomerAccountList = new List<CustomerAccount>();
            List<CustomerAccount> TheCustomerAccountList = GetCustomerAccountList(allOffices, showDeleted);

            if (TheCustomerAccountList.Count > 0)
            {
                var CustomerAccountList = (from CustomerAccounts in TheCustomerAccountList
                                           where CustomerAccounts.MaturityState == false
										   select CustomerAccounts).ToList();

                foreach (CustomerAccount TheCustomerAccount in CustomerAccountList)
                {
                    ImmatureCustomerAccountList.Add(TheCustomerAccount);
                }
            }

            return ImmatureCustomerAccountList;
        }

        public static List<CustomerAccount> GetCustomerAccountListByPolicyType(string policyTypeDescription, bool allOffices = false, bool showDeleted = false)
        {
            List<CustomerAccount> CustomerAccountListByPolicyType = new List<CustomerAccount>();
            List<CustomerAccount> TheCustomerAccountList = GetImmatureCustomerAccountList(allOffices, showDeleted);

            if (TheCustomerAccountList.Count > 0)
            {
                var CustomerAccountList = (from TheAccount in TheCustomerAccountList
                                           where TheAccount.PolicyTypeDescription == policyTypeDescription
                                           select TheAccount);

                foreach (CustomerAccount TheCustomerAccount in CustomerAccountList)
                {
                    CustomerAccountListByPolicyType.Add(TheCustomerAccount);
                }
            }

            return CustomerAccountListByPolicyType;
        }

        public static List<CustomerAccount> GetCustomerAccountListByInstallmentMode(string InstallmentMode, bool allOffices = false, bool showDeleted = false)
        {
            List<CustomerAccount> CustomerAccountListByInstallmentMode = new List<CustomerAccount>();
            List<CustomerAccount> TheCustomerAccountList = GetImmatureCustomerAccountList(allOffices, showDeleted);

            if (TheCustomerAccountList.Count > 0)
            {
                var CustomerAccountList = (from TheAccount in TheCustomerAccountList
                                           where TheAccount.InstallmentMode == InstallmentMode
                                           select TheAccount);

                foreach (CustomerAccount TheCustomerAccount in CustomerAccountList)
                {
                    CustomerAccountListByInstallmentMode.Add(TheCustomerAccount);
                }
            }

            return CustomerAccountListByInstallmentMode;
        }

        public static List<CustomerAccount> GetDiscontinuedCustomerAccountList(DateTime transactionDate, bool allOffices = false)
        {
            List<CustomerAccount> CustomerAccountList = new List<CustomerAccount>();

            DataTable CustomerAccountTable = CustomerAccountDataAccess.GetInstance.GetDiscontinuedCustomerAccountList(transactionDate, allOffices);

            foreach (DataRow dr in CustomerAccountTable.Rows)
            {
                CustomerAccount TheCustomerAccount = DataRowToObject(dr);

                CustomerAccountList.Add(TheCustomerAccount);
            }

            return CustomerAccountList;
        }

        public static List<CustomerAccount> GetCustomerAccountCertificateList()
        {
            List<CustomerAccount> CustomerAccountList = new List<CustomerAccount>();

            DataTable CustomerAccountTable = CustomerAccountDataAccess.GetInstance.GetCustomerAccountCertificateList();

            foreach (DataRow dr in CustomerAccountTable.Rows)
            {
                CustomerAccount TheCustomerAccount = DataRowToObject(dr);

                CustomerAccountList.Add(TheCustomerAccount);
            }

            return CustomerAccountList;
        }

        public static CustomerAccount GetCustomerAccountByID(int CustomerAccountID)
        {
            DataRow CustomerAccountRow = CustomerAccountDataAccess.GetInstance.GetCustomerAccountByID(CustomerAccountID);

            CustomerAccount TheCustomerAccount = DataRowToObject(CustomerAccountRow);

            return TheCustomerAccount;
        }

		public static CustomerAccount GetCustomerAccountByDCAccountId(int DCAccountID)
		{
			DataRow CustomerAccountRow = CustomerAccountDataAccess.GetInstance.GetCustomerAccountByDCAccountId(DCAccountID);

			CustomerAccount TheCustomerAccount = DataRowToObject(CustomerAccountRow);

			return TheCustomerAccount;
		}

        public static CustomerAccount GetPayByCompany(int policyTypeID, decimal installmentAmount, string policyMode, int customerAge = 0)
        {
            CustomerAccount TheCustomerAccount = new CustomerAccount();

            DataRow CustomerAccountRow = CustomerAccountDataAccess.GetInstance.GetPayByCompany(policyTypeID, installmentAmount, policyMode, customerAge);

            TheCustomerAccount.PayToCompany = decimal.Parse(CustomerAccountRow["PayToCompany"].ToString());
            TheCustomerAccount.GuaranteedDividend = decimal.Parse(CustomerAccountRow["GuaranteedDividend"].ToString());
            TheCustomerAccount.BonusAmount = decimal.Parse(CustomerAccountRow["BonusAmount"].ToString());
            TheCustomerAccount.PayByCompany = decimal.Parse(CustomerAccountRow["PayByCompany"].ToString());
            TheCustomerAccount.MoneybackPayable = decimal.Parse(CustomerAccountRow["MoneybackPayable"].ToString());

            return TheCustomerAccount;
        }

        public static List<CustomerAccount> GetCustomerAccountListByOfficeIDs(bool allOffices, string officeIDs)
        {
            List<CustomerAccount> CustomerAccountList = new List<CustomerAccount>();

            DataTable CustomerAccountTable = CustomerAccountDataAccess.GetInstance.GetCustomerAccountListByOfficeIDs(allOffices, officeIDs);

            foreach (DataRow dr in CustomerAccountTable.Rows)
            {
                CustomerAccount TheCustomerAccount = DataRowToObject(dr);

                CustomerAccountList.Add(TheCustomerAccount);
            }
            return CustomerAccountList;
        }

        public static List<CustomerAccount> GetEligibleCustomerAccountListByCustomerID(int customerID, bool isProcessingApproval = false)
        {
            List<CustomerAccount> CustomerAccountList = new List<CustomerAccount>();

            DataTable CustomerAccountTable = CustomerAccountDataAccess.GetInstance.GetEligibleCustomerAccountListByCustomerID(customerID, isProcessingApproval);

            foreach (DataRow dr in CustomerAccountTable.Rows)
            {
                CustomerAccount TheCustomerAccount = DataRowToObject(dr);

                CustomerAccountList.Add(TheCustomerAccount);
            }
            return CustomerAccountList;
        }

        public static List<CustomerAccount> GetContinuedCustomerAccountListByCustomerID(int customerID)
        {
            List<CustomerAccount> CustomerAccountList = new List<CustomerAccount>();

            DataTable CustomerAccountTable = CustomerAccountDataAccess.GetInstance.GetContinuedCustomerAccountListByCustomerID(customerID);

            foreach (DataRow dr in CustomerAccountTable.Rows)
            {
                CustomerAccount TheCustomerAccount = DataRowToObject(dr);

                CustomerAccountList.Add(TheCustomerAccount);
            }
            return CustomerAccountList;
        }

        public static int InsertCustomerAccount(CustomerAccount theCustomerAccount, CustomerAccountReceipt theCustomerAccountReceipt)
        {
            return CustomerAccountDataAccess.GetInstance.InsertCustomerAccount(theCustomerAccount, theCustomerAccountReceipt);
        }

        public static int UpdateCustomerAccount(CustomerAccount theCustomerAccount)
        {
            return CustomerAccountDataAccess.GetInstance.UpdateCustomerAccount(theCustomerAccount);
        }

        public static int DeleteCustomerAccount(CustomerAccount theCustomerAccount)
        {
            return CustomerAccountDataAccess.GetInstance.DeleteCustomerAccount(theCustomerAccount);
        }
        #endregion
    }
}
