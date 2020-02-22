<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="Micro.WebApplication.App_Error.Maintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">Website Work In Progress....</h1>
	<div class="innercontent">
		
        <h1 class="BigErrorText">Website Under Maintenance</h1>
        
        <p class="ErrorMessage">
            Dear User,<br /><br />
			
			Due to application maintenance we have temporarily suspended the service. <br />
            Please note that, this service will not be unavailable from <br />
			<asp:Label ID="LabelEnglishDateTime" runat="server" CssClass="BigErrorText" />. 
			
			<br /><br /><br /><br />
			We are So Sorry for any inconvenience.<br />
			<br />
			<br />
			<br />
		</p>
	</div>
</asp:Content>
