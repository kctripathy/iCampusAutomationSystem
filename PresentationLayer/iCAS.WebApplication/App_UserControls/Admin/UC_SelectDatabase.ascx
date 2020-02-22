<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_SelectDatabase.ascx.cs" Inherits="UC_SelectDatabase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<ul id="SelectDatabase">
	<li class="FormMessage">
		<asp:Label runat="server" ID="lbl_Message" Text="." />
	</li>
	<li class="FormLabel">
	<asp:Label runat="server" ID="Label1" Text="Database" />
	</li>
	<li class="FormValue">
		<ajax:ComboBox runat="server" ID="ajaxComboBox_Database" AutoPostBack="true" OnSelectedIndexChanged="ajaxComboBox_Database_SelectedIndexChanged" CssClass="SelectDatabaseControl" Width="150px" Height="17px" DropDownStyle="DropDownList" />
	</li>
	<li class="FormLabel">
	<asp:Label runat="server" ID="Label2" Text="Company" />
	</li>
	<li class="FormValue">
		<ajax:ComboBox runat="server" ID="ajaxComboBox_Company" OnSelectedIndexChanged="ajaxComboBox_Database_SelectedIndexChanged" CssClass="SelectDatabaseControl" Width="150px" DropDownStyle="DropDownList" Height="17px" />
	</li>

</ul>
 