<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="ShiftRoasters.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.ShiftRoasters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <li class="FormLabel">
        <asp:Label runat="server" ID="lbl_SelectDate" Text="SelectDate " />
    </li>
    <li class="FormValue">
        <asp:TextBox runat="server" ID="txt_SelectDate" AutoPostBack="true" CssClass="SelectDate" />
        <ajax:CalendarExtender ID="CalendarExtender_SelectDate" runat="server" Format="dd-MMM-yyyy"
            PopupButtonID="imgButton_SelectDate" CssClass="MicroCalendar" TargetControlID="txt_SelectDate" />
        <asp:ImageButton runat="server" ID="imgButton_SelectDate" CausesValidation="false"
            ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
            Height="21" Width="21" />
        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_SelectDate"
            ControlToValidate="txt_SelectDate" Display="Dynamic" SetFocusOnError="true" />
        <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_SelectDate"
            ControlToValidate="txt_SelectDate" Display="Dynamic" SetFocusOnError="true" />
    </li>
    <asp:Label runat="server" ID="lbl_WeekStartDateShow" Text="Week Start Date " />
    <asp:Label runat="server" ID="lbl_WeekStartDate" Text="Effective Date"></asp:Label>
    <li class="FormButton_Top">
        <div id="Buttom">
            <asp:Button runat="server" ID="btn_ShowSchedules" Text="View Schedules" CausesValidation="false"
                OnClick="btn_ShowSchedules_Click" />
        </div>
    </li>
    <ul class="GridView">
        <li>
            <asp:GridView ID="gridview_AttendanceRegisterEmployee" runat="server" AllowPaging="True "  DataKeyNames="EmployeeID" OnPageIndexChanging="gridview_AttendanceRegisterEmployee_PageIndexChanging" AutoGenerateColumns="False" BorderStyle="None" CellPadding="4" CssClass="GridView" GridLines="Both" Height="45px" Width="100%" OnRowCommand="gridview_AttendanceRegisterEmployee_RowCommand"  OnRowEditing="gridview_AttendanceRegisterEmployee_RowEditing">
                <HeaderStyle CssClass="HeaderStyle" />
                <Columns>
                    <asp:TemplateField ItemStyle-CssClass="CheckBox">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_ShiftScheduleForWeekDay" Visible="true" />
                            <asp:CheckBox runat="server" ID="chk_ShiftID" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EmployeeName" HeaderText="Name " ItemStyle-CssClass="DeptDescription" />
                    <asp:BoundField DataField="EmployeeCode" HeaderText="Code " ItemStyle-CssClass="DeptDescription" />
                    <asp:BoundField DataField="DesignationDescription" HeaderText="Designation " ItemStyle-CssClass="DeptDescription" />
                    <asp:TemplateField HeaderText="MON" Visible="true">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_Mon" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TUE" Visible="true">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_Tue" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="WED" Visible="true">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_Wed" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="THU" Visible="true">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_Thu" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FRI" Visible="true">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_Fri" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SAT" Visible="true">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_Sat" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SUN" Visible="true">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbl_Sun" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico"
                        ControlStyle-CssClass="EditLink" />
                    <%-- <asp:TemplateField HeaderText="Edit">
<ItemTemplate>
<asp:ImageButton ID="imgbtn" ImageUrl="~/Edit.jpg" runat="server" Width="25" Height="25" onclick="imgbtn_Click" CausesValidation ="false" />
</ItemTemplate>
</asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </li>
    </ul>
    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup"
        PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="269px" Width="400px"
        Style="display: none">
        <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%"
            cellpadding="0" cellspacing="0">
            <tr style="background-color: #D55500">
                <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                    align="center">
                    User Details
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 45%">
                    UserId:
                </td>
                <td>
                    <asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    UserName:
                </td>
                <td>
                    <asp:Label ID="lblusername" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    EmpCode:
                </td>
                <td>
                    <asp:TextBox ID="txt_EmpCode" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Desigantion:
                </td>
                <td>
                    <asp:TextBox ID="txt_Designation" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Mon:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Mon" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Tue:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Tue" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Wed:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Wed" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Thu:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Thu" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Fri:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Fri" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    SAT:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Sat" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Sun:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Sun" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update" OnClick="btnUpdate_Click"  CausesValidation="false" />
                       
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  CausesValidation="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
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
</asp:Content>
