using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class PaymentsMaturity
	{
		public int MaturityID
		{
			get;
			set;
		}

		public int CustomerAccountID
		{
			get;
			set;
		}

		public string MaturityFormNumber
		{
			get;
			set;
		}

		public string MaturityDate
		{
			get;
			set;
		}

		public string MaturityPaymentDate
		{
			get;
			set;
		}

		public decimal MaturityPrincipalPayable
		{
			get;
			set;
		}

		public decimal MaturityPrincipalPaid
		{
			get;
			set;
		}

		public decimal MaturityInterestPayable
		{
			get;
			set;
		}

		public decimal MaturityInterestPaid
		{
			get;
			set;
		}

		public decimal MaturityBonusPayable
		{
			get;
			set;
		}

		public decimal MaturityBonusPaid
		{
			get;
			set;
		}

		public decimal MaturityPrincipalDeductions
		{
			get;
			set;
		}

		public string MaturityPrincipalDeductionsRemarks
		{
			get;
			set;
		}

		public decimal MaturityTotalPayable
		{
			get;
			set;
		}

		public decimal MaturityTotalPaid
		{
			get;
			set;
		}

		public string MaturityType
		{
			get;
			set;
		}

        public string DeathCertificate
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
