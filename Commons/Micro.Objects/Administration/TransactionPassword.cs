using System;

namespace Micro.Objects.Administration
{
	[Serializable]
	public class TransactionPassword
	{
		public int TransactionPasswordID
		{
			get;
			set;
		}

		public int EmployeeID
		{
			get;
			set;
		}

		public string TransactionsPassword
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
