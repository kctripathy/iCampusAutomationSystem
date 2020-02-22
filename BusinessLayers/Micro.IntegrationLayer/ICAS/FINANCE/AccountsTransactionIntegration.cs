using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.DataAccessLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;
using Micro.Commons;

namespace Micro.IntegrationLayer.ICAS.FINANCE
{
    public partial class AccountsTransactionIntegration
    {
        #region Methods & Implementation
        public static Accounts_DailyTransactions DataRowToObject(DataRow dr)
        {
            Accounts_DailyTransactions TheAccounts_DailyTransactions = new Accounts_DailyTransactions();
            TheAccounts_DailyTransactions.VoucherNumber = dr["VoucherNumber"].ToString();
            TheAccounts_DailyTransactions.TranDate = dr["TranDate"].ToString();
            TheAccounts_DailyTransactions.TranNumber = int.Parse(dr["TranNumber"].ToString());
            TheAccounts_DailyTransactions.SerialNumber = int.Parse(dr["SerialNumber"].ToString());
            TheAccounts_DailyTransactions.AccountsID = int.Parse(dr["AccountsID"].ToString());
            TheAccounts_DailyTransactions.AccountCode = dr["AccountCode"].ToString();
            TheAccounts_DailyTransactions.TranType = dr["TranType"].ToString();
            TheAccounts_DailyTransactions.TranAmount = decimal.Parse(dr["TranAmount"].ToString());
            TheAccounts_DailyTransactions.BalanceType = dr["BalanceType"].ToString();
            TheAccounts_DailyTransactions.Narration = dr["Narration"].ToString();
            TheAccounts_DailyTransactions.IsPosted = dr["IsPosted"].ToString();
            TheAccounts_DailyTransactions.PostedBy = int.Parse(dr["PostedBy"].ToString());
            TheAccounts_DailyTransactions.PostedDate = dr["PostedDate"].ToString();
            TheAccounts_DailyTransactions.PostMode = dr["PostMode"].ToString();
            TheAccounts_DailyTransactions.AccountsYearID = int.Parse(dr["AccountsYearID"].ToString());
            TheAccounts_DailyTransactions.OfficeID = int.Parse(dr["OfficeID"].ToString());
            TheAccounts_DailyTransactions.SocietyID = int.Parse(dr["SocietyID"].ToString());

            return TheAccounts_DailyTransactions;
        }

        public static CashBook CashAndBankBookDataRowToObject(DataRow dr)
        {
            CashBook theTransation = new CashBook();

            theTransation.TranNumber = int.Parse(dr["TranNumber"].ToString());
            theTransation.TranDate = DateTime.Parse(dr["TranDate"].ToString()).ToString(MicroConstants.DateFormat);
            theTransation.AccountsID = int.Parse(dr["AccountsID"].ToString());
            theTransation.AccountsCode = dr["AccountsCode"].ToString();
            theTransation.AccountDescription = dr["AccountDescription"].ToString();
            theTransation.Narration = dr["Narration"].ToString();
            theTransation.BalanceType = dr["BalanceType"].ToString();

            if (theTransation.BalanceType.ToUpper().Equals("DB"))
            {
                theTransation.BalanceType = "DR";
                theTransation.DRAmount = Decimal.Parse(dr["TranAmount"].ToString());
                theTransation.CRAmount = Decimal.Parse("0.0");
            }
            else if (theTransation.BalanceType.ToUpper().Equals("CR"))
            {
                theTransation.DRAmount = Decimal.Parse("0.0");
                theTransation.CRAmount = Decimal.Parse(dr["TranAmount"].ToString());
            }

            theTransation.PostedBy = (dr["PostedBy"] == DBNull.Value ? 0 : int.Parse(dr["PostedBy"].ToString()));
            theTransation.PostedDate = (dr["PostedDate"] == null ? "-" : dr["PostedDate"].ToString());
            theTransation.OfficeID = dr["OfficeID"] != DBNull.Value ? int.Parse(dr["OfficeID"].ToString()) : 0;
            theTransation.SocietyID = dr["SocietyID"] != DBNull.Value ? int.Parse(dr["SocietyID"].ToString()) : 0;

            return theTransation;
        }

