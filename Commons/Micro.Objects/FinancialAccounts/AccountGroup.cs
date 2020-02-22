using System;

namespace Micro.Objects.FinancialAccounts
{
    [Serializable]
    public class AccountGroup
    {
        public int AccountGroupID
        {
            get;
            set;
        }

        public string AccountGroupDescription
        {
            get;
            set;
        }

        public string AccountGroupAlias
        {
            get;
            set;
        }

        public int AccountGroupParentID
        {
            get;
            set;
        }

        public string AccountGroupNature
        {
            get;
            set;
        }
        public bool IsUserDefined
        {
            get;
            set;
        }

        public string PrimaryGroupDescription
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
