using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;
using System;

namespace Micro.IntegrationLayer.ICAS.FINANCE
{
    public partial class AccountTransactionIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static AccountTransaction DataRowToObject(DataRow dr)
        {
            AccountTransaction TheAccountTransaction = new AccountTransaction
            {
                TransactionID = int.Parse(dr["TransactionID"].ToString()),
                TransactionCode = dr["TransactionCode"].ToString(),
                TransactionDate = DateTime.Parse(dr["TransactionDate"].ToString()).ToString(MicroConstants.DateFormat),
                AccountID = int.Parse(dr["AccountID"].ToString()),
                //AccountDescription = dr["AccountDescription"].ToString(),
                AccountHeadID = int.Parse(dr["AccountHeadID"].ToString()),
                AccountHeadDescription = dr["AccountHeadDescription"].ToString(),
                AccountHeadType = dr["AccountHeadType"].ToString(),
                ParentAccountHeadID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ParentAccountHeadID"].ToString())),
                //ParentAccountHeadDescription = dr["ParentAccountHeadDescription"].ToString(),
                //ParentAccountID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ParentAccountID"].ToString())),
                IsPrimary = bool.Parse(dr["IsPrimary"].ToString()),
                //AccessType = dr["AccessType"].ToString(),
                //AnalysisFlag = dr["AnalysisFlag"].ToString(),
                //DisplayOrder = int.Parse(dr["DisplayOrder"].ToString()),
                TransactionToID=dr["TransactionToID"].ToString(),
                TransactionToCategory=dr["TransactionToCategory"].ToString(),
                ThirdPartyDescription = dr["ThirdPartyDescription"].ToString(),
                TransactionAmount = decimal.Parse(dr["TransactionAmount"].ToString()),
                TransactionMode = dr["TransactionMode"].ToString(),
                TransactionReference = dr["TransactionReference"].ToString(),
                EntrySide = dr["EntrySide"].ToString(),
                Remarks = dr["Remarks"].ToString(),
                OfficeID = int.Parse(dr["OfficeID"].ToString()),
                OfficeName = dr["OfficeName"].ToString(),
                CompanyID = int.Parse(dr["CompanyID"].ToString()),
                CompanyName = dr["CompanyName"].ToString()
            };

            return TheAccountTransaction;
        }

        public static List<AccountTransaction> GetAccountTransactionList(bool allOffices = false, bool showDeleted = false)
        {
            List<AccountTransaction> AccountTransactionList = new List<AccountTransaction>();

            DataTable GetAccountTransactionTable = AccountTransactionDataAccess.GetInstance.GetAccountTransactionList(allOffices, showDeleted);

            foreach (DataRow dr in GetAccountTransactionTable.Rows)
            {
                AccountTransaction TheAccountTransaction = DataRowToObject(dr);
                AccountTransactionList.Add(TheAccountTransaction);
            }

            return AccountTransactionList;
        }

        public static List<AccountTransaction> GetAccountTransactionListByDate(string transactionDate, bool allOffices = false, bool showDeleted = false)
        {
            List<AccountTransaction> AccountTransactionList = new List<AccountTransaction>();

            DataTable GetAccountTransactionTable = AccountTransactionDataAccess.GetInstance.GetAccountTransactionListByDate(transactionDate, allOffices, showDeleted);

            foreach (DataRow dr in GetAccountTransactionTable.Rows)
            {
                AccountTransaction TheAccountTransaction = DataRowToObject(dr);
                AccountTransactionList.Add(TheAccountTransaction);
            }

            return AccountTransactionList;
        }

        public static AccountTransaction GetAccountTransactionByID(int transactionID)
        {
            AccountTransaction TheAccountTransaction;
            DataRow AccountTransactionRow = AccountTransactionDataAccess.GetInstance.GetAccountTransactionByID(transactionID);

            if (AccountTransactionRow != null)
                TheAccountTransaction = DataRowToObject(AccountTransactionRow);
            else
                TheAccountTransaction = new AccountTransaction();

            return TheAccountTransaction;
        }

        public static decimal GetCashBalances()
        {
            DataRow OpeningBalanceRow = AccountTransactionDataAccess.GetInstance.GetCashBalances();
            decimal ReturnValue = -1;

            if (OpeningBalanceRow != null)
                if (!string.IsNullOrEmpty(OpeningBalanceRow["ClosingBalance"].ToString()))
                    ReturnValue = decimal.Parse(OpeningBalanceRow["ClosingBalance"].ToString());

            return ReturnValue;
        }

        public static int InsertAccountTransaction(AccountTransaction theAccountTransaction)
        {
            return AccountTransactionDataAccess.GetInstance.InsertAccountTransaction(theAccountTransaction);
        }

        public static int DeleteAccountTransaction(AccountTransaction theAccountTransaction, int Record)
        {
            return AccountTransactionDataAccess.GetInstance.DeleteAccountTransaction(theAccountTransaction, Record);
        }
        #endregion
    }
}
