<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="DefaultFeeSetups.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.DefaultFeeSetups" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Default Fee Setup Details:-" />
    </h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_DefaultFeeSetup">
        <ContentTemplate>
            <div>
                <asp:MultiView ID="multiview_DefaultFeeSetup" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_Submit" runat="server" Text=" Save "
                                    CausesValidation="true" OnClick="btn_Submit_Click" />
                                <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false"
                                    OnClick="btn_View_Click" />
                                <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false"
                                    OnClick="btn_reset_Click" />
                            </li>
                        </ul>
                        <ul class="FeeSet">


                            <%--Qualification--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Qualification" Text="Qualification"></asp:Label>

                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_Qualification" runat="server">
                                </asp:DropDownList>
                            </li>
                            <%--Stream--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Stream" Text="Stream" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="DropDown_StreamList" runat="server" Enabled="true"
                                    Width="140px">
                                </asp:DropDownList>
                            </li>
                            <%-- AccountType--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_AccountType" Text=" Account Type :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_ParentAccountGroup" runat="server"
                                    AutoPostBack="True" Height="20px"
                                    OnSelectedIndexChanged="ddl_ParentAccountGroup_SelectedIndexChanged"
                                    Width="140px" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_AccountGroup" Text=" Account Group :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_AccountGroup" runat="server" AutoPostBack="True"
                                    Height="20px" OnSelectedIndexChanged="ddl_AccountGroup_SelectedIndexChanged"
                                    Width="140px" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_AccountName" Text=" Account Name :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_AccountHeads" runat="server" Width="140" />
                            </li>
                            <%-- <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_AccountingYear" Text=" Account Year :" />
                            </li>
                            <li class="FormValue">
                               <asp:DropDownList ID="ddl_AcademicYear"    runat="server" Width="140px" />
                            </li>--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_DefaultAmount" Text="Default Amount :" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_DefaultAmount" runat="server" Width="150px" />
                            </li>

                            <li class="FormButton_Top">
                                <asp:Button ID="btn_Submit1" runat="server" Text=" Save "
                                    CausesValidation="true" OnClick="btn_Submit_Click" />
                                <asp:Button ID="btn_View1" runat="server" Text="View" CausesValidation="false"
                                    OnClick="btn_View_Click" />
                                <asp:Button ID="btn_reset1" runat="server" Text="Reset" CausesValidation="false"
                                    OnClick="btn_reset_Click" />
                            </li>
                        </ul>
                    </asp:View>
                    <asp:View ID="view_Grid" runat="server">
                        <ul>
                            <li>
                                <asp:Button ID="btn_AddNew" runat="server" Text="Add New"
                                    OnClick="btn_AddNew_Click" />
                            </li>
                            <li class="Gview_Qualifications">
                                <asp:GridView ID="gridview_DefaultFee" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%"
                                    OnRowCommand="Qualification_RowCommand" OnRowDeleting="Qualification_RowDeleting"
                                    OnRowEditing="Qualification_RowEditing"
                                    OnRowDataBound="Qualification_RowDataBound">
                                    <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sno
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Slno" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="QualsID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_QualificationID" Text='<%# Eval("Slno") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="QUALIFICATION" HeaderText="Qualification" Visible="true" />
                                        <asp:BoundField DataField="STREAM" HeaderText="Stream" Visible="true" />
                                        <asp:BoundField DataField="ACCOUNT_NAME" HeaderText="Account Name" />
                                        <asp:BoundField DataField="DefaultFee" HeaderText="Fee" />
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
                                        <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico"
                                            ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                            <ControlStyle CssClass="ViewLink" />
                                            <ItemStyle CssClass="ViewLinkItem" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
