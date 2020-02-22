using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class FieldForceChain
	{
		public int FieldForceChainID
		{
			get;
			set;
		}

		public int FieldForceID
		{
			get;
			set;
		}

		public string FieldForceCode
		{
			get;
			set;
		}

		public string FieldForceName
		{
			get;
			set;
		}

		public int FieldForceRankID
		{
			get;
			set;
		}

		public string FieldForceRankName
		{
			get;
			set;
		}

		public string FieldForceRankDescription
		{
			get;
			set;
		}

		public int ReportingToFieldForceID
		{
			get;
			set;
		}

		public string ReportingToFieldForceCode
		{
			get;
			set;
		}

		public string ReportingToFieldForceName
		{
			get;
			set;
		}

		public int ReportingToRankID
		{
			get;
			set;
		}

		public string ReportingToRankName
		{
			get;
			set;
		}

		public string ReportingToRankDescription
		{
			get;
			set;
		}

		public string ChainCode
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

		public string EffectiveDateFrom
		{
			get;
			set;
		}

		public string EffectiveDateTo
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
