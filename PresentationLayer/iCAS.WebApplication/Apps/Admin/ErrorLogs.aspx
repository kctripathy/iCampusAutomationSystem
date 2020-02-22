<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="ErrorLogs.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.ErrorLogs" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
     
    <asp:UpdatePanel ID="updatePanel_ErrorLog" runat="server">
        <ContentTemplate>
        <h1 class="PageTitle">
        User Log
    </h1>
            <ul id="ErrorLog">
           
                <li>
                    <micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search ErrorLog(s), where:" />
                </li >
                <li class="FormPageCounter">
                    <asp:Literal runat="server" ID="lit_PageCounter" />
                </li>
                <li class="GridView">
                    <asp:GridView runat="server" ID="gview_Errors" AutoGenerateColumns="false" GridLines="Both" Width="98%"
                        AllowPaging="true" AllowSorting="true" PageSize="15" OnPageIndexChanging="gview_Errors_PageIndexChanging">
                        <PagerStyle HorizontalAlign="Center" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <Columns>
                            <asp:BoundField HeaderText="Error Date" DataField="ErrorDate" ItemStyle-Width="10%"  />
                            <asp:BoundField HeaderText="User Domain" DataField="UserDomain" ItemStyle-Width="8%"  />
                            <asp:BoundField HeaderText="Enviornment" DataField="Environment" ItemStyle-Width="8%"   />
                            <asp:BoundField HeaderText="Ticket" DataField="Ticket" ItemStyle-Width="12%"  />
                            <asp:BoundField HeaderText="The Page" DataField="ThePage" ItemStyle-Width="45%" />
                           <%-- <asp:BoundField HeaderText="The Message" DataField="TheMessage" />--%>
                      <%--       <asp:BoundField HeaderText="The Inner message" DataField="TheInnerMessage" />--%>
                           <%-- <asp:BoundField HeaderText="Error Stack" DataField="ErrorStack" />--%>
                            
                        </Columns>
                        <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                            Mode="NumericFirstLast" />
                        <PagerStyle CssClass="MicroPagerStyle" />
                    </asp:GridView>
                </li>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
