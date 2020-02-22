<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Name.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.Common.UC_Name" %>


    <ul>
        <li class="FormLabel">
            <asp:Label ID="lbl_Saluation" runat="server" Text="Select :" />
            <asp:Label ID="lbl_SalutationValidation" runat="server" Text="*" CssClass="ValidationColor" />
        </li>
        <li class="FormValue">
            <asp:DropDownList ID="ddl_Salutation" runat="server" AutoPostBack="True" />
            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Salutation" ControlToValidate="ddl_Salutation" Display="Dynamic" SetFocusOnError="true" />
            <asp:TextBox ID="txt_Name" runat="server" />
            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Name" ControlToValidate="txt_Name" Display="Dynamic" SetFocusOnError="true" />
            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Name" ControlToValidate="txt_EmployeeName" Display="Dynamic" SetFocusOnError="true" />
        </li>
    </ul>
  
