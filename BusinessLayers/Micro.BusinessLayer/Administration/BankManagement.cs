using System.Collections.Generic;
using Micro.Objects.Administration;
using Micro.IntegrationLayer.Administration;

namespace Micro.BusinessLayer.Administration
{
  public partial class BankManagement
  {
      #region Declaration
      #endregion

      #region Code to make this as Singleton Class
      /// <summary>
        /// Declare a private static variable
        /// </summary>
      private static BankManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
      public static BankManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BankManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

      #region Methods & Implementation
      public List<Bank> GetAllBanks(string SearchText)
      {
          return BankIntegration.GetAllBanks(SearchText);
      }

      public Bank GetBankByBankId(int BankID)
      {
          return BankIntegration.GetBankByBankId(BankID);
      }

      public int InsertBank(Bank theBank)
      {
          return BankIntegration.InsertBank(theBank);
      }
      public int UpdateBank(Bank theBank)
      {
          return BankIntegration.UpdateBank(theBank);
      }
      public int DeleteBank(Bank theBank)
      {
          return BankIntegration.DeleteBank(theBank);
      }

      #endregion

  }
}
