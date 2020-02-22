using System;

namespace Micro.Objects.ICAS.FINANCE
{
    [Serializable]
    public class DefaultFeeSetup
    {
        public int Slno
        {
            get;
            set;
        }
        public int QualID
        {
            get;
            set;
        }
        public string QUALIFICATION
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public string STREAM
        {
            get;
            set;
        }
        public int AccountTypeID
        {
            get;
            set;
        }
        public string ACCOUNT_TYPE
        {
            get;
            set;
        }
        public string ACCOUNT_CODE
        {
            get;
            set;
        }
        public int AccountGroupID
        {
            get;
            set;
        }
        public string ACCOUNT_GROUP
        {
            get;
            set;
        }
        public int AccountID
        {
            get;
            set;
        }
        public string ACCOUNT_NAME
        {
            get;
            set;
        }
        public decimal DefaultFee
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

        public int CompanyID
        {
            get;
            set;
        }
        public int OfficeID
        {
            get;
            set;
        }
    }
}