        public static CurrentSavingAccountTransaction CurrentSavingAccountTransactionDataRowToObject(DataRow dr)
        {
            CurrentSavingAccountTransaction theCurrentSavingAccountTransaction = new CurrentSavingAccountTransaction();

            theCurrentSavingAccountTransaction.Particulars = dr["Particulars"].ToString();
            theCurrentSavingAccountTransaction.DateOfTransaction = DateTime.Parse(dr["DateOfTransaction"].ToString()).ToString(MicroConstants.DateFormat);
            theCurrentSavingAccountTransaction.Particulars = dr["Particulars"].ToString();
            theCurrentSavingAccountTransaction.CreditAmount = decimal.Parse(dr["CreditAmount"].ToString());
            theCurrentSavingAccountTransaction.DebitAmount = decimal.Parse(dr["DebitAmount"].ToString());
            theCurrentSavingAccountTransaction.ChallanNo = dr["ChallanNo"].ToString();
            theCurrentSavingAccountTransaction.TotalBalance = decimal.Parse(dr["TotalBalance"].ToString());


            return theCurrentSavingAccountTransaction;
        }

        public static int InsertAccountsDailyTransactions(Accounts_DailyTransactions theAccountsDailyTransactions)
        {
            return AccountsTransactionsDataAccess.GetInstance.InsertAccountsDailyTransactions(theAccountsDailyTransactions);
        }

        public static List<Voucher_BatchPosting> GetValidTransactionsList()
        {
            List<Voucher_BatchPosting> theAccounts_DailyTransactionsList = new List<Voucher_BatchPosting>();
            DataTable Accounts_DailyTransactionstable = AccountsTransactionsDataAccess.GetInstance.GetValidTransactionsList();


            foreach (DataRow dr in Accounts_DailyTransactionstable.Rows)
            {
                Voucher_BatchPosting TheAccounts_DailyTransactions = new Voucher_BatchPosting();

                TheAccounts_DailyTransactions.TranDate = dr["TRAN. DATE"].ToString();
                TheAccounts_DailyTransactions.TranNumber = int.Parse(dr["TRAN. NO."].ToString());
                TheAccounts_DailyTransactions.SerialNumber = int.Parse(dr["SL. NO."].ToString());
                TheAccounts_DailyTransactions.AccountsID = int.Parse(dr["ACC. ID"].ToString());
                TheAccounts_DailyTransactions.AccountCode = dr["ACC. CODE"].ToString();
                TheAccounts_DailyTransactions.AccountDescription = dr["ACC. DESC"].ToString();
                TheAccounts_DailyTransactions.TranType = dr["TRAN. TYPE"].ToString();
                TheAccounts_DailyTransactions.TranAmount = decimal.Parse(dr["TRAN. AMOUNT"].ToString());
                TheAccounts_DailyTransactions.BalanceType = dr["DR./CR."].ToString();
                TheAccounts_DailyTransactions.Narration = dr["ACC. NARRATION"].ToString();

                TheAccounts_DailyTransactions.IsPosted = dr["IsPosted"] != DBNull.Value ? dr["IsPosted"].ToString() : "";
                TheAccounts_DailyTransactions.PostedBy = dr["PostedByUserID"] != DBNull.Value ? int.Parse(dr["PostedByUserID"].ToString()) : 0;
                TheAccounts_DailyTransactions.PostedDate = dr["DateOfPosting"].ToString();
                TheAccounts_DailyTransactions.PostMode = dr["ModeOfPosting"].ToString();


                TheAccounts_DailyTransactions.ACC_YEAR_ID = int.Parse(dr["ACC. YEAR ID"].ToString());
                TheAccounts_DailyTransactions.ACC_YEAR_CODE = dr["ACC. YEAR CODE"].ToString();
                TheAccounts_DailyTransactions.CURRENT_START_DATE = dr["YEAR START DT."].ToString();
                TheAccounts_DailyTransactions.CURRENT_END_DATE = dr["YEAR CLOSE DT."].ToString();
                //TheAccounts_DailyTransactions.PREVIOUS_START_DATE = dr["PREVIOUS_START_DATE"].ToString();
                //TheAccounts_DailyTransactions.PREVIOUS_END_DATE = dr["PREVIOUS_END_DATE"].ToString();
                //TheAccounts_DailyTransactions.BOOK_CLOSING_FLAG = dr["BOOK_CLOSING_FLAG"].ToString();
                //TheAccounts_DailyTransactions.YEAR_CLOSING_FLAG = dr["YEAR_CLOSING_FLAG"].ToString();
                //TheAccounts_DailyTransactions.STATUS_FLAG = dr["STATUS_FLAG"].ToString();
                //TheAccounts_DailyTransactions.MOD_DATE = dr["MOD_DATE"].ToString();
                //TheAccounts_DailyTransactions.AUTH_CODE = dr["AUTH_CODE"].ToString();

                //TheAccounts_DailyTransactions.AccountGroupID = int.Parse(dr["AccountGroupID"].ToString());
                TheAccounts_DailyTransactions.AccountGroupDescription = dr["GROUP-NAME"].ToString();

                TheAccounts_DailyTransactions.OfficeTypeID = int.Parse(dr["Office Type id"].ToString());
                TheAccounts_DailyTransactions.OfficeTypeName = dr["Type of Office"].ToString();
                TheAccounts_DailyTransactions.OfficeID = int.Parse(dr["Office ID"].ToString());
                TheAccounts_DailyTransactions.OfficeName = dr["Name Of The Office"].ToString();
                TheAccounts_DailyTransactions.OfficeCode = dr["Office Code"].ToString();
                TheAccounts_DailyTransactions.SocietyID = int.Parse(dr["SOCIETY ID"].ToString());
                TheAccounts_DailyTransactions.SocietyName = dr["SOCIETY NAME"].ToString();
                TheAccounts_DailyTransactions.SocietyAliasName = dr["SOCIETY ALIAS"].ToString();
                TheAccounts_DailyTransactions.SocietyCode = dr["SOCIETY CODE"].ToString();

                theAccounts_DailyTransactionsList.Add(TheAccounts_DailyTransactions);
            }
            return theAccounts_DailyTransactionsList;
        }

