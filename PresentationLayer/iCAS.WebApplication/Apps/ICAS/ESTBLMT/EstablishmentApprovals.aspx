<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="EstablishmentApprovals.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.ESTBLMT.EstablishmentApprovals" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel_EmployeeDetails">
        <ContentTemplate>
            <ul id="EstablishmentApprovalsUL">
                <h1 class="PageTitle">Approve Uploads and Establisments:</h1>
                <li class="FormLabel">
                    <asp:Label ID="lbl_MessageType" runat="server" Text="Please Select the Type:" />
                </li>
                <li class="FormValue">
                    <asp:RadioButtonList ID="rbl_EstablishmentTypeCode" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Width="100%" CssClass="EstbTypeRadioButtons" OnSelectedIndexChanged="rbl_EstablishmentTypeCode_SelectedIndexChanged">
                        <asp:ListItem Text="All" Value="A" />
                        <asp:ListItem Text="Notice" Value="N" />
                        <asp:ListItem Text="Tender" Value="T" />
                        <asp:ListItem Text="Circular" Value="C" />
                        <asp:ListItem Text="Publications" Value="P" />
                        
                    </asp:RadioButtonList>
                </li>
                <li>
                    <asp:Label runat="server" ID="lbl_Status" Text="Select the status to apply:"></asp:Label>
                    <asp:DropDownList ID="ddl_EstablishmentStatus" runat="server" OnSelectedIndexChanged="ddl_EstablishmentStatus_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="A">Approved</asp:ListItem>
                        <asp:ListItem Value="P">Pending</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btn_Approve" runat="server" OnClick="btn_Approve_Click" Text="Approve" CssClass="btn btn-primary" />
                </li>
                <li>
                    <asp:Label ID="lbl_TheMessage" runat="server" Text="-.-.-" />
                </li>
                <li>
                    <asp:GridView ID="gview_EstablishmentApprovals" runat="server" AutoGenerateColumns="false"
                        CssClass="GridView">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                <ControlStyle CssClass="ViewLink" />
                                <ItemStyle CssClass="ViewLinkItem" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_EstablishmentID" Visible="true" AutoPostBack="true" />
                                    <asp:Label runat="server" ID="lbl_EstablishmentID" Text='<%# Eval("EstbID") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EstbID" HeaderText="EstablishmentId" Visible="False" ItemStyle-CssClass="ID" />
                            <asp:BoundField DataField="EstbTypeCodeDesc" HeaderText="Type" Visible="true" ItemStyle-CssClass="Type" />
                            <asp:BoundField DataField="EstbTitle" HeaderText="Tittle" ItemStyle-CssClass="Tittle" />
                            <%--<asp:BoundField DataField="EstbDescription" HeaderText="Description" ItemStyle-CssClass="Description" />--%>
                            <%--<asp:BoundField DataField="EstbViewStartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="Date" />--%>
                            <%--<asp:BoundField DataField="EstbViewEndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="Date" />--%>
                            <asp:BoundField DataField="AuthorOrContributorName" HeaderText="Author/Contributor Name" ItemStyle-CssClass="AuthorContributor" />
                            <asp:BoundField DataField="EstbStatusFlagDesc" HeaderText="Status" ItemStyle-CssClass="Status" />
                        </Columns>
                    </asp:GridView>
                </li>

            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
    <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground"
        Style="display: none" CssClass="modalPopup" EnableViewState="true">
        <ItemTemplate>
            <ul>
                <li>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </li>
            </ul>
        </ItemTemplate>
    </IAControl:DialogBox>
</asp:Content>
