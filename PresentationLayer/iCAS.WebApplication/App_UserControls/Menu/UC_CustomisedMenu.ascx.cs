
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using System.Configuration;

namespace Micro.WebApplication.App_UserControls
{
    /// <author>Kishor Ch. Tripathy</author>
    /// <summary>
    /// Depending upon the rights and permission for the role of the logged on user 
    /// This user control generates the customised menu for the application
    /// </summary>
    public partial class UC_CustomisedMenu : System.Web.UI.UserControl
    {
        public void HideThisMenu()
        {
            this.Visible = false;
        }

        private static string _TheUserMenuStyle;
        public static string TheUserMenuStyle
        {
            get
            {
                return _TheUserMenuStyle;
            }
            set
            {
                _TheUserMenuStyle = value;
            }
        }


        public static string GeneratedMenuText
        {
            get
            {
                string strGeneratedMenuText = HttpContext.Current.Session["GeneratedMenuText"].ToString();
                return strGeneratedMenuText;
            }
            set
            {
                HttpContext.Current.Session.Add("GeneratedMenuText", value);
            }
        }

        public static string GeneratedMenuTextForAdmin
        {
            get
            {
                string strGeneratedMenuText = HttpContext.Current.Session["GeneratedMenuTextForAdmin"].ToString();
                return strGeneratedMenuText;
            }
            set
            {
                HttpContext.Current.Session.Add("GeneratedMenuTextForAdmin", value);
            }
        }

        public static string GetCurrentMenuStyle()
        {
            string UserMenuStyle = "Micro_Default";
            if (Micro.Commons.BasePage.CurrentLoggedOnUser.UserSettings != null)
            {
                var TheCurrentMenuStyle = Micro.Commons.BasePage.CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.ToUpper().Trim().Equals(MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString()));

                if (TheCurrentMenuStyle != null)
                {
                    UserSetting s = (UserSetting)TheCurrentMenuStyle;
                    UserMenuStyle = s.UserSettingValue;
                    if (UserMenuStyle == "")
                        UserMenuStyle = "Micro_Default";
                }
            }

            return UserMenuStyle;
        }
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
           


            if (!IsPostBack)
            {
                if (Micro.Commons.Connection.LoggedOnUser == null)
                {

                    lit_CustomisedMenu.Text = (HttpContext.Current.Session["GeneratedMenuText"] == null 
                                    ?
                                    GenerateCustomisedMenu((int)MicroEnums.UserRole.Everyone)
                                    :
                                    HttpContext.Current.Session["GeneratedMenuText"].ToString()
                                    );
                    return;
                }

                string UserMenuStyle = "Micro_Default";
                var TheCurrentMenuStyle = Micro.Commons.BasePage.CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.ToUpper().Trim().Equals(MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString()));

                if (TheCurrentMenuStyle != null)
                {
                    UserSetting s = (UserSetting)TheCurrentMenuStyle;
                    UserMenuStyle = s.UserSettingValue;
                    if (UserMenuStyle == "")
                        UserMenuStyle = "Micro_Default";
                }

