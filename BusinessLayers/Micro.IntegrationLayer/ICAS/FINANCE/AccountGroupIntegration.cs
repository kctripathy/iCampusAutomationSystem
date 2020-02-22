using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.IntegrationLayer.ICAS.FINANCE
{
   public partial class AccountGroupIntegration
   {
       #region Declaration
       #endregion

       #region Methods & Implementations
       public static AccountGroup DataRowToObject(DataRow dr)
       {
           AccountGroup TheAccountGroup = new AccountGroup();

           TheAccountGroup.AccountGroupID = int.Parse(dr["AccountGroupID"].ToString());
           TheAccountGroup.AccountGroupDescription = (dr["AccountGroupDescription"].ToString());
           TheAccountGroup.AccountGroupAlias = (dr["AccountGroupAlias"].ToString());
           TheAccountGroup.AccountGroupParentID = int.Parse(dr["AccountGroupParentID"].ToString());
           //TheAccountGroup.PrimaryGroupDescription = dr["PrimaryGroupDescription"].ToString();
           TheAccountGroup.AccountGroupNature = dr["AccountGroupNature"].ToString();
           TheAccountGroup.IsUserDefined = bool.Parse(dr["IsUserDefined"].ToString());

           return TheAccountGroup;
       }

       public static List<AccountGroup> GetAccountGroupList()
       {
           List<AccountGroup> AccountGroupList = new List<AccountGroup>();

           DataTable AccountGroupTable = new DataTable();
           AccountGroupTable = AccountGroupDataAccess.GetInstance.GetAccountGroupList();

           foreach (DataRow dr in AccountGroupTable.Rows)
           {
               AccountGroup TheAccountGroup = DataRowToObject(dr);

               AccountGroupList.Add(TheAccountGroup);
           }

           return AccountGroupList;
       }
       public static List<AccountGroup> GetMasterAccountGroupList()
       {
           List<AccountGroup> AccountGroupList = new List<AccountGroup>();

           DataTable AccountGroupTable = new DataTable();
           AccountGroupTable = AccountGroupDataAccess.GetInstance.GetMasterAccountGroupList();

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
