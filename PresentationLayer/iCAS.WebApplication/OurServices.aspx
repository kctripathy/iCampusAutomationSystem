<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="OurServices.aspx.cs" Inherits="Micro.WebApplication.OurServices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ul>
        <li class="formlabel">
        <asp:Label ID="lblstudent_code" runat="server" Text="Student Code" />
        </li>
        <li class="formvalue">
        <asp:TextBox ID="txtSTUDENT_CODE" runat="server" />
        </li>
        </ul>
</asp:Content>
