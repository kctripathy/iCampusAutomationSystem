<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="MasterAccounts.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.FINANCE.MasterAccounts" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Master Accounts :-" />
	</h1>
	<asp:MultiView runat="server" ID="multiview_AccountsMaster" ActiveViewIndex="0">
		<asp:View ID="view_InputControls" runat="server">
			<div id="Mode">
				<asp:Label runat="server" ID="lbl_Mode" />
			</div>
			<ul id="AccountsMaster">
				<!-- Show AccountsMaster's List -->
				<li class="FormButton_Top">
					<div id="Top">
						<asp:Button runat="server" ID="btn_ViewTop" CausesValidation="false" Text=" View Accounts " OnClick="btn_ViewTop_Click" />
						<asp:Button runat="server" ID="btn_SaveTop" Text=" Save " OnClick="btn_SaveTop_Click" />
						<asp:Button runat="server" ID="btn_CancelTop" Text=" Reset " CausesValidation="false" OnClick="btn_CancelTop_Click" />
					</div>
				</li>
				<!-- CATEGORY -->
				<li class="PageSubTitle">
					<asp:Label runat="server" ID="Label1" Text="Account Category :-" />
				</li>
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_SubHeader_PersonalDetails" Text="Choose account type:" />
				</li>
				<li class="FormValue">
					<asp:RadioButtonList runat="server" ID="optList_AccountHeads" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="optList_AccountHeads_SelectedIndexChanged" AutoPostBack="True">
						<asp:ListItem Text="Assets" Value="1" />
						<asp:ListItem Text="Liabilities" Value="2" />
						<asp:ListItem Text="Expense" Value="3" />
						<asp:ListItem Text="Income" Value="4" />
					</asp:RadioButtonList>
				</li>
				<!-- ACCOUNT DETAILS -->
				<li class="PageSubTitle">
					<asp:Label runat="server" ID="Label2" Text="Account Details :-" />
				</li>
				<li class="DividerLine" />
				<!-- Accounts Group Name -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="Label3" Text="Select Account Group:" />
				</li>
				<li class="FormValue">
					<asp:DropDownList runat="server" ID="ddl_AccountGroup" Width="300px" 
                        Height="20px" AutoPostBack="True" 
                        onselectedindexchanged="ddl_AccountGroup_SelectedIndexChanged" />
				</li>
				<!-- Accounts  Name -->
				<li class="DividerLine" />
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_Name" Text="Master Account Name:" />
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_AccountName" Width="300px" />
					<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Name" ControlToValidate="txt_AccountName" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Accounts Name is a required field" SetFocusOnError="true" />
				</li>
				<!-- Accounts  Name -->
				<li class="DividerLine" />
				<li class="FormLabel">
					<asp:Label runat="server" ID="Label4" Text="Master Account Name:" />
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_AccountDesc" TextMode="MultiLine" Rows="4" Width="300px" />
				</li>
				<li class="FormButton_Top">
					<div id="Buttom">
						<asp:Button runat="server" ID="btn_View" CausesValidation="false" Text=" View Accounts " OnClick="btn_ViewTop_Click" />
						<asp:Button runat="server" ID="btn_Save" Text=" Save " OnClick="btn_SaveTop_Click" />
						<asp:Button runat="server" ID="btn_Cancel" Text=" Reset " CausesValidation="false" OnClick="btn_CancelTop_Click" />
					</div>
				</li>
                <li class="FormSpacer" />
                <li>
                 <asp:GridView runat="server" ID="GridAccount" AutoGenerateColumns="False" 
                        Width="100%" EmptyDataText="--No Record Found--" 
                        onrowcommand="GridAccount_RowCommand">
						<Columns>
							<asp:BoundField DataField="AccountID" HeaderText="ID" />
							<asp:BoundField DataField="AccountGroupDescription" HeaderText="Group " />
							<asp:BoundField DataField="AccountDescription" HeaderText="Account Description " />
							<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" />
							<asp:CommandField ShowDeleteButton="true" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" />
						</Columns>
						<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
						<PagerStyle CssClass="MicroPagerStyle" />
					</asp:GridView>	
                </li>
               			
			</ul>
		</asp:View>
		<asp:View runat="server" ID="view_Grid">
			<ul class="GridView">
				<li class="FormButton_Top">
					<asp:Button runat="server" ID="btn_AddAccount" Text="Add New Account" CausesValidation="false" OnClick="btn_AddAccount_Clicked" />
				</li>
				<li>
					<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Accounts(s), where:" />
				</li>
				<li class="FormPageCounter">
					<asp:Literal runat="server" ID="lit_PageCounter" />
				</li>
				<li>
					<asp:GridView runat="server" ID="grid_AccountsMaster" 
                        AutoGenerateColumns="False" Width="100%">
						<Columns>
							<asp:BoundField DataField="AccountID" HeaderText="ID" />
							<asp:BoundField DataField="AccountGroupDescription" HeaderText="Group " />
							<asp:BoundField DataField="AccountDescription" HeaderText="Account Description " />
							<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" 
                                EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" 
                                ItemStyle-CssClass="EditLinkItem" Visible="False" >
							<ItemStyle CssClass="EditLinkItem" />
                            </asp:CommandField>
							<asp:CommandField ShowDeleteButton="true" HeaderText="Del." ButtonType="Image" 
                                DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" 
                                ItemStyle-CssClass="DeleteLinkItem" Visible="False" >
						    <ItemStyle CssClass="DeleteLinkItem" />
                            </asp:CommandField>
						</Columns>
						<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
						<PagerStyle CssClass="MicroPagerStyle" />
					</asp:GridView>
				</li>
			</ul>
		</asp:View>
	</asp:MultiView>
	<asp:SqlDataSource runat="server" ID="sqlds_AccountGroups" SelectCommandType="StoredProcedure" SortParameterName="pFIN_AccountGroups_SelectByAccountGroupID" ConnectionString="<%=Micro.Commons.Connection.ConnectionString %>">
		<SelectParameters>
			<asp:SessionParameter Name="AccountGroupID" Type="Int32" SessionField="AccountGroupID" DefaultValue="1" />
		</SelectParameters>
	</asp:SqlDataSource>
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
