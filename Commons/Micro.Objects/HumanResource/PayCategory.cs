using System;

namespace Micro.Objects.HumanResource
{
	[Serializable]
	public class PayCategory
	{
		public int PayCategoryID
		{
			get;
			set;
		}

		public string PayCategoryDescription
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
