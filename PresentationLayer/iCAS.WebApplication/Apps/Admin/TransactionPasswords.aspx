<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionPasswords.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.TransactionPasswords" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<script language="javascript" type="text/javascript">
		function modalpopuphide() {
			document.getElementById("<%=ajaxModalPopup_Message%>").hide;
		}
		function Invisible() {
			document.getElementById("<%=btn_Save.ClientID%>").disabled = true;
		}
	</script>
	<h1 class="PageTitle">
		Transaction Passwords:
	</h1>
	<div id="TransactionPwd">
		<ul id="TransactionPassword">
			<!--Transaction New Password -->
			<li class="FormLabel">
				<asp:Label runat="server" ID="lbl_NewPassword" Text="New Password" />
				<asp:Label runat="server" ID="lbl_NewPasswordValidator" Text="*" CssClass="ValidationColor" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_NewPassword" TextMode="Password" />
				<asp:RequiredFieldValidator runat="server" ID="requiredfieldValidator_NewPassword" Display="Dynamic" ControlToValidate="txt_NewPassword" SetFocusOnError="true" />
			</li>
			<!--Transaction Confirm Password -->
			<li class="FormLabel">
				<asp:Label runat="server" ID="lbl_ConfirmPassword" Text="Confirm Password" />
				<asp:Label runat="server" ID="lbl_ConfirmPasswordValidator" Text="*" CssClass="ValidationColor" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_ConfirmPassword" TextMode="Password" />
				<asp:RequiredFieldValidator runat="server" ID="requiredfieldValidator_ConfirmPassword" Display="Dynamic" ControlToValidate="txt_ConfirmPassword" SetFocusOnError="true" />
				<asp:CompareValidator runat="server" ID="compareValidator_ConfirmPassword" ControlToValidate="txt_ConfirmPassword" ControlToCompare="txt_NewPassword" Display="Dynamic" SetFocusOnError="true" />
			</li>
			<!--Transaction Save & Cancel Button -->
			<li class="FormSpacer20px" />
			<asp:Label runat="server" ID="lbl_MessageTransactionPassword" Text="" />
			<li class="FormButton_Top">
				<asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Click" />
				<asp:Button runat="server" ID="btn_Cancel" Text="Cancel" CausesValidation="false" OnClick="btn_Cancel_Click" />
			</li>
		</ul>
		<ul>
			<li>
				<!--Modalpopup MessageBox -->
				<asp:Panel ID="panel_Message" runat="server">
					<div id="Container">
						<div id="Header">
							<h2 id="HeaderText">
								Question
							</h2>
						</div>
						<div id="Content">
							<br />
							<br />
							<div class="FormLabel">
								<asp:Label ID="lbl_PanelText" runat="server" Text="Are you Sure to Reset the Transaction Password ?" />
							</div>
							<div class="ButtonAllign">
								<asp:Button ID="btn_Yes" runat="server" Text="Yes" OnClientClick=" modalpopuphide" OnClick="btn_Yes_Click" CausesValidation="false" />
								<asp:Button ID="btn_No" runat="server" Text="No" OnClick="btn_No_Click" CausesValidation="false" OnClientClick="Invisible()" />
							</div>
						</div>
					</div>
				</asp:Panel>
				<ajax:ModalPopupExtender ID="ajaxModalPopup_Message" runat="server" PopupControlID="panel_Message" TargetControlID="btn_No" BackgroundCssClass="modalBackground" CancelControlID="btn_No" />
			</li>
		</ul>

	</div>
    <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
				<itemtemplate>
					<ul>
						<li>
							<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
						</li>
					</ul>
				</itemtemplate>
			</IAControl:DialogBox>
</asp:Content>
