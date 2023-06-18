<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.Departments" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%--<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
        #__tab_ContentPlaceHolderMicroERP_tab_Departments_tab_DepartmentSelect,
        #__tab_ContentPlaceHolderMicroERP_tab_Departments_tab_DepartmentAll {
            height: 22px !important;
        }

        #ContentPlaceHolderMicroERP_tab_Departments_tab_DepartmentAll_lbl_DataOperationMode {
            margin-top: -20px;
            display: block;
        }

        .divider-line {
            height: 1px;
            border-bottom: solid 1px #ccc;
        }
    </style>
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Department Details" />
    </h1> 
    <asp:MultiView runat="server" ID="multiView_DepartmentDetails" ActiveViewIndex="1">
                    <asp:View ID="view_InputControls" runat="server">
                        <div id="Mode">
                            <asp:Label runat="server" ID="lbl_DataOperationMode" />
                        </div>
                        <ul id="DepartmentDetails">
                            <li class="FormButton_Top" style="display:none">
                                <div id="Top">
                                    <asp:Button runat="server" ID="btn_ViewDepartment" CausesValidation="false" Text=" View " OnClick="btn_ViewDepartment_Click" />
                                    <asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="Btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel_Top" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
                                </div>
                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="lbl_Head_DepartmentDetails" Text="Department Details :-" />
                            </li>

                            <!--Parent Department-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_ParentDepartment" Text="Parent Department: " Height="30px" width="80%"/>
                                <asp:Label runat="server" ID="lbl_ParentDepartmentValidator" Text="*" ForeColor="Red" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="ddl_ParentDepartment" Height="30px" width="80%"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddl_ParentDepartment" runat="server" ControlToValidate="ddl_ParentDepartment" Display="Dynamic" SetFocusOnError="true" />
                            </li>

                            <!--Parent Department-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label1" Text="Head of the Department:" />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList runat="server" ID="ddl_DeptHead" Height="30px" width="80%"/>
                            </li>


                            <!--Department Name"-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_DepartmentsName" Text="Department's Name " />
                                <asp:Label runat="server" ID="lbl_DepartmentsNameValidator" Text="*" ForeColor="Red" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_DepartmentDescription" runat="server" Height="30px" width="80%"/>
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_DepartmentDescription" ControlToValidate="txt_DepartmentDescription" Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_DepartmentDescription" ControlToValidate="txt_DepartmentDescription" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[a-zA-Z\s]+" />
                            </li>

                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lblContent" Text="Department Content 1 " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txtContent1" runat="server" TextMode="MultiLine" width="80%"  Height="80px"/>
                            </li>

                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label2" Text="Department Content 2 " />
                            </li>
                             <li class="FormValue">
                                <asp:TextBox ID="txtContent2" runat="server" TextMode="MultiLine" width="80%"  Height="80px"/>
                            </li>

                            <li class="FormLabel">
                                <asp:Label runat="server" ID="Label3" Text="Department Content 3 " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txtContent3" runat="server" TextMode="MultiLine" width="80%" Height="80px" />
                            </li>
                            
                        
                            
                            <li class="FormLabel"></li>
                            <!--Action Button-->
                            <li class="FormButton_Top">
                                <div id="Buttom">
                                    <asp:Button runat="server" ID="Button3" CausesValidation="false" Text=" View " OnClick="btn_ViewDepartment_Click" />
                                    <asp:Button runat="server" ID="Btn_Save" Text="Save" OnClick="Btn_Save_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
                                </div>
                            </li>
                            <li class="FormMessage">
                                <asp:Literal runat="server" ID="lit_Message" Text="" />
                            </li>
                            <li class="FormSpacer" />
                        </ul>
                    </asp:View>
                    <asp:View ID="view_GridView" runat="server">
                        <ul class="GridView">
                            <li class="FormButton_Top">
                                <asp:Button runat="server" ID="btn_AddDepartment" Text="Add New Department" CausesValidation="false" OnClick="btn_AddDepartment_Click" />
                            </li>
                            <li>
                                <%--<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Department(s), where:" />--%>
                            </li>
                            <li class="FormPageCounter">
                                <asp:Literal runat="server" ID="lit_PageCounter" />
                            </li>
                            <li>
                                <asp:GridView runat="server" ID="gview_Department" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="25" Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2" OnRowCommand="gview_Department_RowCommand" OnRowEditing="gview_Department_RowEditing" OnRowDeleting="gview_Department_RowDeleting" OnPageIndexChanging="gview_Department_PageIndexChanging" OnRowDataBound="gview_Department_RowDataBound">
                                    <PagerStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:BoundField ShowHeader="false" DataField="DepartmentID" Visible="false" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_DepartmentID" Text='<%# Eval("DepartmentID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="DepartmentDescription" HeaderText="Department Name:" ItemStyle-CssClass="DeptDescription" />
                                        <asp:TemplateField ItemStyle-CssClass="CheckBox" HeaderText="Department Content for website">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblContent1" Text='<%# Eval("DepartmentContent1") %>' Visible="True" /><hr  class="divider-line" />
                                                <asp:Label runat="server" ID="lblContent2" Text='<%# Eval("DepartmentContent2") %>' Visible="True" /><hr  class="divider-line" />
                                                <asp:Label runat="server" ID="lblContent3" Text='<%# Eval("DepartmentContent3") %>' Visible="True" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DepartmentHeadName" HeaderText="HOD Name " />

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
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <div id="UpdateProgress">
                <div class="UpdateProgressArea">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
