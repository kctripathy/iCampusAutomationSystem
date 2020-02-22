using Micro.BusinessLayer.ICAS.LIBRARY;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.ICAS.LIBRARY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication.Library
{
    public partial class BooksManage : BasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
            ctrl_Search.SearchWhat = MicroEnums.SearchForm.Book.GetStringValue();
            if (!IsPostBack)
            {
                regularExpressionValidator_AccessionNo.ValidationExpression = MicroConstants.REGEX_NUMBER_ONLY;
                regularExpressionValidator_AccessionNo.ErrorMessage = "Please enter Accession Number";
                requiredFieldValidator_AccessionNo.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "AccessionNo");

                regularExpressionValidator_AccessionDate.ValidationExpression = MicroConstants.REGEX_DATE;
                regularExpressionValidator_AccessionDate.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_DATE");

                PopulateDefaultData();

                DisplayBookCount();

                //BindGridviewBooks_Distrinct();
                ShowHideControls(true);
            }

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Book objBook = new Book();

            //Thread.Sleep(4000);

            PopulateFormFieldsToObjectForInsertingPurpose(ref objBook);

            bool isValidData = ValidateInputData(objBook);

            if (isValidData.Equals(false) || objBook.Equals(null)) 
            { 
                return; // don't proceed to insert invalid record.
            }
            else
            {
                if (ButtonSave.Text.Equals(MicroEnums.DataOperation.Save.GetStringValue())) // ADD NEW RECORD TO THE DATABASE
                {
                    //===================================================================           
                    int NewBookId = LibraryManagement.GetInstance.InsertBook(objBook);
                    //===================================================================           

                    if (NewBookId > 0)
                    {
                        //Success
                        lit_DialogMessage.Text = string.Format("<h4 style='color:'#00ff00'>Successfully instered the record as ID {0}</h4>",NewBookId);
                        DisplayBookCount();
                    }
                    else
                    {
                        //faliure
                        lit_DialogMessage.Text = "<h4 style='color:'#ff0000'>Sorry! Failed to add a new record</h4>";
                    }
                }
                else // UPDATE THE RECORD
                {
                    objBook.BookID = Int64.Parse(Session["BOOK_ID"].ToString());
                    //===================================================================           
                    int ReturnValue = LibraryManagement.GetInstance.UpdateBook(objBook);
                    //===================================================================           

                    if (ReturnValue > 0)
                    {
                        //Success
                        lit_DialogMessage.Text = "<h4 style='color:'#00ff00'>Successfully updated the record</h4>";
                    }
                    else
                    {
                        //faliure
                        lit_DialogMessage.Text = "<h4 style='color:'#ff0000'>Sorry! Failed to update the record</h4>";
                    }
                    ButtonSave.Text = MicroEnums.DataOperation.Save.GetStringValue();
                }

            }

            dialog_Message.Show();

            ShowHideControls(false);
        }

        protected void searchCtrl_ButtonClicked(object sender, EventArgs e)
        {
            SearchBooksBindGridView();
        }


        protected void gview_Books_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Books.PageIndex = e.NewPageIndex;
            BindGridviewBooks();
        }

        protected void chkBoxList_BookType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void ButtonView_Click(object sender, EventArgs e)
        {
            ShowHideControls(false);
            BindGridviewBooks();
        }

        protected void ButtonAddNewBook_Click(object sender, EventArgs e)
        {
            PopulateDefaultData();
            ShowHideControls(true);
        }







        protected void lnkbtn_NewCategory_Click(object sender, EventArgs e)
        {
            ShowHideForNewMasterRecordCreation(true);
            rbList_type.SelectedIndex = 3;
            lbl_LabelTitle.Text = "Please enter the New Category Name:";
        }

        protected void btn_NewAuthor_Click(object sender, EventArgs e)
        {
            ShowHideForNewMasterRecordCreation(true);
            rbList_type.SelectedIndex = 0;
            lbl_LabelTitle.Text = "Please enter Name of the Author:";

        }


        protected void lnkbtn_NewPublisher_Click(object sender, EventArgs e)
        {
            ShowHideForNewMasterRecordCreation(true);
            rbList_type.SelectedIndex = 1;
            lbl_LabelTitle.Text = "Please enter New Publisher Name:";

        }

        protected void lnkbtn_Supplier_Click(object sender, EventArgs e)
        {
            ShowHideForNewMasterRecordCreation(true);
            rbList_type.SelectedIndex = 2;
            lbl_LabelTitle.Text = "Please enter New Supplier Name:";

        }


        protected void lnkbtn_NewSegment_Click(object sender, EventArgs e)
        {
            ShowHideForNewMasterRecordCreation(true);
            rbList_type.SelectedIndex = 4;
            lbl_LabelTitle.Text = "Please enter New Segment Name:";
        }


        protected void btn_SaveNewRecord_Click(object sender, EventArgs e)
        {
            if (txt_NewText.Text.ToString().Equals(string.Empty))
            {
                lit_DialogMessage.Text = "Please input data first!";
                dialog_Message.Show();
                ShowHideForNewMasterRecordCreation(true);
            }
            else
            {
                //lit_DialogMessage.Text = "Save!";
                //dialog_Message.Show();
                switch (rbList_type.SelectedValue.ToString())
                {
                    case "A": ddl_Author.Items.Insert(0, new ListItem(txt_NewText.Text.ToString().ToUpper().Trim())); break;
                    case "P": ddl_Publisher.Items.Insert(0, new ListItem(txt_NewText.Text.ToString().ToUpper().Trim())); break;
                    case "S": ddl_Supplier.Items.Insert(0, new ListItem(txt_NewText.Text.ToString().ToUpper().Trim())); break;
                    case "C": ddl_Category.Items.Insert(0, new ListItem(txt_NewText.Text.ToString().ToUpper().Trim())); break;
                    case "T": ddl_Segments.Items.Insert(0, new ListItem(txt_NewText.Text.ToString().ToUpper().Trim())); break;

                }
                ShowHideForNewMasterRecordCreation(false);
                txt_NewText.Text = string.Empty;
            }

        }

        protected void btn_ResetClose_Click(object sender, EventArgs e)
        {
            ShowHideForNewMasterRecordCreation(false);
        }


        protected void gview_Books_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = 0;
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {

                RowIndex = Convert.ToInt32(e.CommandArgument);
                int theBookID = int.Parse(((Label)gview_Books.Rows[RowIndex].FindControl("lbl_BookID")).Text);
                List<Book> FullListOfBooks = LibraryManagement.GetInstance.GetBooksList();
                var theBookRow = (from xyz in FullListOfBooks
                                  where xyz.BookID.Equals(theBookID)
                                  select xyz).Single();

                if (e.CommandName.Equals(MicroEnums.DataOperation.Select.GetStringValue()))
                {

                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
                {
                    // EDIT COMMAND CLICKED
                    PopulateFormFieldToEditTheRecord(theBookRow as Book);
                    ShowHideControls(true);
                    ButtonSave.Text = MicroEnums.DataOperation.Update.GetStringValue();
                }
                else if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
                {
                    // DELETE COMMAND CLICKED
                    int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

                    //ProcReturnValue = DeleteEstablishment();

                    if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                    {
                        //BindGridview();
                    }
                }

            }

        }

        private void PopulateFormFieldToEditTheRecord(Book book)
        {
            try
            {
                Session["BOOK_ID"] = book.BookID;
                if (book.BookType.Equals("GEN")) { rblst_BookTypes.SelectedIndex = 0; } else { rblst_BookTypes.SelectedIndex = 1; }
                txt_AccessionNo.Text = book.AccessionNo.ToString();
                txt_AccessionDate.Text = book.AccessionDate.ToString("dd-MMM-yyyy");
                txt_Title.Text = book.Title;
                txt_Volume.Text = book.VolumeNo;
                txt_Edition.Text = book.Edition;
                txt_Year.Text = book.BookYear.ToString();
                txt_BillNo.Text = book.BillNo;
                txt_BillDate.Text = book.BillDate.ToString("dd-MMM-yyyy");

                ddl_Segments.SelectedIndex = GetDropDownSelectedIndex(ddl_Segments, Convert.ToString(book.SegmentCode)); ;
                ddl_Category.SelectedIndex = GetDropDownSelectedIndex(ddl_Category, Convert.ToString(book.CategoryID)); ;
                ddl_Author.SelectedIndex = GetDropDownSelectedIndex(ddl_Author, Convert.ToString(book.AuthorID)); ;
                ddl_Publisher.SelectedIndex = GetDropDownSelectedIndex(ddl_Publisher, Convert.ToString(book.PublisherID)); ;
                ddl_Supplier.SelectedIndex = GetDropDownSelectedIndex(ddl_Supplier, Convert.ToString(book.SupplierID)); ;


                //GetDropDownSelectedIndex(ddl_ParentDepartment, Convert.ToString(theDepartment.ParentDepartmentId));
            }
            catch
            {

            }
        }

        protected void gview_Books_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Books_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion


        #region Methods

        private void DisplayBookCount()
        {
            lit_BookCount.Text = string.Format("<span class='BookCountSpan'>{0}</span>", LibraryManagement.GetInstance.GetBooks_Count());
        }

        private void BindGridviewBooks()
        {
            List<Book> BooksList = LibraryManagement.GetInstance.GetBooksList();
            List<Book> BooksListNew =
                            (from bb in BooksList
                             select bb).OrderByDescending(x => x.BookID).ToList();

            gview_Books.DataSource = BooksListNew;
            gview_Books.DataBind();
        }


        private void ShowHideControls(bool p)
        {
            //ctrl_Search.Visible = false;
            //UC_LibraryBookAdd1.Visible = p; // show or hide the input control

            //input controls
            LibraryBookUL.Visible = p;
            ButtonSave.Visible = p;
            ButtonView.Visible = p;

            //Grid view 
            ctrl_Search.Visible = !p;
            btn_AddNewBook.Visible = !p;
            btn_Refresh.Visible = !p;
            panel_ViewBook.Visible = !p;
            gview_Books.Visible = !p;

        }

        private void ShowHideForNewMasterRecordCreation(bool theParam)
        {
            //panel_NewBook.Visible = theParam;
            panel_ViewBook.Visible = !theParam;
            panel_InputBookDetails.Visible = !theParam;
            txt_NewText.Focus();
        }

        private bool ValidateInputData(Book objBook)
        {
            bool retValue = true;
            StringBuilder errMessage = new StringBuilder("<ul><li><h2 class='ErrorTitle'>Data Input Error:</h2></li>");

            // Accesion Number Check
            if (txt_AccessionNo.Text.Trim().Equals(string.Empty))
            {
                errMessage.AppendLine("<li>Accession Number can't be empty</li>");
                retValue = false;
            }

            try
            {
                int x = int.Parse(txt_AccessionNo.Text.ToString());
                if (x < 0)
                {
                    errMessage.AppendLine("<li>Accession Number must be a postivie number</li>");
                    retValue = false;
                }
            }
            catch
            {
                errMessage.AppendLine("<li>Accession Number must be a number</li>");
                retValue = false;
            }

            if (txt_Title.Text.Trim().Equals(string.Empty))
            {
                errMessage.AppendLine("<li>Book Title can't be empty</li>");
                retValue = false;
            }
            //if (ddl_Author.Text.Trim().Equals(string.Empty))
            //{
            //    errMessage.AppendLine("<li>Author can't be empty</li>");
            //    retValue = false;
            //}
            errMessage.AppendLine("</ul>");
            txt_Remarks.Text = errMessage.ToString();
            if (retValue.Equals(false))
            {
                lit_DialogMessage.Text = errMessage.ToString();
                dialog_Message.Show();
            }
            return retValue;
            //throw new NotImplementedException();
        }

        private void PopulateDefaultData()
        {
            Book objLastAddedBook = new Book();
            txt_AccessionNo.Text = LibraryManagement.GetInstance.GetBooks_NewAccessionNumber(ref objLastAddedBook).ToString();
            txt_AccessionDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            txt_BillDate.Text = txt_AccessionDate.Text;
            ddl_Author.Text = objLastAddedBook.AuthorName;
            txt_Title.Text = objLastAddedBook.Title; // string.Empty;


            txt_Remarks.Text = DateTime.Today.ToString("dd-MMM-yyyy");

            BindDropdownSegments();
            BindDropdownCategory();
            BindDropdownAuthors();
            BindDropdownPublishers();
            BindDropdownSuppliers();
        }

        private void BindDropdownSegments()
        {
            //throw new NotImplementedException();
            List<BookSegment> BookSegmentList = new List<BookSegment>();
            BookSegmentList = LibraryManagement.GetInstance.GetBook_BookSegments();
            ddl_Segments.DataSource = BookSegmentList;
            ddl_Segments.DataTextField = "Name";
            ddl_Segments.DataValueField = "ID";
            ddl_Segments.DataBind();

        }

        private void BindDropdownCategory()
        {
            //throw new NotImplementedException();
            List<BookCategory> categoryList = new List<BookCategory>();
            categoryList = LibraryManagement.GetInstance.GetBook_Categories();
            ddl_Category.DataSource = categoryList;
            ddl_Category.DataTextField = "Name";
            ddl_Category.DataValueField = "ID";
            ddl_Category.DataBind();

        }

        private void BindDropdownAuthors()
        {
            //throw new NotImplementedException();
            List<Author> theList = new List<Author>();
            theList = LibraryManagement.GetInstance.GetBook_Authors();
            ddl_Author.DataSource = theList;
            ddl_Author.DataTextField = "Name";
            ddl_Author.DataValueField = "ID";
            ddl_Author.DataBind();

        }

        private void BindDropdownPublishers()
        {
            //throw new NotImplementedException();
            List<Publisher> theList = new List<Publisher>();
            theList = LibraryManagement.GetInstance.GetBook_Publishers();
            ddl_Publisher.DataSource = theList;
            ddl_Publisher.DataTextField = "Name";
            ddl_Publisher.DataValueField = "ID";
            ddl_Publisher.DataBind();

        }

        private void BindDropdownSuppliers()
        {
            //throw new NotImplementedException();
            List<Supplier> theList = new List<Supplier>();
            theList = LibraryManagement.GetInstance.GetBook_Suppliers();
            ddl_Supplier.DataSource = theList;
            ddl_Supplier.DataTextField = "Name";
            ddl_Supplier.DataValueField = "ID";
            ddl_Supplier.DataBind();

        }

        private void PopulateFormFieldsToObjectForInsertingPurpose(ref Book b)
        {
            try
            {

                if (txt_AccessionNo.Text != string.Empty) { b.AccessionNo = int.Parse(txt_AccessionNo.Text); }
                if (txt_AccessionDate.Text != string.Empty) { b.AccessionDate = DateTime.Parse(txt_AccessionDate.Text.ToString()); }

                b.BookType = rblst_BookTypes.SelectedItem.Value.ToString();

                b.SegmentCode = int.Parse(ddl_Segments.SelectedItem.Value.ToString());
                b.SegmentName = ddl_Segments.SelectedItem.Text.ToString();

                b.CategoryID = int.Parse(ddl_Category.SelectedItem.Value.ToString());
                b.CategoryName = ddl_Category.SelectedItem.Text.ToString();

                b.AuthorID = int.Parse(ddl_Author.SelectedValue.ToString());
                b.AuthorName = ddl_Author.SelectedItem.Text.ToUpper();

                b.SupplierID = int.Parse(ddl_Supplier.SelectedValue.ToString());
                b.SupplierName = ddl_Supplier.SelectedItem.Text.ToUpper();

                b.PublisherID = int.Parse(ddl_Publisher.SelectedValue.ToString());
                b.PublisherName = ddl_Publisher.SelectedItem.Text.ToUpper();

                
                b.Title = txt_Title.Text.ToUpper();
                b.Edition = txt_Edition.Text;
                b.VolumeNo = txt_Volume.Text;
                b.ClassNo = txt_ClassNo.Text;
                b.IBNNumber = txt_IBN.Text;
                b.BillNo = txt_BillNo.Text;
                if (txt_BillDate.Text == string.Empty) txt_BillDate.Text = "1-Jan-1900"; b.BillDate = DateTime.Parse(txt_BillDate.Text.ToString());
                if (txt_Pages.Text == string.Empty) txt_Pages.Text = "0"; b.Pages = int.Parse(txt_Pages.Text);
                if (txt_Price.Text.ToString() == string.Empty) txt_Price.Text = "0"; b.BookPrice = float.Parse(txt_Price.Text.ToString());
                if (txt_Year.Text == string.Empty) txt_Year.Text = "1900"; b.BookYear = int.Parse(txt_Year.Text);
                b.Remarks = txt_Remarks.Text;
                b.Book_ImageURL_Small = "NA";
                b.Book_ImageURL_Medium = "NA";
                b.Book_Image_URL_Big = "NA";                                    
            }
            catch (Exception ex)
            {
                throw (ex);
                b = null;
            }

        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            ShowHideControls(true);            
        }

        protected void btnUpload_BookCoverPage_Click(object sender, EventArgs e)
        {

        }

        private void SearchBooksBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<Book> SearchList = new List<Book>();
            List<Book> BookList = LibraryManagement.GetInstance.GetBooksList();

            if (BookList.Count > 0)
            {
                // Search by title
                if (searchField == MicroEnums.SearchBook.Title.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from book in BookList
                                      where book.Title.ToUpper().StartsWith(searchText.ToUpper())
                                      select book).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from book in BookList
                                      where book.Title.ToUpper().Contains(searchText.ToUpper())
                                      select book).ToList();
                    }
                }

                //// Search by Category
                //if (searchField == MicroEnums.SearchBook.Category.ToString())
                //{
                //    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                //    {
                //        SearchList = (from book in BookList
                //                      where book.CategoryName.ToUpper().StartsWith(searchText.ToUpper())
                //                      select book).ToList();
                //    }

                //    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                //    {
                //        SearchList = (from book in BookList
                //                      where book.CategoryName.ToUpper().Contains(searchText.ToUpper())
                //                      select book).ToList();
                //    }
                //}

                // Search by Author
                if (searchField == MicroEnums.SearchBook.AuthorName.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from book in BookList
                                      where book.AuthorName.ToUpper().StartsWith(searchText.ToUpper())
                                      select book).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from book in BookList
                                      where book.AuthorName.ToUpper().Contains(searchText.ToUpper())
                                      select book).ToList();
                    }
                }

                //// Search by Segment
                //if (searchField == MicroEnums.SearchBook.Segment.ToString())
                //{
                //    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                //    {
                //        SearchList = (from book in BookList
                //                      where book.SegmentName.ToUpper().StartsWith(searchText.ToUpper())
                //                      select book).ToList();
                //    }

                //    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                //    {
                //        SearchList = (from book in BookList
                //                      where book.CategoryName.ToUpper().Contains(searchText.ToUpper())
                //                      select book).ToList();
                //    }
                //}

                // Search by code
                if (searchField == MicroEnums.SearchBook.AccessionNo.ToString())
                {
                    SearchList = (from empCode in BookList
                                  where empCode.AccessionNo.Equals(int.Parse(searchText))
                                  select empCode).ToList();
                }

            }
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();
            gview_Books.DataSource = SearchList;
            gview_Books.DataBind();
        }

        #endregion

        protected void btn_Refresh_Click(object sender, EventArgs e)
        {
            List<Book> BookList = LibraryManagement.GetInstance.GetBooksList(true).OrderByDescending(a=>a.BookID).ToList();

            gview_Books.DataSource = BookList;
            gview_Books.DataBind();
            //Thread.Sleep(10000);
        }



    }
}