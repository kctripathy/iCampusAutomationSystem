<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="ExamSchedules.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.ExamSchedules" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Exam Schedule:-" />
    </h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_ExamSeduleMaster">    
        <ContentTemplate>
            <div>                
                <asp:MultiView ID="Examschedule_Multi" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>
                         <li class="FormButton_Top">
                            <asp:Button ID="btn_Submit" runat="server" Text=" Save " CausesValidation="true"  OnClick="btn_Submit_Click" />
                             <%--<asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" OnClick="btn_View_Click" />--%>
                             <asp:Button ID="btn_View" runat="server" CausesValidation="false" OnClick="btn_View_Click" Text="View" />
                            <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_reset_Click" />
                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="Label2" Text="Exam Schedule Details" visible="true"/>
                            </li>
                           <%-- <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_PageTitle" Text="Exam Schedule Details" visible="true"/>
                            </li>--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Hidden_SheduleID" Text="" visible="false"/>
                            </li>
                           
                             <li class="FormValue">
                                <asp:Label runat="server" ID="lbl_Blank" Text="" visible="false"/>
                            </li>                            
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ExamID" Text="Exam Name" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="drpdwn_ExamID" 
                                    onselectedindexchanged="drpdwn_ExamID_SelectedIndexChanged" 
                                    Width="130px" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ExamID" ControlToValidate="drpdwn_ExamID"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                             <%-- --Class Name----%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ClassName" Text="Course Of Exam" />                            
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="DropDown_Class" 
                                    onselectedindexchanged="DropDown_Class_SelectedIndexChanged" 
                                    Width="130px" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ClassName" ControlToValidate="DropDown_Class"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%-- --STREAM Name----%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Stream" Text="Stream" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="drpdwn_Stream" 
                                    OnSelectedIndexChanged="drpdwn_Stream_SelectedIndexChanged" Width="130px" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Stream" ControlToValidate="drpdwn_Stream"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                           <%--Class Of Exam--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ClassId" Text="Class Name " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="drpdwn_ClassID" 
                                    onselectedindexchanged="drpdwn_ClassID_SelectedIndexChanged" 
                                    Width="130px" />
                            </li>
                            <%-- --Subject Name----%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Subject" Text="Subject" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="drpdwn_Subject" 
                                    OnSelectedIndexChanged="drpdwn_Subject_SelectedIndexChanged" Width="130px" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Subjects" ControlToValidate="drpdwn_Subject"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                          
                            <%--PR Status--%>
                            <%--<li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_IsSubjectPratical" Text="Is Subject Pratical " />
                            </li>
                            <li class="FormValue">
                                <asp:RadioButtonList ID="radio_PraticalStatus" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </li>--%>
                            <%-- FULL No.--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label4" Text="Subject Full Mark " />                                 
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_ExamFullMark" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ExamFullMark" ControlToValidate="txt_ExamFullMark"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                               <asp:RegularExpressionValidator ID="regularExpressionValidator_ExamFullmark" 
                                    runat="server" ControlToValidate="txt_ExamFullMark" Display="Dynamic" />
                            </li>
                             <%-- Pass No.--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_PassNo" Text="Subject Pass Mark " 
                                    Visible="False" />                                 
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_PassMark" Visible="False" >0</asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_PassMark" ControlToValidate="txt_PassMark"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" 
                                    Visible="False" />
                               <asp:RegularExpressionValidator ID="regularExpressionValidator_PassMark" 
                                    runat="server" ControlToValidate="txt_PassMark" Display="Dynamic" 
                                    Visible="False" />
                            </li>
                            <%--Date Of start--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StartExam" Text="Date Of Exam " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_StartExam" AutoPostBack="false" />
                                <asp:ImageButton runat="server" ID="ImageButton_StartExam" CausesValidation="false"
                                    ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                    Height="21" Width="21" />
                                <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="calendarExtender_StartExam"
                                    PopupButtonID="ImageButton_StartExam" CssClass="MicroCalendar" TargetControlID="txt_StartExam" />
                                <asp:RequiredFieldValidator runat="server" 
                                    ID="requiredFieldValidator_StartExam" 
                                    ControlToValidate="txt_StartExam" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                               <asp:RegularExpressionValidator ID="regularExpressionValidator_StartExam" 
                                    runat="server" ControlToValidate="txt_StartExam" Display="Dynamic" />
                            </li>
                            <%--Date Of close--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label1" Text="Start Time " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_startExamTime" AutoPostBack="false" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_StartTime" ControlToValidate="txt_startExamTime"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator ID="regularExpressionValidator_ExamStartTime" 
                                    runat="server" ControlToValidate="txt_startExamTime" Display="Dynamic" />
                            </li>
                            <%--START TIME--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label6" Text="Close Time " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_CloseTime" AutoPostBack="false" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_CloseTime" ControlToValidate="txt_CloseTime"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator ID="regularExpressionValidator_CloseExamTime" 
                                    runat="server" ControlToValidate="txt_CloseTime" Display="Dynamic" />
                            </li>
                            <%--INVILILATOR--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Inviligitor" Text="Inviligitor " />
                            </li>
                            <li class="FormValue">
                               <asp:DropDownList ID="DropDown_Staff" runat="server" AutoPostBack="false" 
                                    Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Invivilator" ControlToValidate="DropDown_Staff"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />                                 
                            </li>
                            <%--ROOM NO--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_RoomNo" Text="Room Number" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_Roomnumber" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_RoomNo" ControlToValidate="txt_Roomnumber"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator ID="regularExpressionValidator_RoomNo" 
                                    runat="server" ControlToValidate="txt_Roomnumber" Display="Dynamic" />
                            </li>
                             <%-- Exam Sehedule Name.--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SeheduleName" Text="Exam Sehedule Name " />                                
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_ExamSeheduleName" TextMode="MultiLine" 
                                    Width="200px" Enabled="False" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_SeheduleName" ControlToValidate="txt_ExamSeheduleName"
                                    CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Enter Exam Sehedule Name" SetFocusOnError="true" />
                            </li>
                        </ul>
                    </asp:View>
                    <asp:View ID="view_Grid" runat="server">
                        <ul>
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_AddNew" runat="server" Text="Add New" OnClick="btn_AddNew_Click" />
                            </li>
                            <li class="FormPageCounter">
							    <asp:Literal runat="server" ID="lit_PageCounter" />
						    </li>
                            <li class="GridView">
                                <asp:GridView ID="gridview_Examsheedules" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%"
                                    OnRowCommand="Examsheedules_RowCommand" OnRowDeleting="Examsheedules_RowDeleting"
                                    OnRowEditing="Examsheedules_RowEditing" 
                                    OnRowDataBound="Examsheedules_RowDataBound" 
                                    onpageindexchanging="gridview_Examsheedules_PageIndexChanging">
                                    <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                      <asp:Templatefield>
                                        <HeaderTemplate>
                                            Sno
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Slno" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="StudentId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_ExamScheduleID" Text='<%# Eval("ExamScheduleID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <%--<asp:BoundField DataField="StreamID" HeaderText="StreamID" Visible="true" />
                                        <asp:BoundField DataField="ExamID" HeaderText="ExamID" Visible="true" />
                                        <asp:BoundField DataField="SubjectID" HeaderText="SubjectID" />
                                        <asp:BoundField DataField="SubjectPaperID" HeaderText="SubjectPaperID" />
                                        <asp:BoundField DataField="IsSubjectPractical" HeaderText="IsSubjectPractical" />--%>
                                        <asp:BoundField DataField="ExamScheduleName" HeaderText="ExamScheduleName" />
                                        <%--<asp:BoundField DataField="ClassID" HeaderText="ClassID" />--%>
                                        <asp:BoundField DataField="ExamDate" HeaderText="ExamDate" />
                                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                                        <asp:BoundField DataField="CloseTime" HeaderText="CloseTime" />
                                        <%--<asp:BoundField DataField="InvisilatorUserID" HeaderText="InvisilatorUserID" />--%>
                                        <asp:BoundField DataField="RoomNo" HeaderText="RoomNo" />
                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico"
                                            ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
                                            <ControlStyle CssClass="EditLink" />
                                            <ItemStyle CssClass="EditLinkItem" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico"
                                            ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
                                            <ControlStyle CssClass="DeleteLink" />
                                            <ItemStyle CssClass="DeleteLinkItem" />
                                        </asp:CommandField>
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
            </div>
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
