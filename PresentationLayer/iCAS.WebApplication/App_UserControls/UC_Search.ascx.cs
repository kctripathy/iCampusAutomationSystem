using System;
using System.Web.UI.WebControls;
using Micro.Commons;
using System.Web.UI;
using System.ComponentModel;

public partial class UC_Search : System.Web.UI.UserControl
{
	#region Declaration
	/// <summary>
	/// Event fires when user clicks on "Go" button
	/// </summary>
	public event EventHandler OnButtonClick;

	public string SearchLabel
	{
		set
		{
			lbl_SearchTitle.Text = value;
		}
		get
		{
			return lbl_SearchTitle.Text;
		}
	}

	public string SearchText
	{
		get
		{
			return txt_SearchText.Text;
		}
	}

	public string SearchField
	{
		get
		{
			return ddl_SearchField.SelectedValue;
		}
	}
	

	public string SearchOperator
	{
		get
		{
			return ddl_SearchOperator.SelectedValue;
		}
	}

	public string SearchResultCount
	{
		set
		{
			lbl_SearchResult.Text = string.Format("{0} record(s) found.", value);
		}
	}

//Property Declared for GoButton Cause validation
	public virtual bool GoButtonCausesValidation
	{

		set
		{
			btn_SearchNow.CausesValidation = value;
		}
		get 
		{
			return btn_SearchNow.CausesValidation;
		}
	
	}

