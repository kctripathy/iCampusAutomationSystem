<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageDevicePermissions.aspx.cs" Inherits="Micro.WebApplication.MicroERP.HRMS.ManageDevicePermissions" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel_LeaveApplication">
        <ContentTemplate>
            <ul id="BioReader">
                <li id="Mode">
                    <h1 class="PageTitle">
                        <asp:Literal runat="server" ID="lit_PageTitle" Text="BIO-METRICS DEVICE:-" />
                        <asp:Label runat="server" ID="lbl_DataOperationMode" />
                    </h1>
                </li>
                <li class="PageSubTitle">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="&nbsp;&nbsp;Device&nbsp;" />
                    <asp:Label ID="lbl_Device_Status" runat="server" Text="Status:-"></asp:Label>
                    <asp:TextBox ID="txt_DeviceStatus" runat="server" CssClass="CountTextBox" Enabled="true" Width="60"></asp:TextBox>
                    <asp:DropDownList ID="ddl_Year" runat="server" CssClass="YearList" Width="40%" Height="26px" />
                    <asp:Literal ID="lblStatus" runat="server" Text="...." />
                </li>
                <li class="FormButton_Top">
                    <asp:Button ID="btn_Connect" runat="server" OnClick="btn_Connect_Click" Text="Connect" CssClass="btn btn-sucess" />
                    <asp:Button ID="btn_Import" runat="server" OnClick="btn_Import_Click" Text="Import"  CssClass="btn btn-sucess"/>
                </li>
                <li class="AppMessages">
                    
                </li>
                <li class="FormLabel">
                    
                </li>
                <li class="FormValue">
                    
                </li>
                <li>
                    <asp:GridView ID="gridview_ImportList" runat="server" CssClass="GridView" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None" CellPadding="4" GridLines="Horizontal" Height="45px" OnPageIndexChanging="gridview_ImportList_PageIndexChanging" PageSize="12" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Time" DataFormatString="{0:h:mm tt}" HeaderText="Time" />
                        </Columns>
                    </asp:GridView>
                </li>

            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
