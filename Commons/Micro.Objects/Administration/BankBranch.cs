using System;

namespace Micro.Objects.Administration
{
    [Serializable]
    public class BankBranch
    {
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

        public int BankID
        {
            get;
            set;
        }

        public string BranchAddress
        {
            get;
            set;
        }

        public string CityOrTown
        {
            get;
            set;
        }

        public int DistrictID
        {
            get;
            set;
        }

        public string PinCode
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

        public string BankName
        {
            get;
            set;
        }

        public string DistrictName
        {
            get;
            set;

        }
    }
}
