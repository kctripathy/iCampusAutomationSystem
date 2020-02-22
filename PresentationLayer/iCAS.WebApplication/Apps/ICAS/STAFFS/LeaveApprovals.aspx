<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveApprovals.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.LeaveApprovals" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="~/App_UserControls/UC_MultiColumnDropdownList.ascx" TagName="MultiColumnCombo" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
				<asp:Literal runat="server" ID="lit_PageTitle" Text="Leave Approval:-" />
			</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_LeaveApproval">
		<ContentTemplate>
			
			<ul id="EmployeeLeaveApprovalGrid">
		<li class="FormLabelGridview">
			<asp:GridView runat="server" ID="gridview_LeaveApproveBalanceShow" AutoGenerateColumns="False" BorderStyle="None" Width="100%" CellPadding="2" GridLines="None" Height="45px" AllowPaging="True" PageSize="7" OnPageIndexChanging="gridview_LeaveApproveBalanceShow_PageIndexChanging">
				<Columns>
					<asp:TemplateField HeaderText="Leave Description">
						<ItemTemplate>
							<asp:LinkButton ID="lnkEdit" runat="server" Text='<%# Eval("LeaveTypeDescription") %>' CommandArgument='<%# Eval("LeaveApplicationID") %>' OnClick="lnkEdit_Click" />
						</ItemTemplate>
						<HeaderStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:BoundField DataField="DateFrom" HeaderText="Date From" DataFormatString="{0:dd/MM/yyyy}" />
					<asp:BoundField HeaderText="Date To" DataField="DateTo" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
					<asp:BoundField HeaderText="Status" DataField="Status"></asp:BoundField>
					<asp:BoundField DataField="ApplicationReason" HeaderText="Application Reason">
						<HeaderStyle HorizontalAlign="Center" />
					</asp:BoundField>
					<asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code">
						<HeaderStyle HorizontalAlign="Center" />
					</asp:BoundField>
					<asp:BoundField DataField="EmployeeName" HeaderText="Employee Name">
						<HeaderStyle HorizontalAlign="Center" />
					</asp:BoundField>
					<asp:BoundField DataField="LeaveApplicationID" Visible="False" />
				</Columns>
			</asp:GridView>
		</li>
		<li class="LeaveStatus">
			<asp:Literal runat="server" ID="lit_Message" Text="Total No. of Leaves(s) to approve:" />
		</li>
	</ul>
	<ul class="EmployeeLeaveApprovalGrid">
		<li class="FormHeader">
			<asp:Label runat="server" ID="lbl_LeaveShowHistoyrDetails" Text="Leave Details of the Employee:" Font-Bold="True" />
		</li>
		<li class="FormLabel">
			<asp:Label runat="server" ID="lbl_FromDate" Text="From Date:"></asp:Label>
		</li>
		<li class="FormValue">
			<asp:TextBox runat="server" ID="txt_FromDate" CssClass="FromDateTextBox" Enabled="False"></asp:TextBox>
		</li>
		<li class="FormLabel">
			<asp:Label runat="server" ID="lbl_ToDate" Text="To Date:"></asp:Label>
		</li>
		<li class="FormValue">
			<asp:TextBox runat="server" ID="txt_ToDate" CssClass="ToDateTextBox" Enabled="False"></asp:TextBox>
		</li>
		<li class="FormLabel">
			<asp:Label runat="server" ID="lbl_LeaveDescription" Text="Description:"></asp:Label>
		</li>
		<li class="FormValue">
			<asp:TextBox runat="server" ID="txt_LeaveDescription" CssClass="LeaveDescriptionTextBox" Enabled="False"></asp:TextBox>
		</li>
		<li class="FormLabel">
			<asp:Label runat="server" ID="lbl_Reason" Text="Reason of Leave:"></asp:Label>
		</li>
		<li class="FormValue">
			<asp:TextBox runat="server" ID="txt_Reason" CssClass="ReasonTextBox" Enabled="False"></asp:TextBox>
		</li>
		<li class="FormLabel">
			<asp:Label runat="server" ID="lbl_Status" Text="Status"></asp:Label>
		</li>
		<li class="FormValue">
			<asp:DropDownList runat="server" ID="ddl_LeaveStatus" CssClass="StatusDropDownList">
				<asp:ListItem>Approved</asp:ListItem>
				<asp:ListItem>Reject</asp:ListItem>
			</asp:DropDownList>
		</li>
		<li class="FormLabel">
			<asp:Label runat="server" ID="lbl_Remarks" Text="Enter your Remarks:"></asp:Label>
		</li>
		<li class="FormValue">
			<asp:TextBox runat="server" ID="txt_Remarks" TextMode="MultiLine" Rows="2"></asp:TextBox>
		</li>
		<li class="FormButton_Top">
			<asp:Button runat="server" ID="btn_Save" Text="Approve/Reject Leave" CssClass="CommandButton" OnClick="btn_Save_Click" />
			&nbsp;
			<asp:Button runat="server" ID="btn_Cancel" Text=" Cancel " CssClass="CommandButton" OnClick="btn_Cancel_Click" />
		</li>

	</ul>
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
				<div class="UpdateProgressArea" />
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
