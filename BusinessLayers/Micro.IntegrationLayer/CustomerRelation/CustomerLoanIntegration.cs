using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class CustomerLoanIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static CustomerLoan DataRowToObject(DataRow dr)
        {
            CustomerLoan TheCustomerLoan = new CustomerLoan();

            TheCustomerLoan.CustomerLoanID = int.Parse(dr["CustomerLoanID"].ToString());
            TheCustomerLoan.CustomerLoanCode = dr["CustomerLoanCode"].ToString();
            TheCustomerLoan.CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString());
			TheCustomerLoan.CustomerAccountCode = dr["CustomerAccountCode"].ToString();
            TheCustomerLoan.CustomerID = int.Parse(dr["CustomerID"].ToString());
            TheCustomerLoan.CustomerCode = dr["CustomerCode"].ToString();
            TheCustomerLoan.CustomerName = dr["CustomerName"].ToString();
            TheCustomerLoan.LoanApplicationNumber = dr["LoanApplicationNumber"].ToString();
            TheCustomerLoan.LoanApplicationDate = DateTime.Parse(dr["LoanApplicationDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheCustomerLoan.LoanApplicationFee = decimal.Parse(dr["LoanApplicationFee"].ToString());
            TheCustomerLoan.LoanAmount = decimal.Parse(dr["LoanAmount"].ToString());
            TheCustomerLoan.RateOfInterest = decimal.Parse(dr["RateOfInterest"].ToString());
            TheCustomerLoan.RequiredFor = dr["RequiredFor"].ToString();
            TheCustomerLoan.InstallmentType = dr["InstallmentType"].ToString();
            TheCustomerLoan.SanctionedByID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["SanctionedByID"].ToString()));
            TheCustomerLoan.SanctionedByName = dr["SanctionedByName"].ToString();
            TheCustomerLoan.IsClosed = bool.Parse(dr["IsClosed"].ToString());
            if (TheCustomerLoan.IsClosed)
                TheCustomerLoan.ClosureDate = DateTime.Parse(dr["ClosureDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheCustomerLoan.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheCustomerLoan.OfficeName = dr["OfficeName"].ToString();

            return TheCustomerLoan;
        }

        public static List<CustomerLoan> GetCustomerLoanList(bool allOffices = false, bool showDeleted = false)
        {
            List<CustomerLoan> CustomerLoanList = new List<CustomerLoan>();

            DataTable CustomerLoanTable = CustomerLoanDataAccess.GetInstance.GetCustomerLoanList(allOffices, showDeleted);

            foreach (DataRow dr in CustomerLoanTable.Rows)
            {
                CustomerLoan TheCustomerLoan = DataRowToObject(dr);

                CustomerLoanList.Add(TheCustomerLoan);
            }

            return CustomerLoanList;
        }

        public static List<CustomerLoan> GetCustomerActiveLoanList(bool allOffices = false, bool showDeleted = false)
        {
            List<CustomerLoan> CustomerActiveLoanList = new List<CustomerLoan>();
            List<CustomerLoan> CustomerLoanList = GetCustomerLoanList(allOffices, showDeleted);

            if (CustomerLoanList.Count > 0)
            {
                var ActiveLoanList = (from TheLoanList in CustomerLoanList
                                      where TheLoanList.IsClosed == false
                                      select TheLoanList);

                foreach (CustomerLoan EachLoan in ActiveLoanList)
                {
                    CustomerLoan TheCustomerLoan = (CustomerLoan)EachLoan;

                    CustomerActiveLoanList.Add(TheCustomerLoan);
                }
            }

            return CustomerActiveLoanList;
        }

        public static List<CustomerLoan> GetCustomerLoanListByCustomerAccountID(int customerAccountID)
        {
            List<CustomerLoan> CustomerLoanList = new List<CustomerLoan>();
            DataTable CustomerLoanTable = CustomerLoanDataAccess.GetInstance.GetCustomerLoanListByCustomerAccountID(customerAccountID);

            foreach (DataRow dr in CustomerLoanTable.Rows)
            {
                CustomerLoan TheCustomerLoan = DataRowToObject(dr);

                CustomerLoanList.Add(TheCustomerLoan);
            }

            return CustomerLoanList;
        }

        public static CustomerLoan GetActiveCustomerLoanByCustomerAccountID(int customerAccountID)
        {
            CustomerLoan ActiveCustomerLoan = new CustomerLoan();
            List<CustomerLoan> CustomerLoanList = GetCustomerLoanListByCustomerAccountID(customerAccountID);

            if (CustomerLoanList.Count > 0)
            {
                var TheActiveCustomerLoan = (from TheLoanList in CustomerLoanList
                                             where TheLoanList.IsClosed == false
                                             select TheLoanList).LastOrDefault();

                if (TheActiveCustomerLoan != null)
                    ActiveCustomerLoan = TheActiveCustomerLoan;
            }

            return ActiveCustomerLoan;
        }

        public static List<CustomerLoan> GetCustomerLoanListByOfficeIDs(string officeIds, bool allOffices)
        {
            List<CustomerLoan> CustomerLoanList = new List<CustomerLoan>();
            DataTable CustomerLoanTable = CustomerLoanDataAccess.GetInstance.GetCustomerLoanListByOfficeIDs(officeIds, allOffices);

            foreach (DataRow dr in CustomerLoanTable.Rows)
            {
                CustomerLoan TheCustomerLoan = DataRowToObject(dr);

                CustomerLoanList.Add(TheCustomerLoan);
            }

            return CustomerLoanList;
        }

        public static decimal GetMaxLoanCanAvailByCustomerAccountID(int customerAccountID)
        {
            DataRow CustomerLoanDataRow = CustomerLoanDataAccess.GetInstance.GetMaxLoanCanAvailByCustomerAccountID(customerAccountID);
            decimal ReturnValue = decimal.Parse(CustomerLoanDataRow["MaxLoanAmount"].ToString());

            return ReturnValue;
        }

		public static CustomerLoan GetCustomerLoanByCustomerLoanID(int customerLoanID)
		{
			DataRow CustomerLoanRow = CustomerLoanDataAccess.GetInstance.GetCustomerLoanByCustomerLoanID(customerLoanID);

			CustomerLoan TheCustomerLoan = DataRowToObject(CustomerLoanRow);

			return TheCustomerLoan;
		}

        public static CustomerLoan GetActiveLoanDetailsByCustomerAccountID(int customerAccountID)
        {
            DataRow CustomerLoanRow = CustomerLoanDataAccess.GetInstance.GetActiveLoanDetailsByCustomerAccountID(customerAccountID);

            CustomerLoan TheCustomerLoan = DataRowToObject(CustomerLoanRow);

            return TheCustomerLoan;
        }

        public static decimal GetInterestAmount(int customerLoanID, DateTime recoveryDate)
        {
            DataRow CustomerLoanDataRow = CustomerLoanDataAccess.GetInstance.GetInterestAmount(customerLoanID, recoveryDate);
            decimal ReturnValue = decimal.Parse(CustomerLoanDataRow["InterestAmount"].ToString());

            return ReturnValue;
        }

        public static int InsertCustomerLoan(CustomerLoan theCustomerLoan)
        {
            return CustomerLoanDataAccess.GetInstance.InsertCustomerLoan(theCustomerLoan);
        }

        public static int UpdateCustomerLoan(CustomerLoan theCustomerLoan)
        {
            return CustomerLoanDataAccess.GetInstance.UpdateCustomerLoan(theCustomerLoan);
        }

        public static int DeleteCustomerLoan(CustomerLoan theCustomerLoan)
        {
            return CustomerLoanDataAccess.GetInstance.DeleteCustomerLoan(theCustomerLoan);
        }

        public static List<CustomerLoan> GetCustomerLoanListByCustomerID(int customerID)
        {
            List<CustomerLoan> CustomerLoanList = new List<CustomerLoan>();
            DataTable CustomerLoanTable = CustomerLoanDataAccess.GetInstance.GetCustomerLoanListByCustomerID(customerID);

            foreach (DataRow dr in CustomerLoanTable.Rows)
            {
                CustomerLoan TheCustomerLoan = DataRowToObject(dr);

                CustomerLoanList.Add(TheCustomerLoan);
            }

            return CustomerLoanList;
        }
        #endregion
    }
}
