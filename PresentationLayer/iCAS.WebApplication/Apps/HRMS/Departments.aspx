<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.Departments" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Department Details" />
	</h1>
	<ajax:TabContainer runat="server" ID="tab_Departments" ActiveTabIndex="1" autopostback="true" onactivetabchanged="tab_Departments_ActiveTabChanged">
					<ajax:TabPanel ID="tab_DepartmentAll" runat="server" HeaderText="ALL Department">
                    
		<ContentTemplate>
			<asp:MultiView runat="server" ID="multiView_DepartmentDetails">
				<asp:View ID="view_InputControls" runat="server">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="DepartmentDetails">
						<li class="FormButton_Top">
							<div id="Top">
								<asp:Button runat="server" ID="btn_ViewDepartment" CausesValidation="false" Text=" View " OnClick="btn_ViewDepartment_Click" />
								<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="Btn_Save_Click" />
								<asp:Button ID="btn_Cancel_Top" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
							</div>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Head_DepartmentDetails" Text="Department Details :-" />
						</li>
						<!--Department Name"-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_DepartmentsName" Text="Department'sName " />
							<asp:Label runat="server" ID="lbl_DepartmentsNameValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox ID="txt_DepartmentDescription" runat="server" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DepartmentDescription" ControlToValidate="txt_DepartmentDescription" Display="Dynamic" SetFocusOnError="true" />
							<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DepartmentDescription" ControlToValidate="txt_DepartmentDescription" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[a-zA-Z\s]+" />
						</li>
						<!--Parent Department-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_ParentDepartment" Text="Parent Department " />
							<asp:Label runat="server" ID="lbl_ParentDepartmentValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:DropDownList runat="server" ID="ddl_ParentDepartment" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_ddl_ParentDepartment" runat="server" ControlToValidate="ddl_ParentDepartment" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel"></li>
						<!--Action Button-->
						<li class="FormButton_Top">
							<div id="Buttom">
								<asp:Button runat="server" ID="Button3" CausesValidation="false" Text=" View " OnClick="btn_ViewDepartment_Click" />
								<asp:Button runat="server" ID="Btn_Save" Text="Save" OnClick="Btn_Save_Click" />
								<asp:Button ID="btn_Cancel" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
							</div>
						</li>
						<li class="FormMessage">
							<asp:Literal runat="server" ID="lit_Message" Text="" />
						</li>
						<li class="FormSpacer" />
					</ul>
				</asp:View>
				<asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_AddDepartment" Text="Add New Department" CausesValidation="false" OnClick="btn_AddDepartment_Click" />
						</li>
						<li>
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Department(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
							<asp:GridView runat="server" ID="gview_Department" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="25" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2" OnRowCommand="gview_Department_RowCommand" OnRowEditing="gview_Department_RowEditing" OnRowDeleting="gview_Department_RowDeleting" OnPageIndexChanging="gview_Department_PageIndexChanging" OnRowDataBound="gview_Department_RowDataBound">
								<PagerStyle HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField ShowHeader="false" DataField="DepartmentID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_DepartmentID" Visible="true" />
											<asp:Label runat="server" ID="lbl_DepartmentID" Text='<%# Eval("DepartmentID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="DepartmentDescription" HeaderText="Department " ItemStyle-CssClass="DeptDescription" />
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
			
		</ContentTemplate>
	</ajax:TabPanel>
                     <ajax:TabPanel ID="tab_DepartmentSelect" runat="server" HeaderText="DepartmentSelect">
                    <ContentTemplate>
                   <asp:MultiView runat="server" ID="Multiview_Desig">
				<asp:View ID="view_GridViewDepart" runat="server">
                <ul class="GridView">
                
                <asp:GridView runat="server" ID="gview_DepartmentSelect" AutoGenerateColumns="False"  AllowPaging="True" PageSize="25" Width="98%" CssClass="GridView"  CellPadding="2" OnPageIndexChanging="gview_Department_PageIndexChanging" >
								<PagerStyle HorizontalAlign="Center" CssClass="MicroPagerStyle" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									
									<asp:TemplateField Visible="False">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_DepartmentId" Text='<%# Eval("DepartmentId") %>' Visible="false" />
							            </ItemTemplate>
						            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DepartmentOfficeID">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_DepartmentOfficeId"  Visible="true" />
							            </ItemTemplate>
						            </asp:TemplateField>
                                    <asp:BoundField DataField="DepartmentID" HeaderText="DepartmentID" />
									<asp:BoundField DataField="DepartmentDescription" HeaderText="Name " >
									    <ItemStyle CssClass="DDescription" />
                                    </asp:BoundField>
                                		<asp:TemplateField HeaderText="Check All">
							                <HeaderTemplate>
								            <asp:Literal runat="server" ID="lit_Add" Text="Add" /><br />
								            <asp:CheckBox ID="chkSelectAll_Add" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_Add_CheckedChanged" ToolTip="Select All ADD Permissions" />
							                </HeaderTemplate>
							            <ItemTemplate>
								            <asp:CheckBox ID="chk_Add" runat="server" />
							            </ItemTemplate>
						                </asp:TemplateField>
								</Columns>
								<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
							</asp:GridView>
                
                <li class="FormButton_Top">
						<asp:Button runat="server" ID="btn_Apply"  Text=" ApplyChanges" OnClick="btn_Apply_Click" />
				</li>
                
                  </ul>
                   </asp:View>
                   
                   </asp:MultiView>
                    </ContentTemplate>
                    </ajax:TabPanel>
      </ajax:TabContainer>
	
     <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
				<itemtemplate>
					<ul>
						<li>
							<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
						</li>
					</ul>
				</itemtemplate>
			</IAControl:DialogBox>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
		<ProgressTemplate>
			<div id="UpdateProgress">
				<div class="UpdateProgressArea">
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
