using Micro.BusinessLayer.ICAS.LIBRARY;
using Micro.Commons;
using Micro.Objects.ICAS.LIBRARY;
using Micro.WebApplication.App_UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCon.iCAS.WebApplication.Library
{
    public partial class Books : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
            ctrl_Search.SearchWhat = MicroEnums.SearchForm.Book.GetStringValue();

            ((TreeView)Master.FindControl("TreeView1")).Visible = false;
            ((UC_UserLoggedOn)Master.FindControl("ctrl_LoggedOnUser")).Visible = false;

            if (!IsPostBack)
            {
                lit_BookCount.Text = string.Format("<span class='BookCountSpan'>{0}</span>", LibraryManagement.GetInstance.GetBooks_Count());
                BindGridviewBooks_Distinct();
            }

        }
        protected void searchCtrl_ButtonClicked(object sender, EventArgs e)
        {
            SearcBooksBindGridView();
        }

        private void SearcBooksBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<Book> SearchList = new List<Book>();
            List<Book> BookList = LibraryManagement.GetInstance.GetBooksList();
            if (BookList.Count > 0)
            {
                // Search by name/title
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
                
                // Search by name/title
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
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();
            gview_Books.DataSource = SearchList;
            gview_Books.DataBind();
        }
        protected void gview_Books_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Books.PageIndex = e.NewPageIndex;
            BindGridviewBooks_Distinct();
        }

        protected void chkBoxList_BookType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Methods
        private void BindGridviewBooks_Distinct()
        {
            List<Book> BooksList = LibraryManagement.GetInstance.GetBooksList_DistinctRecords();
            gview_Books.DataSource = BooksList;
            gview_Books.DataBind();
        }
        #endregion
    }
}