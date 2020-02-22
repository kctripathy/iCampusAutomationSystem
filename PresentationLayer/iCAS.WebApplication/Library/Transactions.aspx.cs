using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.ICAS.STUDENT;
using Micro.BusinessLayer.ICAS.STUDENT;
using Micro.Framework.ReadXML;
using Micro.Objects.ICAS.STAFFS;
using Micro.BusinessLayer.ICAS.STAFFS;
using Micro.Commons;
using Micro.Objects.ICAS.LIBRARY;
using Micro.BusinessLayer.ICAS.LIBRARY;
using System.Linq;

namespace TCon.iCAS.WebApplication.Library
{
	/// <summary>
	/// Author: Kishor Tripathy, Date: 18-Jan-2018
	/// Library Book Transaction Screen
	/// </summary>
	public partial class Transactions : Page
	{

		public static class PageVar
		{
			public static List<Book> BooksList
			{
				get
				{
					List<Book> TheBooksList = HttpContext.Current.Session["BooksList"] as List<Book>;
					return TheBooksList;
				}
				set
				{
					HttpContext.Current.Session.Add("BooksList", value);
				}
			}

			public static List<Student> StudentsList
			{
				get
				{
					List<Student> TheStudentsList = HttpContext.Current.Session["StudentsList"] as List<Student>;
					return TheStudentsList;
				}
				set
				{
					HttpContext.Current.Session.Add("StudentsList", value);
				}
			}
			public static List<StaffMaster> StaffsList
			{
				get
				{
					List<StaffMaster> TheStaffMasterList = HttpContext.Current.Session["StaffsList"] as List<StaffMaster>;
					return TheStaffMasterList;
				}
				set
				{
					HttpContext.Current.Session.Add("StaffsList", value);
				}
			}

			public static List<BookTransaction> BookTranList
			{
				get
				{
					List<BookTransaction> TheBookTransactionList = HttpContext.Current.Session["BookTranList"] as List<BookTransaction>;
					return TheBookTransactionList;
				}
				set
				{
					HttpContext.Current.Session.Add("BookTranList", value);
				}
			}
		}

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{

			//ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
			//ctrl_Search.SearchWhat = MicroEnums.SearchForm.Book.GetStringValue();
			//requiredFieldValidator_TransactionDate.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Transaction Date");


			if (!IsPostBack)
			{
				string theTransaction = (Page.RouteData.Values["theTransaction"] == null ? "VIEW" : Page.RouteData.Values["theTransaction"].ToString());
				txt_TransactionDate.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
				SetPageTitle(theTransaction);
				ShowHideControls(theTransaction);
				if (rbList_UserType.SelectedIndex == 0)
				{
					FillDropdownUserType_Student();
				}
				else if (rbList_UserType.SelectedIndex == 1)
				{
					FillDropdownUserType_Staff();
				}
				//FillDropdownLibraryBooks();
			}
		}

		protected void lnkBtn_FillBookList_Click(object sender, EventArgs e)
		{
			FillDropdownLibraryBooks(rbList_TransactionType.SelectedValue.ToString());
		}

		protected void lnkBtn_RefreshList_Click(object sender, EventArgs e)
		{

		}

