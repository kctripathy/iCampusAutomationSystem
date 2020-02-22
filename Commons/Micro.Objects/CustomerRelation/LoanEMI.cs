using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class LoanEMI
	{
		public int EMINumber
		{
			get;
			set;
		}

		public decimal EMIAmount
		{
			get;
			set;
		}

		public decimal InterestAmount
		{
			get;
			set;
		}

		public decimal PrincipalReduction
		{
			get;
			set;
		}

		public decimal BalanceDue
		{
			get;
			set;
		}

		public decimal TotalPrincipalPayable
		{
			get;
			set;
		}

		public decimal TotalInterestPayable
		{
			get;
			set;
		}

		public decimal TotalPayable
		{
			get;
			set;
		}

		public decimal RoundOff
		{
			get;
			set;
		}
	}
}
