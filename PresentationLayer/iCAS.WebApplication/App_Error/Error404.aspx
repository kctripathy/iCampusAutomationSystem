<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="Micro.WebApplication.App_Error.Error404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="innercontent">
        <h1 class="PageTitle">ERROR 404: File not found.</h1>
        <p class="ErrorMessage">Ooups!, Its an error </p>
        <hr />
        <h2>The file (<i><asp:Literal runat="server" ID="lit_FilePath" /></i>) doesn't exists.</h2>
        <asp:Literal runat="server" ID="lit_Message" />
    </div>
</asp:Content>
