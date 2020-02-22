<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AccountTransactions.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.FINANCE.AccountTransactions" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Account Transactions" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_Account">
		<ContentTemplate>
			<asp:MultiView runat="server" ID="multiView_AccountTransaction">
				<asp:View runat="server" ID="view_InputControls">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="AccountTransaction">
						<!-- Operational Button @ Top -->
						<li class="FormButton_Top">
						<div id="Top">
							<asp:Button runat="server" ID="btn_View" CausesValidation="false" Text=" View " OnClick="btn_View_Click" />
							<asp:Button runat="server" ID="btn_Submit" Text="Save" OnClick="btn_Submit_Click" />
							<asp:Button runat="server" ID="btn_Cancel" CausesValidation="false" Text=" Reset " OnClick="btn_Cancel_Click" />
						</div>
						</li>
						<li class="FormSpacer20px"></li>
						<li class="FormValueHighlighter">
							<asp:Label runat="server" ID="lbl_OpeningBalance" CssClass="HighlighterText" />
						</li>
						<li class="FormSpacer20px"></li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_SubHeading_VoucherType" Text="Select Voucher Type :-" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_AccountName" Text="Voucher Type" />
							<asp:Label runat="server" ID="lbl_AccountNameValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:RadioButtonList runat="server" ID="radio_PaymentType" AutoPostBack="True" OnSelectedIndexChanged="radio_PaymentType_SelectedIndexChanged" RepeatDirection="Vertical">
								<asp:ListItem Selected="True">Debit Voucher</asp:ListItem>
								<asp:ListItem>Credit Voucher</asp:ListItem>
							</asp:RadioButtonList>
						</li>
                        <li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_TransCategory" Text="Select Transaction To Category :-" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CatType" Text="Category Type" />
							<asp:Label runat="server" ID="lbl_Validator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:RadioButtonList runat="server" ID="radio_Trans_Category" 
                                AutoPostBack="True" RepeatDirection="Vertical" 
                                onselectedindexchanged="radio_Trans_Category_SelectedIndexChanged">
								<asp:ListItem>Employee</asp:ListItem>
								<asp:ListItem>Student</asp:ListItem>
                                <asp:ListItem Selected="True">Guest</asp:ListItem>
							</asp:RadioButtonList>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_SubHeading_Transaction" Text="Transaction Details :-" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_TransactionDate" Text="Transaction Date " />
							<asp:Label runat="server" ID="lbl_TransactionDateValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_TransactionDate" />
						</li>
                        <li class="FormLabel">
							<asp:Label runat="server" ID="lbl_TransID" Text="Transaction Person ID " />
							<asp:Label runat="server" ID="lbl_Trans_Validator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="DropDown_TrsndID" Width="140" 
                                AutoPostBack="True" 
                                onselectedindexchanged="DropDown_TrsndID_SelectedIndexChanged" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_TransIDs" ControlToValidate="DropDown_TrsndID" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_Accounts" Text="Accounts Head" />
							<asp:Label runat="server" ID="lbl_AccountsValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_AccountHeads" Width="140" 
                                onselectedindexchanged="ddl_Accounts_SelectedIndexChanged" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Accounts" ControlToValidate="ddl_AccountHeads" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_ThirdParty" Text="Paid To " />
							<asp:Label runat="server" ID="lbl_ThirdPartyValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_ThirdParty" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ThirdParty" ControlToValidate="txt_ThirdParty" Display="Dynamic" SetFocusOnError="true" />
							<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_ThirdParty" ControlToValidate="txt_ThirdParty" Display="Dynamic" SetFocusOnError="true" />
							<ajax:FilteredTextBoxExtender runat="server" ID="ajaxFilteredTextBox_ThirdParty" Enabled="true" FilterInterval="10" FilterMode="ValidChars" FilterType="UppercaseLetters, LowercaseLetters, Custom" TargetControlID="txt_ThirdParty" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_Amount" Text="Amount" />
							<asp:Label runat="server" ID="lbl_AmountValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_Amount" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Amount" ControlToValidate="txt_Amount" Display="Dynamic" SetFocusOnError="true" />
							<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Amount" ControlToValidate="txt_Amount" Display="Dynamic" SetFocusOnError="true" />
							<ajax:FilteredTextBoxExtender runat="server" ID="ajaxFilteredTextBox_Amount" Enabled="true" FilterInterval="10" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txt_Amount" />
						</li>						
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_Reference" Text="Reference" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_Reference" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_Remark" Text="Remark" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_Remark" TextMode="MultiLine" Rows="3" />
						</li>
                        <li class="FormLabel">
							<asp:Label runat="server" ID="lbl_PaymentMode" Text="Payment Mode " />
							<asp:Label runat="server" ID="lbl_PaymentModeValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_PaymentMode" Width="140" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddl_PaymentMode_SelectedIndexChanged" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_PaymentMode" ControlToValidate="ddl_PaymentMode" Display="Dynamic" SetFocusOnError="true" />
						</li>  
                        <li class="PageSubTitle">
							<asp:Label runat="server" ID="Label1" Text="Cheque/Draft Details :-" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_ChqDate" Text="Cheque/Draft Date " />
							<asp:Label runat="server" ID="lbl_chqDate_Validator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_ChqDAte" Enabled="False" />
						</li>
                        <li class="FormLabel">
							<asp:Label runat="server" ID="lbl_BankName" Text="Bank Name" />
							<asp:Label runat="server" ID="lbl_Bankvalidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_BankName" Enabled="False" />
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_ChqNo" Text="Cheque No" />
							<asp:Label runat="server" ID="lbl_ChqNoValidator" Text="*" CssClass="ValidationColor" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_ChqNo" Enabled="False" />
						</li>                      
					</ul>
				</asp:View>
				<asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<!-- Add new -->
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_New" CausesValidation="false" 
                                OnClick="btn_New_Click" Text=" New Transaction " />
							<asp:Button runat="server" ID="btn_Delete_CheckedItem" CausesValidation="false" Text=" Delete Checked Item(s) " OnClick="btn_Delete_CheckedItem_Click" />
						</li>
						<li class="FormSearch">
							<micro:UC_Search ID="ctrl_Search" runat="server" 
                                SearchLabel="Search Transaction(s), where:" Visible="False" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
							<asp:GridView runat="server" ID="gview_AccountTransaction" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" CssClass="GridView" PageSize="25" PagerSettings-Position="Bottom" Width="98%" OnPageIndexChanging="gview_AccountTransaction_PageIndexChanging" OnRowCommand="gview_AccountTransaction_RowCommand" OnRowDataBound="gview_AccountTransaction_RowDataBound" OnRowDeleting="gview_AccountTransaction_RowDeleting">
								<PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField DataField="TransactionID" ShowHeader="false" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<HeaderTemplate>
											<asp:CheckBox runat="server" ID="chk_CheckUncheckAll" onclick="GridViewCheckAll(this);" />
										</HeaderTemplate>
										<ItemTemplate>
											<asp:Label runat="server" ID="lbl_TransactionID" Text='<%# Eval("TransactionID") %>' Visible="false" />
											<asp:CheckBox runat="server" ID="chk_TransactionID" onclick="GridViewCheck(this);" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="TransactionDate" HeaderText="Trans. Date" ItemStyle-CssClass="TransactionDate" />
									<asp:BoundField DataField="AccountHeadDescription" HeaderText="Acc. Head" ItemStyle-CssClass="AccountDescription" />
                                    <asp:BoundField DataField="TransactionCode" HeaderText="Pay Mode" ItemStyle-CssClass="PaymentMode" />
									<asp:BoundField DataField="AccountHeadType" HeaderText="Head Type" ItemStyle-CssClass="AccountHeadType" />
                                    <asp:BoundField DataField="TransactionToID" HeaderText="Trans. To ID" ItemStyle-CssClass="TransactionToID" />
									<asp:BoundField DataField="TransactionToCategory" HeaderText="Trans.To Cat." ItemStyle-CssClass="TransactionToCategory" />
                                    <asp:BoundField DataField="ThirdPartyDescription" HeaderText="Name" ItemStyle-CssClass="ThirdPartyDescription" />
									<asp:BoundField DataField="TransactionAmount" HeaderText="Trans. Amount" ItemStyle-CssClass="TransactionAmount" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="DeleteLinkItem" />
								</Columns>
								<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
								<PagerStyle CssClass="MicroPagerStyle" />
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
