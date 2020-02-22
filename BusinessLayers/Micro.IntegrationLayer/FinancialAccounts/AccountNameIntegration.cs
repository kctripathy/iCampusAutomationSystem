using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.IntegrationLayer.FinancialAccounts
{
    public partial class AccountNameIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementaion
        public static AccountName DataRowToObject(DataRow dr)
        {
            AccountName TheAccount = new AccountName
            {
                AccountID = int.Parse(dr["AccountID"].ToString()),
                AccountDescription = dr["AccountDescription"].ToString(),
                AccountHeadID = int.Parse(dr["AccountHeadID"].ToString()),
                AccountHeadDescription = dr["AccountHeadDescription"].ToString(),
                AccountHeadType = dr["AccountHeadType"].ToString(),
                ParentAccountHeadID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ParentAccountHeadID"].ToString())),
                ParentAccountHeadDescription = dr["ParentAccountHeadDescription"].ToString(),
                ParentAccountID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ParentAccountID"].ToString())),
                IsPrimary = bool.Parse(dr["IsPrimary"].ToString()),
                AccessType = dr["AccessType"].ToString(),
                AnalysisFlag = dr["AnalysisFlag"].ToString(),
                DisplayOrder = int.Parse(dr["DisplayOrder"].ToString())
            };

            return TheAccount;
        }

        public static List<AccountName> GetAccountList(bool showPrimary = true, bool showDeleted = false)
        {
            List<AccountName> AccountList = new List<AccountName>();

            DataTable GetAccountTable = AccountNameDataAccess.GetInstance.GetAccountList(showPrimary, showDeleted);

            foreach (DataRow dr in GetAccountTable.Rows)
            {
                AccountName TheAccount = DataRowToObject(dr);
                AccountList.Add(TheAccount);
            }

            return AccountList;
        }

        public static List<AccountName> GetAccountListByAccessType(string accessType)
        {
            List<AccountName> FilteredAccountList;
            List<AccountName> AccountList = GetAccountList(true, false);

            if (AccountList.Count > 0)
                FilteredAccountList = (from TheAccount in AccountList
                                       where TheAccount.AccessType.Equals(accessType)
                                       select TheAccount).ToList();
            else
                FilteredAccountList = new List<AccountName>();

            return FilteredAccountList;
        }

        public static List<AccountName> GetAccountListByAnalysisFlag(string analysisFlag, bool showPrimary = true, bool showDeleted = false)
        {
            List<AccountName> FilteredList;
            List<AccountName> AccountNameList = GetAccountList(showPrimary, showDeleted);

            if (AccountNameList.Count > 0)
                FilteredList = (from AccountNames in AccountNameList
                                where AccountNames.AnalysisFlag.Equals(analysisFlag)
                                select AccountNames).ToList();
            else
                FilteredList = new List<AccountName>();

            return FilteredList;
        }

        public static List<AccountName> GetAccountListByAnalysisFlag(List<AccountName> accountNameList, string analysisFlag)
        {
            List<AccountName> FilteredList;
            List<AccountName> AccountNameList = accountNameList;

            if (AccountNameList.Count > 0)
                FilteredList = (from AccountNames in AccountNameList
                                where AccountNames.AnalysisFlag.Equals(analysisFlag)
                                select AccountNames).ToList();
            else
                FilteredList = new List<AccountName>();

            return FilteredList;
        }

        public static AccountName GetAccountByID(int accountID)
        {
            AccountName TheAccount;
            DataRow TheAccountRow = AccountNameDataAccess.GetInstance.GetAccountByID(accountID);

            if (TheAccountRow != null)
                TheAccount = DataRowToObject(TheAccountRow);
            else
                TheAccount = new AccountName();

            return TheAccount;
        }

        public static int InsertAccount(AccountName theAccount)
        {
            return AccountNameDataAccess.GetInstance.InsertAccount(theAccount);
        }

        public static int UpdateAccount(AccountName theAccount)
        {
            return AccountNameDataAccess.GetInstance.UpdateAccount(theAccount);
        }

        public static int DeleteAccount(AccountName theAccount)
        {
            return AccountNameDataAccess.GetInstance.DeleteAccount(theAccount);
        }

        public static int UpdateDisplayOrder(List<AccountName> accountList)
        {
            return AccountNameDataAccess.GetInstance.UpdateDisplayOrder(accountList);
        }
        #endregion
    }
}
