<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AttendanceAmmendmentApproves.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.AttendanceAmmendmentApproves" %>

<%@ Register Src="../../App_UserControls/UC_MultiColumnDropdownList.ascx" TagName="MultiColumnCombo" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Attendance Ammendment Approval:-" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_AttendanceAmmendmentApproval">
		<ContentTemplate>
			<ul id="AttendanceApprovesGrid">
				<li class="FormLabelGridview">
					<asp:GridView runat="server" ID="gridview_AttendanceAmmendmentApproves" 
                        AutoGenerateColumns="False" BorderStyle="None" Width="100%" CellPadding="2" 
                        GridLines="None" Height="45px" AllowPaging="True" PageSize="7" 
                        onpageindexchanging="gridview_AttendanceAmmendmentApproves_PageIndexChanging">
						<Columns>
							<asp:TemplateField HeaderText="Date">
								<ItemTemplate>
									<asp:LinkButton ID="lnkEdit" runat="server" Text='<%# Eval("DateOfAttendance","{0:dd-MMM-yyyy}") %>' CommandArgument='<%# Eval("AttendanceAmendmentID") %>' OnClick="lnkEdit_Click" CausesValidation ="false" />
								</ItemTemplate>
								<HeaderStyle HorizontalAlign="Center" />
							</asp:TemplateField>
							<asp:BoundField DataField="EmployeeName" HeaderText="Name">
								<HeaderStyle HorizontalAlign="Center" />
							</asp:BoundField>
							<%--<asp:BoundField DataField="DateOfAttendance" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />--%>
							<asp:BoundField DataField="OldTime" HeaderText="OldTime" DataFormatString="{0:h:mm tt}" />
							<asp:BoundField HeaderText="NewTime" DataField="NewTime" DataFormatString="{0:h:mm tt}" />
							<asp:BoundField HeaderText="Status" DataField="Status"></asp:BoundField>
							<asp:BoundField DataField="Reason" HeaderText="Application Reason">
								<HeaderStyle HorizontalAlign="Center" />
							</asp:BoundField>
						</Columns>
					</asp:GridView>
				</li>
                <li class="LeaveStatus">
			<asp:Literal runat="server" ID="lit_Message" Text="Total No. of Application(s) to approve:" />
		</li>
			</ul>
			<ul class="AttendanceAmmendmentApprovalGrid">
				<li class="FormHeader">
					<asp:Label runat="server" ID="lbl_AttendanceAmmendmentApproval" Text="Attendance Ammendment Approval :" Font-Bold="True" />
				</li>
                <!-- EmployeeName -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_EmpName" Text="Employee Name:"></asp:Label>
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_EmpName" Enabled="False"></asp:TextBox>
				</li>
                <!-- Emp Code -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_EmpCode" Text="Employee Code:"></asp:Label>
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_EmpCode" Enabled="False"></asp:TextBox>
				</li>
                <!-- Designation -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_Designation" Text="Designation:"></asp:Label>
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_Designation" Enabled="False"></asp:TextBox>
				</li>
                <!-- Status -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_Status" Text="Status"></asp:Label>
				</li>
				<li class="FormValue">
					<asp:DropDownList runat="server" ID="ddl_AttendanceApproval">
                   <%-- <asp:ListItem>Approved</asp:ListItem>
				    <asp:ListItem>Reject</asp:ListItem>--%>
					</asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_AttendanceApproval" runat="server" ControlToValidate="ddl_AttendanceApproval" Display="Dynamic" SetFocusOnError="true" />
				</li>
                <!--From Date -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_FromDate" Text="FromDate:"></asp:Label>
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_AttendanceDate" Enabled="False"></asp:TextBox>
				</li>
                <!-- Old Time -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_OldTime" Text="OldTime:"></asp:Label>
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_OldTime"></asp:TextBox>
				</li>
                <!-- New Time -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_NewTime" Text="NewTime:"></asp:Label>
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_NewTime"></asp:TextBox>
				</li>	
                <!--Reason -->
				<li class="FormLabel">
					<asp:Label runat="server" ID="lbl_Reason" Text="Enter your Reason:"></asp:Label>
				</li>
				<li class="FormValue">
					<asp:TextBox runat="server" ID="txt_Reason" TextMode="MultiLine" Rows="2"></asp:TextBox>
				</li>
				<li class="FormButton_Top">
					<asp:Button runat="server" ID="btn_Save" Text="Approve Attendance" CssClass="CommandButton" OnClick="btn_Save_Click" />
					<asp:Button runat="server" ID="btn_Cancel" Text=" Reset " CssClass="CommandButton" OnClick="btn_Cancel_Click" />
				</li>
			</ul>
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
				<div class="UpdateProgressArea" />
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
