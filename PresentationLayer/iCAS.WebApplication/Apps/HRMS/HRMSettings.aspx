<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="HRMSettings.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.HRMSettings" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
 <h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Holiday Details" />
	</h1>

                <ajax:TabContainer runat="server" ID="tab_Holidays" ActiveTabIndex="1" autopostback="true" onactivetabchanged="tab_Holidays_ActiveTabChanged">
					<ajax:TabPanel ID="tab_HolidayAll" runat="server" HeaderText="ALL Holiday">
                    
						<ContentTemplate>
                              <asp:MultiView runat="server" ID="multiView_HolidayDetails">
				<asp:View ID="view_InputControls" runat="server">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
                     <ul id="HolidayDetails">
						<li class="FormButton_Top">
							<div id="Top">
								<asp:Button runat="server" ID="btn_ViewHolidayDetails"  CausesValidation="False" Text=" View "  OnClick="btn_ViewHolidayDetails_Click" />
								<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="btn_Top_Save_Click" />
								<asp:Button ID="btn_Reset" runat="server" CausesValidation="False" Text="Reset" OnClick="btn_Reset_Click" />
                                    
							</div>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Head_HolidayDetails" Text="Holiday Details :-" />
						</li>
						<!--Occasion-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_Occasion" Text="Occasion Name :" />
						</li>
						<li class="FormValue">
							<asp:TextBox ID="txt_OccasionDescription" runat="server" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator_OccasionName" runat="server" ControlToValidate="txt_OccasionDescription" Display="Dynamic" SetFocusOnError="true" />
							<asp:RegularExpressionValidator ID="RegularExpressionValidator_OccasionName" runat="server" ControlToValidate="txt_OccasionDescription" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[a-zA-Z\s]+" />
						</li>
						<!--Date Of Occasion-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_DateOfOccasion" Text="Date Of Occasion :" />
						</li>
						<li class="FormValue">
							<asp:TextBox ID="txt_DateOfOccasion" runat="server" />
							<asp:ImageButton runat="server" ID="imgButton_DateOfBirth" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
										<ajax:CalendarExtender ID="ajaxCalender_DOB" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_DateOfBirth" CssClass="MicroCalendar" TargetControlID="txt_DateOfOccasion"  />
										<asp:RequiredFieldValidator ID="requiredFieldValidator_DateOfOccasion" runat="server" ControlToValidate="txt_DateOfOccasion" Display="Dynamic" SetFocusOnError="true" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DateOfOccasion" ControlToValidate="txt_DateOfOccasion" Display="Dynamic" SetFocusOnError="true" />
										</li>
						<!--Is Date Fixed-->
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_IsDateFixed" Text="Is Date Fixed :" />
						</li>
						<li class="FormValue">
							<asp:CheckBox ID="chk_IsDateFixed" runat="server" />
						</li>
						
						<li class="FormLabel"></li>
						<!--Action Button-->
						<li class="FormButton_Top">
						<div id="Buttom">
							<asp:Button runat="server" ID="btn_View" CausesValidation="False" Text=" View " OnClick="btn_ViewHolidayDetails_Click" />
							<asp:Button runat="server" ID="Btn_Save" Text="Save" OnClick="btn_Top_Save_Click" />
							<asp:Button ID="btn_Cancel" runat="server" CausesValidation="False" Text="Reset" OnClick="btn_Reset_Click" /><!-- OnClick="btn_Cancel_Click"-->
						</div>
						</li>
						<li class="FormMessage">
							<asp:Literal runat="server" ID="lit_Message" Text="." />
						</li>
						<li class="FormSpacer" />
					</ul>
				</asp:View>

                 <asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_AddHoliday" Text="Add New Holiday"  CausesValidation="False" OnClick="btn_AddHoliday_Click" />
						</li>
						<li>
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Holiday(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
							<asp:GridView runat="server" ID="gview_Holiday" AutoGenerateColumns="False"  AllowPaging="True" PageSize="25" Width="98%" CssClass="GridView" CellPadding="2" OnPageIndexChanging="gview_Holiday_PageIndexChanging"  OnRowCommand="gview_Holiday_RowCommand" OnRowDeleting="gview_Holiday_RowDeleting"  OnRowEditing="gview_Holiday_RowEditing" OnRowDataBound="gview_Holiday_RowDataBound">
								<PagerStyle HorizontalAlign="Center" CssClass="MicroPagerStyle" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:BoundField ShowHeader="False" DataField="HolidayID" Visible="False" />
									<asp:TemplateField>
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_HolidayID" Visible="true" />
											<asp:Label runat="server" ID="lbl_HolidayID" Text='<%# Eval("HolidayID") %>' Visible="false" />
										</ItemTemplate>
									    <ItemStyle CssClass="CheckBox" />
									</asp:TemplateField>
                                    
									<asp:BoundField DataField="Occasion" HeaderText="Occasion " >
									    <ItemStyle CssClass="Occasion" />
                                    </asp:BoundField>
									<asp:BoundField DataField="DateOfOccasion" HeaderText="Date"  DataFormatString="{0:dd/MM/yyyy}" >
									    <ItemStyle CssClass="DateOfOccasion" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IsDateFixed" HeaderText="Fixed" >
									    <ItemStyle CssClass="IsDateFixed" />
                                    </asp:BoundField>
                                    
									<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image"  EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" >
									    <ControlStyle CssClass="EditLink" />
                                         <ItemStyle CssClass="EditLinkItem" />
                                    </asp:CommandField>
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image"  DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" >
									            <ControlStyle CssClass="DeleteLink" />
                                                <ItemStyle CssClass="DeleteLinkItem" />
                                    </asp:CommandField>
									<asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" >
                                        <ControlStyle CssClass="ViewLink" />
                                        <ItemStyle CssClass="ViewLinkItem" />
                                    </asp:CommandField>
								</Columns>
								    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
							</asp:GridView>
						</li>
						<li class="FormMessage">
							<asp:Literal ID="lit_GridMessage" runat="server" />
						</li>
						<li class="FormSpacer" />
					</ul>
				</asp:View>
			</asp:MultiView>
						</ContentTemplate>
                   
					</ajax:TabPanel>
                    <ajax:TabPanel ID="tab_HolidaySelect" runat="server" HeaderText="HolidaySelect">
                    <ContentTemplate>
                   <asp:MultiView runat="server" ID="Multiview_Holid">
				<asp:View ID="view_GridViewHolida" runat="server">
                <ul class="GridView">
                
                <asp:GridView runat="server" ID="gview_HolidaySelect" 
                        AutoGenerateColumns="False" PageSize="25" Width="98%" CssClass="GridView"  
                        CellPadding="2"  OnRowDataBound="gview_HolidaySelect_RowDataBound" >
								<PagerStyle HorizontalAlign="Center" CssClass="MicroPagerStyle" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									
									<asp:TemplateField Visible="False">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_HolidayId" Text='<%# Eval("HolidayID") %>' Visible="false" />
							            </ItemTemplate>
						            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HolidayOfficeID">
							            <ItemTemplate>
								            <asp:Label runat="server" ID="lbl_HolidayOfficeId"  Visible="true" />
							            </ItemTemplate>
						            </asp:TemplateField>
                                    <asp:BoundField DataField="HolidayID" HeaderText="HolidayID" />
									<asp:BoundField DataField="Occasion" HeaderText="Occasion " >
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
