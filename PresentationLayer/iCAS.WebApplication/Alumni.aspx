<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Alumni.aspx.cs" Inherits="Micro.WebApplication.Alumni" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">

    <asp:UpdatePanel runat="server" ID="updatepanel_StudentMaster">
        <ContentTemplate>


            <asp:MultiView ID="Student_Multi" runat="server">
                <!-- input VIEW -->
                <asp:View ID="InputControls" runat="server">
                    <h1 class="PageTitle">
                        <asp:Literal runat="server" ID="lit_PageTitle" Text="TSD College Alumni Regisration:- " />
                    </h1>

                    <div>

                        <ul class="Student">
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_PersonalDetails" Text="Alumni's Academic Details:" />
                            </li>

                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lblAdmissionYear" Text="Please select the Year of your Admission to The College:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_AcademicYear" runat="server" Width="70%" AutoPostBack="True" OnSelectedIndexChanged="ddl_AcademicYear_SelectedIndexChanged" />
                            </li>

                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label1" Text="Please select the Year of Passing / Leaving The College:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_PassingYear" runat="server" Width="70%" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lblRegdNo" Text="Specify the Registration No. (ref. your certificate pls.):" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_RegdNo" Width="69%" />
                                <ajax:TextBoxWatermarkExtender runat="server" ID="txtWater_RegdNo" WatermarkText="Please Enter Your Registration Number" TargetControlID="txt_RegdNo" WatermarkCssClass="TextBoxWatermarkExtender" />
                            </li>

                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="Label2" Text="Alumni's Personal Details:" />
                            </li>
                            <%--CurrentProfession Id--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_CurrentProfession" Text="Current Profession :" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_CurrentProfession" Width="69%" />
                                <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender1" WatermarkText="Teachership, IT, Business etc. " TargetControlID="txt_CurrentProfession" WatermarkCssClass="TextBoxWatermarkExtender" />
                                <%--<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator1" ControlToValidate="txt_CurrentProfesscion" Display="Dynamic" SetFocusOnError="true"  ErrorMessage="Please tell us your profession."/>--%>
                            </li>


                            <%-- --Student Name----%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StudentName" Text="Student / Alumni's Name:" />
                                <asp:Label runat="server" ID="Label20" Text="*" CssClass="ValidationColor" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="drpdwn_Salutation" Width="12%" />
                                <asp:TextBox runat="server" ID="txt_StudentName" Width="56%" />
                                <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender2" WatermarkText="Please Enter Your Full Name Here" TargetControlID="txt_StudentName" WatermarkCssClass="TextBoxWatermarkExtender" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Name" ControlToValidate="txt_StudentName" Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Name" ControlToValidate="txt_StudentName" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Date of Birth--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_DateOfBirth" Text="Date Of Birth: " />
                                <asp:Label runat="server" ID="Label4" Text="*" CssClass="ValidationColor" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_DateOfBirth" AutoPostBack="true" OnTextChanged="txt_DateOfBirth_TextChanged" Width="46%" />
                                <asp:ImageButton runat="server" ID="imgbtn_DateOfBirth" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                                <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_dob" PopupButtonID="imgbtn_DateOfBirth" CssClass="MicroCalendar" TargetControlID="txt_DateOfBirth" />

                                <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender3" WatermarkText="Example: 10-Aug-1975" TargetControlID="txt_DateOfBirth" WatermarkCssClass="TextBoxWatermarkExtender" />

                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DateOfBirth" ControlToValidate="txt_DateOfBirth" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Date of Birth or Age must be given" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DateOfBirth" ControlToValidate="txt_DateOfBirth" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Date" />

                                <%--<div id="Age">--%>


                                <asp:Label runat="server" ID="lbl_Age" Text=": Age: " />

                                <asp:TextBox runat="server" ID="txt_Age" AutoPostBack="True" OnTextChanged="txt_Age_TextChanged" ReadOnly="True" Width="30px" />
                                <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Age" ControlToValidate="txt_Age" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Age" SetFocusOnError="true" />
                                <asp:RangeValidator runat="server" ID="rangeValidator_Age" ControlToValidate="txt_Age" Display="Dynamic" SetFocusOnError="true" Type="Integer" />--%>


                                <%--</div>--%>
                            </li>
                            <%--  Father Name--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_FatherNmae" Text="Father's Name: " />
                                <asp:Label runat="server" ID="Label5" Text="*" CssClass="ValidationColor" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_FatherName" Width="69%" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_FatherName" ControlToValidate="txt_FatherName" CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_FatherName" ControlToValidate="txt_FatherName" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Mother Name--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_MotherName" Text="Mother's Name: " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_MotherName" Width="69%" />
                                <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_MotherName" ControlToValidate="txt_MotherName" CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />--%>
                                <%--<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_MotherName" ControlToValidate="txt_MotherName" Display="Dynamic" SetFocusOnError="true" />--%>
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Gender" Text="Gender:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="drpdwn_Gender" runat="server" />


                                <asp:Label runat="server" ID="lbl_Caste" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Caste " />
                                <asp:DropDownList ID="drpdwn_Caste" runat="server">
                                    <asp:ListItem>General</asp:ListItem>
                                    <asp:ListItem>OBC</asp:ListItem>
                                    <asp:ListItem>SC</asp:ListItem>
                                    <asp:ListItem>ST</asp:ListItem>
                                </asp:DropDownList>
                            </li>

                            <%-- Life Member--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PHStatus" Text="Whether interested to be a Yearly/Life Member? " />
                            </li>
                            <li class="FormValue">
                                <asp:RadioButtonList ID="radio_LifeMember" runat="server" RepeatLayout="UnorderedList">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                            </li>


                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="Label10" Text="Alumni's Communication Details:" />
                            </li>

                            <%--Email Id--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_EmailId" Text="Email Address: " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_EmailId" Width="69%" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_EmailId" ControlToValidate="txt_EmailId" Display="Dynamic" SetFocusOnError="true" />
                            </li>


                            <%--Mobile--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Mobile" Text="Mobile Phone No.:" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_Mobile" Width="23%" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_MobileNo" ControlToValidate="txt_Mobile" Display="Dynamic" SetFocusOnError="true" />


                                <asp:Label runat="server" ID="lbl_PhoneNumber" Text="Land Phone No.: " />
                                <asp:TextBox runat="server" ID="txt_PhoneNumber" Width="23%" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PhoneNumber" ControlToValidate="txt_PhoneNumber" Display="Dynamic" SetFocusOnError="true" />

                            </li>

                            <%--<li class="PageSubTitle">
                                <asp:Label runat="server" ID="Label2" Text="Communication Details : " />
                            </li>--%>

                            <li class="FormLabel"></li>
                            <li class="FormValue"></li>
                        </ul>

                        <ul class="Student50pc">
                            <li class="PageSubTitle">
                                <asp:Label ID="lbl_PresentAddress" runat="server" Text="Present / Office Address:" />
                                <asp:Label runat="server" ID="Label6" Text="*" CssClass="ValidationColor" />
                            </li>

                            <%--Town/City--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentCity" Text="Address Line: " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PresentCity" Height="30px" Width="100%" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Present_TownOrCity" ControlToValidate="txt_PresentCity" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Landmark--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentLandmark" Text="Landmark: " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PresentLandmark" Width="100%" />
                            </li>
                            <%--District--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label8" Text="*" CssClass="ValidationColor" />
                                <asp:Label runat="server" ID="lbl_PresentDistrictId" Text="District, State, Country: " />

                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="drpdwn_PresentDistrictId" runat="server" Width="100%" /><%-- AutoPostBack="True" OnSelectedIndexChanged="drpdwn_PresentDistrictId_SelectedIndexChanged" --%>
                            </li>
                            <div style="display: none;">
                                <%--State--%>
                                <li class="FormLabel">
                                    <asp:Label runat="server" ID="lbl_PresentStateName" Text="State" />
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_PresentStateName" runat="server" ReadOnly="true" Width="100%" />
                                </li>
                                <%--Country--%>
                                <li class="FormLabel">
                                    <asp:Label runat="server" ID="lbl_PresentCountry" Text="Country" />
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_PresentCountry" runat="server" ReadOnly="true" Width="100%" />
                                </li>
                            </div>
                            <%--Pincode--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PresentPincode" Text="Pincode" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PresentPincode" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Present_Pincode" ControlToValidate="txt_PresentPincode" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                        </ul>
                        <ul class="Student50pc">
                            <li class="PageSubTitle">
                                <asp:Label ID="lbl_PermanentAddress" runat="server" Text="Permanent Address" />
                                <asp:Label runat="server" ID="Label9" Text="*" CssClass="ValidationColor" />
                                <asp:CheckBox ID="check_Address" runat="server" Text="Same as Present Address" OnCheckedChanged="check_Address_CheckedChanged" AutoPostBack="true" CssClass="SameAsPresentAddress" Checked="false" />
                            </li>
                            <li class="FullWidth"></li>
                            <%--Town/City--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentCity" Text="Address Line: " Width="100%" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PermanentCity" Height="30px" Width="100%" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Permanent_TownOrCity" ControlToValidate="txt_PermanentCity" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Landmark--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentLandmark" Text="Landmark: " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PermanentLandmark" Width="100%" />
                            </li>
                            <%--District--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label7" Text="*" CssClass="ValidationColor" />
                                <asp:Label runat="server" ID="lbl_PermanentDistrictId" Text="District, State, Country: " />

                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="drpdwn_PermanentDistrictId" runat="server" Width="100%" />
                                <%--AutoPostBack="True" OnSelectedIndexChanged="drpdwn_PermanentDistrictId_SelectedIndexChanged"--%>
                            </li>
                            <div style="display: none;">
                                <%--State--%>
                                <li class="FormLabel">
                                    <asp:Label runat="server" ID="lbl_PermanentStateName" Text="State" />
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_PermanentStateName" runat="server" ReadOnly="true" Width="100%" />
                                </li>
                                <%--Country--%>
                                <li class="FormLabel">
                                    <asp:Label runat="server" ID="lbl_PermanentCountry" Text="Country" />
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_PermanentCountry" runat="server" ReadOnly="true" Width="100%" />
                                </li>
                            </div>
                            <%--Pincode--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PermanentPincode" Text="Pincode" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PermanentPincode" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Permanent_Pincode" ControlToValidate="txt_PermanentPincode" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                        </ul>
                        <div style="display: none">
                            <ul class="StudentSubjectsFullWidthRow">
                                <li class="PageSubTitle">

                                    <ul>
                                        <li>

                                            <asp:Label runat="server" ID="lbl_SubjectTitle" Text="Please Tick your choice of the Subjects for the " />
                                        </li>
                                        <li>
                                            <asp:Label runat="server" ID="lbl_CourseId" Text="Course :- " />

                                        </li>
                                        <li>
                                            <asp:DropDownList ID="drpdwn_CourseId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpdwn_CourseId_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </li>
                                        <li>
                                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_CourseID" ControlToValidate="drpdwn_CourseId" Display="Dynamic" SetFocusOnError="true" />--%>
                                            <asp:Label runat="server" ID="lbl_StreamID" Text="Stream: -" />

                                        </li>
                                        <li>
                                            <asp:DropDownList ID="DropDown_StreamList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDown_StreamList_SelectedIndexChanged" Enabled="False">
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_StreamList" ControlToValidate="DropDown_StreamList" Display="Dynamic" SetFocusOnError="true" />--%>
                            
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                            <ul class="StudentSubjectsFullWidthRow">
                                <li class="PageSubSubTitle">
                                    <asp:Label runat="server" ID="lbl_Compulsorysubjects" Text="Compulsory Subjects:" />
                                </li>
                                <li class="FormValueFullWidth">
                                    <asp:CheckBoxList runat="server" ID="chklist_CompulsorySubjectLists" CssClass="SmallFontSubjectDetails" RepeatLayout="OrderedList" />
                                </li>
                                <li>
                                    <asp:MultiView ID="MultiView_Subjects" runat="server">
                                        <asp:View ID="View_Elective" runat="server">
                                            <ul class="StudentFullWidth">
                                                <li class="PageSubSubTitle">
                                                    <asp:Label runat="server" ID="lbl_ElectiveSubjects" Text="Elective Subjects" /><asp:Label runat="server" ID="lbl_MaxCount" Text="" />
                                                </li>
                                                <li class="FormValueFullWidth">
                                                    <asp:CheckBoxList runat="server" ID="chklist_ElectiveSubjectsBind" CssClass="SmallFontSubjectDetails" RepeatLayout="OrderedList" />
                                                </li>
                                            </ul>
                                        </asp:View>
                                        <asp:View ID="View_MajorMinorElective" runat="server">
                                            <ul class="StudentSubjects">
                                                <li class="PageSubSubTitle">
                                                    <asp:Label runat="server" ID="lbl_Elective" Text="Major Elective Subjects" />
                                                    <asp:Label runat="server" ID="lbl_MajorMaxCount" Text="" />
                                                </li>
                                                <li class="FormValueFullWidth">

                                                    <asp:CheckBoxList runat="server" ID="chklist_MajorElectiveSubjects" CssClass="SmallFontSubjectDetails" RepeatLayout="OrderedList" />

                                                </li>
                                            </ul>
                                            <ul class="StudentSubjects">
                                                <li class="PageSubSubTitle">
                                                    <asp:Label runat="server" ID="lbl_ChooseMinorSubjects" Text="Minor Elective Subjects" /><asp:Label runat="server" ID="lbl_MinorMaxCount" Text="" />
                                                </li>
                                                <li class="FormValueFullWidth">
                                                    <asp:CheckBoxList runat="server" ID="chklist_MinorSubject" CssClass="SmallFontSubjectDetails" RepeatLayout="OrderedList" />
                                                </li>
                                                <li class="FullWidth"></li>
                                            </ul>
                                        </asp:View>
                                    </asp:MultiView>
                                    <asp:Panel runat="server" class="StudentfullWidth" ID="PanelHonsPass" Visible="False">
                                        <ul class="StudentFullWidth">
                                            <li class="PageSubSubTitle">
                                                <asp:Label runat="server" ID="lbl_HonsSubjects" Text="Hons. Subjects" /><asp:Label runat="server" ID="lbl_HonsMaxCount" Text="" />
                                            </li>
                                            <li class="FormValueFullWidth">
                                                <asp:CheckBoxList runat="server" ID="chklist_HonsSubjects" CssClass="SmallFontSubjectDetails" RepeatLayout="OrderedList" />
                                            </li>
                                        </ul>
                                        <ul class="StudentFullWidth">
                                            <li class="PageSubSubTitle">
                                                <asp:Label runat="server" ID="lbl_PassSubjects" Text="Pass Subjects" /><asp:Label runat="server" ID="lbl_PassMaxCount" Text="" />
                                            </li>
                                            <li class="FormValueFullWidth">
                                                <asp:CheckBoxList runat="server" ID="chklistPassSubjects" CssClass="SmallFontSubjectDetails" RepeatLayout="OrderedList" />
                                            </li>
                                            <li class="FullWidth"></li>
                                        </ul>
                                    </asp:Panel>
                                </li>
                            </ul>


                            <ul class="EducationalQualification">
                                <!-- Education Details PageSubTitle -->
                                <li class="PageSubTitle">
                                    <asp:Label runat="server" ID="Label3" Text="Educational Qualification:" />
                                </li>
                                <asp:Panel ID="pnlStPreQual" runat="server">
                                    <%--<ul class="StudentFullWidth">--%>
                                    <!-- Qualification -->
                                    <li class="FormLabel_EQ">
                                        <asp:Label runat="server" ID="lbl_Qualification" Text="Qualification:" />
                                        <%--<asp:Label runat="server" ID="Label19" Text="*" CssClass="ValidationColor" />--%>
                                    </li>
                                    <!--Passing Year -->
                                    <li class="FormLabel_EQ">
                                        <asp:Label runat="server" ID="lbl_PassingYear" Text="Passing Year :" />
                                        <%--<asp:Label runat="server" ID="Label20" Text="*" CssClass="ValidationColor" />--%>
                                    </li>
                                    <!--Board Or University-->
                                    <li class="FormLabel_EQ">
                                        <asp:Label runat="server" ID="lbl_Board" Text="Board Or University :" />
                                    </li>
                                    <!--Division-->
                                    <li class="FormLabel_EQ">
                                        <asp:Label runat="server" ID="lbl_Division" Text="Division :" />
                                    </li>
                                    <!--Percentage of Marks-->
                                    <li class="FormLabel_EQ">
                                        <asp:Label runat="server" ID="lbl_Percentage" Text="Percentage :" />
                                    </li>
                                    <li class="FormValue_EQ">
                                        <asp:DropDownList runat="server" ID="ddl_Qualification" />
                                        <%--<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Qualification" ControlToValidate="ddl_Qualification" Display="Dynamic" SetFocusOnError="true" />--%>
                                    </li>
                                    <li class="FormValue_EQ">
                                        <asp:TextBox runat="server" ID="txt_PassingYear" />
                                        <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PassingYear" ControlToValidate="txt_PassingYear" Display="Dynamic" />
                                    </li>
                                    <li class="FormValue_EQ">
                                        <asp:TextBox runat="server" ID="txt_Board" />
                                    </li>
                                    <li class="FormValue_EQ">
                                        <asp:TextBox runat="server" ID="txt_Division" />
                                    </li>
                                    <li class="FormValue_EQ">
                                        <asp:TextBox runat="server" ID="txt_Percentage" />
                                        <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Percentage" ControlToValidate="txt_Percentage" Display="Dynamic" />
                                    </li>
                                    <li class="FormValue_EQ_Btn">
                                        <asp:Button runat="server" ID="btn_AddQual" CausesValidation="false" Text="Add Qualification " OnClick="btn_AddQual_Click" />
                                    </li>
                                    <li class="GridView">
                                        <asp:GridView runat="server" ID="gview_Course" AutoGenerateColumns="True" AllowPaging="true" AllowSorting="true" PageSize="15" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2">
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
                                </asp:Panel>
                            </ul>
                            <ul class="StudentSubjectsFullWidthRow">

                                <li class="GridView">
                                    <asp:GridView runat="server" ID="gview_BindCourse" AutoGenerateColumns="False" AllowSorting="true" PageSize="15" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2">
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
                            </ul>
                        </div>

                        <ul class="StudentSubjectsFullWidthRow">
                            <li class="Spacer" />
                            <li>
                                <asp:CheckBox runat="server" Font-Bold="true" ID="chk_Agree" Text="&nbsp; &nbsp; I hereby declare that the information given above is true to the best of my knowledge and belief. That I further undertake to abide by the rules and regulation as laid down from time to time in the bye-law of the association." Checked="true" />
                                <br />
                                <br />
                                <asp:Label runat="server" ID="lbl_Note" Text="* indicates mandatory field. it can't be left blank." CssClass="ValidationColor" />
                            </li>

                            <li id="FormButton">
                                <asp:Button ID="btn_Submit" runat="server" Text=" Save " CausesValidation="true" OnClick="btn_Submit_Click" />

                                <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" OnClick="btn_View_Click" />

                                <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_reset_Click" />
                            </li>
                        </ul>
                    </div>
                </asp:View>

                <!--############################################################ grid VIEW ################################-->
                <asp:View ID="View_Grid" runat="server">
                    <ul class="StudentFullWidth">
                        <li>
                            <h1 class="PageTitle">
                                <asp:Literal runat="server" ID="Literal1" Text="Alumnus of TSD College:- " />
                            </h1>
                        </li>
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_AddNew" runat="server" Text="Add New" OnClick="btn_AddNew_Click" />
                        </li>
                        <li class="GridView">
                            <asp:GridView ID="gridview_Students" runat="server" AllowPaging="True" AllowSorting="True"
                                PageSize="25" AutoGenerateColumns="False"
                                CssClass="GridView" GridLines="Both"
                                CellPadding="2" Width="98%" OnRowCommand="gridview_Students_RowCommand" OnRowDeleting="gridview_Students_RowDeleting" OnRowEditing="gridview_Students_RowEditing" OnRowDataBound="gridview_Students_RowDataBound" OnPageIndexChanging="gridview_Students_PageIndexChanging">
                                <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>


                                    <asp:TemplateField ItemStyle-CssClass="StudentId" Visible="False">
                                        <HeaderTemplate>
                                            StudentID
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chk_EstablishmentID" Visible="true" AutoPostBack="true" />
                                            <asp:Label runat="server" ID="lbl_StudentId" Text='<%# Eval("StudentId") %>' Visible="false" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="StudentId" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sno
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Slno" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                    <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" />
                                    <asp:BoundField DataField="RegistrationNumber" HeaderText="Regd No" />
                                    <asp:BoundField DataField="EMailID" HeaderText="EMail ID" />
                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                    <asp:BoundField DataField="DateOfAdmission" Visible="true" HeaderText="Date Of Admission" />
                                    <%--<asp:BoundField DataField="StudentCode" HeaderText="Student Code" />
                                    <asp:BoundField DataField="AlumniPresentOccupation" HeaderText="Occupation" />
                                    <asp:BoundField DataField="Address_Present_TownOrCity" HeaderText="Present_TownOrCity" />
                                    --%>


                                    <%--<asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" />--%>
                                    <%--<asp:BoundField DataField="Age" HeaderText="Age" />--%>
                                    <%--<asp:BoundField DataField="Gender" HeaderText="Gender" />
													 <asp:BoundField DataField="Caste" HeaderText="Caste" />
													 <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
													 <asp:BoundField DataField="MotherName" HeaderText="Mother Name" />--%>
                                    <%--   <asp:BoundField DataField="LandPhoneNumber" HeaderText="Phone Number" />
                                    --%>
                                    <%--<asp:BoundField DataField="MRINO" HeaderText="MRI NO" />
													 <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No" />
													 <asp:BoundField DataField="TCNo" HeaderText="TC No" />--%>
                                    <%--<asp:BoundField DataField="DateOfLeaving" HeaderText="Date Of Leaving" />--%>
                                    <%--<asp:BoundField DataField="Status" HeaderText="Status" />--%>
                                    <%--<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico"
                                        ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
                                        <ControlStyle CssClass="EditLink" />
                                        <ItemStyle CssClass="EditLinkItem" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico"
                                        ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
                                        <ControlStyle CssClass="DeleteLink" />
                                        <ItemStyle CssClass="DeleteLinkItem" />
                                    </asp:CommandField>--%>
                                    <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                        <ControlStyle CssClass="ViewLink" />
                                        <ItemStyle CssClass="ViewLinkItem" />
                                    </asp:CommandField>
                                </Columns>
                                <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <PagerStyle CssClass="MicroPagerStyle" />
                            </asp:GridView>
                        </li>
                    </ul>
                </asp:View>

                <!--############################################################ details VIEW ################################-->
                <asp:View ID="View_detail_Student" runat="server">
                    <h1 class="PageTitle">
                        <asp:Literal runat="server" ID="lit_CurrentStudentInfo" Text="Alumni Information :-" />
                    </h1>
                    <asp:Literal ID="lit_StudentDetail" runat="server" />
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

            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                <ProgressTemplate>
                    <div id="UpdateProgress">
                        <div class="UpdateProgressArea">
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
         
    </script>

</asp:Content>
