using System;

namespace Micro.Objects.FinancialAccounts
{
    [Serializable]
    public class AccountRemittance
    {
        public int RemittanceID
        {
            get;
            set;
        }

        public string RemittanceDate
        {
            get;
            set;
        }

        public int RemittancePaidBy
        {
            get;
            set;
        }

        public string RemittancePaidByCode
        {
            get;
            set;
        }

        public string RemittancePaidByName
        {
            get;
            set;
        }

        public int RemittanceReceivedBy
        {
            get;
            set;
        }

        public string RemittanceReceivedByCode
        {
            get;
            set;
        }

        public string RemittanceReceivedByName
        {
            get;
            set;
        }

        public decimal TransactionAmount
        {
            get;
            set;
        }

        public string RemittanceMode
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

        public int BankID
        {
            get;
            set;
        }

        public string BankAccountNo
        {
            get;
            set;
        }

        public bool ReceiptStatus
        {
            get;
            set;
        }

        public string ReceiptDate
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
    }
}
