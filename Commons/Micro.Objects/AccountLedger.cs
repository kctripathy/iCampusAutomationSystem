using System;

namespace Micro.Objects
{
    [Serializable]
    public class AccountLedger
    {
        public int AccountLedgerID
        {
            get;
            set;
        }

        public string AccountLedgerDescription
        {
            get;
            set;
        }

        public string AccountLedgerAlias
        {
            get;
            set;
        }

        public string AccountGroupDescription
        {
            get;
            set;
        }

        public int AccountGroupID
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