		protected void ddl_Books_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Add a transaction to the list 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_Add2List_Click(object sender, EventArgs e)
		{
			if (ddl_TransactionToFromUser.SelectedIndex == 0 || ddl_Books.SelectedIndex == 0)
			{
				lbl_TheMessage.Text = string.Format("Please select a BOOK and an user ({0}) to perform a transaction!", rbList_UserType.SelectedItem.Value.ToString().ToLower());
				dialog_Message.Show();
				return;
			}
			List<BookTransaction> bookList4Transaction = new List<BookTransaction>();

			BookTransaction theTranObject = new BookTransaction();
			theTranObject.TransactionDate = DateTime.Parse(txt_TransactionDate.Text.ToString());
			theTranObject.TransactionType = rbList_TransactionType.SelectedValue.ToString();
			theTranObject.UserType = rbList_UserType.SelectedValue.ToString();
			theTranObject.BookID = long.Parse(ddl_Books.SelectedValue.ToString());
			theTranObject.AccessionNo = GetAccessionNumber(theTranObject.BookID);
			theTranObject.TitleAccessionNo = ddl_Books.SelectedItem.Text.ToString();
			theTranObject.UserID = int.Parse(ddl_TransactionToFromUser.SelectedValue.ToString());
			theTranObject.UserName = ddl_TransactionToFromUser.SelectedItem.Text.ToString().Trim();
			if (!rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("ISSUE"))
			{
				theTranObject.ActualReturnDate = DateTime.Today;
			}
			
			theTranObject.FineAmount = CalculateFineAmount(theTranObject);
			bookList4Transaction.Add(theTranObject);
			gview_Books4Transaction.DataSource = bookList4Transaction;
			if (rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("ISSUE"))
			{
				gview_Books4Transaction.Columns[2].Visible = false;
				gview_Books4Transaction.Columns[3].Visible = false;
			}
			else
				if (rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("RECEIVE"))
				{
					gview_Books4Transaction.Columns[2].Visible = true;
					gview_Books4Transaction.Columns[3].Visible = true;
				}
				else
					if (rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("MISSING"))
					{
						gview_Books4Transaction.Columns[2].HeaderText = "Missing Date";
						gview_Books4Transaction.Columns[2].Visible = true;
						gview_Books4Transaction.Columns[3].HeaderText = "Missing Fine";
						gview_Books4Transaction.Columns[3].Visible = true;
					}
					else
						if (rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("DAMAGED"))
						{
							gview_Books4Transaction.Columns[2].HeaderText = "Damaged Date";
							gview_Books4Transaction.Columns[2].Visible = true;
							gview_Books4Transaction.Columns[3].HeaderText = "Damaged Fine";
							gview_Books4Transaction.Columns[3].Visible = true;
						}
			gview_Books4Transaction.DataBind();


			//gview_Books4Transaction.Columns[3].Visible = theTranObject.TransactionType.Equals("RECEIVE") ? true : false;
			
		}

		private double CalculateFineAmount(BookTransaction b)
		{
			//TODO: calculate here how many days a user has taken or lend a book
			//TODO : read a setting for the fine amount per day 
			int totalDays = 5;
			double fineAmountPerDay = 1.25;
			double totalFineAmount = 0;
			if (b.TransactionType.Equals("ISSUE"))
			{
				totalFineAmount = 0.00;
			}
			else if (b.TransactionType.Equals("RECEIVE"))
			{
				if (b.ActualReturnDate > b.ExpetedReturnDate)
				{
					totalFineAmount = totalDays * fineAmountPerDay;
				}

			}
			else if (b.TransactionType.Equals("MISSING"))
			{
				//TODO: GET THE BOOK PRICE FROM THE LIST
				// GET THE % OF FINE FOR MISSING BOOK
				// CALCUALTE TOTAL AMOUNT
				Book theBook = LibraryManagement.GetInstance.GetBooksList().Find(buk => buk.BookID == b.BookID);
				totalFineAmount = theBook.BookPrice * 2;

			}
			else if (b.TransactionType.Equals("DAMAGED"))
			{
				//totalFineAmount = totalDays * fineAmountPerDay * 200;
				//TODO: GET THE BOOK PRICE FROM THE LIST
				// GET THE % OF FINE FOR MISSING BOOK
				// CALCUALTE TOTAL AMOUNT
				Book theBook = LibraryManagement.GetInstance.GetBooksList().Find(buk => buk.BookID == b.BookID);
				totalFineAmount = theBook.BookPrice;
			}
			return totalFineAmount;
		}

