<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AttendanceApplies.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.AttendanceApplies" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Attandance Application Form:-" />
    </h1>
    <asp:UpdatePanel runat="server" ID="updatePanel_AttandenceApplication">
       <ContentTemplate>
			<asp:MultiView runat="server" ID="multiView_AttandenceApplicationDetails">
				<asp:View ID="view_InputControls" runat="server">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="AttandenceApplicationDetails">
						<li class="FormButton_Top">
							<div id="Top">
								<asp:Button runat="server" ID="btn_ViewApplication" CausesValidation="false" 
                                    Text=" View " onclick="btn_ViewApplication_Click"  />
								<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="Btn_Save_Click" />
								<asp:Button ID="btn_Cancel_Top" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
							</div>
						</li>
						<li class="PageSubTitle">
							<asp:Label runat="server" ID="lbl_Head_AttandanceApplicationDetails" Text="Attandence Application Details :-" />
						</li>
                        <!-- From Date -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_FromDate" runat="server" Text="AttendanceDate :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_AttendanceDate" runat="server" Enabled="False"></asp:TextBox>
                            <ajax:CalendarExtender ID="CalendarExtenderFromDate" runat="server" CssClass="MicroCalendar"
                                Format="dd-MMM-yyyy" PopupButtonID="imgButton_AttendanceDate" TargetControlID="txt_AttendanceDate" />
                            <asp:ImageButton ID="imgButton_AttendanceDate" runat="server" CausesValidation="false"
                                Height="21" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                ToolTip="Show Calender" Width="21" />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_AttendanceDate" runat="server"
                                ControlToValidate="txt_AttendanceDate" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator ID="regularExpressionValidator_AttendanceDate" runat="server"
                                ControlToValidate="txt_AttendanceDate" Display="Dynamic" SetFocusOnError="true" />
                            <asp:Button ID="btn_GetAttandance" runat="server" Text="GetAttendance"  CausesValidation ="false"  OnClick="btn_GetAttandance_Click" />
                        </li>
                        <!--InTime -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_InTime" runat="server" Text="InTime :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_InTime" runat="server" Columns="7" />
                            <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                AcceptAMPM="true" ErrorTooltipEnabled="true" Mask="99:99" MaskType="Time"
                                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                TargetControlID="txt_InTime">
                            </ajax:MaskedEditExtender>
                            	<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_InTime" ControlToValidate="txt_InTime" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_InTime" ControlToValidate="txt_InTime" Display="Dynamic" SetFocusOnError="true" />
                      
                        </li>
                        <!-- OutTime -->
                        <li class="FormLabel">
                            <asp:Label ID="lbl_OutTime" runat="server" Text="Out Time :"></asp:Label>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_OutTime" runat="server" Columns="7" />
                            <ajax:MaskedEditExtender ID="BusinessHoursStartMaskedEditExtender" runat="server"
                                AcceptAMPM="true" ErrorTooltipEnabled="true" Mask="99:99" MaskType="Time"
                                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                TargetControlID="txt_OutTime">
                            </ajax:MaskedEditExtender>
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_OutTime" ControlToValidate="txt_OutTime" Display="Dynamic" SetFocusOnError="true" />
                             <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_OutTime" ControlToValidate="txt_OutTime" Display="Dynamic" SetFocusOnError="true" />

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
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Approval Details:-" />
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
                            <asp:Label ID="lbl_ApprovedBy" runat="server" Text="Approved By :"></asp:Label>
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
                                CausesValidation="false" onclick="btn_AddApplication_Click"  />
						</li>
						<li>
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search AttendanceApplication(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
                            <asp:GridView ID="gridview_AttendanceApply" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BorderStyle="None" CellPadding="4" GridLines="None" Height="45px" PageSize="7"
                                Width="100%" OnRowCommand="gridview_AttendanceApply_RowCommand" OnRowEditing="gridview_AttendanceApply_RowEditing" OnRowDeleting="gridview_AttendanceApply_RowDeleting" OnPageIndexChanging="gridview_AttendanceApply_PageIndexChanging" OnRowDataBound="gridview_AttendanceApply_RowDataBound">
                                <Columns>
                                 <asp:BoundField ShowHeader="false" DataField="AttendanceApplicationID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_AttendanceApplicationID" Visible="true" />
											<asp:Label runat="server" ID="lbl_AttendanceApplicationID" Text='<%# Eval("AttendanceApplicationID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
                                     <asp:BoundField DataField="DateOfAttendance" HeaderText="Date"  DataFormatString="{0:dd-MMM-yyyy}"/>
                                    <asp:BoundField DataField="InTime" HeaderText="InTime" DataFormatString="{0:h:mm tt}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OutTime" HeaderText="OutTime" DataFormatString="{0:h:mm tt}"/>
                                    <asp:BoundField DataField="ApplicationReason" HeaderText="Reason" />
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
            		
                
            <IAControl:DialogBox ID="dialog_Message" runat="server" BackgroundCssClass="modalBackground"
                CssClass="modalPopup" EnableViewState="true" Style="display: none" Title="">
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
    <%--<asp:UpdateProgress runat="server" ID="PageUpdateProgress">
		<ProgressTemplate>
			<div id="UpdateProgress">
				<div class="UpdateProgressArea" />
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>--%>
</asp:Content>
