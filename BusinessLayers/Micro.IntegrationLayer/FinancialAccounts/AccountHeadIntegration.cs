using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micro.Commons;
using Micro.DataAccessLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.IntegrationLayer.FinancialAccounts
{
    public partial class AccountHeadIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementaion
        public static AccountHead DataRowToObject(DataRow dr)
        {
            AccountHead TheAccountHead = new AccountHead();

            TheAccountHead.AccountHeadID = int.Parse(dr["AccountHeadID"].ToString());
            TheAccountHead.AccountHeadDescription = dr["AccountHeadDescription"].ToString();
            TheAccountHead.AccountHeadType = dr["AccountHeadType"].ToString();
            TheAccountHead.ParentAccountHeadID = int.Parse(MicroGlobals.ReturnZeroIfNull(dr["ParentAccountHeadID"].ToString()));
            TheAccountHead.ParentAccountHeadDescription = dr["ParentAccountHeadDescription"].ToString();
			TheAccountHead.IsPrimary = bool.Parse(dr["IsPrimary"].ToString());
            TheAccountHead.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());

            return TheAccountHead;
        }

        public static List<AccountHead> GetAccountHeadList(bool showPrimary = true, bool showDeleted = false)
        {
            List<AccountHead> AccountHeadList = new List<AccountHead>();

            DataTable GetAccountHeadTable = AccountHeadDataAccess.GetInstance.GetAccountHeadList(showPrimary, showDeleted);

            foreach (DataRow dr in GetAccountHeadTable.Rows)
            {
                AccountHead TheAccountHead = DataRowToObject(dr);
                AccountHeadList.Add(TheAccountHead);
            }

            return AccountHeadList;
        }

        public static List<AccountHead> GetAccountHeadListByType(string accountHeadType, bool showPrimary = true, bool showDeleted = false)
        {
            List<AccountHead> FilteredList;
            List<AccountHead> AccountHeadList = GetAccountHeadList(showPrimary, showDeleted);

            if (AccountHeadList.Count > 0)
                FilteredList = (from AccountHeads in AccountHeadList
                                where AccountHeads.AccountHeadType.Equals(accountHeadType)
                                select AccountHeads).ToList();
            else
                FilteredList = new List<AccountHead>();

            return FilteredList;
        }

        public static List<AccountHead> GetAccountHeadListByType(List<AccountHead> accountHeadList, string accountHeadType, bool showPrimary = true, bool showDeleted = false)
        {
            List<AccountHead> FilteredList;
            List<AccountHead> AccountHeadList = accountHeadList;

            if (AccountHeadList.Count > 0)
                FilteredList = (from AccountHeads in AccountHeadList
                                where AccountHeads.AccountHeadType.Equals(accountHeadType)
                                select AccountHeads).ToList();
            else
                FilteredList = new List<AccountHead>();

            return FilteredList;
        }        

        public static AccountHead GetAccountHeadByID(int accountHeadID)
        {
            AccountHead TheAccountHead;
            DataRow TheAccountHeadRow = AccountHeadDataAccess.GetInstance.GetAccountHeadByID(accountHeadID);

            if (TheAccountHeadRow != null)
                TheAccountHead = DataRowToObject(TheAccountHeadRow);
            else
                TheAccountHead = new AccountHead();

            return TheAccountHead;
        }

        public static int InsertAccountHead(AccountHead theAccountHead)
        {
            return AccountHeadDataAccess.GetInstance.InsertAccountHead(theAccountHead);
        }

        public static int UpdateAccountHead(AccountHead theAccountHead)
        {
            return AccountHeadDataAccess.GetInstance.UpdateAccountHead(theAccountHead);
        }

        public static int DeleteAccountHead(AccountHead theAccountHead)
        {
            return AccountHeadDataAccess.GetInstance.DeleteAccountHead(theAccountHead);
        }

        public static int UpdateDisplayOrder(List<AccountHead> accountHeadList)
        {
            return AccountHeadDataAccess.GetInstance.UpdateDisplayOrder(accountHeadList);
        }
        #endregion
    }
}
