using System;

namespace Micro.Objects.ICAS.FINANCE
{
	[Serializable]
	public class AccountHead
	{
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
		
        public bool IsPrimary
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
