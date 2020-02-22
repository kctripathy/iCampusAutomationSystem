<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="Approvals.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.ESTBLMT.AdminApprovals" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel_EmployeeDetails">
        <ContentTemplate>
            <ul id="EstablishmentApprovalsUL">
                <h1 class="PageTitle">
               

                <li class="FormLabel">
                    <asp:Label ID="lbl_MessageType" runat="server" Text="Upload Approvals:" />
                </li>
                <li class="FormValue">
                    <asp:RadioButtonList ID="rbl_EstablishmentTypeCode" runat="server" AutoPostBack="true"
                        RepeatDirection="Horizontal" Width="100%" OnSelectedIndexChanged="rbl_EstablishmentTypeCode_SelectedIndexChanged">
                        <asp:ListItem Text="Notice" Value="N" />
                        <asp:ListItem Text="Tender" Value="T" />
                        <asp:ListItem Text="Circular" Value="C" />
                        <asp:ListItem Text="All" Value="A" />
                    </asp:RadioButtonList>
                </li> </h1>
                <li class="GridView">
                    <asp:GridView ID="gview_EstablishmentApprovals" runat="server" AutoGenerateColumns="false"
                        CssClass="GridView">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_EstablishmentID" Visible="true" AutoPostBack="true" />
                                    <asp:Label runat="server" ID="lbl_EstablishmentID" Text='<%# Eval("EstbID") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EstbID" HeaderText="EstablishmentId" Visible="False" />
                            <asp:BoundField DataField="EstbTypeCodeDesc" HeaderText="Message Type" Visible="true" />
                            <asp:BoundField DataField="EstbTitle" HeaderText="Tittle" />
                            <asp:BoundField DataField="EstbViewStartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="EstbViewEndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}" />
                            <%--<asp:BoundField DataField="EstbDescription" HeaderText="Description" />--%>
                            <asp:BoundField DataField="EstbStatusFlagDesc" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </li>
                <li class="FormValueFullWidth">
                    <asp:Label runat="server" ID="lbl_Status" Text="Select the status to apply:"></asp:Label>
                    <asp:DropDownList ID="ddl_EstablishmentStatus" runat="server" 
                        onselectedindexchanged="ddl_EstablishmentStatus_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="P">Pending</asp:ListItem>
                        <asp:ListItem Value="A">Approved</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btn_Approve" runat="server" OnClick="btn_Approve_Click" 
                        Text="Approve" />
                </li>
                <li class="FormValue">
                </li>
                <li class="FormButton_Top">
                    <asp:Label ID="lbl_TheMessage" runat="server" Text="." />
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
