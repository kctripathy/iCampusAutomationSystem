using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Micro.Objects.Administration;
using Micro.BusinessLayer.Administration;
using Micro.Commons;
using Micro.Framework.ReadXML;
using System.Drawing;
using System.Web;

namespace Micro.WebApplication.MicroERP.ADMIN
{
    /// <summary>
    /// Add,Edit&Delete MenuItems
    /// 
    /// <Author>
    /// Premananda Routray
    /// </Author>
    /// </summary>
    public partial class MenuItems : BasePage
    {

        #region Declarations
        //Page Variables  modified on Dt.19-Feb-2013
        protected static class PageVariables
        {
            public static WebMenu TheMenuItem
            {
                get
                {
                    WebMenu TheWebMenu = HttpContext.Current.Session["TheMenuItem"] as WebMenu;
                    return TheWebMenu;
                }
                set
                {
                    HttpContext.Current.Session.Add("TheMenuItem", value);
                }
            }
            //TODO Exclude Session variable for List type.
            public static List<WebMenu> MenuList
            {
                get
                {
                    List<WebMenu> TheMenuList = HttpContext.Current.Session["MenuList"] as List<WebMenu>;
                    return TheMenuList;
                }
                set
                {
                    HttpContext.Current.Session.Add("MenuList", value);
                }
            }
            public static string WebMenuID
            {
                get
                {
                    string TheWebMenuID = HttpContext.Current.Session["WebMenuID"].ToString();
                    return TheWebMenuID;
                }
                set
                {
                    HttpContext.Current.Session.Add("WebMenuID", value);
                }
            }

            public static string ParentWebMenuID
            {
                get
                {
                    string TheParentWebMenuID = HttpContext.Current.Session["ParentWebMenuID"].ToString();
                    return TheParentWebMenuID;
                }
                set
                {
                    HttpContext.Current.Session.Add("ParentWebMenuID", value);
                }
            }
            public static string SubWebMenuID
            {
                get
                {
                    string TheSubMenuID = HttpContext.Current.Session["SubWebMenuID"].ToString();
                    return TheSubMenuID;
                }
                set
                {
                    HttpContext.Current.Session.Add("SubWebMenuID", value);
                }
            }
            public static string SubParentWebMenuID
            {
                get
                {
                    string TheSubParentWebMenuID = HttpContext.Current.Session["SubParentWebMenuID"].ToString();
                    return TheSubParentWebMenuID;
                }
                set
                {
                    HttpContext.Current.Session.Add("SubParentWebMenuID", value);
                }
            }

            //public static int RowIndex;
        }

        #endregion

        #region Events For Menu

        protected void Page_Load(object sender, EventArgs e)
        {
            //PageVariables.MenuList = new List<WebMenu>();
            //PageVariables.MenuList = WebMenuManagement.GetInstance.GetWebMenusAll();
            if (!IsPostBack)
            {
                //BasePage.CurrentLoggedOnUser.ClientPage = this.Page;
                //BasePage.ShowHidePagePermissions(gview_Menu, btn_New, this.Page);
                BindDropDown_MenuHeads();
                multiView_MenuItems.SetActiveView(view_MenuItemEntry);

                SetFormMessage();
                ddl_SubMenu.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
            }
            //((UC_Menu)Master.FindControl("ctrl_Menu")).SetActiveIndex = 5;

            Session["SubMenuID"] = "";
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {

            lbl_ErrorMessage.Text = string.Empty;
            lbl_Message.Text = string.Empty;
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;
            if (btn_Save.Text == MicroEnums.DataOperation.Save.GetStringValue() && btn_Bottom_Save.Text == MicroEnums.DataOperation.Save.GetStringValue())
            {
                lbl_ErrorMessage.Text = string.Empty;
                if (ValidateFormFields())
                {

                    ProcReturnValue = Save_MenuItems();
                    lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Menu Items", MicroEnums.DataOperation.AddNew);
                    dialog_Message.Show();

                }
            }

            else
            {

                ProcReturnValue = UpdateRecord();
                dialog_Message.Show();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Menu Items", MicroEnums.DataOperation.Edit);

            }
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                BindGrid_MenuItems();
                ResetTextBoxes();
                ResetBackColor(view_MenuItemEntry);
            }
        }

        protected void ddl_MenuHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid_MenuItems();
            BindSubMenu();
        }