        public static List<Voucher2Post> GetValidTransactions()
        {
            List<Voucher2Post> TheVoucher2PostList = new List<Voucher2Post>();
            DataTable TheVoucher2PostDataTable = AccountsTransactionsDataAccess.GetInstance.GetValidTransactionsList();


            foreach (DataRow dr in TheVoucher2PostDataTable.Rows)
            {
                Voucher2Post TheVoucher2Post = new Voucher2Post();

                TheVoucher2Post.TranDate = dr["TRAN. DATE"].ToString();
                TheVoucher2Post.TranNumber = int.Parse(dr["TRAN. NO."].ToString());
                TheVoucher2Post.SerialNumber = int.Parse(dr["SL. NO."].ToString());
                TheVoucher2Post.AccountsID = int.Parse(dr["ACC. ID"].ToString());
                TheVoucher2Post.AccountCode = dr["ACC. CODE"].ToString();
                TheVoucher2Post.AccountDescription = dr["ACC. DESC"].ToString();
                TheVoucher2Post.TranType = dr["TRAN. TYPE"].ToString();
                TheVoucher2Post.TranAmount = decimal.Parse(dr["TRAN. AMOUNT"].ToString());
                TheVoucher2Post.BalanceType = dr["DR./CR."].ToString();
                TheVoucher2Post.Narration = dr["ACC. NARRATION"].ToString();
                if (dr["IsPosted"] != DBNull.Value)
                {
                    TheVoucher2Post.IsPosted = dr["IsPosted"].ToString();
                }
                else
                {
                    TheVoucher2Post.IsPosted = "";
                }
                if (dr["PostedByUserID"] != DBNull.Value)
                {
                    TheVoucher2Post.PostedBy = int.Parse(dr["PostedByUserID"].ToString());
                }
                else
                {
                    TheVoucher2Post.PostedBy = Micro.Commons.Connection.LoggedOnUser.UserID;
                }
                if (dr["DateOfPosting"] != DBNull.Value)
                {
                    TheVoucher2Post.PostedDate = dr["DateOfPosting"].ToString();
                }
                else
                {
                    TheVoucher2Post.PostedDate = dr["TRAN. DATE"].ToString();
                }
                TheVoucher2Post.PostMode = dr["ModeOfPosting"].ToString();


                TheVoucher2Post.ACC_YEAR_ID = int.Parse(dr["ACC. YEAR ID"].ToString());
                TheVoucher2Post.ACC_YEAR_CODE = dr["ACC. YEAR CODE"].ToString();
                TheVoucher2Post.CURRENT_START_DATE = dr["YEAR START DT."].ToString();
                TheVoucher2Post.CURRENT_END_DATE = dr["YEAR CLOSE DT."].ToString();
                //TheAccounts_DailyTransactions.PREVIOUS_START_DATE = dr["PREVIOUS_START_DATE"].ToString();
                //TheAccounts_DailyTransactions.PREVIOUS_END_DATE = dr["PREVIOUS_END_DATE"].ToString();
                //TheAccounts_DailyTransactions.BOOK_CLOSING_FLAG = dr["BOOK_CLOSING_FLAG"].ToString();
                //TheAccounts_DailyTransactions.YEAR_CLOSING_FLAG = dr["YEAR_CLOSING_FLAG"].ToString();
                //TheAccounts_DailyTransactions.STATUS_FLAG = dr["STATUS_FLAG"].ToString();
                //TheAccounts_DailyTransactions.MOD_DATE = dr["MOD_DATE"].ToString();
                //TheAccounts_DailyTransactions.AUTH_CODE = dr["AUTH_CODE"].ToString();

                //TheAccounts_DailyTransactions.AccountGroupID = int.Parse(dr["AccountGroupID"].ToString());
                TheVoucher2Post.AccountGroupDescription = dr["GROUP-NAME"].ToString();

                TheVoucher2Post.OfficeTypeID = int.Parse(dr["Office Type id"].ToString());
                TheVoucher2Post.OfficeTypeName = dr["Type of Office"].ToString();
                TheVoucher2Post.OfficeID = int.Parse(dr["Office ID"].ToString());
                TheVoucher2Post.OfficeName = dr["Name Of The Office"].ToString();
                TheVoucher2Post.OfficeCode = dr["Office Code"].ToString();
                TheVoucher2Post.SocietyID = int.Parse(dr["SOCIETY ID"].ToString());
                TheVoucher2Post.SocietyName = dr["SOCIETY NAME"].ToString();
                TheVoucher2Post.SocietyAliasName = dr["SOCIETY ALIAS"].ToString();
                TheVoucher2Post.SocietyCode = dr["SOCIETY CODE"].ToString();

                TheVoucher2PostList.Add(TheVoucher2Post);
            }
            return TheVoucher2PostList;
        }

