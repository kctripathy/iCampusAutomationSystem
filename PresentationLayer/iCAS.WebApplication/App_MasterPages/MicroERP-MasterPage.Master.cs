using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects.Administration;

namespace Micro.WebApplication.App_MasterPages
{
	public partial class MicroERP_MasterPage : System.Web.UI.MasterPage
	{
		#region Declaration
		public bool IECSS;
		public bool IE6CSS;
		public bool IE7CSS;
		public static class PageVars
		{
			public static bool HasDisplayedOnce = false;
		}

		public DateTime GetCalendarDate
		{
			get
			{
				//return ctrl_LeftColumn.GetMyCalendarSelectedDate;
                return DateTime.Now;
			}
			set
			{
				//ctrl_LeftColumn.GetMyCalendarSelectedDate = value;
			}
		}

		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			TreeView1.Visible = true;
			if (!IsPostBack)
			{
				GetAndSetWebApplicationProperties();
				//CompanyLogoAsImage();
				//lit_OfficeValue.Text = DisplayCompanyOfficeInformation();
				CheckNotification();
			}
			if (HttpContext.Current.Session["GeneratedMenuTextForAdmin"] != null)
			{
				lit_MenuItems.Text = HttpContext.Current.Session["GeneratedMenuTextForAdmin"].ToString();

				
			}
			SetBrowserOptionsforCSS();
            if (Connection.LoggedOnUser != null)
            {
                BindTreeview_Menus(BasePage.CurrentLoggedOnUser.TheUser.RoleID);
            }
		}

		private void DisplayCompanyLogoAsImage()
		{
			
		}

