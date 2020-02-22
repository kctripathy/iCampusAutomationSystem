<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Designations.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.Designations" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%--<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Designation Details" />
    </h1>

    <ajax:TabContainer runat="server" ID="tab_Designations" ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="tab_Designations_ActiveTabChanged">
        <ajax:TabPanel ID="tab_DesignationAll" runat="server" HeaderText="ALL Designation">

            <ContentTemplate>
                <asp:MultiView runat="server" ID="multiView_DesignationDetails">
                    <asp:View ID="view_InputControls" runat="server">
                        <div id="Mode">
                            <asp:Label runat="server" ID="lbl_DataOperationMode" />
                        </div>
                        <ul id="DesignationDetails">
                            <li class="FormButton_Top">
                                <div id="Top">
                                    <asp:Button runat="server" ID="btn_ViewDesignationDetails" CausesValidation="False" Text=" View " OnClick="btn_ViewDesignationDetails_Click" />
                                    <asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="btn_Top_Save_Click" />
                                    <asp:Button ID="btn_Reset" runat="server" CausesValidation="False" Text="Reset" OnClick="btn_Reset_Click" />

                                </div>
                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_Head_DesigantionDetails" Text="Designation Details :-" />
                            </li>

                            <!--Teaching?-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label4" Text="Please Choose Staff Category:" />
                            </li>
                            <li class="FormValue">
                                <asp:RadioButtonList runat="server" ID="optCategory" RepeatDirection="Horizontal" CellSpacing="2" CellPadding="2">
                                    <asp:ListItem Text="Teaching" Value="T" Selected="True" />
                                    <asp:ListItem Text="Non-Teaching" Value="N" />
                                </asp:RadioButtonList>
                            </li>
                            <!--Department Name"-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_DesignationsName" Text="Designation's Description :" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Designation" runat="server" Height="17px" />
                                <asp:RequiredFieldValidator ID="requiredFieldValidator_Designation" runat="server" ControlToValidate="txt_Designation" SetFocusOnError="True" Display="Dynamic" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Designation" runat="server" ControlToValidate="txt_Designation" SetFocusOnError="True" Display="Dynamic" ValidationExpression="[a-zA-Z\s]+" />
                            </li>
                            <!--Role Description-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_RoleDescription" Text="Role Description :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="ddl_RoleDescription" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_RoleDescription" runat="server" ControlToValidate="ddl_RoleDescription" SetFocusOnError="True" Display="Dynamic" />
                            </li>

                            <!--Reportin To-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ReportingTo" Text="Reporting To :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="ddl_ReportingTo" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddl_ReportingTo" runat="server" ControlToValidate="ddl_ReportingTo" SetFocusOnError="True" Display="Dynamic" />
                            </li>
                            <li class="FormLabel"></li>
                            <!--Action Button-->
                            <li class="FormButton_Top">
                                <div id="Buttom">
                                    <asp:Button runat="server" ID="btn_View" CausesValidation="False" Text=" View " OnClick="btn_ViewDesignationDetails_Click" />
                                    <asp:Button runat="server" ID="Btn_Save" Text="Save" OnClick="btn_Top_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" CausesValidation="False" Text="Reset" OnClick="btn_Reset_Click" /><!-- OnClick="btn_Cancel_Click"-->
                                </div>
                            </li>
                            <li class="FormMessage">
                                <asp:Literal runat="server" ID="lit_Message" Text="." />
                            </li>
                            <li class="FormSpacer" />
                        </ul>
                    </asp:View>

                    <asp:View ID="view_GridView" runat="server">
                        <ul class="GridView">
                            <li class="FormButton_Top">
                                <asp:Button runat="server" ID="btn_AddDesignation" Text="Add New Designation" CausesValidation="False" OnClick="btn_AddDesignation_Click" />
                            </li>
                            <li></li>
                            <li class="FormPageCounter">
                                <asp:Literal runat="server" ID="lit_PageCounter" />
                            </li>
                            <li>
                                <asp:GridView runat="server" ID="gview_Designation" AutoGenerateColumns="False" AllowPaging="True" PageSize="25" Width="98%" CssClass="GridView" CellPadding="2" OnPageIndexChanging="gview_Designation_PageIndexChanging" OnRowCommand="gview_Designation_RowCommand" OnRowDeleting="gview_Designation_RowDeleting" OnRowEditing="gview_Designation_RowEditing" OnRowDataBound="gview_Designation_RowDataBound">
                                    <PagerStyle HorizontalAlign="Center" CssClass="MicroPagerStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:BoundField ShowHeader="False" DataField="DepartmentID" Visible="False" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk_DepartmentID" Visible="true" />
                                                <asp:Label runat="server" ID="lbl_DesignationID" Text='<%# Eval("DesignationID") %>' Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="CheckBox" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="DesignationDescription" HeaderText="Name ">
                                            <ItemStyle CssClass="DDescription" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RoleDescription" HeaderText="RoleDescription">
                                            <ItemStyle CssClass="RDescription" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico">
                                            <ControlStyle CssClass="EditLink" />
                                            <ItemStyle CssClass="EditLinkItem" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico">
                                            <ControlStyle CssClass="DeleteLink" />
                                            <ItemStyle CssClass="DeleteLinkItem" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico">
                                            <ControlStyle CssClass="ViewLink" />
                                            <ItemStyle CssClass="ViewLinkItem" />
                                        </asp:CommandField>
                                    </Columns>
                                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                </asp:GridView>
                            </li>
                            <li class="FormMessage">
                                <asp:Literal ID="lit_GridMessage" runat="server" />
                            </li>
                            <li class="FormSpacer" />
                        </ul>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>

        </ajax:TabPanel>
        <ajax:TabPanel ID="tab_DesignationSelect" runat="server" HeaderText="Select Designation">
            <ContentTemplate>
                <asp:MultiView runat="server" ID="Multiview_Desig">
                    <asp:View ID="view_GridViewDesig" runat="server">
                        <ul class="GridView">

                            <asp:GridView runat="server" ID="gview_DesignationSelect" AutoGenerateColumns="False" PageSize="25" Width="98%" CssClass="GridView" CellPadding="2" OnRowDataBound="gview_DesignationSelect_RowDataBound">
                                <PagerStyle HorizontalAlign="Center" CssClass="MicroPagerStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_DesignationId" Text='<%# Eval("DesignationID") %>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation of Office">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_DesignationOfficeId" Visible="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DesignationID" HeaderText="Designation" />
                                    <asp:BoundField DataField="DesignationDescription" HeaderText="Name ">
                                        <ItemStyle CssClass="DDescription" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Check All">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="lit_Add" Text="Add" /><br />
                                            <asp:CheckBox ID="chkSelectAll_Add" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_Add_CheckedChanged" ToolTip="Select All ADD Permissions" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_Add" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                            </asp:GridView>

                            <li class="FormButton_Top">
                                <asp:Button runat="server" ID="btn_Apply" Text=" ApplyChanges" OnClick="btn_Apply_Click" />
                            </li>

                        </ul>
                    </asp:View>

                </asp:MultiView>
            </ContentTemplate>
        </ajax:TabPanel>
    </ajax:TabContainer>
    <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
        <ItemTemplate>
            <ul>
                <li>
                    <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
                </li>
            </ul>
        </ItemTemplate>
    </IAControl:DialogBox>

    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <div id="UpdateProgress">
                <div class="UpdateProgressArea">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>



</asp:Content>
