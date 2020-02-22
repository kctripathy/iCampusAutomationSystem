<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="Micro.WebApplication.App_Error.AccessDenied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <div>
        <h1 class="PageTitle" style="width: 150%; background-color:none;color:black;">Access Denied:</h1>
        <br />
        <h1 class="BigErrorText"></h1>
        <ul>
            <li class="BigErrorText">
               <h1 class="BigErrorText">Authentication failed! </h1>
               
               Please click here to <a href="../APPS/UserLogin.aspx" style="color:red; font-size:14pt; font-weight:normal; text-decoration:underline;">login</a>, so that you can access the requested page.
            </li>
            <li>
                <p class="ErrorMessage">
                    Kindly be informed that, certain pages requires to pass through a valid 'authentication' or 'login' process. 
                </p>
                <p>
                    Means, you must have to <a href="../APPS/UserLogin.aspx">log in</a> to this website by supplying valid login credentials (user name & password) to access some of the pages.
                </p>
            </li>
            <li style="margin:20px 0px;">
                <asp:Label ID="lbl_SupportMessage" runat="server" Text="Label"></asp:Label>
                
            </li>
        </ul>
    </div>
</asp:Content>
