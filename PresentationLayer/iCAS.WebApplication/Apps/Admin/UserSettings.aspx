<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.UserSettings" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Your Settings :-" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_UserSettings">
		<ContentTemplate>
			<ul class="GridView">
				<li class="FormSpacer" />
				<li>
					<asp:GridView runat="server" ID="gview_UserSettings" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" CssClass="GridView" OnPageIndexChanging="gview_UserSettings_PageIndexChanging" OnRowCancelingEdit="gview_UserSettings_RowCancelingEdit" OnRowCommand="gview_UserSettings_RowCommand" OnRowDataBound="gview_UserSettings_RowDataBound" OnRowEditing="gview_UserSettings_RowEditing" OnRowUpdating="gview_UserSettings_RowUpdating" PagerSettings-Position="Bottom" PageSize="13" Width="100%">
						<HeaderStyle CssClass="HeaderStyle" />
						<EditRowStyle CssClass="EditRowStyle" />
						<Columns>
							<asp:BoundField DataField="UserSettingKeyDescription" HeaderText="Setting Description" ReadOnly="True" ItemStyle-CssClass="SettingKeyDesc" />
							<asp:TemplateField HeaderText="Value" ItemStyle-CssClass="SettingValue">
								<ItemTemplate>
									<asp:Literal runat="server" ID="lit_SettingValue" Text='<%#Eval("UserSettingValue") %>' />
								</ItemTemplate>
								<EditItemTemplate>
									<asp:Literal runat="server" ID="lit_SettingKeyName" Text='<%#Eval("UserSettingKeyName") %>' Visible="false" />
									<asp:DropDownList ID="ddl_UserSettingValue" runat="server" />
								</EditItemTemplate>
							</asp:TemplateField>
							<asp:CommandField CausesValidation="false" ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" UpdateImageUrl="~/Themes/Default/Images/GRID_SAVE.ico" UpdateText="Save" CancelImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" CancelText="Cancel"  ItemStyle-Height="32" ItemStyle-Width="32" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
						</Columns>
					</asp:GridView>
					<IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
						<ItemTemplate>
							<ul id="CustomerDialog">
								<li>
									<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
								</li>
							</ul>
						</ItemTemplate>
					</IAControl:DialogBox>
				</li>
			</ul>
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
