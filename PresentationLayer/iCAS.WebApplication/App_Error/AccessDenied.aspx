<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="Micro.WebApplication.App_Error.AccessDenied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <div>
        <h1 class="PageTitle" style="width: 150%; background-color:none;color:black;">Access Denied:</h1>
        <br />
        <h1 class="BigErrorText"></h1>
        <ul>
            <li class="BigErrorText">
               <h1 class="BigErrorText">Access denied! </h1>
               Please click here to <a href="../APPS/UserLogin.aspx" style="color:red; font-size:14pt; font-weight:normal; text-decoration:underline;">login</a>, so that you can access the requested page.
            </li>
        </ul>
    </div>
</asp:Content>
