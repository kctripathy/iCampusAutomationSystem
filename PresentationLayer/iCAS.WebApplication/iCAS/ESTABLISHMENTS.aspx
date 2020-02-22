<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true"
    CodeBehind="ESTABLISHMENTS.aspx.cs" Inherits="LTPL.ICAS.WebApplication.iCAS.ESTABLISHMENTS" %>

<%@ Register Src="../App_UserControls/ICAS/UC_EstablishmentZone.ascx" TagName="UC_EstablishmentZone"
    TagPrefix="ltpl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <ltpl:UC_EstablishmentZone ID="ctrl_EstablishmentZone" runat="server" />--%>
    <h2 class="PageTitle">
        Select Establishment Type: 
		<asp:RadioButtonList runat="server" ID="radioList_Estb" AutoPostBack="true" RepeatDirection="Horizontal" Width="100%">
                <asp:ListItem Text="Notice" Value="N" />
                <asp:ListItem Text="Tender" Value="T" />
                <asp:ListItem Text="Circular" Value="C" />
                <asp:ListItem Text="All" Value="A" />
            </asp:RadioButtonList>
	</h2>
    <ul class="GridView">
        <li class="UCTitleEstb2">
            
        </li>
        <li>
            <asp:GridView runat="server" ID="gview_Estb" AutoGenerateColumns="false" AllowPaging="true"
                AllowSorting="true" PageSize="4" Width="98%" CssClass="GridView">
                <PagerStyle HorizontalAlign="Center" />
                <HeaderStyle CssClass="HeaderStyle" />
                <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                    Mode="NumericFirstLast" />
                <PagerStyle CssClass="MicroPagerStyle" />
                <Columns>
                    <asp:BoundField DataField="EstbDate" DataFormatString="{0:dd/MMM}:" ItemStyle-CssClass="ItemStyle_DT" />
                    <asp:BoundField DataField="EstbTitleZone" ItemStyle-CssClass="ItemStyle_Title" />
                    <asp:BoundField DataField="EstbTypeCode" ItemStyle-CssClass="ItemStyle_Icon" />
                    <asp:CommandField ShowEditButton="True" HeaderText="View" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_SELECT.ico"
                        ItemStyle-CssClass="ItemStyle_Icon" />
                </Columns>
                <HeaderStyle CssClass="gridViewEstbHeaderStyle" />
                <RowStyle CssClass="gridViewEstbRowStyle" />
            </asp:GridView>
        </li>
        <li class="FormSpacer" />
    </ul>
</asp:Content>
