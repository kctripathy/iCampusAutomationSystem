using System;

namespace Micro.Objects.FinancialAccounts
{
	[Serializable]
	public class AccountName
	{
		public int AccountID
		{
			get;
			set;
		}

		public string AccountDescription
		{
			get;
			set;
		}

		public int AccountHeadID
		{
			get;
			set;
		}

        public string AccountHeadDescription
        {
            get;
            set;
        }

        public string AccountHeadType
        {
            get;
            set;
        }

        public int ParentAccountHeadID
        {
            get;
            set;
        }

        public string ParentAccountHeadDescription
        {
            get;
            set;
        }

		public int ParentAccountID
		{
			get;
			set;
		}

		public bool IsPrimary
		{
			get;
			set;
		}

		public string AccessType
		{
			get;
			set;
		}

		public string AnalysisFlag
		{
			get;
			set;
		}

		public int DisplayOrder
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
