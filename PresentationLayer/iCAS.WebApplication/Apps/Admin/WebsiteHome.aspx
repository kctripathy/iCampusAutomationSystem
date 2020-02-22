<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="WebsiteHome.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.WebsiteHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<asp:Table ID="tbl_HomePage" runat="server" Width="100%">
	<asp:TableRow>
			<asp:TableCell ColumnSpan="2" >
			NEWS HEALINE -1
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell>
				<asp:Label ID="Label1" runat="server" Text=""></asp:Label></asp:TableCell>
			<asp:TableCell>
				<asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox><br />
				<asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
				</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2" >
			NEWS HEALINE -2
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell>
				<asp:Label ID="Label2" runat="server" Text=""></asp:Label></asp:TableCell>
			<asp:TableCell>
				<asp:TextBox ID="TextBox3" runat="server" Width="100%"></asp:TextBox><br />
				<asp:TextBox ID="TextBox4" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
				</asp:TableCell>
		</asp:TableRow>
	</asp:Table>

	
</asp:Content>
