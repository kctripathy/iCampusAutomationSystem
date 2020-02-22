<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.Forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		Forms
	</h1>
	<ul class="GridView">
		<li class="FormLabel">
			<asp:Label runat="server" ID="lbl_Roles" Text="Roles" />
			<asp:Label runat="server" ID="lbl_RolesValidator" Text="*" ForeColor="Red" />
		</li>
		<li class="FormValue">
			<asp:DropDownList runat="server" ID="ddl_Roles" AutoPostBack="true" />
			<asp:RequiredFieldValidator ID="requiredFieldValidator_Roles" runat="server" ControlToValidate="ddl_Roles" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Select a Role" />
		</li>
		<li class="FormButton_Top">
			<asp:Button runat="server" ID="btn_View" Text="ViewFormPermissions" />
		</li>
		<li class="FormPageCounter">
			<asp:Literal runat="server" ID="lit_PageCounter" />
		</li>
		<li>
			<asp:GridView runat="server" ID="gview_Forms" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridView" PageSize="25" PagerSettings-Position="Bottom" Width="98%">
				<PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
				<HeaderStyle CssClass="HeaderStyle" />
				<Columns>
					<asp:BoundField DataField="WebFormName" HeaderText="WebForm" />
					<asp:TemplateField HeaderText="Show">
						<ItemTemplate>
							<asp:CheckBox ID="chk_WebForm" runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
					<%--<asp:ButtonField DataTextField="" HeaderText="Show" />
<asp:ButtonField DataTextField="" HeaderText="Hide" />--%>
				</Columns>
				<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
				<PagerStyle CssClass="MicroPagerStyle" />
			</asp:GridView>
		</li>
		<li class="FormButton_Top">
			<asp:Button ID="btn_Update" runat="server" Text="Update" />
		</li>
	</ul>
</asp:Content>
