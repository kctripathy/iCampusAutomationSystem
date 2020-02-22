using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Micro.Commons;
using Micro.Objects;
using Micro.BusinessLayer.FinancialAccounts;
using Micro.BusinessLayer.Administration;
using Micro.Framework.ReadXML;
using System.Linq;
using System.Drawing;

namespace Micro.WebApplication.MicroERP.FINANCE
{
	/// <summary>
	/// Credit Vouchers for recording Receipts
	/// </summary>
	/// <author>Subrat Swain</author>
	/// <date>24-Aug-2012</date>

	public partial class CreditVouchers : BasePage
	{
		#region Declartion
		protected static class PageVariables
		{
			public static List<CreditAccountEntry> theCreditAccountEntrylist = new List<CreditAccountEntry>();
		}

		public class CreditAccountEntry
		{
			public string AccountName
			{
				get;
				set;
			}

			public decimal Debit
			{
				get;
				set;
			}

			public decimal Credit
			{
				get;
				set;
			}
		}
		#endregion
		
		#region events
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				PageVariables.theCreditAccountEntrylist = new List<CreditAccountEntry>();
				FillAccounts();
				FillComboEntryType();
			}
		}
		
		protected void btn_AddEntry_Click(object sender, EventArgs e)
		{
			if (PageVariables.theCreditAccountEntrylist.Count == 0)
			{
				AddEntryToList(ddl_Account.Text, decimal.Parse(txt_Amount.Text), 0);
				AddEntryToList("Cash", 0, decimal.Parse(txt_Amount.Text));
			}
			else
			{
				AddEntryToList(ddl_Account.Text, decimal.Parse(txt_Amount.Text), 0);
			}
			ResetCashAccount_CreditAmount();
			HighlightCashAccountRow();
		}
		#endregion

		#region Methods & Implementation

		private void FillComboEntryType()
		{
			ddl_EntryType.DataSource = CommonKeyManagement.GetInstance.GetCommonKeyListByName(MicroEnums.CommonKeyNames.VoucherEntryType.GetStringValue());
			ddl_EntryType.DataTextField = CommonKeyManagement.GetInstance.DisplayMember;
			ddl_EntryType.DataBind();
		}

		private void FillAccounts()
		{
			List<AccountLedger> ThisAccountLedgerList = AccountLedgerManagement.GetInstance.GetNonCaseAccountLedgerList();

			ddl_Account.DataSource = ThisAccountLedgerList;
			ddl_Account.DataTextField = AccountLedgerManagement.GetInstance.DisplayMember;
			ddl_Account.DataBind();
			ddl_Account.Items.Insert(0, new ListItem("--Select--"));
		}
		
		private void ResetControls()
		{
			txt_Amount.Text = string.Empty;
			ddl_Account.SelectedIndex = 0;
		}

		private void ResetCashEntry()
		{
			//foreach (ListViewItem TheItem in listView_CreditVoucher.Items)
			//{

			//}
		}

		public bool ValidateFormFields()
		{
			string UserMessage = string.Empty;
			bool ReturnValue = true;
			if (ddl_Account.SelectedIndex == 0)
			{
				UserMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY","Account");
				lbl_TheMessage.Text = UserMessage;
				ReturnValue = false;

				ReturnValue = false;
			}

			return ReturnValue;
		}

		private void AddEntryToList(string account, decimal debit, decimal credit)
		{
			List<CreditAccountEntry> ThisCreditAccountEntryList = PageVariables.theCreditAccountEntrylist;

			CreditAccountEntry sameCreditAccounEntry = (from creditAccount in ThisCreditAccountEntryList
													  where creditAccount.AccountName == account
													  select creditAccount).SingleOrDefault();

			CreditAccountEntry theCreditAccountEntry = new CreditAccountEntry();
			if (sameCreditAccounEntry != null)
			{
				sameCreditAccounEntry.Debit = sameCreditAccounEntry.Debit + debit;
			}
			else
			{
				theCreditAccountEntry.AccountName = account;
				theCreditAccountEntry.Debit = debit;
				theCreditAccountEntry.Credit = credit;

				if (ThisCreditAccountEntryList.Count > 1)
				{
					ThisCreditAccountEntryList.Insert(ThisCreditAccountEntryList.Count - 1, theCreditAccountEntry);
				}
				else
				{
					ThisCreditAccountEntryList.Add(theCreditAccountEntry);
				}
			}
			GridView1.DataSource = ThisCreditAccountEntryList;
			GridView1.DataBind();
		}

		private void ResetCashAccount_CreditAmount()
		{
			decimal TotalCredit = 0;
			TotalCredit = PageVariables.theCreditAccountEntrylist.Select(thecreditAccountEntry => thecreditAccountEntry.Debit).Sum();

			CreditAccountEntry LastCreditAccount = PageVariables.theCreditAccountEntrylist.LastOrDefault();
			LastCreditAccount.Credit = TotalCredit;

			GridView1.DataSource = PageVariables.theCreditAccountEntrylist;
			GridView1.DataBind();
		}

		private void HighlightCashAccountRow()
		{
			foreach (GridViewRow theRow in GridView1.Rows)
			{
				if (theRow.Cells[0].Text == "Cash")
				{
					theRow.BackColor = Color.Yellow;
					theRow.ForeColor = Color.Red;
				}
			}
		}
	
		#endregion

		
	}
}