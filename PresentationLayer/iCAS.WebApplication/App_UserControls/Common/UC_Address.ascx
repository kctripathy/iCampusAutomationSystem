<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Address.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.Common.UC_Address" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<ul id="AddressDetails">
	<li class="formLabel">
		<asp:Label runat="server" ID="lbl_AT" Text="AT" />
	</li>
	<li class="FormValue">
		<asp:TextBox ID="txt_At" runat="server" Height="40px" Width="215px" TextMode="MultiLine" />
	</li>
	<li class="formLabel">
	<asp:Label runat="server" ID="lbl_Country" Text="Country" />
	</li>
	<li class="FormValue" >
	<asp:DropDownList runat="server" ID="ddl_Country" AutoPostBack="true" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged"/>
	</li>
	<li class="formLabel">
	<asp:Label runat="server" ID="lbl_State" Text="State" />
	</li>
	<li class="FormValue">
	<asp:DropDownList ID="ddl_State" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddl_State_SelectedIndexChanged"/>
	</li>
	<li class="formLabel">
	<asp:Label runat="server" ID="lbl_District" Text="District" />
	</li>
	<li class="FormValue">
	<asp:TextBox runat="server" ID="txt_District" ontextchanged="txt_District_TextChanged" />
	<ajax:TextBoxWatermarkExtender runat="server" ID="txtWaterMark_Search" TargetControlID="txt_District" WatermarkText="Enter District Name " WatermarkCssClass="WatermarkClass" />
	<ajax:AutoCompleteExtender runat="server" ID="AutoComplete_FieldForce" TargetControlID="txt_District" ServicePath="~/App_WebServices/ServiceCommons.svc" ServiceMethod="GetDistrictNameList" FirstRowSelected="True" MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="False" ShowOnlyCurrentWordInCompletionListItem="true" CompletionSetCount="8" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth"/>
	</li>

</ul>