using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Micro.Objects.Administration;
using Micro.Commons;
using System.Configuration;
using Micro.BusinessLayer.Administration;

namespace Micro.WebApplication.MicroERP.ADMIN
{

    /// <summary>
    /// View Error logs
    /// </summary>
    
	public partial class ErrorLogs : System.Web.UI.Page
	{
        #region Declaration
        protected static class PageVariables
        {
            public static List<ErrorLog> TheErrorLogList
            { 
                get
                {
                    List<ErrorLog> ThisErrorLogList = HttpContext.Current.Session["TheErrorLogList"] as List<ErrorLog>;
                    return ThisErrorLogList;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheErrorLogList", value);
                }
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
		{
            ctrl_Search.OnButtonClick += searchCtrl_ButtonClicked;
            if (!IsPostBack)
            {
                BindGridView();
                ctrl_Search.SearchWhat = MicroEnums.SearchForm.UserLog.ToString();
            }
		}

        private void searchCtrl_ButtonClicked(object sender, System.EventArgs e)
        {
            SearchUserLogBindGridView();
        }

        protected void gview_Errors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gview_Errors.PageIndex = e.NewPageIndex;
            BindGridView();
            lit_PageCounter.Text = string.Format("Page <b>{0}</b> of {1}", e.NewPageIndex + 1, gview_Errors.PageCount);
        }

        #endregion

        #region Methods & Implementation

        private void SearchUserLogBindGridView()
        {
            string searchText = ctrl_Search.SearchText;
            string searchOperator = ctrl_Search.SearchOperator;
            string searchField = ctrl_Search.SearchField;

            List<ErrorLog> SearchList = new List<ErrorLog>();
            // Search by Ticket
            if (PageVariables.TheErrorLogList.Count > 0)
            {
                if (searchField == MicroEnums.SearchErrorLog.Ticket.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from tickName in PageVariables.TheErrorLogList
                                      where tickName.Ticket.ToUpper().StartsWith(searchText.ToUpper())
                                      select tickName).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from tickName in PageVariables.TheErrorLogList
                                      where tickName.Ticket.ToUpper().Contains(searchText.ToUpper())
                                      select tickName).ToList();
                    }
                }
                //search by UserDomain
                if (searchField == MicroEnums.SearchErrorLog.UserDomain.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from domname in PageVariables.TheErrorLogList
                                      where domname.UserDomain.ToUpper().StartsWith(searchText.ToUpper())
                                      select domname).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from domname in PageVariables.TheErrorLogList
                                      where domname.UserDomain.ToUpper().Contains(searchText.ToUpper())
                                      select domname).ToList();
                    }
                }
                //Search by Date
                if (searchField == MicroEnums.SearchErrorLog.Date.ToString())
                {
                    if (searchOperator.Equals(MicroEnums.SearchOperator.StartsWith.ToString()))
                    {
                        SearchList = (from date in PageVariables.TheErrorLogList
                                      where date.ErrorDate.ToShortDateString().StartsWith(searchText.ToUpper())
                                      select date).ToList();
                    }

                    if (searchOperator.Equals(MicroEnums.SearchOperator.Contains.ToString()))
                    {
                        SearchList = (from date in PageVariables.TheErrorLogList
                                      where date.ErrorDate.ToShortDateString().Contains(searchText.ToUpper())
                                      select date).ToList();
                    }
                }

            }
            // Dispaly the search result
            ctrl_Search.SearchResultCount = SearchList.Count.ToString();
            gview_Errors.DataSource = SearchList;
            gview_Errors.DataBind();
        }

        private void BindSearchFields()
        {
            foreach (MicroEnums.SearchErrorLog x in Enum.GetValues(typeof(MicroEnums.SearchErrorLog)))
            {
                string xyz = x.ToString();
            }
        }
      
        private void BindGridView()
        {

            PageVariables.TheErrorLogList = UserManagement.GetInstance.GetErrorLogs();
            if (PageVariables.TheErrorLogList.Count > 0)
            {
                gview_Errors.DataSource = PageVariables.TheErrorLogList;
                gview_Errors.DataBind();
            }
        }

       
        #endregion
    }
}