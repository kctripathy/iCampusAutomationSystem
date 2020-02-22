<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="ShiftSchedules.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.ShiftSchedules" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Shift Details" />
    </h1>
    <asp:UpdatePanel runat="server" ID="updatePanel_ShiftSchedules">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="multiView_ShiftSchedules">
                <asp:View ID="view_InputControls" runat="server">
                    <div id="Mode">
                        <asp:Label runat="server" ID="lbl_DataOperationMode" />
                    </div>
                    <ul id="ShiftScheduleDetails">
                        <%--<li class="FormButton_Top">
							<div id="Top">
								<asp:Button runat="server" ID="btn_ViewShift" CausesValidation="false" Text=" View " OnClick="btn_ViewShift_Click" />
								<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="Btn_Save_Click" />
								<asp:Button ID="btn_Cancel_Top" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
							</div>
						</li>--%>
                        <li class="PageSubTitle">
                            <asp:Label runat="server" ID="lbl_Head_ShiftScheduleDetails" Text="Shift Schedules(Department) :-" />
                        </li>
                        <!--Department Name"-->
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_SelectDepartment" Text="SelectDepartment " />
                        </li>
                        <li class="FormValue">
                            <asp:DropDownList runat="server" ID="ddl_SelectDepartment" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectDepartment_SelectedIndexChanged" />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_SelectDepartment" runat="server" ControlToValidate="ddl_SelectDepartment" Display="Dynamic" SetFocusOnError="true" />
                           </li> 
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_SelectDate" Text="SelectDate " />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_SelectDate" AutoPostBack="true" CssClass="SelectDate" />
                                <ajax:CalendarExtender ID="CalendarExtender_SelectDate" runat="server" Format="dd-MMM-yyyy"
                                    PopupButtonID="imgButton_SelectDate" CssClass="MicroCalendar" TargetControlID="txt_SelectDate"  />
                                   
                                <asp:ImageButton runat="server" ID="imgButton_SelectDate" CausesValidation="false"
                                    ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif"
                                    Height="21" Width="21" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_SelectDate"
                                    ControlToValidate="txt_SelectDate" Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_SelectDate"
                                    ControlToValidate="txt_SelectDate" Display="Dynamic" SetFocusOnError="true" />
                            </li>
                        </li>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_WeekStartDateShow" Text="Week Start Date " />
                        </li>
                        <li class="FormValue">
                            <asp:Label runat="server" ID="lbl_WeekStartDate" Text="Effective Date"></asp:Label>
                        </li>
                        <li class="FormLabel"></li>
                        <!--Action Button-->
                        <li class="FormButton_Top">
                            <div id="Buttom">
                                <asp:Button runat="server" ID="btn_ShowSchedules" Text="View Schedules" CausesValidation ="false" OnClick="btn_ShowSchedules_Click"  />
                            </div>
                        </li>
                        <li class="FormMessage">
                            <asp:Literal runat="server" ID="lit_Message" Text="" />
                        </li>
                        <li class="FormSpacer" />
                    </ul>
                    <ul class="GridView">
                        <li>
                            <asp:GridView runat="server" ID="gview_ShiftSchedules" AutoGenerateColumns="false"
                                AllowPaging="true" DataKeyNames="EmployeeID" AllowSorting="true" PageSize="25"
                                Width="98%" CssClass="GridView" GridLines="Both" CellPadding="2" OnPageIndexChanging="gview_ShiftSchedules_PageIndexChanging">
                                <PagerStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="CheckBox">
                                        <ItemTemplate>
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
                                </Columns>
                                <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last"
                                    Mode="NumericFirstLast" />
                                <PagerStyle CssClass="MicroPagerStyle" />
                            </asp:GridView>
                        </li>
                        <li class="FormSpacer" />
                    </ul>
                </asp:View>
            </asp:MultiView>
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
