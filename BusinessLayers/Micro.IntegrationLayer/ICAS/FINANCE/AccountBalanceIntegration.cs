using System;
using System.Collections.Generic;
using System.Data;
using Micro.DataAccessLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.IntegrationLayer.ICAS.FINANCE
{
    public partial class AccountBalanceIntegration
    {
        #region Declaration
        #endregion
        #region Methods & Implementations
        public static AccountBalance DataRowToObject(DataRow dr)
        {
            AccountBalance TheAccountBalance = new AccountBalance();

            TheAccountBalance.AccountsYearID = int.Parse(dr["AccountsYearID"].ToString());
            TheAccountBalance.FinYearStartDate = (dr["FinYearStartDate"].ToString());
            TheAccountBalance.FinYearCloseDate = (dr["FinYearCloseDate"].ToString());
            TheAccountBalance.AccountsID = int.Parse(dr["AccountsID"].ToString());
            TheAccountBalance.AccountDescription = dr["AccountDescription"].ToString();
            TheAccountBalance.FinYearOpeningBalance = decimal.Parse(dr["FinYearOpeningBalance"].ToString());
            TheAccountBalance.FinYearOpeningBalanceType = dr["FinYearOpeningBalanceType"].ToString();
            TheAccountBalance.Total_DB_Balance_Month_04 = dr["Total_DB_Balance_Month_04"] != DBNull.Value ? decimal.Parse(dr["Total_DB_Balance_Month_04"].ToString()) : 0;
            TheAccountBalance.Total_CR_Balance_Month_04 = dr["Total_CR_Balance_Month_04"] != DBNull.Value ? decimal.Parse(dr["Total_CR_Balance_Month_04"].ToString()) : 0;
            TheAccountBalance.Total_DEBIT_Transactions = dr["Total_DEBIT_Transactions"] != DBNull.Value ? decimal.Parse(dr["Total_DEBIT_Transactions"].ToString()) : 0;
            TheAccountBalance.Total_CREDIT_Transactions = dr["Total_CREDIT_Transactions"] != DBNull.Value ? decimal.Parse(dr["Total_CREDIT_Transactions"].ToString()) : 0;
            TheAccountBalance.AuthorisationID = dr["AuthorisationID"] != DBNull.Value ? int.Parse(dr["AuthorisationID"].ToString()) : 0;
            TheAccountBalance.SocietyID = int.Parse(dr["SocietyID"].ToString());
            TheAccountBalance.OfficeID = int.Parse(dr["OfficeID"].ToString());

            return TheAccountBalance;
        }

        public static List<AccountBalance> GetAccountsBalanceListByAccountsYearID(int accountsYearID, int officeID)
        {
            List<AccountBalance> AccountBalanceList = new List<AccountBalance>();

            DataTable AccountBalanceTable = new DataTable();
            AccountBalanceTable = AccountBalanceDataAccess.GetInstance.GetAccountsBalanceListByAccountsYearID(accountsYearID, officeID);

            foreach (DataRow dr in AccountBalanceTable.Rows)
            {
                AccountBalance TheAccountBalance = DataRowToObject(dr);

                AccountBalanceList.Add(TheAccountBalance);
            }

            return AccountBalanceList;
        }

        public static int UpdateFinyearOpeningBalance(AccountBalance theAccountBalance)
        {
            return AccountBalanceDataAccess.GetInstance.UpdateFinyearOpeningBalance(theAccountBalance);
        }
        #endregion
    }
}
