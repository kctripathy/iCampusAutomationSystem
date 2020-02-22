<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS-Reports.Master" AutoEventWireup="true" CodeBehind="StaffReports.aspx.cs" Inherits="TCon.iCAS.WebApplication.APPS.ICAS.REPORTS.StaffReports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERPReport" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Employee Report Master:-" />
    </h1>
    <%--<asp:UpdatePanel runat="server" ID="updatepanel_StudentReportMaster">
        <ContentTemplate>
            
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:MultiView ID="Employeeeport_Multi" runat="server">
                <asp:View ID="InputControls" runat="server">
                    <div>                        
                        <ul class="SearchBox">
	<li class="SearchLabel">
		<asp:Label runat="server" ID="lbl_SearchTitle" Text="Search XYZ(s), where:" />
	</li>
	<li class="SearchFields">
		<asp:DropDownList ID="ddl_SearchField" runat="server" Width="110px" 
            AutoPostBack="false">
			<asp:ListItem Selected="True" Value="0">[--Select--]</asp:ListItem>
			<asp:ListItem Text="Employee Name" Value="EmployeeName" />
			<asp:ListItem Text="Employee Code" Value="Employee Code" />
			<asp:ListItem Text="DepartmentID" Value="DepartmentID" />
		</asp:DropDownList>
	</li>
	<li class="SearchOperator">
		<asp:DropDownList ID="ddl_SearchOperator" runat="server" Width="75px">
			<asp:ListItem Value="0" Selected="True" >-Select-</asp:ListItem>
            <asp:ListItem Text="Starts With" Value="1"></asp:ListItem>
            <asp:ListItem Text="Contains" Value="2"></asp:ListItem>
			<asp:ListItem Value="3" >EqualsTo</asp:ListItem>
		</asp:DropDownList>
	</li>
	<li class="SearchText">
		<asp:TextBox runat="server" ID="txt_SearchText" />
		<ajax:TextBoxWatermarkExtender runat="server" ID="txtWaterMark_Search" TargetControlID="txt_SearchText" WatermarkText="Enter search text here" WatermarkCssClass="WatermarkClass" />
	</li>
	<li class="SearchButton">
		<asp:Button runat="server" ID="btn_SearchNow" Text="&nbsp;GO&nbsp;" OnClick="btn_SearchNow_Click" />
	</li>
	<%--<li class="SearchMessage">
		<asp:Label runat="server" ID="lbl_SearchResult" Text="" CssClass="ValidateMessage" />
	</li>--%>
</ul>
                    </div>
                    </asp:View>
                    <asp:View ID="ViewReport" runat="server">
                    <ul>
                     <li class="FormButton_Top">
                            <asp:Button ID="btn_SearchNew" runat="server" Text="Click Back To Search" 
                                onclick="btn_SearchNew_Click" />
                     </li>
                    </ul>
                        <CR:CrystalReportViewer ID="CrystalReportViewer_Employee" runat="server" 
                            AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" 
                            ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
                    
                    </asp:View>
            </asp:MultiView>
</asp:Content>
