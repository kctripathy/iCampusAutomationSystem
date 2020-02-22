using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.IntegrationLayer.FinancialAccounts
{
    public partial class AccountGroupIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementations
        public static AccountGroup DataRowToObject(DataRow dr)
        {
            AccountGroup TheAccountGroup = new AccountGroup
            {
                AccountGroupID = int.Parse(dr["AccountGroupID"].ToString()),
                AccountGroupDescription = (dr["AccountGroupDescription"].ToString()),
                AccountGroupAlias = (dr["AccountGroupAlias"].ToString()),
                AccountGroupParentID = int.Parse(dr["AccountGroupParentID"].ToString()), /*TheAccountGroup.PrimaryGroupDescription = dr["PrimaryGroupDescription"].ToString();*/
                AccountGroupNature = dr["AccountGroupNature"].ToString()
            };


            return TheAccountGroup;
        }

        public static List<AccountGroup> GetAccountGroupList(string searchText = "", bool showPrimary = false)
        {
            List<AccountGroup> AccountGroupList = new List<AccountGroup>();

            DataTable AccountGroupTable = AccountGroupDataAccess.GetInstance.GetAccountGroupList(searchText, showPrimary);

            foreach (DataRow dr in AccountGroupTable.Rows)
            {
                AccountGroup TheAccountGroup = DataRowToObject(dr);

                AccountGroupList.Add(TheAccountGroup);
            }

            return AccountGroupList;
        }

        public static List<AccountGroup> GetAccountGroupList(int groupID)
        {
            List<AccountGroup> AccountGroupList = new List<AccountGroup>();

            DataTable AccountGroupTable  = AccountGroupDataAccess.GetInstance.GetAccountGroupList(groupID);

            foreach (DataRow dr in AccountGroupTable.Rows)
            {
                AccountGroup TheAccountGroup = DataRowToObject(dr);

                AccountGroupList.Add(TheAccountGroup);
            }

            return AccountGroupList;
        }

        public static AccountGroup GetAccountGroupByID(int accountGroupID)
        {
            DataRow AccountGroupRow = AccountGroupDataAccess.GetInstance.GetAccountGroupByID(accountGroupID);

            AccountGroup TheAccountGroup = DataRowToObject(AccountGroupRow);

            return TheAccountGroup;
        }

        public static int InsertAccountGroup(AccountGroup theAccountGroup)
        {
            return AccountGroupDataAccess.GetInstance.InsertAccountGroup(theAccountGroup);
        }

        public static int UpdateAccountGroup(AccountGroup theAccountGroup)
        {
            return AccountGroupDataAccess.GetInstance.UpdateAccountGroup(theAccountGroup);
        }

        public static int DeleteAccountGroup(AccountGroup theAccountGroup)
        {
            return AccountGroupDataAccess.GetInstance.DeleteAccountGroup(theAccountGroup);
        }
        #endregion
    }
}
