<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_SelectOffice.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.UC_SelectOffice" %>

<ul id="OfficeDetails">
	<li id="FormLabel">
		<asp:Label runat="server" ID="lbl_OfficeType" Text="&nbsp;" />
	</li>
	<li id="FormValueOfficeType">
		<asp:DropDownList runat="server" ID="ddl_OfficeType" AutoPostBack="True" OnSelectedIndexChanged="ddl_OfficeType_SelectedIndexChanged" />
	</li>
	<li id="FormValueOfficeName">
		<asp:DropDownList runat="server" ID="ddl_OfficeName" AutoPostBack="True" onselectedindexchanged="ddl_OfficeName_SelectedIndexChanged" />
	</li>
</ul>
