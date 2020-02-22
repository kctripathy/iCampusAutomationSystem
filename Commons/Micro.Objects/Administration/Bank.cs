using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class Bank
    {
        public int BankID
        {
            get;
            set;
        }

        public string BankName
        {
            get;
            set;
        }

        public int BankBranchID
        {
            get;
            set;
        }

        public string BranchName
        {
            get;
            set;
        }

        public string CityOrTown
        {
            get;
            set;
        }

        public string DateAdded
        {
            get;
            set;
        }

        public int AddedBy
        {
            get;
            set;
        }

        public string DateModified
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }
    }
}
