<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master"
    AutoEventWireup="true" CodeBehind="AttendanceRegisters.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.AttendanceRegisters" %>

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
                <ul  id="AttendanceRegisters">
                    <li class="FormLabel">
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
                    </li>
                    <li class="FormValue">
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
                   <asp:Button runat="server" ID="btn_ShowAttendence" Text="ShowAttendence" OnClick="btn_ShowAttendence_Click" />
                    </li>
                    
                    </ul>
                  <ul class="GridView">
                        <li>
                            <asp:GridView ID="gridview_AttendanceRegisterEmployee" runat="server" AllowPaging="False "
                                ShowFooter="true" DataKeyNames="IsPresent, IsAbsent,IsWeeklyOff,IsPresentOnWeeklyOff,IsHoliday,IsPresentOnHoliday,IsLeave"
                                OnRowCommand="gridview_AttendanceRegisterEmployee_RowCommand" AutoGenerateColumns="False"
                                BorderStyle="None" CellPadding="4"  Height="45px" Width="100%" CssClass="GridView" GridLines="Both"
                                OnRowDataBound="gridview_AttendanceRegisterEmployee_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="DateOfAttendance" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Date" />
                                    <asp:BoundField DataField="ShiftAlias" HeaderText="Shift" />
                                    <asp:BoundField DataField="InTime" HeaderText="NewTime" DataFormatString="{0:h:mm tt}" />
                                    <asp:BoundField DataField="OutTime" HeaderText="OutTime" DataFormatString="{0:h:mm tt}" />
                                    <asp:TemplateField HeaderText="Present">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_Present" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbl_TotalPrsent" runat="server" Text='<%# Eval("IsPresent") %>' />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Absent">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_Absent" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbl_TotalAbsent" runat="server" Text='<%# Eval("IsAbsent") %>' />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="WeeklyOff">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_IsWeeklyOff" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbl_TotalWeeklyOff" runat="server" Text='<%# Eval("IsWeeklyOff") %>' />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PresentWeeklyOff">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_IsPresentOnWeeklyOff" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbl_PresentOnWeeklyOff" runat="server" Text='<%# Eval("IsPresentOnWeeklyOff") %>' />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Holiday">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_IsHoliday" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbl_Holiday" runat="server" Text='<%# Eval("IsHoliday") %>' />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PresentOnHoliday">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_IsPresentOnHoliday" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbl_PresentOnHoliday" runat="server" Text='<%# Eval("IsPresentOnHoliday") %>' />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leave">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_IsLeave" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbl_Leave" runat="server" Text='<%# Eval("IsLeave") %>' />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </li>
                    </ul>
                    <li class="FormSpacer" />
           
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
