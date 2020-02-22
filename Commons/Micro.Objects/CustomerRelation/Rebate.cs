using System;

namespace Micro.Objects.CustomerRelation
{
	/// <summary>
	/// Manages Rebate on each Customer Account Receipts
	/// </summary>
	/// <author> Syed Ameer </author>
	/// <date> 05-Mar-2012 </date>

	[Serializable]
	public class Rebate
	{
		public int RebateID
		{
			get;
			set;
		}

		public int PolicyTypeID
		{
			get;
			set;
		}

		public string PolicyName
		{
			get;
			set;
		}

		public string InstallmentMode
		{
			get;
			set;
		}

		public decimal RebatePer
		{
			get;
			set;
		}

		public decimal RebateValue
		{
			get;
			set;
		}

		public string EffectiveDateFrom
		{
			get;
			set;
		}

		public int RebateOfficewiseID
		{
			get;
			set;
		}

		public int OfficeID
		{
			get;
			set;
		}
        public string PolicyTypeDescription
        {
            get;
            set;
        }
	}
}
