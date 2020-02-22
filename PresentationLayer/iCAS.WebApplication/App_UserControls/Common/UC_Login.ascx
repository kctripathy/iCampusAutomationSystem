<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Login.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.Common.UC_Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<ul id="Login">
	<li class="FormValue">
		<asp:DropDownList ID="ddl_UserTye" runat="server">
			<asp:ListItem Value="1" Text="Employee" />
			<asp:ListItem Value="2" Text="Guest" />
		</asp:DropDownList>
	</li>
	<li class="FormValue">
		<asp:TextBox runat="server" ID="txt_UserName" OnTextChanged="txt_UserName_TextChanged" AutoPostBack="true" />
		<ajax:TextBoxWatermarkExtender runat="server" ID="txtWaterMark_UserName" TargetControlID="txt_UserName" WatermarkText="Enter User Name" WatermarkCssClass="WatermarkClass" />
		<asp:TextBox runat="server" ID="txt_Password" TextMode="Password" />
		<%--<ajax:TextBoxWatermarkExtender runat="server" ID="txtWaterMark_Password" TargetControlID="txt_Password" WatermarkText="Enter Password " WatermarkCssClass="WatermarkClass" />--%>
		<asp:Button runat="server" ID="btn_Go" Text="GO" OnClick="btn_Go_Click" CausesValidation="false" />
	</li>
	<li>
		<asp:Label ID="lit_Message" runat="server" ForeColor="Red" />
	</li>
</ul>

<div id="CompanyList" style="display: block;">
	<asp:RadioButtonList ID="radioButtonListCompanies" runat="server" RepeatDirection="Horizontal">
	</asp:RadioButtonList>
</div>
<asp:LinkButton runat="server" ID="btn_Link" Text="SignUp" OnClick="btn_Link_Click" />
<asp:Panel ID="pnlSelect" runat="server" Width="400px" Height="180px" BackColor="InactiveCaption">
	<center>
		<li >
			<asp:Label ID="lbl_signupUserName" runat="server" Text="Name" />
		</li>
		<li >
			<asp:TextBox ID="txt_signupUserName" runat="server" />
			<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_signupUserName" ControlToValidate="txt_signupUserName" ErrorMessage="*" SetFocusOnError="true" ForeColor="Red" />
		</li>
		<li >
			<asp:Label ID="lbl_signupEmailID" runat="server" Text="EmailID" />
		</li>
		<li >
			<asp:TextBox ID="txt_signupEmailID" runat="server" />
			<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_signupEmailID" ControlToValidate="txt_signupEmailID" ErrorMessage="*" SetFocusOnError="true" ForeColor="Red" />
		</li>
		<li >
			<asp:Label ID="lbl_signupPhoneNumber" runat="server" Text="Mobile" />
		</li>
		<li >
			<asp:TextBox ID="txt_signupPhoneNumber" runat="server" />
			<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_signupPhoneNumber" ControlToValidate="txt_signupPhoneNumber" ErrorMessage="*" SetFocusOnError="true" ForeColor="Red" />
		</li>
		<li>
			<asp:Button ID="ButtonOK" runat="server" Text="Create User" OnClick="ButtonOK_Click" Width="81px" />
			<asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" Width="74px" />
		</li>
	</center>
</asp:Panel>
<ajax:ModalPopupExtender ID="Modal_SignUp" runat="server" TargetControlID="btn_Link" PopupControlID="pnlSelect" CancelControlID="ButtonCancel">
</ajax:ModalPopupExtender>
