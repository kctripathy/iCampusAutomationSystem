using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class RenewalReceipt
    {
        public int ReceiptID
        {
            get;
            set;
        }

        public string ReceiptSeries
        {
            get;
            set;
        }

        public string ReceiptDate
        {
            get;
            set;
        }

        public int CustomerAccountID
        {
            get;
            set;
        }

         public int PolicyTypeID
        {
            get;
            set;
        }

        public int InstallmentNumberFrom
        {
            get;
            set;
        }

         public int InstallmentNumberTo
        {
            get;
            set;
        }

        public decimal InstallmentAmountPayable
        {
            get;
            set;
        }

        public decimal AdmissionOrFineAmount
        {
            get;
            set;
        }

        public decimal InstallmentAmountPaid
        {
            get;
            set;
        }

        public decimal RebateAmount
        {
            get;
            set;
        }

         public string PaymentMode
        {
            get;
            set;
        }

        public string PaymentReference
        {
            get;
            set;
        }

          public int ScrollID
        {
            get;
            set;
        }

         public int TellerID
        {
            get;
            set;
        }

        public int OfficeID
        {
            get;
            set;
        }

          public int PrintCounter
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

         public string CustomerName
         {
             get;
             set;
         }

         public string PolicyName
         {
             get;
             set;
         }

    }
}
