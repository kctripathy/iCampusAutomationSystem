<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_DateWithAge.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.Common.UC_DateWithAge" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

    <ul>
        <li class="FormLabel">
			<asp:Label runat="server" ID="lbl_DateOfBirth" Text="Date of Birth " />
			<asp:Label runat="server" ID="lbl_DateOfBirthValidation" Text="*" ForeColor="Red" />
		</li>
        <li class="FormValue">
			<asp:TextBox runat="server" ID="txt_DateOfBirth" Width="111px" AutoPostBack="true" OnTextChanged="txt_DateOfBirth_TextChanged" />
			<asp:ImageButton runat="server" ID="imgButton_DateOfBirth" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
			<ajax:CalendarExtender runat="server" ID="ajaxCalender_DateOfBirth" Enabled="true" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="CheckLeaveDateRange" PopupButtonID="imgButton_DateOfBirth" CssClass="MicroCalendar" TargetControlID="txt_DateOfBirth" />
			<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DateOfBirth" ControlToValidate="txt_DateOfBirth" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Date of Birth or Age must be given" SetFocusOnError="true" />
			<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DateOfBirth" ControlToValidate="txt_DateOfBirth" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Date" />
			<asp:Label runat="server" ID="lbl_CustomerAge" Text=" or Age :" />
			<asp:TextBox runat="server" ID="txt_Age" Width="30px" AutoPostBack="true" OnTextChanged="txt_Age_TextChanged" />
			<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Age" ControlToValidate="txt_Age" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Age" SetFocusOnError="true" />
			<asp:RangeValidator runat="server" ID="rangeValidator_Age" ControlToValidate="txt_Age" Display="Dynamic" SetFocusOnError="true" Type="Integer" />
        </li>
    </ul>