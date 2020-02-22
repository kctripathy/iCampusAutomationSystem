using System;

namespace Micro.Objects.ICAS.FINANCE
{
    [Serializable]
    public class AccountMaster
    {
        public int AccountID
        {
            get;
            set;
        }
        public string AccountCode
        {
            get;
            set;
        }
        public string AccountDescription
        {
            get;
            set;
        }

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



        //public int AccountParentGroupID
        //{
        //    get;
        //    set;
        //}
        public int AccountGroupParentID
        {
            get;
            set;
        }
        public int AccountParentGroupDesc
        {
            get;
            set;
        }

        //public int ParentAccountID
        //{
        //    get;
        //    set;
        //}

        //public bool IsPrimary
        //{
        //    get;
        //    set;
        //}

        //public string AccessType
        //{
        //    get;
        //    set;
        //}

        //public string AnalysisFlag
        //{
        //    get;
        //    set;
        //}

        public int DisplayOrder
        {
            get;
            set;
        }

        public string AccountLedgerType
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

        public int SocietyID
        {
            get;
            set;
        }
    }
}
