<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.EmployeeDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/App_UserControls/UC_SelectOffice.ascx" TagName="UC_SelectOffice" TagPrefix="Micro" %>
<%@ Register Src="~/App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="Micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Employee Informations" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_EmployeeInfo">
		<ContentTemplate>
			<div id="Mode">
				<asp:Label runat="server" ID="lbl_DataOperationMode" />
			</div>
			<ul id="CustomerDetails">
				<Micro:UC_SelectOffice ID="UC_SelectMicroOffice" runat="server" />
			</ul>
			<ul class="GridView">
				<li class="PageSubTitle">
					<asp:Label ID="lbl_Subheading" runat="server" />
				</li>
				<li>
					<Micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Employee(s), where:" />
				</li>
				<li class="FormPageCounter">
					<asp:Literal runat="server" ID="lit_PageCounter" />
				</li>
				<li>
					<asp:GridView runat="server" ID="gView_EmployeeList" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2" OnRowCommand="gView_EmployeeList_RowCommand" OnPageIndexChanging="gView_EmployeeList_PageIndexChanging">
						<PagerStyle CssClass="PagerStyle" />
						<HeaderStyle CssClass="HeaderStyle" />
						<Columns>
							<asp:BoundField ShowHeader="false" DataField="EmployeeID" Visible="false" />
							<asp:TemplateField Visible="false" ItemStyle-CssClass="ECheck">
								<ItemTemplate>
									<asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:BoundField DataField="EmployeeCode" HeaderText="Code " ItemStyle-CssClass="ECode" />
							<asp:BoundField DataField="EmployeeName" HeaderText="Name " ItemStyle-CssClass="EName" />
							<asp:BoundField DataField="OfficeName" HeaderText="Office" ItemStyle-CssClass="OfficeName" />
							<asp:CommandField ShowSelectButton="true" HeaderText="View" ButtonType="Image" InsertImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ItemStyle-CssClass="ViewLinkItem" />
						</Columns>
						<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
						<PagerStyle CssClass="MicroPagerStyle" />
					</asp:GridView>
				</li>
			</ul>
			<ul id="Tab_EmployeeDetails">
				<li class="PageSubTitle">
					<asp:Label runat="server" ID="lbl_TabHeading" Text="Employee Details" />
				</li>
				<ajax:TabContainer runat="server" ID="tab_Employee" ActiveTabIndex="0">
					<ajax:TabPanel ID="tab_PersonalDetails" runat="server" HeaderText="Personal Details">
						<ContentTemplate>
							<li class="FormLabel">
								<asp:Label ID="lbl_EmployeeName" runat="server" Text="Employee Name: " /></li><li class="FormValue">
									<asp:Label ID="lbl_EmployeeNameText" Text="N/A" runat="server" /></li><li class="FormLabel">
										<asp:Label ID="lbl_EmployeeCode" runat="server" Text="Employee Code: " /></li><li class="FormValue">
											<asp:Label ID="lbl_EmployeeCodeText" Text="N/A" runat="server" /></li><li class="FormLabel">
												<asp:Label ID="lbl_FatherName" runat="server" Text="Father Name: " /></li><li class="FormValue">
													<asp:Label ID="lbl_FatherNameText" Text="N/A" runat="server" /></li><li class="FormLabel">
														<asp:Label ID="lbl_Gender" runat="server" Text="Gender: " /></li><li class="FormValue">
															<asp:Label ID="lbl_GenderText" Text="N/A" runat="server" /></li><li class="FormLabel">
																<asp:Label ID="lbl_DOB" runat="server" Text="Date Of Birth: " /></li><li class="FormValue">
																	<asp:Label ID="lbl_DOBText" Text="N/A" runat="server" /></li><li class="FormLabel">
																		<asp:Label ID="lbl_Mobile" runat="server" Text="Mobile Number: " /></li><li class="FormValue">
																			<asp:Label ID="lbl_MobileText" Text="N/A" runat="server" /></li><li class="FormLabel">
																				<asp:Label ID="lbl_Age" runat="server" Text="Age: " /></li><li class="FormValue">
																					<asp:Label ID="lbl_AgeText" Text="N/A" runat="server" /></li><li class="FormLabel">
																						<asp:Label ID="lbl_PresentAddress" runat="server" Text="Present Address: " /></li><li class="FormValue">
																							<asp:Label ID="lbl_PresentAddressText" Text="N/A" runat="server" /></li></ContentTemplate>
					</ajax:TabPanel>
					<ajax:TabPanel ID="Tab_ProfileImage" runat="server" HeaderText="Profile Picture">
						<ContentTemplate>
							<!-- Show Image -->
							<li class="FormLabel">
								<asp:Label ID="lbl_ProfileImage" runat="server" Text="Photo : " />
							</li>
							<li class="FormLabel">
								<asp:Image runat="server" ID="img_ProfileImage" Width="150" Height="150" />
							</li>
							<!-- Show Signature -->
							<li class="FormLabel">
								<asp:Label ID="lbl_Signature" runat="server" Text="Signature :" />
							</li>
							<li class="FormLabel">
								<asp:Image runat="server" ID="img_Signature" Width="150" Height="150" />
							</li>
						</ContentTemplate>
					</ajax:TabPanel>
				</ajax:TabContainer>
				<li class="FormSpacer"></li>
			</ul>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
