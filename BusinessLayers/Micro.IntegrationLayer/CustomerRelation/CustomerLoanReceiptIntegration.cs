using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class CustomerLoanReceiptIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
		public static CustomerLoanReceipt DataRowToObject(DataRow dr)
		{
			CustomerLoanReceipt TheCustomerLoanReceipt = new CustomerLoanReceipt
			{
				CustomerLoanReceiptID = int.Parse(dr["CustomerLoanReceiptID"].ToString()),
				ReceiptSeries = dr["ReceiptSeries"].ToString(),
				CustomerLoanReceiptNumber = dr["CustomerLoanReceiptNumber"].ToString(),
				CustomerLoanID = int.Parse(dr["CustomerLoanID"].ToString()),
				CustomerLoanCode=dr["CustomerLoanCode"].ToString(),
				LoanApplicationNumber = dr["LoanApplicationNumber"].ToString(),
				LoanApplicationDate = DateTime.Parse(dr["LoanApplicationDate"].ToString()).ToString(MicroConstants.DateFormat),
				LoanAmount=decimal.Parse(dr["LoanAmount"].ToString()),
				RateOfInterest = decimal.Parse(dr["RateOfInterest"].ToString()),
				CustomerID = int.Parse(dr["CustomerID"].ToString()),
				CustomerCode = dr["CustomerCode"].ToString(),
				CustomerName = dr["CustomerName"].ToString(),
				CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString()),
				CustomerAccountCode=dr["CustomerAccountCode"].ToString(),
				DateOfRecovery = DateTime.Parse(dr["DateOfRecovery"].ToString()).ToString(MicroConstants.DateFormat),
				AmountPaid = decimal.Parse(dr["AmountPaid"].ToString()),
				AmountPaidAsPrincipal = decimal.Parse(dr["AmountPaidAsPrincipal"].ToString()),
				AmountPaidAsInterest = decimal.Parse(dr["AmountPaidAsInterest"].ToString()),
				InstallmentNumber = int.Parse(dr["InstallmentNumber"].ToString()),
				Remark = dr["Remark"].ToString(),
				IsCancelled = bool.Parse(dr["IsCancelled"].ToString()),
				OfficeID = int.Parse(dr["OfficeID"].ToString()),
				OfficeName = dr["OfficeName"].ToString()
			};

			return TheCustomerLoanReceipt;
		}

		public static List<CustomerLoanReceipt> GetCustomerLoanReceiptList()
        {
            List<CustomerLoanReceipt> CustomerLoanReceiptList = new List<CustomerLoanReceipt>();
			DataTable CustomerLoanReceiptTable = CustomerLoanReceiptDataAccess.GetInstance.GetCustomerLoanReceiptList();

			foreach(DataRow dr in CustomerLoanReceiptTable.Rows)
            {
				CustomerLoanReceipt TheCustomerLoanReceipt =DataRowToObject(dr);
                
                CustomerLoanReceiptList.Add(TheCustomerLoanReceipt);
            }

           return CustomerLoanReceiptList;
        }

		public static List<CustomerLoanReceipt> GetCustomerLoanReceiptListByCustomerLoanID(int customerLoanID)
		{
			List<CustomerLoanReceipt> CustomerLoanReceiptList = new List<CustomerLoanReceipt>();
			DataTable CustomerLoanReceiptTable = CustomerLoanReceiptDataAccess.GetInstance.GetCustomerLoanReceiptListByCustomerLoanID(customerLoanID);

			foreach(DataRow dr in CustomerLoanReceiptTable.Rows)
			{
				CustomerLoanReceipt TheCustomerLoanReceipt = DataRowToObject(dr);

				CustomerLoanReceiptList.Add(TheCustomerLoanReceipt);
			}

			return CustomerLoanReceiptList;
		}

		public static CustomerLoanReceipt GetCustomerLoanReceiptByID(int loanReceiptID)
		{
			DataRow CustomerLoanReceiptRow = CustomerLoanReceiptDataAccess.GetInstance.GetCustomerLoanReceiptByID(loanReceiptID);

			CustomerLoanReceipt TheCustomerLoanReceipt = DataRowToObject(CustomerLoanReceiptRow);

			return TheCustomerLoanReceipt;
		}

		public static int InsertCustomerLoanReceipt(CustomerLoanReceipt theCustomerLoanReceipt)
        {
            return CustomerLoanReceiptDataAccess.GetInstance.InsertCustomerLoanReceipt(theCustomerLoanReceipt);
        }

		public static int UpdateCustomerLoanReceipt()
        {
            return CustomerLoanReceiptDataAccess.GetInstance.UpdateCustomerLoanReceipt();
        }

		public static int DeleteCustomerLoanReceipt()
        {
            return CustomerLoanReceiptDataAccess.GetInstance.DeleteCustomerLoanReceipt();
        }
        #endregion
    }
}