                //this.TheUserMenuStyle = UserMenuStyle;
                //lit_CustomisedMenu.Text = string.Concat(GenerateCustomisedMenu(), GenerateCustomisedMenuAdmin());
                lit_CustomisedMenu.Text = GenerateCustomisedMenu();
                GeneratedMenuTextForAdmin = GenerateCustomisedMenuAdmin();

            }
        }
        #endregion

        #region Methods

        public void MakeMenuSystem(int roleId)
        {
            //HttpContext.Current.Cache["MENU-SYS"] = GenerateCustomisedMenu(roleId);
        }

        private string GenerateCustomisedMenu(int roleId)
        {

            string ToolTipText;

            StringBuilder sbMenu = new StringBuilder();

            try
            {
                sbMenu.Append(string.Format("<ul id='{0}' class='topmenu'>", GetCurrentMenuStyle()));
                List<WebMenu> CustomisedMenuList = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(roleId, (int)MicroEnums.UserCompany.TSDC);

                List<WebMenu> ParentMenuItems = (from m in CustomisedMenuList
                                                 where m.ParentWebMenuID == -1
                                                 orderby m.DisplayOrder
                                                 select m).ToList<WebMenu>();

                foreach (WebMenu objParentMenu in ParentMenuItems)
                {
                    ToolTipText = objParentMenu.MenuToolTip;
                    string ParentWebMenu = objParentMenu.MenuDisplayText;
                    int ParentWebMenuID = objParentMenu.WebMenuID;
                    string ParentWebMenuLink = Helpers.ResolveURL(objParentMenu.NavigationURL);
                    string ParentWebImage = objParentMenu.ImageURL;

                    sbMenu.Append("<li class='topmenu'>");
					//if (!(ParentWebImage.ToString().Trim().Equals(string.Empty)))
					//{
					//	sbMenu.Append(string.Format("<img class='imgIcon' src='{0}' />", ParentWebImage));
					//}
					string TheParentMenuDisplayText = String.Format("<a href='{0}' title='{1}'>{3} {2}</a>", ParentWebMenuLink, ToolTipText, ParentWebMenu, ParentWebImage);
                    sbMenu.Append(TheParentMenuDisplayText);

                    List<WebMenu> ChildMenuItems = (from mm in CustomisedMenuList
                                                    where mm.ParentWebMenuID == objParentMenu.WebMenuID
                                                    orderby mm.DisplayOrder
                                                    select mm).ToList<WebMenu>();

                    if (ChildMenuItems.Count > 0)
                    {
                        sbMenu.Append("<ul>");

                        foreach (WebMenu objChildMenu in ChildMenuItems)
                        {
                            ToolTipText = objChildMenu.MenuToolTip;
                            string ChildWebMenu = objChildMenu.MenuDisplayText;
                            int ChildWebMenuID = objChildMenu.WebMenuID;
                            string ChildWebMenuLink = Helpers.ResolveURL(objChildMenu.NavigationURL);
                            string ChildWebImage = objChildMenu.ImageURL;
                            sbMenu.Append("<li>");

							//if (!(ChildWebImage.ToString().Trim().Equals(string.Empty)))
							//{
							//	sbMenu.Append(string.Format("<img class='imgIcon' src='{0}'  />", ChildWebImage));
							//}
							string TheChildMenuDisplayText = String.Format("<a href='{0}' title='{1}'>{3} {2}</a>", ChildWebMenuLink, ToolTipText, ChildWebMenu, ChildWebImage);
                            //sbMenu.Append(TheChildMenuDisplayText);

                            List<WebMenu> ChildSubMenuItems = (from mmm in CustomisedMenuList
                                                               where mmm.ParentWebMenuID == objChildMenu.WebMenuID
                                                               orderby mmm.DisplayOrder
                                                               select mmm).ToList<WebMenu>();
                            if (ChildSubMenuItems.Count > 0)
                            {
                                sbMenu.Append(string.Format("<span>{0}</span>", TheChildMenuDisplayText));
                                sbMenu.Append("<ul>");
                                foreach (WebMenu objChildSubMenu in ChildSubMenuItems)
                                {
                                    ToolTipText = objChildSubMenu.MenuToolTip;
                                    string ChildWebSubMenu = objChildSubMenu.MenuDisplayText;
                                    string ChildWebSubMenuURL = Helpers.ResolveURL(objChildSubMenu.NavigationURL);
                                    int ChildWebMenuSubID = objChildSubMenu.WebMenuID;
                                    sbMenu.Append("<li>");
                                    string TheChildSubMenuDisplayText = String.Format("<a href='{0}'  title='{1}'>{2}</a>", ChildWebSubMenuURL, ToolTipText, ChildWebSubMenu);
                                    sbMenu.Append(TheChildSubMenuDisplayText);
                                    sbMenu.Append("<li>");
                                }
                                sbMenu.Append("</ul>");
                            }
                            else
                            {
                                sbMenu.Append(string.Format("{0}", TheChildMenuDisplayText));
                            }
                            sbMenu.Append("</li>");

                        }
                        sbMenu.Append("</ul>");
                    }
                    sbMenu.Append("</li>");

                }
                //photogallery
                //string PhotoGalleryURL = String.Format(@"<a href='{0}' target='_blank'>PHTO GALLERY</a>", ConfigurationManager.AppSettings["PhotoGalleryURL"]);
                //sbMenu.Append(string.Format("<li class='topmenu'>{0}</li>", PhotoGalleryURL));

                //Login logout
                string LoginLogoutUrl = "";
                if (Micro.Commons.Connection.LoggedOnUser == null)
                {
                    LoginLogoutUrl = String.Format(@"<a href='http://{0}/APPS/UserLogin.aspx'>LOG IN</a>", ConfigurationManager.AppSettings["WebServerIP"]);
                }
                else
                {
                    LoginLogoutUrl = String.Format(@"<a href='http://{0}/APPS/Logout.aspx'>LOG OUT</a>", ConfigurationManager.AppSettings["WebServerIP"]);
                }
                sbMenu.Append(string.Format("<li class='topmenu'>{0}</li>", LoginLogoutUrl));

                ////register
                //string RegisterUrl = String.Format(@"<a href='http://{0}/Students.aspx'>REGISTER</a>", ConfigurationManager.AppSettings["WebServerIP"]);
                //sbMenu.Append(string.Format("<li class='topmenu'>{0}</li>", RegisterUrl));

                sbMenu.Append("</ul>");
            }
            catch (Exception ex)
            {
                Log.Error(ex, true);
                sbMenu = null;
            }
            //sbMenu.Append("</ul>");
            //TODO: KISHOR: REMOVE SESSION?
            GeneratedMenuText = sbMenu.ToString();
            return sbMenu.ToString();
        }



        private string GenerateCustomisedMenu()
        {

            string ToolTipText;

            StringBuilder sbMenu = new StringBuilder();
            try
            {
                sbMenu.Append(string.Format("<ul id='{0}' class='topmenu'>", "Micro_Default"));
                List<WebMenu> CustomisedMenuList = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(Micro.Commons.Connection.LoggedOnUser.RoleID);

                List<WebMenu> ParentMenuItems = (from m in CustomisedMenuList
                                                 where m.ParentWebMenuID == -1
                                                 orderby m.DisplayOrder
                                                 select m).ToList<WebMenu>();

                foreach (WebMenu objParentMenu in ParentMenuItems)
                {
                    ToolTipText = objParentMenu.MenuToolTip;
                    string ParentWebMenu = objParentMenu.MenuDisplayText;
                    int ParentWebMenuID = objParentMenu.WebMenuID;
                    string ParentWebMenuLink = Helpers.ResolveURL(objParentMenu.NavigationURL);
                    string ParentWebImage = objParentMenu.ImageURL;

                    sbMenu.Append("<li class='topmenu'>");
                    if (!(ParentWebImage.ToString().Trim().Equals(string.Empty)))
                    {
                        sbMenu.Append(string.Format("<img class='imgIcon' src='{0}' />", ParentWebImage));
                    }
                    string TheParentMenuDisplayText = String.Format("<a href='{0}' title='{1}'>{2}</a>", ParentWebMenuLink, ToolTipText, ParentWebMenu);
                    sbMenu.Append(TheParentMenuDisplayText);

                    List<WebMenu> ChildMenuItems = (from mm in CustomisedMenuList
                                                    where mm.ParentWebMenuID == objParentMenu.WebMenuID
                                                    orderby mm.DisplayOrder
                                                    select mm).ToList<WebMenu>();

                    if (ChildMenuItems.Count > 0)
                    {
                        sbMenu.Append("<ul>");

                        foreach (WebMenu objChildMenu in ChildMenuItems)
                        {
                            ToolTipText = objChildMenu.MenuToolTip;
                            string ChildWebMenu = objChildMenu.MenuDisplayText;
                            int ChildWebMenuID = objChildMenu.WebMenuID;
                            string ChildWebMenuLink = Helpers.ResolveURL(objChildMenu.NavigationURL);
                            string ChildWebImage = objChildMenu.ImageURL;
                            sbMenu.Append("<li>");

                            if (!(ChildWebImage.ToString().Trim().Equals(string.Empty)))
                            {
                                sbMenu.Append(string.Format("<img class='imgIcon' src='{0}' />", ChildWebImage));
                            }
                            string TheChildMenuDisplayText = String.Format("<a href='{0}' title='{1}'>{2}</a>", ChildWebMenuLink, ToolTipText, ChildWebMenu);
                            //sbMenu.Append(TheChildMenuDisplayText);

                            List<WebMenu> ChildSubMenuItems = (from mmm in CustomisedMenuList
                                                               where mmm.ParentWebMenuID == objChildMenu.WebMenuID
                                                               orderby mmm.DisplayOrder
                                                               select mmm).ToList<WebMenu>();
                            if (ChildSubMenuItems.Count > 0)
                            {
                                sbMenu.Append(string.Format("<span>{0}</span>", TheChildMenuDisplayText));
                                sbMenu.Append("<ul>");
                                foreach (WebMenu objChildSubMenu in ChildSubMenuItems)
                                {
                                    ToolTipText = objChildSubMenu.MenuToolTip;
                                    string ChildWebSubMenu = objChildSubMenu.MenuDisplayText;
                                    string ChildWebSubMenuURL = Helpers.ResolveURL(objChildSubMenu.NavigationURL);
                                    int ChildWebMenuSubID = objChildSubMenu.WebMenuID;
                                    sbMenu.Append("<li>");
                                    string TheChildSubMenuDisplayText = String.Format("<a href='{0}'  title='{1}'>{2}</a>", ChildWebSubMenuURL, ToolTipText, ChildWebSubMenu);
                                    sbMenu.Append(TheChildSubMenuDisplayText);
                                    sbMenu.Append("<li>");
                                }
                                sbMenu.Append("</ul>");
                            }
                            else
                            {
                                sbMenu.Append(string.Format("{0}", TheChildMenuDisplayText));
                            }
                            sbMenu.Append("</li>");

                        }
                        sbMenu.Append("</ul>");
                    }
                    sbMenu.Append("</li>");

                }

                //photogallery
                //string PhotoGalleryURL = String.Format(@"<a href='{0}' target='_blank'>PHTO GALLERY</a>", ConfigurationManager.AppSettings["PhotoGalleryURL"]);
                //sbMenu.Append(string.Format("<li class='topmenu'>{0}</li>", PhotoGalleryURL));

                string LogoutUrl = String.Format(@"<a href='http://{0}/APPS/Logout.aspx'>LOG OUT</a>", ConfigurationManager.AppSettings["WebServerIP"]);
                sbMenu.Append(string.Format("<li class='topmenu'>{0}</li>", LogoutUrl));
                sbMenu.Append("</ul>");
            }
            catch (Exception ex)
            {
                Log.Error(ex, true);
                sbMenu = null;
            }
            //sbMenu.Append("</ul>");

            return sbMenu.ToString();
        }

        private string GenerateCustomisedMenuAdmin()
        {

            string ToolTipText;

            StringBuilder sbMenu = new StringBuilder();
            try
            {
                string theStyle = "z-index: 9999;  background-color: rgb(226, 240, 255); position: fixed;  top:0px; border-bottom: 1px #ccc solid; margin: 0px 26%;   width: 65%;";
                sbMenu.Append(string.Format("<ul id='{0}' class='topmenu'>", "Blue_Vertical"));
                List<WebMenu> CustomisedMenuList = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(Micro.Commons.Connection.LoggedOnUser.RoleID);
                
                int parentMenuID = 9;
                if (!Micro.Commons.Connection.LoggedOnUser.RoleID.Equals(9))
                {
                    return "";
                }
                List<WebMenu> ParentMenuItems = (from m in CustomisedMenuList
                                                 where m.ParentWebMenuID == parentMenuID
                                                 orderby m.DisplayOrder
                                                 select m).ToList<WebMenu>();

                foreach (WebMenu objParentMenu in ParentMenuItems)
                {
                    ToolTipText = objParentMenu.MenuToolTip;
                    string ParentWebMenu = objParentMenu.MenuDisplayText;
                    int ParentWebMenuID = objParentMenu.WebMenuID;
                    string ParentWebMenuLink = Helpers.ResolveURL(objParentMenu.NavigationURL);
                    string ParentWebImage = objParentMenu.ImageURL;

                    sbMenu.Append("<li class='topmenu'>");
                    if (!(ParentWebImage.ToString().Trim().Equals(string.Empty)))
                    {
                        sbMenu.Append(string.Format("<span><img class='imgIcon' src='{0}' /></span>", ParentWebImage));
                    }
                    string TheParentMenuDisplayText = String.Format("<a href='{0}' title='{1}'>{2}</a>", ParentWebMenuLink, ToolTipText, ParentWebMenu);
                    sbMenu.Append(TheParentMenuDisplayText);

                    List<WebMenu> ChildMenuItems = (from mm in CustomisedMenuList
                                                    where mm.ParentWebMenuID == objParentMenu.WebMenuID
                                                    orderby mm.DisplayOrder
                                                    select mm).ToList<WebMenu>();

                    if (ChildMenuItems.Count > 0)
                    {
                        sbMenu.Append("<ul>");

                        foreach (WebMenu objChildMenu in ChildMenuItems)
                        {
                            ToolTipText = objChildMenu.MenuToolTip;
                            string ChildWebMenu = objChildMenu.MenuDisplayText;
                            int ChildWebMenuID = objChildMenu.WebMenuID;
                            string ChildWebMenuLink = Helpers.ResolveURL(objChildMenu.NavigationURL);
                            string ChildWebImage = objChildMenu.ImageURL;
                            sbMenu.Append("<li>");

                            if (!(ChildWebImage.ToString().Trim().Equals(string.Empty)))
                            {
                                sbMenu.Append(string.Format("<span><img class='imgIcon' src='{0}' /></span>", ChildWebImage));
                            }
                            string TheChildMenuDisplayText = String.Format("<a href='{0}' title='{1}'>{2}</a>", ChildWebMenuLink, ToolTipText, ChildWebMenu);
                            //sbMenu.Append(TheChildMenuDisplayText);

                            List<WebMenu> ChildSubMenuItems = (from mmm in CustomisedMenuList
                                                               where mmm.ParentWebMenuID == objChildMenu.WebMenuID
                                                               orderby mmm.DisplayOrder
                                                               select mmm).ToList<WebMenu>();
                            if (ChildSubMenuItems.Count > 0)
                            {
                                sbMenu.Append(string.Format("<span>{0}</span>", TheChildMenuDisplayText));
                                sbMenu.Append("<ul>");
                                foreach (WebMenu objChildSubMenu in ChildSubMenuItems)
                                {
                                    ToolTipText = objChildSubMenu.MenuToolTip;
                                    string ChildWebSubMenu = objChildSubMenu.MenuDisplayText;
                                    string ChildWebSubMenuURL = Helpers.ResolveURL(objChildSubMenu.NavigationURL);
                                    int ChildWebMenuSubID = objChildSubMenu.WebMenuID;
                                    sbMenu.Append("<li>");
                                    string TheChildSubMenuDisplayText = String.Format("<a href='{0}'  title='{1}'>{2}</a>", ChildWebSubMenuURL, ToolTipText, ChildWebSubMenu);
                                    sbMenu.Append(TheChildSubMenuDisplayText);
                                    sbMenu.Append("<li>");
                                }
                                sbMenu.Append("</ul>");
                            }
                            else
                            {
                                sbMenu.Append(string.Format("{0}", TheChildMenuDisplayText));
                            }
                            sbMenu.Append("</li>");

                        }
                        sbMenu.Append("</ul>");
                    }
                    sbMenu.Append("</li>");

                }

                //photogallery
                //string PhotoGalleryURL = String.Format(@"<a href='{0}' target='_blank'>PHTO GALLERY</a>", ConfigurationManager.AppSettings["PhotoGalleryURL"]);
                //sbMenu.Append(string.Format("<li class='topmenu'>{0}</li>", PhotoGalleryURL));

                //string LogoutUrl = String.Format(@"<a href='http://{0}/APPS/Logout.aspx'>LOG OUT</a>", ConfigurationManager.AppSettings["WebServerIP"]);
                //sbMenu.Append(string.Format("<li class='topmenu'>{0}</li>", LogoutUrl));
                sbMenu.Append("</ul>");
            }
            catch (Exception ex)
            {
                Log.Error(ex, true);
                sbMenu = null;
            }
            //sbMenu.Append("</ul>");

            return sbMenu.ToString();
            //return "";
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect( "/websearchform.aspx");
        }
    }
}