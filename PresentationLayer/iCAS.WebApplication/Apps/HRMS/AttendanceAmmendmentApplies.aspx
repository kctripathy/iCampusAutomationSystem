<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AttendanceAmmendmentApplies.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.AttendanceAmmendmentApplies" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Attandance Ammendment Application Form:-" />
    </h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_AttandenceAmmendmentApplication">
		<ContentTemplate>
			<asp:MultiView runat="server" ID="multiView_AttandenceAmmendmentApplicationDetails">
				<asp:View ID="view_InputControls" runat="server">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="AttandenceAmmendmentApplicationDetails">
						<li class="FormButton_Top">
							<div id="Top">
								<asp:Button runat="server" ID="btn_ViewApplication" CausesValidation="false" 
                                    Text=" View " onclick="btn_ViewApplication_Click"  />
								<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="Btn_Save_Click" />
								<asp:Button ID="btn_Cancel_Top" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
							</div>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Head_DepartmentDetails" Text="Attandence Ammendment Application Details :-" />
						</li>
					<li class="FormLabel">
                            <asp:Label ID="lbl_FromDate" runat="server" Text="AttendanceDate :"/>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_AttendanceDate" runat="server" />
                            <ajax:CalendarExtender ID="CalendarExtenderFromDate" runat="server" CssClass="MicroCalendar"   Format="dd-MMM-yyyy" PopupButtonID="imgButton_AttendanceDate" TargetControlID="txt_AttendanceDate" />
                            <asp:ImageButton ID="imgButton_AttendanceDate" runat="server" CausesValidation="false"  Height="21" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" ToolTip="Show Calender" Width="21" />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_AttendanceDate" runat="server"  ControlToValidate="txt_AttendanceDate" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator ID="regularExpressionValidator_AttendanceDate" runat="server" ControlToValidate="txt_AttendanceDate" Display="Dynamic" SetFocusOnError="true" />
                            <asp:Button ID="btn_GetAttandance" runat="server" Text="GetAttendance"   CausesValidation =false OnClick="btn_GetAttandance_Click" />
                        </li>

                        <!-- Attendance Type -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_AttendanceType" runat="server" Text="Attendacne Type:"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList ID="ddl_AttendanceType" runat="server"  />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_AttendanceType" runat="server"  ControlToValidate="ddl_AttendanceType" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
                        </li>
                        <!--OldTime -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_OldTime" runat="server" Text="Old Time :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_OldTime" runat="server" Columns="10" Enabled="False" />
                            <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true" ErrorTooltipEnabled="true" Mask="99:99" MaskType="Time"  MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txt_OldTime">
                            </ajax:MaskedEditExtender>
                           
                        </li>
                        <!-- New Time -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_NewTime" runat="server" Text="New Time :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_NewTime" runat="server" Columns="7" />
                            <ajax:MaskedEditExtender ID="BusinessHoursStartMaskedEditExtender" runat="server" AcceptAMPM="true" ErrorTooltipEnabled="true" Mask="99:99" MaskType="Time"   MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"  TargetControlID="txt_NewTime">
                              </ajax:MaskedEditExtender>  
                             <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_NewTime" ControlToValidate="txt_NewTime" Display="Dynamic" SetFocusOnError="true"  ErrorMessage= "sorry"/>
                               <asp:RequiredFieldValidator ID="requiredFieldValidator_NewTime" runat="server"  ControlToValidate="txt_NewTime" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <!-- Reason -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_Reason" runat="server" Text="Reason :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_Reason" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_Reason" runat="server" ControlToValidate="txt_Reason" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                    </ul>
                    <ul>
                        <li class="SubHeading">
                            <asp:Label ID="lbl_ApprovalDetails" runat="server" Font-Bold="True" Text="Approval Details:-" />
                        </li>
                        <!--Status -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_Status" runat="server" Text="Status :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_Status" runat="server" Enabled="False"></asp:TextBox>
                        </li>
                        <!-- Approved By -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_Approvedby" runat="server" Text="Approved By :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_ApprovedBy" runat="server" Enabled="False"></asp:TextBox>
                        </li>
                        <!-- Reason -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_Remarks" runat="server" Text="Remarks :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_Remarks" runat="server" Enabled="False"></asp:TextBox>
                        </li>
						<li class="FormLabel"></li>
						<!--Action Button-->
						<li class="FormButton_Top">
							<div id="Buttom">
								<asp:Button runat="server" ID="Button3" CausesValidation="false" Text=" View "  onclick="btn_ViewApplication_Click"  />
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
							<asp:Button runat="server" ID="btn_AddApplication" Text="Add Application" 
                                CausesValidation="false" onclick="btn_AddApplication_Click" />
						</li>
						<li>
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search AttendanceAmmendment(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
							 <asp:GridView ID="gridview_AttendanceAmmendmentApply" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None" CellPadding="4" GridLines="None" Height="45px" PageSize="7"  Width="100%" OnRowCommand="gridview_AttendanceAmmendmentApply_RowCommand" OnRowEditing="gridview_AttendanceAmmendmentApply_RowEditing" OnRowDeleting="gridview_AttendanceAmmendmentApply_RowDeleting" OnPageIndexChanging="gridview_AttendanceAmmendmentApply_PageIndexChanging" OnRowDataBound="gridview_AttendanceAmmendmentApply_RowDataBound">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Date" ItemStyle-CssClass="lnkEdit" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("AttendanceAmendmentID") %>'
                                                OnClick="lnkEdit_Click" Text='<%# Eval("DateOfAttendance","{0:dd-MMM-yyyy}")  %>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"  />
                                    </asp:TemplateField>--%>
                                    <asp:BoundField ShowHeader="false" DataField="AttendanceAmendmentID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_AttendanceAmendmentID" Visible="true" />
											<asp:Label runat="server" ID="lbl_AttendanceAmendmentID" Text='<%# Eval("AttendanceAmendmentID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
                                    <asp:BoundField DataField="DateOfAttendance" HeaderText="NewTime"  DataFormatString="{0:dd-MMM-yyyy}"/>
                                    <asp:BoundField DataField="AttendanceType" HeaderText="Type" />
                                    <asp:BoundField DataField="OldTime" HeaderText="OldTime" DataFormatString="{0:h:mm tt}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NewTime" HeaderText="NewTime"  DataFormatString="{0:h:mm tt}"/>
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
                                </Columns>
                            </asp:GridView>
						</li>
						<li class="FormSpacer" />
					</ul>
				</asp:View>
			</asp:MultiView>
			<IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
				<itemtemplate>
					<ul>
						<li>
							<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
						</li>
					</ul>
				</itemtemplate>
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
