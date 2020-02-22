<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_MultiColumnDropdownList.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.UC_MultiColumnDropdownList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:UpdatePanel runat="server" ID="updatePanel_SelectDCAcccountControl">
	<ContentTemplate>
		<asp:DropDownList runat="server" ID="ddl_MultiColumn" Font-Name="Courier New" Font-Size="Larger" Font-Bold="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_MultiColumn_OnSelectedIndexChanged" />
        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_MultiColumn" ControlToValidate="ddl_MultiColumn" Display="Dynamic" SetFocusOnError="true" />
	</ContentTemplate>
</asp:UpdatePanel>