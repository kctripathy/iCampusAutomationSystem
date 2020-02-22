<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TCon.iCAS.WebApplication.APPS.ICAS.STAFFS.Default" %>

<%@ Register src="../../../App_UserControls/Charts/UC_Chart_StudentStrengthYearWise.ascx" tagname="UC_Chart_StudentStrengthYearWise" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle col-lg-12 col-md-12 col-sm-12 col-xs-12">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="YOUR DASHBOARD:" />

	</h1>
    <div class="row col-md-12">
        &nbsp;<uc1:UC_Chart_StudentStrengthYearWise ID="UC_Chart_StudentStrengthYearWise1" runat="server" />
    </div>
</asp:Content>
