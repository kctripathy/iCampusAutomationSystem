<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AccountRemittances.aspx.cs" Inherits="Micro.WebApplication.MicroERP.FINANCE.AccountRemittances" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Remittances :-" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_Remittances">
		<ContentTemplate>
			<asp:MultiView runat="server" ID="multiView_Remittances">
				<asp:View runat="server" ID="view_InputControls">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="Remittances">
						<!-- Operational Button @ Top -->
						<li class="FormButton_Top">
							<div id="Top">
								<div id="RadioList">
									<asp:RadioButtonList runat="server" ID="radio_RemittanceType" AutoPostBack="true" CausesValidation="false" CellPadding="5" CellSpacing="5" OnSelectedIndexChanged="radio_RemittanceType_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Table">
										<asp:ListItem Selected="True" Text="Remittance (Payment)" Value="Payment" />
										<asp:ListItem Selected="False" Text="Remittance (Receipt)" Value="Receipt" />
									</asp:RadioButtonList>
								</div>
								<asp:Button runat="server" ID="btn_View_Top" CausesValidation="false" OnClick="btn_View_Click" Text=" View " />
								<asp:Button runat="server" ID="btn_Submit_Top" OnClick="btn_Submit_Click" Text=" Save " />
								<asp:Button runat="server" ID="btn_Cancel_Top" CausesValidation="false" OnClick="btn_Cancel_Click" Text=" Reset " />
							</div>
						</li>
						<!-- Remittance (Payment) -->
						<ul runat="server" id="ul_RemittancePayments">
							<li class="PageSubTitle">
								<asp:Label runat="server" ID="lbl_SubHeading_RemittancePayment" Text="Remittance (Payment) :-" />
							</li>
							<li class="FormLabel">
								<asp:Label runat="server" ID="lbl_TransactionDate" Text="Transaction Date :" />
								<asp:Label runat="server" ID="lbl_TransactionDate_Validation" Text="*" ForeColor="Red" />
							</li>
							<li class="FormValue">
								<asp:TextBox runat="server" ID="txt_TransactionDate" />
								<asp:ImageButton runat="server" ID="imgButton_TransactionDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
								<ajax:CalendarExtender runat="server" ID="ajaxCalender_TransactionDate" Enabled="true" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="CheckLeaveDateRange" PopupButtonID="imgButton_TransactionDate" CssClass="MicroCalendar"  TargetControlID="txt_TransactionDate" />
								<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_TransactionDate" ControlToValidate="txt_TransactionDate" Display="Dynamic" SetFocusOnError="true" />
								<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_TransactionDate" ControlToValidate="txt_TransactionDate" Display="Dynamic" />
							</li>
							<li class="FormLabel">
								<asp:Label runat="server" ID="lbl_RemittancePaidTo" Text="Remittance Paid To :" />
								<asp:Label runat="server" ID="lbl_RemittancePaidTo_Validation" Text="*" ForeColor="Red" />
							</li>
							<li class="FormValue">
								<asp:TextBox runat="server" ID="txt_RemittancePaidTo" />
								<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_RemittancePaidTo" ControlToValidate="txt_RemittancePaidTo" Display="Dynamic" SetFocusOnError="true" />
								<ajax:FilteredTextBoxExtender runat="server" ID="ajaxFilteredTextBox_RemittancePaidTo" Enabled="true" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txt_RemittancePaidTo" />
								<asp:Button runat="server" ID="btn_RemittancePaidTo" CausesValidation="false" OnClick="btn_RemittancePaidTo_Click" Text="..." ToolTip="Click here to search Office" Width="21" />
							</li>
							<li class="FormLabel">
								<asp:Label runat="server" ID="lbl_RemittanceMode" Text="Remittance Mode :" />
							</li>
							<li class="FormValue">
								<asp:RadioButtonList runat="server" ID="radioRemittanceMode" AutoPostBack="true" CausesValidation="false" CellPadding="5" CellSpacing="5" OnSelectedIndexChanged="radioRemittanceMode_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Table">
									<asp:ListItem Selected="True" Text="Remittance by Cash" Value="Payment" />
									<asp:ListItem Selected="False" Text="Remittance by Bank Deposit" Value="Receipt" />
								</asp:RadioButtonList>
							</li>
							<li class="FormLabel">
								<asp:Label runat="server" ID="lbl_BankBranch" Text="Select Bank :" />
							</li>
							<li class="FormValue">
								<asp:DropDownList runat="server" ID="ddl_BankBranch" AutoPostBack="true" OnSelectedIndexChanged="ddl_BankBranch_SelectedIndexChanged" />
								<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_BankBranch" ControlToValidate="ddl_BankBranch" Display="Dynamic" Enabled="false" SetFocusOnError="true" />
							</li>
							<li class="FormLabel">
								<asp:Label runat="server" ID="lbl_BankAccount" Text="Select Account No :" />
							</li>
							<li class="FormValue">
								<asp:DropDownList runat="server" ID="ddl_BankAccount" />
								<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_BankAccount" ControlToValidate="ddl_BankAccount" Display="Dynamic" Enabled="false" SetFocusOnError="true" />
							</li>
						</ul>
						<!--Remittance (Receipt) -->
						<ul runat="server" id="ul_RemittanceReceipt" visible="false">
							<li class="PageSubTitle">
								<asp:Label runat="server" ID="lbl_SubHeading_RemittanceReceipt" Text="Remittance (Reciept) :-" />
							</li>
						</ul>
					</ul>
				</asp:View>
				<asp:View runat="server" ID="view_GridView">
					<ul class="GridView">
						<!-- Add new -->
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_New" CausesValidation="false" OnClick="btn_New_Click" Text=" Remittance " />
						</li>
						<li>
							<micro:UC_Search runat="server" ID="ctrl_Search" SearchLabel="Search Customer(s), where:" />
						</li>
						<!-- Display Customer List -->
						<li>
							<asp:GridView runat="server" ID="gview_Remittances" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" CssClass="GridView" OnPageIndexChanging="gview_Remittances_PageIndexChanging" OnRowDataBound="gview_Remittances_RowDataBound" PageSize="17" PagerSettings-Position="Bottom" Width="100%">
								<PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField DataField="RemittanceID" ShowHeader="false" Visible="false" />
									<asp:BoundField DataField="RemittanceDate" HeaderText="Date" />
									<asp:BoundField DataField="RemittancePaidByOfficeName" HeaderText="Remittance From" />
									<asp:BoundField DataField="RemittanceReceivedByOfficeName" HeaderText="Remittance To" />
									<asp:BoundField DataField="TransactionAmount" HeaderText="Amount" ItemStyle-CssClass="GridViewNumericItem" />
									<asp:BoundField DataField="Remittance Mode" HeaderText="Remittane Mode" />
								</Columns>
							</asp:GridView>
						</li>
						<li class="FormSpacer" />
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
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdateProgress runat="server" ID="PageUpdateProgress">
		<ProgressTemplate>
			<div id="UpdateProgress">
				<div class="UpdateProgressArea">
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
