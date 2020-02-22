using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class AccountsRevival
	{
		public int RevivalID
		{
			get;
			set;
		}

		public string RevivalDate
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

		public int RevivedFromInstallmentNumber
		{
			get;
			set;
		}

		public int TotalInstallmentsRevived
		{
			get;
			set;
		}

		public string DueDateOfLastPayment
		{
			get;
			set;
		}

		public string DueDateOfMaturity
		{
			get;
			set;
		}

		public decimal PayToCompany
		{
			get;
			set;
		}

		public decimal GuaranteedDividend
		{
			get;
			set;
		}

		public decimal BonusAmount
		{
			get;
			set;
		}

		public decimal PayByCompany
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public bool IsDeleted
		{
			get;
			set;
		}
	}
}
