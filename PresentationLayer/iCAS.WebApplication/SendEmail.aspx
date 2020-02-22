<%@ Page Title="Send SMS" Language="C#" MasterPageFile="~/App_MasterPages/ICAS-Reports.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="TCon.iCAS.WebApplication.SendEmail" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERPReport" runat="server">
 
    <asp:UpdatePanel runat="server" ID="updatePanel_SendSMS">
        <ContentTemplate>
            <ul id="SMS_UL">
                <li>
                     <h1 class="PageTitle">
                        Send Email
                    </h1>  
                </li>
                <li style="margin-bottom: 5px;">
                    <asp:Label runat="server" ID="lblMessage" Text="Please type here your email message:" />
                    <asp:TextBox runat="server" ID="txtMessage" Rows="6" Text="" Width="100%" TextMode="MultiLine" />
                </li>
                <li>
                    <asp:CheckBox runat="server" ID="chk_Students" Checked="false" OnCheckedChanged="chk_Students_CheckedChanged" Text="Students" />
                    <asp:CheckBox runat="server" ID="chk_Staffs" Checked="false" OnCheckedChanged="chk_Staffs_CheckedChanged" Text="Staffs" />
                    <asp:Button runat="server" ID="btnShowRecords" Text="Display" OnClick="btnShowRecords_Click" CssClass="btn" />
                    <asp:Button ID="btnSelectAllStaffs" runat="server" Text="Select All Staffs" OnClick="btnSelectAllStaffs_Click" CssClass="btn" Visible="false" />
                    <asp:Button ID="btnSelectAllStudents" runat="server" Text="Select All Students" OnClick="btnSelectAllStudents_Click" CssClass="btn" Visible="false" />

                </li>


                <li class="GridView" style="height: 300px; overflow: auto; margin-top: 20px; width: 50%;">
                    <h4>Students:</h4>
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
                            <asp:BoundField DataField="StudentCode" HeaderText="StudentCode" Visible="true" />

                            <asp:BoundField DataField="EmailID" HeaderText="EmailID" Visible="false" />
                        </Columns>
                    </asp:GridView>

                </li>
                <li class="GridView" style="height: 300px; overflow: auto; margin-top: 20px; width: 50%;">
                    <h4>Staffs:</h4>

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
                <li class="FormButton_Top" style="margin-top: 10px;">
                    <asp:Button runat="server" ID="btnSendSMS" Text="Send Email to All Selected Persons" OnClick="btnSendSMS_Click" />
                </li>
            </ul>
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
</asp:Content>
