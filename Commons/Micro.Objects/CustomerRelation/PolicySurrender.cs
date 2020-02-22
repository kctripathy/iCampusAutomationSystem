using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class PolicySurrender
    {
        public int SurrenderID
        {
            get;
            set;
        }

        public int CustomerAccountID
        {
            get;
            set;
        }

        public string CustomerAccountCode
        {
            get;
            set;
        }

        public string CustomerName
        {
            get;
            set;
        }

        public string SurrenderFormNumber
        {
            get;
            set;
        }

        public string SurrenderDate
        {
            get;
            set;
        }

        public decimal SurrenderPrincipalPayable
        {
            get;
            set;
        }

        public decimal SurrenderPrincipalPaid
        {
            get;
            set;
        }

        public decimal SurrenderInterestPayable
        {
            get;
            set;
        }

        public decimal SurrenderInterestPaid
        {
            get;
            set;
        }

        public decimal SurrenderBonusPayable
        {
            get;
            set;
        }

        public decimal SurrenderBonusPaid
        {
            get;
            set;
        }

        public decimal SurrenderPrincipalDeductions
        {
            get;
            set;
        }

        public string SurrenderPrincipalDeductionsRemarks
        {
            get;
            set;
        }

        public decimal SurrenderTotalPayable
        {
            get;
            set;
        }

        public decimal SurrenderTotalPaid
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
//, , , , , , , , , , , , , , , DateAdded, AddedBy, DateModified, ModifiedBy