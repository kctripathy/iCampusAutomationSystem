<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Search.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.ICAS.UC_Search" %>

    <ul>
        <li id="SText">
            <asp:TextBox runat="server" ID="txt_Search" CssClass="SearchTextBox" />
        </li>
        <li id="SButton">
            <asp:Button runat="server" ID="btn_Search" Text=" GO " />
        </li>
    </ul>
