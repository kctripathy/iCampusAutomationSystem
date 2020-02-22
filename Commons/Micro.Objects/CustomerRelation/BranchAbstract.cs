using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class BranchAbstract
    {
        public decimal BusinessNew
        {
            get;
            set;
        }
        public decimal BusinessRenew
        {
            get;
            set;
        }
        public decimal BusinessOneTime
        {
            get;
            set;
        }
        public decimal PaymentLoan
        {
            get;
            set;
        }
        public decimal RecoveryLoan
        {
            get;
            set;
        }
        public decimal PaymentMaturity
        {
            get;
            set;
        }
        public string DateOfTransaction
        {
            get;
            set;
        }
        public string OfficeTypeAbbreviation
        {
            get;
            set;
        }
        public string OfficeTypeDescription
        {
            get;
            set;
        }
        public int OfficeTypeID
        {
            get;
            set;
        }
        public string OfficeName
        {
            get;
            set;
        }
        public string OfficeCode
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
