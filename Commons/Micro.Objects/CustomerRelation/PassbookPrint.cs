using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class PassbookPrint
	{
		public int PassbookPrintID
		{
			get;
			set;
		}

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

		public string PassbookPage
		{
			get;
			set;
		}

		public string PassbookPrintDate
		{
			get;
			set;
		}
	}
}
