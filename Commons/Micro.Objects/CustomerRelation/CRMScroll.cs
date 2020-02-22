using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class CRMScroll
	{
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

		public String ScrollDate
		{
			get;
			set;
		}

		public string DepositorName
		{
			get;
			set;
		}

		public decimal ScrollAmountPayable
		{
			get;
			set;
		}

		public decimal ScrollAmountPaid
		{
			get;
			set;
		}

		public string ScrollStatus
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
	}
}
