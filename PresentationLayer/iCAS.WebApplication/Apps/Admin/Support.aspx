<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.Support" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		SUPPORT @ MICRO HOUSE:
	</h1>
	<div style="width:48%; display: block; float:left;">
		<ul id="Support">
			<li class="PageSubTitle">
				<asp:Label runat="server" ID="lbl_SupportHead" Text="Your Details:" />
			</li>
			<!-- sender's name -->
			<li class="FormValue">
				<asp:Label runat="server" ID="lbl_Name" Text="Your Name:" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_Name" Width="273px" ReadOnly="true" />
			</li>
			<!-- sender's email -->
			<li class="FormValue">
				<asp:Label runat="server" ID="Label3" Text="Email ID:" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_Email" Width="272px" ReadOnly="true" />
			</li>
			<!-- sender's subject -->
			<li class="PageSubTitle">
				<asp:Label runat="server" ID="lbl_Topic" Text="Mail Content:" />
			</li>
			<li class="FormValue">
				<asp:DropDownList runat="server" ID="ddl_SupportType">
					<asp:ListItem Text="Please send this mail for IT Support" Value="IT-SUPPORT" />
					<asp:ListItem Text="Please send this mail for HR Support" Value="HR-SUPPORT" />
					<asp:ListItem Text="Please send this mail for General Support" Value="GENERAL-SUPPORT" />
				</asp:DropDownList>
			</li>
			<li class="FormValue">
				<asp:Label runat="server" ID="Label2" Text="Subject:" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_Subject" Width="368px" />
			</li>
			<li class="FormValue">
				<asp:Label runat="server" ID="Label1" Text="Body:" />
			</li>
			<li class="FormValue">
				<asp:TextBox runat="server" ID="txt_SupportBody" TextMode="MultiLine" Rows="10" Width="132%" />
			</li>
			<li class="FormSpacer" />
			<li class="FormButton_Top">
				<asp:Button runat="server" ID="btn_SendMail" Text="Send Mail" onclick="btn_SendMail_Click" />
			</li>
			<li class="FormSpacer" />
			<li class="FormValue">
				<asp:Literal runat="server" ID="lit_Message" Text="test message" />
			</li>
		</ul>
	</div>
	<div class="SupportImage">
	
	</div>
</asp:Content>
