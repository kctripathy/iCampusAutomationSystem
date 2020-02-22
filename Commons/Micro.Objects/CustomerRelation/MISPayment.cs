using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class MISPayment
	{
		public int MISPaymentID
		{
			get;
			set;
		}

		public int CustomerAccountID
		{
			get;
			set;
		}

		public string CustomerName
		{
			get;
			set;
		}

		public string MISFirstDueDate
		{
			get;
			set;
		}

		public string MISLastDueDate
		{
			get;
			set;
		}

		public int MISNumberFrom
		{
			get;
			set;
		}

		public int MISNumberTo
		{
			get;
			set;
		}

		public decimal MISPayable
		{
			get;
			set;
		}

		public string MISPaymentDate
		{
			get;
			set;
		}

		public decimal MISPaid
		{
			get;
			set;
		}

		public string MISPaymentMode
		{
			get;
			set;
		}

		public string MISPaymentReference
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
