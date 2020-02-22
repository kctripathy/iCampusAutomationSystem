using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class Country
    {
        public int CountryID
        { 
            get; 
            set; 
        }

        public string CountryName
        {
            get;
            set;
        }

		public string CapitalName
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
