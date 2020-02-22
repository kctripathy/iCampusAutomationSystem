<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Shifts.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.Shifts" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Shift Details" />
	</h1>
	  <ajax:TabContainer runat="server" ID="tab_Shifts" ActiveTabIndex="1" autopostback="true" onactivetabchanged="tab_Shifts_ActiveTabChanged">
					<ajax:TabPanel ID="tab_ShiftAll" runat="server" HeaderText="ALL Shift">
                    
		<ContentTemplate>
			<asp:MultiView runat="server" ID="multiView_ShiftDetails">
				<asp:View ID="view_InputControls" runat="server">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="DepartmentDetails">
						<li class="FormButton_Top">
							<div id="Top">
								<asp:Button runat="server" ID="btn_ViewShift" CausesValidation="false" Text=" View " OnClick="btn_ViewShift_Click" />
								<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="Btn_Save_Click" />
								<asp:Button ID="btn_Cancel_Top" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
							</div>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Head_ShiftDetails" Text="Shift Details :-" />
						</li>
						<!--Shift Name"-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_ShiftsName" Text="Description " />
							<asp:Label runat="server" ID="lbl_ShiftsNameValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox ID="txt_Description" runat="server" />
							<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Description" ControlToValidate="txt_Description" Display="Dynamic" SetFocusOnError="true" />
							<%--<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Description" ControlToValidate="txt_Description" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[a-zA-Z\s]+" />--%>
						</li>
						<!--Alias-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_Alias" Text="Alias " />
							<asp:Label runat="server" ID="lbl_AliasValidator" Text="*" ForeColor="Red" />
						</li>
						<li class="FormValue">
							<asp:TextBox ID="txt_Alias" runat="server" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_Alias" runat="server" ControlToValidate="txt_Alias" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel"></li>
						<!--Action Button-->
						<li class="FormButton_Top">
							<div id="Buttom">
								<asp:Button runat="server" ID="Button3" CausesValidation="false" Text=" View " OnClick="btn_ViewShift_Click" />
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
							<asp:Button runat="server" ID="btn_AddShift" Text="Add New Shift" CausesValidation="false" OnClick="btn_AddShift_Click" />
						</li>
						<li>
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Shift(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
							<asp:GridView runat="server" ID="gview_Shift" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="25" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2" OnRowCommand="gview_Shift_RowCommand" OnRowEditing="gview_Shift_RowEditing" OnRowDeleting="gview_Shift_RowDeleting" OnPageIndexChanging="gview_Shift_PageIndexChanging" OnRowDataBound="gview_Shift_RowDataBound">
								<PagerStyle HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField ShowHeader="false" DataField="ShiftID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_ShiftID" Visible="true" />
											<asp:Label runat="server" ID="lbl_ShiftID" Text='<%# Eval("ShiftID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="ShiftDescription" HeaderText="Description " ItemStyle-CssClass="DeptDescription" />
                                    <asp:BoundField DataField="ShiftAlias" HeaderText="Alias " ItemStyle-CssClass="DeptDescription" />
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
                    <ajax:TabPanel ID="tab_ShiftSelect" runat="server" HeaderText="ShiftSelect">
                    <ContentTemplate>
                   <asp:MultiView runat="server" ID="Multiview_Desig">
				<asp:View ID="view_GridViewShift" runat="server">
                <ul class="GridView">
                
                <asp:GridView runat="server" ID="gview_Shiftelect" AutoGenerateColumns="False"  AllowPaging="False" PageSize="25" Width="98%" CssClass="GridView"  CellPadding="2"  OnRowDataBound="gview_Shiftelect_RowDataBound" >
								<PagerStyle HorizontalAlign="Center" CssClass="MicroPagerStyle" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									
									<asp:TemplateField Visible="False">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_ShiftId" Text='<%# Eval("ShiftID") %>' Visible="false" />
							            </ItemTemplate>
						            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ShiftOfficeID"  Visible="true">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_ShiftOfficeId"  Visible="true" />
							            </ItemTemplate>
						            </asp:TemplateField>
                                    <asp:BoundField DataField="ShiftID" HeaderText="ShiftID" />
								<asp:BoundField DataField="ShiftDescription" HeaderText="Description " ItemStyle-CssClass="DeptDescription" />
                                    <asp:BoundField DataField="ShiftAlias" HeaderText="Alias " ItemStyle-CssClass="DeptDescription" />
									    
                                   
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
