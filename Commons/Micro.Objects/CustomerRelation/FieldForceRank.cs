using System;

namespace Micro.Objects.CustomerRelation
{
	[Serializable]
	public class FieldForceRank
	{
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

		public int HierarchyIndex
		{
			get;
			set;
		}

		public string FieldForceAbbrText
		{
			get;
			set;
		}

		public int NumberOfDigitsInCode
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
