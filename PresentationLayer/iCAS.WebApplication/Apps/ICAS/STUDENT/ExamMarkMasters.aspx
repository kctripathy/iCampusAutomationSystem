<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="ExamMarkMasters.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.ExamMarkMasters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		Exam Mark Feeding Master:
	</h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_ExamMarkMaster">
        <ContentTemplate>
            <div>               
                <asp:MultiView ID="ExamMarks_Multi" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>
                        <li class="FormButton_Top">
                            <asp:Button ID="btn_Submit" runat="server" Text=" Save " CausesValidation="true"  OnClick="btn_Submit_Click" />
                             <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" OnClick="btn_View_Click" />
                            <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_reset_Click" />
                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_PageTitle" Text="Exam Schedule Mark Details" visible="true"/>
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Hidden_ExamMarkID" Text="" visible="false"/>
                            </li>
                           
                             <li class="FormValue">
                                <asp:Label runat="server" ID="lbl_Blank" Text="" visible="false"/>
                            </li>
                                                                                
                            <%--Exam ExamMarkSehedule--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ExamMarkSeheduleId" Text="Choose ExamMarkSehedule " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="true" 
                                    ID="drpdwn_ExamMarkSeheduleID" 
                                    onselectedindexchanged="drpdwn_ExamMarkSeheduleID_SelectedIndexChanged" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_ExamSchedule" ControlToValidate="drpdwn_ExamMarkSeheduleID"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>                                                     
                            <li class="Gview_Students">
                                <asp:GridView ID="gridview_ExamSehedule" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%">
                                    <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>

                                        <asp:TemplateField ItemStyle-CssClass="StudentId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_ExamScheduleID" Text='<%# Eval("ExamScheduleID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:BoundField DataField="StreamID" HeaderText="StreamID" Visible="true" />
                                        <asp:BoundField DataField="ExamID" HeaderText="ExamID" Visible="true" />
                                        <asp:BoundField DataField="SubjectID" HeaderText="SubjectID" />
                                        <asp:BoundField DataField="FullMark" HeaderText="FullMark" Visible="true" />
                                        <asp:BoundField DataField="PassMark" HeaderText="PassMark" />
                                        <asp:BoundField DataField="ExamDate" HeaderText="ExamDate" />
                                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                                        <asp:BoundField DataField="CloseTime" HeaderText="CloseTime" />
                                        <asp:BoundField DataField="InvisilatorUserID" HeaderText="InvisilatorUserID" />
                                        <asp:BoundField DataField="RoomNo" HeaderText="RoomNo" />                                       
                                    </Columns>
                                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                        Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="MicroPagerStyle" />
                                </asp:GridView>
                            </li>                            
                          <%-- <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_GridBlank" Text=". " />
                            </li>--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StudentID" Text="Choose StudentID " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="false" ID="drpdwn_StudentOnSeheduleID" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Student" ControlToValidate="drpdwn_StudentOnSeheduleID"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>                        
                            <%-- ExamMark Marks.--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_MarksObtain" Text="Marks Obtain" />                                
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_MarksObtained" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_MarksObtain" ControlToValidate="txt_MarksObtained"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator ID="regularExpressionValidator_MarksObtain" 
                                    runat="server" ControlToValidate="txt_MarksObtained" Display="Dynamic" />
                            </li>
                              <%-- Varified By.--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_VarifiedBy" Text="Varified By" />                                
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_VarifiedBy" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_VarifiedBy" ControlToValidate="txt_VarifiedBy"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator ID="regularExpressionValidator_Varifiedby" 
                                    runat="server" ControlToValidate="txt_VarifiedBy" Display="Dynamic" />
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
                                <asp:GridView ID="gridview_ExamMarkList" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%"
                                    OnRowCommand="gridview_ExamMarkList_RowCommand" OnRowDeleting="gridview_ExamMarkList_RowDeleting"
                                    OnRowEditing="gridview_ExamMarkList_RowEditing" 
                                    OnRowDataBound="gridview_ExamMarkList_RowDataBound" 
                                    onpageindexchanging="gridview_ExamMarkList_PageIndexChanging">
                                    <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="StudentId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_ExamMarkID" Text='<%# Eval("Exam_Mark_ScheduleID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:BoundField DataField="ExamScheduleID" HeaderText="ExamMark Schedule" Visible="true" />                                      
                                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                                        <asp:BoundField DataField="MarksObtained" HeaderText="Marks Obtained" />
                                        <asp:BoundField DataField="VarifiedBy" HeaderText="VarifiedBy" />                                       
                                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" />                                        
                                        <asp:CommandField ShowEditButton="True" HeaderText="View/Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico"
                                            ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
                                            <ControlStyle CssClass="EditLink" />
                                            <ItemStyle CssClass="EditLinkItem" />
                                        </asp:CommandField>
                                       <%-- <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico"
                                            ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
                                            <ControlStyle CssClass="DeleteLink" />
                                            <ItemStyle CssClass="DeleteLinkItem" />
                                        </asp:CommandField>--%>
                                       <%-- <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico"
                                            ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                            <ControlStyle CssClass="ViewLink" />
                                            <ItemStyle CssClass="ViewLinkItem" />
                                        </asp:CommandField>--%>
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
        </ContentTemplate>
    </asp:UpdatePanel>
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
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <div id="UpdateProgress">
                <div class="UpdateProgressArea">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
