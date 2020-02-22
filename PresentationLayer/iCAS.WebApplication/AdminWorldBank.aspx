<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="AdminWorldBank.aspx.cs" Inherits="Micro.WebApplication.AdminWorldBank" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel_Establishment" runat="server" UpdateMode="Conditional">

        <ContentTemplate>
          
            <div class="innercontent">
                <h1 class="PageTitle">
                    <asp:Literal runat="server" ID="lit_PageTitle" Text="World Bank assisted OHEPEE Projects: Repository" />
                </h1>
                <asp:GridView ID="gridview_Establishment"
                    runat="server"
                    AllowPaging="True"
                    AllowSorting="True"
                    PageSize="200"
                    class="GridView"
                    AutoGenerateColumns="False"
                    RowStyle-CssClass="RowStyleCss"
                    OnRowCommand="gridview_Establishment_RowCommand">

                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />

                    <Columns>

                        <asp:TemplateField ItemStyle-CssClass="StudentId" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbl_EstbID" Text='<%# Eval("EstbID") %>' Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="EstbID" HeaderText="EstablishmentId" Visible="false" />
                        <asp:BoundField DataField="EstbViewStartDate" HeaderText="Date:" DataFormatString="{0:dd/MMM/yyyy}" HeaderStyle-Width="10%" />
                        <asp:BoundField DataField="EstbTitle" HeaderText="Title:" HeaderStyle-Width="40%" />
                        <asp:HyperLinkField
                            DataNavigateUrlFields="AddedBy"
                            DataNavigateUrlFormatString="~/MinutesOfMeeting.aspx?ID={0}"
                            DataTextField="AuthorOrContributorName"
                            HeaderText="Uploaded By"
                            HeaderStyle-Width="20%" />
                        <asp:CommandField SelectText="SHOW_RECORD" ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Images/pdf.gif" ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem"
                            HeaderStyle-Width="5%">
                            <ControlStyle CssClass="ViewLink" />
                            <ItemStyle CssClass="ViewLinkItem" />
                        </asp:CommandField>

                    </Columns>
                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    <PagerStyle CssClass="MicroPagerStyle" />
                </asp:GridView>
            </div>


            <IAControl:DialogBox ID="dialog_Message" runat="server"
                Title=":-"
                BackgroundCssClass="modalBackground"
                Style="display: none;"
                CssClass="modalPopup"
                EnableViewState="true">
                <ItemTemplate>
                    <ul>
                        <li>
                            <asp:Label ID="lbl_TheMessage" runat="server" Text="'" Visible="false" /></li>
                    </ul>
                    <ul id="DialogBoxUL">
                        <li class="FLabel">Type:</li>
                        <li class="FValue">
                            <asp:Label ID="LabelType" runat="server" Text=""></asp:Label>.</li>

                        <li class="FLabel">Title:</li>
                        <li class="FValue">
                            <asp:Label ID="LabelTitle" runat="server" Text=""></asp:Label></li>

                        <li class="FLabel">Date:</li>
                        <li class="FValue">
                            <asp:Label ID="LabelDate" runat="server" Text=""></asp:Label>.</li>


                        <li class="FLabel">Display Till</li>
                        <li class="FValue">
                            <asp:Label ID="LabelDisplayTill" runat="server" Text=""></asp:Label>.</li>


                        <li class="FLabel">Description</li>
                        <li class="FValue">
                            <asp:Label ID="LabelDesc" runat="server" Text=""></asp:Label>.</li>


                        <li class="FLabel">Uploaded File</li>
                        <li class="FValue">
                            <asp:HyperLink runat="server" ID="lnkPage" NavigateUrl="#">Click here to download</asp:HyperLink>

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

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_Establishment">
                <ProgressTemplate>
                    Please wait image is getting uploaded....
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
