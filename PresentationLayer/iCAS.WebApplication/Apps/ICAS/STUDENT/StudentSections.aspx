<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentSections.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.StudentSections" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
  <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Student Sectioning:-" />
    </h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_StudentSections">
        <ContentTemplate>
            <div>                
                <asp:MultiView ID="multiview_StudentSections" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>                
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_Submit" runat="server" Text=" Save " CausesValidation="true" onclick="btn_Submit_Click"/>
                                <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false" onclick="btn_View_Click"/>
                                <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false" onclick="btn_reset_Click"/>
                            </li>
                        </ul>                       
                        <ul id="enterDetals">                         
                            <%--Course Of Section--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lblCourse" Text="Course Name:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="DropDownList_Course" AutoPostBack="false" 
                                    Width="150px" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Course"
                                    ControlToValidate="DropDownList_Course" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                            </li>
                             <%--Stream Of Section--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Stream" Text="Stream Name:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="DropDownList_Stream" AutoPostBack="True" 
                                    Width="150px" 
                                    onselectedindexchanged="DropDownList_Stream_SelectedIndexChanged" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Stream"
                                    ControlToValidate="DropDownList_Stream" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                            </li>
                            <%--Class Of Section--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Class" Text="Class Name:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="DropDownList_Class" AutoPostBack="True" 
                                    Width="150px" 
                                    onselectedindexchanged="DropDownList_Class_SelectedIndexChanged" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Class"
                                    ControlToValidate="DropDownList_Class" CssClass="ValidateMessage" Display="Dynamic"
                                    SetFocusOnError="true" />
                            </li>
                            <%--Subject Of Section--%>
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
                             <%--Sections--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SectionName" Text="Section Name:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="DropDown_Section" 
                                    Width="150px" 
                                     >
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
                                <asp:GridView ID="gridview_StudentSectionList" runat="server" 
                                    AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridView" Width="98%"
                                    OnRowDataBound="gridview_StudentSectionList_RowDataBound" 
                                    HorizontalAlign="Center" 
                                    onrowcommand="gridview_StudentSectionList_RowCommand">
                                    <Columns>    
                                         <asp:TemplateField ItemStyle-CssClass="StudentID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_StudentID" Text='<%# Eval("StudentID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                   
                                         <asp:TemplateField HeaderText="Current Section" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_Section" runat="server" />
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
                                <asp:GridView ID="gridview_StudentSection" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridView" Width="98%"
                                    OnRowCommand="gridview_StudentSection_RowCommand" 
                                    OnRowEditing="gridview_StudentSection_RowEditing" 
                                    OnRowDataBound="gridview_StudentSection_RowDataBound" 
                                    onselectedindexchanged="gridview_StudentSection_SelectedIndexChanged">
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
                                         <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_SectionID" Text='<%# Eval("SectionID") %>' Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="AttnsID" />                                           
                                        </asp:TemplateField>
                                         <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_SectiongroupID" Text='<%# Eval("SectionGroupID") %>' Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="AttnsID" />                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="AttnsID" HeaderText="Section Students">
                                         <ItemTemplate>
                                                <asp:DropDownList ID="ddlStudentsSection" runat="server">
                                                </asp:DropDownList>
                                          </ItemTemplate>
                                            <ItemStyle CssClass="AttnsID" />
                                        </asp:TemplateField>                                        
                                       
                                        <%--<asp:BoundField DataField="QualCode" HeaderText="SubjectID" Visible="true" />--%>
                                        <asp:BoundField DataField="SectionName" HeaderText="SectionName" Visible="true" />
                                        <asp:BoundField DataField="SubjectName" HeaderText="SubjectName" Visible="true" />
                                        <asp:BoundField DataField="Comment" HeaderText="Comment" />                                       
                                        <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico"
                                            ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                            <ControlStyle CssClass="ViewLink" />
                                            <ItemStyle CssClass="ViewLinkItem" />
                                        </asp:CommandField>

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
