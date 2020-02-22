<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentDailyAttendances.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.StudentDailyAttendances" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
  <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Student Daily Attendance:-" />
    </h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_StudentAttendance">
        <ContentTemplate>
            <div>                
                <asp:MultiView ID="multiview_StudentAttendance" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>                
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_Submit" runat="server" Text=" Save " CausesValidation="true" onclick="btn_Submit_Click"/>
                                <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" onclick="btn_View_Click"/>
                                <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" onclick="btn_reset_Click"/>
                                <asp:HiddenField ID="hiddenatten" runat="server" />
                            </li>
                        </ul>                       
                        <ul id="enterDetals">                         
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StaffId" Text="Enter Faculty ID:" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_Faculty" AutoPostBack="True" ontextchanged="txt_Faculty_TextChanged" />
                                <asp:RegularExpressionValidator ID="regularExpressionValidator_Invigilator" 
                                    runat="server" ControlToValidate="txt_Faculty" CssClass="ValidateMessage" 
                                    Display="Dynamic" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Faculty" ControlToValidate="txt_Faculty" 
                                CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                             </li>
                            <%--Subject Of Attendance--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Subject" Text="Subject Of Class:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="DropDown_subjectClas" AutoPostBack="false" 
                                    Width="150px" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_SubjectClass"
                                    ControlToValidate="DropDown_subjectClas" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                            </li>
                             <%--Subject Of Sections--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Section" Text="Choose Section:" />
                            </li>
                            <li class="FormValue">
                              <asp:DropDownList runat="server" ID="DropDown_Section" AutoPostBack="false" 
                                    Width="150px" >
                                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Section1</asp:ListItem>
                                    <asp:ListItem Value="2">Section2</asp:ListItem>
                                    <asp:ListItem Value="3">Section3</asp:ListItem>
                                    <asp:ListItem Value="4">Section4</asp:ListItem>
                                    <asp:ListItem Value="5">Section5</asp:ListItem>
                                    <asp:ListItem Value="6">Section6</asp:ListItem>
                                    <asp:ListItem Value="7">Section7</asp:ListItem>
                                    <asp:ListItem Value="8">Section8</asp:ListItem>
                                    <asp:ListItem Value="9">Section9</asp:ListItem>
                                    <asp:ListItem Value="10">Section10</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Section"
                                    ControlToValidate="DropDown_Section" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                            </li>

                             <%--Class Date--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ClassDate" Text="Class Date :"/>                             
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_ClassDate" AutoPostBack="false" />
                                <asp:ImageButton runat="server" ID="imgbtn_DateOfAttendance" CausesValidation="false"
                                    ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                    Height="21" Width="21" />
                                <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_dateofattendance"
                                    PopupButtonID="imgbtn_DateOfAdmission" CssClass="MicroCalendar" TargetControlID="txt_ClassDate" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DateOfAttendance"
                                    ControlToValidate="txt_ClassDate" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DateOFAttendancce"
                                    ControlToValidate="txt_ClassDate" CssClass="ValidateMessage" Display="Dynamic"
                                    ErrorMessage="Invalid Date" />
                            </li>
                             <%--Class Start Time--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ClassStarttime" Text="Class Start Time :" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_ClassStarttime" AutoPostBack="false" />
                                <asp:RegularExpressionValidator ID="regularExpressionValidator_StartTime" 
                                    runat="server" ControlToValidate="txt_Faculty" CssClass="ValidateMessage" 
                                    Display="Dynamic" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ClassStarttime"
                                    ControlToValidate="txt_ClassStarttime" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                            </li>
                              <%-- Class Close Time--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ClassCloseTime" Text=" Class Close Time:" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_ClassCloseTime" AutoPostBack="false" />
                                <asp:RegularExpressionValidator ID="regularExpressionValidator_CloseTime" 
                                    runat="server" ControlToValidate="txt_Faculty" CssClass="ValidateMessage" 
                                    Display="Dynamic" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ClassClosetime"
                                    ControlToValidate="txt_ClassCloseTime" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />                                    
                            </li>
                             <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Comment" Text="Comment Here:" />
                            </li>
                              <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_Comment" AutoPostBack="false" 
                                      TextMode="MultiLine" />                                
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Comment"
                                    ControlToValidate="txt_Comment" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" /> 
                                    <asp:Button ID="btn_Go" runat="server" Text="Show Student List" 
                                    onclick="btn_Go_Click" /> 
                             </li>                                                  
                            <li class="GridView">
                                <asp:GridView ID="gridview_StudentAttedanceList" runat="server" 
                                    AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridView" Width="98%"
                                    OnRowDataBound="gridview_StudentAttedanceList_RowDataBound" 
                                    HorizontalAlign="Center" 
                                    onrowcommand="gridview_StudentAttedanceList_RowCommand" 
                                    EmptyDataText="!!! SORRY NO MORE RECORD FOUND TO THIS CRITERIA">
                                     <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>    
                                         <asp:TemplateField ItemStyle-CssClass="StudentID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_StudentID" Text='<%# Eval("StudentID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                   
                                         <asp:TemplateField HeaderText="Attendance" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_Attendance" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:BoundField DataField="StudentCode" HeaderText="StudentCode" Visible="true" />
                                        <asp:BoundField DataField="RollNo" HeaderText="RollNo" Visible="true" />
                                        <asp:BoundField DataField="StudentName" HeaderText="StudentName" />                                                                                                                      
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                        Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="MicroPagerStyle" />
                                    <RowStyle HorizontalAlign="Left" />
                                </asp:GridView>
                            </li>
                            </ul> 
                        <ul>                
                                <li class="FormButton_Top">
                                    <asp:Button ID="btn_Submit1" runat="server" Text=" Save " 
                                    CausesValidation="true" onclick="btn_Submit_Click"/>
                                    <asp:Button ID="btn_View1" runat="server" Text="View" CausesValidation="false" 
                                    onclick="btn_View_Click"/>
                                    <asp:Button ID="btn_reset1" runat="server" Text="Reset" CausesValidation="false" 
                                    onclick="btn_reset_Click"/>
                                </li>
                            </ul>
                    </asp:View>
                    <asp:View ID="view_Grid" runat="server">
                        <ul>
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_AddNew" runat="server" Text="Add New" 
                                    onclick="btn_AddNew_Click" />
                            </li>
                            <li class="GridView">
                                <asp:GridView ID="gridview_StudentAttendance" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridView" Width="98%"
                                    OnRowCommand="gridview_StudentAttendance_RowCommand" OnRowDeleting="gridview_StudentAttendance_RowDeleting"
                                    OnRowEditing="gridview_StudentAttendance_RowEditing" 
                                    OnRowDataBound="gridview_StudentAttendance_RowDataBound">
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
                                        <asp:TemplateField ItemStyle-CssClass="AttnsID" HeaderText="Attendanded Students">
                                         <ItemTemplate>
                                                <asp:DropDownList ID="ddlStudentsPresent" runat="server">
                                                </asp:DropDownList>
                                          </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_AttendanceID" Text='<%# Eval("AttenID") %>' Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="AttnsID" />                                           
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="QualCode" HeaderText="SubjectID" Visible="true" />--%>
                                        <asp:BoundField DataField="EmployeeName" HeaderText="Faculty" Visible="true" />
                                        <asp:BoundField DataField="SubjectName" HeaderText="Subject" Visible="true" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                        <asp:BoundField DataField="ClassStartTime" HeaderText="Class Time" />
                                        <asp:BoundField DataField="ClassCloseTime" HeaderText="Close On" />

                                        <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico"
                                            ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                            <ControlStyle CssClass="ViewLink" />
                                            <ItemStyle CssClass="ViewLinkItem" />
                                        </asp:CommandField>

                                        <%--<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico"
                                            ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
                                            <ControlStyle CssClass="EditLink" />
                                            <ItemStyle CssClass="EditLinkItem" />
                                        </asp:CommandField>--%>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico"
                                            ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
                                            <ControlStyle CssClass="DeleteLink" />
                                            <ItemStyle CssClass="DeleteLinkItem" />
                                        </asp:CommandField>
                                    </Columns>
                                    <HeaderStyle CssClass="HeaderStyle" />
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
