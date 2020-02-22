<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="WebMenus.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.WebMenus" %>
<%@ Register src="../../App_UserControls/Menu/UC_MenuDynamic.ascx" tagname="UC_MenuDynamic" tagprefix="micro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
.<micro:UC_MenuDynamic ID="UC_MenuDynamic1" runat="server" />
&nbsp;
</asp:Content>
