<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="Passwords.aspx.cs" Inherits="TCon.iCAS.WebApplication.Passwords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox runat="server" ID="txt_Source" Text="." />
    <asp:DropDownList runat="server" ID="ddlOption">
        <asp:ListItem Text="Encrypt" Value="E" Selected="True" ></asp:ListItem>
        <asp:ListItem Text="Decrypt" Value="D" ></asp:ListItem>
    </asp:DropDownList>
    <asp:Button runat="server" ID="btnConvert" Text="Submit" OnClick="btnConvert_Click" />
    <asp:TextBox runat="server" ID="txt_Result" Text="-" />


</asp:Content>