        public static List<Voucher2Post> GetCurrentMonthTransactionsList(int officeID)
        {
            List<Voucher2Post> TheVoucher2PostList = new List<Voucher2Post>();
            DataTable TheVoucher2PostDataTable = AccountsTransactionsDataAccess.GetInstance.GetCurrentMonthTransactionsList(officeID);

            foreach (DataRow dr in TheVoucher2PostDataTable.Rows)
            {
                Voucher2Post TheVoucher2Post = new Voucher2Post();

                TheVoucher2Post.TranDate = DateTime.Parse(dr["TRAN. DATE"].ToString()).ToString(MicroConstants.DateFormat);
                TheVoucher2Post.TranNumber = int.Parse(dr["TRAN. NO."].ToString());
                TheVoucher2Post.VoucherNumber = dr["VOUCHER NO."].ToString();
                TheVoucher2Post.SerialNumber = int.Parse(dr["SL. NO."].ToString());
                TheVoucher2Post.AccountsID = int.Parse(dr["ACC. ID"].ToString());
                TheVoucher2Post.AccountCode = dr["ACC. CODE"].ToString();
                TheVoucher2Post.AccountDescription = dr["ACC. DESC"].ToString().ToUpper();
                TheVoucher2Post.TranType = dr["TRAN. TYPE"].ToString();
                TheVoucher2Post.TranAmount = decimal.Parse(dr["TRAN. AMOUNT"].ToString());
                TheVoucher2Post.BalanceType = dr["DR./CR."].ToString();
                TheVoucher2Post.Narration = dr["ACC. NARRATION"].ToString();
                TheVoucher2Post.IsPosted = dr["IsPosted"] != DBNull.Value ? dr["IsPosted"].ToString() : "N";
                TheVoucher2Post.PostedBy = dr["PostedByUserID"] != DBNull.Value ? int.Parse(dr["PostedByUserID"].ToString()) : 0;

                TheVoucher2Post.PostedDate = dr["DateOfPosting"] != DBNull.Value ? dr["DateOfPosting"].ToString() : "";
                TheVoucher2Post.PostMode = dr["ModeOfPosting"].ToString();

                TheVoucher2Post.ACC_YEAR_ID = int.Parse(dr["ACC. YEAR ID"].ToString());
                TheVoucher2Post.ACC_YEAR_CODE = dr["ACC. YEAR CODE"].ToString();
                TheVoucher2Post.CURRENT_START_DATE = dr["YEAR START DT."].ToString();
                TheVoucher2Post.CURRENT_END_DATE = dr["YEAR CLOSE DT."].ToString();

                TheVoucher2Post.AccountGroupDescription = dr["GROUP-NAME"].ToString();

                TheVoucher2Post.OfficeTypeID = int.Parse(dr["Office Type id"].ToString());
                TheVoucher2Post.OfficeTypeName = dr["Type of Office"].ToString();
                TheVoucher2Post.OfficeID = int.Parse(dr["Office ID"].ToString());
                TheVoucher2Post.OfficeName = dr["Name Of The Office"].ToString();
                TheVoucher2Post.OfficeCode = dr["Office Code"].ToString();
                TheVoucher2Post.SocietyID = int.Parse(dr["SOCIETY ID"].ToString());
                TheVoucher2Post.SocietyName = dr["SOCIETY NAME"].ToString();
                TheVoucher2Post.SocietyAliasName = dr["SOCIETY ALIAS"].ToString();
                TheVoucher2Post.SocietyCode = dr["SOCIETY CODE"].ToString();

                TheVoucher2PostList.Add(TheVoucher2Post);
            }
            return TheVoucher2PostList;
        }

