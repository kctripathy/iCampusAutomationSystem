using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
    public partial class CustomerAccountReceiptIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static CustomerAccountReceipt DataRowToObject(DataRow dr)
        {
            CustomerAccountReceipt TheCustomerAccountReceipt = new CustomerAccountReceipt
            {
                ReceiptID = int.Parse(dr["ReceiptID"].ToString()),
                ReceiptSeries = dr["ReceiptSeries"].ToString(),
                ReceiptNumber = dr["ReceiptNumber"].ToString(),
                ReceiptDate = DateTime.Parse(dr["ReceiptDate"].ToString()).ToString(MicroConstants.DateFormat),
                CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString()),
                CustomerAccountCode = dr["CustomerAccountCode"].ToString(),
                CustomerName = dr["CustomerName"].ToString(),
                PolicyTypeID = int.Parse(dr["PolicyTypeID"].ToString()),
                InstallmentNumberFrom = int.Parse(dr["InstallmentNumberFrom"].ToString()),
                InstallmentNumberTo = int.Parse(dr["InstallmentNumberTo"].ToString()),
                InstallmentAmountPayable = decimal.Parse(dr["InstallmentAmountPayable"].ToString()),
                InstallmentAmountPaid = decimal.Parse(dr["InstallmentAmountPaid"].ToString()),
                AdmissionOrFineAmount = decimal.Parse(dr["AdmissionOrFineAmount"].ToString()),
                RebateAmount = decimal.Parse(dr["RebateAmount"].ToString()),
                PaymentMode = dr["PaymentMode"].ToString(),
                PaymentReference = dr["PaymentReference"].ToString(),
                DueDateOfNextInstallment = DateTime.Parse(dr["DueDateOfNextInstallment"].ToString()).ToString(MicroConstants.DateFormat),
                ScrollID = int.Parse(dr["ScrollID"].ToString()),
                ScrollNumber = int.Parse(dr["ScrollNumber"].ToString()),
                ScrollDate = DateTime.Parse(dr["ScrollDate"].ToString()).ToString(MicroConstants.DateFormat),
                DepositorName = dr["DepositorName"].ToString(),
                TellerID = int.Parse(dr["TellerID"].ToString()),
                TellerName = dr["TellerName"].ToString(),
                OfficeID = int.Parse(dr["OfficeID"].ToString()),
                OfficeName = dr["OfficeName"].ToString(),
                PrintCounter = int.Parse(dr["PrintCounter"].ToString()),
                IsCancelled = bool.Parse(dr["IsCancelled"].ToString())
            };

            return TheCustomerAccountReceipt;
        }

        public static List<CustomerAccountReceipt> GetCustomerAccountReceiptsByScrollID(int scrollID)
        {
            List<CustomerAccountReceipt> TheCustomerAccountReceiptList = new List<CustomerAccountReceipt>();
            DataTable CustomerAccountReceiptTable = CustomerAccountReceiptDataAccess.GetInstance.GetCustomerAccountReceiptsByScrollID(scrollID);

            foreach (DataRow dr in CustomerAccountReceiptTable.Rows)
            {
                CustomerAccountReceipt TheCustomerAccountReceipt = DataRowToObject(dr);

                TheCustomerAccountReceiptList.Add(TheCustomerAccountReceipt);
            }

            return TheCustomerAccountReceiptList;
        }

        public static List<CustomerAccountReceipt> GetCustomerAccountReceiptsByCustomerAccountID(int customerAccountID)
        {
            List<CustomerAccountReceipt> CustomerAccountReceiptList = new List<CustomerAccountReceipt>();
            DataTable CustomerAccountReceiptTable = CustomerAccountReceiptDataAccess.GetInstance.GetCustomerAccountReceiptsByCustomerAccountID(customerAccountID);

            foreach (DataRow dr in CustomerAccountReceiptTable.Rows)
            {
                CustomerAccountReceipt TheCustomerAccountReceipt = DataRowToObject(dr);

                CustomerAccountReceiptList.Add(TheCustomerAccountReceipt);
            }

            return CustomerAccountReceiptList;
        }

		public static List<CustomerAccountReceipt> GetCustomerAccountReceiptsByDCAccountID(int DCAccountID)
		{
			List<CustomerAccountReceipt> CustomerAccountReceiptList = new List<CustomerAccountReceipt>();
			DataTable CustomerAccountReceiptTable = CustomerAccountReceiptDataAccess.GetInstance.GetCustomerAccountReceiptsByDCAccountID(DCAccountID);

			foreach (DataRow dr in CustomerAccountReceiptTable.Rows)
			{
				CustomerAccountReceipt TheCustomerAccountReceipt = DataRowToObject(dr);

				CustomerAccountReceiptList.Add(TheCustomerAccountReceipt);
			}

			return CustomerAccountReceiptList;
		}

		public static CustomerAccountReceipt GetFirstReceiptByDCAccountID(int DCAccountID)
		{
			CustomerAccountReceipt ReturnValue;

			List<CustomerAccountReceipt> TheCustomerAccountReceiptList = GetCustomerAccountReceiptsByDCAccountID(DCAccountID);

			if (TheCustomerAccountReceiptList.Count > 0)
				ReturnValue = (TheCustomerAccountReceiptList.OrderBy(Receipt => Receipt.ReceiptDate)).First();
			else
				ReturnValue = new CustomerAccountReceipt();

			return ReturnValue;
		}

		public static decimal GetCustomerAccountBalanceByDCAccountID(int DCAccountID)
		{
			decimal InstallmentAmountPayable = 0;
			List<CustomerAccountReceipt> TheCustomerAccountReceiptList = GetCustomerAccountReceiptsByDCAccountID(DCAccountID);

			if (TheCustomerAccountReceiptList.Count > 0)
			{
				InstallmentAmountPayable = (from ReceiptTotal in TheCustomerAccountReceiptList
											select ReceiptTotal.InstallmentAmountPayable).Sum();
			}

			return InstallmentAmountPayable;
		}

        public static CustomerAccountReceipt GetFirstReceiptByCustomerAccountID(int customerAccountID)
        {
            CustomerAccountReceipt ReturnValue;

            List<CustomerAccountReceipt> TheCustomerAccountReceiptList = GetCustomerAccountReceiptsByCustomerAccountID(customerAccountID);

            if (TheCustomerAccountReceiptList.Count > 0)
                ReturnValue = (TheCustomerAccountReceiptList.OrderBy(Receipt => Receipt.ReceiptDate)).First();
            else
                ReturnValue = new CustomerAccountReceipt();

            return ReturnValue;
        }

        public static decimal GetCustomerAccountBalance(int customerAccountID)
        {
            decimal InstallmentAmountPayable = 0;
            List<CustomerAccountReceipt> TheCustomerAccountReceiptList = GetCustomerAccountReceiptsByCustomerAccountID(customerAccountID);

            if (TheCustomerAccountReceiptList.Count > 0)
            {
                InstallmentAmountPayable = (from ReceiptTotal in TheCustomerAccountReceiptList
                                            select ReceiptTotal.InstallmentAmountPayable).Sum();
            }

            return InstallmentAmountPayable;
        }

        public static int CancelCustomerAccountReceipt(CustomerAccountReceipt theCustomerAccountReceipt)
        {
            return CustomerAccountReceiptDataAccess.GetInstance.CancelCustomerAccountReceipt(theCustomerAccountReceipt);
        }

        public static int InsertCustomerAccountReceipt(CustomerAccountReceipt theCustomerAccountReceipt)
        {
            return CustomerAccountReceiptDataAccess.GetInstance.InsertCustomerAccountReceipt(theCustomerAccountReceipt);
        }
        #endregion
    }
}
