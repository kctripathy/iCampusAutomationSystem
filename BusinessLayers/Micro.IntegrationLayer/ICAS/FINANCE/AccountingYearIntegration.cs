using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.ICAS.FINANCE;
using Micro.Objects.ICAS.FINANCE;

namespace Micro.IntegrationLayer.ICAS.FINANCE
{
    public partial class AccountingYearIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static AccountingYear DataRowToObject(DataRow dr)
        {
            AccountingYear TheAccountingYear = new AccountingYear();

            TheAccountingYear.AccountingYearID = int.Parse(dr["AccountingYearID"].ToString());
            TheAccountingYear.AccountingYearDescription = dr["AccountingYearDescription"].ToString();
            TheAccountingYear.YearStartDate = DateTime.Parse(dr["YearStartDate"].ToString()).ToString(MicroConstants.DateFormat);
            TheAccountingYear.YearEndDate = DateTime.Parse(dr["YearEndDate"].ToString()).ToString(MicroConstants.DateFormat);

            return TheAccountingYear;
        }
        //public static AccountingYear DataRowToObject(DataRow dr)
        //{
        //    AccountingYear TheAccountingYear = new AccountingYear();

        //    TheAccountingYear.ACC_YEAR_ID = int.Parse(dr["ACC_YEAR_ID"].ToString());
        //    TheAccountingYear.CURRENT_START_DATE = dr["CURRENT_START_DATE"].ToString();
        //    TheAccountingYear.CURRENT_END_DATE = dr["CURRENT_END_DATE"].ToString();
        //    TheAccountingYear.PREVIOUS_START_DATE = dr["PREVIOUS_START_DATE"].ToString();
        //    TheAccountingYear.PREVIOUS_END_DATE = dr["PREVIOUS_END_DATE"].ToString();
        //    TheAccountingYear.BOOK_CLOSING_FLAG = dr["BOOK_CLOSING_FLAG"].ToString();
        //    TheAccountingYear.YEAR_CLOSING_FLAG = dr["YEAR_CLOSING_FLAG"].ToString();
        //    TheAccountingYear.STATUS_FLAG = dr["STATUS_FLAG"].ToString();
        //    TheAccountingYear.MOD_DATE = dr["MOD_DATE"].ToString();
        //    TheAccountingYear.AUTH_CODE = dr["AUTH_CODE"].ToString();
        //    TheAccountingYear.AddedBy = int.Parse(dr["AddedBy"].ToString());
        //    TheAccountingYear.SocietyID = int.Parse(dr["SocietyID"].ToString());
        //    //TheAccountingYear.SlNo = int.Parse(dr["SlNo"].ToString());
        //    //TheAccountingYear.ForMonth = dr["ForMonth"].ToString();
        //    return TheAccountingYear;
        //}

        public static AccountingYear DataRowToObjectForMonth(DataRow dr)
        {
            AccountingYear TheAccountingYear = new AccountingYear();

            TheAccountingYear.SlNo = int.Parse(dr["SlNo"].ToString());
            TheAccountingYear.ForMonth = dr["ForMonth"].ToString();

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

        public static int GetAccountingYearIDByFlag(string flag)
        {
            DataRow AccountingYearRow = AccountingYearDataAccess.GetInstance.GetAccountingYearByFlag(flag);

            AccountingYear TheAccountingYear = DataRowToObject(AccountingYearRow);
            int AccountsYearID = TheAccountingYear.ACC_YEAR_ID;

            return AccountsYearID;
        }

        public static List<AccountingYear> GetAllMonthsFromCurrentAccountYear()
        {
            List<AccountingYear> AccountingYearList = new List<AccountingYear>();

            DataTable AccountingYearTable = new DataTable();
            AccountingYearTable = AccountingYearDataAccess.GetInstance.GetAllMonthsFromCurrentAccountYear();

            foreach (DataRow dr in AccountingYearTable.Rows)
            {
                AccountingYear TheAccountingYear = DataRowToObjectForMonth(dr);


                AccountingYearList.Add(TheAccountingYear);
            }
            return AccountingYearList;
        }
        #endregion

        #region Methods & Implementation for Account Book Close

        public static AccountBookClose DataRow(DataRow dr)
        {
            AccountBookClose TheAccountBookClose = new AccountBookClose();

            TheAccountBookClose.RecordNumber = int.Parse(dr["RecordNumber"].ToString());
            TheAccountBookClose.AccountYearID = int.Parse(dr["AccountYearID"].ToString());
            TheAccountBookClose.AccountYearMonth = dr["AccountYearMonth"].ToString();
            TheAccountBookClose.IsBookClosed = char.Parse(dr["IsBookClosed"].ToString());
            if (dr["BookCloseDateTime"] != DBNull.Value)
            {
                TheAccountBookClose.BookCloseDateTime = DateTime.Parse(dr["BookCloseDateTime"].ToString()).ToString(MicroConstants.DateFormat);
            }
            TheAccountBookClose.BookClosedByUserID = dr["BookClosedByUserID"] != DBNull.Value ? int.Parse(dr["BookClosedByUserID"].ToString()) : 0;
            TheAccountBookClose.AuthorisationID = dr["AuthorisationID"] != DBNull.Value ? int.Parse(dr["AuthorisationID"].ToString()) : 0;
            TheAccountBookClose.SocietyID = int.Parse(dr["SocietyID"].ToString());
            TheAccountBookClose.OfficeID = int.Parse(dr["OfficeID"].ToString());
            return TheAccountBookClose;
        }

        public static List<AccountBookClose> GetMonthByOfficeId(int OfficeId)
        {
            List<AccountBookClose> AccountBookCloseList = new List<AccountBookClose>();
            DataTable AccountingYeartable = AccountingYearDataAccess.GetInstance.GetMonthByOfficeId(OfficeId);

            foreach (DataRow dr in AccountingYeartable.Rows)
            {
                AccountBookClose TheAccountBookClose = DataRow(dr);
                AccountBookCloseList.Add(TheAccountBookClose);
            }
            return AccountBookCloseList;
        }

        #endregion
    }
}





