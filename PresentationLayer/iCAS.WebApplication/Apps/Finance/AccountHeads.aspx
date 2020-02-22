<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AccountHeads.aspx.cs" Inherits="Micro.WebApplication.MicroERP.FINANCE.AccountHeads" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="MANAGE ACCOUNT HEADS" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_AccountHeads">
		<ContentTemplate>
			<asp:MultiView runat="server" ID="multiView_AccountHeads">
				<asp:View runat="server" ID="view_InputControls">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="AccountHead">
						<!-- Operational Button @ Top -->
						<li class="FormButton_Top">
						<div id="Top">
							<asp:Button runat="server" ID="btn_View" CausesValidation="false" Text=" View " OnClick="btn_View_Click" />
							<asp:Button runat="server" ID="btn_Submit" Text=" Save " OnClick="btn_Submit_Click" />
							<asp:Button runat="server" ID="btn_Cancel" CausesValidation="false" Text=" Reset " OnClick="btn_Cancel_Click" />
						</div>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Subheading" Text="Account Head Description :-" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_AccountHeadName" Text="Account Head Name " />
							<asp:Label runat="server" ID="lbl_AccountHeadNameValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_AccountHeadName" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AccountHeadName" ControlToValidate="txt_AccountHeadName" Display="Dynamic" SetFocusOnError="true" />
							<ajax:FilteredTextBoxExtender runat="server" ID="ajaxFilteredTextBox_AccountHeadName" Enabled="true" FilterMode="ValidChars" FilterType="LowercaseLetters, UppercaseLetters, Custom" TargetControlID="txt_AccountHeadName" ValidChars=" " />
						</li>
						<li class="FormLabel">
							<asp:Label ID="lbl_AccountHeadType" runat="server" Text="Account Head Type " />
							<asp:Label runat="server" ID="lbl_AccountHeadTypeValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_AccountHeadType" AutoPostBack="true" OnSelectedIndexChanged="ddl_AccountHeadType_SelectedIndexChanged" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AccountHeadType" ControlToValidate="ddl_AccountHeadType" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label ID="lbl_ParentAccountHeadName" runat="server" Text="Under (Account Heads) :" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_ParentAccountHeadName" Enabled="false" />
							<asp:CheckBox runat="server" ID="chk_TreatAsSubHead" AutoPostBack="True" Checked="false" OnCheckedChanged="chk_TreatAsSubHead_CheckedChanged" Text=" Treat as Sub-Head" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ParentAccountHeadName" ControlToValidate="ddl_ParentAccountHeadName" Display="Dynamic" Enabled="false" SetFocusOnError="true" />
						</li>
					</ul>
				</asp:View>
				<asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<!-- Add new -->
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_New" CausesValidation="false" OnClick="btn_New_Click" Text=" New Account Head " />
							<asp:Button runat="server" ID="btn_Delete_CheckedItem" CausesValidation="false" OnClick="btn_Delete_CheckedItem_Click" Text=" Delete Checked Item(s) " />
						</li>
						<li class="FormSearch">
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Account Head(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
							<asp:GridView runat="server" ID="gview_AccountHead" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" CssClass="GridView" OnPageIndexChanging="gview_AccountHead_PageIndexChanging" OnRowCommand="gview_AccountHead_RowCommand" OnRowDataBound="gview_AccountHead_RowDataBound" OnRowDeleting="gview_AccountHead_RowDeleting" OnRowEditing="gview_AccountHead_RowEditing" PageSize="25" PagerSettings-Position="Bottom" Width="98%">
								<PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField DataField="AccountHeadID" ShowHeader="false" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<HeaderTemplate>
											<asp:CheckBox runat="server" ID="chk_CheckUncheckAll" onclick="GridViewCheckAll(this);" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:Label runat="server" ID="lbl_AccountHeadID" Text='<%# Eval("AccountHeadID") %>' Visible="false" />
											<asp:CheckBox runat="server" ID="chk_AccountHeadID" onclick="GridViewCheck(this);" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="AccountHeadDescription" HeaderText="Name" ItemStyle-CssClass="AccountHeadDescription" />
									<asp:BoundField DataField="AccountHeadType" HeaderText="Type" ItemStyle-CssClass="AccountHeadType" />
									<asp:BoundField DataField="IsPrimary" HeaderText="Is Primary" ItemStyle-CssClass="IsPrimary" />
									<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
								    <asp:CommandField ShowSelectButton="true" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ItemStyle-CssClass="ViewLinkItem" ControlStyle-CssClass="ViewLink"/>
								</Columns>
								<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
								<PagerStyle CssClass="MicroPagerStyle" />
							</asp:GridView>
						</li>
						<li class="FormSpacer" />
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