		private string GetAccessionNumber(long p)
		{
			return "NN"; // NN = Not Needed as BookID will do the job. else ///p.ToString(); //TODO: Put the accession number 
		}

		protected void btn_Save_Click(object sender, EventArgs e)
		{
			if (rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("ISSUE"))
			{
				ISSUE_A_BOOK();
			}
			else
				if (rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("RECEIVE"))
				{
					RECEIVE_A_BOOK();
				}
				else
					if (rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("MISSING"))
					{
						RECORD_A_MISSING_BOOK();
					}
					else
						if (rbList_TransactionType.SelectedItem.Value.ToString().ToUpper().Equals("DAMAGED"))
						{
							RECORD_A_DAMAGED_BOOK();
						}
		}

		private void RECORD_A_DAMAGED_BOOK()
		{
		}

		private void RECORD_A_MISSING_BOOK()
		{
		}

		/// <summary>
		/// RECEIVE_A_BOOK
		/// </summary>
		private void RECEIVE_A_BOOK()
		{
			BookTransaction theTranObject = new BookTransaction();
			theTranObject.TransactionDate = DateTime.Parse(txt_TransactionDate.Text.ToString());
			theTranObject.TransactionType = rbList_TransactionType.SelectedValue.ToString();
			theTranObject.UserType = rbList_UserType.SelectedValue.ToString();
			theTranObject.BookID = long.Parse(ddl_Books.SelectedValue.ToString());
			theTranObject.AccessionNo = GetAccessionNumber(theTranObject.BookID);
			theTranObject.TitleAccessionNo = ddl_Books.SelectedItem.Text.ToString();
			theTranObject.UserID = int.Parse(ddl_TransactionToFromUser.SelectedValue.ToString());
			theTranObject.UserName = ddl_TransactionToFromUser.SelectedItem.Text.ToString().Trim();
			theTranObject.ActualReturnDate = DateTime.Today;
			theTranObject.FineAmount = CalculateFineAmount(theTranObject);
			int ReturnValue = LibraryManagement.GetInstance.InsertBookTransaction_RECEIVE(theTranObject);
			if (ReturnValue > 0)
			{
				string tranRef = string.Format("TransactionRef#- {0}", ReturnValue);
				lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_BOOK_RECEIVED").Replace("{0}", ddl_Books.SelectedItem.Text).Replace("{1}", "<br/>" + ddl_TransactionToFromUser.SelectedItem.Text + "<br/>" + tranRef);
				dialog_Message.Show();
				//RemoveItemFromBookList(theTranObject.BookID); // Remove the book from the list of books dropdwon list
				PageVar.BooksList = LibraryManagement.GetInstance.GetBooksList(true); // refesh the cache after the successful transaction
			}
			else
			{
				lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_BOOK_RECEIVED");
				dialog_Message.Show();
			}
		}

		private void ISSUE_A_BOOK()
		{
			BookTransaction theTranObject = new BookTransaction();
			theTranObject.TransactionDate = DateTime.Parse(txt_TransactionDate.Text.ToString());
			theTranObject.TransactionType = rbList_TransactionType.SelectedValue.ToString();
			theTranObject.UserType = rbList_UserType.SelectedValue.ToString();
			theTranObject.BookID = long.Parse(ddl_Books.SelectedValue.ToString());
			theTranObject.AccessionNo = GetAccessionNumber(theTranObject.BookID);
			theTranObject.TitleAccessionNo = ddl_Books.SelectedItem.Text.ToString();
			theTranObject.UserID = int.Parse(ddl_TransactionToFromUser.SelectedValue.ToString());
			theTranObject.UserName = ddl_TransactionToFromUser.SelectedItem.Text.ToString().Trim();
			theTranObject.ActualReturnDate = DateTime.Today;
			theTranObject.FineAmount = CalculateFineAmount(theTranObject);
			int ReturnValue = LibraryManagement.GetInstance.InsertBookTransaction_ISSUE(theTranObject);
			if (ReturnValue > 0)
			{
				string s = string.Format("TransactionRef#- {0}", ReturnValue);
				lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_BOOK_ISSUED").Replace("{0}", ddl_Books.SelectedItem.Text).Replace("{1}", "<br/>" + ddl_TransactionToFromUser.SelectedItem.Text + "<br/>" + s);
				dialog_Message.Show();
				RemoveItemFromBookList(theTranObject.BookID); // Remove the book from the list of books dropdwon list
				PageVar.BooksList = LibraryManagement.GetInstance.GetBooksList(true); // refesh the cache after the successful transaction
			}
			else
			{
				lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_BOOK_ISSUED");
				dialog_Message.Show();
			}
		}

