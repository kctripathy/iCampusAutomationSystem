<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.Roles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel runat="server" ID="Panel">
        <ContentTemplate>
            <ul class="GridView">
                <li style="display: none">
                    <asp:Button runat="server" ID="Button1" OnClick="UpdateButton_Click" Text="Update" />
                    <asp:Button runat="server" ID="UpdateButton" OnClick="UpdateButton_Click" Text="Update" />
                </li>
                <li>
                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                        <ProgressTemplate>
                            <div id="UpdateProgress">
                                <div class="UpdateProgressArea">
                                    <h1 class="PageTitle">Updating... please wait</h1>
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </li>
                <li>
                    <asp:TextBox runat="server" ID="txt_RoleDesc" Width="50%" Font-Size="Large" />
                    <ajax:TextBoxWatermarkExtender runat="server" ID="watermark_NoticeTitleWater" TargetControlID="txt_RoleDesc" WatermarkText="Please enter the new role description " WatermarkCssClass="" />
                    <asp:RequiredFieldValidator ID="requiredFieldValidator_UserLogInName" runat="server" ControlToValidate="txt_RoleDesc" Display="Dynamic" ErrorMessage="Please enter the role description" SetFocusOnError="true" />
                    <asp:Button runat="server" ID="btn_Save" Text="Add New Role" OnClick="btn_Save_Click" CssClass="btn btn-primary" />
                </li>
                <li>
                    <asp:GridView runat="server" ID="gview_Roles" AutoGenerateColumns="true" />
                </li>
            </ul>

            <IAControl:DialogBox ID="dialog_Message" runat="server"
                Title="Displaying Publication Record:-"
                BackgroundCssClass="modalBackground"
                Style="display: none;"
                CssClass="modalPopup"
                EnableViewState="true">
                <ItemTemplate>
                    <ul id="DialogBoxUL">
                        <li>
                            <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
                        </li>
                    </ul>
                </ItemTemplate>
            </IAControl:DialogBox>
        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
