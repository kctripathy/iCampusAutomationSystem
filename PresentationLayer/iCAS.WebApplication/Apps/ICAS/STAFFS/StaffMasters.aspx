<%@ Page Title="Staff Master" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffMasters.aspx.cs" Inherits="Micro.WebApplication.APPS.ICAS.STAFFS.StaffMasters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">

    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text=" Manage (Add/Edit/Delete/View) College Staff Master:-" />
    </h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_Staff">
        <ContentTemplate>
            <asp:MultiView ID="multiView_EmployeeDetails" runat="server">
                <asp:View ID="view_InputControls" runat="server">
                    <ul class="StaffFullWidth">
                        <li class="FormButton_Top">
                            <asp:Button runat="server" ID="Button1" CausesValidation="false" Text=" View " OnClick="btn_ViewEmployeeDetails_OnClick" />
                            <asp:Button runat="server" ID="btn_Saveupdate" Text="Save" CausesValidation="true" OnClick="Btn_Save_Click" />
                            <asp:Button ID="Button3" runat="server" CausesValidation="false" Text="Reset" OnClick="btn_Reset_Click"></asp:Button>
                        </li>
                    </ul>

                    <ul class="Staff">
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="Label141" Text="Staff Personal Details :" />
                        </li>

                        <!--EmpCode-->
                        <li class="FormLabel" style="display: none;">
                            <asp:Label runat="server" ID="lbl_EmpCode" Text="Emp Code :" />
                        </li>
                        <li class="FormValue" style="display: none;">
                            <asp:TextBox runat="server" ID="txt_EmpCode" Enabled="false" />
                        </li>

                        <!--Teaching?-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="Label4" Text="Name of the Office / College:" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Office" Width="90%" />
                        </li>






                        <!--Department-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Department" Text="Select Department:" />
                            <asp:Label runat="server" ID="Label23" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Department" Width="50%" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Department" ControlToValidate="ddl_Department" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
                        </li>



                        <!--Designation-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Designation" Text="Select Designation:" />
                            <asp:Label runat="server" ID="Label22" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Designation" Width="50%" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Designation" ControlToValidate="ddl_Designation" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
                        </li>

                        <!--Salutation EmployeeName"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Salutation" Text="Enter Name of the Staff:" />
                            <asp:Label runat="server" ID="Label7" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <ul style="display: block; width: 100%; margin: 0px; padding: 0px;">
                                <li style="display: block; float: left; width: auto; margin: 0px; padding: 0px;">
                                    <asp:DropDownList runat="server" ID="ddl_Salutation" Width="50px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Salutation_SelectedIndexChanged" />
                                    <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Salutation" ControlToValidate="ddl_Salutation" Display="Dynamic" SetFocusOnError="true" />
                                </li>
                                <li style="display: block; float: left; width: 70%; margin: 0px; padding: 0px;">
                                    <asp:TextBox runat="server" ID="txt_EmployeeName" Width="51%" />
                                    <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EmployeeName" ControlToValidate="txt_EmployeeName" Display="Dynamic" SetFocusOnError="true" />
                                    <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_EmployeeName" ControlToValidate="txt_EmployeeName" Display="Dynamic" SetFocusOnError="true" />

                                </li>
                            </ul>
                        </li>

                        <!--Date Of Birth"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lblDateOfBirth" Text="Date Of Birth /Age :" />
                            <asp:Label runat="server" ID="Label11" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">

                            <asp:TextBox runat="server" ID="txt_DOB" Width="177px" OnTextChanged="txt_DOB_TextChanged" AutoPostBack="true" />
                            <asp:ImageButton runat="server" ID="imgButton_DateOfBirth" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <ajax:CalendarExtender ID="ajaxCalender_DOB" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_DateOfBirth" CssClass="MicroCalendar" TargetControlID="txt_DOB" OnClientDateSelectionChanged="CheckLeaveDateRange" />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_DOB" runat="server" ControlToValidate="txt_DOB" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DOB" ControlToValidate="txt_DOB" Display="Dynamic" SetFocusOnError="true" />
                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Age" ControlToValidate="txt_Age"  Display="Dynamic"  SetFocusOnError="true" />--%>
                            <asp:TextBox runat="server" ID="txt_Age" CssClass="TextSmallWidth" AutoPostBack="true" OnTextChanged="txt_Age_OnTextChanged" Enabled="false" Visible="false" /><!--OnTextChanged="txt_Age_TextChanged"-->
                        </li>





                        <!--Reporting To-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_ReportingTo" Text="Reporting To Emp:" />
                            <asp:Label runat="server" ID="Label25" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_ReportingTo" Width="90%" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ReportingTo" ControlToValidate="ddl_ReportingTo" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
                        </li>

                        <!--Identification Mark"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_IdentificationMark" Text="Identification Mark :" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_IdentificationMark" />
                        </li>
                        <!--Known Ailment"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_KnownAilment" Text="Known Ailment :" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_KnownAilment" />
                        </li>
                    </ul>
                    <ul class="Staff">

                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="Label5" Text="Personal Details :" />

                        </li>
                        <!--Gender"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Gender" Text="Gender :" />
                            <asp:Label runat="server" ID="lbl_GenderErr" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Gender" AutoPostBack="True" OnSelectedIndexChanged="ddl_Gender_SelectedIndexChanged" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Gender" ControlToValidate="ddl_Gender" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <!--MaritalStatus"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_MaritalStatus" Text="Marital Status:" />
                            <%--<asp:Label runat="server" ID="Label10" Text="*" CssClass="ValidationColor" />--%>
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_MaritalStatus" />
                            <!--OnSelectedIndexChanged="ddl_MaritalStatus_SelectedIndexChanged"-->
                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_MaritalStatus" ControlToValidate="ddl_MaritalStatus" Display="Dynamic" SetFocusOnError="true" />--%>
                        </li>
                        <!--Father's Name"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_FathersName" Text="Father's Name :" />
                            <%--<asp:Label runat="server" ID="lbl_FatherNameValidation" Text="*" CssClass="ValidationColor" />--%>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_FathersName" />
                            <%--                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_FatherName" ControlToValidate="txt_FathersName" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_FatherName" ControlToValidate="txt_FathersName" Display="Dynamic" SetFocusOnError="true" />--%>
                        </li>
                        <!--Spouse Name"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lblSpouceName" Text="Spouse:" />
                            <%--<asp:Label runat="server" ID="lbl_HusbandValidation" Text="*" ForeColor="Red" />--%>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_SpouceName" ReadOnly="true" />
                            <%--<asp:RequiredFieldValidator ID="requiredFieldValidator_SpouceName" runat="server" ControlToValidate="txt_SpouceName" Display="Dynamic" SetFocusOnError="true"  />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_SpouceName" ControlToValidate="txt_SpouceName" Display="Dynamic" Enabled="false" SetFocusOnError="true" />--%>
                        </li>

                        <!--Nationality"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Nationality" Text="Nationality :" />
                            <%--<asp:Label runat="server" ID="Label12" Text="*" CssClass="ValidationColor" />--%>
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Nationality" />
                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Nationality" ControlToValidate="ddl_Nationality" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />--%>
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
                        <!--Bio DeviceEmpid-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_BioEmpid" Text="Bio-Dev.Id:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_BioDeviceEmpid" Width="90%" />
                            <%--<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_BioDeviceEmpid" ControlToValidate="txt_BioDeviceEmpid" Display="Dynamic" />--%>
                        </li>
                    </ul>
                    <ul class="Staff">
                        <!-- Contact Details PageSubTitle -->
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="lbl_ContactDetailsubHeading" Text="Contact Details :" />
                        </li>
                        <!-- Phone -->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Phone" Text="Phone Number:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_PhoneNumber" Width="90%" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PhoneNumber" ControlToValidate="txt_PhoneNumber" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator ID="regularExpressionValidator_PhoneNumberLength"
                                runat="server" ControlToValidate="txt_PhoneNumber" Display="Dynamic"
                                SetFocusOnError="true" />
                        </li>
                        <!--Mobile -->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Mobile" Text="Mobile Number:" Width="90%" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_Mobile" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_MobileNumber" ControlToValidate="txt_Mobile" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RangeValidator ID="rangeValidator_Mobile" runat="server" ControlToValidate="txt_Mobile" Display="Dynamic" SetFocusOnError="true" Type="Double" />
                            <asp:RegularExpressionValidator ID="regularExpressionValidator_MobileLength"
                                runat="server" ControlToValidate="txt_Mobile" Display="Dynamic"
                                SetFocusOnError="true" />
                        </li>
                        <!--Emergency Nummber -->
                        <%--<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_EmergenceNumber" Text="Emergency No. :" />
										<asp:Label runat="server" ID="Label9" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:TextBox runat="server" ID="txt_EmergencyNo" />
                                    </li>--%>
                        <!-- Personal Email ID -->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_PersonalEmailID" Text="Personal Email:" Width="90%" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_PersonalEmailID" Width="90%" /><!--OnTextChanged="txt_EmailID_TextChanged"-->
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonalEmailID" ControlToValidate="txt_PersonalEmailID" Display="Dynamic" />
                        </li>
                        <!-- Official Email ID -->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_OfficialEmailID" Text="Official Email:" Width="90%" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_OfficialEmailID" /><!--OnTextChanged="txt_OfficialEmailID_TextChanged"-->
                        </li>
                        <!--ReferencedBy Name -->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_ReferenceName" Text="Reference Name:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_ReferenceName" Width="90%" />
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
                        <asp:RegularExpressionValidator ID="regularExpressionValidator_ReferencephoneLength"
                            runat="server" ControlToValidate="txt_ReferencePhone" Display="Dynamic"
                            SetFocusOnError="true" />
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_ReferenceMobile" Text="Reference Mobile No.:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_ReferenceMobile" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_ReferenceMobile" ControlToValidate="txt_ReferenceMobile" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="regularExpressionValidator_Reference_Mobile_length"
                                runat="server" ControlToValidate="txt_ReferencePhone" Display="Dynamic"
                                SetFocusOnError="true" />
                            <asp:RangeValidator ID="rangeValidator_ReferenceMobile" runat="server" ControlToValidate="txt_ReferenceMobile" Display="Dynamic" SetFocusOnError="true" Type="Double" />
                        </li>


                    </ul>
                    <ul class="Staff">
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="Label8" Text="Payroll Details :" />
                        </li>
                        <!--EpfGPFAccountNo-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_EpfGPFAccNo" Text="EPG & GPF A/C No:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_EpfAndGpfAccNo" Width="95%" />
                        </li>
                        <!--PanNo-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_PanNo" Text="PAN Number:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_PanNo" Width="95%" />
                        </li>
                        <!--SbiAccountNo-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_SbiAccNo" Text="BANK A/C No:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_SbiAccountNo" Width="95%" />
                        </li>
                        <!--ScaleOF Pay-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_ScaleOfPay" Text="Scale Of Pay:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_ScaleOfPay" Width="95%" />
                        </li>
                        <!--Gp orAGP-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_GporAGP" Text="Gp or AGP:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_GporAgp" Width="95%" />
                        </li>
                        <!--ChseRegdno-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_ChseRegdno" Text="CHSE Regd. No:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_ChseRegdno" Width="95%" />
                        </li>
                        <!--UniversityRegdNo-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_UnivRegdNo" Text="University Regd. No:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_UniverRegdNo" Width="95%" />
                        </li>

                    </ul>
                    <ul class="Staff">
                        <!-- Miscellaneous Details PageSubTitle -->
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="Label6" Text="Joining Details :" />
                        </li>
                        <!--JoinDatein office-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_JoinDate" Text="Join Date :" />
                            <asp:Label runat="server" ID="Label21" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_JoinDate" AutoPostBack="true" OnTextChanged="txt_JoinDate_TextChanged" CssClass="JoinDate" Width="60%" />
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_JoinDate" CssClass="MicroCalendar" TargetControlID="txt_JoinDate" />
                            <asp:ImageButton runat="server" ID="imgButton_JoinDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_JoinDate" ControlToValidate="txt_JoinDate" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_JoinDate" ControlToValidate="txt_JoinDate" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <!--JoinDatein service-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_JoinDateInService" Text="Join Date In Service :" />
                            <asp:Label runat="server" ID="Label888" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_JoinDateinService" AutoPostBack="true" OnTextChanged="txt_JoinDateinService_TextChanged" CssClass="JoinDate" Width="60%" />
                            <ajax:CalendarExtender ID="CalendarExtender_JoinDateinService" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_JoinDateinService" CssClass="MicroCalendar" TargetControlID="txt_JoinDateinService" />
                            <asp:ImageButton runat="server" ID="imgButton_JoinDateinService" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_JoinDateinService" ControlToValidate="txt_JoinDateinService" Display="Dynamic" SetFocusOnError="true" />
                            <%--<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_JoinDateinService" ControlToValidate="txt_JoinDateinService" Display="Dynamic" SetFocusOnError="true" />--%>
                        </li>
                        <!--Date Of Next Increment-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_DateofNextIncrement" Text="Date Of Next Increment :" />
                            <asp:Label runat="server" ID="Label17" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_DateofNextIncrement" Width="60%" />
                            <asp:ImageButton runat="server" ID="imgButton_DateofNextIncrement" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <ajax:CalendarExtender ID="CalendarExtender_DateofNextIncrement" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_DateofNextIncrement" CssClass="MicroCalendar" TargetControlID="txt_DateofNextIncrement" />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_DateofNextIncrement" runat="server" ControlToValidate="txt_DateofNextIncrement" Display="Dynamic" SetFocusOnError="true" />
                            <%--			<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DateofNextIncrement" ControlToValidate="txt_DateofNextIncrement" Display="Dynamic" SetFocusOnError="true" />--%>
                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Age" ControlToValidate="txt_Age"  Display="Dynamic"  SetFocusOnError="true" />--%>
                        </li>
                        <!--EmployeeType1-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_EmployeeType1" Text="Emp. Type1:" />
                            <asp:Label runat="server" ID="Label20" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Employeetyp1" Width="170px" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Employeetyp1" ControlToValidate="ddl_Employeetyp1" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <!--EmployeeType2-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_EmployeeType2" Text="Emp. Type2:" />
                            <asp:Label runat="server" ID="Label28" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Employeetyp2" Width="170px" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Employeetyp2" ControlToValidate="ddl_Employeetyp2" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <!--EmployeeType3-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_EmployeeType3" Text="Emp. Type3:" />
                            <asp:Label runat="server" ID="Label29" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Employeetyp3" Width="170px" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Employeetyp3" ControlToValidate="ddl_Employeetyp3" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <!--EmployeeType4-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_EmployeeType4" Text="Emp. Type4:" />
                            <asp:Label runat="server" ID="Label30" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Employeetyp4" Width="170px" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Employeetyp4" ControlToValidate="ddl_Employeetyp4" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                    </ul>
                    <ul class="Staff">
                        <!--PageSubTitle"-->
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="Label9" Text="Service Status :" />
                        </li>
                        <!--ServiceStatusLastWorkingDate-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_ServiceStatusLastWorkingDate" Text="Last Working Date:" />
                            <asp:Label runat="server" ID="Label31" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_ServiceStatusLastWorkingDate" AutoPostBack="true" CssClass="JoinDate" />
                            <ajax:CalendarExtender ID="CalendarExtender_ServiceStatusLastWorkingDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_ServiceStatusLastWorkingDate" CssClass="MicroCalendar" TargetControlID="txt_ServiceStatusLastWorkingDate" />
                            <asp:ImageButton runat="server" ID="imgButton_ServiceStatusLastWorkingDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ServiceStatusLastWorkingDate" ControlToValidate="txt_ServiceStatusLastWorkingDate" Display="Dynamic" SetFocusOnError="true" Text="*" />
                            <%--			<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_ServiceStatusLastWorkingDate" ControlToValidate="txt_ServiceStatusLastWorkingDate" Display="Dynamic" SetFocusOnError="true" />--%>
                        </li>
                        <!--ServiceStatusChangeRequestDate-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_ServiceStatusChangeRequestDate" Text="Change Request Date:" />
                            <asp:Label runat="server" ID="Label899" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_ServiceStatusChangeRequestDate" AutoPostBack="true" CssClass="JoinDate" />
                            <ajax:CalendarExtender ID="CalendarExtender_ServiceStatusChangeRequestDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_ServiceStatusChangeRequestDate" CssClass="MicroCalendar" TargetControlID="txt_ServiceStatusChangeRequestDate" />
                            <asp:ImageButton runat="server" ID="imgButton_ServiceStatusChangeRequestDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ServiceStatusChangeRequestDate" ControlToValidate="txt_ServiceStatusChangeRequestDate" Display="Dynamic" SetFocusOnError="true" />
                            <%--		<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_ServiceStatusChangeRequestDate" ControlToValidate="txt_ServiceStatusChangeRequestDate" Display="Dynamic" SetFocusOnError="true" />--%>
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
                            <asp:Label runat="server" ID="lbl_PhStatus" Text="Physical Status :" />
                            <asp:Label runat="server" ID="Label27" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_PhStatus" />
                        </li>
                        <!--Notice If Any-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Notice" Text="Notice If Any :" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_Notice" Width="95%" />
                        </li>
                    </ul>
                    <ul class="Staff">

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
                            <asp:TextBox runat="server" ID="txt_PresentPincode" Width="95%" />
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

                    <!-- Permanent Address PageSubTitle -->
                    <ul class="Staff">
                        
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_PermanentAddress" runat="server" ControlToValidate="txt_PermanentAddress" SetFocusOnError="True" Display="Dynamic" />
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
                            <asp:TextBox runat="server" ID="txt_PermanentPincode" Width="95%" />
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
                     

                    
                    <ul class="StaffFullWidth">
                        <!-- Education Details PageSubTitle -->
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="Label3" Text="Educational Qualification :" />
                        </li>
                        <!-- Qualification -->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Qualification" Text="Qualification :" />
                            <asp:Label runat="server" ID="Label19" Text="*" CssClass="ValidationColor" />
                        </li>
                        <!--Passing Year -->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_PassingYear" Text="Passing Year :" />
                            <%--<asp:Label runat="server" ID="Label20" Text="*" CssClass="ValidationColor" />--%>
                        </li>
                         <!--Board Or University-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Board" Text="Board/University :" />
                        </li>

                        <!--Division-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Division" Text="Division :" />
                        </li>
                         <!--Percentage of Marks-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Percentage" Text="Percentage :" />
                        </li>


                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_Qualification" AutoPostBack="True" />
                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Qualification" ControlToValidate="ddl_Qualification" Display="Dynamic" SetFocusOnError="true" />--%>
                        </li>
                        
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_PassingYear" />
                            <%--<asp:RangeValidator ID="rangeValidator_PassingYear" runat="server" ControlToValidate="txt_PassingYear" Display="Dynamic" SetFocusOnError="true" Type="Integer" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_PassingYear" ControlToValidate="txt_PassingYear" Display="Dynamic" SetFocusOnError="true" />--%>
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PassingYear" ControlToValidate="txt_PassingYear" Display="Dynamic" />
                        </li>
                       
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_Board" />
                        </li>
                        
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_Division" />
                        </li>
                       
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_Percentage" />
                            
                        </li>
                        <li class="FormButton">
                            <asp:Button runat="server" ID="btn_AddSample" CausesValidation="false" Text="Add Qualification" OnClick="btn_AddSample_Click" />
                        </li>
                        <li class="GridView">
                            <asp:GridView runat="server" ID="gview_Course" AutoGenerateColumns="True" AllowSorting="true" PageSize="15" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2">
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="CheckBox">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chk_SubjectID" Visible="true" Checked="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="HeaderStyle" />
                            </asp:GridView>
                        </li>
                    </ul>

                    <ul>
                        <li class="FormButton_Top">
                            <asp:Button runat="server" ID="btn_ViewEmployeeDetails" CausesValidation="false" Text=" View " OnClick="btn_ViewEmployeeDetails_OnClick" />
                            <asp:Button runat="server" ID="btn_Top_Save" Text="Save" CausesValidation="true" OnClick="Btn_Save_Click" />
                            <asp:Button ID="btn_Reset" runat="server" CausesValidation="false" Text="Reset" OnClick="btn_Reset_Click"></asp:Button>
                        </li>
                    </ul>
                </asp:View>
                <asp:View ID="view_GridView" runat="server">
                    <ul class="StaffFullWidth">
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_AddNew" runat="server" Text="Add New" OnClick="btn_AddNew_Click" />
                        </li>
                        <li class="FormPageCounter">
                            <asp:Literal runat="server" ID="lit_PageCounter" />
                        </li>
                        <li class="GridView">
                            <asp:GridView runat="server" ID="gview_Employee" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="30" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2" OnRowCommand="gview_Employee_RowCommand" OnRowEditing="gview_Employee_RowEditing" OnRowDeleting="gview_Employee_RowDeleting" OnRowDataBound="gview_Employee_RowDataBound" OnPageIndexChanging="gview_Employee_PageIndexChanging">
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="CheckBox">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chk_EmployeeID" Visible="true" />
                                            <asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />
                                            <asp:Label runat="server" ID="lbl_ServiceDetailsID" Text='<%#Eval("EmployeeServiceDetailsID") %>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DepartmentDescription" HeaderText="Department" ItemStyle-CssClass="Department" />
                                    <asp:BoundField DataField="EmployeeCode" HeaderText="Code " ItemStyle-CssClass="EmployeeCode" />
                                    <asp:BoundField DataField="EmployeeName" HeaderText="Name " ItemStyle-CssClass="EmployeeName" />
                                    <asp:BoundField DataField="DesignationDescription" HeaderText="Designation " ItemStyle-CssClass="DesignationAndRole" />
                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" ItemStyle-CssClass="Mobile" />
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
</asp:Content>
