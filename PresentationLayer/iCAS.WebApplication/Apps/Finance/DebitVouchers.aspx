<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="DebitVouchers.aspx.cs" Inherits="Micro.WebApplication.MicroERP.FINANCE.DebitVouchers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<asp:UpdatePanel runat="server" ID="updatePanel_DebitVouchers">
		<ContentTemplate>
			<h1 class="PageTitle">
				<asp:Literal runat="server" ID="lit_PageTitle" Text="Debit Vouchers" />
			</h1>
			<div id="Mode">
				<asp:Label runat="server" ID="lbl_DataOperationMode" />
			</div>
			<ul id="DebitVouchers">
				<li class="PageSubTitle">
					<asp:Label runat="server" ID="lbl_Head_DebitDetails" Text="Debit Information Details:-" />
				</li>
				<!-- Date -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_DebitDate" Text="Date:" />
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_DebitDate" />
					<%--<ajax:calendarextender id="ajaxCalender_DebitDate" runat="server" format="dd-MMM-yyyy" onclientdateselectionchanged="CheckLeaveDateRange" CssClass="MicroCalendar" targetcontrolid="txt_DebitDate" />--%>
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
				<div id="Buttom">
					<asp:Button runat="server" ID="btn_AddEntry" Text="Add Entry" OnClick="btn_AddEntry_Click" />
					<asp:Button ID="btn_UpdateEntry" runat="server" CausesValidation="false" Text="Update Entry" OnClick="btn_UpdateEntry_Click" />
					<asp:Button ID="btn_Reset" runat="server" CausesValidation="false" Text="Reset" />
				</div>
				<li class="PageSubTitle"></li>
				<li class="FormPageCounter">
					<asp:Literal runat="server" ID="lit_PageCounter" />
				</li>
				<li>
					<asp:GridView ID="gView_DebitVoucher" runat="server" AutoGenerateColumns="false" Width="770px" OnRowEditing="gView_DebitVoucher_RowEditing" OnRowCommand="gView_DebitVoucher_RowCommand" OnRowDeleting="gView_DebitVoucher_RowDeleting">
						<PagerStyle CssClass="PagerStyle" />
						<HeaderStyle CssClass="HeaderStyle" />
						<Columns>
							<asp:BoundField DataField="AccountName" HeaderText="Account Name" ControlStyle-CssClass="CName" ItemStyle-CssClass="AccountName" />
							<asp:BoundField DataField="Debit" HeaderText="Debit" ControlStyle-CssClass="CLCode" ItemStyle-CssClass="Debit" />
							<asp:BoundField DataField="Credit" HeaderText="Credit" ControlStyle-CssClass="CLRNumber" ItemStyle-CssClass="Credit" />
							<asp:CommandField ShowEditButton="True" HeaderText="Edit" EditText="Correct" ItemStyle-CssClass="EditLinkItem" />
							<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" />
						</Columns>
						<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
						<PagerStyle CssClass="MicroPagerStyle" />
					</asp:GridView>
				</li>
				<%--<iacontrol:dialogbox id="dialog_Message" runat="server" title="Confirmation" backgroundcssclass="modalBackground" style="display: none" cssclass="modalPopup" enableviewstate="true">
					<ItemTemplate>
						<ul id="CustomerDialog">
							<li>
								<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
							</li>
						</ul>
					</ItemTemplate>
				</iacontrol:dialogbox>--%>
				<li class="FormButton">
					<asp:Button runat="server" ID="btn_Submit" Text="Submit" OnClick="btn_Submit_Click" />
				</li>
			</ul>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
