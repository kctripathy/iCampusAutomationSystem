<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="UserLog.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.UserLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">

	<asp:GridView runat="server" ID="gview_UserLog" AutoGenerateColumns="true" /> 
      
    
	<%--<asp:SqlDataSource runat="server" DataSourceMode="DataReader" ID="ds_UserLog" ConnectionString="<%$ ConnectionStrings:Micro-DEV (Development) %>" SelectCommand="dbo.pADM_Users_Log_Select" />--%>
</asp:Content>
