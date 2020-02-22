<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="ExamMasters.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.ExamMasters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		Exam Master:
	</h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_ExamMaster">
        <ContentTemplate>
            <div>              
                <asp:MultiView ID="Exams_Multi" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul id="ExamDetails">
                            <li class="FormButton_Top">
                            <asp:Button ID="btn_Submit" runat="server" Text=" Save " CausesValidation="true"  OnClick="btn_Submit_Click" />
                             <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" OnClick="btn_View_Click" />
                            <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_reset_Click" />
                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_PageTitle" Text="Exam Schedule Details" visible="true"/>
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Hidden_ExamID" Text="" visible="false"/>
                            </li>
                           
                             <li class="FormValue">
                                <asp:Label runat="server" ID="lbl_Blank" Text="" visible="false"/>
                            </li>
                                                                                
                            <%--Exam Class--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ClassId" Text="Choose Class " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="false" ID="drpdwn_ClassID" />
                                <asp:RequiredFieldValidator ID="requiredFieldValidator_ClassName" 
                                runat="server" ControlToValidate="drpdwn_ClassID" CssClass="ValidateMessage" 
                                Display="Dynamic" SetFocusOnError="true" />
                            </li>                            
                            <%--Academic Year--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_AcademicYear" Text="Choose Season " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="false" ID="DropDown_CurrentSeason" />
                                <asp:RequiredFieldValidator ID="requiredFieldValidator_CurrentSeassion" 
                                runat="server" ControlToValidate="DropDown_CurrentSeason" CssClass="ValidateMessage" 
                                Display="Dynamic" SetFocusOnError="true" />
                            </li>   
                            <%-- Exam Name.--%>
                            
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ExamName" Text="Exam Name" />                                
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_ExamName" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ExamName" ControlToValidate="txt_ExamName"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--Date Of start--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StartExamDate" Text="Date Of Start " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_StartExam" AutoPostBack="false" />
                                <asp:ImageButton runat="server" ID="ImageButton_StartExam" CausesValidation="false"
                                    ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                    Height="21" Width="21" />
                                <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="calendarExtender_StartExam"
                                    PopupButtonID="ImageButton_StartExam" CssClass="MicroCalendar" TargetControlID="txt_StartExam" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_StartExam"
                                    ControlToValidate="txt_StartExam" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                                <asp:RegularExpressionValidator ID="regularExpressionValidator_StartExam" 
                                    runat="server" ControlToValidate="txt_StartExam" Display="Dynamic" />
                            </li>
                            <%--Date Of close--%>
                             <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_DateOfClose" Text="Date Of Close " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_DateOfClose" AutoPostBack="false" />
                                <asp:ImageButton runat="server" ID="ImageButton_EndExam" CausesValidation="false"
                                    ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                    Height="21" Width="21" />
                                <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="calendarExtender_EndExam"
                                    PopupButtonID="ImageButton_EndExam" CssClass="MicroCalendar" TargetControlID="txt_DateOfClose" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EndExam"
                                    ControlToValidate="txt_DateOfClose" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                                    <asp:RegularExpressionValidator ID="regularExpressionValidator_CloaseExam" 
                                    runat="server" ControlToValidate="txt_DateOfClose" Display="Dynamic" />
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
                                <asp:GridView ID="gridview_ExamList" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%"
                                    OnRowCommand="gridview_ExamList_RowCommand" OnRowDeleting="gridview_ExamList_RowDeleting"
                                    OnRowEditing="gridview_ExamList_RowEditing" 
                                    OnRowDataBound="gridview_ExamList_RowDataBound">
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
                                                <asp:Label runat="server" ID="lbl_ExamID" Text='<%# Eval("ExamID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:BoundField DataField="ExamName" HeaderText="Exam Name" Visible="true" />
                                        <asp:BoundField DataField="SessionID" HeaderText="Session ID" Visible="true" />
                                        <asp:BoundField DataField="QualID" HeaderText="Qualification" />
                                        <asp:BoundField DataField="DateOfStart" HeaderText="Date of Start" />
                                        <asp:BoundField DataField="DateOfClose" HeaderText="Date Of Close" />
                                        <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                                        
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
