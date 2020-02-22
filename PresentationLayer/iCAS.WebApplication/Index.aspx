<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/PKTrendz.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TCon.iCAS.WebApplication.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link href="<%#Micro.Commons.Helpers.GetApplicationPath(this.Page) + @"Content/slider.css"%>" rel="stylesheet" />
	<%----%>
	<asp:Literal runat="server" ID="lit_Keywords" Text="<meta name='keywords' content='Bangles, Handmade bangles, Ladies Fashion Items for sale, Online store for Handicraft Products of Odisha, Brash Fish of Bellaguntha, Brash Tiger, Brash Sri Jagannath, Brash Snake, ' />" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