        public static int UpdateTransactionsPostingBatch(List<Voucher2PostUpdate> voucher2PostUpdateList)
        {
            return AccountsTransactionsDataAccess.GetInstance.UpdateTransactionsPostingBatch(voucher2PostUpdateList);
        }

        public static long GetNextTransactionNumber()
        {
            return AccountsTransactionsDataAccess.GetInstance.GetNextTransactionNumber();
        }

        public static List<AccountMaster> FillAccountsListByOffice()
        {
            List<AccountMaster> AccList = new List<AccountMaster>();
            AccList = AccountMasterIntegration.GetAccountMasterList();
            return AccList;
        }

        public static List<AccountMaster> FillAccountsListByOffice(int parentGroupId)
        {
            List<AccountMaster> AccList = new List<AccountMaster>();
            AccList = AccountMasterIntegration.GetAccountMasterList();

            List<AccountGroup> theAccountGroupList = AccountGroupIntegration.GetAccountGroupList();

            List<AccountGroup> theAccountGroupByGroupName = theAccountGroupList
                                                            .Where(ag => ag.AccountGroupParentID.Equals(parentGroupId)).ToList();

            var filteredAccountList = (from ac in AccList
                                       join acGroup in theAccountGroupByGroupName
                                       on ac.AccountGroupID equals acGroup.AccountGroupID
                                       select ac).ToList();
            AccList = filteredAccountList;

            return AccList;
        }

        public static List<AccountBookClose> GetAccountsBookCloseList()
        {
            List<AccountBookClose> theAccountBookCloseList = new List<AccountBookClose>();
            DataTable theAccountBookCloseTable = AccountsTransactionsDataAccess.GetInstance.GetAccountsBookCloseList();

            foreach (DataRow dr in theAccountBookCloseTable.Rows)
            {
                AccountBookClose theAccountBookClose = new AccountBookClose();

                theAccountBookClose.RecordNumber = int.Parse(dr["RecordNumber"].ToString());
                theAccountBookClose.AccountYearID = int.Parse(dr["AccountYearID"].ToString());
                theAccountBookClose.AccountYearMonth = dr["AccountYearMonth"].ToString();
                theAccountBookClose.IsBookClosed = char.Parse(dr["IsBookClosed"].ToString());
                theAccountBookClose.BookClosedByUserID = dr["BookClosedByUserID"] != DBNull.Value ? int.Parse(dr["BookClosedByUserID"].ToString()) : 0;
                theAccountBookClose.BookCloseDateTime = dr["BookCloseDateTime"] != DBNull.Value ? dr["BookCloseDateTime"].ToString() : string.Empty;
                theAccountBookClose.AuthorisationID = dr["AuthorisationID"] != DBNull.Value ? int.Parse(dr["AuthorisationID"].ToString()) : 0;
                theAccountBookClose.SocietyID = int.Parse(dr["SocietyID"].ToString());
                theAccountBookClose.OfficeID = int.Parse(dr["OfficeID"].ToString());

                theAccountBookCloseList.Add(theAccountBookClose);
            }
            return theAccountBookCloseList;
        }

