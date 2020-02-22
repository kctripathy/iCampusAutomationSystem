<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="TCon.iCAS.WebApplication.Library.Books" %>

<%@ Register Src="../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    
    <asp:UpdatePanel runat="server" ID="UpdatePanel_Books">
        <ContentTemplate>
            <div class="innercontent">
                <h1 class="PageTitle">College Library Books (<asp:Literal runat="server" ID="lit_BookCount" Text="0" />)</h1>
                <ul id="BooksGridUL">
                    <li class="SearchRowLI">
                        <uc1:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Book(s):- " SearchResultCount="" SearchWhat="Books" />
                    </li>
                    <li>
                        <asp:GridView
                            runat="server"
                            ID="gview_Books"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            AllowSorting="true"
                            PageSize="40"
                            Width="100%"
                            CssClass="GridView"
                            GridLines="Horizontal"
                            CellPadding="2"
                            OnPageIndexChanging="gview_Books_PageIndexChanging">
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="MicroPagerStyle" />
                            <RowStyle CssClass="GridRowStyle" />
                            <AlternatingRowStyle CssClass="GridAlternatRowStyle" />
                            <Columns>
                                 <asp:BoundField DataField="AccessionNo" HeaderText="Acc. No:" ItemStyle-Width="5%" />
                                <asp:BoundField DataField="CategoryName" HeaderText="Category:" ItemStyle-Width="15%" />
                                <asp:BoundField DataField="Title" HeaderText="Book Title:" ItemStyle-Width="34%" ItemStyle-CssClass="TitleClass" />
                                <asp:BoundField DataField="AuthorName" HeaderText="Author:" ItemStyle-Width="25%" />
                                <asp:BoundField DataField="PublisherName" HeaderText="Publisher:" ItemStyle-Width="17%" />
                                <%--<asp:BoundField DataField="Pages" HeaderText="Pages" ItemStyle-Width="5%" />--%>
                                <%--<asp:BoundField DataField="Edition" HeaderText="Edition" ItemStyle-Width="5%" />--%>
                                <%--<asp:BoundField DataField="AccessionNo" HeaderText="ACCN" ItemStyle-Width="5%" />--%>
                                <asp:BoundField DataField="IsBookIssued" HeaderText="Issued?" ItemStyle-Width="4%" />
                                <%--<asp:BoundField DataField="IssuedToUserName" HeaderText="Issued2User" ItemStyle-Width="4%" />--%>
                                <asp:BoundField DataField="BookID" HeaderText="ID" Visible="false" />
                            </Columns>
                            <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        </asp:GridView>
                    </li>
                </ul>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <div id="UpdateProgress">
                <div class="UpdateProgressArea">
                    Please wait a while...
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
