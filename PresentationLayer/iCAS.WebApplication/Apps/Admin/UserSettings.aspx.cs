using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Objects.Administration;
using Micro.Framework.ReadXML;

namespace Micro.WebApplication.MicroERP.ADMIN
{
    public partial class UserSettings : BasePage
    {
        #region Declaration
        protected static class PageVariables
        {
            public static List<UserSetting> UserSettingsList;
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                Session["SettingKey"] = string.Empty;
                Session["SettingValue"] = string.Empty;
                BindGrid_UserSettings();
            }
        }

        protected void gview_UserSettings_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            return;
        }

        protected void gview_UserSettings_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gview_UserSettings.EditIndex = -1;
            BindGrid_UserSettings();
        }

        protected void gview_UserSettings_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gview_UserSettings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserSetting theSettingRow = (UserSetting)e.Row.DataItem;


                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList theDropDown = (DropDownList)e.Row.FindControl("ddl_UserSettingValue");
                    if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_PAGE.ToString()))
                    {
                        List<WebMenu> theWebMenu = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(Micro.Commons.Connection.LoggedOnUser.RoleID);

                        foreach (WebMenu wm in theWebMenu)
                        {
                            //if (wm.CanRedirectAfterUserLogin == "YES")
                            //{
                            if (!wm.NavigationURL.Equals("#"))
                            {
                                ListItem theListItem = new ListItem();
                                theListItem.Text = wm.NavigationURL;
                                theDropDown.Items.Add(theListItem);
                            }
                                
                           // }
                        }
                    }
                    else if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString()))
                    {
                        List<CommonKey> theCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString());
                        foreach (CommonKey ck in theCommonKeyList)
                        {
                            ListItem theListItem = new ListItem();
                            theListItem.Text = ck.CommonKeyValue;
                            theDropDown.Items.Add(theListItem);
                        }

                    }
                    else if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString()))
                    {
                        List<CommonKey> theCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString());
                        foreach (CommonKey ck in theCommonKeyList)
                        {
                            ListItem theListItem = new ListItem();
                            theListItem.Text = ck.CommonKeyValue;
                            theDropDown.Items.Add(theListItem);
                        }

                    }
                }
                else
                {
                    Literal theLiteral = (Literal)e.Row.FindControl("lit_SettingValue");
                    if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_PAGE.ToString()))
                    {
                        theLiteral.Text = GetUserSettingValue(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_PAGE.ToString());
                    }
                    else if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString()))
                    {
                        theLiteral.Text = GetUserSettingValue(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString());
                    }
                    else if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString()))
                    {
                        theLiteral.Text = GetUserSettingValue(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString());
                    }
                }
            }
        }

        protected void gview_UserSettings_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gview_UserSettings.EditIndex = e.NewEditIndex;
            BindGrid_UserSettings();
        }

        protected void gview_UserSettings_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //e.Cancel = true;
            DropDownList theDropDown = (DropDownList)gview_UserSettings.Rows[e.RowIndex].FindControl("ddl_UserSettingValue");
            Literal theLiteral = (Literal)gview_UserSettings.Rows[e.RowIndex].FindControl("lit_SettingKeyName");
            Session["SettingKey"] = theLiteral.Text;
            Session["SettingValue"] = theDropDown.SelectedItem.Text;
            InsertUserSetting();
            gview_UserSettings.EditIndex = -1;
            BindGrid_UserSettings();
        }

        #endregion

        #region Methods
        //public List<string> GetDefaultPageList()
        //{
        //    List<WebMenu> theWebMenu = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(Micro.Commons.Connection.LoggedOnUser.RoleID); ;
        //    List<string> MenuStyle_collection = new List<string>();
        //    List<WebMenu> WebMenuList = (from m in theWebMenu
        //                                 where m.ParentWebMenuID != -1
        //                                 select m).ToList<WebMenu>();

        //    List<WebMenu> BindMenuItems = (from m in theWebMenu
        //                                       where
        //                                          m.ParentWebMenuID != -1 &&
        //                                          m.NavigationURL.Trim().Length > 0 &&
        //                                          !m.NavigationURL.ToLower().Contains("reports")
        //                                       orderby m.ParentWebMenuID, m.DisplayOrder
        //                                       select m).ToList<WebMenu>();

        //    foreach (WebMenu wm in WebMenuList)
        //    {
        //        MenuStyle_collection.Add(wm.MenuDisplayText);
        //    }
        //    return MenuStyle_collection;
        //}

        public List<string> GetAllMenuStyles()
        {
            List<string> MenuStyle_collection = new List<string>();
            List<CommonKey> theCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList();
            foreach (CommonKey ck in theCommonKeyList)
            {
                if (ck.CommonKeyName == "MENU_STYLE")
                {
                    MenuStyle_collection.Add(ck.CommonKeyValue);
                }
            }

            return MenuStyle_collection;
        }

        public string GetUserSettingValue(string theSettingKey)
        {
            var ReturnValue = "N/A";
            var SettingKeyValue = CurrentLoggedOnUser.UserSettings.Find(s => s.UserSettingKeyName.ToUpper().Trim().Equals(theSettingKey));

            if (SettingKeyValue != null)
            {
                UserSetting s = (UserSetting)SettingKeyValue;
                ReturnValue = s.UserSettingValue;
            }
            return ReturnValue;

        }

        private void BindLiteralValues(GridViewRowEventArgs e)
        {
            UserSetting theSettingRow = (UserSetting)e.Row.DataItem;
            DropDownList theDropDown = (DropDownList)e.Row.FindControl("ddl_UserSettingValue");
            Literal theLiteral = (Literal)e.Row.FindControl("lit_SettingValue");

            if (theLiteral == null)
            {
                return;
            }
            //theDropDown.Visible = true;
            if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_PAGE.ToString()))
            {
                theLiteral.Text = GetUserSettingValue(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_PAGE.ToString());
                List<WebMenu> theWebMenu = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(Micro.Commons.Connection.LoggedOnUser.RoleID);
                List<WebMenu> theMenuList = (from m in theWebMenu
                                             where (m.NavigationURL.Length > 0 && m.NavigationURL != "#")
                                             select m).OrderBy(a=> a.NavigationURL).ToList();


                theDropDown.DataSource = theMenuList;
                theDropDown.DataTextField = "MenuDisplayText";
                theDropDown.DataValueField = "NavigationURL";
            }
            else if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString()))
            {
                theLiteral.Text = GetUserSettingValue(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString());
                List<CommonKey> theCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString());
                theDropDown.DataSource = theCommonKeyList;
                theDropDown.DataTextField = "CommonKeyValue";
                theDropDown.DataValueField = "CommonKeyName";

            }
            else if (theSettingRow.UserSettingKeyName.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString()))
            {
                theLiteral.Text = GetUserSettingValue(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString());
                List<CommonKey> theCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString());
                theDropDown.DataSource = theCommonKeyList;
                theDropDown.DataTextField = "CommonKeyValue";
                theDropDown.DataValueField = "CommonKeyName";
            }
        }

        public void BindGrid_UserSettings()
        {
            if (PageVariables.UserSettingsList == null)
            {
                PageVariables.UserSettingsList = UserManagement.GetInstance.GetUserSettingList();
            }
            if (PageVariables.UserSettingsList.Count > 0)
            {
                gview_UserSettings.DataSource = PageVariables.UserSettingsList;
                gview_UserSettings.DataBind();
            }
            //List<UserSetting> theSettingsList = UserManagement.GetInstance.GetUserSettingList();
            //gview_UserSettings.DataSource = PageVariables.UserSettingsList;
            //gview_UserSettings.DataBind();
        }

        private void BindDropdown(ref DropDownList theDropDown, string SettingKey)
        {

            //theLiteral.Text = GetUserSettingValue(UserSettingEnum.MENU_STYLE.ToString());


            if (SettingKey.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_PAGE.ToString()))
            {
                List<WebMenu> theWebMenu = WebMenuManagement.GetInstance.SelectAllMenuItemsByRoleId(Micro.Commons.Connection.LoggedOnUser.RoleID);

                List<WebMenu> BindMenuItems = (from m in theWebMenu
                                               where
                                                  m.ParentWebMenuID != -1 &&
                                                  m.NavigationURL.Trim().Length > 0 &&
                                                  !m.NavigationURL.ToLower().Contains("reports")
                                               orderby m.ParentWebMenuID, m.DisplayOrder
                                               select m).ToList<WebMenu>();

                theDropDown.DataSource = BindMenuItems;
                theDropDown.DataTextField = "NavigationURL";
                theDropDown.DataValueField = "NavigationURL";
            }
            else if (SettingKey.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString()))
            {
                List<CommonKey> theCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList(Micro.Commons.MicroEnums.UserSettingKey.USER_DEFAULT_MODE.ToString());
                theDropDown.DataSource = theCommonKeyList;
                theDropDown.DataTextField = "CommonKeyValue";
                theDropDown.DataValueField = "CommonKeyName";

            }
            else if (SettingKey.Equals(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString()))
            {
                List<CommonKey> theCommonKeyList = CommonKeyManagement.GetInstance.GetCommonKeyList(Micro.Commons.MicroEnums.UserSettingKey.USER_MENU_STYLE.ToString());
                theDropDown.DataSource = theCommonKeyList;
                theDropDown.DataTextField = "CommonKeyValue";
                theDropDown.DataValueField = "CommonKeyName";
            }
            theDropDown.DataBind();
            //theDropDown.AutoPostBack = true;
            //theDropDown.SelectedIndexChanged += ddl_UserSettingValue_SelectedIndexChanged;
        }

        public void InsertUserSetting()
        {
            int ProcReturnValue = 0;
            string theSettingKey = Session["SettingKey"].ToString();
            string theSettingValue = Session["SettingValue"].ToString();

            if (theSettingValue.Length == 0)
            {
                lbl_TheMessage.Text = "No values set for updation";
                dialog_Message.Show();
                return;
            }

            ProcReturnValue = UserManagement.GetInstance.SaveUserSettings(theSettingKey, theSettingValue);
            if (ProcReturnValue > 0)
            {
                lbl_TheMessage.Text = ReadXML.GetSuccessMessage("OK_USERSETTING_ADDED");
                dialog_Message.Show();
                //Login.GetAndSetUserSettings();
                BindGrid_UserSettings();
            }
            else
            {
                lbl_TheMessage.Text = ReadXML.GetFailureMessage("KO_USERSETTING_ADDED");
                dialog_Message.Show();
            }
        }
        #endregion
    }
}