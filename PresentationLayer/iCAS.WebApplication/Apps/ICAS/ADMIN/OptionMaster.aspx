<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="OptionMaster.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.ADMIN.OptionMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel ID="updatepanel_ManageFeedbacks" runat="server">
        <ContentTemplate>
			  <h1 class="PageTitle">
				  <asp:Literal runat="server" ID="lit_PageTitle" Text=" Options of the Question:-" />
			  </h1>
			  <h2>
					  <asp:RadioButton ID="Radio_Questionpage" runat="server" AutoPostBack="True" Text=" Go to Question Master" OnCheckedChanged="Radio_Questionpage_CheckedChanged" />
			  </h2>
			  <div>
                
                <asp:MultiView ID="multiview_ManageFeedbacks" runat="server">
                    <asp:View ID="view_EnterQuestions" runat="server">
                        <ul>
                            <li class="FormLabel">
                                <asp:Label ID="lbl_Question" runat="server" Text="Select  Feedback: " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_Question" runat="server" />
                            </li>
                           <li class="FormLabel">
                           <asp:Label ID="lbl_options" runat="server" Text="                 Option# 1 " /> 
                           </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Option1" runat="server" />
                                <asp:RequiredFieldValidator ID="Required_Option1" runat="server" ControlToValidate="txt_Option1" ErrorMessage="*" ForeColor="Red" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label ID="lbl_Option2" runat="server" Text="                 Option# 2" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Option2" runat="server" />
                                <asp:RequiredFieldValidator ID="Required_Option2" runat="server" ControlToValidate="txt_Option2" ErrorMessage="*" ForeColor="Red" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label ID="lbl_Option3" runat="server" Text="                 Option# 3" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Option3" runat="server" />
                                <asp:RequiredFieldValidator ID="Required_Option3" runat="server" ControlToValidate="txt_Option3" ErrorMessage="*" ForeColor="Red" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label ID="lbl_Option4" runat="server" Text="                 Option# 4" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Option4" runat="server" />
                                <asp:RequiredFieldValidator ID="Required_Option4" runat="server" ControlToValidate="txt_Option4" ErrorMessage="*" ForeColor="Red" />
                            </li>
                        </ul>
                        <ul id="Button">
                            <li class="FormButton_Top">
                        <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
                        <asp:Button ID="btn_Reset" runat="server" Text="Reset" CausesValidation="false" 
                            onclick="btn_Reset_Click" />
                        <asp:Button ID="btn_ViewAll" runat="server" OnClick="btn_ViewAll_Click" Text="ViewAll" CausesValidation="false" />
                        </li>
                        </ul>
                        <h1>
                        </h1>
                        <h1>
                        </h1>
                        </h1>
                    </asp:View>
                    <asp:View ID="View_Grid" runat="server">
                        <ul>
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_AddNew" runat="server" Text="Add New" OnClick="btn_AddNew_Click" CausesValidation="false" />
                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="Label1" />
                            </li>
                            <li class="GridView">
                                <asp:GridView ID="gridview_Option" runat="server" AllowPaging="true" AllowSorting="true"
                                     PageSize="10" AutoGenerateColumns="false" CssClass="GridView" 
                                    GridLines="Both" PagerSettings-Position="Bottom"
                                    Width="100%" OnRowCommand="gridview_Option_RowCommand" OnRowDataBound="gridview_Option_RowDataBound"
                                    OnRowDeleting="gridview_Option_RowDeleting" 
                                    OnRowEditing="gridview_Option_RowEditing" 
                                    onpageindexchanging="gridview_Option_PageIndexChanging">
                                    <HeaderStyle CssClass="HeaderStyle" />
											  <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
											  <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="OptionID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_OptionID" Text='<%# Eval("OptionID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OptionID" HeaderText="OptionID" Visible="false" />
                                        <asp:BoundField DataField="Option1" HeaderText="Option1" ItemStyle-CssClass="Option1" />
                                        <asp:BoundField DataField="Option2" HeaderText="Option2" ItemStyle-CssClass="Option2" />
                                        <asp:BoundField DataField="Option3" HeaderText="Option3" ItemStyle-CssClass="Option3" />
                                        <asp:BoundField DataField="Option4" HeaderText="Option4" ItemStyle-CssClass="Option4" />
                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico"
                                            ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
                                            <ControlStyle CssClass="EditLink" />
                                            <ItemStyle CssClass="EditLinkItem" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico"
                                            ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
                                            <ControlStyle CssClass="DeleteLink" />
                                            <ItemStyle CssClass="DeleteLinkItem" />
                                        </asp:CommandField>
                                    </Columns>
                                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                        Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="MicroPagerStyle" />
                                </asp:GridView>
                            </li>
                        </ul>
                    </asp:View>
                </asp:MultiView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground"
        Style="display: none" CssClass="modalPopup" EnableViewState="true">
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
