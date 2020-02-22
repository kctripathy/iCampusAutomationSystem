<%@ Page Title="Send SMS" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="SendSMS.aspx.cs" Inherits="TCon.iCAS.WebApplication.SendSMS" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="updatePanel_SendSMS">
        <ContentTemplate>
            <div class="innercontent">
                <ul id="SMS_UL">
                    <li>
                        <h1 class="PageTitle">Send SMS
                        </h1>
                        <asp:Label runat="server" ID="lblStatus" Text="" Font-Bold="true" ForeColor="Red" Font-Size="Medium" />
                    </li>
                    <li style="margin-bottom: 5px;">
                        <asp:Label runat="server" ID="lblMessage" Text="Message:" />
                        <asp:TextBox runat="server" ID="txtMessage" Rows="2" MaxLength="150" Font-Size="Medium" Text="" Width="100%" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Message" ControlToValidate="txtMessage"
                            Display="Dynamic" SetFocusOnError="true" ErrorMessage="Please type the sms first" ForeColor="Red" />
                        <ajaxToolkit:TextBoxWatermarkExtender runat="server" ID="txtwatermark_message" TargetControlID="txtMessage" WatermarkText="Please type the SMS, which need to be sent to the selected persons" />


                    </li>
                    <li>
                        <asp:CheckBox runat="server" ID="chk_Students" Checked="false" OnCheckedChanged="chk_Students_CheckedChanged" Text="Students" />
                        <asp:CheckBox runat="server" ID="chk_Staffs" Checked="false" OnCheckedChanged="chk_Staffs_CheckedChanged" Text="Staffs" />
                        <asp:Button runat="server" ID="btnShowRecords" Text="Display all the records to send SMS" OnClick="btnShowRecords_Click" CssClass="btn" />
                    </li>
                    <li style="height: 50px; overflow: auto; margin-top: 0px; width: 100%; border: solid 1px #ccc;">
                        <asp:RadioButtonList runat="server" ID="rblist_classes" RepeatDirection="Horizontal" RepeatColumns="8" RepeatLayout="Table">
                            <asp:ListItem Text="All" Value="0"></asp:ListItem>
                            <asp:ListItem Text="+2 Sc. 1st Year" Value="2"></asp:ListItem>
                            <asp:ListItem Text="+2 Sc. 2nd Year" Value="3"></asp:ListItem>
                            <asp:ListItem Text="+2 Arts 1st Year" Value="9"></asp:ListItem>
                            <asp:ListItem Text="+2 Arts 2nd Year" Value="10"></asp:ListItem>
                            <asp:ListItem Text="+3 Arts 1st Year" Value="12"></asp:ListItem>
                            <asp:ListItem Text="+3 Arts 2nd Year" Value="13"></asp:ListItem>
                            <asp:ListItem Text="+3 Arts 3rd Year" Value="14"></asp:ListItem>
                            <asp:ListItem Text="+3 Sc. 1st Year" Value="5"></asp:ListItem>
                            <asp:ListItem Text="+3 Sc. 2nd Year" Value="6"></asp:ListItem>
                            <asp:ListItem Text="+3 Sc. 3rd Year" Value="7"></asp:ListItem>
                        </asp:RadioButtonList>
                    </li>
                    <li class="FormButton_Top" style="margin-top: 10px; width: 100%; text-align: right;">
                        <asp:Button runat="server" ID="btnSendSMS" Text="Send SMS to All Selected Persons" OnClick="btnSendSMS_Click" />
                    </li>
                    <li>
                        <h4>Students:<asp:Label runat="server" ID="lblTextCount" Text="(0)" ForeColor="Blue" /></h4>
                        <%--<asp:CheckBox runat="server" ID="chkSelectUnselectAllStudents" Text="Select/Unselect All Staffs" OnCheckedChanged="chkSelectUnselectAllStudents_CheckedChanged" />--%>
                        <asp:Button runat="server" ID="btnSelectAll" Text="Select/Check All Students" OnClick="btnSelectAll_Click" />
                        <asp:Button runat="server" ID="btnUnSelectAll" Text="Deselect/Uncheck All Students" OnClick="btnUnSelectAll_Click" />

                    </li>
                    <li class="GridView" style="height: 400px; overflow: auto; margin-top: 20px; width: 50%;">

                        <asp:GridView ID="grdview_Students" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_StudentID" Visible="true" AutoPostBack="false" Checked="true" />
                                        <asp:Label runat="server" ID="lbl_EstablishmentID" Text='<%# Eval("StudentID") %>' Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StudentName" HeaderText="StudentName" Visible="true" />
                                <asp:BoundField DataField="Mobile" HeaderText="Phone (Mobile)" />
                                <asp:BoundField DataField="RollNo" HeaderText="Roll No." />
                                <asp:TemplateField HeaderText="Name of the Class">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbl_className" Text='<%# GetClassName(int.Parse(Eval("ClassID").ToString())) %>' Visible="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="StudentCode" HeaderText="StudentCode" Visible="false" />

                                <asp:BoundField DataField="EmailID" HeaderText="EmailID" Visible="false" />
                            </Columns>
                        </asp:GridView>

                    </li>
                    <li>
                        <h4>Staffs:
                            <asp:Label runat="server" ID="lblStaffCount" Text="(0)" ForeColor="Blue" /></h4>
                        <asp:Button runat="server" ID="ButtonSelectAllStaffs" Text="Select/Check All Staffs" OnClick="ButtonSelectAllStaffs_Click" />
                        <asp:Button runat="server" ID="ButtonUnSelectAllStaffs" Text="Deselect/Uncheck All Staffs" OnClick="ButtonUnSelectAllStaffs_Click" />

                    </li>
                    <li class="GridView" style="height: 400px; overflow: auto; margin-top: 20px; width: 50%;">
                        <asp:GridView ID="grdview_Staffs" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_EmployeeID" Visible="true" AutoPostBack="false" Checked="true" />
                                        <asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EmployeeName" HeaderText="Name" Visible="true" />
                                <asp:BoundField DataField="Mobile" HeaderText="Phone (Mobile)" />
                                <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" Visible="true" />
                                <asp:BoundField DataField="EmailID" HeaderText="EmailID" Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </li>

                </ul>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
        <ItemTemplate>
            <ul>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="PROGRESS"></asp:Label>
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
