<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveApplications.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.LeaveApplications" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_MultiColumnDropdownList.ascx" TagName="MultiColumnCombo" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Leave Application Form:-" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_LeaveApplication">
		<ContentTemplate>
        <ul id="LeaveApplications">
			        <div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
                       
                    <li class="FullWidth">
							<ul>
                                <li class="PageSubTitle">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True"  Text="Leave Application Form:-" />
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_LeaveDescription" runat="server" Text="Type of Leave:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:DropDownList ID="ddl_LeaveDescription" runat="server" CssClass="leaveDescriptionDropDownList" />
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_LeaveDescription"  runat="server" ControlToValidate="ddl_LeaveDescription" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_FromDate" runat="server" Text="Leave Start From Date:"></asp:Label>
                                </li>
                                <%--<head id="Head1" runat="server" />--%>
                                <li class="FormValueCalendar">
                                    <asp:TextBox ID="txt_FromDate" runat="server" CssClass="TextBoxClass" />
                                    <ajax:CalendarExtender ID="CalendarExtenderFromDate" runat="server"  CssClass="MicroCalendar" Format="dd-MMM-yyyy"  OnClientDateSelectionChanged="CheckLeaveDateRangeForLeave"   PopupButtonID="imgButton_Fromdate" TargetControlID="txt_FromDate" />
                                    <asp:ImageButton ID="imgButton_Fromdate" runat="server"  CausesValidation="false" Height="21" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" ToolTip="Show Calender"  Width="21" />
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_FromDate" runat="server" ControlToValidate="txt_FromDate" Display="Dynamic" SetFocusOnError="true" />
                                    <asp:RegularExpressionValidator ID="regularExpressionValidator_FromDate" runat="server" ControlToValidate="txt_FromDate" Display="Dynamic" SetFocusOnError="true" />
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_ToDate" runat="server" Text="Leave Finish On Date:"></asp:Label>
                                </li>
                                <li class="FormValueCalendar">
                                    <asp:TextBox ID="txt_Todate" runat="server" AutoPostBack="true"  OnTextChanged="txt_Todate_TextChanged"></asp:TextBox>
                                    <ajax:CalendarExtender ID="CalendarExtenderToDate" runat="server" CssClass="MicroCalendar" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="CheckLeaveDateRangeForLeave"  PopupButtonID="imgButton_Todate" TargetControlID="txt_Todate" />
                                    <asp:ImageButton ID="imgButton_Todate" runat="server" CausesValidation="false"  Height="21" ImageAlign="AbsMiddle"  ImageUrl="~/Themes/Default/Images/Calander 01.gif" ToolTip="Show Calender" Width="21" />
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_Todate" runat="server" 
                                        ControlToValidate="txt_Todate" Display="Dynamic" SetFocusOnError="true" />
                                    <asp:RegularExpressionValidator ID="regularExpressionValidator_Todate"  runat="server" ControlToValidate="txt_Todate" Display="Dynamic"  SetFocusOnError="true" />
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_Count" runat="server" Text="Total day(s) of Leave:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_Count" runat="server" CssClass="CountTextBox" Enabled="False" Width="40"></asp:TextBox>
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_Reason" runat="server" Text="Reason of Leave:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_Reason" runat="server" CssClass="ReasonTextBox" Rows="3" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                </li>
                          </ul>
                            <ul>
                                <li class="PageSubTitle">
                                    <asp:Label ID="Label1" runat="server" Text="Leave Balance List:" />
                                </li>
                                <li class="FormLabelGridview">
                                    <asp:GridView ID="gridview_LeaveApplyBalance" runat="server" AllowPaging="True"  AutoGenerateColumns="False" BorderStyle="None" CellPadding="4" GridLines="None" Height="45px" OnPageIndexChanging="gridview_LeaveApplyBalance_PageIndexChanging" PageSize="7" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="LeaveTypeDescription" HeaderText="Leave Type"><HeaderStyle HorizontalAlign="Center" /> </asp:BoundField>
                                            <asp:BoundField DataField="TotalNumberOfLeavesElligibleToAvail" HeaderText="Balance of Leaves"> <HeaderStyle HorizontalAlign="Center" /></asp:BoundField>
                                            <asp:BoundField DataField="NumberOfConsecutiveDaysAllowed" HeaderText="Consecutive Allowed" />
                                        </Columns>
                                    </asp:GridView>
                                </li>
                                <li class="PageSubTitle">Email Details:</li>
                                <li class="FormLabel">Your Email ID:</li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_From" runat="server" BorderWidth="0"   CssClass="TextBoxClass" Enabled="False" ReadOnly="true"></asp:TextBox>
                                </li>
                                <li class="FormLabel">Supervisor&#39;s eMail: </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_To" runat="server" BorderWidth="0" CssClass="TextBoxClass"  Enabled="false" ReadOnly="true"></asp:TextBox>
                                </li>
                            </ul>
                    </li>
                    <li class="FullWidth">
                            <ul>
                                <li class="PageSubTitle">
                                    <asp:Label ID="lbl_LeaveApproveDetails" runat="server" Font-Bold="True" 
                                        Text="Leave Approval Details:-" />
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_Status" runat="server" Text="Status Details :"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_Status" runat="server" CssClass="StatusTextBox"  Enabled="False"></asp:TextBox>
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_ApprovedBy" runat="server" Text="Approved By :"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_ApprovedBy" runat="server" CssClass="ApprovedByTextBox"  Enabled="False"></asp:TextBox>
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_Remarks" runat="server" Text="Remarks:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_RemarksDetails" runat="server" CssClass="RemarksDetailsTextBox" Enabled="False"></asp:TextBox>
                                </li>
                               
                            </ul>
                            <ul>
                                <li class="PageSubTitle">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                                        Text="Leave Balance Details:-" />
                                </li>
                                <li class="FormLabelGridview">
                                    <asp:GridView ID="gridview_LeaveApplyBalanceShow" runat="server"  AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None"  CellPadding="4" GridLines="None" Height="45px" OnPageIndexChanging="gridview_LeaveApplyBalanceShow_PageIndexChanging"  PageSize="4" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Leave Description" ItemStyle-CssClass="lnkEdit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false"  CommandArgument='<%# Eval("LeaveApplicationID") %>' OnClick="lnkEdit_Click" Text='<%# Eval("LeaveTypeDescription") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DateFrom" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From Date" ItemStyle-CssClass="DateFrom" />
                                                
                                            <asp:BoundField DataField="DateTo" DataFormatString="{0:dd/MM/yyyy}"  HeaderText="To Date" ItemStyle-CssClass="DateTo" />
                                               
                                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-CssClass="Status" />
                                            <asp:BoundField DataField="LeaveApplicationID" Visible="False" />
                                            <asp:TemplateField HeaderText="Cancel?" ItemStyle-CssClass="lnkCancel">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("LeaveApplicationID") %>' OnClick="lnkCancel_Click" OnClientClick="return " Text="Delete">
                                                            <img src="~/Themes/Default/Images/delete.gif" height="15px" width="15px" border="0" alt="Are u Sure to Delete" />    
							                        </asp:LinkButton>
                                                </ItemTemplate>
                                                     <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </li>
                            </ul>
                    </li>
                     <li class="FormButton_Top">
                                    <li class="FormButton_Top">
                                        <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" />
                                        <asp:Button ID="btn_LeaveCancel" runat="server" CausesValidation="false"  OnClick="btn_LeaveCancel_Click" Text="Cancel" />
                                    </li>
                                    <li class="AppMessages">
                                        <asp:Literal ID="lblStatus" runat="server" Text="." />
                                    </li>
                                </li>
         </ul>
         <p class="ErrorMessage">
					<asp:Literal runat="server" ID="lit_Message" Text="" />
				</p>
                        <IAControl:DialogBox ID="dialog_Message" runat="server" 
                            BackgroundCssClass="modalBackground" CssClass="modalPopup" 
                            EnableViewState="true" Style="display: none" Title="">
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
				<div class="UpdateProgressArea" />
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
