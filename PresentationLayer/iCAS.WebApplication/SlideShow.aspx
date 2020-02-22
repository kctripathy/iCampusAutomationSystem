<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/Micro-Website.Master" AutoEventWireup="true" CodeBehind="SlideShow.aspx.cs" Inherits="LTPL.ICAS.WebApplication.SlideShow" %>
<%@ Register src="App_UserControls/UC_SlideShowSimple.ascx" tagname="UC_SlideShow" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<uc1:UC_SlideShow ID="UC_SlideShow1" runat="server" />
.
</asp:Content>
