<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Search.ascx.cs" Inherits="UC_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<ul class="SearchBox">
	<li class="SearchLabel">
		<asp:Label runat="server" ID="lbl_SearchTitle" Text="Search XYZ(s), where:" />
	</li>
	<li class="SearchFields">
		<asp:DropDownList ID="ddl_SearchField" runat="server" Width="146px" AutoPostBack="false">
			<asp:ListItem Text="Customer Name" Value="CustomerName" />
			<asp:ListItem Text="Customer Code" Value="CustomerCode" />
			<asp:ListItem Text="Mobile Phone" Value="MobilePhone" />
		</asp:DropDownList>
	</li>
	<li class="SearchOperator">
		<asp:DropDownList ID="ddl_SearchOperator" runat="server" Width="75px">
			<asp:ListItem Text="Contains" Value="Contains" Selected="True" />
			<asp:ListItem Text="Starts With" Value="StartsWith" />
		</asp:DropDownList>
	</li>
	<li class="SearchText">
		<asp:TextBox runat="server" ID="txt_SearchText" Height="15px" />
		<ajax:TextBoxWatermarkExtender runat="server" ID="txtWaterMark_Search" TargetControlID="txt_SearchText" WatermarkText="Enter search text here" WatermarkCssClass="WatermarkClass" />
	</li>
	<li class="SearchButton">
		<asp:Button runat="server" ID="btn_SearchNow" Text="&nbsp;GO&nbsp;" OnClick="btn_SearchNow_Click" />
	</li>
	<li class="SearchMessage">
		<asp:Label runat="server" ID="lbl_SearchResult" Text="" CssClass="ValidateMessage" />
	</li>
</ul>