        protected void gview_Menu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                PageVariables.WebMenuID = ((Label)gview_Menu.Rows[RowIndex].FindControl("lbl_WebMenuID")).Text;
                PageVariables.ParentWebMenuID = ((Label)gview_Menu.Rows[RowIndex].FindControl("lbl_ParentID")).Text;
            }
            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {
                btn_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Update.GetStringValue());
                btn_Bottom_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Update.GetStringValue());

                multiView_MenuItems.SetActiveView(view_MenuItemEntry);
                PopulatePageFields(int.Parse(PageVariables.WebMenuID));
                BindGridSubMenu(int.Parse(PageVariables.WebMenuID));
                BindSubMenuItem();
                gview_SubMenu.Visible = true;
            }

        }

        protected void gview_Menu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_Menu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ProcReturnValue = 0;

            WebMenu theWebMenu = new WebMenu();

            int TheWebMenuID = int.Parse(PageVariables.WebMenuID);
            theWebMenu.WebMenuID = TheWebMenuID;
            ProcReturnValue = WebMenuManagement.GetInstance.DeleteMenuItems(theWebMenu);

            dialog_Message.Show();

            lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Menu Items", MicroEnums.DataOperation.Delete);
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                gview_Menu.EditIndex = -1;
                BindGrid_MenuItems();
            }

        }

        protected void gview_Menu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gview_Menu.PageIndex = e.NewPageIndex;
            BindGrid_MenuItems();
        }

        protected void gview_Menu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 7);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                    BasePage.GridViewToolTips(e, 6, 7);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btn_New_Click(object sender, EventArgs e)
        {
            lbl_ErrorMessage.Text = string.Empty;
            multiView_MenuItems.SetActiveView(view_MenuItemEntry);
            ResetBackColor(view_MenuItemEntry);
            ResetTextBoxes();

        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            if (ddl_MenuHead.SelectedIndex == 0)
            {
                lbl_ErrorMessage.Text = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "MenuHeads");
                ddl_MenuHead.SelectedIndex = 1;
            }
            else
            {
                lbl_ErrorMessage.Text = string.Empty;
                multiView_MenuItems.SetActiveView(view_GridView);
                BindGrid_MenuItems();
            }

        }



        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
            ddl_MenuHead.Enabled = true;
            ResetBackColor(view_MenuItemEntry);
        }

        #endregion

        #region Methods For Menu

        private void BindDropDown_MenuHeads()
        {
            try
            {
                //var MenuHead = from m in PageVariables.MenuList
                //               where m.ParentWebMenuID == -1
                //               select m;

                //ddl_MenuHead.DataSource = MenuHead;
                ddl_MenuHead.DataSource = WebMenuManagement.GetInstance.GetParentWebMenuAll();
                ddl_MenuHead.DataTextField = WebMenuManagement.GetInstance.DisplayMember;
                ddl_MenuHead.DataValueField = WebMenuManagement.GetInstance.ValueMember;
                ddl_MenuHead.DataBind();
                ddl_MenuHead.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
            }
            catch
            {
            }
        }

        private void BindGrid_MenuItems()
        {
            gview_Menu.Columns[0].Visible = false;
            gview_Menu.Columns[1].Visible = false;

            if (Session["SubMenuID"].ToString() == "")
            {
                List<WebMenu> TheMenuList = WebMenuManagement.GetInstance.GetWebMenuAllByParentWebMenuID(int.Parse(ddl_MenuHead.SelectedValue));
                gview_Menu.DataSource = TheMenuList;
                gview_Menu.DataBind();
            }
            else if (ddl_MenuHead.SelectedValue != MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT)
            {
                List<WebMenu> TheMenuList = WebMenuManagement.GetInstance.GetWebMenuAllByParentWebMenuID(int.Parse(ddl_SubMenuHead.SelectedValue));
                gview_Menu.DataSource = TheMenuList;
                gview_Menu.DataBind();
            }
            else
            {
                gview_Menu.DataSource = null;
                gview_Menu.DataBind();
            }
        }

        private bool ValidateFormFields()
        {

            return true;
        }

        private int Save_MenuItems()
        {
            int ProcReturnValue = 0;

            WebMenu TheWebMenu = new WebMenu();

            TheWebMenu.MenuDisplayText = txt_MenuDisplayText.Text;
            TheWebMenu.NavigationURL = txt_NavigationUrl.Text;
            TheWebMenu.MenuToolTip = txt_MenuToolTip.Text;
            if (!string.IsNullOrEmpty(txt_DisplayOrder.Text))
            {
                TheWebMenu.DisplayOrder = int.Parse(txt_DisplayOrder.Text.ToString());
            }
            if (!ddl_SubMenu.SelectedValue.Equals(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT))
            {

                TheWebMenu.ParentWebMenuID = int.Parse(ddl_SubMenu.SelectedValue);
            }
            else
            {
                TheWebMenu.ParentWebMenuID = int.Parse(ddl_MenuHead.SelectedValue);

            }
            ProcReturnValue = WebMenuManagement.GetInstance.InsertMenuItems(TheWebMenu);

            return ProcReturnValue;

        }

        private void SetFormMessage()
        {

            requiredFieldValidator_MenuHeads.InitialValue = MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT;
            requiredFieldValidator_MenuHeads.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "MenuHeads");
            requiredFieldValidator_MenuDisplayText.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Menu Diplay Text");
            requiredFieldValidator_NavigationUrl.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "NavigationUrl");
            requiredFieldValidator_SubMenuDisplayText.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Menu Diplay Text");
            requiredFieldValidator_SubMenuNavigationURL.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "NavigationUrl");
            //requiredFieldValidator_DisplayOrder.ErrorMessage = ReadXML.GetGeneralMessage("FIELD_CAN_NOT_EMPTY", "Display Order");
            regularExpressionValidator_DisplayOrder.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");
            regularExpressionValidator_SubMenuDisplayOrder.ErrorMessage = ReadXML.GetGeneralMessage("REGEX_NUMBER_WITH_SPACE");

            regularExpressionValidator_SubMenuDisplayOrder.ValidationExpression = MicroConstants.REGEX_NUMBER_WITH_SPACE;


            SetFormMessageCssClass("ValidateMessage");
        }

        private void SetFormMessageCssClass(string theCssClass)
        {
            requiredFieldValidator_MenuHeads.CssClass = theCssClass;
            requiredFieldValidator_MenuDisplayText.CssClass = theCssClass;
            requiredFieldValidator_NavigationUrl.CssClass = theCssClass;
            //requiredFieldValidator_DisplayOrder.CssClass = theCssClass;
            regularExpressionValidator_DisplayOrder.CssClass = theCssClass;
            requiredFieldValidator_SubMenuDisplayText.CssClass = theCssClass;
            requiredFieldValidator_SubMenuNavigationURL.CssClass = theCssClass;
            regularExpressionValidator_SubMenuDisplayOrder.CssClass = theCssClass;
            lbl_Message.CssClass = theCssClass;
            lbl_ErrorMessage.CssClass = theCssClass;

        }

        private bool ValidateDuplicateValue()
        {
            bool ReturnValue = true;
            for (int i = 0; i < gview_Menu.Rows.Count; i++)
            {
                for (int col = 0; col < gview_Menu.Rows[i].Cells.Count; col++)
                {
                    string TheDisplayOrder = gview_Menu.Rows[i].Cells[col].Controls.ToString();

                    string theMenuDisplaytext = gview_Menu.Rows[i].Cells[col].Text;
                    string theMenuNavigationUrl = gview_Menu.Rows[i].Cells[col].Text;
                    if (theMenuDisplaytext.Equals(txt_MenuDisplayText.Text) && theMenuNavigationUrl.Equals(txt_NavigationUrl.Text))
                    {
                        lbl_Message.Text = ReadXML.GetFailureMessage("DUPLICATE_RECORD");
                        txt_MenuDisplayText.Text = string.Empty;
                        txt_NavigationUrl.Text = string.Empty;
                        txt_MenuDisplayText.Focus();
                        ReturnValue = false;
                    }

                    if (theMenuDisplaytext.Equals(txt_MenuDisplayText.Text))
                    {
                        lbl_Message.Text = ReadXML.GetFailureMessage("DUPLICATE_RECORD");
                        txt_MenuDisplayText.Text = string.Empty;
                        txt_MenuDisplayText.Focus();
                        ReturnValue = false;

                    }

                    if (theMenuNavigationUrl.Equals(txt_NavigationUrl.Text))
                    {
                        lbl_Message.Text = ReadXML.GetFailureMessage("DUPLICATE_RECORD");
                        txt_NavigationUrl.Text = string.Empty;
                        txt_NavigationUrl.Focus();

                        ReturnValue = false;
                    }

                }
            }
            return ReturnValue;

        }

        private int UpdateRecord()
        {
            WebMenu theMenu = new WebMenu();
            theMenu.MenuDisplayText = txt_MenuDisplayText.Text;
            theMenu.MenuToolTip = txt_MenuToolTip.Text;
            theMenu.NavigationURL = txt_NavigationUrl.Text;
            if (!string.IsNullOrEmpty(txt_DisplayOrder.Text))
            {
                theMenu.DisplayOrder = int.Parse(txt_DisplayOrder.Text);
            }
            theMenu.WebMenuID = int.Parse(PageVariables.WebMenuID);
            theMenu.ParentWebMenuID = int.Parse(ddl_MenuHead.SelectedValue);
            int ProcReturnValue = WebMenuManagement.GetInstance.UpdateMenuItems(theMenu);
            return ProcReturnValue;
        }

        private void ResetTextBoxes()
        {
            txt_MenuDisplayText.Text = string.Empty;
            txt_MenuToolTip.Text = string.Empty;
            txt_NavigationUrl.Text = string.Empty;
            txt_DisplayOrder.Text = string.Empty;
            ddl_MenuHead.SelectedIndex = 0;
            ddl_SubMenu.SelectedIndex = 0;
            lbl_ErrorMessage.Text = string.Empty;
            btn_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Save.GetStringValue());
            btn_Bottom_Save.Text = string.Format("{0}", MicroEnums.DataOperation.Save.GetStringValue());
        }

        private void PopulatePageFields(int theWebMenuId)
        {
            WebMenu TheWebMenu = WebMenuManagement.GetInstance.GetWebMenuByWebMenuID(theWebMenuId);
            txt_MenuDisplayText.Text = TheWebMenu.MenuDisplayText;
            txt_MenuToolTip.Text = TheWebMenu.MenuToolTip;
            txt_NavigationUrl.Text = TheWebMenu.NavigationURL;

            txt_DisplayOrder.Text = TheWebMenu.DisplayOrder.ToString();


            ChangeBackColor(view_MenuItemEntry);

        }

        private void ChangeControlsBackColor()
        {
            txt_MenuDisplayText.BackColor = Color.White;
            txt_MenuToolTip.BackColor = Color.White;
            txt_NavigationUrl.BackColor = Color.White;
            txt_DisplayOrder.BackColor = Color.White;
        }



        #endregion

        #region  Events For SubMenu

        protected void btn_UpdateSubMenu_Click(object sender, EventArgs e)
        {
            int ProcReturnValue = (int)MicroEnums.DataOperationResult.Failure;

            ProcReturnValue = UpdateSubMenuRecord();
            dialog_Message.Show();
            lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "SubMenu", MicroEnums.DataOperation.Edit);
            if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
            {
                BindGridSubMenu(int.Parse(PageVariables.SubWebMenuID));
                ResetSubMenuPage();
                ResetBackColor(view_InputControlChildMenu);
                ResetTextBoxes();
                multiView_MenuItems.SetActiveView(view_MenuItemEntry);
                ResetBackColor(view_MenuItemEntry);
                gview_SubMenu.Visible = false;

            }
        }

        protected void btn_ResetSubMenu_Click(object sender, EventArgs e)
        {

            ResetSubMenuPage();
            ResetTextBoxes();

        }

        protected void btn_AddNewMenu_Click(object sender, EventArgs e)
        {
            multiView_MenuItems.SetActiveView(view_MenuItemEntry);
            gview_SubMenu.Visible = false;
            ResetTextBoxes();
            ResetBackColor(view_MenuItemEntry);

        }

        protected void gview_SubMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals(MicroEnums.DataOperation.Page.GetStringValue()))
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                PageVariables.SubWebMenuID = ((Label)gview_SubMenu.Rows[RowIndex].FindControl("lbl_SubWebMenuID")).Text;
                PageVariables.SubParentWebMenuID = ((Label)gview_SubMenu.Rows[RowIndex].FindControl("lbl_SubParentID")).Text;
            }

            if (e.CommandName.Equals(MicroEnums.DataOperation.Edit.GetStringValue()))
            {

                multiView_MenuItems.SetActiveView(view_InputControlChildMenu);
                PopulateSubMenu(int.Parse(PageVariables.SubWebMenuID));
            }
            if (e.CommandName.Equals(MicroEnums.DataOperation.Delete.GetStringValue()))
            {
                int ProcReturnValue = DeleteRecord();
                dialog_Message.Show();
                lbl_TheMessage.Text = GetDataOperationResult(ProcReturnValue, "Sub Menu", MicroEnums.DataOperation.Delete);
                if (ProcReturnValue > (int)MicroEnums.DataOperationResult.Success)
                {
                    BindGridSubMenu(int.Parse(PageVariables.SubWebMenuID));
                }
            }
        }

        protected void gview_SubMenu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_SubMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void gview_SubMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    BasePage.GridViewOnDelete(e, 6);
                    BasePage.GridViewOnClientMouseOver(e);
                    BasePage.GridViewOnClientMouseOut(e);
                    BasePage.GridViewToolTips(e, 5, 6);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Methods For SubMenu

        private void BindSubMenu()
        {
            if (ddl_MenuHead.SelectedValue != MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT)
            {

                ddl_SubMenu.DataSource = WebMenuManagement.GetInstance.GetWebMenuAllByParentWebMenuID(int.Parse(ddl_MenuHead.SelectedValue));
                ddl_SubMenu.DataTextField = "MenuDisplayText";
                ddl_SubMenu.DataValueField = "WebMenuID";
                ddl_SubMenu.DataBind();
                ddl_SubMenu.Items.Insert(0, new ListItem(MicroConstants.DROPDOWNLIST_DEFAULT_ITEMTEXT));
            }

            else
            {
                ddl_SubMenu.DataSource = null;
                ddl_SubMenu.DataBind();
            }

        }

        private void BindGridSubMenu(int TheWebMenuID)
        {
            gview_SubMenu.Columns[0].Visible = false;

            gview_SubMenu.DataSource = null;
            gview_SubMenu.DataBind();
            List<WebMenu> SubMenuList = WebMenuManagement.GetInstance.GetWebMenuAllByParentWebMenuID(TheWebMenuID);
            if (SubMenuList.Count > 0)
            {
                gview_SubMenu.DataSource = SubMenuList;
                gview_SubMenu.DataBind();
            }
        }

        private void PopulateSubMenu(int theWebMenuId)
        {
            WebMenu TheWebMenu = WebMenuManagement.GetInstance.GetWebMenuByWebMenuID(theWebMenuId);
            ddl_SubMenuHead.SelectedIndex = GetSelecteIndex(ddl_SubMenuHead, TheWebMenu.WebMenuID);

            txt_SubMenuDisplayText.Text = TheWebMenu.MenuDisplayText;
            txt_SubMenuToolTip.Text = TheWebMenu.MenuToolTip;
            txt_SubMenuNavigationURL.Text = TheWebMenu.NavigationURL;

            txt_SubMenuDisplayOrder.Text = TheWebMenu.DisplayOrder.ToString();

            ChangeBackColor(view_InputControlChildMenu);

        }

        private void BindSubMenuItem()
        {
            ddl_SubMenuHead.DataSource = WebMenuManagement.GetInstance.GetWebMenuAllByParentWebMenuID(int.Parse(PageVariables.ParentWebMenuID));
            ddl_SubMenuHead.DataTextField = "MenuDisplayText";
            ddl_SubMenuHead.DataValueField = "WebMenuID";
            ddl_SubMenuHead.DataBind();

        }

        private int UpdateSubMenuRecord()
        {
            WebMenu theMenu = new WebMenu();
            theMenu.MenuDisplayText = txt_SubMenuDisplayText.Text;
            theMenu.MenuToolTip = txt_SubMenuToolTip.Text;
            theMenu.NavigationURL = txt_SubMenuNavigationURL.Text;
            if (!string.IsNullOrEmpty(txt_SubMenuDisplayOrder.Text))
            {
                theMenu.DisplayOrder = int.Parse(txt_SubMenuDisplayOrder.Text);
            }
            theMenu.WebMenuID = int.Parse(PageVariables.SubWebMenuID);
            theMenu.ParentWebMenuID = int.Parse(ddl_SubMenuHead.SelectedValue);
            int ProcReturnValue = WebMenuManagement.GetInstance.UpdateMenuItems(theMenu);
            return ProcReturnValue;
        }

        private void ResetSubMenuPage()
        {
            txt_SubMenuDisplayOrder.Text = string.Empty;
            txt_SubMenuDisplayText.Text = string.Empty;
            txt_SubMenuNavigationURL.Text = string.Empty;
            txt_SubMenuToolTip.Text = string.Empty;
            ddl_SubMenuHead.SelectedIndex = 0;
            ResetBackColor(view_InputControlChildMenu);

        }

        private int DeleteRecord()
        {
            WebMenu objWebMenu = new WebMenu();
            objWebMenu.WebMenuID = int.Parse(PageVariables.SubWebMenuID);
            int ProcReturnValue = WebMenuManagement.GetInstance.DeleteMenuItems(objWebMenu);
            return ProcReturnValue;

        }

        private int GetSelecteIndex(DropDownList ddl, int TheID)
        {
            int ReturnValue = 0;
            for (int ctr = 0; ctr < ddl.Items.Count; ctr++)
            {

                if (ddl.Items[ctr].Value == TheID.ToString())
                {
                    ReturnValue = ctr;
                    break;
                }
            }
            return ReturnValue;
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btn_PopulateMenuHavingSubMenu_Click(object sender, EventArgs e)
        {

        }

        protected void ddl_SubMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SubMenuID"] = ddl_SubMenuHead.SelectedValue;
        }

    }
}