		private void RemoveItemFromBookList(long p)
		{
			//throw new NotImplementedException();
			//PageVar.BooksList.RemoveAll(b => b.BookID == p);
			//ddl_Books.Items.Clear();
			//ddl_Books.DataSource = PageVar.BooksList;
			//ddl_Books.DataBind();
		}

		protected void btn_Cancel_Click(object sender, EventArgs e)
		{
			//lbl_TheMessage.Text = "cancel";
			//dialog_Message.Show();
			//PageVar.BookTranList.Clear();
			gview_Books4Transaction.DataSource = null;
			gview_Books4Transaction.DataBind();
		}

		protected void btn_View_Click(object sender, EventArgs e)
		{

		}

		protected void searchCtrl_ButtonClicked(object sender, EventArgs e)
		{
			SearcBooksBindGridView();
		}

		protected void vu_Issue_Init(object sender, EventArgs e)
		{

		}

		protected void vu_Return_Init(object sender, EventArgs e)
		{

		}

		protected void ddl_TransactionToFromUser_SelectedIndexChanged(object sender, EventArgs e)
		{
			tranPageUpdateProgress.Attributes.Add("display", "block");
			FillDropdownLibraryBooks(rbList_TransactionType.SelectedValue.ToString());
			tranPageUpdateProgress.Attributes.Add("display", "none");

		}

		protected void ddla_TransactUser_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void gview_Transactions_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}

		protected void gview_Transactions_RowCommand(object sender, GridViewCommandEventArgs e)
		{

		}

		protected void gview_Transactions_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{

		}

		protected void gview_Transactions_RowEditing(object sender, GridViewEditEventArgs e)
		{
			e.Cancel = true;
		}

		protected void btn_AddNew_Click(object sender, EventArgs e)
		{
			//SetPageTitle();
		}

		protected void rbList_TransactionType_SelectedIndexChanged(object sender, EventArgs e)
		{
			tranPageUpdateProgress.Attributes.Add("display", "block");
			SetPageTitle(rbList_TransactionType.SelectedValue.ToString());
			FillDropdownLibraryBooks(rbList_TransactionType.SelectedValue.ToString());
			tranPageUpdateProgress.Attributes.Add("display", "none");
		}

