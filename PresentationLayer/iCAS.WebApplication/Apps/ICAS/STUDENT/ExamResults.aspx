<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="ExamResults.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.ExamResults" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		Exam Result Master:
	</h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_ExamResultMaster">
        <ContentTemplate>
            <div>               
                <asp:MultiView ID="ExamResults_Multi" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>
                        <li class="FormButton_Top">
                            <%--<asp:Button ID="btn_Submit" runat="server" Text=" Save " CausesValidation="true"  OnClick="btn_Submit_Click" />--%>
                             <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" OnClick="btn_View_Click" />
                            <%--<asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_reset_Click" />--%>
                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_PageTitle" Text="Exam Result"/>
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Hidden_ExamResultID" Text="" visible="false"/>
                            </li>
                           
                             <li class="FormValue">
                                <asp:Label runat="server" ID="lbl_Blank" Text="" visible="false"/>
                            </li>
                                                                                
                            <%--Exam ExamResultSehedule--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ExamResultSeheduleId" Text="Choose Exam" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" 
                                    ID="drpdwn_ExamResultSeheduleID" 
                                    
                                    onselectedindexchanged="drpdwn_ExamResultSeheduleID_SelectedIndexChanged" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Exam" ControlToValidate="drpdwn_ExamResultSeheduleID"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>  
                             <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StudentID" Text="Enter StudentID " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_StudentID" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Student" ControlToValidate="txt_StudentID"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                                <asp:Button ID="btn_go" runat="server" Text="Go" onclick="btn_go_Click"/>
                            </li>  
                             <li class="FormLabel">
                                <asp:Label runat="server" ID="lblStudentCode" Text="Student Code " />
                            </li>
                            <li class="FormValue">
                            <asp:Label runat="server" ID="val_StudentCode" Text="" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ExamName" Text="Name Of Exam" />                                
                            </li>
                            <li class="FormValue">                            
                                <asp:Label runat="server" ID="value_ExamName" Text="" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StudentName" Text="Name Of Student" />                                
                            </li>
                            <li class="FormValue">                            
                                <asp:Label runat="server" ID="val_StudentName" Text="" />
                            </li>
                             <li class="GridView">
                                <asp:GridView ID="gridview_ExamResultList" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridView" Width="98%"
                                    OnRowCommand="gridview_ExamResultList_RowCommand" OnRowDeleting="gridview_ExamResultList_RowDeleting"
                                    OnRowEditing="gridview_ExamResultList_RowEditing" 
                                    OnRowDataBound="gridview_ExamResultList_RowDataBound" 
                                    onpageindexchanging="gridview_ExamResultList_PageIndexChanging">
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
                                                <asp:Label runat="server" ID="lbl_StudentID" Text='<%# Eval("StudentID") %>' Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="StudentId" />
                                        </asp:TemplateField>                                        
                                        <asp:BoundField DataField="StudentCode" HeaderText="StudentCode" 
                                            Visible="False" />
                                        <asp:BoundField DataField="StudentName" HeaderText="StudentName" 
                                            Visible="False" />
                                        <asp:BoundField DataField="ExamName" HeaderText="ExamName" Visible="False" />
                                        <asp:BoundField DataField="ExamDate" HeaderText="ExamDate" Visible="true" />
                                        <asp:BoundField DataField="ExamID" HeaderText="ExamID" />
                                        <asp:BoundField DataField="ExamDate" HeaderText="ExamDate" />
                                        <asp:BoundField DataField="SubjectName" HeaderText="SubjectName" />
                                        <asp:BoundField DataField="SubjectFullMark" HeaderText="FullMark" />
                                        <%--<asp:BoundField DataField="StaffID" HeaderText="Faculty" />--%>
                                        <asp:BoundField DataField="MarksObtained" HeaderText="MarksObtained" />  
                                    </Columns>
                                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                        Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="MicroPagerStyle" />
                                </asp:GridView>
                            </li>                                                     
                        </ul>
                    </asp:View>
                    <asp:View ID="view_Grid" runat="server">
                        <ul>
                             <li class="FormButton_Top">
                                <asp:Button ID="btn_AddNew" runat="server" Text="View By Student" 
                                     OnClick="btn_AddNew_Click" />
                            </li>
                            <li class="FormPageCounter">
							    <asp:Literal runat="server" ID="lit_PageCounter" />
						    </li>
                            <li class="GridView">
                                <asp:GridView ID="gridview_ViewExamResult" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CssClass="GridView" GridLines="Both" Width="98%"
                                    >
                                    <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="HeaderStyle" />                                      
                                      <Columns>
                                        <asp:Templatefield>
                                        <HeaderTemplate>
                                            Sno
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Slno1" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField ItemStyle-CssClass="StudentId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_StudentID" Text='<%# Eval("StudentID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:BoundField DataField="StudentCode" HeaderText="StudentCode" Visible="true" />
                                        <asp:BoundField DataField="StudentName" HeaderText="StudentName" Visible="true" />
                                        <asp:BoundField DataField="ExamName" HeaderText="ExamName" />
                                        <asp:BoundField DataField="ExamDate" HeaderText="ExamDate" Visible="true" />
                                        <asp:BoundField DataField="ExamID" HeaderText="ExamID" />
                                        <asp:BoundField DataField="ExamDate" HeaderText="ExamDate" />
                                        <asp:BoundField DataField="SubjectName" HeaderText="SubjectName" />
                                        <asp:BoundField DataField="SubjectFullMark" HeaderText="FullMark" />
                                        <%--<asp:BoundField DataField="SubjectPassMark" HeaderText="PassMark" />--%>
                                        <asp:BoundField DataField="MarksObtained" HeaderText="MarksObtained" />  
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