	public string SearchWhat
	{
		set
		{
            // Populate the dropdown list for the files to search studentt
            if (value.Equals(MicroEnums.SearchForm.Book.ToString()))
            {
                ddl_SearchField.Items.Clear();
                foreach (MicroEnums.SearchBook theString in Enum.GetValues(typeof(MicroEnums.SearchBook)))
                {
                    string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

                    ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
                }
            }

			// Populate the dropdown list for the files to search studentt
			if (value.Equals(MicroEnums.SearchForm.Student.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchStudent theString in Enum.GetValues(typeof(MicroEnums.SearchStudent)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
            //if (value.Equals(MicroEnums.SearchForm.Customer.ToString()))
            //{
            //    ddl_SearchField.Items.Clear();
            //    foreach (MicroEnums.SearchCustomer theString in Enum.GetValues(typeof(MicroEnums.SearchCustomer)))
            //    {
            //        string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

            //        ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
            //    }
            //}
            // Populate the dropdown list for the files to search dc collector
            if (value.Equals(MicroEnums.SearchForm.DCCollector.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchDCCollector theString in Enum.GetValues(typeof(MicroEnums.SearchDCCollector)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			// Populate the dropdown list for the files to search Employee
			if (value.Equals(MicroEnums.SearchForm.Employee.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchEmployee theString in Enum.GetValues(typeof(MicroEnums.SearchEmployee)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			// Populate the dropdown list for the files to search department
			if (value.Equals(MicroEnums.SearchForm.Department.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchDepartment theString in Enum.GetValues(typeof(MicroEnums.SearchDepartment)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			// Populate the dropdown list for the files to search designation
			if (value.Equals(MicroEnums.SearchForm.Designation.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchDesignation theString in Enum.GetValues(typeof(MicroEnums.SearchDesignation)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			// Populate the dropdown list for the files to search Holiday
			if (value.Equals(MicroEnums.SearchForm.Holiday.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchHoliday theString in Enum.GetValues(typeof(MicroEnums.SearchHoliday)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			// Populate the dropdown list for the files to search Office
			if (value.Equals(MicroEnums.SearchForm.Office.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchOffice theString in Enum.GetValues(typeof(MicroEnums.SearchOffice)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			// Populate the dropdown list for the files to search dc account
			if (value.Equals(MicroEnums.SearchForm.DCAccount.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchDCAccount theString in Enum.GetValues(typeof(MicroEnums.SearchDCAccount)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			// Populate the dropdown list for the files to search dc device
			if (value.Equals(MicroEnums.SearchForm.DCDevice.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchDCDevice theString in Enum.GetValues(typeof(MicroEnums.SearchDCDevice)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			// Populate the dropdown list for the files to search DcDeviceAllotment
			if (value.Equals(MicroEnums.SearchForm.DCDeviceAllotments.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchDCDeviceAllotment theString in Enum.GetValues(typeof(MicroEnums.SearchDCDeviceAllotment)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}


			// Populate the dropdown list for the files to search dc account receipt
			if (value.Equals(MicroEnums.SearchForm.DCAccountReceipt.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchDCAccountReceipt theString in Enum.GetValues(typeof(MicroEnums.SearchDCAccountReceipt)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			// Populate the dropdown list for the files to search field force
			if (value.Equals(MicroEnums.SearchForm.FieldForce.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchFieldForce theString in Enum.GetValues(typeof(MicroEnums.SearchFieldForce)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}


			// Populate the dropdown list for the files to search Account
			if (value.Equals(MicroEnums.SearchForm.Accounts.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchAccount theString in Enum.GetValues(typeof(MicroEnums.SearchAccount)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			if (value.Equals(MicroEnums.SearchForm.PrematurityApplication.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchPrematurityApplication theString in Enum.GetValues(typeof(MicroEnums.SearchPrematurityApplication)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			if (value.Equals(MicroEnums.SearchForm.PrematurityPayment.ToString()))
			{
				ddl_SearchField.Items.Clear();

				foreach (MicroEnums.SearchPrematurityPayment theString in Enum.GetValues(typeof(MicroEnums.SearchPrematurityPayment)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());
					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			if (value.Equals(MicroEnums.SearchForm.GuarantorLoanApplication.ToString()))
			{
				ddl_SearchField.Items.Clear();

				foreach (MicroEnums.SearchGuarantorLoanApplication theString in Enum.GetValues(typeof(MicroEnums.SearchGuarantorLoanApplication)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());
					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			if (value.Equals(MicroEnums.SearchForm.GuarantorLoanPayment.ToString()))
			{
				ddl_SearchField.Items.Clear();

				foreach (MicroEnums.SearchGuarantorLoanPayment theString in Enum.GetValues(typeof(MicroEnums.SearchGuarantorLoanPayment)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());
					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			if (value.Equals(MicroEnums.SearchForm.CRMScrolls.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchCRMScrolls theString in Enum.GetValues(typeof(MicroEnums.SearchCRMScrolls)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			if (value.Equals(MicroEnums.SearchForm.CustomerAccountReceipt.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchCustomerAccountReceipt theString in Enum.GetValues(typeof(MicroEnums.SearchCustomerAccountReceipt)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			// Populate the dropdown list for the files to search Mediclaim Application
			if (value.Equals(MicroEnums.SearchForm.MediclaimApplication.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchMediclaimApplication theString in Enum.GetValues(typeof(MicroEnums.SearchMediclaimApplication)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			// Populate the dropdown list for the files to search Mediclaim Approval
			if (value.Equals(MicroEnums.SearchForm.MediclaimApproval.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchMediclaimApproval theString in Enum.GetValues(typeof(MicroEnums.SearchMediclaimApproval)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			// AccountHead
			if (value.Equals(MicroEnums.SearchForm.AccountHead.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchAccountHead theString in Enum.GetValues(typeof(MicroEnums.SearchAccountHead)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
					if (ddl_SearchField.Items.Count.Equals(2))
					{
						break;
					}
				}
			}

			// AccountName
			if (value.Equals(MicroEnums.SearchForm.AccountName.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchAccountName theString in Enum.GetValues(typeof(MicroEnums.SearchAccountName)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			// Shift
			if (value.Equals(MicroEnums.SearchForm.Shift.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchShift theString in Enum.GetValues(typeof(MicroEnums.SearchShift)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}


			// AttendanceAmendment
			if (value.Equals(MicroEnums.SearchForm.AttendanceAmendment.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchAttendanceAmmendment theString in Enum.GetValues(typeof(MicroEnums.SearchAttendanceAmmendment)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			// AttendanceApplication
			if (value.Equals(MicroEnums.SearchForm.AttendanceApplication.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchAttendanceApplication theString in Enum.GetValues(typeof(MicroEnums.SearchAttendanceApplication)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}

			// AccountTransaction
			if (value.Equals(MicroEnums.SearchForm.AccountTransaction.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchAccountTransaction theString in Enum.GetValues(typeof(MicroEnums.SearchAccountTransaction)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			//User Log
			if (value.Equals(MicroEnums.SearchForm.UserLog.ToString()))
			{
				ddl_SearchField.Items.Clear();
				foreach (MicroEnums.SearchErrorLog theString in Enum.GetValues(typeof(MicroEnums.SearchErrorLog)))
				{
					string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

					ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
				}
			}
			////Item Group
			//if (value.Equals(MicroEnums.SearchForm.ItemGroup.ToString()))
			//{
			//	ddl_SearchField.Items.Clear();
			//	foreach (MicroEnums.SearchItemGroup theString in Enum.GetValues(typeof(MicroEnums.SearchItemGroup)))
			//	{
			//		string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

			//		ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
			//	}
			//}
			////Item
			//if (value.Equals(MicroEnums.SearchForm.Item.ToString()))
			//{
			//	ddl_SearchField.Items.Clear();
			//	foreach (MicroEnums.SearchItem theString in Enum.GetValues(typeof(MicroEnums.SearchItem)))
			//	{
			//		string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

			//		ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
			//	}
			//}

			////ItemIngredient
			//if (value.Equals(MicroEnums.SearchForm.ItemIngredient.ToString()))
			//{
			//	ddl_SearchField.Items.Clear();
			//	foreach (MicroEnums.SearchIngredient theString in Enum.GetValues(typeof(MicroEnums.SearchIngredient)))
			//	{
			//		string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

			//		ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
			//	}
			//}

			////Guest
			//if (value.Equals(MicroEnums.SearchForm.Guests.ToString()))
			//{
			//	ddl_SearchField.Items.Clear();
			//	foreach (MicroEnums.SearchGuest theString in Enum.GetValues(typeof(MicroEnums.SearchGuest)))
			//	{
			//		string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

			//		ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
			//	}
			//}
			////BillDetail
			//if (value.Equals(MicroEnums.SearchForm.BillDetails.ToString()))
			//{
			//	ddl_SearchField.Items.Clear();
			//	foreach (MicroEnums.SearchBillDetail theString in Enum.GetValues(typeof(MicroEnums.SearchBillDetail)))
			//	{
			//		string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

			//		ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
			//	}
			//}
   //         //ItemIssue
   //         if (value.Equals(MicroEnums.SearchForm.ItemIssue.ToString()))
   //         {
   //             ddl_SearchField.Items.Clear();
   //             foreach (MicroEnums.SearchItemIssue theString in Enum.GetValues(typeof(MicroEnums.SearchItemIssue)))
   //             {
   //                 string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

   //                 ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
   //             }
   //         }
   //         //ItemReceive
   //         if (value.Equals(MicroEnums.SearchForm.ItemReceive.ToString()))
   //         {
   //             ddl_SearchField.Items.Clear();
   //             foreach (MicroEnums.SearchItemReceive theString in Enum.GetValues(typeof(MicroEnums.SearchItemReceive)))
   //             {
   //                 string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

   //                 ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
   //             }
   //         }
			////Booking
			//if (value.Equals(MicroEnums.SearchForm.Booking.ToString()))
			//{
			//	ddl_SearchField.Items.Clear();
			//	foreach (MicroEnums.SearchBooking theString in Enum.GetValues(typeof(MicroEnums.SearchBooking)))
			//	{
			//		string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

			//		ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
			//	}
			//}
			////Room
			//if (value.Equals(MicroEnums.SearchForm.Room.ToString()))
			//{
			//	ddl_SearchField.Items.Clear();
			//	foreach (MicroEnums.SearchRoom theString in Enum.GetValues(typeof(MicroEnums.SearchRoom)))
			//	{
			//		string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

			//		ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
			//	}
			//}
			////RoomType
			//if (value.Equals(MicroEnums.SearchForm.RoomType.ToString()))
			//{
			//	ddl_SearchField.Items.Clear();
			//	foreach (MicroEnums.SearchRoomType theString in Enum.GetValues(typeof(MicroEnums.SearchRoomType)))
			//	{
			//		string TheDataTextField = Helpers.SplitCamelCase(theString.ToString());

			//		ddl_SearchField.Items.Add(new ListItem(TheDataTextField, theString.ToString()));
			//	}
			//}
		}

		

	}
	#endregion
	
	#region Events
	protected void btn_SearchNow_Click(object sender, EventArgs e)
	{
		OnClick(sender, e);
	}
	#endregion

	#region Methods & Implementation
	/// <summary>
	/// Raises OnButtonClick event assigned by the client
	/// </summary>
	/// <param name="sender">The object that raises the event.</param>
	/// <param name="e">An System.EventArgs object that contains the event data.</param>
	protected virtual void OnClick(object sender, EventArgs e)
	{
		if (this.OnButtonClick != null)
		{
			this.OnButtonClick(sender, e);
		}
	}
	#endregion
}