		protected void rbList_UserType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetPageTitle(rbList_TransactionType.SelectedValue.ToString());

		}

		#endregion

		#region Methods
		/// <summary>
		/// Set the Transaction Page Title
		/// </summary>
		/// <param name="theTransaction"></param>
		private void SetPageTitle(string theTransaction)
		{

			lit_PageTitle.Text = string.Empty;
			lit_PageTitle.Text = ReadXML.GetGeneralMessage(theTransaction + "_" + rbList_UserType.SelectedValue.ToString());

			




		}


		private void SearcBooksBindGridView()
		{
			//string searchText = ctrl_Search.SearchText;
			//string searchOperator = ctrl_Search.SearchOperator;
			//string searchField = ctrl_Search.SearchField;

			//List<Book> SearchList = new List<Book>();
			//List<Book> BookList = LibraryManagement.GetInstance.GetBooksList();
			//if (BookList.Count > 0)
			//{
			//	// Search by name/title
			//	if (searchField == MicroEnums.SearchBook.Title.ToString())
			//	{
			//		if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
			//		{
			//			SearchList = (from book in BookList
			//						  where book.Title.ToUpper().StartsWith(searchText.ToUpper())
			//						  select book).ToList();
			//		}

			//		if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
			//		{
			//			SearchList = (from book in BookList
			//						  where book.Title.ToUpper().Contains(searchText.ToUpper())
			//						  select book).ToList();
			//		}
			//	}

			//	// Search by name/title
			//	if (searchField == MicroEnums.SearchBook.AuthorName.ToString())
			//	{
			//		if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
			//		{
			//			SearchList = (from book in BookList
			//						  where book.AuthorName.ToUpper().StartsWith(searchText.ToUpper())
			//						  select book).ToList();
			//		}

			//		if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
			//		{
			//			SearchList = (from book in BookList
			//						  where book.AuthorName.ToUpper().Contains(searchText.ToUpper())
			//						  select book).ToList();
			//		}
			//	}
			//// Search by code
			//if (searchField == MicroEnums.SearchBook.AccessionNo.ToString())
			//{
			//    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
			//    {
			//        SearchList = (from empCode in BookList
			//                      where empCode.AccessionNo.ToUpper().StartsWith(searchText.ToUpper())
			//                      select empCode).ToList();
			//    }

			//    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
			//    {
			//        SearchList = (from empCode in BookList
			//                      where empCode.AccessionNo.ToUpper().Contains(searchText.ToUpper())
			//                      select empCode).ToList();
			//    }
			//}

		}

		private void FillDropdownLibraryBooks()
		{
			if (PageVar.BooksList == null)
				PageVar.BooksList = LibraryManagement.GetInstance.GetBooksList().OrderByDescending(a => a.TitleAccessionNo).ToList();
			ddl_Books.DataSource = PageVar.BooksList;
			ddl_Books.DataTextField = "TitleAccessionNo";
			ddl_Books.DataValueField = "BookID";
			ddl_Books.DataBind();
			ddl_Books.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));

		}


		private void FillDropdownLibraryBooks(string theTransactionType)
		{
			string YesNoFlag;
			PageVar.BooksList = LibraryManagement.GetInstance.GetBooksList(true).OrderByDescending(a => a.TitleAccessionNo).ToList();
			List<Book> BooksList_filtered = new List<Book>();
			//if (PageVar.BooksList == null)
			//{
			//	PageVar.BooksList = LibraryManagement.GetInstance.GetBooksList().OrderByDescending(a => a.TitleAccessionNo).ToList();
			//}

			if (theTransactionType == "ISSUE")
			{
				YesNoFlag = "NO";
				BooksList_filtered = (from x in PageVar.BooksList
									  select x).ToList().FindAll(a => a.IsBookIssued.Equals(YesNoFlag)).OrderByDescending(a => a.TitleAccessionNo).ToList();
			}
			else if (theTransactionType == "RECEIVE")
			{
				YesNoFlag = "YES";
				BooksList_filtered = (from x in PageVar.BooksList
									  select x).ToList().FindAll(a => a.IsBookIssued.Equals(YesNoFlag)).OrderByDescending(a => a.TitleAccessionNo).ToList();
			}
			else
			{
				BooksList_filtered = PageVar.BooksList;
			}
			ddl_Books.DataSource = BooksList_filtered;
			ddl_Books.DataTextField = "TitleAccessionNo";
			ddl_Books.DataValueField = "BookID";
			ddl_Books.DataBind();
			ddl_Books.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT_BOOK));
			Label2.Text = string.Format("Please select a Book: (<a href='Books.aspx'>{0}</a>)", BooksList_filtered.Count);
		}

		private void FillDropdownUserType_Staff()
		{
			if (PageVar.StaffsList == null)
			{
				PageVar.StaffsList = StaffMasterManagement.GetInstance.GetEmployeeListForLibrary();
			}
			//ddl_TransactionToFromUser.Visible = false;
			ddl_TransactionToFromUser.Items.Clear();
			ddl_TransactionToFromUser.DataSource = PageVar.StaffsList;
			ddl_TransactionToFromUser.DataTextField = "EmpoyeeNameAndCode";
			ddl_TransactionToFromUser.DataValueField = "EmployeeID";
			ddl_TransactionToFromUser.DataBind();
			//ddl_TransactionToFromUser.Visible = true;
			if (rbList_UserType.SelectedIndex == 0)
			{
				ddl_TransactionToFromUser.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT_STUDENT));
			}
			else
			{
				ddl_TransactionToFromUser.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT_STAFF));
			}
		}

		private void FillDropdownUserType_Student()
		{
			//if (PageVar.StudentsList == null)
			//{
			//	PageVar.StudentsList = StudentManagement.GetInstance.GetStudentList_Library();
			//}
			if (rbList_TransactionType.SelectedItem != null)
			{
				if (rbList_TransactionType.SelectedItem.Value.Equals("ISSUE"))
				{
					// READ THE TRANSACTION FILE AND EXCLUDE THOSE OUT THE STUDENTS WHO HAS TAKEN THE BOOKS
					PageVar.StudentsList = StudentManagement.GetInstance.GetStudentList_Library_Issue();
				}

				if (rbList_TransactionType.SelectedItem.Value.Equals("RECEIVE"))
				{
					// READ THE TRANSACTION FILE AND LIST OUT THE STUDENTS WHO HAS TAKEN THE BOOKS
					PageVar.StudentsList = StudentManagement.GetInstance.GetStudentList_Library_Receive();
				}
			ddl_TransactionToFromUser.Items.Clear();
			ddl_TransactionToFromUser.DataSource = PageVar.StudentsList;
			ddl_TransactionToFromUser.DataTextField = "StudentRollNoName";
			ddl_TransactionToFromUser.DataValueField = "StudentID";
			ddl_TransactionToFromUser.DataBind();
			ddl_TransactionToFromUser.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT_STUDENT));
			}
		}
			

		private void FillDropdownUserType()
		{
			//throw new NotImplementedException();
		}

		/// <summary>
		/// Show Hide Controls
		/// </summary>
		/// <param name="theTransaction">theTransaction</param>
		private void ShowHideControls(string theTransaction)
		{
			foreach (ListItem item in rbList_TransactionType.Items)
			{
				if (item.Text.Contains(theTransaction.ToUpper()))
				{
					item.Enabled = true;
					item.Attributes.Add("color", "black;");
				}
				else
					item.Enabled = false;
			}
			View v = new View();
			//throw new NotImplementedException();
			switch (theTransaction.ToUpper())
			{
				case "VIEW":
					mview_Transactions.SetActiveView(vu_View);
					break;
				case "ISSUE":
					rbList_TransactionType.SelectedIndex = 0;
					mview_Transactions.SetActiveView(vu_Issue);
					break;
				case "RECEIVE":
					gview_Books4Transaction.Columns[3].Visible = true;
					gview_Books4Transaction.Columns[4].Visible = true;
					rbList_TransactionType.SelectedIndex = 1;
					mview_Transactions.SetActiveView(vu_Return);
					break;
				case "MISSING":
					rbList_TransactionType.SelectedIndex = 2;
					mview_Transactions.SetActiveView(vu_Missing);
					break;
				case "DAMAGED":
					rbList_TransactionType.SelectedIndex = 3;
					mview_Transactions.SetActiveView(vu_Damaged);
					break;
				case "MESSAGE":
					v.Controls.Add(lit_PageTitle);
					mview_Transactions.Views.Add(v);
					mview_Transactions.SetActiveView(v);
					break;
			}
			v.Dispose();
		}

		#endregion
	}
}