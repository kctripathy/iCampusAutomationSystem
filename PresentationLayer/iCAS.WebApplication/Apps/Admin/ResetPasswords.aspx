<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="ResetPasswords.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.ResetPasswords" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<%--<script language="javascript" type="text/jscript">
//	function modalpopuphide() {
//		document.getElementById("<%=ajaxModalPopup_panelMesage%>").hide;
//	}
</script>--%>
	<h1 class="PageTitle">Reset Password:</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_ResetPassword">
		<ContentTemplate>
			<div id="ResetPwd">
				<ul id="ResetPassword">
					<li class="FormLabel">
						<asp:Label runat="server" ID="lbl_UserId" Text="Enter Login User ID:" />
					</li>
					<!--User Id -->
					<li class="FormValue">
						<asp:TextBox runat="server" ID="txt_UserID" OnTextChanged="txt_UserName_Leave" AutoPostBack="true" />
						<asp:Label runat="server" ID="lbl_UserMessage" Text="" CssClass="ValidateMessage" />
						<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_UserID" ControlToValidate="txt_UserID" Display="Dynamic" CssClass="ValidateMessage" SetFocusOnError="true" />
					</li>
					<!--User Name -->
					<li class="FormLabel">
						<asp:Label runat="server" ID="lbl_UserName" Text="User Name:" />
					</li>
					<li class="FormValue">
						<asp:Label runat="server" ID="lbl_DisplayUserName" Text="N/A" />
					</li>
					<!--User Type -->
					<li class="FormLabel">
						<asp:Label runat="server" ID="lbl_UserType" Text="User Type:" />
					</li>
					<li class="FormValue">
						<asp:Label runat="server" ID="lbl_DisplayUserType" Text="N/A" />
					</li>
					<!--User EmployeeName -->
					<li class="FormLabel">
						<asp:Label runat="server" ID="lbl_EmployeeName" Text="Employee Name:" />
					</li>
					<li class="FormValue">
						<asp:Label runat="server" ID="lbl_DisplayEmployeeName" Text="N/A" />
					</li>
					<!--New Password -->
					<li class="FormLabel">
						<asp:Label runat="server" ID="lbl_NewPassword" Text="New Password:" />
					</li>
					<li class="FormValue">
						<asp:Label runat="server" ID="lbl_DisplayNewPassword" Text="N/A" />
					</li>
					<li class="FormValueCaptchaVerification">Type the text as shown in below image
						<br />
						<asp:TextBox ID="txtimgcode" runat="server" Width="220px" Height="20px"></asp:TextBox><br />
						<asp:Image ID="img_VerifyCaptcha" runat="server" ImageUrl="~/CImage.aspx" />
					</li>
					<li class="FormSpacer20px" />
					<!--Button GeneratePassword & Cancel -->
					<li class="FormButton_Top">
						<asp:Button runat="server" ID="btn_GeneratePassword" Text="Generate Password" OnClick="btn_GeneratePassword_Click" />
						<ajax:ConfirmButtonExtender runat="server" ID="ajaxConfirmButtonExtender_Password" TargetControlID="btn_GeneratePassword" ConfirmText="Are you Sure to Reset the Password ?" />
						<asp:Button runat="server" ID="btn_Cancel" Text="Cancel" CausesValidation="False" OnClick="btn_Cancel_Click" />
					</li>
				</ul>
			</div>
			<p class="ErrorMessage">
				<asp:Literal runat="server" ID="lit_ErrorMessage" Text="" />
			</p>
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="btn_Cancel" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>
