using System;
using System.Collections.Generic;
using System.Data;
using Micro.Commons;
using Micro.DataAccessLayer.CustomerRelation;
using Micro.Objects.CustomerRelation;

namespace Micro.IntegrationLayer.CustomerRelation
{
	public partial class AccountsRevivalIntegration
	{
		#region Declaration
		#endregion

		#region Methods & Implementation
		public static AccountsRevival DataRowToObject(DataRow dr)
		{
			AccountsRevival TheAccountsRevival = new AccountsRevival
			{
				RevivalID = int.Parse(dr["RevivalID"].ToString()),
				RevivalDate = DateTime.Parse(dr["RevivalDate"].ToString()).ToString(MicroConstants.DateFormat),
				CustomerAccountID = int.Parse(dr["CustomerAccountID"].ToString()),
				CustomerAccountCode = dr["CustomerAccountCode"].ToString(),
				CustomerName = dr["CustomerName"].ToString(),
				RevivedFromInstallmentNumber = int.Parse(dr["RevivedFromInstallmentNumber"].ToString()),
				TotalInstallmentsRevived = int.Parse(dr["TotalInstallmentsRevived"].ToString()),
				DueDateOfLastPayment = DateTime.Parse(dr["DueDateOfLastPayment"].ToString()).ToString(MicroConstants.DateFormat),
				DueDateOfMaturity = DateTime.Parse(dr["DueDateOfMaturity"].ToString()).ToString(MicroConstants.DateFormat),
				PayToCompany = decimal.Parse(dr["PayToCompany"].ToString()),
				GuaranteedDividend = decimal.Parse(dr["GuaranteedDividend"].ToString()),
				BonusAmount = decimal.Parse(dr["BonusAmount"].ToString()),
				PayByCompany = decimal.Parse(dr["PayByCompany"].ToString())
			};

			return TheAccountsRevival;
		}

		public static List<AccountsRevival> GetAccountsRevivalList(bool allOffices = false, bool showDeleted = false)
		{
			List<AccountsRevival> AccountsRevivalList = new List<AccountsRevival>();
			DataTable AccountsRevivalTable =  AccountsRevivalDataAccess.GetInstance.GetAccountsRevivalList(allOffices, showDeleted);

			foreach(DataRow dr in AccountsRevivalTable.Rows)
			{
				AccountsRevival TheAccountRevival = DataRowToObject(dr);

				AccountsRevivalList.Add(TheAccountRevival);
			}

			return AccountsRevivalList;
		}

		public static int InsertAccountsRevivals(AccountsRevival theAccountsRevival)
		{
			return AccountsRevivalDataAccess.GetInstance.InsertAccountsRevivals(theAccountsRevival);
		}
		#endregion
	}
}
