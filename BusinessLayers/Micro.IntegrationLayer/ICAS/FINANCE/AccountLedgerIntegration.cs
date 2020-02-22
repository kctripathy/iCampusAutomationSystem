using System;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.ICAS.FINANCE;
using Micro.Objects;

namespace Micro.IntegrationLayer.ICAS.FINANCE
{
    public partial class AccountLedgerIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static AccountLedger DataRowToObject(DataRow dr)
        {
            AccountLedger TheAccountLedger = new AccountLedger();
            TheAccountLedger.AccountLedgerID = int.Parse(dr["AccountLedgerID"].ToString());
            TheAccountLedger.AccountLedgerDescription = (dr["AccountLedgerDescription"].ToString());
            TheAccountLedger.AccountLedgerAlias = (dr["AccountLedgerAlias"].ToString());
            TheAccountLedger.AccountGroupID = int.Parse(dr["AccountGroupID"].ToString());
            TheAccountLedger.AccountGroupDescription = (dr["AccountGroupDescription"].ToString());

            return TheAccountLedger;
        }

        public static AccountLedger GetAccountLedgerByID(int accountLedgerID)
        {
            DataRow AccountLedgerRow = AccountLedgerDataAccess.GetInstance.GetAccountLedgerByID(accountLedgerID);

            AccountLedger TheAccountLedger = DataRowToObject(AccountLedgerRow);

            return TheAccountLedger;
        }

        public static List<AccountLedger> GetAccountLedgerList(String searchText)
        {
            List<AccountLedger> AccountLedgerList = new List<AccountLedger>();
            DataTable AccountLedgerTable = new DataTable();
            AccountLedgerTable = AccountLedgerDataAccess.GetInstance.GetAccountLedgerList(searchText);

            foreach (DataRow dr in AccountLedgerTable.Rows)
            {
                AccountLedger TheAccountLedger = DataRowToObject(dr);

                AccountLedgerList.Add(TheAccountLedger);
            }

            return AccountLedgerList;

        }

        public static List<AccountLedger> GetNonCaseAccountLedgerList(bool allOffices = false, bool showDeleted = false)
        {
            List<AccountLedger> AccountLedgerList = new List<AccountLedger>();
            DataTable AccountLedgerTable = new DataTable();
            AccountLedgerTable = AccountLedgerDataAccess.GetInstance.GetNonCaseAccountLedgerList(allOffices, showDeleted);

            foreach (DataRow dr in AccountLedgerTable.Rows)
            {
                AccountLedger TheAccountLedger = DataRowToObject(dr);

                AccountLedgerList.Add(TheAccountLedger);
            }

            return AccountLedgerList;
        }

        public static List<AccountLedger> GetBankLedgerList(bool allOffices = false, bool showDeleted = false)
        {
            List<AccountLedger> AccountLedgerList = new List<AccountLedger>();
            DataTable AccountLedgerTable = new DataTable();
            AccountLedgerTable = AccountLedgerDataAccess.GetInstance.GetBankLedgerList(allOffices, showDeleted);

            foreach (DataRow dr in AccountLedgerTable.Rows)
            {
                AccountLedger TheAccountLedger = DataRowToObject(dr);

                AccountLedgerList.Add(TheAccountLedger);
            }

            return AccountLedgerList;
        }

        public static int InsertAccountLedger(AccountLedger theAccountLedger)
        {
            return AccountLedgerDataAccess.GetInstance.InsertAccountLedger(theAccountLedger);
        }

        public static int UpdateAccountLedger(AccountLedger theAccountLedger)
        {
            return AccountLedgerDataAccess.GetInstance.UpdateAccountLedger(theAccountLedger);
        }

        public static int DeleteAccountLedger(AccountLedger theAccountLedger)
        {
            return AccountLedgerDataAccess.GetInstance.DeleteAccountLedger(theAccountLedger);
        }
        #endregion
    }
}
