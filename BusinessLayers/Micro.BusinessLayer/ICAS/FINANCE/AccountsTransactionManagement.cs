using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Micro.IntegrationLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;
using Micro.Objects;

namespace Micro.BusinessLayer.ICAS.FINANCE
{
    public partial class AccountsTransactionManagement
    {
        #region Code to make this as Singleton Class
        /// <summary>
        /// Declare a private static variable
        /// </summary>
        private static AccountsTransactionManagement _Instance;

        /// <summary>
        /// Return the instance of the application by initialising once only.
        /// </summary>
        public static AccountsTransactionManagement GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountsTransactionManagement();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion

        #region Declaration
        public string DefaultColumn = "AccountDescription, AccountCode";
        public string DisplayMember = "AccountDescription";
        public string ValueMember = "AccountID";

        const string BalanceTypeDebit = "DB";
        const string BalanceTypeCredit = "CR";
        #endregion

        #region Methods & Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theAccountsDailyTransactions"></param>
        /// <returns></returns>
        public int InsertAccountsDailyTransactions(Accounts_DailyTransactions theAccountsDailyTransactions)
        {
            return AccountsTransactionIntegration.InsertAccountsDailyTransactions(theAccountsDailyTransactions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Voucher_BatchPosting> GetValidTransactionsList()
        {
            return AccountsTransactionIntegration.GetValidTransactionsList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="officeID"></param>
        /// <returns></returns>
        public List<Voucher2Post> GetCurrentMonthTransactionsList(int officeID)
        {
            return AccountsTransactionIntegration.GetCurrentMonthTransactionsList(officeID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Voucher2Post> GetValidTransactions()
        {
            return AccountsTransactionIntegration.GetValidTransactions();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voucher2PostUpdateList"></param>
        /// <returns></returns>
        public int UpdateTransactionsPostingBatch(List<Voucher2PostUpdate> voucher2PostUpdateList)
        {
            return AccountsTransactionIntegration.UpdateTransactionsPostingBatch(voucher2PostUpdateList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long GetNextTransactionNumber()
        {
            return AccountsTransactionIntegration.GetNextTransactionNumber();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cnt"></param>
        /// <returns></returns>
        public Boolean FillAccountsListByOffice(Control Cnt)
        {


            string Context = "FillAccountsListByOffice";

            try
            {
                List<AccountMaster> AccountsMasterList = GetAccountsMasterList();
                int officeID = Micro.Commons.Connection.LoggedOnUser.OfficeID;
                //if (Cnt is DevExpress.XtraEditors.LookUpEdit)
                //{
                //    ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = AccountsMasterList;
                //    ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = AccountsTransactionManagement.GetInstance.DisplayMember;
                //    ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = AccountsTransactionManagement.GetInstance.ValueMember;
                //    ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
                //}
                //else if (Cnt is DevExpress.XtraGrid.GridControl)
                //{
                //    ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AccountsTransactionIntegration.FillAccountsListByOffice(); //OfficeManagement.GetInstance.GetOfficeListByReportingOfficeID(officeID);
                //}
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw (new Exception(Context, ex));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<AccountMaster> GetAccountsMasterList()
        {
            string Context = "GetAccountsMasterList()";
            List<AccountMaster> AccountsMasterList = new List<AccountMaster>();
            if (HttpRuntime.Cache[Context] == null)
            {
                AccountsMasterList = AccountMasterManagement.GetInstance.GetAccountMasterList();
                HttpRuntime.Cache[Context] = AccountsMasterList;
            }
            else
            {
                AccountsMasterList = ((List<AccountMaster>)(HttpRuntime.Cache[Context]));
            }
            return AccountsMasterList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cnt"></param>
        /// <param name="accountGroupId"></param>
        /// <returns></returns>
        public Boolean FillAccountsListByOffice(Control Cnt, int accountGroupId)
        {
            string Context = string.Concat("FillAccountsListByOffice", accountGroupId.ToString());
            try
            {
                int officeID = Micro.Commons.Connection.LoggedOnUser.OfficeID;
                int CurrentAccountYearID = 1;//TO DO KP Account Year

                List<AccountGroup> theAccountGroupList = AccountGroupManagement.GetInstance.GetAccountGroupList();
                List<AccountMaster> theAccountMasterList = GetAccountsMasterList();
                List<AccountBalance> theAccountBalanceList = AccountBalanceManagement.GetInstance.GetAccountsBalanceListByAccountsYearID(CurrentAccountYearID, officeID);

                theAccountMasterList = (from am in theAccountMasterList
                                        join ab in theAccountBalanceList
                                        on am.AccountID equals ab.AccountsID
                                        where !am.AccountDescription.StartsWith("RD")
                                        && !am.AccountDescription.StartsWith("FD")
                                        select am).ToList();

                // if parent is not zero
                if (!accountGroupId.Equals(0))
                {
                    if (theAccountGroupList.Count > 0) // receipt or payment
                    {
                        List<AccountGroup> theAccountGroupByGroupName = theAccountGroupList.Where(ag => ag.AccountGroupParentID.Equals(accountGroupId)).ToList();

                        var filteredAccountList = (from ac in theAccountMasterList
                                                   join acGroup in theAccountGroupByGroupName
                                                   on ac.AccountGroupID equals acGroup.AccountGroupID
                                                   select ac).ToList();

                        //if (accountGroupId == 4)
                        // RECEIPT AND PAY TO THE MEMBERS PERSONAL ACCOUNT  
                        var filteredAccountList2 = (from ac in theAccountMasterList
                                                    where ac.AccountCode.StartsWith("M") || ac.AccountCode.StartsWith("EMP")
                                                    select ac).ToList();


                        // RECEIPT AND PAY TO THE MEMBERS PERSONAL ACCOUNT  
                        var filteredAccountList3 = (from ac in theAccountMasterList
                                                    where ac.AccountCode.StartsWith("01") && ac.AccountDescription.Trim().Length > 0
                                                    select ac).ToList();
                        // RECEIPT AND PAY TO THE MEMBERS SAVING ACCOUNTS   
                        var filteredAccountList4 = (from ac in theAccountMasterList
                                                    where ac.AccountDescription.StartsWith("SD") //|| ac.AccountDescription.StartsWith("FD")
                                                    select ac).ToList();

                        filteredAccountList4.AddRange(filteredAccountList);
                        filteredAccountList4.AddRange(filteredAccountList3);
                        filteredAccountList4.AddRange(filteredAccountList2);

                        //var filteredAccountList = (from ac in theAccountMasterList
                        //                           join acGroup in theAccountGroupByGroupName
                        //                           on ac.AccountGroupID equals acGroup.AccountGroupID
                        //                           select ac).ToList();
                        //theAccountMasterList = filteredAccountList;
                        //if (Cnt is DevExpress.XtraEditors.LookUpEdit)
                        //{
                        //    ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = filteredAccountList4;
                        //    ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = AccountsTransactionManagement.GetInstance.DisplayMember;
                        //    ((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = AccountsTransactionManagement.GetInstance.ValueMember;
                        //    ((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
                        //}
                        //else if (Cnt is DevExpress.XtraGrid.GridControl)
                        //{
                        //    ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AccountsTransactionIntegration.FillAccountsListByOffice(); //OfficeManagement.GetInstance.GetOfficeListByReportingOfficeID(officeID);
                        //}
                    }
                }

                else
                {
                    // all records for journal and voucher
                    //if (Cnt is DevExpress.XtraEditors.LookUpEdit)
                    //{
                        List<AccountGroup> theAccountGroupByGroupName = theAccountGroupList.Where(ag => ag.AccountGroupParentID.Equals(accountGroupId)).ToList();

                        var filteredAccountList = (from ac in theAccountMasterList
                                                   join acGroup in theAccountGroupByGroupName
                                                   on ac.AccountGroupID equals acGroup.AccountGroupID
                                                   select ac).ToList();

                        ////if (accountGroupId == 4)
                        //// RECEIPT AND PAY TO THE MEMBERS PERSONAL ACCOUNT  
                        //var filteredAccountList2 = (from ac in theAccountMasterList
                        //                            where ac.AccountCode.StartsWith("M") || ac.AccountCode.StartsWith("EMP")
                        //                            select ac).ToList();


                        //// RECEIPT AND PAY TO THE MEMBERS PERSONAL ACCOUNT  
                        //var filteredAccountList3 = (from ac in theAccountMasterList
                        //                            where ac.AccountCode.StartsWith("01") && ac.AccountDescription.Trim().Length > 0
                        //                            select ac).ToList();


                        //// RECEIPT AND PAY TO THE MEMBERS SAVING ACCOUNTS, CAN'T TRANSACT RD AND FD ACCOUNTS FROM THIS FORM  
                        var filteredAccountList4 = (from ac in theAccountMasterList
                                                    where !ac.AccountDescription.StartsWith("RD") || !ac.AccountDescription.StartsWith("FD")
                                                    select ac).ToList();

                        //filteredAccountList4.AddRange(filteredAccountList);
                        //filteredAccountList4.AddRange(filteredAccountList3);
                        //filteredAccountList4.AddRange(filteredAccountList2);

                        //((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DataSource = theAccountMasterList;
                        //((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.DisplayMember = AccountsTransactionManagement.GetInstance.DisplayMember;
                        //((DevExpress.XtraEditors.LookUpEdit)Cnt).Properties.ValueMember = AccountsTransactionManagement.GetInstance.ValueMember;
                        //((DevExpress.XtraEditors.LookUpEdit)Cnt).EditValue = "";
                    //}
                    //else if (Cnt is DevExpress.XtraGrid.GridControl)
                    //{
                    //    ((DevExpress.XtraGrid.GridControl)Cnt).DataSource = AccountsTransactionIntegration.FillAccountsListByOffice(); //OfficeManagement.GetInstance.GetOfficeListByReportingOfficeID(officeID);
                    //}
                }
                return true;
            }
            catch (Exception ex)
            {
                //throw (new Exception(Context, ex));
                return false;

            }
        }
        #endregion

        #region Methods & Implementation for Financial Year Book Closing and Account Ledgers
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AccountBookClose> GetAccountsBookCloseList()
        {
            return AccountsTransactionIntegration.GetAccountsBookCloseList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="officeID"></param>
        /// <param name="accountID"></param>
        /// <param name="accountYearID"></param>
        /// <param name="ledgerType"></param>
        /// <returns></returns>
        public List<CashBook> GetAccountLedgerListByAccountID(int officeID, int accountID, int accountYearID, string ledgerType)
        {
            return AccountsTransactionIntegration.GetAccountLedgerListByAccountID(officeID, accountID, accountYearID, ledgerType);

        }

        /// <summary>
        /// Close the accounting month
        /// </summary>
        /// <param name="officeID"></param>
        /// <param name="accountsYearId"></param>
        /// <param name="accountsYearName"></param>
        /// <param name="accountsMonthName"></param>
        /// <param name="bookCloseFlag"></param>
        /// <returns></returns>
        public int CloseAccountingMonthBookByOffice(int officeID, int accountsYearId, string accountsYearName, string accountsMonthName, char bookCloseFlag)
        {
            return AccountsTransactionIntegration.CloseAccountingMonthBookByOffice(officeID, accountsYearId, accountsYearName, accountsMonthName, bookCloseFlag);
        }

        //---------------------------------------------------------
        /// <summary>
        /// Close the Account Book for the Year
        /// </summary>
        /// <param name="accountYearID"></param>
        /// <param name="societyID"></param>
        /// <returns></returns>
        public int CloseAccountingYearBookBySociety(int accountYearID, int societyID)
        {
            return AccountsTransactionIntegration.CloseAccountingYearBookBySociety(accountYearID, societyID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public AccountingYear GetAccountingYearIDByFlag(string flag)
        {
            return AccountsTransactionIntegration.GetAccountingYearIDByFlag(flag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="societyID"></param>
        /// <returns></returns>
        public AccountingYear GetAccountingYearByFlagAndSocietyID(string flag, int societyID)
        {
            return AccountsTransactionIntegration.GetAccountingYearIDByFlag(flag);
        }

        /// <summary>
        /// Get Opening & Closing Balance
        /// </summary>
        /// <param name="officeID"></param>
        /// <param name="accountID"></param>
        /// <param name="accountYearID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="openingBalance"></param>
        /// <param name="closingBalance"></param>
        /// <param name="currentFinYearStartDate"></param>
        public void GetOpeningAndClosingBalance(int officeID, int accountID, int accountYearID, DateTime fromDate, DateTime toDate, out decimal openingBalance, out decimal closingBalance, out DateTime currentFinYearStartDate)
        {
            //OUTPUT PARAMETERS
            openingBalance = 0;
            closingBalance = 0;
            currentFinYearStartDate = DateTime.Today;

            try
            {
                decimal TotalDebit = 0;
                decimal TotalCredit = 0;
                decimal DebitFromDate = 0;
                decimal CreditFromDate = 0;

                //Get all the Accounts Balance by Account YearID
                List<AccountBalance> theAccountBalanceList = AccountBalanceIntegration.GetAccountsBalanceListByAccountsYearID(accountYearID, officeID);

                if (theAccountBalanceList.Count > 0)
                {
                    //Get the single Account Balance by AccountID
                    AccountBalance theAccountBalance = theAccountBalanceList.Where(ab => ab.AccountsID == accountID).SingleOrDefault();

                    //Get all valid Posted Accounts Transactions list
                    List<Voucher_BatchPosting> theAccountTransactionList = new List<Voucher_BatchPosting>();
                    theAccountTransactionList = AccountsTransactionManagement.GetInstance.GetValidTransactionsList();

                    var theACTList = new List<Voucher_BatchPosting>();
                    //Get all valid Posted Accounts Transactions list filter By Transaction Date which is -(To Date) - given by the user
                    theACTList = theAccountTransactionList.Where(ac => ac.OfficeID == officeID &&
                                                                  ac.ACC_YEAR_ID == accountYearID &&
                                                                  ac.AccountsID == accountID &&
                                                                  (DateTime.Parse(ac.TranDate) <= toDate)).ToList();


                    TotalDebit = theACTList.Where(ac => ac.BalanceType.Equals(BalanceTypeDebit) && DateTime.Parse(ac.TranDate) <= toDate).Sum(ac => ac.TranAmount);
                    TotalCredit = theACTList.Where(ac => ac.BalanceType.Equals(BalanceTypeCredit) && DateTime.Parse(ac.TranDate) <= toDate).Sum(ac => ac.TranAmount);


                    ////Total Debit and Credit amount count on (ToDate) -  given by the user 
                    DebitFromDate = theACTList.Where(ac => ac.BalanceType.Equals(BalanceTypeDebit) && DateTime.Parse(ac.TranDate) < fromDate).Sum(ac => ac.TranAmount);
                    CreditFromDate = theACTList.Where(ac => ac.BalanceType.Equals(BalanceTypeCredit) && DateTime.Parse(ac.TranDate) < fromDate).Sum(ac => ac.TranAmount);

                    currentFinYearStartDate = DateTime.Parse(theAccountBalance.FinYearStartDate);
                    //-----------------------------------------------------------------------------
                    // CALCULATING THE CLOSING BALANCE:
                    //-----------------------------------------------------------------------------
                    if (theAccountBalance.FinYearOpeningBalanceType.Equals(BalanceTypeDebit))
                    {

                        openingBalance = (DebitFromDate + theAccountBalance.FinYearOpeningBalance) - CreditFromDate;
                        closingBalance = (TotalDebit + theAccountBalance.FinYearOpeningBalance) - TotalCredit;
                    }
                    else if (theAccountBalance.FinYearOpeningBalanceType.Equals(BalanceTypeCredit))
                    {
                        openingBalance = (CreditFromDate + theAccountBalance.FinYearOpeningBalance) - DebitFromDate;
                        closingBalance = (TotalCredit + theAccountBalance.FinYearOpeningBalance) - TotalDebit;
                    }

                    //-----------------------------------------------------------------------------
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public List<CashBook> GetAccountLedgerListByAccountIDAndDates(int officeID, int accountID, int accountsYearId, string ledgerType, DateTime fromDate, DateTime toDate)
        {
            List<CashBook> theTransactionsList = new List<CashBook>();
            theTransactionsList = GetAccountLedgerListByAccountID(officeID, accountID, accountsYearId, ledgerType);

            if (theTransactionsList.Count > 0)
            {
                theTransactionsList = theTransactionsList.Where(ac =>
                                                        DateTime.Parse(ac.TranDate) >= fromDate
                                                        &&
                                                        DateTime.Parse(ac.TranDate) <= toDate).ToList();
            }
            return theTransactionsList;
        }

        public List<CashBook> GetAccountLedgerListByOfficeIDAndDates(int officeID, int accountsYearId, DateTime fromDate, DateTime toDate)
        {
            List<CashBook> theTransactionsList = new List<CashBook>();
            theTransactionsList = AccountsTransactionIntegration.GetAccountLedgerListByOfficeID(officeID, accountsYearId);

            if (theTransactionsList.Count > 0)
            {
                theTransactionsList = theTransactionsList.Where(ac =>
                                                        DateTime.Parse(ac.TranDate) >= fromDate
                                                        &&
                                                        DateTime.Parse(ac.TranDate) <= toDate).ToList();
            }
            return theTransactionsList;
        }

        public List<CashBook> GetCashAndBankBookByAccountIDAndDates(int officeID, int accountID, int accountsYearId, string ledgerType, DateTime fromDate, DateTime toDate)
        {
            List<CashBook> theTransactionsList = new List<CashBook>();
            theTransactionsList = AccountsTransactionIntegration.GetCashAndBankBookByAccountID(officeID, accountID, accountsYearId, ledgerType);

            if (theTransactionsList.Count > 0)
            {
                theTransactionsList = theTransactionsList.Where(ac =>
                                                        DateTime.Parse(ac.TranDate) >= fromDate
                                                        &&
                                                        DateTime.Parse(ac.TranDate) <= toDate).ToList();
            }
            return theTransactionsList;
        }

        public List<AccountLedgerNew> GetIncomeAndExpendituresByParentAccountGroup(int officeID, int accountYearID, string parentAccountGroup, string DateFrom, string DateTo)
        {
            return AccountsTransactionIntegration.GetIncomeAndExpendituresByParentAccountGroup(officeID, accountYearID, parentAccountGroup, DateFrom, DateTo);
        }
        #endregion

        # region Methods & Implementation for Current or Saving Account Transaction for Passbook
        public List<CurrentSavingAccountTransaction> GetSavingAccountTransactionList(string accountsCode)
        {
            return AccountsTransactionIntegration.GetSavingAccountTransactionList(accountsCode);
        }
        #endregion
    }
}
