<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.UserProfile" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		User Profile:
	</h1>
	<ul>
		<li class="User">
			<asp:Literal ID="lit_UserType" runat="server" />
		</li>
	</ul>
	<div>
		<asp:UpdatePanel runat="server" ID="updatePanel_UserProfile">
			<ContentTemplate>
				<div>
					<asp:MultiView ID="multiView_UserProfile" runat="server" ActiveViewIndex="0">
						<asp:View ID="view_Employee" runat="server">
							<div id="Mode">
								<asp:Label runat="server" ID="lbl_DataOperationMode" />
							</div>
							<ul id="UserProfile">
                            <li class="FormSpacer"/>
								<!-- Update Employee Profile Button -->
								<li class="FormButton_Top">
									<div id="Top">
										<asp:Button runat="server" ID="btn_EmployeeUpdateTop" Text="Update Profile" OnClick="btn_EmployeeUpdate_Click" />
										<ajax:ConfirmButtonExtender ID="ajaxConfirmButtonExtender_EmployeeTop" runat="server" TargetControlID="btn_EmployeeUpdateTop" ConfirmText="Are You Sure to Update the Profile ?" />
									</div>
								</li>
								<li class="FullWidth">
									<ul>
										<li class="PageSubTitle">
											<asp:Label runat="server" ID="lbl_EmployeeSubHeading" Text="Personal Details" />
										</li>
										<!-- Employee Full Name -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeSalutation" runat="server" Text="Name:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeeName" ReadOnly="true" />
										</li>
										<!-- Employee Father's Full Name -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeFatherName" runat="server" Text="FatherName:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeeFatherName" TabIndex="1" ReadOnly="true" />
										</li>
										<!-- Employee Spouse Full Name  -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeSpouseName" runat="server" Text="Spouse Name:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeeSpouseName" TabIndex="2" ReadOnly="true" />
										</li>
										<!-- Employee Date Of Birth -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeDateOfBirth" runat="server" Text="Date Of Birth:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeeDateOfBirth" TabIndex="3" ReadOnly="true" />
										</li>
										<!-- Employee Gender -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeGender" runat="server" Text="Gender:" Width="20px" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_EmployeeGender" TabIndex="4" ReadOnly="true" />
										</li>
										<!-- Employee BloodGroup -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeBloodGroup" runat="server" Text="Blood Group:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_EmployeeBloodGroup" TabIndex="5" ReadOnly="true" />
										</li>
										<!-- Employee Religion -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeReligion" runat="server" Text="Religion:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_EmployeeReligion" TabIndex="6" ReadOnly="true" />
										</li>
										<!-- Employee Nationality -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeNationality" runat="server" Text="Nationality:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_EmployeeNationality" TabIndex="7" ReadOnly="true" />
										</li>
										<!--Employee Marital Status -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeMaritalStatus" runat="server" Text="Marital Status:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_EmployeeMaritalStatus" TabIndex="8" ReadOnly="true" />
										</li>
										<!-- Employee Known Aliments  -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeKnownAliments" runat="server" Text="Known Aliments:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeeKnownAliments" TabIndex="9" TextMode="MultiLine" ReadOnly="true" />
											<%--<asp:RegularExpressionValidator ID="regulalExpressionVlidator_EmployeeKnownAliments" runat="server" Display="Dynamic" ControlToValidate="txt_EmployeeKnownAliments" ValidationExpression="^[0-9a-zA-Z\s ]+$" SetFocusOnError="True" />--%>
										</li>
										<!-- Employee Identification -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeIdentificationMark" runat="server" Text="Identification Mark:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeeIdentificationMark" TabIndex="10" TextMode="MultiLine" ReadOnly="true" />
											<%--<asp:RegularExpressionValidator runat="server" ID="regulalExpressionVlidator_EmployeeIdentficationMark" ControlToValidate="txt_EmployeeIdentificationMark" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9a-zA-Z\s\. ]+$" />--%>
										</li>
									</ul>
									<ul>
										<!--Employee Office PageSubTitle-->
										<li class="PageSubTitle">
											<asp:Label ID="lbl_OfficeSubHead" runat="server" Text="Office Details" />
										</li>
										<!--Employee Designation-->
										<li class="FormLabel">
											<asp:Label ID="lbl_Designation" runat="server" Text="Designation:" />
										</li>
										<li class="FormValue">
											<asp:TextBox ID="txt_Designation" runat="server" ReadOnly="true" />
										</li>
										<!--Employee Department-->
										<li class="FormLabel">
											<asp:Label ID="lbl_Department" runat="server" Text="Department:" />
										</li>
										<li class="FormValue">
											<asp:TextBox ID="txt_Department" runat="server" ReadOnly="true" />
										</li>
										<!--Employee Reporting Office-->
										<li class="FormLabel">
											<asp:Label ID="lbl_ReportingOffice" runat="server" Text="Reporting Office:" />
										</li>
										<li class="FormValue">
											<asp:TextBox ID="txt_ReportingOffice" runat="server" ReadOnly="true" />
										</li>
										<!--Employee Reporting To Employee-->
										<li class="FormLabel">
											<asp:Label ID="lbl_ReportingEmployee" runat="server" Text="Reporting Employee:" />
										</li>
										<li class="FormValue">
											<asp:TextBox ID="txt_ReportingEmployee" runat="server" ReadOnly="true" />
										</li>
										<!--Employee Service Type-->
										<li class="FormLabel">
											<asp:Label ID="lbl_ServiceType" runat="server" Text="Service Type:" />
										</li>
										<li class="FormValue">
											<asp:TextBox ID="txt_ServiceType" runat="server" ReadOnly="true" />
										</li>
										<!--Employee Status-->
										<li class="FormLabel">
											<asp:Label ID="lbl_Status" runat="server" Text="Status:" />
										</li>
										<li class="FormValue">
											<asp:TextBox ID="txt_Status" runat="server" ReadOnly="true" />
										</li>
										<!--Employee JoinDate-->
										<li class="FormLabel">
											<asp:Label ID="lbl_JoinDate" runat="server" Text="Join Date:" />
										</li>
										<li class="FormValue">
											<asp:TextBox ID="txt_JoinDate" runat="server" ReadOnly="true" />
										</li>
										<!--Employee Office Email-->
										<li class="FormLabel">
											<asp:Label ID="lbl_OfficeEmail" runat="server" Text="Office Email:" />
										</li>
										<li class="FormValue">
											<asp:TextBox ID="txt_OfficeEmail" runat="server" ReadOnly="true" />
										</li>
									</ul>
								</li>
								<li class="FullWidth">
									<ul>
										<!--Employee PresentAddress PageSubTitle -->
										<li class="PageSubTitle">
											<asp:Label runat="server" ID="lbl_EmployeePresentAddress" Text=" Present Address" />
										</li>
										<!--Employee Present Town Or City -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeePresentTownOrCity" runat="server" Text=" Town Or City:" />
                                            <asp:Label runat="server" ID="lbl_TownMandatoryField" Text="*" CssClass="ValidationColor" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_EmployeePresentTownOrCity" TabIndex="11" TextMode="MultiLine" />
											<asp:RegularExpressionValidator ID="regulalExpressionVlidator_EmployeePresentTownOrCity" runat="server" Display="Dynamic" ControlToValidate="txt_EmployeePresentTownOrCity" ValidationExpression="^[a-zA-Z\s\.\,]+$" SetFocusOnError="True" />
											<asp:RequiredFieldValidator ID="requiredFieldValidator_EmployeePresentTownOrCity" runat="server" ControlToValidate="txt_EmployeePresentTownOrCity" Display="Dynamic" SetFocusOnError="true" />
										</li>
										<!--Employee PresentLandmark -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeePresentLandMark" runat="server" Text=" Land Mark:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeePresentLandMark" TabIndex="12" TextMode="MultiLine" />
											<asp:RegularExpressionValidator ID="regulalExpressionVlidator_EmployeePresentLandMark" runat="server" Display="Dynamic" ControlToValidate="txt_EmployeePresentLandMark" ValidationExpression="[0-9a-zA-Z\s\.\,]+" SetFocusOnError="True" />
										</li>
										<!--EmployeePresent PinCode -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeePresentPinCode" runat="server" Text=" Pin Code:" />
                                            <asp:Label runat="server" ID="lbl_PinMandatoryField" Text="*" CssClass="ValidationColor" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeePresentPinCode" TabIndex="13" />
											<asp:RegularExpressionValidator runat="server" ID="regulalExpressionVlidator_EmployeePresentPinCode" Display="Dynamic" ControlToValidate="txt_EmployeePresentPinCode" ValidationExpression="^[0-9\s]+$" SetFocusOnError="true" />
											<asp:RequiredFieldValidator ID="requiredFieldValidator_EmployeePresentPinCode" runat="server" ControlToValidate="txt_EmployeePresentPinCode" Display="Dynamic" SetFocusOnError="true" />
										</li>
										<!--Employee Present District-->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeePresentDistrict" runat="server" Text="Present District:" />
                                             <asp:Label runat="server" ID="lbl_DistrictMandatoryField" Text="*" CssClass="ValidationColor" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_EmployeePresentDistrict" OnSelectedIndexChanged="ddl_EmployeePresentDistrict_SelectedIndexChanged" TabIndex="14" AutoPostBack="True" />
											<asp:RequiredFieldValidator ID="requiredFieldValidator_PresentDistrict" runat="server" ControlToValidate="ddl_EmployeePresentDistrict" Display="Dynamic" SetFocusOnError="true" />
										</li>
										<!--Employee Present State-->
										<li class="FormLabel">
											<asp:Label runat="server" ID="lbl_EmployeeState" Text="State" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_EmployeePresentState" TabIndex="15" ReadOnly="True" />
										</li>
										<!--Employee Present Country-->
										<li class="FormLabel">
											<asp:Label runat="server" ID="lbl_EmployeePresentCountry" Text="Country:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_EmployeePresentCountry" TabIndex="16" ReadOnly="True" />
										</li>
									</ul>
									<ul>
										<!-- Employee Contacts Subheading -->
										<li class="PageSubTitle">
											<asp:Label ID="lbl_EmployeeContacts" runat="server" Text=" Contacts" />
										</li>
										<!--Employee Phone Number -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeePhoneNumber" runat="server" Text="Phone Number:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeePhoneNumber" TabIndex="22" />
											<asp:RangeValidator ID="rangeValidator_EmployeePhoneNumber" runat="server" ControlToValidate="txt_EmployeePhoneNumber" Display="Dynamic" SetFocusOnError="True" MaximumValue="9999999999999" MinimumValue="1000000" Type="Double" />
										</li>
										<!--Employee Mobile -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeMobile" runat="server" Text="Mobile:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeeMobile" TabIndex="23" />
											<asp:RangeValidator ID="rangeValidator_EmployeeMobile" runat="server" ControlToValidate="txt_EmployeeMobile" Display="Dynamic" SetFocusOnError="True" MaximumValue="999999999999" MinimumValue="1000000000" Type="Double" />
										</li>
										<!-- Employee Personal EmailId -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeePersonalEmailId" runat="server" Text="Personal Email Id:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeePersonalEmailId" TabIndex="25" />
											<asp:RegularExpressionValidator ID="regularExpression_EmployeePersonalEmailId" runat="server" ControlToValidate="txt_EmployeePersonalEmailId" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" />
										</li>
										<!--Employee Emergency Contact Number -->
										<li class="FormLabel">
											<asp:Label ID="lbl_EmployeeEmergencyContactNumber" runat="server" Text="Emergency Contact Number:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_EmployeeEmergencyContactNumber" TabIndex="26" />
											<asp:RangeValidator ID="rangevalidator_EmployeeEmergencycontactNumber" runat="server" ControlToValidate="txt_EmployeeEmergencyContactNumber" Display="Dynamic" SetFocusOnError="True" MaximumValue="9999999999999" MinimumValue="1000000" Type="Double" />
										</li>
									</ul>
								</li>
								<!-- Update Employee Profile Button -->
								<li class="FormButton_Top">
									<div id="Buttom">
										<asp:Button runat="server" ID="btn_EmployeeUpdate" Text="Update Profile" OnClick="btn_EmployeeUpdate_Click" />
										<asp:Label ID="lbl_Message" runat="server" />
										<ajax:ConfirmButtonExtender ID="ajaxConfirmButtonExtender_Employee" runat="server" TargetControlID="btn_EmployeeUpdate" ConfirmText="Are You Sure to Update the Profile ?" />
									</div>
								</li>
								<li class="FormSpacer" />
							</ul>
							<IAControl:DialogBox ID="dialog_EmployeeMessage" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none;" CssClass="modalPopup" EnableViewState="true">
								<ItemTemplate>
									<ul id="EmployeeDialog">
										<li>
											<asp:Label ID="lbl_TheMessage" runat="server" />
										</li>
									</ul>
								</ItemTemplate>
							</IAControl:DialogBox>
						</asp:View>
						<asp:View ID="view_FieldForce" runat="server">
							<ul id="FieldForceProfile">
								<li class="FormButton_Top">
									<asp:Button runat="server" ID="btn_UpdateFieldForceTop" Text="Update Profile" OnClick="btn_FieldForceUpdate_Click" />
								</li>
								<!--Field Force PageSubTitle -->
								<li class="FullWidth">
									<ul>
										<li class="PageSubTitle">
											<asp:Label runat="server" ID="lbl_FieldForceSubHeading" Text="Personal Details" />
										</li>
										<!--Field Force Name-->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForceSalutation" runat="server" Text="Name:" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_FieldForceSalutation" Width="50px" AutoPostBack="True" OnSelectedIndexChanged="ddl_FieldForceSalutation_SelectedIndexChanged" />
											<asp:TextBox runat="Server" ID="txt_FieldForceName" Width="165px" />
											<asp:RegularExpressionValidator ID="regularExpressionValidator_FieldForceName" runat="server" ControlToValidate="txt_FieldForceName" Display="Dynamic" ValidationExpression="[a-zA-Z\S\.]+" SetFocusOnError="True" />
											<asp:RequiredFieldValidator ID="requiredFieldValidator_FieldForceName" runat="server" ControlToValidate="txt_FieldForceName" Display="Dynamic" SetFocusOnError="true" />
										</li>
										<!-- FieldForce Father's Full Name -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForceFatherNameName" runat="server" Text="FatherName:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_FieldForceFatherName" TabIndex="1" />
											<asp:RegularExpressionValidator ID="regularExpressionValidator_FieldForceFatherName" runat="server" Display="Dynamic" ControlToValidate="txt_FieldForceFatherName" ValidationExpression="[a-zA-Z\s\.]+" SetFocusOnError="True" />
										</li>
										<!-- FieldForce Date Of Birth -->
										<li class="FormLabel">
											<asp:Label ID="lbl_fieldForceDateOfBirth" runat="server" Text="Date Of Birth:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_fieldForceDateOfBirth" TabIndex="2" />
											<ajax:CalendarExtender runat="server" ID="CalendarExtender1" Enabled="true" OnClientDateSelectionChanged="CheckLeaveDateRange" TargetControlID="txt_fieldForceDateOfBirth" CssClass="MicroCalendar" Format="dd-MMM-yyyy" />
											<asp:RequiredFieldValidator ID="requiredFieldValidator_fieldForceDateOfBirth" runat="server" ControlToValidate="txt_fieldForceDateOfBirth" Display="Dynamic" SetFocusOnError="true" />
										</li>
										<!-- FieldForceGender -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForceGender" runat="server" Text="Gender:" Width="20px" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_FieldForceGender" TabIndex="4" />
										</li>
										<!-- FieldForce BloodGroup -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForceBloodGroup" runat="server" Text="Blood Group:" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_FieldForceBloodGroup" TabIndex="5" />
										</li>
										<!-- FieldForce Religion -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForceReligion" runat="server" Text="Religion:" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_FieldForceReligion" TabIndex="6" />
										</li>
										<!--FieldForce Nationality -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForceNationality" runat="server" Text="Nationality:" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_FieldForceNationality" TabIndex="7" />
										</li>
										<!--FieldForce Marital Status -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForceMaritalStatus" runat="server" Text="Marital Status:" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_FieldForceMaritalStatus" TabIndex="8" />
										</li>
									</ul>
									<ul>
										<!-- FieldForce Contacts Subheading -->
										<li class="PageSubTitle">
											<asp:Label ID="lbl_FieldForceContacts" runat="server" Text=" Contacts" />
										</li>
										<!--FieldForce Phone Number -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForcePhoneNumber" runat="server" Text="Phone Number:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_FieldForcePhoneNumber" TabIndex="18" />
											<asp:RangeValidator ID="rangeValidator_FieldForcePhoneNumber" runat="server" ControlToValidate="txt_FieldForcePhoneNumber" Display="Dynamic" SetFocusOnError="True" MaximumValue="9999999999999" MinimumValue="1000000" Type="Double" />
										</li>
										<!-- FieldForce Mobile -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForceMobile" runat="server" Text="Mobile:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_FieldForceMobile" TabIndex="19" />
											<asp:RangeValidator ID="rangeValidator_FieldForceMobile" runat="server" ControlToValidate="txt_FieldForceMobile" Display="Dynamic" SetFocusOnError="True" MaximumValue="999999999999" MinimumValue="1000000000" Type="Double" />
										</li>
									</ul>
								</li>
								<li class="FullWidth">
									<ul>
										<!-- FieldForce PresentAddress PageSubTitle -->
										<li class="PageSubTitle">
											<asp:Label runat="server" ID="lbl_FieldForcePresentAddressSubHeading" Text="Present Address" />
										</li>
										<!-- FieldForce Present Town Or City -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForcePresentTownOrCity" runat="server" Text=" Town Or City:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_FieldForcePresentTownOrCity" TabIndex="9" TextMode="MultiLine" />
											<asp:RegularExpressionValidator ID="regularExpressionValidator_FieldForcePresentTownOrCity" runat="server" Display="Dynamic" ControlToValidate="txt_FieldForcePresentTownOrCity" ValidationExpression="^[a-zA-Z\s\.\,]+$" SetFocusOnError="True" />
											<asp:RequiredFieldValidator ID="requiredFieldValidator_FieldForcePresentTownOrCity" runat="server" ControlToValidate="txt_FieldForcePresentTownOrCity" Display="Dynamic" SetFocusOnError="true" />
										</li>
										<!--FieldForce Present District-->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForcePresentDistrict" runat="server" Text="Present District:" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_FieldForcePresentDistrict" OnSelectedIndexChanged="ddl_FieldForcePresentDistrict_SelectedIndexChanged" TabIndex="10" AutoPostBack="True" />
											<asp:RequiredFieldValidator ID="requiredFieldValidator_FieldForcePresentDistrict" runat="server" ControlToValidate="ddl_FieldForcePresentDistrict" Display="Dynamic" SetFocusOnError="true" />
										</li>
										<!--FieldForce Present State-->
										<li class="FormLabel">
											<asp:Label runat="server" ID="lbl_FieldForcePresentState" Text="State" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_FieldForcePresentState" TabIndex="11" ReadOnly="True" />
										</li>
										<!--FieldForce Present Country-->
										<li class="FormLabel">
											<asp:Label runat="server" ID="lbl_FieldForcePresentCountry" Text="Country:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_FieldForcePresentCountry" TabIndex="12" ReadOnly="True" />
										</li>
									</ul>
									<ul>
										<!-- FieldForce PermanentAddress PageSubTitle -->
										<li class="PageSubTitle">
											<asp:Label runat="server" ID="lbl_FieldForcePermanentAddressSubHeading" Text=" Permanent Address" />
										</li>
										<!-- FieldForce Permanent Town Or City -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForcePermanentTownOrCity" runat="server" Text="Town Or City:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="Server" ID="txt_FieldForcePermanentTownOrCity" TabIndex="13" TextMode="MultiLine" />
											<asp:RegularExpressionValidator ID="regulalExpressionVlidator_FieldForcePermanentTownOrCity" runat="server" Display="Dynamic" ControlToValidate="txt_FieldForcePermanentTownOrCity" ValidationExpression="^[a-zA-Z\s\,\.]+$" SetFocusOnError="True" />
										</li>
										<!-- FieldForce Permanent District -->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForcePermanentDistrict" runat="server" Text=" District:" />
										</li>
										<li class="FormValue">
											<asp:DropDownList runat="server" ID="ddl_FieldForcePermanentDistrict" OnSelectedIndexChanged="ddl_FieldForcePermanentDistrict_SelectedIndexChanged" TabIndex="14" AutoPostBack="True" />
										</li>
										<!-- FieldForce Permanent State-->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForcePermanentState" runat="server" Text="State:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_FieldForcePermanentState" TabIndex="16" ReadOnly="True" />
										</li>
										<!--FieldForce Permanent Country-->
										<li class="FormLabel">
											<asp:Label ID="lbl_FieldForcePermanentCountry" runat="server" Text="Country:" />
										</li>
										<li class="FormValue">
											<asp:TextBox runat="server" ID="txt_FieldForcePermanentCountry" TabIndex="17" ReadOnly="True" />
										</li>
								</li>
							</ul>
							<!--FieldForce Photo PageSubTitle -->
							<li class="PageSubTitle">
								<asp:Label ID="lbl_FieldForcePhotoSubHeader" runat="Server" Text=" Photo" />
							</li>
							<!-- FieldForce Photo -->
							<li class="FormLabel">
								<asp:Label ID="lbl_FieldForcePhoto" runat="server" Text="Photo:" />
							</li>
							<li class="FormValue">
								<asp:Image ID="Img_FieldForcePhoto" runat="server" Width="150" Height="150" TabIndex="23" />
								<asp:FileUpload runat="server" ID="flup_FieldForcePhoto" />
								<asp:Button runat="server" ID="btn_FieldForceUpload" Text="Uplaod" OnClick="btn_FieldForceUpload_Click" />
							</li>
							<!--FieldForce Signature -->
							<%--<li class="FormLabel">
							<asp:Label ID="lbl_FieldForceSignature" runat="server" Text="Signature:" />
						</li>
						<li class="FormValue">
							<asp:Image ID="Img_FieldForceSignature" runat="server" Width="150" Height="50" TabIndex="28" />
							<asp:FileUpload ID="flup_FieldForceSignature" runat="server" />
						</li>--%>
							<li class="FormLabel">
								<asp:Label ID="lbl_FileName" runat="server" Visible="false" />
							</li>
							<!-- Update FeildForceProfile Button -->
							<li class="FormButton_Top">
								<asp:Button runat="server" ID="btn_FieldForceUpdate" Text="Update Profile" OnClick="btn_FieldForceUpdate_Click" />
							</li>
							<li class="FormLabel">.</li>
							<li class="FormValue">.</li>
							</ul>
							<IAControl:DialogBox ID="dialog_FieldForceMessage" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none;" CssClass="modalPopup" EnableViewState="true">
								<ItemTemplate>
									<ul id="Ul1">
										<li>
											<asp:Label ID="Label1" runat="server" Text="FieldForce Profile Updated Successfully !!" />
										</li>
									</ul>
								</ItemTemplate>
							</IAControl:DialogBox>
						</asp:View>
						<asp:View ID="view_Guest" runat="server">
							<ul>
								<li class="FormButton_Top">
									<asp:Button runat="server" ID="btn_UpdateGuestTop" Text="Update Profile" OnClick="btn_GuestUpdate_Click" />
								</li>
								<li class="PageSubTitle">
									<asp:Label runat="server" ID="lbl_GuestSubHeading" Text="Personal Details" />
								</li>
								<!-- GuestSalutation -->
								<li class="FormLabel">
									<asp:Label ID="lbl_GuestSalutation" runat="server" Text="Name:" />
								</li>
								<li class="FormValue">
									<asp:DropDownList runat="server" ID="ddl_GuestSalutation" TabIndex="0" AutoPostBack="True" OnSelectedIndexChanged="ddl_GuestSalutation_SelectedIndexChanged" />
									<!-- GuestName -->
									<asp:TextBox runat="Server" ID="txt_GuestName" TabIndex="1" />
									<asp:RegularExpressionValidator ID="regularExpressionValidator_GuestName" runat="server" ControlToValidate="txt_GuestName" Display="Dynamic" ValidationExpression="[a-zA-Z\s\.]+" SetFocusOnError="True" />
									<asp:RequiredFieldValidator ID="requiredFieldValidator_GuestName" runat="server" ControlToValidate="txt_GuestName" Display="Dynamic" SetFocusOnError="true" />
								</li>
								<!-- GuestGender -->
								<li class="FormLabel">
									<asp:Label ID="lbl_GuestGender" runat="server" Text="Gender:" />
								</li>
								<li class="FormValue">
									<asp:DropDownList runat="server" ID="ddl_GuestGender" TabIndex="2" />
								</li>
								<!-- Guest PresentAddress PageSubTitle -->
								<li class="PageSubTitle">
									<asp:Label runat="server" ID="lbl_GuestPresentAddress" Text=" Present Address" />
								</li>
								<!--Guest Age -->
								<li class="FormLabel">
									<asp:Label runat="server" ID="lbl_GuestAge" Text="Age:" />
								</li>
								<li class="FormValue">
									<asp:TextBox runat="server" ID="txt_GuestAge" />
									<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_GuestAge" Display="Dynamic" ControlToValidate="txt_GuestAge" SetFocusOnError="true" />
									<asp:RangeValidator runat="server" ID="rangeValidator_GuestAge" Display="Dynamic" ControlToValidate="txt_GuestAge" SetFocusOnError="true" MinimumValue="1" MaximumValue="150" Type="Integer" />
								</li>
								<!-- Guest Present Town Or City -->
								<li class="FormLabel">
									<asp:Label ID="lbl_GuestPresentTownOrCity" runat="server" Text=" Town Or City:" />
								</li>
								<li class="FormValue">
									<asp:TextBox runat="server" ID="txt_GuestPresentTownOrCity" TabIndex="3" Height="17px" TextMode="MultiLine" />
									<asp:RegularExpressionValidator ID="regularExpressionValidator_GuestPresentTownOrCity" runat="server" Display="Dynamic" ControlToValidate="txt_GuestPresentTownOrCity" ValidationExpression="^[a-zA-Z\s\.\,]+$" SetFocusOnError="True" />
									<asp:RequiredFieldValidator ID="requiredFieldValidator__GuestPresentTownOrCity" runat="server" ControlToValidate="txt_GuestPresentTownOrCity" Display="Dynamic" SetFocusOnError="true" />
								</li>
								<!--Guest Present District-->
								<li class="FormLabel">
									<asp:Label ID="lbl_GuestPresentDistrict" runat="server" Text="Present District:" />
								</li>
								<li class="FormValue">
									<asp:DropDownList runat="server" ID="ddl_GuestPresentDistrict" OnSelectedIndexChanged="ddl_GuestPresentDistrict_SelectedIndexChanged" TabIndex="4" AutoPostBack="True" />
									<asp:RequiredFieldValidator ID="requiredFieldValidator_GuestPresentDistrict" runat="server" ControlToValidate="ddl_FieldForcePresentDistrict" Display="Dynamic" SetFocusOnError="true" />
								</li>
								<!--Guest Present State-->
								<li class="FormLabel">
									<asp:Label runat="server" ID="lbl_GuestState" Text="State" />
								</li>
								<li class="FormValue">
									<asp:TextBox runat="server" ID="txt_GuestState" TabIndex="5" ReadOnly="True" />
								</li>
								<!--Guest Present Country-->
								<li class="FormLabel">
									<asp:Label runat="server" ID="lbl_GuestCountry" Text="Country:" />
								</li>
								<li class="FormValue">
									<asp:TextBox runat="server" ID="txt_GuestCountry" TabIndex="6" ReadOnly="True" />
								</li>
								<!-- Guest Contacts Subheading -->
								<li class="PageSubTitle">
									<asp:Label ID="lbl_GuestContact" runat="server" Text="Contacts" />
								</li>
								<!--Guest Phone Number -->
								<li class="FormLabel">
									<asp:Label ID="lbl_GuestPhone" runat="server" Text="Phone Number:" />
								</li>
								<li class="FormValue">
									<asp:TextBox runat="Server" ID="txt_GuestPhone" TabIndex="7" />
									<asp:RangeValidator ID="rangeValidator_GuestPhone" runat="server" ControlToValidate="txt_GuestPhone" Display="Dynamic" SetFocusOnError="True" MaximumValue="9999999999999" MinimumValue="10000000" Type="Double" />
								</li>
								<!-- Guest EmailId -->
								<li class="FormLabel">
									<asp:Label ID="lbl_GuestEmailId" runat="server" Text="Email Id:" />
								</li>
								<li class="FormValue">
									<asp:TextBox runat="Server" ID="txt_GuestEmailId" TabIndex="8" />
									<asp:RegularExpressionValidator ID="regularExpressionValidator_GuestEmailId" runat="server" Display="Dynamic" ControlToValidate="txt_GuestEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" />
								</li>
								<!-- Update Profile Button -->
								<li class="FormButton_Top">
									<asp:Button runat="server" ID="btn_GuestUpdate" Text="Update Profile" OnClick="btn_GuestUpdate_Click" />
								</li>
								<li class="FormLabel">.</li>
								<li class="FormValue">.</li>
								</li>
							</ul>
							<IAControl:DialogBox ID="dialog_GuestMessage" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none;" CssClass="modalPopup" EnableViewState="true">
								<ItemTemplate>
									<ul>
										<li>
											<asp:Label ID="Label2" runat="server" Text="GuestProfile Updated Successfully !!" />
										</li>
									</ul>
								</ItemTemplate>
							</IAControl:DialogBox>
						</asp:View>
					</asp:MultiView>
				</div>
			</ContentTemplate>
			<Triggers>
				<%--<asp:PostBackTrigger ControlID="btn_UploadEmployeePhoto" />
				<asp:PostBackTrigger ControlID="btn_FieldForceUpload" />--%>
				<%--<asp:PostBackTrigger ControlID="btn_UploadEmployeeSignature" />--%>
				<%--<asp:PostBackTrigger ControlID="btn_UploadEmployeeSignature"></asp:PostBackTrigger>--%>
			</Triggers>
		</asp:UpdatePanel>
	</div>
</asp:Content>
