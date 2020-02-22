using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class Passbook
	{
		public int PassbookID
		{
			get;
			set;
		}

		public string PassbookCode
		{
			get;
			set;
		}
        public string PassBookType
        {
            get;
            set;
        }
		public int PassbookTypeReferenceID
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

		public string PassbookIssueDate
		{
			get;
			set;
		}

		public bool CoverPageState
		{
			get;
			set;
		}

		public bool FirstPageState
		{
			get;
			set;
		}

		public int PrintPosition
		{
			get;
			set;
		}

	}
}