		public static string DisplayCompanyOfficeInformation()
		{
			string OfficeInfo = string.Empty;
			if (Connection.LoggedOnUser != null)
			{
				List<Office> OfficeList = Micro.BusinessLayer.Administration.OfficeManagement.GetInstance.GetOfficeTreeByUserID(Connection.LoggedOnUser.UserID);
				if (OfficeList != null)
				{
					if (OfficeList.Count == 1)
					{
						OfficeInfo = OfficeList[0].OfficeName + "/ ";
					}
					else
					{
						for (int ctr = 0; ctr < OfficeList.Count-1; ctr++)
						{
							OfficeInfo += String.Format("{0} {1} / ", OfficeList[ctr].OfficeName, OfficeList[ctr].OfficeTypeDescription);
						}
					}
				}

				if (OfficeInfo != string.Empty)
				{
					if (OfficeInfo.Length > 2)
					{
						OfficeInfo = OfficeInfo.ToUpper().Substring(0, OfficeInfo.Length - 2);
					}
				}
			}
			return OfficeInfo;
		}
		private void SetBrowserOptionsforCSS()
		{
			if (this.Page.Request.Browser.Type.Contains("IE"))
			{
				if (IECSS)
				{
					Page.Header.Controls.Add(new LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + Helpers.GetApplicationPath(this.Page) + "Themes/" + this.Page.Theme + "/CSS/MSIE/" + Helpers.GetFullPathPageName(this.Page) + ".css\" title=\"Default\" />"));
				}
				if (this.Page.Request.Browser.Type == "IE6")
				{
					if (IE6CSS)
					{
						Page.Header.Controls.Add(new LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + Helpers.GetApplicationPath(this.Page) + "Themes/" + this.Page.Theme + "/CSS/MSIE6/" + Helpers.GetFullPathPageName(this.Page) + ".css\" title=\"Default\" />"));
					}
				}
				else if (this.Page.Request.Browser.Type == "IE7")
				{
					if (IE7CSS)
					{
						Page.Header.Controls.Add(new LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + Helpers.GetApplicationPath(this.Page) + "Themes/" + this.Page.Theme + "/CSS/MSIE7/" + Helpers.GetFullPathPageName(this.Page) + ".css\" title=\"Default\" />"));
					}
				}
			}
		}

		private void CheckNotification()
		{
			// For dispaly notification : only once display for session
			if (HttpContext.Current.Session["DisplayedOnce"] == null)
			{
				HttpContext.Current.Session["DisplayedOnce"] = "NO";
			}
			else
			{
				if (HttpContext.Current.Session["DisplayedOnce"] == "NO")
				{
					DisplayNotification();
				}
			}
		}

		private void GetAndSetWebApplicationProperties()
		{
			string WebServerIP = @"http://" + ConfigurationManager.AppSettings["WebServerIP"].ToString();
			string HomePage = string.Format("<a href='{0}' >Home</a>", string.Concat(WebServerIP, "/Default.aspx"));
			string ContactPage = string.Format("<a href='{0}'>Contact</a>", string.Concat(WebServerIP, "/ContactUs.aspx"));
			string AppVer = Micro.WebApplication.App_MasterPages.Micro_Website.AssemblyVersion;
			string WebName = ConfigurationManager.AppSettings["ApplicationName"].ToString();

			// Display the version information
			lbl_Database.Text = ConfigurationManager.AppSettings["DefaultDatabaseEnviroment"].ToString();
			lbl_Version.Text = String.Format("{0} :: {1} v.{2} ] :: {3}", HomePage, WebName, AppVer, ContactPage);
			//this.Page.Title = string.Format("{0}  || {1} v.{2}]", Helpers.SplitCamelCase(Helpers.GetPageName(this.Page).Replace(".aspx", "")), WebName, AppVer);

			//ctrl_LeftColumn.Visible = ctrl_CustomisedMenu.Visible;	// Hide the left column calendar and emp of the month if no menu to display for the user
				
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Page.Header.DataBind();
		}
		#endregion

		private void DisplayNotification()
		{
			try
			{
                if (Micro.Commons.Connection.LoggedOnUser == null)
                {
                    ctrl_LoggedOnUser.Visible = false;
					divUserLogin.Visible = false;
                    return; // user has not logged into the application
                }
                else if (Micro.Commons.Connection.LoggedOnUser.UserName.ToUpper().Contains("ADMIN"))
                {
                    TreeView1.Visible = true;
                    ctrl_LoggedOnUser.Visible = false;
					divUserLogin.Visible = true;
                    BindTreeview_Menus(Micro.Commons.Connection.LoggedOnUser.RoleID);
                }

				
				string XMLFileNameAndPath = string.Concat(Server.MapPath("~"), ConfigurationManager.AppSettings["XMLFilePath_Miscellenous"]);
				XElement XmlElementNotifications = XElement.Load(XMLFileNameAndPath);

				IEnumerable<XElement> TheNotification = from nn in XmlElementNotifications.Elements("notifications")
														select nn;

				foreach (var notify in TheNotification)
				{
					lit_TheDialogMessage.Text = string.Empty;
					string TheMessageTextSpan = string.Empty;
					string TheMessageText = notify.Element("allUsers").Value;

					if (TheMessageText != null && TheMessageText.Length > 0)
					{
						TheMessageTextSpan = string.Format("<span id='ToAllUser'>{0}</span>",TheMessageText);
					}

					IEnumerable<XElement> TheUsers = from uu in notify.Elements("user") select uu;
					foreach (var usr in TheUsers)
					{
						string UserCode = usr.Attribute("id").Value;
						string FullName = usr.Attribute("name").Value;
						string WillDisplayFlag = usr.Attribute("willDisplay").Value;
						if (UserCode.Trim() == Micro.Commons.Connection.LoggedOnUser.UserName.Trim() && WillDisplayFlag.Equals("Y") && usr.Value.Trim().Length > 1)
						{
							lit_TheDialogMessage.Text = string.Format("<div id='NotificationDialogBox'>" +
																		"{0}" + 
																		"<span id='OnlyToTheUserName'>Message for: {1}</span>" +
																		"<span id='OnlyToTheUser'>{2}</span>" +
																		"</div>", TheMessageTextSpan, FullName, usr.Value.Replace("\n","<br/>"));

							dialog_Message.Show();
							HttpContext.Current.Session["DisplayedOnce"] = "YES";
							return;
						}
					}

					if (lit_TheDialogMessage.Text == string.Empty && TheMessageTextSpan.Length > 0)
					{
						lit_TheDialogMessage.Text = string.Format("<div id='NotificationDialogBox'>{0}</div>",TheMessageTextSpan);
						dialog_Message.Show();
						HttpContext.Current.Session["DisplayedOnce"] = "YES";
						return;
					}
				}
				
			}
			catch (Exception ex)
			{
				Micro.Commons.Log.Error(ex);
				HttpContext.Current.Session["DisplayedOnce"] = "WITH ERROR";
			}

		}

        private void BindTreeview_Menus(int roleId)
        {
            TreeNode MyParentNode;
            TreeNode MyChildNode;
			TreeView1.Visible = true;
            try
            {
                //List<WebMenu> CustomisedMenuList = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(0);
                List<WebMenu> CustomisedMenuListByRole = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(roleId);


                List<WebMenu> ParentMenuItems = (from m in CustomisedMenuListByRole
                                                 where m.ParentWebMenuID == -1
                                                 orderby m.DisplayOrder
                                                 select m).ToList<WebMenu>();


                TreeView1.Nodes.Clear();
                foreach (WebMenu objParentMenu in ParentMenuItems)
                {
                    string ParentWebMenu = objParentMenu.MenuDisplayText;
                    int ParentWebMenuID = objParentMenu.WebMenuID;
                    string ParentWebImage = objParentMenu.ImageURL;

                    MyParentNode = new TreeNode(ParentWebMenu, ParentWebMenuID.ToString());
                    //MyParentNode.Checked = WillSelectCheckBox(ParentWebMenuID, CustomisedMenuListByRole);

                    TreeView1.Nodes.Add(MyParentNode);

                    List<WebMenu> ChildMenuItems = (from mm in CustomisedMenuListByRole
                                                    where mm.ParentWebMenuID == objParentMenu.WebMenuID //&& mm.IsDeleted == false && mm.IsActive == true
                                                    orderby mm.DisplayOrder
                                                    select mm).ToList<WebMenu>();

                    if (ChildMenuItems.Count > 0)
                    {

                        foreach (WebMenu objChildMenu in ChildMenuItems)
                        {
                            string ChildWebMenu = objChildMenu.MenuDisplayText;
                            int ChildWebMenuID = objChildMenu.WebMenuID;

                            MyChildNode = new TreeNode();
                            MyChildNode.Text = ChildWebMenu;
                            MyChildNode.Value = ChildWebMenuID.ToString();
                            MyChildNode.ToolTip = objChildMenu.MenuToolTip;
                            //MyChildNode.Checked = WillSelectCheckBox(ChildWebMenuID, CustomisedMenuListByRole);

                            MyParentNode.ChildNodes.Add(MyChildNode);


                            List<WebMenu> ChildSubMenuItems = (from mmm in CustomisedMenuListByRole
                                                               where mmm.ParentWebMenuID == objChildMenu.WebMenuID //&& mmm.IsDeleted == false && mmm.IsActive == true
                                                               orderby mmm.DisplayOrder
                                                               select mmm).ToList<WebMenu>();
                            if (ChildSubMenuItems.Count > 0)
                            {
                                foreach (WebMenu objChildSubMenu in ChildSubMenuItems)
                                {
                                    string ChildWebSubMenu = objChildSubMenu.MenuDisplayText;

                                    TreeNode ChildNode2 = new TreeNode();
                                    ChildNode2 = new TreeNode();
                                    ChildNode2.Text = ChildWebSubMenu;
                                    ChildNode2.Value = objChildSubMenu.WebMenuID.ToString();
                                    //ChildNode2.Checked = WillSelectCheckBox(objChildSubMenu.WebMenuID, CustomisedMenuListByRole);
                                    ChildNode2.NavigateUrl = Helpers.ResolveURL(objChildSubMenu.NavigationURL);
                                    ChildNode2.ToolTip = objChildSubMenu.MenuToolTip;
                                   
                                    MyChildNode.ChildNodes.Add(ChildNode2);
                                }
                            }

                        }
                        MyParentNode.CollapseAll();

                    }

                }
                if (TreeView1.Nodes.Count > 1)
                {
                    TreeView1.Nodes[0].CollapseAll();
					TreeView1.Nodes[0].Expand();
					TreeView1.Visible = true;
                }
            }
            catch (Exception ex)
            {
				throw (ex);
            }
            //sbMenu.Append("</ul>");

        }
    }
}