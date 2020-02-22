<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.ForgotPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">Forgot Password:</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_Customers">
		<ContentTemplate>
			<div id="ForgotPwd">
				<ul id="ForgotPassword">
					<li class="PageSubTitle">
						<asp:Label runat="server" ID="lbl_Login" Text="Please enter your User Name and Email address:" />
					</li>
					<li class="FormSpacer20px" />
					<%--User Name--%>
					<li class="FormLabel">
						<asp:Label runat="server" ID="lbl_UserName" Text="User Name:" />
					</li>
					<li class="FormValue">
						<asp:TextBox runat="server" ID="txt_UserID" Text="" AutoPostBack="true" OnTextChanged="txt_UserID_OnTextChanged" />
						<asp:RequiredFieldValidator ID="requiredFieldValidator_UserID" runat="server" ControlToValidate="txt_UserID" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
						<ajax:TextBoxWatermarkExtender ID="txt_UserName_WatermarkExtender" runat="server" TargetControlID="txt_UserID" WatermarkText="Enter your Login ID" WatermarkCssClass="WatermarkClass">
						</ajax:TextBoxWatermarkExtender>
					</li>
					<%--UserEmailId--%>
					<li class="FormLabel">
						<asp:Label runat="server" ID="lbl_EmailID" Text="Email ID:" />
					</li>
					<li class="FormValue">
						<asp:TextBox runat="server" ID="txt_EmailID" Text="" BackColor="Gainsboro" />
						<ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txt_EmailID" WatermarkText="Your Email Address" WatermarkCssClass="WatermarkClass">
						</ajax:TextBoxWatermarkExtender>
						<asp:RequiredFieldValidator ID="requiredFieldValidator_EmailId" runat="server" ControlToValidate="txt_EmailID" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator ID="regularExpressionValidator_EmailID" runat="server" ControlToValidate="txt_EmailID" Display="Dynamic" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
					</li>

					<li class="FormValueCaptchaVerification">
						 Type the text as shown in below image <br /><asp:TextBox ID="txtimgcode" runat="server" Width="220px" Height="20px"></asp:TextBox><br />
						<asp:Image ID="img_VerifyCaptcha" runat="server" ImageUrl="~/CImage.aspx" />
					</li>
					<!-- Button Submit -->
					<li class="FormButton">
						<asp:Button runat="server" ID="btn_RetrievePassword" Text="  Retrieve Password  " OnClick="btn_RetrievePassword_Click" />
					</li>
				</ul>
				<%--<p class="Links"><a href="../../Index.aspx">Home</a> :: <a href="../Login.aspx">Login</a> :: <a href="../../ContactUs.aspx">Contact</a> </p>--%>
				<p class="ErrorMessage">
					<asp:Literal runat="server" ID="lit_Message" Text="" />
				</p>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdateProgress runat="server" ID="PageUpdateProgress">
		<ProgressTemplate>
			<div id="UpdateProgress">
				<div class="UpdateProgressArea" />
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
