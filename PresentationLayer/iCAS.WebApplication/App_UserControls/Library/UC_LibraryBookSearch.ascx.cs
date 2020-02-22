using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Micro.BusinessLayer.ICAS.LIBRARY;
using Micro.Commons;
using Micro.Framework.ReadXML;
using Micro.Objects.ICAS.LIBRARY;

namespace TCon.iCAS.WebApplication.App_UserControls.Library
{
	public partial class UC_LibraryBookSearch : BaseUserControl
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//BindGridView_OnStartup();
			}

		}

		private void BindGridView_OnStartup()
		{
			try
			{
				List<Book> BookList = LibraryManagement.GetInstance.GetBooksList();

				var maxId = (from x in BookList
							 select x).OrderByDescending(y => y.BookID).First();

				long LastBookID = ((Book)maxId).BookID - long.Parse(ConfigurationManager.AppSettings["MaxLibraryBooks2Display"].ToString());

				List<Book> Top10List = (from x in BookList
										where x.BookID >= LastBookID
										select x).OrderByDescending(a => a.BookID).ToList();


				dgrid_Books.DataSource = Top10List;
				dgrid_Books.DataBind();

				//gview_Books.DataSource = Top10List;
				//gview_Books.DataBind();
			}
			catch
			{

			}

		}

		protected void btnGoSearch_Click(object sender, EventArgs e)
		{
			
			if (txt_SearchText.Text.ToString().Trim().Equals(string.Empty))
			{
			
				lit_TheMessage.Text = ReadXML.GetFailureMessage("KO_EMPTY_SEARCH_TEXT");
				dialog_Message.Show();				
				return;
			}
			BindGridviewSearchResult();
		}

		private void BindGridviewSearchResult()
		{
			List<Book> BookList = LibraryManagement.GetInstance.GetBooksList();
			List<Book> FilterList = (from x in BookList
									 where x.Title.ToUpper().Trim().Contains(txt_SearchText.Text.ToUpper().Trim())
									 select x).OrderByDescending(a => a.BookID).ToList();

			
			lit_RecordCount.Text = string.Format("{0} {1} found.", FilterList.Count, (FilterList.Count <= 1 ? "record" : "records"));
			if (FilterList.Count > 0)
			{
				dgrid_Books.DataSource = FilterList;
				dgrid_Books.DataBind();
				
				//gview_Books.DataSource = FilterList;
				//gview_Books.DataBind();
			}
		}

		protected void txt_SearchText_TextChanged(object sender, EventArgs e)
		{
			BindGridviewSearchResult();
		}

		protected void dataGrid_Books_ItemCommand(object source, DataGridCommandEventArgs e)
		{

			if (e.CommandName.Equals("CmdAccessionNo"))
			{
				string BookID = e.Item.Cells[0].Text;

				//_clientPartner = new ClientPartnerBusiness();
				//if (!strClientPartnerId.Equals(""))
				//{
				//	int iPartnerAccountID = _clientPartner.GetPartnerAccountID(Convert.ToInt32(strClientPartnerId));
				//	_clientPartner.ErasePartnerLink(Convert.ToInt32(strClientPartnerId));
				//	BindGrid();

				//	// Update Lara Flag
				//	ApplicationEvent applicationEvent = new ApplicationEvent();
				//	applicationEvent.UpdateLaraStatus(iPartnerAccountID);
				//}
			}
			else if (e.CommandName.Equals("IssueBook"))
			{
				//string strClientPartnerCode = ((LinkButton)e.Item.Cells[1].Controls[0]).Text;

				//// Transfer the information to Partner Information Page
				//Context.Items.Add("PARTNER_CODE", strClientPartnerCode);
				//Context.Items.Add("SHIPCOMP_CODE", accountInformation.Shipcompcode);
				//Server.Transfer(ApplicationVariables.GetApplicationPath(this.Page) + "Administration/Partner/PartnerInformation.aspx", true);
				//lit_TheMessage.Text = "Please log on to Issue/Return the books";
				string theBookDetails = string.Format("Book: <b><u>{0}</u></b><br/> " +
														"Segment: <b>{1}</b><br/>" +
														"Category: <b>{2}</b><br/> " +
														"Author: <b>{3}</b><br/>" +
														"Publisher: <b>{4}</b><br/>",
														e.Item.Cells[2].Text,
														e.Item.Cells[6].Text,
														e.Item.Cells[7].Text,
														e.Item.Cells[4].Text,
														e.Item.Cells[5].Text,
														e.Item.Cells[1].Text);
				lit_TheMessage.Text = theBookDetails;
				dialog_Message.Title = "Details for the Book Accession Number: " + e.Item.Cells[2].Text;
				dialog_Message.Show();
			}



		}

		protected void dgrid_Books_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			//this.lnkAdd.Attributes.Add("onclick", "window.showModalDialog('AddPartners.aspx', null, 'status:no;dialogWidth:800px;dialogHeight:550px;dialogHide:true;help:no;scroll:yes');document.forms[0][3].value='1';");


			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				string strToolTip = string.Format("Auhor: {0} &nbsp;<br/>Publisher:{1}&nbsp;<br/>", e.Item.Cells[4].Text, e.Item.Cells[5].Text);
				//strToolTip = @"<ul>" +
				//			"<li class='col-md-3>Author</li><li class='col-md-9'>" + Helpers.ReplaceQuote(e.Item.Cells[4].Text) + "</li>" +
				//			"<li class='col-md-3>Publisher</li><li class='col-md-9'>" + Helpers.ReplaceQuote(e.Item.Cells[5].Text) + "</li>" +
				//			"<li class='col-md-3>Segment</li><li class='col-md-9'>" + Helpers.ReplaceQuote(e.Item.Cells[6].Text) + "</li>" +
				//			"<li class='col-md-3>Category</li><li class='col-md-9'>" + Helpers.ReplaceQuote(e.Item.Cells[7].Text) + "</li>";
														 

				e.Item.Cells[2].Attributes.Add("onMouseOver", "drc('" + strToolTip + "'); return true;");
				e.Item.Cells[2].Attributes.Add("onMouseOut", "nd(); return true;");
				//e.Item.Attributes.Add("onMouseOver", "javascript:style.backgroundColor='#F5F5F5'");
				//e.Item.Attributes.Add("onmouseout", "javascript:style.backgroundColor='#FFFFFF'");
				//if (!(e.Item.Cells[3].Text.Equals("NO") || e.Item.Cells[3].Text.Equals("&nbsp;")))
				//{
				//	XmlDocument xdocXMLStatus = new XmlDocument();
				//	xdocXMLStatus.Load(Server.MapPath(Helpers.GetApplicationPath(this.Page)) + @"App_Data\MicroERP\Status.xml");
				//	e.Item.Cells[5].Text = ((XmlElement)xdocXMLStatus.SelectSingleNode("/TOPSTATUS/STATUS[CODE='" + e.Item.Cells[5].Text + "']/NAME")).InnerText;
				//}

				if (e.Item.Cells[3].Text.Equals("NO")) // if book issued flag is no, means available in  library
				{					
					e.Item.ForeColor = Color.Black;
					XmlDocument xdocXMLStatus = new XmlDocument();
					xdocXMLStatus.Load(Server.MapPath(Helpers.GetApplicationPath(this.Page)) + @"App_Data\MicroERP\Status.xml");
					e.Item.Cells[3].Text = ((XmlElement)xdocXMLStatus.SelectSingleNode("/TOPSTATUS/STATUS[CODE='" + e.Item.Cells[3].Text + "']/NAME")).InnerText;
				}
				else
				{
					e.Item.ForeColor = Color.Gray;
					XmlDocument xdocXMLStatus = new XmlDocument();
					xdocXMLStatus.Load(Server.MapPath(Helpers.GetApplicationPath(this.Page)) + @"App_Data\MicroERP\Status.xml");
					e.Item.Cells[3].Text = ((XmlElement)xdocXMLStatus.SelectSingleNode("/TOPSTATUS/STATUS[CODE='" + e.Item.Cells[3].Text + "']/NAME")).InnerText;
					 
					e.Item.Cells[3].ToolTip = "Already Issued To: <b>" + e.Item.Cells[8].Text +"</b>";
				}
			}
		}

		protected void dgrid_Books_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			dgrid_Books.CurrentPageIndex = e.NewPageIndex;
			BindGridviewSearchResult();
		}
	}
}