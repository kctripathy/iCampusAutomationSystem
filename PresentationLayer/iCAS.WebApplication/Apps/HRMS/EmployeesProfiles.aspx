<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeesProfiles.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.EmployeesProfiles" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_MultiColumnDropdownList.ascx" TagName="MultiColumnCombo" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Employee Profile" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_EmployeeProfiles">
		<ContentTemplate>
			<asp:MultiView runat="server" ID="multiView_EmployeeProfiles">
				<asp:View ID="view_InputControls" runat="server">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="EmployeeProfile">
						<!-- Operational Button @ Top -->
						<li class="FormButton_Top">
						<div id="Top">
							<asp:Button runat="server" ID="btn_View_Top" CausesValidation="false" OnClick="btn_View_Click" Text=" View " />
							<asp:Button runat="server" ID="btn_Submit_Top" OnClick="btn_Submit_Click" Text=" Save " />
							<asp:Button runat="server" ID="btn_Cancel_Top" CausesValidation="false" OnClick="btn_Cancel_Click" Text=" Reset " />
						</div>
						</li>
						<!-- Sub Heading - Employee Profile -->
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Heading_EmployeeProfile" Text="Employee Profile :-" />
						</li>
						<!-- Select Customers -->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_EmployeeName" Text="Name " />
							<asp:Label runat="server" ID="lbl_EmployeeNameValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_Employees" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EmployeeCode" ControlToValidate="ddl_Employees" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<!-- Select Profile -->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_Profile" Text="Profile " />
							<asp:Label runat="server" ID="lbl_Profilevalidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_Profile" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EmployeeProfile" ControlToValidate="ddl_Profile" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<!-- Enter Reference -->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_Reference" Text="Reference " />
						</li>
						<li class="FormValue">
							<asp:TextBox runat="server" ID="txt_Reference" />
						</li>
						<!-- Sub Heading - Customer Profile Image -->
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Heading_CustomerProfileImage" Text="Profile Image :-" />
						</li>
						<!-- Browse Image -->
						<li class="FormLabel">
							<asp:Label ID="lbl_BrowseImage" runat="server" Text="Browse Image " />
						</li>
						<li class="FormValue">
							<asp:FileUpload ID="fileUpload_ProfileImage" runat="server" onchange="this.form.submit();" />
						</li>
						<!-- Show Image -->
						<li class="FormLabel">
							<asp:Label ID="lbl_ProfileImage" runat="server" Text="Profile Image " />
							<asp:Label runat="server" ID="lbl_ProfileImageValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:Image runat="server" ID="img_ProfileImage" Width="150" Height="150" />
						</li>
						<!-- Operational Button @ Bottom -->
						<li class="FormButton_Top">
						<div id="Buttom">
							<asp:Button runat="server" ID="btn_View_Bottom" CausesValidation="false" OnClick="btn_View_Click" Text=" View " />
							<asp:Button runat="server" ID="btn_Submit_Bottom" OnClick="btn_Submit_Click" Text=" Save " />
							<asp:Button runat="server" ID="btn_Cancel_Bottom" CausesValidation="false" OnClick="btn_Cancel_Click" Text=" Reset " />
						</div>
						</li>
					</ul>
				</asp:View>
				<asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<!-- Buttons @ Top -->
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_New" CausesValidation="false" OnClick="btn_New_Click" Text=" New Employee Profile " UseSubmitBehavior="true" />
						</li>
						<!-- Sub Heading  Profiles -->
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_GridView_ProfileInformation" Text="Employee Profile Details :-" />
						</li>
						<!-- About selected Customer -->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_GridView_AboutSelectedProfile" Text="" />
						</li>
						<li class="FormValue">
							<asp:Label runat="server" ID="lbl_GridView_AboutEmployee" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<!-- Selected Employee's Profile GridView -->
						<li>
							<asp:GridView runat="server" ID="gview_EmployeeProfiles" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" OnPageIndexChanging="gview_EmployeeProfiles_PageIndexChanging" OnRowCommand="gview_EmployeeProfiles_RowCommand" OnRowDataBound="gview_EmployeeProfiles_RowDataBound" OnRowDeleting="gview_EmployeeProfiles_RowDeleting" OnRowEditing="gview_EmployeeProfiles_RowEditing" Width="98%">
								<PagerStyle CssClass="PagerStyle" VerticalAlign="Middle" HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField ShowHeader="false" DataField="EmployeeProfileID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_EmployeeID" Visible="true" />
											<asp:Label runat="server" ID="lbl_EmployeeProfileID" Text='<%# Eval("EmployeeProfilleID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:ImageField DataImageUrlField="ImageUrl" ControlStyle-Height="150" ControlStyle-Width="150" ItemStyle-CssClass="ImageUrl" />
									<asp:BoundField DataField="EmployeeName" HeaderText=" Name " ItemStyle-CssClass="EmployeeName" />
									<asp:BoundField DataField="EmployeeCode" HeaderText=" Code " ItemStyle-CssClass="EmployeeCode" />
									<asp:BoundField DataField="CommonKeyValue" HeaderText=" Profile " ItemStyle-CssClass="CommonKeyValue" />
									<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
									<asp:CommandField ShowSelectButton="true" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ItemStyle-CssClass="ViewLinkItem" ControlStyle-CssClass="ViewLink" />
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
	<asp:UpdateProgress runat="server" ID="updateProgress_EmployeeProfile">
		<ProgressTemplate>
			<div id="UpdateProgress">
				<div class="UpdateProgressArea">
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