        public static List<CashBook> GetAccountLedgerListByAccountID(int officeID, int accountID, int accountYearID, string ledgerType)
        {
            List<CashBook> theTransactionsList = new List<CashBook>();
            DataTable theTransactionTable = AccountsTransactionsDataAccess.GetInstance.GetAccountLedgerListByAccountID(officeID, accountID, accountYearID, ledgerType);

            foreach (DataRow dr in theTransactionTable.Rows)
            {
                CashBook theTransation = new CashBook();
                theTransation = CashAndBankBookDataRowToObject(dr);
                theTransactionsList.Add(theTransation);
            }
            return theTransactionsList;
        }

        public static List<CashBook> GetAccountLedgerListByOfficeID(int officeID, int accountYearID)
        {
            List<CashBook> theTransactionsList = new List<CashBook>();
            DataTable theTransactionTable = AccountsTransactionsDataAccess.GetInstance.GetAccountLedgerListByOfficeID(officeID, accountYearID);

            foreach (DataRow dr in theTransactionTable.Rows)
            {
                CashBook theTransation = new CashBook();
                theTransation = CashAndBankBookDataRowToObject(dr);
                theTransactionsList.Add(theTransation);
            }
            return theTransactionsList;
        }

        public static List<CashBook> GetCashAndBankBookByAccountID(int officeID, int accountID, int accountYearID, string ledgerType)
        {
            List<CashBook> theTransactionsList = new List<CashBook>();
            DataTable theTransactionTable = AccountsTransactionsDataAccess.GetInstance.GetCashAndBankBookByAccountID(officeID, accountID, accountYearID, ledgerType);

            foreach (DataRow dr in theTransactionTable.Rows)
            {
                CashBook theTransation = new CashBook();
                theTransation = CashAndBankBookDataRowToObject(dr);
                theTransactionsList.Add(theTransation);
            }
            return theTransactionsList;
        }

        public static List<AccountLedgerNew> GetIncomeAndExpendituresByParentAccountGroup(int officeID, int accountYearID, string parentAccountGroup, string DateFrom, string DateTo)
        {
            List<AccountLedgerNew> theAccountLedgerList = new List<AccountLedgerNew>();
            DataTable theTransactionTable = AccountsTransactionsDataAccess.GetInstance.GetIncomeAndExpendituresByParentAccountGroup(officeID, accountYearID, parentAccountGroup, DateFrom, DateTo);

            foreach (DataRow dr in theTransactionTable.Rows)
            {
                AccountLedgerNew theAccountLedger = new AccountLedgerNew();

                theAccountLedger.AccountID = int.Parse(dr["AccountsID"].ToString());
                theAccountLedger.AccountCode = dr["AccountsCode"].ToString();
                theAccountLedger.AccountDescription = dr["AccountDescription"].ToString();
                theAccountLedger.AccountGroupID = int.Parse(dr["AccountGroupID"].ToString());
                theAccountLedger.AccountGroupDescription = dr["AccountGroupDescription"].ToString();
                theAccountLedger.ParentAccountGroupID = int.Parse(dr["AccountGroupParentID"].ToString());
                theAccountLedger.ParentAccountGroupDescription = dr["AccountGroupParentDesc"].ToString();
                theAccountLedger.BalanceType = dr["BalanceType"].ToString();

                if (theAccountLedger.BalanceType.ToUpper().Equals("DB"))
                {
                    theAccountLedger.BalanceType = "DR";
                    theAccountLedger.Debit = Decimal.Parse(dr["TranAmount"].ToString());
                    theAccountLedger.Credit = Decimal.Parse("0.0");
                }
                else if (theAccountLedger.BalanceType.ToUpper().Equals("CR"))
                {
                    theAccountLedger.Debit = Decimal.Parse("0.0");
                    theAccountLedger.Credit = Decimal.Parse(dr["TranAmount"].ToString());
                }
                


                //theAccountLedger.OfficeID = dr["OfficeID"] != DBNull.Value ? int.Parse(dr["OfficeID"].ToString()) : 0;
                //theAccountLedger.SocietyID = dr["SocietyID"] != DBNull.Value ? int.Parse(dr["SocietyID"].ToString()) : 0;

                theAccountLedgerList.Add(theAccountLedger);
            }
            return theAccountLedgerList;
        }

