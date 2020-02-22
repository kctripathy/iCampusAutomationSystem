<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">Change Password: </h1>
	<div id="ChangePwd">
		 
		<ul id="ChangePassword">
			<li class="FormLabel">
				<asp:Label runat="server" ID="lbl_OldPassword" Text="Old Password" />
				<asp:Label runat="server" ID="lbl_OldPasswordValidator" Text="*" CssClass="ValidationColor" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_OldPassword" TextMode="Password" />
				<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_OldPassword" ControlToValidate="txt_OldPassword" Display="Dynamic" SetFocusOnError="true" />
			</li>
			<li class="FormLabel">
				<asp:Label runat="server" ID="lbl_NewPassword" Text="New Password" />
				<asp:Label runat="server" ID="lbl_NewPasswordValidator" Text="*" CssClass="ValidationColor" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_NewPassword" TextMode="Password" />
				<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_NewPassword" ControlToValidate="txt_NewPassword" Display="Dynamic" SetFocusOnError="true" />
			</li>
			<li class="FormLabel">
				<asp:Label runat="server" ID="lbl_ConfirmPassword" Text="Confirm Password" />
				<asp:Label runat="server" ID="lbl_ConfirmPasswordValidator" Text="*" CssClass="ValidationColor" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_ConfirmPassword" TextMode="Password" />
				<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ConfirmPassword" ControlToValidate="txt_confirmPassword" Display="Dynamic" SetFocusOnError="true" />
				<asp:CompareValidator runat="server" ID="compareValidator_ConfirmPassword" ControlToValidate="txt_ConfirmPassword" ControlToCompare="txt_NewPassword" Display="Dynamic" SetFocusOnError="true" />
			</li>
			<li class="FormValueCaptchaVerification">Type the text as shown in below image
				<br />
				<asp:TextBox ID="txtimgcode" runat="server" Width="220px" Height="20px"></asp:TextBox><br />
				<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidatorImageCode" ControlToValidate="txtimgcode" Display="Dynamic" SetFocusOnError="true" />
				<asp:Image ID="img_VerifyCaptcha" runat="server" ImageUrl="~/CImage.aspx" />
			</li>
			<li class="FormSpacer20px" />
			<asp:Label runat="server" ID="lbl_SuccessMessage" Text="" CssClass="ValidateMessage" />
			<li class="FormButton_Top">
				<asp:Button runat="server" ID="btn_ChangePassword" Text=" Submit " OnClick="btn_ChangePassword_Click" />
				<asp:Button runat="server" ID="btn_Cancel" Text=" Cancel " CausesValidation="false" OnClick="btn_Cancel_Click" />
			</li>
			<li>
				<asp:Label runat="server" ID="lbl_ErrorMessage" Text="" CssClass="ValidateMessage" />
			</li>
		</ul>
	</div>
</asp:Content>
