using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class District
    {
        public int DistrictID
        {
            get;
            set;
        }

        public string DistrictName
        {
            get;
            set;

        }

        public int StateID
        {
            get;
            set;
        }

        public string StateName
        {
            get;
            set;
        }

        public string HeadQuarterName
        {
            get;
            set;
        }

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
        public string CountryCode
        {
            get;
            set;
        }
        public bool IsAvailable
        {
            get;
            set;
        }
    }
}
