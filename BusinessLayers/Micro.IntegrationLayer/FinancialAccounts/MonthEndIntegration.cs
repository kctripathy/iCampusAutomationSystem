using System;
using System.Collections.Generic;
using Micro.Objects.FinancialAccounts;
using System.Data;
using Micro.DataAccessLayer.FinancialAccounts;

namespace Micro.IntegrationLayer.FinancialAccounts
{
    public partial class MonthEndIntegration
    {
        #region Declaration
        #endregion

        #region Methods & Implementation
        public static MonthEnd DataRowToObject(DataRow dr)
        {
            MonthEnd TheMonthEnd = new MonthEnd
            {
                MonthEndID = int.Parse(dr["MonthEndID"].ToString()),
                DateFrom = DateTime.Parse(dr["DateFrom"].ToString()).ToString(Micro.Commons.MicroConstants.DateFormat),
                DateTo = DateTime.Parse(dr["DateTo"].ToString()).ToString(Micro.Commons.MicroConstants.DateFormat),
                GraceDays = int.Parse(dr["GraceDays"].ToString()),
                ClosingDate = DateTime.Parse(dr["ClosingDate"].ToString()).ToString(Micro.Commons.MicroConstants.DateFormat),
                Status = bool.Parse(dr["Status"].ToString()),
                OfficeID = int.Parse(dr["OfficeID"].ToString()),
                OfficeName = dr["OfficeName"].ToString()
            };

            return TheMonthEnd;
        }

        public static List<MonthEnd> GetMonthEndList(bool allOffices = false, bool showDeleted = false)
        {
            List<MonthEnd> MonthEndList = new List<MonthEnd>();

            DataTable MonthEndTable = MonthEndDataAccess.GetInstance.GetMonthEndList(allOffices, showDeleted);

            foreach (DataRow dr in MonthEndTable.Rows)
            {
                MonthEnd TheMonthEnd = DataRowToObject(dr);

                MonthEndList.Add(TheMonthEnd);
            }

            return MonthEndList;
        }

        public static List<MonthEnd> GetMonthEndList(string officeIDs, bool allOffices = false, bool showDeleted = false)
        {
            List<MonthEnd> MonthEndList = new List<MonthEnd>();

            DataTable MonthEndTable = MonthEndDataAccess.GetInstance.GetMonthEndList(officeIDs, allOffices, showDeleted);

            foreach (DataRow dr in MonthEndTable.Rows)
            {
                MonthEnd TheMonthEnd = DataRowToObject(dr);

                MonthEndList.Add(TheMonthEnd);
            }

            return MonthEndList;
        }

        #endregion
    }
}
