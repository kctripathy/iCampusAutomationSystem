<%@ Page Title="Send Short Message for the College" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="SendShortMessage.aspx.cs" Inherits="TCon.iCAS.WebApplication.SendShortMessage" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .innercontent
        {
            margin: 0;
            padding: 0px;
            overflow: auto;
            color: #000033;
            border: solid 1px green;
        }

        #ContentPlaceHolder1_chkList_Classes,
        #DisplayRecordsUL li ul,
        #DisplayRecordsUL,
        #CreateMessaegUL
        {
            display: block;
            float: left;
            margin: 0px;
            padding: 0px;
            width: 100%;
            list-style-type: none;
        }

        #CreateMessaegUL
        {
            overflow: hidden;
        }

        #DisplayRecordsUL li
        {
            display: block;
            float: left;
            margin: 0px 1%;
            padding: 0px 1%;
            width: 46%;
        }

        #DisplayRecordsUL > li > ul > li
        {
            display: block;
            float: left;
            margin: 0px;
            padding: 0px;
            width: 100%;
        }

        #ContentPlaceHolder1_chkList_Classes li
        {
            display: block;
            float: left;
            width: 8%;
            border-left: solid 1px #ccc;
            margin: 0px 2px 0px 2px;
            padding: 0px 2px 0px 2px;
            text-align: center;
        }

            #ContentPlaceHolder1_chkList_Classes li:first-child
            {
                display: block;
                float: left;
                width: 8%;
                border-left: none;
                margin-left: 0px;
                padding-left: 0px;
                text-align: center;
            }

        #ContentPlaceHolder1_chkList_Classes > li > label
        {
            font-family: Lato, Verdana;
            font-weight: normal;
            font-size: 1em;
            color: navy;
        }

        #ContentPlaceHolder1_lblMessage
        {
            text-align: left;
            font-weight: 200;
        }

        .WatermarkExtender
        {
            font-family: Lato, Verdana;
            font-weight: normal;
            font-size: 1.1em;
            color: darkgrey;
        }

        .FormButtons
        {
            display: block;
            float: right;
            width: 47%;
            padding: 0;
            margin: 0;
        }

        .sendButton
        {
            text-align: right;
        }

        .chooseButton
        {
            text-align: left;
        }

        #ContentPlaceHolder1_grdview_Students > tbody > tr > td > span
        {
            font-family: 'Lato', sans-serif;
            font-size: 10pt;
            letter-spacing: -0.3px;
        }

        #ContentPlaceHolder1_grdview_Students
        {
            width: 100%;
            border-left: solid 2px cyan;
        }
    </style>
    <script type="text/javascript">
        function CheckAllStudents() {
            alert('ok-CheckAllStudents');
            var grid = document.getElementById('<%= grdview_Students.ClientID %>');

            var cell;
            if (grid.rows.length > 0) {
                for (i = 1; i < grid.rows.length–1; i++) {
                    cell = grid.rows[i].cells[3];
                    for (j = 0; j < cell.childNodes.length; j++) {
                        if (cell.childNodes[j].type == 'checkbox') {
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }
    </script>
    <asp:UpdatePanel runat="server" ID="updatePanel_SendSMS" UpdateMode="Always">
        <ContentTemplate>
            <h1 class="PageTitle">Send - Short Message Service (SMS):</h1>

            <div class="innercontent">

                <%--CREATE THE MESSAGE--%>
                <ul id="CreateMessaegUL">
                    <li>
                        <asp:Label runat="server" ID="lblMessage" Text="&nbsp;Please enter below the Message you want to send:" CssClass="PageSubTitle" Width="100%" />
                    </li>
                    <li>
                        <asp:TextBox runat="server" ID="txtMessage" Rows="1" MaxLength="150" Font-Size="Medium" Text="" Width="100%" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Message" ControlToValidate="txtMessage" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Message can't be left blank. Please enter the 'Short Message'" ForeColor="Red" />
                        <ajaxToolkit:TextBoxWatermarkExtender runat="server" ID="txtwatermark_message" TargetControlID="txtMessage" WatermarkText="Example: Please attend the staff council monthly meeting 2maro without any fail or reasons." WatermarkCssClass="WatermarkExtender" />
                        <asp:Label runat="server" ID="lblStatus" Text="" Font-Bold="true" ForeColor="Red" Font-Size="Medium" />
                    </li>
                    <li class="FormButtons sendButton">
                        <asp:TextBox Visible="false" runat="server" ID="txt1" Text="9938046866" />
                        <asp:Button Visible="false" runat="server" ID="Button2" Text="test SEND MESSAGE" OnClick="Button2_Click" CssClass="btn btn-primary" CausesValidation="true" />
                        <asp:Button runat="server" ID="btnSendSMS" Text="SEND MESSAGE" OnClick="btnSendSMS_Click" CssClass="btn btn-primary" CausesValidation="true" />
                    </li>
                    <li class="FormButtons chooseButton">
                        <%--<asp:CheckBox runat="server" ID="chk_Students" Checked="false" Text="Students" AutoPostBack="true" />--%>
                        <asp:CheckBox runat="server" ID="chk_Students" Checked="false" OnCheckedChanged="chk_Students_CheckedChanged" Text="Students" AutoPostBack="true" />
                        <asp:CheckBox runat="server" ID="chk_Staffs" Checked="false" OnCheckedChanged="chk_Staffs_CheckedChanged" Text="Staffs" />
                        <%--<asp:Button runat="server" ID="btnShowRecords" Text="Display Records" OnClick="btnShowRecords_Click" CssClass="btn  btn-primary btn-xs" CausesValidation="false" />--%>
                        <asp:Button runat="server" ID="btnShowRecords" Text="Display Records" OnClick="btnShowRecords_Click" CssClass="btn  btn-primary btn-xs" CausesValidation="false" />
                    </li>

                    <li>
                        <asp:CheckBoxList runat="server" ID="chkList_Classes" RepeatLayout="UnorderedList" Visible="false">
                            <asp:ListItem Text="+2 Arts 1st Year" Value="9"></asp:ListItem>
                            <asp:ListItem Text="+2 Sc. 1st Year" Value="2"></asp:ListItem>
                            <asp:ListItem Text="+3 Arts 1st Year" Value="12"></asp:ListItem>
                            <asp:ListItem Text="+3 Sc. 1st Year" Value="5"></asp:ListItem>
                            <asp:ListItem Text="+2 Arts 2nd Year" Value="10"></asp:ListItem>
                            <asp:ListItem Text="+2 Sc. 2nd Year" Value="3"></asp:ListItem>
                            <asp:ListItem Text="+3 Arts 2nd Year" Value="13"></asp:ListItem>
                            <asp:ListItem Text="+3 Sc. 2nd Year" Value="6"></asp:ListItem>
                            <asp:ListItem Text="+3 Arts 3rd Year" Value="14"></asp:ListItem>
                            <asp:ListItem Text="+3 Sc. 3rd Year" Value="7"></asp:ListItem>
                        </asp:CheckBoxList>

                    </li>
                </ul>


                <%--DISPLAY RECORDS--%>
                <ul id="DisplayRecordsUL">
                    <li>
                        <ul>
                            <li>
                                <span class="PageSubTitle">Students:
                                <asp:Label runat="server" ID="lblStudentsCount" Text="(0)" CssClass="StudentCountClass" />
                                </span>
                                <%--OnClick="btnSelectAll_Click"--%>
                                <asp:Button runat="server" ID="btnSelectAll" Text="Check All Students" OnClick="btnSelectAllStudents_Click" CssClass="btn btn-success btn-xs" />
                                <asp:Button runat="server" ID="btnUnSelectAll" Text="UnCheck All Students" OnClick="btnUnSelectAll_Click" CssClass="btn btn-success btn-xs" />
                            </li>
                            <li class="GridView">
                                <asp:GridView ID="grdview_Students" runat="server" AutoGenerateColumns="false" CssClass="GridView">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk_StudentID" Visible="true" AutoPostBack="false" Checked="true" />
                                                <asp:Label runat="server" ID="lbl_EstablishmentID" Text='<%# Eval("StudentID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="RollNo" HeaderText="Roll No." />--%>
                                        <asp:TemplateField HeaderText="Name of the Class">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_className" Text='<%# GetClassName(int.Parse(Eval("ClassID").ToString())) %>' Visible="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="StudentName" HeaderText="StudentName" Visible="true" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Phone (Mobile)" />

                                        <asp:BoundField DataField="StudentCode" HeaderText="StudentCode" Visible="false" />

                                        <asp:BoundField DataField="EmailID" HeaderText="EmailID" Visible="false" />
                                    </Columns>
                                </asp:GridView>
                            </li>
                        </ul>
                    </li>

                    <li>
                        <ul>
                            <li>
                                <span class="PageSubTitle">Staffs:
                                <asp:Label runat="server" ID="lblStaffCount" Text="(0)" CssClass="CountClass" />
                                </span>
                                <asp:Button runat="server" ID="ButtonSelectAllStaffs" Text="Select All Staffs" OnClick="ButtonSelectAllStaffs_Click" CssClass="btn btn-success btn-xs" />
                                <asp:Button runat="server" ID="ButtonUnSelectAllStaffs" Text="Uncheck All Staffs" OnClick="ButtonUnSelectAllStaffs_Click" CssClass="btn btn-success btn-xs" />
                            </li>
                            <li class="GridView">
                                <asp:GridView ID="grdview_Staffs" runat="server" AutoGenerateColumns="false" CssClass="GridView">
                                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                                    <RowStyle CssClass="RowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk_EmployeeID" Visible="true" AutoPostBack="false" Checked="true" />
                                                <asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EmployeeName" HeaderText="Name" Visible="true" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Phone (Mobile)" />
                                        <%--<asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" Visible="true" />--%>
                                        <%--<asp:BoundField DataField="EmailID" HeaderText="EmailID" Visible="true" />--%>
                                    </Columns>
                                </asp:GridView>
                            </li>
                        </ul>
                    </li>

                </ul>
                <ul>
                    <li class="FormButton">
                        <asp:Button runat="server" ID="Button1" Text="SEND SHORT MESSAGE" OnClick="btnSendSMS_Click" CssClass="btn btn-primary" CausesValidation="true" />
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
