<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="SendSMS.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.SendSMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<ul>
<li>
<asp:TextBox runat="server" ID="txtToPhoneNo" Text="9437522845" />
</li>
<li>
<asp:TextBox runat="server" ID="txtSmsBodyText" TextMode="MultiLine" Rows="4" Text="this is my message" />
</li>
<li>
<asp:Button runat="server" ID="btnSend" Text="Send" OnClick="btnSendSMS_OnClick" />
</li>
<li>
<asp:Literal runat="server" ID="lit_Message" Text=".." />
</li>
</ul>

</asp:Content>
