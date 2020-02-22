using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class GuarantorLoanApplication
	{
		public int GuarantorLoanApplicationID
		{
			get;
			set;
		}

		public string LoanAppliedBy
		{
			get;
			set;
		}

		public int LoanApplicantID
		{
			get;
			set;
		}

		public string LoanApplicantName
		{
			get;
			set;
		}

		public string LoanApplicationNumber
		{
			get;
			set;
		}

		public string LoanApplicationDate
		{
			get;
			set;
		}

		public decimal LoanApplicationFee
		{
			get;
			set;
		}

		public string RequiredFor
		{
			get;
			set;
		}

		public decimal LoanAmountApplied
		{
			get;
			set;
		}

		public string ApprovalStatus
		{
			get;
			set;
		}

		public string Remarks
		{
			get;
			set;
		}

		public int OfficeID
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
