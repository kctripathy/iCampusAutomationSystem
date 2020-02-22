<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="MenuItems.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.MenuItems" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
        .FullRowLI
        {
            display:block;
            float:left;
            background: skyblue;
        }
    </style>
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Website Menu:-" />
    </h1>
    <asp:UpdatePanel runat="server" ID="updatePanel_CMenuItems">
        <ContentTemplate>
            <ul>
                <li class="FormLabel">
                    <asp:Label runat="server" ID="lbl_Menu" Text="Please select Menu head" />
                    <asp:Label runat="server" ID="lbl_MenuValidator" Text="*" ForeColor="Red" />
                </li>
                <li class="FormValue">
                    <asp:DropDownList runat="server" ID="ddl_MenuHead" AutoPostBack="true" OnSelectedIndexChanged="ddl_MenuHead_SelectedIndexChanged" />
                    <asp:Label runat="server" ID="lbl_ErrorMessage" />
                    <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_MenuHeads" ControlToValidate="ddl_MenuHead" Display="Dynamic" SetFocusOnError="true" />
                </li>
                <li class="FormLabel">
                    <asp:Label ID="lbl_SubMenu" runat="server" Text="Sub Menu" />
                </li>
                <li class="FormValue">
                    <asp:DropDownList runat="server" ID="ddl_SubMenu" AutoPostBack="true" OnSelectedIndexChanged="ddl_SubMenu_SelectedIndexChanged" />
                </li>
                <li class="FormButton">
                    <asp:Button runat="server" ID="btn_View" Text=" View Menuitems" CausesValidation="false" OnClick="btn_View_Click"  />
                    <asp:Button runat="server" ID="btn_PopulateMenuHavingSubMenu" CausesValidation="false" Visible="false" Text=" Populate Submenus " OnClick="btn_PopulateMenuHavingSubMenu_Click" />
                    
                    
                </li>
            </ul>
            <asp:MultiView runat="server" ID="multiView_MenuItems" ActiveViewIndex="0">
                <asp:View runat="server" ID="view_MenuItemEntry">
                    <ul>
                        <li class="FormButton_Top">
                            <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click" />
                            <asp:Button runat="server" ID="btn_Reset" Text="Reset" CausesValidation="false" OnClick="btn_Reset_Click" />
                        </li>
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="lbl_NewMenuEntry" Text="New Menu Items Entry" />
                        </li>

                        <!--Menu DisplayText-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_MenuDisplayText" Text="MenuDisplayText" />
                            <asp:Label runat="server" ID="lbl_MenuDisplayTextValidator" Text="*" ForeColor="Red" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txt_MenuDisplayText" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_MenuDisplayText" ControlToValidate="txt_MenuDisplayText" Display="Dynamic" SetFocusOnError="true" />
                            <%--<asp:RegularExpressionValidator runat="server" ID="regularExpresseionValidator_MenuDisplayText" ControlToValidate="txt_MenuDisplayText" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[a-zA-Z\s\.]+" />--%>
                            <!--Menu ToolTip-->
                        </li>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_MenuToolTip" Text="Menu Tool Tip" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txt_MenuToolTip" />
                        </li>
                        <!--Menu NavigationURL-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_NavigationUrl" Text="Navigation Url" />
                            <asp:Label runat="server" ID="lbl_NavigationUrlValidator" Text="*" ForeColor="Red" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txt_NavigationUrl" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_NavigationUrl" ControlToValidate="txt_NavigationUrl" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <!--Menu DisplayOrder-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_DisplayOrder" Text="Display Order" />
                            <%--<asp:Label runat="server" ID="lbl_DisplayOrderValidator" Text="*" ForeColor="Red" />--%>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_DisplayOrder" />
                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DisplayOrder" ControlToValidate="txt_DisplayOrder" Display="Dynamic" SetFocusOnError="true" />--%>
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DisplayOrder" ControlToValidate="txt_DisplayOrder" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[0-9\s]+" />
                        </li>
                        <li class="FormSpacer" />
                        <!--Operational Button-->
                        <li class="FormButton_Top">
                            <asp:Button runat="server" ID="btn_Bottom_Save" Text="Save" OnClick="btn_Save_Click" />
                            <asp:Button runat="server" ID="btn_Bottom_View" Text="View" OnClick="btn_View_Click" CausesValidation="false" />
                            <asp:Button runat="server" ID="btn_Bottom_Reset" Text="Reset" CausesValidation="false" OnClick="btn_Reset_Click" />
                        </li>
                        <li class="FormValue">
                            <asp:Label runat="server" ID="lbl_Message" Text="" />
                        </li>
                        <li class="FormSpacer" />
                        <li class="FormSpacer" />
                        <!--GridviewSubMenu-->
                        <hr />
                        <li>
                            <asp:GridView ID="gview_SubMenu" runat="server" AutoGenerateColumns="false" CssClass="GridView" PagerSettings-Position="Bottom" Width="98%" OnRowCommand="gview_SubMenu_RowCommand" OnRowEditing="gview_SubMenu_RowEditing" OnRowDataBound="gview_SubMenu_RowDataBound" OnRowDeleting="gview_SubMenu_RowDeleting">
                                <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_SubWebMenuID" Text='<%# Eval("WebMenuID") %>' />
                                            <asp:Label runat="server" ID="lbl_SubParentID" Text='<%# Eval("ParentWebMenuID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MenuDisplayText" HeaderText="Menu Name" ItemStyle-CssClass="MDText" />
                                    <asp:BoundField DataField="MenuToolTip" HeaderText="Menu Tool Tip Text" ItemStyle-CssClass="MTTip" />
                                    <asp:BoundField DataField="NavigationURL" HeaderText="Menu Navigation URL" ItemStyle-CssClass="NURL" />
                                    <asp:BoundField DataField="DisplayOrder" HeaderText="Order" ItemStyle-CssClass="DOrder" />
                                    <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
                                </Columns>
                            </asp:GridView>
                        </li>
                        <li class="FormSpacer" />
                    </ul>
                </asp:View>
                <asp:View runat="server" ID="view_GridView">
                    <ul class="GridView">
                        <!-- Add new -->
                        <li class="FormButton_Top">
                            <asp:Button runat="server" ID="btn_New" CausesValidation="false" Text=" New Menu Item " OnClick="btn_New_Click" />

                        </li>
                        <li class="FormSpacer" />
                        <li class="FormPageCounter">
                            <asp:Literal runat="server" ID="lit_PageCounter" />
                        </li>
                        <li>
                            <asp:GridView ID="gview_Menu" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" AllowSorting="true" CssClass="GridView" PagerSettings-Position="Bottom" Width="98%" OnRowCommand="gview_Menu_RowCommand" OnRowDataBound="gview_Menu_RowDataBound" OnRowDeleting="gview_Menu_RowDeleting" OnRowEditing="gview_Menu_RowEditing" OnPageIndexChanging="gview_Menu_PageIndexChanging">
                                <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:BoundField DataField="WebMenuID" ShowHeader="false" Visible="false" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_WebMenuID" Text='<%# Eval("WebMenuID") %>' />
                                            <asp:Label runat="server" ID="lbl_ParentID" Text='<%# Eval("ParentWebMenuID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateColumn HeaderText="Menu Name" >
                                <ItemTemplate>
                                <asp:TextBox runat="server"   ID="txt_MenuName" Text='<%# Bind("MenuDisplayText") %>' />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_GridMenuName" ControlToValidate="txt_MenuName" Display="None" SetFocusOnError="true" ErrorMessage="Menu Number Can't be left blank." />
                             
                               </ItemTemplate>
                                </asp:TemplateColumn>

                                 <asp:TemplateColumn HeaderText="Menu Tool Tip" >
                                <ItemTemplate>
                                <asp:TextBox runat="server" ID="txt_MenuToolTip" Text='<%# Bind("MenuToolTip") %>' />
                               </ItemTemplate>
                                </asp:TemplateColumn>
                               
                                 <asp:TemplateColumn HeaderText="Menu Navigation URL" >
                                <ItemTemplate>
                                <asp:TextBox runat="server" ID="txt_NavigationURL" Text='<%# Bind("NavigationURL") %>' />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_GridNavigationUrl" ControlToValidate="txt_NavigationURL" Display="None" SetFocusOnError="true" ErrorMessage="Navigation Url Text Can't be left blank."/>
                               </ItemTemplate>
                                </asp:TemplateColumn>

                                 <asp:TemplateColumn HeaderText="Display Order" >
                                <ItemTemplate>
                                <asp:TextBox runat="server" ID="txt_DisplayOrder" Text='<%# Bind("DisplayOrder") %>'/>
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_GridDisplayOrder" ControlToValidate="txt_DisplayOrder" Display="None" SetFocusOnError="true" ValidationExpression="[0-9\s]+" ErrorMessage="Disply Order Must be Number." />
                               <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_GridDisplayOrder" ControlToValidate="txt_DisplayOrder" Display="None" SetFocusOnError="true" ErrorMessage="Display order Can't be left blank." />
                               </ItemTemplate>
                                </asp:TemplateColumn>--%>
                                    <asp:BoundField DataField="MenuDisplayText" HeaderText="Menu Name" ItemStyle-CssClass="MDText" />
                                    <asp:BoundField DataField="MenuToolTip" HeaderText="Menu Tool Tip Text" ItemStyle-CssClass="MTTip" />
                                    <asp:BoundField DataField="NavigationURL" HeaderText="Menu Navigation URL" ItemStyle-CssClass="NURL" />
                                    <asp:BoundField DataField="DisplayOrder" HeaderText="Order" ItemStyle-CssClass="DOrder" />
                                    <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ControlStyle-Height="16" ControlStyle-Width="16" />
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ControlStyle-Height="16" ControlStyle-Width="16" />
                                    <%--<pagersettings position="TopAndBottom" firstpagetext="First" lastpagetext="Last" mode="NumericFirstLast" />
									<pagerstyle cssclass="MicroPagerStyle" />--%>
                                </Columns>
                            </asp:GridView>
                        </li>
                        <%--<li class="FormSpacer" />
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_NewBottom" CausesValidation="false" Text=" New Menu Item " OnClick="btn_New_Click" />
							<asp:Button runat="server" ID="btn_RefreshBottom" CausesValidation="false" Text="Refresh Grid" OnClick="btn_Refresh_Click" />
						</li>--%>
                        <li class="FormSpacer"></li>
                    </ul>
                    <%--<asp:ValidationSummary runat="server" ID="ValidationSummary_Grid" ShowMessageBox="true" DisplayMode="BulletList" HeaderText="ALERT"  ShowSummary="false" CssClass="ValidateMessage" Font-Bold="true" /> --%>
                </asp:View>
                <asp:View ID="view_InputControlChildMenu" runat="server">
                    <ul>
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_UpdateSubMenu" runat="server" Text="Update" OnClick="btn_UpdateSubMenu_Click" />
                            <asp:Button ID="btn_AddNewMenu" runat="server" Text="Add New Menu" CausesValidation="false" OnClick="btn_AddNewMenu_Click" />
                            <asp:Button ID="btn_ResetSubMenu" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_ResetSubMenu_Click" />
                        </li>
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="lbl_Child" Text="Sub Menu Edit" />
                        </li>
                        <!--SubMenu Head-->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_SubMenuHead" runat="server" Text="Sub Menu" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_SubMenuHead" AutoPostBack="true" />
                        </li>
                        <!--SubMenu DisplayText-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_SubMenuDisplayText" Text="Sub Menu DisplayText" />
                            <asp:Label runat="server" ID="Label4" Text="*" ForeColor="Red" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txt_SubMenuDisplayText" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_SubMenuDisplayText" ControlToValidate="txt_SubMenuDisplayText" Display="Dynamic" SetFocusOnError="true" />
                            <%--<asp:RegularExpressionValidator runat="server" ID="regularExpresseionValidator_MenuDisplayText" ControlToValidate="txt_MenuDisplayText" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[a-zA-Z\s\.]+" />--%>
                        </li>
                        <!--SubMenu ToolTip-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_SubMenuToolTip" Text="Sub Menu Tool Tip" />
                            <%--<asp:Label runat="server" ID="Label6" Text="*" ForeColor="Red" />--%>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txt_SubMenuToolTip" />
                        </li>
                        '
						<!--SubMenu Navigation URL-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_SubMenuNavigationURL" Text="Navigation Url" />
                            <%--<asp:Label runat="server" ID="lbl_7" Text="*" ForeColor="Red" />--%>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txt_SubMenuNavigationURL" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_SubMenuNavigationURL" ControlToValidate="txt_SubMenuNavigationURL" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <!--SubMenu DisplayOrder-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_SubMenuDisplayOrder" Text="Display Order" />
                            <%--<asp:Label runat="server" ID="lbl_DisplayOrderValidator" Text="*" ForeColor="Red" />--%>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_SubMenuDisplayOrder" />
                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DisplayOrder" ControlToValidate="txt_DisplayOrder" Display="Dynamic" SetFocusOnError="true" />--%>
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_SubMenuDisplayOrder" ControlToValidate="txt_SubMenuDisplayOrder" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[0-9\s]+" />
                        </li>
                        <li class="FormSpacer" />
                    </ul>
                </asp:View>
            </asp:MultiView>
            <IAControl:DialogBox ID="dialog_Message" runat="server" CssClass="modalPopup" BackgroundCssClass="modalBackground" EnableViewState="true" Style="display: none;" Title="">
                <ItemTemplate>
                    <ul>
                        <li>
                            <asp:Label ID="lbl_TheMessage" runat="server" Text="" />
                        </li>
                    </ul>
                </ItemTemplate>
            </IAControl:DialogBox>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <div id="UpdateProgress">
                <div class="UpdateProgressArea">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
