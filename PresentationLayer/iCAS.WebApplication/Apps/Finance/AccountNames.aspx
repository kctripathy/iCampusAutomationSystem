<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AccountNames.aspx.cs" Inherits="Micro.WebApplication.MicroERP.FINANCE.AccountNames" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="MANAGE ACCOUNT LEDGERS" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_Account">
		<ContentTemplate>
			<asp:MultiView runat="server" ID="mview_Accounts">
				<asp:View runat="server" ID="view_InputControls">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="Accounts">
						<!-- Operational Button @ Top -->
						<li class="FormButton_Top">
						<div id="Top">
							<asp:Button runat="server" ID="btn_View_Top" CausesValidation="false" Text=" View " OnClick="btn_View_Click" />
							<asp:Button runat="server" ID="btn_Submit" Text=" Save " OnClick="btn_Submit_Click" />
							<asp:Button runat="server" ID="btn_Cancel" CausesValidation="false" Text=" Reset " OnClick="btn_Cancel_Click" />
						</div>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Subheading" Text="Account Description :-" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_AccountName" Text="Account Name " />
							<asp:Label runat="server" ID="lbl_AccountNameValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_AccountName" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AccountName" ControlToValidate="txt_AccountName" Display="Dynamic" SetFocusOnError="true" />
							<ajax:FilteredTextBoxExtender runat="server" ID="ajaxFilteredTextBoxtxt_AccountName" Enabled="true" FilterMode="ValidChars" FilterType="Custom, LowercaseLetters, UppercaseLetters" TargetControlID="txt_AccountName" ValidChars=" " />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_AccountHeads" Text="Account Heads " />
							<asp:Label runat="server" ID="lbl_AccountHeadsValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_AccountHeads" AutoPostBack="true" OnSelectedIndexChanged="ddl_AccountHeads_SelectedIndexChanged" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AccountHeads" ControlToValidate="ddl_AccountHeads" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_AccessType" Text="Access Type " />
							<asp:Label runat="server" ID="lbl_AccessTypeValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_AccessType" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AccessType" ControlToValidate="ddl_AccessType" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_AnalysisFlag" Text="Anlysis Flag " />
							<asp:Label runat="server" ID="lbl_AnalysisFlagValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_AnalysisFlag" OnSelectedIndexChanged="ddl_AnalysisFlag_SelectedIndexChanged" AutoPostBack="true" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AnalysisFlag" ControlToValidate="ddl_AnalysisFlag" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_AccountNames" Text="Under (Accounts) :" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_ParentAccountName" Enabled="false" />
							<asp:CheckBox runat="server" ID="chk_TreatAsSubAccount" AutoPostBack="True" Checked="false" OnCheckedChanged="chk_TreatAsSubAccount_CheckedChanged" Text=" Treat as Sub-Account" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ParentAccountName" ControlToValidate="ddl_ParentAccountName" Display="Dynamic" Enabled="false" SetFocusOnError="true" />
						</li>
					</ul>
				</asp:View>
				<asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<!-- Add New -->
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_New" CausesValidation="false" OnClick="btn_New_Click" Text=" New Account " />
							<asp:Button runat="server" ID="btn_Delete_CheckedItem" CausesValidation="false" OnClick="btn_Delete_CheckedItem_Click" Text=" Delete Checked Item(s) " />
						</li>
						<li class="FormSearch">
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Account(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
							<asp:GridView runat="server" ID="gview_AccountName" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" CssClass="GridView" PagerSettings-Position="Bottom" Width="98%" OnPageIndexChanging="gview_AccountName_PageIndexChanging" OnRowCommand="gview_AccountName_RowCommand" OnRowDataBound="gview_AccountName_RowDataBound" OnRowDeleting="gview_AccountName_RowDeleting" OnRowEditing="gview_AccountName_RowEditing" PageSize="30">
								<PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField DataField="AccountID" ShowHeader="false" Visible="false" ItemStyle-CssClass="CheckBox" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<HeaderTemplate>
											<asp:CheckBox runat="server" ID="chk_CheckUncheckAll" onclick="GridViewCheckAll(this);" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_AccountID" Visible="true" onclick="GridViewCheck(this);" />
											<asp:Label runat="server" ID="lbl_AccountID" Text='<%# Eval("AccountID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="AccountDescription" HeaderText="Account Name" ItemStyle-CssClass="AccountDescription" />
									<asp:BoundField DataField="AccountHeadDescription" HeaderText="Head Name" ItemStyle-CssClass="AccountHeadDescription" />
									<asp:BoundField DataField="AccessType" HeaderText="Access type" ItemStyle-CssClass="AccessType" />
									<asp:BoundField DataField="AnalysisFlag" HeaderText="Analysis Flag" ItemStyle-CssClass="AnalysisFlag" />
									<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
								<asp:CommandField ShowSelectButton="true" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ItemStyle-CssClass="ViewLinkItem" ControlStyle-CssClass="ViewLink" />
								</Columns>
								<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
								<PagerStyle CssClass="MicroPagerStyle" />
							</asp:GridView>
						</li>
					</ul>
				</asp:View>
			</asp:MultiView>
			<IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
				<ItemTemplate>
					<ul>
						<li>
							<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
						</li>
					</ul>
				</ItemTemplate>
			</IAControl:DialogBox>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdateProgress runat="server" ID="PageUpdateProgress">
		<ProgressTemplate>
			<div id="UpdateProgress">
				<div class="UpdateProgressArea">
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
