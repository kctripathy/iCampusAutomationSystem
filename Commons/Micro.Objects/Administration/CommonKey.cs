using System;

namespace Micro.Objects.Administration
{
	[Serializable]
	public class CommonKey
	{

		public int CommonKeyID
		{
			get;
			set;
		}

		public string CommonKeyName
		{
			get;
			set;	
		}

		public string CommonKeyValue
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
