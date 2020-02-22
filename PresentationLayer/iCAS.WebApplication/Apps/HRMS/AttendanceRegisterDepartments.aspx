<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AttendanceRegisterDepartments.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.AttendanceRegisterDepartments" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Attendance Registers" />
	</h1>
<asp:UpdatePanel runat="server" ID="updatePanel_AttendanceRegisterEmployee">
        <ContentTemplate>
            <div>
                <div id="Mode">
                    <asp:Label runat="server" ID="lbl_DataOperationMode" />
                </div>
                <ul id="AttendanceRegisterEmployee">
                     <li class="FormValueDropdown">
            <asp:Label runat="server" ID="lbl_MonthandYear" Text="Please Select a Month & Year:"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_SelectMonth" CssClass="SelectMonthTextBox">
            <asp:ListItem>--Select Month--</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">JANUARY</asp:ListItem>
                <asp:ListItem Selected="False" Value="2">FEBRUARY</asp:ListItem>
                <asp:ListItem Selected="False" Value="3">MARCH</asp:ListItem>
                <asp:ListItem Selected="False" Value="4">APRIL</asp:ListItem>
                <asp:ListItem Selected="False" Value="5">MAY</asp:ListItem>
                <asp:ListItem Selected="False" Value="6">JUNE</asp:ListItem>
                <asp:ListItem Selected="False" Value="7">JULY</asp:ListItem>
                <asp:ListItem Selected="False" Value="8">AUGUST</asp:ListItem>
                <asp:ListItem Selected="False" Value="9">SEPTEMBER</asp:ListItem>
                <asp:ListItem Selected="False" Value="10">OCTOBER</asp:ListItem>
                <asp:ListItem Selected="False" Value="11">NOVEMBER</asp:ListItem>
                <asp:ListItem Selected="False" Value="12">DECEMBER</asp:ListItem>
             </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddl_SelectYear" CssClass="SelectYearTextBox">
             <asp:ListItem>--Select Year--</asp:ListItem>
                <asp:ListItem>2011</asp:ListItem>
                <asp:ListItem Selected="True">2012</asp:ListItem>
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
             </asp:DropDownList>
           <asp:Button runat="server" ID="btn_ShowAttendence" Text="View Attendence" onclick="btn_ShowAttendence_Click"/>
                
                
        </li>
                    <ul class="GridView">
                        <li>
                            <asp:GridView ID="gridview_AttendanceRegisterEmployee" runat="server" AllowPaging="False " AutoGenerateColumns="False" BorderStyle="None" CellPadding="4" GridLines="None" Height="45px" Width="100%">
                               
								<HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                <asp:BoundField DataField="EmployeeName" HeaderText="Name " ItemStyle-CssClass="DeptDescription" />
                                    <asp:BoundField DataField="EmployeeCode" HeaderText="Code " ItemStyle-CssClass="DeptDescription" />
                                    <asp:BoundField DataField="DesignationDescription" HeaderText="Designation " ItemStyle-CssClass="DeptDescription" />
                                     <asp:BoundField DataField="DepartmentDescription" HeaderText="Department " />
                                      <asp:BoundField DataField="TotalPresent" HeaderText="Present "  />
                                      <asp:BoundField DataField="TotalAbsent" HeaderText="Absent " />
                                      <asp:BoundField DataField="TotalWeeklyOff" HeaderText="WeeklyOff "  />
                                      <asp:BoundField DataField="TotalPresentonWeeklyOff" HeaderText="PresentOnWeeklyOff "  />
                                       <asp:BoundField DataField="TotalHoliday" HeaderText="Holiday "  />
                                       <asp:BoundField DataField="TotalPresentonHoliday" HeaderText="PresentOnHoliday "  />
                                       <asp:BoundField DataField="TotalLeave" HeaderText="Leave "  />
                                </Columns>
                            </asp:GridView>
                        </li>
                    </ul>
                    <li class="FormSpacer" />
                </ul>
                <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground"   Style="display: none" CssClass="modalPopup" EnableViewState="true">
                    <ItemTemplate>
                        <ul>
                            <li>
                                <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
                            </li>
                        </ul>
                    </ItemTemplate>
                </IAControl:DialogBox>
            </div>
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