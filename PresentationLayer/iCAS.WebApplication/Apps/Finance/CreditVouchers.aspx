<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="CreditVouchers.aspx.cs" Inherits="Micro.WebApplication.MicroERP.FINANCE.CreditVouchers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		Credit Vouchers:
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_CreditVouchers">
		<ContentTemplate>
			<div id="Mode">
				<asp:Label runat="server" ID="lbl_DataOperationMode" />
			</div>
			<ul id="CriditVouchers">
				<li class="PageSubTitle">
					<asp:Label runat="server" ID="lbl_Head_CriditVouchers" Text="Credit Information Details:-" />
				</li>
				<!-- Date -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_CreditDate" Text="Date:" />
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_CreditDate" />
					<ajax:CalendarExtender ID="ajaxCalender_CreditDate" runat="server" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="CheckLeaveDateRange" CssClass="MicroCalendar" TargetControlID="txt_CreditDate" />
				</li>
				<!-- Account -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_Account" Text="Account:" />
				</li>
				<li class="FormValue">
					<asp:DropDownList runat="server" ID="ddl_Account" AutoPostBack="true" />
					<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Account" ControlToValidate="ddl_Account" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
				</li>
				<!-- Amount -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_Amount" Text="Amount:" />
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_Amount" />
				</li>
				<!-- Entry Type -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_EntryType" Text="Entry Type:" />
				</li>
				<li class="FormValue">
					<asp:DropDownList runat="server" ID="ddl_EntryType" AutoPostBack="true" />
					<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EntryType" ControlToValidate="ddl_EntryType" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
				</li>
				<!-- Narration -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_Narration" Text="Narration:" />
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_Narration" TextMode="MultiLine" />
				</li>
				<!--ActionButton-->
				<li class="FormButton_Top">
				<div id="Buttom">
					<asp:Button runat="server" ID="btn_AddEntry" Text="Add Entry" OnClick="btn_AddEntry_Click" />
					<asp:Button ID="btn_CorrectEntry" runat="server" CausesValidation="false" Text="CorrectEntry" />
					<asp:Button ID="btn_DeleteEntry" runat="server" CausesValidation="false" Text="DeleteEntry" />
				</div>
				</li>
				<li class="PageSubTitle"></li>
				<li class="FormPageCounter">
					<asp:Literal runat="server" ID="lit_PageCounter" />
				</li>
				<li class="FormLabel">
					<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="770px">
						<PagerStyle CssClass="PagerStyle" />
						<HeaderStyle CssClass="HeaderStyle" />
						<Columns>
							<asp:BoundField DataField="AccountName" HeaderText="Account Name" ControlStyle-CssClass="CName" ItemStyle-CssClass="AccountName" />
							<asp:BoundField DataField="Debit" HeaderText="Debit" ControlStyle-CssClass="CLCode" ItemStyle-CssClass="Debit" />
							<asp:BoundField DataField="Credit" HeaderText="Credit" ControlStyle-CssClass="CLRNumber" ItemStyle-CssClass="Credit" />
							<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" EditText="Correct" ItemStyle-CssClass="EditLinkItem" />
							<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" />
						</Columns>
						<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
						<PagerStyle CssClass="MicroPagerStyle" />
					</asp:GridView>
				</li>
				<IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
					<ItemTemplate>
						<ul>
							<li>
								<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
							</li>
						</ul>
					</ItemTemplate>
				</IAControl:DialogBox>
			</ul>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
