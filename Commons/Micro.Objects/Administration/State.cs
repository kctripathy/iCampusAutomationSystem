using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class State
    {
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

        public int CountryId
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
