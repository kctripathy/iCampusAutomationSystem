using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.FinancialAccounts;
using Micro.Objects.FinancialAccounts;

namespace Micro.IntegrationLayer.FinancialAccounts
{
    public partial class AccountingYearIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation

        public static AccountingYear DataRowToObject(DataRow dr)
        {
            AccountingYear TheAccountingYear = new AccountingYear();

            //TheAccountingYear.AccountingYearID = int.Parse(dr["AccountingYearID"].ToString());
            //TheAccountingYear.AccountingYearDescription = dr["AccountingYearDescription"].ToString();
            //TheAccountingYear.YearStartDate = DateTime.Parse(dr["YearStartDate"].ToString()).ToString(MicroConstants.DateFormat);
            //TheAccountingYear.YearEndDate = DateTime.Parse(dr["YearEndDate"].ToString()).ToString(MicroConstants.DateFormat);

            TheAccountingYear.AccountingYearID = int.Parse(dr["ACC_YEAR_ID"].ToString());
            TheAccountingYear.AccountingYearDescription = dr["ACC_YEAR_CODE"].ToString();
            TheAccountingYear.YearStartDate = DateTime.Parse(dr["CURRENT_START_DATE"].ToString()).ToString(MicroConstants.DateFormat);
            TheAccountingYear.YearEndDate = DateTime.Parse(dr["CURRENT_END_DATE"].ToString()).ToString(MicroConstants.DateFormat);

            return TheAccountingYear;
        }

        public static List<AccountingYear> GetAccountingYearList(string searchText)
        {
            List<AccountingYear> AccountingYearList = new List<AccountingYear>();

            DataTable AccountingYearTable = new DataTable();
            AccountingYearTable = AccountingYearDataAccess.GetInstance.GetAccountingYearList(searchText);

            foreach (DataRow dr in AccountingYearTable.Rows)
            {
                AccountingYear TheAccountingYear = DataRowToObject(dr);


                AccountingYearList.Add(TheAccountingYear);
            }

            return AccountingYearList;
        }

        public static int InsertAccountingYear(AccountingYear theAccountingYear)
        {
            return AccountingYearDataAccess.GetInstance.InsertAccountingYear(theAccountingYear);
        }

        public static int UpdateAccountingYear(AccountingYear theAccountingYear)
        {
            return AccountingYearDataAccess.GetInstance.UpdateAccountingYear(theAccountingYear);
        }

        public static int DeleteAccountingYear(AccountingYear theAccountingYear)
        {
            return AccountingYearDataAccess.GetInstance.DeleteAccountingYear(theAccountingYear);
        }

        public static AccountingYear GetAccountingYearById(int recordId)
        {
            DataRow AccountingYearRow = AccountingYearDataAccess.GetInstance.GetAccountingYearById(recordId);

            AccountingYear TheAccountingYear = DataRowToObject(AccountingYearRow);

            return TheAccountingYear;
        }
        #endregion
    }
}





