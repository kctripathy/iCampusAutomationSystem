using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.ICAS.FINANCE;
using Micro.Objects;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.IntegrationLayer.ICAS.FINANCE
{
    public partial class AccountMasterIntegration
    {
        #region Methods & Implementation
        public static AccountMaster DataRowToObject(DataRow dr)
        {
            AccountMaster TheAccountMaster = new AccountMaster();

            TheAccountMaster.AccountID = int.Parse(dr["AccountID"].ToString());
            TheAccountMaster.AccountCode = dr["AccountCode"].ToString();
            TheAccountMaster.AccountDescription = dr["AccountDescription"].ToString();
            TheAccountMaster.AccountGroupID = int.Parse(dr["AccountGroupID"].ToString());
            TheAccountMaster.AccountGroupDescription = dr["AccountGroupDescription"].ToString();
            TheAccountMaster.AccountGroupParentID = int.Parse(dr["AccountGroupParentID"].ToString());
            //TheAccountMaster.IsPrimary = bool.Parse(dr["IsPrimary"].ToString());
            //TheAccountMaster.AccessType = dr["AccessType"].ToString();
            //TheAccountMaster.AnalysisFlag = dr["AnalysisFlag"].ToString();
            TheAccountMaster.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());
            TheAccountMaster.AccountLedgerType = dr["AccountLedgerType"].ToString();
            TheAccountMaster.SocietyID = int.Parse(dr["CompanyID"].ToString());

            return TheAccountMaster;
        }

        public static List<AccountMaster> GetAccountMasterList()
        {
            List<AccountMaster> AccountMasterList = new List<AccountMaster>();
            DataTable AccountMasterTable = AccountMasterDataAccess.GetInstance.GetAccountMasterList();

            foreach (DataRow dr in AccountMasterTable.Rows)
            {
                AccountMaster TheAccountMaster = DataRowToObject(dr);
                AccountMasterList.Add(TheAccountMaster);
            }
            return AccountMasterList;
        }

        public static AccountMaster GetAccountMasterByAccountID(int accountID)
        {
            DataRow TheAccountMasterRow = AccountMasterDataAccess.GetInstance.GetAccountMasterByAccountID(accountID);

            AccountMaster TheAccountMaster = DataRowToObject(TheAccountMasterRow);

            return TheAccountMaster;
        }

        public static AccountMaster GetAccountMasterByAccountDescription(string accountDescription)
        {
            DataRow TheAccountMasterRow = AccountMasterDataAccess.GetInstance.GetAccountMasterByAccountDescription(accountDescription);

            AccountMaster TheAccountMaster = DataRowToObject(TheAccountMasterRow);

            return TheAccountMaster;
        }

        public static AccountMaster GetAccountMasterByAccountCode(string accountCode)
        {
            AccountMaster TheAccountMaster;
            DataRow TheAccountMasterRow = AccountMasterDataAccess.GetInstance.GetAccountMasterByAccountCode(accountCode);

            if (TheAccountMasterRow != null)
                TheAccountMaster = DataRowToObject(TheAccountMasterRow);
            else
                TheAccountMaster = new AccountMaster();

            return TheAccountMaster;
        }

        public static int InsertAccountMaster(AccountMaster theAccountMaster)
        {
            return AccountMasterDataAccess.GetInstance.InsertAccountMaster(theAccountMaster);
        }

        public static int UpdateAccountMaster(AccountMaster theAccountMaster)
        {
            return AccountMasterDataAccess.GetInstance.UpdateAccountMaster(theAccountMaster);
        }

        public static int DeleteAccountMaster(AccountMaster theAccountMaster)
        {
            return AccountMasterDataAccess.GetInstance.DeleteAccountMaster(theAccountMaster);
        }
        #endregion
    }
}
