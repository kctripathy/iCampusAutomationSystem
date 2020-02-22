<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AccountGroups.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.FINANCE.AccountGroups" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Account Groups:-" />
	</h1>
     <div id="Mode">
		<asp:Label runat="server" ID="lbl_DataOperationMode" />
	</div>
    <asp:MultiView runat="server" ID="multiview_AccountsMaster" ActiveViewIndex="0">
	<asp:View ID="view_InputControls" runat="server">
	<ul id="AccountsMaster">
    <li class="FormLabel">
					<asp:Label runat="server" ID="lbl_ParentAccountGroup" 
                        Text="Master Account Group:" />
				</li>
				<li class="FormValue">
					<asp:DropDownList runat="server" ID="ddl_ParentAccountGroup" Width="300px" 
                        Height="20px" />
				</li>
				<!-- Accounts  Name -->
				<li class="DividerLine" />
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_AccountGroup" Text="Account Group Name:" />
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_AccountGroupName" Width="300px" />
					<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Name" 
                        ControlToValidate="txt_AccountGroupName" CssClass="ValidateMessage" 
                        Display="Dynamic" ErrorMessage="Accounts Group Name is a required field" 
                        SetFocusOnError="true" />
				</li>
                <li class="FormButton_Top">
					<div id="Top">
						<asp:Button runat="server" ID="btn_View" CausesValidation="false" Text=" View " OnClick="btn_View_Click" />
						<asp:Button runat="server" ID="btn_Submit" Text=" Save " OnClick="btn_Submit_Click" />
						<asp:Button runat="server" ID="btn_Cancel" CausesValidation="false" Text=" Reset " OnClick="btn_Cancel_Click" />
					</div>
				</li>
	</ul>
    </asp:View>
    <asp:View runat="server" ID="view_Grid">
			<ul class="GridView">
				<li class="FormButton_Top">
					<asp:Button runat="server" ID="btn_AddAccount" Text="Add New Account" CausesValidation="false" OnClick="btn_AddAccount_Clicked" />
				</li>
				<%--<li>
					<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Accounts(s), where:" />
				</li>--%>
				<li class="FormPageCounter">
					<asp:Literal runat="server" ID="lit_PageCounter" />
				</li>
				<li>
					<asp:GridView runat="server" ID="grid_AccountsMaster" 
                        AutoGenerateColumns="false" Width="100%" 
                        onrowcommand="grid_AccountsMaster_RowCommand">
						<Columns>
                            <asp:TemplateField ItemStyle-CssClass="CheckBox" Visible="false"> 
										<ItemTemplate>
											<asp:Label runat="server" ID="lbl_AccountGroupID" Text='<%# Eval("AccountGroupID") %>' Visible="false" />										
										</ItemTemplate>
						    </asp:TemplateField>
							<asp:BoundField DataField="AccountGroupID" HeaderText="ID" />
							<asp:BoundField DataField="AccountGroupDescription" HeaderText="AccountGroupDescription " />
							<asp:BoundField DataField="AccountGroupAlias" HeaderText="AccountGroupAlias " Visible="false"/>
							<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" />
							<asp:CommandField ShowDeleteButton="true" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" />
						</Columns>
						<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
						<PagerStyle CssClass="MicroPagerStyle" />
					</asp:GridView>
				</li>
			</ul>
		</asp:View>
    </asp:MultiView>
    <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
		<ItemTemplate>
		<ul>
		<li>
			<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
		</li>
		</ul>
		</ItemTemplate>
	</IAControl:DialogBox>
</asp:Content>
