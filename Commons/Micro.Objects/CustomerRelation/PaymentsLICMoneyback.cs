using System;

namespace Micro.Objects.CustomerRelation
{
    [Serializable]
    public class PaymentsLICMoneyback
    {
        public int LICMoneyBackID
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
      public string DueDateOfPayment
      {
          get;
          set;
      }
      public decimal MoneyBackPayable
      {
          get;
          set;
      }
      public string MoneyBackDescription
      {
          get;
          set;
      }
      public string ActualDateOfPayment
      {
          get;
          set;
      }
      public decimal ActualMoneyBackAmountPaid
      {
          get;
          set;
      }
      public string PaymentStatus
      {
          get;
          set;
      }
    }

}
