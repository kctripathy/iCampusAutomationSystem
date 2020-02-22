using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class CustomerAccountReceipt
	{
		public int ReceiptID
		{
			get;
			set;
		}

		public string ReceiptSeries
		{
			get;
			set;
		}

        public string ReceiptNumber
        {
            get;
            set;
        }

		public string ReceiptDate
		{
			get;
			set;
		}

		public int CustomerAccountID
		{
			get;
			set;
		}

		public string CustomerAccountCode
		{
			get;
			set;
		}

		public string CustomerName
		{
			get;
			set;
		}

		public int PolicyTypeID
		{
			get;
			set;
		}

		public int InstallmentNumberFrom
		{
			get;
			set;
		}

		public int InstallmentNumberTo
		{
			get;
			set;
		}

		public decimal InstallmentAmountPayable
		{
			get;
			set;
		}

		public decimal InstallmentAmountPaid
		{
			get;
			set;

		}

		public decimal AdmissionOrFineAmount
		{
			get;
			set;
		}

		public decimal RebateAmount
		{
			get;
			set;
		}

		public string PaymentMode
		{
			get;
			set;
		}

		public string PaymentReference
		{
			get;
			set;
		}

        public string DueDateOfNextInstallment
        {
            get;
            set;
        }
	
		public string ForMonth
		{
			get;
			set;
		}
		
		public decimal InstallAmount
		{
			get;
			set;
		}
		
		public decimal LedgerBalance
		{
			get;
			set;
		}
		
		public int ScrollID
		{
			get;
			set;
		}

		public int ScrollNumber
		{
			get;
			set;
		}

		public string ScrollDate
		{
			get;
			set;
		}

		public string DepositorName
		{
			get;
			set;
		}

		public int TellerID
		{
			get;
			set;
		}

		public string TellerName
		{
			get;
			set;
		}

		public int OfficeID
		{
			get;
			set;
		}

		public string OfficeName
		{
			get;
			set;
		}

		public int PrintCounter
		{
			get;
			set;
		}

        public bool IsCancelled
        {
            get;
            set;
        }
	}
}
