<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="TCon.iCAS.WebApplication.APPS.UserLogin" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="innercontent">
                <h1 class="PageTitle">Login | New User Registration:</h1>
                <div id="UserLoginDiv">
                    <ul id="UserLoginUL">
                        <li class="FormMessage">
                            <asp:Literal runat="server" ID="lit_Message" Text="" />
                        </li>
                        <%--User Name--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_UserName" Text="Please enter your 'Login ID' / Mobile phone number" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_UserName" Text="" MaxLength="10" CssClass="LoginTextClass" />
                            <%--<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_UserName4Login" ControlToValidate="txt_UserName" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Invalid User Name, it should alphanumeric!" />--%>
                            <%--<asp:RequiredFieldValidator ID="requiredFieldValidator_UserName" runat="server" ErrorMessage="User Name can't be blank!" ControlToValidate="txt_UserName" CssClass="ValidateMessage"></asp:RequiredFieldValidator>--%>
                            <%--<ajax:TextBoxWatermarkExtender runat="server" ID="watermarkTxt_UserName" TargetControlID="txt_UserName" WatermarkText="Hints: Your registerd Phone number is your login identity!" WatermarkCssClass="WatermarkCssClass" />--%>
                        </li>
                        <%--User Password--%>
                        <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Password" Text="Please provide your Password:" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_Password" Text="" TextMode="Password" CssClass="LoginTextClass" MaxLength="20" />
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_Password" runat="server" ErrorMessage="Password can't left blank!!!" ControlToValidate="txt_Password" CssClass="ValidateMessage"></asp:RequiredFieldValidator>
                        </li>
                        <%--Remember User Name--%>
                        <li class="FormLabel">
                            <asp:CheckBox runat="server" ID="chk_Remember" TextAlign="Right" Text="&nbsp;Remember me?" Font-Bold="false" CssClass="RememberMe" />
                            &nbsp;|&nbsp;
                            <asp:LinkButton runat="server" ID="lnkBtn_ForgotPassword" Text="&nbsp;&nbsp;Forgot Password?" OnClick="lnkBtn_ForgotPassword_Click" CausesValidation="false" />
                        </li>
                        <!-- Button Submit -->
                        <li class="FormButtonLogin" style="margin-top: 5px; text-align:center;">
                            <asp:Button runat="server" ID="btn_Login" Text="LOG IN | SIGN IN" OnClick="btn_Login_Click" CssClass="btn btn-primary" />
                        </li>
                    </ul>

                    <ul id="UserRegisterUL" style="display: block;">
                        <li>
                            <h4 class="PageSubTitle">New User Registration? Please choose the type of user:</h4>
                        </li>
                        <li>
                            
                            <asp:RadioButtonList runat="server" AutoPostBack="true" ID="rbList_UserType" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbList_UserType_SelectedIndexChanged">
                                <asp:ListItem Text="Alumni" Value="6" Selected="False" />
                                <asp:ListItem Text="Student" Value="4" Selected="False" />
                                <asp:ListItem Text="Staff" Value="2" Selected="False" />
                                <asp:ListItem Text="Parent" Value="5" Selected="False" />
                                <asp:ListItem Text="Guest/Guardian" Value="7" Selected="False" />
                            </asp:RadioButtonList>
                        </li>
                         

                    </ul>
                </div>
                <div id="CompanySelection" style="display: none;">
                    <asp:RadioButtonList runat="server" ID="radioBtnListCompany" RepeatDirection="Horizontal" RepeatLayout="Table">
                        <asp:ListItem Text="TSDC" Value="T" Selected="True" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <IAControl:DialogBox ID="dialog_Message"
                runat="server"
                Title="Message:"
                BackgroundCssClass="modalBackground"
                Style="display: none" CssClass="modalPopup" EnableViewState="true">
                <ItemTemplate>
                    <ul>
                        <li>
                            <asp:Literal ID="lit_TheDialogMessage" runat="server" Text="" />
                        </li>
                    </ul>
                </ItemTemplate>
            </IAControl:DialogBox>

            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                <ProgressTemplate>
                    <div id="UpdateProgress">

                        <div class="UpdateProgressAreaLogin">
                            <span class="UpdateProgressAreaTextLogin">Validating...</span>
                        </div>

                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
