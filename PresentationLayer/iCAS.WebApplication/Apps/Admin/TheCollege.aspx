<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="TheCollege.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.TheCollege" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="manage company details " />
	</h1>
	<asp:UpdatePanel ID="updatePanel_Company" runat="server">
		<ContentTemplate>
			<asp:MultiView ID="multiView_Companydetails" runat="server" ActiveViewIndex="0">
				<asp:View runat="server" ID="view_InputControls">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="Companydetails">
						<li class="FormButton_Top">
							<div id="Top">
								<asp:Button runat="server" ID="btn_Top_View" CausesValidation="false" Text="View" OnClick="btn_Top_View_Click" />
								<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="btn_Top_Save_Click" />
								<asp:Button runat="server" ID="btn_Top_Reset" CausesValidation="false" Text="Reset" OnClick="btn_Top_Reset_Click" />
							</div>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Head_CompanyDetails" Text="Company Details :-" />
						</li>
						<!--Company Name-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CompanyName" Text="Company Name " />
							<asp:Label runat="server" ID="lbl_CompanyNameValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_CompanyName" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_CompanyName" runat="server" ControlToValidate="txt_CompanyName" SetFocusOnError="true" Display="Dynamic" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator_CompanyName" runat="server" ControlToValidate="txt_CompanyName" SetFocusOnError="true" Display="Dynamic" ValidationExpression="[a-zA-Z\s\.]+" />
						</li>
						<!--CompanyAliasName-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CompanyAliasName" Text="Company AliasName " />
							<asp:Label runat="server" ID="lbl_CompanyAliasNameValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_CompanyAliasName" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_CompanyAliasName" runat="server" ControlToValidate="txt_CompanyAliasName" SetFocusOnError="true" Display="Dynamic" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator_CompanyAliasName" runat="server" ControlToValidate="txt_CompanyAliasName" SetFocusOnError="true" Display="Dynamic" ValidationExpression="[a-zA-Z\s]+" />
						</li>
						<%--<!--CompanyCode-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CompanyCode" Text="Company Code :" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_CompanyCode" />
						</li>--%>
						<!--CompanyMailingName-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CompanyMailingName" Text="Company MailAddress " />
							<asp:Label runat="server" ID="lbl_CompanyMailingNameValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_CompanyMailingName" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_CompanyMailingName" runat="server" ControlToValidate="txt_CompanyMailingName" SetFocusOnError="true" Display="Dynamic" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator_CompanyMailingName" runat="server" ControlToValidate="txt_CompanyMailingName" SetFocusOnError="true" Display="Dynamic" />
						</li>
						<%--<!--CompanyRegisteredOfficeID-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CompanyRegisteredOfficeID" Text="Company RegisteredOfficeID :" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_CompanyRegisteredOfficeID" />
						</li>
						<!--CompanyHeadOfficeID-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CompanyHeadOfficeID" Text="Company HeadOfficeID :" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_CompanyHeadOfficeID" />
						</li>--%>
						<!--CompanyRegistrationNumber-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CompanyRegistrationNumber" Text="Company RegistrationNumber " />
							<asp:Label runat="server" ID="lbl_CompanyRegistrationNumberValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_CompanyRegistrationNumber" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_CompanyRegistrationNumber" runat="server" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txt_CompanyRegistrationNumber" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator_CompanyRegistrationNumber" runat="server" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txt_CompanyRegistrationNumber" />
						</li>
						<!--CompanyEPFRegistrationNumber-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_CompanyEPFRegistrationNumber" Text="Company EPFREGD Number " />
							<asp:Label runat="server" ID="lbl_CompanyEPFRegistrationNumberValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_CompanyEPFRegistrationNumber" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_CompanyEPFRegistrationNumber" runat="server" ControlToValidate="txt_CompanyEPFRegistrationNumber" SetFocusOnError="true" Display="Dynamic" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator_CompanyEPFRegistrationNumber" runat="server" ControlToValidate="txt_CompanyEPFRegistrationNumber" SetFocusOnError="true" Display="Dynamic" />
						</li>
						<!--EstablishmentDate-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_EstablishmentDate" Text="Company EstablishmentDate " />
							<asp:Label runat="server" ID="lbl_EstablishmentDateValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_EstablishmentDate" />
							<ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_EstablishmentDate" CssClass="MicroCalendar" Format="dd-MMM-yyyy">
							</ajax:CalendarExtender>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_EstablishmentDate" runat="server" ControlToValidate="txt_EstablishmentDate" SetFocusOnError="true" Display="Dynamic" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator_EstablishmentDate" runat="server" ControlToValidate="txt_EstablishmentDate" SetFocusOnError="true" Display="Dynamic" />
						</li>
						<!--IsActive-->
						<%--<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_IsActive" Text="IsActive" />
						</li>
						<li class="FormValue">
							<asp:CheckBox ID="chk_IsActive" runat="server" />
						</li>
						<li class="FormLabel" />--%>
						<!--ActionButton-->
						<li class="FormButton_Top">
							<div id="Buttom">
								<asp:Button runat="server" ID="btn_bottom_View" CausesValidation="false" Text="View" OnClick="btn_Top_View_Click" />
								<asp:Button runat="server" ID="btn_bottom_Save" Text="Save" OnClick="btn_Top_Save_Click" />
								<asp:Button runat="server" ID="btn_bottom_Reset" CausesValidation="false" Text="Reset" OnClick="btn_Top_Reset_Click" />
							</div>
						</li>
						<li class="FormSpacer" />
					</ul>
				</asp:View>
				<asp:View runat="server" ID="view_GridView">
					<ul class="GridView">
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_AddCompanies" Text="Add New Company" CausesValidation="false" OnClick="btn_AddCompanies_Click" />
						</li>
						<li>
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Company(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
							<asp:GridView ID="gv_Company" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2" OnRowEditing="gv_Company_RowEditing" OnRowDeleting="gv_Company_RowDeleting" OnRowCommand="gv_Company_RowCommand" OnRowDataBound="gv_Company_RowDataBound" OnPageIndexChanging="gv_Company_PageIndexChanging">
								<PagerStyle HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField ShowHeader="false" DataField="CompanyID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_CompanyID" Visible="true" />
											<asp:Label runat="server" ID="lbl_CompanyID" Text='<%# Eval("CompanyID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="CompanyName" HeaderText="CompanyName" ItemStyle-CssClass="CName" />
									<asp:BoundField DataField="CompanyAliasName" HeaderText="AliasName" ItemStyle-CssClass="CAName" />
									<asp:BoundField DataField="CompanyCode" HeaderText="Code" ItemStyle-CssClass="CCode" />
									<asp:BoundField DataField="CompanyMailingName" HeaderText="MailAddress" ItemStyle-CssClass="CMName" />
									<%--<asp:BoundField DataField="CompanyRegisteredOfficeID" HeaderText="RegisteredOfficeID" />
									<asp:BoundField DataField="CompanyHeadOfficeID" HeaderText="HeadOfficeID" />
									<asp:BoundField DataField="CompanyRegistrationNumber" HeaderText="RegistrationNumber" />
									<asp:BoundField DataField="CompanyEPFRegistrationNumber" HeaderText="EPFRegistrationNumber" />--%>
									<asp:BoundField DataField="EstablishmentDate" HeaderText="EstablishmentDate" ItemStyle-CssClass="EDate" />
									<asp:BoundField DataField="IsActive" HeaderText="IsActive" ItemStyle-CssClass="IsActive" />
									<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
								</Columns>
								<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
								<PagerStyle CssClass="MicroPagerStyle" />
							</asp:GridView>
						</li>
						<li class="FormMessage">
							<asp:Literal ID="lit_GridMessage" runat="server" Text="" />
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
</asp:Content>
