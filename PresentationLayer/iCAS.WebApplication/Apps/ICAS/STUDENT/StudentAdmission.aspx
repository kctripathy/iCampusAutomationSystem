<%@ Page Title="Admission " Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentAdmission.aspx.cs" Inherits="Micro.WebApplication.APPS.ICAS.STUDENT.StudentAdmission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="~/App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="tsdc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
        .FeesPaid
        {
            color: red;
        }

        .BtnFeesPaid
        {
            padding: 2px 10px;
            border: solid 1px navy;
        }

        .StepStyle
        {
            padding: 10px;
        }

            .StepStyle label
            {
                font-size: 110%;
                margin-right: 10px;
            }

        #WebBody #PageContent_RightColumn ul.SearchBox
        {
            width: 100%;
            height: 20px;
        }
    </style>
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Student Admission:" />
    </h1>

    <asp:UpdatePanel runat="server" ID="updatepanel_StudentAdmMaster">
        <ContentTemplate>
            <ul class="StudentFullWidth">
                <asp:RadioButtonList runat="server"
                    ID="chklist_Details"
                    AutoPostBack="True"
                    RepeatDirection="Horizontal"
                    OnSelectedIndexChanged="chklist_Details_SelectedIndexChanged" Width="100%"
                    Font-Bold="True" CssClass="StepStyle">
                    <asp:ListItem Selected="True" Value="1"> Step1- Registration >></asp:ListItem>
                    <asp:ListItem Value="2" Enabled="False"> Step2- Admission >></asp:ListItem>
                    <asp:ListItem Value="3" Enabled="False"> Step3- Assign Subject >></asp:ListItem>
                </asp:RadioButtonList>
            </ul>
            <asp:MultiView ID="Student_Multi" runat="server">
                <asp:View ID="InputControls" runat="server">
                    <div>
                        <ul id="Button">
                            <li class="FormButton_Top">
                                <asp:Label ID="lbl_Message" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btn_ViewList" runat="server" Text="<<< View Apply List" CausesValidation="false" OnClick="btn_View_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btn_MoveNext" runat="server"
                                    Text=" Click Here For Admission >>> " CausesValidation="true"
                                    OnClick="btn_MoveNext_Click" />

                                <%--<asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_reset_Click" />--%>
                            </li>
                        </ul>
                        <ul class="Student">
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_PersonalDetails" Text="Personal Details :" />
                                <asp:Label runat="server" ID="lbl_RegNo" Text="" />
                            </li>

                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Salutation" Text="Salutation " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="drpdwn_Salutation" />
                            </li>
                            <%-- --Student Name----%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StudentName" Text="Student Name " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_StudentName" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Name" ControlToValidate="txt_StudentName"
                                    Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Name"
                                    ControlToValidate="txt_StudentName" Display="Dynamic" SetFocusOnError="true" />
                            </li>

                            <%--Date of Birth--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_DateOfBirth" Text="Date Of Birth " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_DateOfBirth" AutoPostBack="true" OnTextChanged="txt_DateOfBirth_TextChanged" />
                                <asp:ImageButton runat="server" ID="imgbtn_DateOfBirth" CausesValidation="false"
                                    ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                    Height="21" Width="21" />
                                <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_dob"
                                    PopupButtonID="imgbtn_DateOfBirth" CssClass="MicroCalendar" TargetControlID="txt_DateOfBirth" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DateOfBirth"
                                    ControlToValidate="txt_DateOfBirth" CssClass="ValidateMessage" Display="Dynamic"
                                    ErrorMessage="Date of Birth or Age must be given" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DateOfBirth"
                                    ControlToValidate="txt_DateOfBirth" CssClass="ValidateMessage" Display="Dynamic"
                                    ErrorMessage="Invalid Date" />
                            </li>
                            <%--Age--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Age" Text="Age" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_Age" AutoPostBack="True" OnTextChanged="txt_Age_TextChanged"
                                    ReadOnly="True" />
                                <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Age" ControlToValidate="txt_Age"
                                    CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Age" SetFocusOnError="true" />
                                <asp:RangeValidator runat="server" ID="rangeValidator_Age" ControlToValidate="txt_Age"
                                    Display="Dynamic" SetFocusOnError="true" Type="Integer" />--%>
                            </li>
                            <%--  Father Name--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_FatherNmae" Text="Father Name " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_FatherName" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_FatherName"
                                    ControlToValidate="txt_FatherName" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_FatherName"
                                    ControlToValidate="txt_FatherName" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Mother Name--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_MotherName" Text="Mother Name " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_MotherName" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_MotherName"
                                    ControlToValidate="txt_MotherName" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_MotherName"
                                    ControlToValidate="txt_MotherName" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                        </ul>
                        <ul class="Student">
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="Label2" Text="College Roll Details" />
                            </li>

                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_AcademicYear" Text="Academic Year " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_AcademicYear" runat="server" />
                            </li>
                            <%--Gender--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Gender" Text="Gender" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="drpdwn_Gender" runat="server" />
                            </li>
                            <%--Caste--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Caste" Text="Caste " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="drpdwn_Caste" runat="server">
                                    <asp:ListItem>General</asp:ListItem>
                                    <asp:ListItem>OBC</asp:ListItem>
                                    <asp:ListItem>SC</asp:ListItem>
                                    <asp:ListItem>ST</asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <%--PH Status--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PHStatus" Text="Physically Challenged " />
                            </li>
                            <li class="FormValue">
                                <asp:RadioButtonList ID="radio_PHStatus" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                            </li>
                            <%--Phone Number--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PhoneNumber" Text="Phone Number " />
                            </li>
                            <%--Mobile--%>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PhoneNumber" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PhoneNumber"
                                    ControlToValidate="txt_PhoneNumber" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Mobile" Text="Mobile" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_Mobile" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_MobileNo"
                                    ControlToValidate="txt_Mobile" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Email Id--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_EmailId" Text="Email Id" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_EmailId" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_EmailId"
                                    ControlToValidate="txt_EmailId" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                        </ul>
                        <ul class="Student">
                            <li class="PageSubTitle">
                                <asp:Label ID="lbl_PresentAddress" runat="server" Text="Present Address" />
                            </li>
                            <%--Town/City--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentCity" Text="Address Line" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PresentCity" Height="64px" Width="206px" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Present_TownOrCity"
                                    ControlToValidate="txt_PresentCity" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Landmark--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentLandmark" Text="Landmark" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PresentLandmark" />
                            </li>
                            <%--District--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentDistrictId" Text="District" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="drpdwn_PresentDistrictId" runat="server" AutoPostBack="True"
                                    Width="95%" /><%--OnSelectedIndexChanged="drpdwn_PresentDistrictId_SelectedIndexChanged" --%>
                            </li>
                            <%--State--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentStateName" Text="State" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_PresentStateName" runat="server" ReadOnly="true" />
                            </li>
                            <%--Country--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentCountry" Text="Country" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_PresentCountry" runat="server" ReadOnly="true" />
                            </li>
                            <%--Pincode--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentPincode" Text="Pincode" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PresentPincode" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Present_Pincode"
                                    ControlToValidate="txt_PresentPincode" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                        </ul>
                        <ul class="Student">
                            <li class="PageSubTitle">
                                <asp:Label ID="lbl_PermanentAddress" runat="server" Text="Permanent Address" />
                                <asp:CheckBox ID="check_Address" runat="server" Text="Same as Present Address" OnCheckedChanged="check_Address_CheckedChanged"
                                    AutoPostBack="true" />
                            </li>
                            <li class="FullWidth"></li>
                            <%--Town/City--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentCity" Text="Address Line" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PermanentCity" Height="64px" Width="206px" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Permanent_TownOrCity"
                                    ControlToValidate="txt_PermanentCity" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Landmark--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentLandmark" Text="Landmark" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PermanentLandmark" />
                            </li>
                            <%--District--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentDistrictId" Text="District" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="drpdwn_PermanentDistrictId" runat="server" AutoPostBack="True"
                                    Width="95%" />
                                <%--OnSelectedIndexChanged="drpdwn_PermanentDistrictId_SelectedIndexChanged" --%>
                            </li>
                            <%--State--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentStateName" Text="State" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_PermanentStateName" runat="server" ReadOnly="true" />
                            </li>
                            <%--Country--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentCountry" Text="Country" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_PermanentCountry" runat="server" ReadOnly="true" />
                            </li>
                            <%--Pincode--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentPincode" Text="Pincode" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PermanentPincode" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Permanent_Pincode"
                                    ControlToValidate="txt_PermanentPincode" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                        </ul>
                        <ul class="StudentFullWidth">
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_SubjectTitle" Text="Course Enrollment Details:-" />
                            </li>
                            <li>
                                <ul class="Student">
                                    <%--Class Id--%>
                                    <li class="FormLabel">
                                        <asp:Label runat="server" ID="lbl_CourseId" Text="Course" />
                                    </li>
                                    <li class="FormValue">
                                        <asp:DropDownList ID="drpdwn_CourseId" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpdwn_CourseId_SelectedIndexChanged"
                                            Enabled="False">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_CourseID" ControlToValidate="drpdwn_CourseId"
                                            Display="Dynamic" SetFocusOnError="true" />
                                    </li>
                                </ul>
                                <ul class="Student">
                                    <li class="FormLabel">
                                        <asp:Label runat="server" ID="lbl_StreamID" Text="Stream" />
                                    </li>
                                    <li class="FormValue">
                                        <asp:DropDownList ID="DropDown_StreamList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDown_StreamList_SelectedIndexChanged"
                                            Enabled="False">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_StreamList"
                                            ControlToValidate="DropDown_StreamList" Display="Dynamic" SetFocusOnError="true" />
                                    </li>
                                </ul>
                            </li>
                            <li class="GridView">
                                <asp:GridView runat="server" ID="gview_BindCourse" AutoGenerateColumns="False" AllowSorting="true"
                                    PageSize="15" Width="100%" CssClass="GridView" GridLines="Both" CellPadding="2">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="CheckBox">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk_PreQualID" Visible="true" Checked="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="Label">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_PreQualID" Visible="false" Text='<%# Eval("PreQualID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="StudentID" HeaderText="StudentID" Visible="false" />
                                        <asp:BoundField DataField="QualID" HeaderText="CourseName" />
                                        <asp:BoundField DataField="PassingYear" HeaderText="PassingYear" />
                                        <asp:BoundField DataField="Board" HeaderText="Board" />
                                        <asp:BoundField DataField="Division" HeaderText="Division" />
                                        <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                                    </Columns>
                                    <HeaderStyle CssClass="HeaderStyle" />
                                </asp:GridView>
                            </li>
                            <li>
                                <asp:Panel ID="PnlPrevQual" runat="server">
                                    <ul class="StudentFullWidth">
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
                                            <asp:DropDownList runat="server" ID="ddl_Qualification" />
                                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Qualification"
                                                ControlToValidate="ddl_Qualification" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <!--Passing Year -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_PassingYear" Text="Passing Year :" />
                                            <%--<asp:Label runat="server" ID="Label20" Text="*" CssClass="ValidationColor" />--%>
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PassingYear" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PassingYear"
                                                ControlToValidate="txt_PassingYear" Display="Dynamic" />
                                        </li>
                                        <!--Board Or University-->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_Board" Text="Board Or University :" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_Board" />
                                        </li>
                                        <!--Division-->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_Division" Text="Division :" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_Division" />
                                        </li>
                                        <!--Percentage of Marks-->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_Percentage" Text="Percentage :" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_Percentage" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Percentage"
                                                ControlToValidate="txt_Percentage" Display="Dynamic" />
                                            <asp:Button runat="server" ID="btn_AddQual" CausesValidation="false" Text="Add Qualification "
                                                OnClick="btn_AddQual_Click" />
                                        </li>
                                        <li class="GridView">
                                            <asp:GridView runat="server" ID="gview_Course" AutoGenerateColumns="True" AllowPaging="true"
                                                AllowSorting="true" PageSize="15" Width="98%" CssClass="GridView" GridLines="Both"
                                                CellPadding="2">
                                                <HeaderStyle CssClass="HeaderStyle" />
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
                                </asp:Panel>
                            </li>
                        </ul>
                        <ul id="Button1" class="StudentFullWidth">
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_ViewList1" runat="server" Text="<<< View Apply List" CausesValidation="false" OnClick="btn_View_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btn_MoveNext1" runat="server" Text=" Click Here For Admission >>> "
                                    CausesValidation="true" OnClick="btn_MoveNext1_Click" />

                                <%--<asp:Button ID="Button3" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_reset_Click" />--%>
                            </li>
                        </ul>
                    </div>
                </asp:View>
                <asp:View ID="View_LeaveDetails" runat="server">
                    <ul class="StudentFullWidth">
                        <li class="PageSubTitle">
                            <asp:Label ID="lbl_AdministrativeDetails" runat="server" Text="Administrative Details" />
                        </li>
                        <%--MRI No.--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_MRINo" Text="MRI No " />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_MRINo" />
                        </li>

                        <%--TC No.--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_TCNo" Text="TC No" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_TCNo" />
                        </li>
                        <%--Date Of Leaving--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_DateOfLeaving" Text="Date Of Leaving " />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_DateOfLeaving" />
                            <asp:ImageButton runat="server" ID="imgbtn_DateOfLeaving" CausesValidation="false"
                                ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                Height="21" Width="21" />
                            <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_dateofleaving"
                                PopupButtonID="imgbtn_DateOfLeaving" CssClass="MicroCalendar" TargetControlID="txt_DateOfLeaving" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DateOfLeaving"
                                ControlToValidate="txt_DateOfLeaving" CssClass="ValidateMessage" Display="Dynamic"
                                SetFocusOnError="true" ValidationGroup="non" />
                        </li>
                        <%--Status--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Status" Text="Status " />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_Status" />
                        </li>

                        <li class="FormButton_Top">
                            <asp:Button ID="btn_Submit2" runat="server" Text=" Save "
                                CausesValidation="true" OnClick="btn_Submit_Click" />
                            <asp:Button ID="Button5" runat="server" Text="View" CausesValidation="false" OnClick="btn_View_Click" />
                            <asp:Button ID="Button6" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_reset_Click" />
                        </li>
                    </ul>
                </asp:View>
                <asp:View ID="View_Admision" runat="server">

                    <ul class="StudentFullWidth">
                        <li class="PageSubTitle">
                            <asp:Label ID="lbl_AdmissionDetail" runat="server" Text="Administrative Details" />
                        </li>
                        <%--Admission To--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lblAdmissionTo" Text="Admission To :" />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList ID="DropDown_AdmissionTo" runat="server" Enabled="False" />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_AdmissionTo"
                                runat="server" ControlToValidate="DropDown_AdmissionTo"
                                CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                        </li>

                        <%-- Roll No.--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_RollNo" Text="Roll No " />
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator_RollNo" Text="*" runat="server" 
										  ErrorMessage="Roll No should not be Empty" ControlToValidate="txt_RollNo"/>--%>
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_RollNo" Text=" " />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_RollNo" ControlToValidate="txt_RollNo"
                                CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid RollNo" SetFocusOnError="true" />
                        </li>
                        <%--Receipt No.--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_ReceiptNo" Text="Receipt No " />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_ReceiptNo" Text=" " />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_ReceiptNo"
                                runat="server" ControlToValidate="txt_ReceiptNo"
                                CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <%--Date Of Addmission--%>

                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_DateOfAdmission" Text="Date Of Admission " />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_DateOfAdmission" AutoPostBack="true" />
                            <asp:ImageButton runat="server" ID="imgbtn_DateOfAdmission" CausesValidation="false"
                                ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                Height="21" Width="21" />
                            <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_dateofadmission"
                                PopupButtonID="imgbtn_DateOfAdmission" CssClass="MicroCalendar" TargetControlID="txt_DateOfAdmission" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DateOfAdmission"
                                ControlToValidate="txt_DateOfAdmission" CssClass="ValidateMessage" Display="Dynamic"
                                SetFocusOnError="true" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DateOFAdmission"
                                ControlToValidate="txt_DateOfAdmission" CssClass="ValidateMessage" Display="Dynamic"
                                ErrorMessage="Invalid Date" />
                        </li>
                        <%--Total Fees Paid--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_TotalFeesPaid" Text="Total Fees Paid " />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox ID="txt_AdmissionAmount" runat="server" ReadOnly="true" Font-Size="Large" CssClass="FeesPaid" Text="0.00"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_AdmissionAmount"
                                runat="server" ControlToValidate="txt_AdmissionAmount" CssClass="ValidateMessage"
                                Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <li class="StudentFullWidth">
                            <asp:Button runat="server" ID="btnCheckAll" Text="Select All Fees" OnClick="btnCheckAll_Click" CssClass="BtnFeesPaid" />
                            <asp:GridView ID="gridview_DefaultFee" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="GridView" Width="98%">
                                <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="CheckBox" HeaderText="Check Fee">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chk_DefaultFe" Visible="true"
                                                AutoPostBack="True" OnCheckedChanged="chk_DefaultFe_CheckedChanged" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle CssClass="CheckBox" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sno
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Slno" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Left" />

                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-CssClass="QualsID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_QualificationID" Text='<%# Eval("Slno") %>' Visible="false" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle CssClass="QualsID" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AccountID" HeaderText="AccountID"
                                        Visible="true">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACCOUNT_CODE" HeaderText="Account Code" Visible="true">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QUALIFICATION" HeaderText="Qualification"
                                        Visible="true">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="STREAM" HeaderText="Stream" Visible="true">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACCOUNT_NAME" HeaderText="Account Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DefaultFee" HeaderText="Fee">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                    Mode="NumericFirstLast" />
                                <PagerStyle CssClass="MicroPagerStyle" />
                            </asp:GridView>
                        </li>

                        <li class="FormButton_Top">
                            <asp:Button ID="btn_Previous" runat="server" Text="<<< Previous "
                                CausesValidation="true" OnClick="btn_Previous_Click" />
                            &nbsp;
                                <asp:Button ID="btn_Next" runat="server" Text="Next >>> " CausesValidation="true" OnClick="btn_Next_Click" />
                        </li>

                    </ul>
                </asp:View>
                <asp:View ID="View_SubjectEdition" runat="server">


                    <ul id="Ul2" class="StudentFullWidth">
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_Submit" runat="server" Text=" Save " CausesValidation="true"
                                OnClick="btn_Submit_Click" />
                            <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" OnClick="btn_View_Click" />&nbsp; &nbsp;
                                <asp:Button ID="btn_BackAdmission" runat="server" Text="<<< Back To Admission"
                                    CausesValidation="false" OnClick="btn_BackAdmission_Click" />
                        </li>
                    </ul>
                    <h1>Assign Subjects To The Students As Per He Selected :- </h1>

                    <ul class="StudentFullWidth">
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="lbl_chooseComplsory"
                                Text="Assign Compulsory Subjects" />
                        </li>
                        <li class="FormValue">
                            <div class="SubjectList">
                                <asp:CheckBoxList runat="server" ID="chk_ChooseCompulsory" RepeatDirection="Horizontal"
                                    CssClass="SmallFontSubjectDetails"
                                    CellPadding="1">
                                </asp:CheckBoxList>
                            </div>
                        </li>
                    </ul>
                    <asp:MultiView ID="MultiView_Choosesub" runat="server">
                        <asp:View ID="View_ChooseElactive" runat="server">
                            <ul class="StudentFullWidth">
                                <li class="PageSubTitle">
                                    <asp:Label runat="server" ID="Label4" Text="Assign Elective Subjects" />
                                    <asp:Label runat="server" ID="lbl_MaxSub_elective" />
                                </li>
                                <li class="FormValue">
                                    <div>
                                        <asp:CheckBoxList runat="server" ID="chk_chooseElective" RepeatDirection="Horizontal"
                                            CssClass="SmallFontSubjectDetails" Width="100%">
                                        </asp:CheckBoxList>
                                    </div>
                                </li>
                            </ul>
                        </asp:View>
                        <asp:View ID="View_Choosemajorminor" runat="server">
                            <ul class="StudentSubjects">
                                <li class="PageSubTitle">
                                    <asp:Label runat="server" ID="Label6" Text="Assign Major Elective Subjects" />
                                    <asp:Label runat="server" ID="lblmaxmajor" />
                                </li>
                                <li class="FormValue">
                                    <div class="SubjectList">
                                        <asp:CheckBoxList runat="server" ID="chk_choosemajor" RepeatDirection="Horizontal"
                                            CssClass="SmallFontSubjectDetails">
                                        </asp:CheckBoxList>
                                    </div>
                                </li>
                            </ul>
                            <ul class="StudentSubjects">
                                <li class="PageSubTitle">
                                    <asp:Label runat="server" ID="Label8" Text="Assign Minor Elective Subjects" />
                                    <asp:Label runat="server" ID="lblmaxminor" />
                                </li>
                                <li class="FormValue">
                                    <div class="SubjectList">
                                        <asp:CheckBoxList runat="server" ID="chk_chooseminor" RepeatDirection="Horizontal"
                                            CssClass="SmallFontSubjectDetails">
                                        </asp:CheckBoxList>
                                    </div>
                                </li>
                                <li class="FullWidth"></li>
                            </ul>
                        </asp:View>
                    </asp:MultiView>
                    <asp:Panel runat="server" class="StudentfullWidth" ID="pnl_ChooseHonsPass" Visible="False">
                        <ul class="StudentSubjects">
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_ChooseHons" Text="Assign Hons. Subjects" />
                                <asp:Label runat="server" ID="lblhonsmax" />
                            </li>
                            <li class="FormValue">
                                <div class="SubjectList">
                                    <asp:CheckBoxList runat="server" ID="chk_chooseHons" RepeatDirection="Horizontal"
                                        CssClass="SmallFontSubjectDetails"
                                        Width="100%">
                                    </asp:CheckBoxList>
                                </div>
                            </li>
                        </ul>
                        <ul class="StudentSubjects">
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="Label12" Text="Assign Pass Subjects" />
                                <asp:Label runat="server" ID="lblpassmax" />
                            </li>
                            <li class="FormValue">
                                <div class="SubjectList">
                                    <asp:CheckBoxList runat="server" ID="chk_choosepass" RepeatDirection="Horizontal"
                                        CssClass="SmallFontSubjectDetails"
                                        Width="100%">
                                    </asp:CheckBoxList>
                                </div>
                            </li>
                            <li class="FullWidth"></li>
                        </ul>
                    </asp:Panel>
                    <ul id="Ul3" class="StudentFullWidth">
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_Submit1" runat="server" Text=" Save "
                                CausesValidation="true" OnClick="btn_Submit_Click" />
                            <asp:Button ID="Button2" runat="server" Text="View" CausesValidation="false" OnClick="btn_View_Click" />
                            &nbsp;&nbsp;
                                <asp:Button ID="btnBackAdmission1" runat="server" Text="<<< Back To Admission"
                                    CausesValidation="false" OnClick="btnBackAdmission1_Click" />
                        </li>
                    </ul>

                </asp:View>
                <asp:View ID="View_Grid" runat="server">
                    <tsdc:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Student(s), where:" />
                    <ul class="StudentFullWidth">
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_AddNew" runat="server" Text="Add New"
                                OnClick="btn_AddNew_Click" Visible="False" />
                        </li>
                        <li style="width: 100%; display: block; float: left;"></li>
                        <li class="GridView">
                            <asp:GridView ID="gridview_Students" runat="server" AllowPaging="True" AllowSorting="True"
                                PageSize="22" AutoGenerateColumns="False" CssClass="GridView"
                                CellPadding="2" Width="98%" OnRowCommand="gridview_Students_RowCommand" OnRowDeleting="gridview_Students_RowDeleting"
                                OnRowEditing="gridview_Students_RowEditing" OnRowDataBound="gridview_Students_RowDataBound"
                                OnPageIndexChanging="gridview_Students_PageIndexChanging">
                                <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="StudentId" Visible="False">
                                        <HeaderTemplate>
                                            StudentID
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_StudentId" Text='<%# Eval("StudentId") %>' Visible="false" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="StudentId" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            SL No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Slno" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DateOfAdmission" HeaderText="DOA" />
                                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                    <asp:BoundField DataField="StudentCode" HeaderText="Student Code" />
                                    <%--<asp:BoundField DataField="EMailID" HeaderText="EMail ID" />--%>
                                    <asp:BoundField DataField="QualID" HeaderText="Course" />
                                    <asp:BoundField DataField="StreamID" HeaderText="Stream" />
                                    <%--<asp:BoundField DataField="Gender" HeaderText="Gender" />
													 <asp:BoundField DataField="Caste" HeaderText="Caste" />
													 <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
													 <asp:BoundField DataField="MotherName" HeaderText="Mother Name" />--%>
                                    <%--   <asp:BoundField DataField="LandPhoneNumber" HeaderText="Phone Number" />--%>
                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                    <%--<asp:BoundField DataField="MRINO" HeaderText="MRI NO" />
													 <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No" />
													 <asp:BoundField DataField="TCNo" HeaderText="TC No" />--%>
                                    <%--<asp:BoundField DataField="DateOfLeaving" HeaderText="Date Of Leaving" />--%>
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:CommandField ShowEditButton="True" HeaderText="Admission" ButtonType="Image" EditImageUrl="~/Themes/Common/Images/Admission.jpg">
                                        <ControlStyle CssClass="EditLink" />
                                        <ItemStyle CssClass="EditLinkItem" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:CommandField>
                                    <%--<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico"
                                        ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
                                        <ControlStyle CssClass="DeleteLink" />
                                        <ItemStyle CssClass="DeleteLinkItem" />
                                    </asp:CommandField>--%>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:Button ID="deletebtn" runat="server" CommandName="Delete"
                                                Text="Delete" OnClientClick="return confirm('Are you sure?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico"
                                        ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                        <ControlStyle CssClass="ViewLink" />
                                        <ItemStyle CssClass="ViewLinkItem" />
                                    </asp:CommandField>
                                </Columns>
                                <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                    Mode="NumericFirstLast" />
                                <PagerStyle CssClass="MicroPagerStyle" />
                            </asp:GridView>
                        </li>
                    </ul>
                </asp:View>
            </asp:MultiView>
            <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground"
                Style="display: none" CssClass="modalPopup" EnableViewState="true">
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
                <div class="UpdateProgressArea">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
