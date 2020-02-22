<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="Micro.WebApplication.MicroERP.FINANCE.Transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<style>
		ul#MicroTransactions
		{
			margin: 0px;
			padding: 0px;
			display: block;
			float: left;
			width: 100%;
		}
		
		
		ul#MicroTransactions li.FormLabelAcc
		{
			width: 20%;
			display: block;
			float: left;
		}
		
		ul#MicroTransactions li.FormLabelDrCr
		{
			width: 18%;
			display: block;
			float: left;
		}
		
		ul#MicroTransactions li.FormBtn
		{
			width: 18%;
			display: block;
			float: left;
		}
	</style>
	<ul id="MicroTransactions">
		<li>
			<div id="Mode">
				<asp:Label runat="server" ID="lbl_Mode" />
			</div>
			<ul id="InputControls">
				<li class="FormLabelAcc">
					<asp:Label runat="server" ID="lbl_Select" Text="Code" />
				</li>
				<li class="FormLabelAcc">
					<asp:Label runat="server" ID="Label1" Text="Account Name" />
				</li>
				<li class="FormLabelDrCr">
					<asp:Label runat="server" ID="Label2" Text="Dr/Cr" />
				</li>
				<li class="FormLabelAcc">
					<asp:Label runat="server" ID="Label3" Text="Amount" />
				</li>
				<li class="FormBtn">
					<asp:Label runat="server" ID="Label4" Text="." />
				</li>
				<li class="FormLabelAcc">
					<asp:TextBox runat="server" ID="txt_Code" />
				</li>
				<li class="FormLabelAcc">
					<asp:TextBox runat="server" ID="TextBox1" />
				</li>
				<li class="FormLabelDrCr">
					<asp:DropDownList runat="server" ID="ddl_DrCr">
						<asp:ListItem Text="Dr" Value="DB" />
						<asp:ListItem Text="Cr" Value="CR" />
					</asp:DropDownList>
				</li>
				<li class="FormLabelAcc">
					<asp:TextBox runat="server" ID="TextBox3" />
				</li>
				<li class="FormBtn">
					<asp:Button runat="server" ID="btn_Add" Text="Add" />
				</li>
			</ul>
		</li>
	</ul>
</asp:Content>
