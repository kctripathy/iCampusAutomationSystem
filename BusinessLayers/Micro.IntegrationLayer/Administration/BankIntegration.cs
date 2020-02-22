using System;
using System.Collections.Generic;
using Micro.Objects.Administration;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.Administration;

namespace Micro.IntegrationLayer.Administration
{
  public partial  class BankIntegration
  {
      #region Declaration
      #endregion

      #region Methods & Implementation
      public static Bank DataRowToObject(DataRow dr)
      {
          Bank TheBank = new Bank();
          TheBank.BankID = int.Parse(dr["BankID"].ToString());
          TheBank.BankName = dr["BankName"].ToString();
          TheBank.AddedBy = int.Parse(dr["AddedBy"].ToString());
          TheBank.DateAdded = DateTime.Parse(dr["DateAdded"].ToString()).ToString(MicroConstants.DateFormat);

          return TheBank;
      }

      public static List<Bank> GetAllBanks(string SearchText)
      {
          List<Bank> BankList = new List<Bank>();

          DataTable BankTable = new DataTable();
          BankTable = BankDataAccess.GetInstance.GetAllBanks(SearchText);

          foreach (DataRow dr in BankTable.Rows)
          {
              Bank TheBank = DataRowToObject(dr);

              BankList.Add(TheBank);
          }

          return BankList;
      }

      public static Bank GetBankByBankId(int BankID)
      {
          DataRow BankRow = BankDataAccess.GetInstance.GetBankByBankId(BankID);

          Bank TheBank = DataRowToObject(BankRow);

          return TheBank;
      }

      public static int InsertBank(Bank theBank)
      {
          return BankDataAccess.GetInstance.InsertBank(theBank);
      }

      public static int UpdateBank(Bank theBank)
      {
          return BankDataAccess.GetInstance.UpdateBank(theBank);
      }

      public static int DeleteBank(Bank theBank)
      {
          return BankDataAccess.GetInstance.DeleteBank(theBank);
      }

      #endregion

  }
}
