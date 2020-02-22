<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.Employees" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="../../App_UserControls/UC_MultiColumnDropdownList.ascx" TagName="MultiColumnCombo" TagPrefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
		<ul>
			<li style="display: block; float: left; width: 30%;">
				<asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Employee Details :-" />
			</li>
			<li><span class="notBold">
				<asp:RadioButtonList runat="server" ID="radio_Profile" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="radio_Profile_SelectedIndexChanged">
					<asp:ListItem Text="Employee Master &nbsp;&nbsp;&nbsp;" Value="0" Selected="True"></asp:ListItem>
					<asp:ListItem Text="Employee Profile" Value="1"></asp:ListItem>
				</asp:RadioButtonList></li>
			</span>
		</ul>
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_EmployeeDetails">
		<ContentTemplate>
			<div>
				<asp:MultiView runat="server" ID="multiView_EmployeeDetails" ActiveViewIndex="0">
					<asp:View ID="view_InputControls" runat="server">
						<div id="Mode">
							<asp:Label runat="server" ID="lbl_DataOperationMode" />
						</div>
						<ul id="EmployeeDetails">
							<li class="FormButton_Top">
								<div id="Top">
									<asp:Button runat="server" ID="btn_ViewEmployeeDetails" CausesValidation="false" Text=" View " OnClick="btn_ViewEmployeeDetails_OnClick" />
									<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="Btn_Save_Click" />
									<asp:Button ID="btn_Reset" runat="server" CausesValidation="false" Text="Reset" OnClick="btn_Reset_Click"></asp:Button>
								</div>
							</li>
							<li class="FullWidth">
								<ul>
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="Label14" Text="Office Details :" />
									</li>
									<!--EmpCode-->
									<li class="FormLabel" style="display: none;">
										<asp:Label runat="server" ID="lbl_EmpCode" Text="Emp Code :" />
									</li>
									<li class="FormValue" style="display: none;">
										<asp:TextBox runat="server" ID="txt_EmpCode" Enabled="false" />
									</li>
									<!--Salutation EmployeeName"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Salutation" Text="Name:" />
										<asp:Label runat="server" ID="Label7" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Salutation" Width="50px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Salutation_SelectedIndexChanged" />
									    <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Salutation" ControlToValidate="ddl_Salutation" Display="Dynamic" SetFocusOnError="true" />
										<asp:TextBox runat="server" ID="txt_EmployeeName" Width="75%" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EmployeeName" ControlToValidate="txt_EmployeeName" Display="Dynamic" SetFocusOnError="true" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_EmployeeName" ControlToValidate="txt_EmployeeName" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Designation-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Designation" Text="Designation:" />
										<asp:Label runat="server" ID="Label22" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Designation" Width="95%" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Designation" ControlToValidate="ddl_Designation" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
									</li>
									<!--Department-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Department" Text="Department:" />
										<asp:Label runat="server" ID="Label23" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Department" Width="95%" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Department" ControlToValidate="ddl_Department" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
									</li>
									<!--Office-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Office" Text="Reporting Office:" />
										<asp:Label runat="server" ID="Label24" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Office" Width="95%" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Office" ControlToValidate="ddl_Office" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
									</li>
									<!--Reporting To-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_ReportingTo" Text="Reporting To Emp:" />
										<asp:Label runat="server" ID="Label25" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_ReportingTo" Width="95%" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ReportingTo" ControlToValidate="ddl_ReportingTo" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
									</li>
									<!--Bio DeviceEmpid-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_BioEmpid" Text="Bio-Dev.Id:" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_BioDeviceEmpid" Width="95%" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_BioDeviceEmpid" ControlToValidate="txt_BioDeviceEmpid" Display="Dynamic" />
									</li>
								</ul>
								<ul>
									<!-- Miscellaneous Details PageSubTitle -->
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="Label6" Text="Joining Details :" />
									</li>
									<!--Service Type-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_ServiceType" Text="Service Type:" />
										<asp:Label runat="server" ID="Label26" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_ServiceType" AutoPostBack="true" />
										<asp:RequiredFieldValidator ID="requiredFieldValidator_ServiceType" runat="server" ControlToValidate="ddl_ServiceType" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--JoinDate-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_JoinDate" Text="Join Date :" />
										<asp:Label runat="server" ID="Label21" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_JoinDate" AutoPostBack="true" OnTextChanged="txt_JoinDate_TextChanged" CssClass="JoinDate" />
										<ajax:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_JoinDate" CssClass="MicroCalendar" TargetControlID="txt_JoinDate" OnClientDateSelectionChanged="CheckLeaveDateRange" />
										<asp:ImageButton runat="server" ID="imgButton_JoinDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_JoinDate" ControlToValidate="txt_JoinDate" Display="Dynamic" SetFocusOnError="true" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_JoinDate" ControlToValidate="txt_JoinDate" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Ref. Letter No-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_RefLetterNo" Text="Ref.Letter No:" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_RefLetterNo" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_RefLetterNo" ControlToValidate="txt_RefLetterNo" Display="Dynamic" />
									</li>
									<!--Status-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Status" Text="Status :" />
										<asp:Label runat="server" ID="Label27" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Status" AutoPostBack="true" />
										<asp:RequiredFieldValidator ID="requiredFieldValidator_Status" runat="server" ControlToValidate="ddl_Status" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Notice If Any-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Notice" Text="Notice If Any :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_Notice" Width="95%" />
									</li>
								</ul>
							</li>
							<li class="FullWidth">
								<ul>
									<!--PageSubTitle"-->
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="Label1" Text="Present Address for Communication :" />
									</li>
									<!--Present Address"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PresentAddress" Text="Address :" />
										<asp:Label runat="server" ID="Label13" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PresentAddress" TextMode="MultiLine" Rows="1" Width="95%" />
										<asp:RequiredFieldValidator ID="requiredFieldValidator_PresentAddress" runat="server" ControlToValidate="txt_PresentAddress" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Present LandMark"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PresentLandMark" Text="LandMark :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PresentLandMark" Width="95%" />
									</li>
									<!--Present PinCode"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PresentPinCode" Text="Pin Code :" />
										<%--<asp:Label runat="server" ID="Label14" Text="*" CssClass="ValidationColor" />--%>
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PresentPincode" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Present_Pincode" ControlToValidate="txt_PresentPincode" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Present District"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PresentDistrict" Text="District :" />
										<asp:Label runat="server" ID="Label15" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_PresentDistrict" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="ddl_PresentDistrict_SelectedIndexChanged" />
										<!--OnSelectedIndexChanged="ddl_PresentDistrict_SelectedIndexChanged""-->
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Present_District" ControlToValidate="ddl_PresentDistrict" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Present State"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PresentState" Text="State :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PresentState" ReadOnly="True" Width="95%" />
									</li>
									<!-- Present Country -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PresentCountry" Text="Country :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PresentCountry" ReadOnly="True" Width="95%" />
									</li>
								</ul>
								<ul>
									<!-- Permanent Address PageSubTitle -->
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="Label2" Text="Permanent Address:" />
										<span class="notBold">
											<asp:CheckBox runat="server" ID="chk_CopyPresentAddress" Text=" Same as Present Address" AutoPostBack="true" OnCheckedChanged="chk_CopyPresentAddress_CheckedChanged" /><!-- OnCheckedChanged="chk_CopyPresentAddress_CheckedChanged" -->
										</span></li>
									<!-- Permanent Address -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PermanentAddress" Text=" Address:" />
										<asp:Label runat="server" ID="Label16" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PermanentAddress" TextMode="MultiLine" Rows="1" Width="95%" />
										<asp:RequiredFieldValidator ID="RequiredFieldValidator_PermanentAddress" runat="server" ControlToValidate="txt_PermanentAddress" SetFocusOnError="True" Display="Dynamic"  />
									</li>
									<!-- Permanent LandMark -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PermanentLandMark" Text="LandMark :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PermanentLandMark" Width="95%" />
									</li>
									<!-- Permanent PinCode -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PermanentPinCode" Text="Pin Code :" />
										<%--<asp:Label runat="server" ID="Label17" Text="*" CssClass="ValidationColor" />--%>
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PermanentPincode" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Permanent_Pincode" ControlToValidate="txt_PermanentPincode" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!-- Permanent District -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PermanentDistrict" Text="District :" />
										<asp:Label runat="server" ID="Label18" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_PermanentDistrict" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="ddl_PermanentDistrict_SelectedIndexChanged" />
										<!-- OnSelectedIndexChanged="ddl_PermanentDistrict_SelectedIndexChanged" -->
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Permanent_District" ControlToValidate="ddl_PermanentDistrict" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!-- Permanent State -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PermanentState" Text="State:" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PermanentState" ReadOnly="True" Width="95%" />
										<%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Permanent_State" ControlToValidate="txt_PermanentState" Display="Dynamic"  SetFocusOnError="true" />--%>
									</li>
									<!-- Permanent Country -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PermanentCountry" Text="Country :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PermanentCountry" ReadOnly="True" Width="95%" />
									</li>
								</ul>
							</li>
							<li class="FullWidth">
								<ul>
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="Label5" Text="Personal Details :" />
									</li>
									<!--Gender"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Gender" Text="Gender :" />
										<%--<asp:Label runat="server" ID="Label9" Text="*" CssClass="ValidationColor" />--%>
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Gender" AutoPostBack="True" OnSelectedIndexChanged="ddl_Gender_SelectedIndexChanged" />
										 <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Gender" ControlToValidate="ddl_Gender" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--MaritalStatus"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_MaritalStatus" Text="Marital Status:" />
										<asp:Label runat="server" ID="Label10" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_MaritalStatus" AutoPostBack="True" OnSelectedIndexChanged="ddl_MaritalStatus_SelectedIndexChanged"/>
										<!--OnSelectedIndexChanged="ddl_MaritalStatus_SelectedIndexChanged"-->
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_MaritalStatus" ControlToValidate="ddl_MaritalStatus" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Father's Name"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_FathersName" Text="Father's Name :" />
										<asp:Label runat="server" ID="lbl_FatherNameValidation" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_FathersName" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_FatherName" ControlToValidate="txt_FathersName" Display="Dynamic" SetFocusOnError="true" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_FatherName" ControlToValidate="txt_FathersName" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Spouse Name"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lblSpouceName" Text="Spouse:" />
                                        <%--<asp:Label runat="server" ID="lbl_HusbandValidation" Text="*" ForeColor="Red" />--%>
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_SpouceName" ReadOnly="true" />
										<%--<asp:RequiredFieldValidator ID="requiredFieldValidator_SpouceName" runat="server" ControlToValidate="txt_SpouceName" Display="Dynamic" SetFocusOnError="true"  />--%>
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_SpouceName" ControlToValidate="txt_SpouceName" Display="Dynamic" Enabled="false" SetFocusOnError="true" />
									</li>
									<!--Date Of Birth"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lblDateOfBirth" Text="Date Of Birth /Age :" />
										<asp:Label runat="server" ID="Label11" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_DOB" Width="137px" OnTextChanged="txt_DOB_TextChanged" AutoPostBack="true"  />
										<asp:ImageButton runat="server" ID="imgButton_DateOfBirth" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
										<ajax:CalendarExtender ID="ajaxCalender_DOB" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_DateOfBirth" CssClass="MicroCalendar" TargetControlID="txt_DOB" OnClientDateSelectionChanged="CheckLeaveDateRange" />
										<asp:RequiredFieldValidator ID="requiredFieldValidator_DOB" runat="server" ControlToValidate="txt_DOB" Display="Dynamic" SetFocusOnError="true" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DOB" ControlToValidate="txt_DOB" Display="Dynamic" SetFocusOnError="true" />
										<%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Age" ControlToValidate="txt_Age"  Display="Dynamic"  SetFocusOnError="true" />--%>
										<asp:TextBox runat="server" ID="txt_Age" CssClass="TextSmallWidth" AutoPostBack="true" OnTextChanged="txt_Age_OnTextChanged" Enabled="false" /><!--OnTextChanged="txt_Age_TextChanged"-->
									</li>
									<!--Nationality"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Nationality" Text="Nationality :" />
										<asp:Label runat="server" ID="Label12" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Nationality" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Nationality" ControlToValidate="ddl_Nationality" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
									</li>
									<!--Religion"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Religion" Text="Religion :" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Religion" />
										<%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Religion" ControlToValidate="ddl_Religion" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />--%>
									</li>
									<!--Blood Group"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Bloodgroup" Text="Blood Group :" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_BloodGroup" />
										<%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_BloodGroup" ControlToValidate="ddl_BloodGroup" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />--%>
									</li>
									<!--Known Ailment"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_KnownAilment" Text="Known Ailment :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_KnownAilment" />
									</li>
								</ul>
								<ul>
									<!-- Contact Details PageSubTitle -->
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="lbl_ContactDetailsubHeading" Text="Contact Details :" />
									</li>
									<!-- Phone -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Phone" Text="Phone :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PhoneNumber" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PhoneNumber" ControlToValidate="txt_PhoneNumber" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Mobile -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Mobile" Text="Mobile :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_Mobile" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_MobileNumber" ControlToValidate="txt_Mobile" Display="Dynamic" SetFocusOnError="true" />
										<asp:RangeValidator ID="rangeValidator_Mobile" runat="server" ControlToValidate="txt_Mobile" Display="Dynamic" SetFocusOnError="true" Type="Double" />
									</li>
									<!--Emergency Nummber -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_EmergenceNumber" Text="Emergency No. :" />
										<asp:Label runat="server" ID="Label9" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_EmergencyNo" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EmergenceNumber" ControlToValidate="txt_EmergencyNo" Display="Dynamic" SetFocusOnError="true" />
									    <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_EmergenceNumber" ControlToValidate="txt_EmergencyNo" Display="Dynamic" SetFocusOnError="true" />
                                    </li>
									<!-- Personal Email ID -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PersonalEmailID" Text="Personal Email:" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PersonalEmailID" /><!--OnTextChanged="txt_EmailID_TextChanged"-->
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonalEmailID" ControlToValidate="txt_PersonalEmailID" Display="Dynamic" />
									</li>
									<!-- Official Email ID -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_OfficialEmailID" Text="Official Email:" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_OfficialEmailID" /><!--OnTextChanged="txt_OfficialEmailID_TextChanged"-->
									</li>
									<!--ReferencedBy Name -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_ReferenceName" Text="Reference Name:" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_ReferenceName" />
									</li>
									<!--Referenced PhoneNo -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_ReferencePhone" Text="Reference Phone No.:" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_ReferencePhone" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_ReferencePhone" ControlToValidate="txt_ReferencePhone" Display="Dynamic" />
									</li>
									<!--Referenced MobileNo -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_ReferenceMobile" Text="Reference Mobile No.:" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_ReferenceMobile" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_ReferenceMobile" ControlToValidate="txt_ReferenceMobile" Display="Dynamic" />
										<asp:RangeValidator ID="rangeValidator_ReferenceMobile" runat="server" ControlToValidate="txt_ReferenceMobile" Display="Dynamic" SetFocusOnError="true" Type="Double" />
									</li>
									<!--Identification Mark"-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_IdentificationMark" Text="Identification Mark :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_IdentificationMark" />
									</li>
								</ul>
							</li>
							<li class="FullWidth">
								<ul>
									<!-- Education Details PageSubTitle -->
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="Label3" Text="Educational Qualification :" />
									</li>
									<!-- Qualification -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Qualification" Text="Qualification :" />
										<asp:Label runat="server" ID="Label19" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_Qualification" AutoPostBack="True" OnSelectedIndexChanged="ddl_Qualification_SelectedIndexChanged" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Qualification" ControlToValidate="ddl_Qualification" Display="Dynamic" SetFocusOnError="true" />
									</li>
									<!--Passing Year -->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_PassingYear" Text="Passing Year :" />
										<%--<asp:Label runat="server" ID="Label20" Text="*" CssClass="ValidationColor" />--%>
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_PassingYear" />
										<%--<asp:RangeValidator ID="rangeValidator_PassingYear" runat="server" ControlToValidate="txt_PassingYear" Display="Dynamic" SetFocusOnError="true" Type="Integer" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_PassingYear" ControlToValidate="txt_PassingYear" Display="Dynamic" SetFocusOnError="true" />--%>
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PassingYear" ControlToValidate="txt_PassingYear" Display="Dynamic" />
									</li>
									<%-- ontextchanged="txt_PassingYear_TextChanged"--%>
									<!--Institution-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Institution" Text="Institution :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_Institution" />
									</li>
									<!--Board Or University-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Board" Text="Board Or University :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_Board" />
									</li>
								</ul>
								<ul>
									<!-- Professional Qualification Details PageSubTitle -->
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="Label4" Text="Professional Qualification :" />
									</li>
									<!--Certificate-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_Certificate" Text="Certificate :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_Certificate" />
									</li>
									<!--Institution-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_ProfessionalInstitution" Text="Institution :" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_ProfessionalInstitution" />
									</li>
								</ul>
							</li>
							<!--Action Button-->
							<li class="FormButton_Top">
								<div id="Buttom">
									<asp:Button runat="server" ID="Button3" CausesValidation="false" Text=" View " OnClick="btn_ViewEmployeeDetails_OnClick" /><%--OnClick="btn_ViewDCCollector_Click" --%>
									<asp:Button runat="server" ID="Btn_Save" Text="Save" OnClick="Btn_Save_Click"  />
									<asp:Button runat="server" ID="btn_Cancel" Text="Reset" CausesValidation="false"  OnClick="btn_Reset_Click" /><%--OnClick="btn_Cancel_Click"--%>
								</div>
							</li>
							<li class="FormMessage">
								<asp:Literal runat="server" ID="lit_Message" Text="." />
							</li>
							<li class="FormSpacer" />
						</ul>
					</asp:View>
					<!--Employee Profile -->
					<asp:View ID="view_Profile" runat="server">
						<ul>
							<!--To View,Save& Reset Button-->
							<li class="FormButton_Top">
								<asp:Button runat="server" ID="btn_EmpProfileView" CausesValidation="false" Text="View" OnClick="btn_EmpProfileView_Click" />
								<asp:Button runat="server" ID="btn_EmpProfileSave" Text="Save" OnClick="btn_EmpProfileSave_Click" />
								<asp:Button ID="btn_EmpProfileReset" runat="server" CausesValidation="false" Text="Reset" OnClick="btn_EmpProfileReset_Click" />
							</li>
							<li class="PageSubTitle">
								<asp:Label ID="lbl_EmpProfileSubHead" runat="server" Text="Employee Profile Details :" />
							</li>
							<!--Employee Name-->
							<li class="FormLabel">
								<asp:Label ID="lbl_EmployeeCode" runat="server" Text="Employee Code" />
							</li>
							<li class="FormValue">
								<micro:MultiColumnCombo ID="ddl_EmployeeCode" runat="server" />
								<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EmployeeCode" ControlToValidate="ddl_EmployeeCode" Display="Dynamic" SetFocusOnError="true" />
							</li>
							<!--Employee Profile Type-->
							<li class="FormLabel">
								<asp:Label ID="lbl_Profile" runat="server" Text="Profile:" />
							</li>
							<li class="FormValue">
								<asp:DropDownList ID="ddl_Profile" runat="server" />
								<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Profile" ControlToValidate="ddl_Profile" Display="Dynamic" SetFocusOnError="true" />
							</li>
							<!--Reference-->
							<li class="FormLabel">
								<asp:Label ID="lbl_Reference" runat="server" Text="Reference:" />
							</li>
							<li class="FormValue">
								<asp:TextBox ID="txt_Reference" runat="server" />
							</li>
							<!--File Upload Control-->
							<li class="FormLabel">
								<asp:Label ID="lbl_browseProfileImage" runat="server" Text="Browse Image:" />
							</li>
							<li class="FormValue">
								<asp:FileUpload ID="fileUpload_ProfileImage" runat="server" onchange="if (confirm('Upload ' + this.value + '?')) this.form.submit();" />
							</li>
							<!--Image-->
							<li class="FormLabel">
								<asp:Label ID="lbl_ProfileImage" runat="server" Text="Profile Image :" />
							</li>
							<li class="FormValue">
								<asp:Image runat="server" ID="img_ProfileImage" Width="150" Height="150" />
							</li>
							<li class="FormSpacer" />
							<li class="FormButton_Top">
							
								<asp:Button runat="server" ID="btn_EmpProfileBottomView" CausesValidation="false" Text="View" OnClick="btn_EmpProfileView_Click" />
								<asp:Button runat="server" ID="btn_EmpProfileBottomSave" Text="Save" OnClick="btn_EmpProfileSave_Click" />
								<asp:Button ID="btn_EmpProfileBottomReset" runat="server" CausesValidation="false" Text="Reset" OnClick="btn_EmpProfileReset_Click" />
								</li>
						</ul>
					</asp:View>
					<asp:View ID="view_GridView" runat="server">
						<ul class="GridView">
							<li class="FormButton_Top">
								<asp:Button runat="server" ID="btn_AddEmployee"  CausesValidation="false" Text="Add New Employee" UseSubmitBehavior="true" OnClick="btn_AddEmployee_Click"/><!--OnClick="btn_AddDCCollector_Clicked"-->
							</li>
							<li>
								<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Employee(s), where:" />
							</li>
							<li class="FormPageCounter">
								<asp:Literal runat="server" ID="lit_PageCounter" />
							</li>
							<li>
								<!--OnPageIndexChanging="gview_DcCollector_PageIndexChanging" OnRowCommand="gview_DcCollector_RowCommand" OnRowEditing="gview_DcCollector_RowEditing" OnRowDeleting="gview_DcCollector_RowDeleting" onrowdatabound="gview_DcCollector_RowDataBound"-->
								<asp:GridView runat="server" ID="gview_Employee" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="15" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2" OnRowCommand="gview_Employee_RowCommand" OnRowEditing="gview_Employee_RowEditing" OnRowDeleting="gview_Employee_RowDeleting" OnRowDataBound="gview_Employee_RowDataBound" OnPageIndexChanging="gview_Employee_PageIndexChanging">
									<HeaderStyle CssClass="HeaderStyle" />
									<Columns>
										<asp:TemplateField ItemStyle-CssClass="CheckBox">
											<ItemTemplate>
												<asp:CheckBox runat="server" ID="chk_EmployeeID" Visible="true" />
												<asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />
												<asp:Label runat="server" ID="lbl_ServiceDetailsID" Text='<%#Eval("EmployeeServiceDetailsID") %>' Visible="false" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:BoundField DataField="EmployeeCode" HeaderText="Code " ItemStyle-CssClass="EmployeeCode" />
										<asp:BoundField DataField="EmployeeName" HeaderText="Name " ItemStyle-CssClass="EmployeeName" />
										<asp:BoundField DataField="DesignationDescription" HeaderText="Designation " ItemStyle-CssClass="DesignationAndRole" />
										<asp:BoundField DataField="OfficeName" HeaderText="Office" ItemStyle-CssClass="OfficeName"  />
										<asp:BoundField DataField="DepartmentDescription" HeaderText="Department" ItemStyle-CssClass="Department" />
										<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
										<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
									    <asp:CommandField ShowSelectButton="true" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ItemStyle-CssClass="ViewLinkItem"  ControlStyle-CssClass="ViewLink"/>
                                    </Columns>
									<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
									<PagerStyle CssClass="MicroPagerStyle" />
								</asp:GridView>
							</li>
						</ul>
					</asp:View>
					<asp:View ID="view_GriviewProfile" runat="server">
						<ul class="GridView">
							<!-- Buttons @ Top -->
							<li class="FormButton_Top">
								<asp:Button runat="server" ID="btn_AddEmployeeProfile" CausesValidation="false" Text=" Add Employee Profile " UseSubmitBehavior="true" OnClick="btn_AddEmployeeProfile_Click" />
							</li>
							<!-- Sub Heading  Profiles -->
							<li class="PageSubTitle">
								<asp:Label runat="server" ID="lbl_GridView_ProfileInformation" Text="Employee Profile Details :" />
							</li>
							<!-- About selected Customer -->
							<li class="FormLabel">
								<asp:Label runat="server" ID="lbl_GridView_AboutSelectedProfile" Text="" />
							</li>
							<li class="FormValue">
								<asp:Label runat="server" ID="lbl_GridView_AboutEmployee" />
							</li>
							<!-- Selected Employee's Profile GridView -->
							<li>
								<asp:GridView runat="server" ID="gview_EmployeeProfiles" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%" OnRowCommand="gview_EmployeeProfiles_RowCommand" OnRowEditing="gview_EmployeeProfiles_RowEditing" OnRowDeleting="gview_EmployeeProfiles_RowDeleting" OnPageIndexChanging="gview_EmployeeProfiles_PageIndexChanging" OnRowDataBound="gview_EmployeeProfiles_RowDataBound">
									<PagerStyle CssClass="PagerStyle" VerticalAlign="Middle" HorizontalAlign="Center" />
									<HeaderStyle CssClass="HeaderStyle" />
									<Columns>
										<asp:BoundField ShowHeader="false" DataField="EmployeeProfileID" Visible="false" />
										<asp:TemplateField>
											<ItemTemplate>
												<asp:Label runat="server" ID="lbl_EmployeeProfileID" Text='<%# Eval("EmployeeProfilleID") %>' Visible="false" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:ImageField DataImageUrlField="ImageUrl" ControlStyle-Height="150" ControlStyle-Width="150" />
										<asp:BoundField DataField="EmployeeName" HeaderText=" Name " />
										<asp:BoundField DataField="EmployeeCode" HeaderText=" Code " />
										<asp:BoundField DataField="CommonKeyValue" HeaderText=" Profile " />
										<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ControlStyle-CssClass="EditLink" />
										<asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ControlStyle-CssClass="DeleteLink" />
									</Columns>
								</asp:GridView>
							</li>
							<li class="FormSpacer" />
						</ul>
					</asp:View>
				</asp:MultiView>
			</div>
			<!--Employee Profile Multiview-->
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
