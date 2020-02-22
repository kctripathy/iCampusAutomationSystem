<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentSubjects.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STUDENT.StudentSubjects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">SUBJECTS:
    </h1>
    <asp:UpdatePanel runat="server" ID="updatepanel_subject">
        <ContentTemplate>
            <div>
                <asp:MultiView ID="multiview_Subject" runat="server">
                    <asp:View ID="InputControls" runat="server">
                        <ul>
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_Submit" runat="server" Text="Save" CausesValidation="true"
                                    OnClick="btn_Submit_Click" />

                                <asp:Button ID="btn_View" runat="server" Text="View" CausesValidation="false"
                                    OnClick="btn_View_Click" />
                                <asp:Button ID="btn_reset" runat="server" Text="Reset" CausesValidation="false"
                                    OnClick="btn_reset_Click" />

                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_PageTitle" Text="Subject" Visible="true" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Hidden_SubjectID" Text="" Visible="false" />
                            </li>

                            <li class="FormValue">
                                <asp:Label runat="server" ID="lbl_Blank" Text="" Visible="false" />
                            </li>


                            </li>                                                                                                               
                            <%--QualID--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_QualID" Text="Select Qualification" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="false" ID="DropDown_QualID"
                                    Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="requiredFieldValidator_QualID"
                                    runat="server" ControlToValidate="DropDown_QualID" CssClass="ValidateMessage"
                                    Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--StreamID--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StreamID" Text="Select Stream :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="True" ID="DropDown_StreamID"
                                    OnSelectedIndexChanged="DropDown_StreamID_SelectedIndexChanged"
                                    Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="requiredFieldValidator_StreamID"
                                    runat="server" ControlToValidate="DropDown_StreamID" CssClass="ValidateMessage"
                                    Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--ClassID--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ClassId" Text="Select Class :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="True" ID="DropDown_ClassID"
                                    Width="200px"
                                    OnSelectedIndexChanged="DropDown_ClassID_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="requiredFieldValidator_ClassID"
                                    runat="server" ControlToValidate="DropDown_ClassID" CssClass="ValidateMessage"
                                    Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--SubjectTypeName--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SubjectTypeName"
                                    Text="Select Subject Type :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="True"
                                    ID="DropDown_SubjectTypeName" Width="200px"
                                    OnSelectedIndexChanged="DropDown_SubjectTypeName_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="requiredFieldValidator_SubjectTypeName"
                                    runat="server" ControlToValidate="DropDown_SubjectTypeName" CssClass="ValidateMessage"
                                    Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SubjectCategory"
                                    Text="Choose Subject Category" />
                            </li>
                            <li class="FormValue">
                                <asp:RadioButtonList ID="RadioSubjectCategory" runat="server"
                                    RepeatDirection="Horizontal" AutoPostBack="True"
                                    OnSelectedIndexChanged="RadioSubjectCategory_SelectedIndexChanged"
                                    Width="200px">
                                    <asp:ListItem Value="0">IsMain</asp:ListItem>
                                    <asp:ListItem Value="1">IsParent</asp:ListItem>
                                    <asp:ListItem Value="2">IsRoot</asp:ListItem>
                                </asp:RadioButtonList>
                            </li>
                            <%--Parent Subject--%>
                            <asp:Panel runat="server" class="FullWidth" ID="Panel_SubCat" Visible="False">
                                <ul>
                                    <li class="FormLabel">
                                        <asp:Label runat="server" ID="lbl_ParentSubject" Text="Parent Subject Category" />
                                    </li>
                                    <li class="FormValue">
                                        <asp:DropDownList runat="server" AutoPostBack="false" ID="DropDownSub_Cat"
                                            Width="200px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="requiredFieldValidator_SubjectCat"
                                            runat="server" ControlToValidate="DropDownSub_Cat" CssClass="ValidateMessage"
                                            Display="Dynamic" SetFocusOnError="true" />
                                    </li>
                                </ul>
                            </asp:Panel>
                            <%--SubjectName--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SubjectName" Text="Subject Name :" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_SubjectName" Width="200px" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator1" ControlToValidate="txt_SubjectName"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--SubjectFullMark--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SubjectFullMark" Text="Subject FullMark :" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_SubjectFullMark" Width="200px" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_SubjectFullMark" ControlToValidate="txt_SubjectFullMark"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--SubjectPasslMark--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_StaffID" Text="Choose Staff :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="DropDown_Staff" runat="server" AutoPostBack="false"
                                    Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Staff" ControlToValidate="DropDown_Staff"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--SubjectPracticalFlag--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SubjectPracticalFlag"
                                    Text="Is Subject Having Pratical ?" />
                            </li>
                            <li class="FormValue">
                                <asp:CheckBox ID="chk_SubjPratical" Text="Choose if Pratical Subject" runat="server" />
                            </li>
                            <%--SubjectPracticalMark--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SubjectPracticalMark"
                                    Text="Subject Practical Mark" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_SubjectPracticalMark" Width="200px" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_SubjectPracticalMark" ControlToValidate="txt_SubjectPracticalMark"
                                    CssClass="ValidateMessage" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <%--SessionID--%>
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SessionID" Text="Select Session :" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" AutoPostBack="false" ID="DropDown_SessionID"
                                    Width="200px">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="requiredFieldValidator_SessionID"
                                    runat="server" ControlToValidate="DropDown_SessionID" CssClass="ValidateMessage"
                                    Display="Dynamic" SetFocusOnError="true" />
                            </li>
                            <li class="GridView">
                                <asp:GridView ID="gridviewCourseSubjects" 
                                    runat="server" 
                                    AllowPaging="True" 
                                    AllowSorting="True"
                                    AutoGenerateColumns="False" 
                                    CssClass="GridView" 
                                    Width="98%"
                                    HorizontalAlign="Left" PageSize="50">
                                    <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sno
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Slno" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-CssClass="SubjectId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_SubjectID" Text='<%# Eval("SubjectID") %>' Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="SubjectId" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SubjectName" HeaderText="Subject" Visible="true" />
                                        <asp:BoundField DataField="SubjectTypeID" HeaderText="SubjectTypeID"
                                            Visible="False" />
                                        <asp:BoundField DataField="SubjectTypeName" HeaderText="Subject Type" />
                                        <asp:BoundField DataField="QualCode" HeaderText="Qualification" />
                                        <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                        <asp:BoundField DataField="StreamName" HeaderText="Stream" />
                                        <asp:BoundField DataField="SubjectFullMark" HeaderText="Subject Full Mark"
                                            Visible="False" />
                                        <asp:BoundField DataField="StaffID" HeaderText="Staff ID"
                                            Visible="False" />
                                        <asp:BoundField DataField="SubjectPracticalFlag"
                                            HeaderText="Is Subject Praical ?" Visible="False" />
                                        <asp:BoundField DataField="SubjectPracticalMark"
                                            HeaderText="Practical Mark" Visible="False" />
                                        <asp:BoundField DataField="SessionID" HeaderText="Session ID" Visible="true" />
                                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" Visible="False" />
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                        Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="MicroPagerStyle" />
                                </asp:GridView>
                            </li>
                        </ul>
                    </asp:View>
                    <asp:View ID="view_Grid" runat="server" OnActivate="Page_Load">
                        <ul>
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_AddNew" runat="server" Text="Add New"
                                    OnClick="btn_AddNew_Click" />
                            </li>
                            <li class="FormPageCounter">
                                <asp:Literal runat="server" ID="lit_PageCounter" />
                            </li>
                            <li class="GridView">
                                <asp:GridView ID="gridview_Subject"
                                    runat="server" 
                                    AllowPaging="True" 
                                    AllowSorting="True"
                                    AutoGenerateColumns="False"
                                    CssClass="GridView" 
									Width="98%"
									PageSize="50"
                                    HorizontalAlign="Left"
                                    OnPageIndexChanging="gridview_Subject_PageIndexChanging"
                                    OnRowCommand="gridview_Subject_RowCommand"
                                    OnRowEditing="gridview_Subject_RowEditing"
                                    OnRowDeleting="gridview_Subject_RowDeleting">
                                    <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="SubjectId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_SubjectID" Text='<%# Eval("SubjectID") %>' Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="SubjectId" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SubjectName" HeaderText="Subject" Visible="true" />
                                        <asp:BoundField DataField="SubjectTypeID" HeaderText="SubjectTypeID"
                                            Visible="False" />
                                        <asp:BoundField DataField="SubjectTypeName" HeaderText="Subject Type" />
                                        <asp:BoundField DataField="QualCode" HeaderText="Qualification" />
                                        <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                        <asp:BoundField DataField="StreamName" HeaderText="Stream" />
                                        <asp:BoundField DataField="SubjectFullMark" HeaderText="Subject FullMark"
                                            Visible="False" />
                                        <asp:BoundField DataField="StaffID" HeaderText="Staff ID"
                                            Visible="False" />
                                        <asp:BoundField DataField="SubjectPracticalFlag"
                                            HeaderText="Is Subject Pratical" Visible="False" />
                                        <asp:BoundField DataField="SubjectPracticalMark"
                                            HeaderText="Subject Practical Mark" Visible="False" />
                                        <asp:BoundField DataField="SessionID" HeaderText="Session ID" Visible="true" />
                                        <asp:BoundField DataField="IsActive" HeaderText="IsActive" Visible="False" />
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
                                    <HeaderStyle HorizontalAlign="Left" />
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


