using System;

namespace Micro.Objects.ICAS.FINANCE
{    
    [Serializable]
    public class AccountTransaction
    {
        public int TransactionID
        {
            get;
            set;
        }

        public string TransactionCode
        {
            get;
            set;
        }

        public string TransactionDate
        {
            get;
            set;
        }
        public string TransactionToCategory
        {
            get;
            set;
        }
        public string TransactionToID
        {
            get;
            set;
        }
        public string ThirdPartyDescription
        {
            get;
            set;
        } 
        public int AccountID
        {
            get;
            set;
        }

        public string AccountDescription
        {
            get;
            set;
        }

        public int AccountHeadID
        {
            get;
            set;
        }

        public string AccountHeadDescription
        {
            get;
            set;
        }

        public string AccountHeadType
        {
            get;
            set;
        }

        public int ParentAccountHeadID
        {
            get;
            set;
        }

        public string ParentAccountHeadDescription
        {
            get;
            set;
        }

        public int ParentAccountID
        {
            get;
            set;
        }

        public bool IsPrimary
        {
            get;
            set;
        }

        public string AccessType
        {
            get;
            set;
        }

        public string AnalysisFlag
        {
            get;
            set;
        }

        public int DisplayOrder
        {
            get;
            set;
        }        
        public decimal TransactionAmount
        {
            get;
            set;
        }

        public string TransactionMode
        {
            get;
            set;
        }
        public int AutoReferenceID
        {
            get;
            set;
        }
        public string BankName
        {
            get;
            set;
        }

        public string ChqDate
        {
            get;
            set;
        }

        public string ChqNumber
        {
            get;
            set;
        }        
        public string TransactionReference
        {
            get;
            set;
        }

        public string EntrySide
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public int OfficeID
        {
            get;
            set;
        }

        public string OfficeName
        {
            get;
            set;
        }

        public int CompanyID
        {
            get;
            set;
        }

        public string CompanyName
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
        public int AddedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public string DateAdded
        {
            get;
            set;
        }
        public string DateModified
        {
            get;
            set;
        }        
    }
}