        //Account Book Month Closing------------------------------------------------------------------------------------------------------------------------
        public static int CloseAccountingMonthBookByOffice(int officeID, int accountsYearId, string accountsYearName, string accountsMonthName, char bookCloseFlag)
        {
            return AccountsTransactionsDataAccess.GetInstance.CloseAccountingMonthBookByOffice(officeID, accountsYearId, accountsYearName, accountsMonthName, bookCloseFlag);
        }

        //Account Book Year Closing---------------------------------------------------------
        public static int CloseAccountingYearBookBySociety(int accountYearID, int societyID)
        {
            return AccountsTransactionsDataAccess.GetInstance.CloseAccountingYearBookBySociety(accountYearID, societyID);
        }

        public static AccountingYear GetAccountingYearIDByFlag(string flag)
        {
            DataRow AccountingYearRow = AccountingYearDataAccess.GetInstance.GetAccountingYearByFlag(flag);

            AccountingYear TheAccountingYear = new AccountingYear();

            TheAccountingYear.ACC_YEAR_ID = int.Parse(AccountingYearRow["ACC_YEAR_ID"].ToString());
            TheAccountingYear.CURRENT_START_DATE = AccountingYearRow["CURRENT_START_DATE"].ToString();
            TheAccountingYear.CURRENT_END_DATE = AccountingYearRow["CURRENT_END_DATE"].ToString();
            TheAccountingYear.PREVIOUS_START_DATE = AccountingYearRow["PREVIOUS_START_DATE"].ToString();
            TheAccountingYear.PREVIOUS_END_DATE = AccountingYearRow["PREVIOUS_END_DATE"].ToString();
            TheAccountingYear.BOOK_CLOSING_FLAG = AccountingYearRow["BOOK_CLOSING_FLAG"].ToString();
            TheAccountingYear.YEAR_CLOSING_FLAG = AccountingYearRow["YEAR_CLOSING_FLAG"].ToString();
            TheAccountingYear.STATUS_FLAG = AccountingYearRow["STATUS_FLAG"].ToString();
            TheAccountingYear.MOD_DATE = AccountingYearRow["MOD_DATE"].ToString();
            TheAccountingYear.AUTH_CODE = AccountingYearRow["AUTH_CODE"].ToString();
            TheAccountingYear.AddedBy = int.Parse(AccountingYearRow["AddedBy"].ToString());
            TheAccountingYear.SocietyID = int.Parse(AccountingYearRow["SocietyID"].ToString());

            return TheAccountingYear;
        }

        public static List<CurrentSavingAccountTransaction> GetSavingAccountTransactionList(string accountsCode)
        {
            List<CurrentSavingAccountTransaction> theCurrentSavingAccountTransactionList = new List<CurrentSavingAccountTransaction>();
            DataTable theCurrentSavingAccountTransactionTable = AccountsTransactionsDataAccess.GetInstance.GetSavingAccountTransactionList(accountsCode);

            foreach (DataRow dr in theCurrentSavingAccountTransactionTable.Rows)
            {
                CurrentSavingAccountTransaction theCurrentSavingAccountTransaction = new CurrentSavingAccountTransaction();
                theCurrentSavingAccountTransaction = CurrentSavingAccountTransactionDataRowToObject(dr);
                theCurrentSavingAccountTransactionList.Add(theCurrentSavingAccountTransaction);
            }
            return theCurrentSavingAccountTransactionList;
        }
        #endregion
    }
}
