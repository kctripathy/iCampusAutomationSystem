<%@ Page Title="Dasboard - Administrator's" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Micro.WebApplication.MicroERP.Default" %>

<%@ Register Src="../App_UserControls/Charts/UC_Chart_StudentStrengthYearWise.ascx" TagName="UC_Chart_StudentStrengthYearWise" TagPrefix="uc2" %>

<asp:Content ID="ContentDefault" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<asp:UpdatePanel runat="server" ID="updatePanel_Default">
		<ContentTemplate>
			<h1 class="PageTitle col-lg-12 col-md-12 col-sm-12 col-xs-12">
				<asp:Literal runat="server" ID="lit_PageTitle" Text="Dashboard:" />
			</h1>
			<div class="row col-md-12">
				<uc2:UC_Chart_StudentStrengthYearWise ID="UC_Chart_StudentStrengthYearWise1" runat="server" />
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
