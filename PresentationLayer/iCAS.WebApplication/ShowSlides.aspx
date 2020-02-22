<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="ShowSlides.aspx.cs" Inherits="TCon.iCAS.WebApplication.ShowSlides" %>
<%@ Register src="App_UserControls/UC_SlideShowSimple.ascx" tagname="UC_SlideShowSimple" tagprefix="uc1" %>
<%@ Register src="App_UserControls/UC_WebUserControlSlider.ascx" tagname="UC_WebUserControlSlider" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<uc1:UC_SlideShowSimple ID="UC_SlideShowSimple1" runat="server" />

	<hr />
	<uc2:UC_WebUserControlSlider ID="UC_WebUserControlSlider1" runat="server" />
</asp:Content>
