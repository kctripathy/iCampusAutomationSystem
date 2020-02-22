using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects;
using Micro.BusinessLayer.FinancialAccounts;
using Micro.Framework.ReadXML;
using System.Linq;
using System.Drawing;
using Micro.Objects.FinancialAccounts;

namespace Micro.WebApplication.MicroERP.FINANCE
{
	/// <summary>
	/// Debit Vouchers for recording Payments
	/// </summary>
	/// <author>Tanmaya Kumar Jena</author>
	/// <date>24-Aug-2012</date>

	public partial class DebitVouchers : BasePage
	{
		#region Declartion
		protected static class PageVariables
		{
			public static List<DebitAccountEntry> theDebitAccountEntrylist = new List<DebitAccountEntry>();
			public static DebitAccountEntry theDebitAccountEntry;
			public static decimal TotalDebitAmount;
			public static int index = 0;
		}

		public class DebitAccountEntry
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
				PageVariables.theDebitAccountEntrylist = new List<DebitAccountEntry>();
				FillAccounts();
				FillComboEntryType();
				btn_UpdateEntry.Visible = false;
			}
		}

		protected void btn_AddEntry_Click(object sender, EventArgs e)
		{
			if (PageVariables.theDebitAccountEntrylist.Count == 0)
			{
				AddEntryToList(ddl_Account.Text, decimal.Parse(txt_Amount.Text), 0);
				AddEntryToList("Cash", 0, decimal.Parse(txt_Amount.Text));
			}
			else
			{
				AddEntryToList(ddl_Account.Text, decimal.Parse(txt_Amount.Text), 0);
			}
			ResetCashAccount_CreditAmount();
			ResetControls();
		}

		protected void btn_UpdateEntry_Click(object sender, EventArgs e)
		{
			PageVariables.theDebitAccountEntry.Debit = decimal.Parse(txt_Amount.Text);
			gView_DebitVoucher.Rows[PageVariables.index].Cells[1].Text = txt_Amount.Text;
			ResetCashAccount_CreditAmount();
			ResetControls();
		}

		protected void btn_Submit_Click(object sender, EventArgs e)
		{
			int ProcReturnValue = 0;
			ProcReturnValue = InsertRecord();

			if (ProcReturnValue > 0)
			{
				InsertVoucherDetails(ProcReturnValue);
			}
		}

		protected void gView_DebitVoucher_RowEditing(object sender, GridViewEditEventArgs e)
		{
			e.Cancel = true;
		}

		protected void gView_DebitVoucher_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			e.Cancel = true;
		}

		protected void gView_DebitVoucher_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			PageVariables.index = Convert.ToInt32(e.CommandArgument);
			string account = gView_DebitVoucher.Rows[PageVariables.index].Cells[0].Text;

			PageVariables.theDebitAccountEntry = PageVariables.theDebitAccountEntrylist.Where(debitVoucher => debitVoucher.AccountName == account).SingleOrDefault();

			if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
			{
				populateDebitVoucher(PageVariables.index);
			}
			else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
			{
				PageVariables.theDebitAccountEntrylist.Remove(PageVariables.theDebitAccountEntry);
			}
			ResetCashAccount_CreditAmount();
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
			btn_UpdateEntry.Visible = false;
			ddl_Account.Enabled = true;
			ddl_Account.SelectedIndex = 0;
			txt_Amount.Text = string.Empty;
		}

		private void ResetCashEntry()
		{
			//foreach (ListViewItem TheItem in listView_DebitVoucher.Items)
			//{

			//}
		}

		public bool ValidateFormFields()
		{
			string UserMessage = string.Empty;
			bool ReturnValue = true;
			if (ddl_Account.SelectedIndex == 0)
			{
				UserMessage = ReadXML.GetGeneralMessage("SELECTION_CAN_NOT_EMPTY", "Account");
				//lbl_TheMessage.Text = UserMessage;
				ReturnValue = false;

				ReturnValue = false;
			}

			return ReturnValue;
		}

		private void AddEntryToList(string account, decimal debit, decimal credit)
		{
			List<DebitAccountEntry> ThisDebitAccountEntryList = PageVariables.theDebitAccountEntrylist;

			DebitAccountEntry sameDebitAccounEntry = (from debitAccount in ThisDebitAccountEntryList
													  where debitAccount.AccountName == account
													  select debitAccount).SingleOrDefault();

			DebitAccountEntry theDebitAccountEntry = new DebitAccountEntry();
			if (sameDebitAccounEntry != null)
			{
				sameDebitAccounEntry.Debit = sameDebitAccounEntry.Debit + debit;
			}
			else
			{
				theDebitAccountEntry.AccountName = account;
				theDebitAccountEntry.Debit = debit;
				theDebitAccountEntry.Credit = credit;

				if (ThisDebitAccountEntryList.Count > 1)
				{
					ThisDebitAccountEntryList.Insert(ThisDebitAccountEntryList.Count - 1, theDebitAccountEntry);
				}
				else
				{
					ThisDebitAccountEntryList.Add(theDebitAccountEntry);
				}
			}
			gView_DebitVoucher.DataSource = ThisDebitAccountEntryList;
			gView_DebitVoucher.DataBind();
		}

		private void ResetCashAccount_CreditAmount()
		{
			PageVariables.TotalDebitAmount = 0;
			PageVariables.TotalDebitAmount = PageVariables.theDebitAccountEntrylist.Select(thedebitAccountEntry => thedebitAccountEntry.Debit).Sum();
			DebitAccountEntry LastDebitAccount = PageVariables.theDebitAccountEntrylist.LastOrDefault();
			LastDebitAccount.Credit = PageVariables.TotalDebitAmount;
			gView_DebitVoucher.DataSource = PageVariables.theDebitAccountEntrylist;
			gView_DebitVoucher.DataBind();

			HighlightCashAccountRow();
		}

		private void HighlightCashAccountRow()
		{
			foreach (GridViewRow theRow in gView_DebitVoucher.Rows)
			{
				if (theRow.Cells[0].Text == "Cash")
				{
					theRow.BackColor = Color.LightYellow;
					theRow.ForeColor = Color.Red;
					theRow.Cells[3].Visible = false;
					theRow.Cells[4].Visible = false;
				}
			}
		}

		private void populateDebitVoucher(int rowIndex)
		{
			ddl_Account.Text = gView_DebitVoucher.Rows[rowIndex].Cells[0].Text;
			txt_Amount.Text = gView_DebitVoucher.Rows[rowIndex].Cells[1].Text;

			btn_UpdateEntry.Visible = true;
			ddl_Account.Enabled = true;
		}

		private int InsertVoucherDetails(int voucherID)
		{
			int ReturnValue = 0;

			List<VoucherDetails> VoucherDetailsList = new List<VoucherDetails>();

			foreach (GridViewRow TheRow in gView_DebitVoucher.Rows)
			{
				VoucherDetails TheVoucherDetails = new VoucherDetails();
				{
					TheVoucherDetails.VoucherID = voucherID;

					if (TheRow.Cells[0].Text != "Cash")
					{
						TheVoucherDetails.VoucherAmount = decimal.Parse(TheRow.Cells[1].Text);
						TheVoucherDetails.VoucherEntryType = MicroEnums.GetStringValue(MicroEnums.VoucherEntryType.DebitSide);
					}
					else
					{
						TheVoucherDetails.VoucherAmount = PageVariables.TotalDebitAmount;
						TheVoucherDetails.VoucherEntryType = MicroEnums.GetStringValue(MicroEnums.VoucherEntryType.CreditSide);
					}
					TheVoucherDetails.AccountLedgerDescription = TheRow.Cells[0].Text;
				}

				VoucherDetailsList.Add(TheVoucherDetails);
			}
			ReturnValue = VoucherManagement.GetInstance.InsertVoucherDetails(VoucherDetailsList);
			return ReturnValue;
		}

		public int InsertRecord()
		{
			int ReturnValue = 0;

			Voucher TheVoucher = new Voucher();

			TheVoucher.VoucherCode = "mlfl-1234";
			TheVoucher.VoucherType = ddl_EntryType.Text;
			TheVoucher.VoucherDate = txt_DebitDate.Text;
			TheVoucher.VoucherNarration = txt_Narration.Text;
			TheVoucher.IsPosted = true;

			ReturnValue = VoucherManagement.GetInstance.InsertVouchers(TheVoucher);
			return ReturnValue;
		}
		#endregion
	}
}