<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="TCon.iCAS.WebApplication.APPS.UserRegister" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanelUserRegister" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="innercontent">
                <h1 class="PageTitle">
                    <asp:Literal runat="server" ID="lit_PageTitle" /></h1>
                <div id="UserLoginDiv">
                    <ul id="UserLoginUL">
                        <li class="FormMessage">
                            <asp:Literal runat="server" ID="lit_Message" Text="" />
                        </li>
                    </ul>

                    <ul id="UserRegisterUL" style="display: block;">
                        <li>
                            <asp:RadioButtonList runat="server" ID="rbList_Salutation" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Mr." Value="Male" Selected="True" />
                                <asp:ListItem Text="Miss." Value="Female" Selected="False" />
                                <asp:ListItem Text="Mrs." Value="Female" Selected="False" />
                            </asp:RadioButtonList>
                            <asp:TextBox runat="server" ID="txt_UserFullName" MaxLength="400" CausesValidation="true" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Name" ControlToValidate="txt_UserFullName" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Invalid Input! it must be alphabets" />
                            <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender1" TargetControlID="txt_UserFullName" WatermarkText="Enter Name of the Student/Staff/Parent/Guest:" WatermarkCssClass="WatermarkCssClass" />
                        </li>
                        <li>
                            <asp:TextBox runat="server" ID="txt_UserPhone" OnLoad="txt_UserPhone_Load" MaxLength="10" />
                            <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender2" TargetControlID="txt_UserPhone" WatermarkText="Mobile Phone Number:" WatermarkCssClass="WatermarkCssClass" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_MobileNo" ControlToValidate="txt_UserPhone" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Invalid Phone Number! It must be number" />

                            <asp:Panel runat="server" ID="panel_UserOTPVerification" Visible="false">
                                <asp:TextBox runat="server" ID="txt_UserOTPVerificationCode" MaxLength="4" Width="80px" />
                                <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender_UserOTPVerification" TargetControlID="txt_UserOTPVerificationCode" WatermarkText="Enter OTP" WatermarkCssClass="WatermarkCssClass" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_UserOTPVerification" ControlToValidate="txt_UserOTPVerificationCode" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Invalid OTP" />
                                <asp:Button runat="server" ID="btn_VerifyOTP" Text="Verify OTP" CssClass="btn btn-success" OnClick="btn_VerifyOTP_Click" CausesValidation="false" />
                            </asp:Panel>




                            <asp:TextBox runat="server" ID="txt_UserEmail" OnUnload="txt_UserEmail_Unload" />
                            <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender3" TargetControlID="txt_UserEmail" WatermarkText="Email Address:" WatermarkCssClass="WatermarkCssClass" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_EmailId" ControlToValidate="txt_UserEmail" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Invalid Email Address!" />

                            <asp:Panel runat="server" ID="panel_UserEmailVerification" Visible="false">
                                <asp:TextBox runat="server" ID="txt_UserEmailVerification" MaxLength="4" Width="80px" />
                                <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender_UserEmailVerification" TargetControlID="txt_UserEmailVerification" WatermarkText="Enter OTP" WatermarkCssClass="WatermarkCssClass" />
                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_UserEmailVerification" ControlToValidate="txt_UserEmailVerification" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Invalid OTP" />
                                <asp:Button runat="server" ID="Button1" Text="Verify Email" CssClass="btn btn-success" OnClick="btn_VerifyOTP_Click" CausesValidation="false" />
                            </asp:Panel>
                        </li>
                        <li>
                            <h4 class="RegisterTitleText">To verify you are a human, Please enter the code as shown below:</h4>
                            <asp:Image ID="img_VerifyCaptcha" runat="server" ImageUrl="~/Apps/UserCaptchaImage.aspx" CssClass="UserCaptchaImage" />
                            <asp:TextBox runat="server" ID="txt_UserCaptcha" Text="" MaxLength="5" OnUnload="txt_UserCaptcha_Unload" CssClass="UserCaptchaText" Width="48%" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidatorUserCaptcha" ControlToValidate="txt_UserCaptcha" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Invalid Email Address!" />
                            <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtenderUserCaptcha" TargetControlID="txt_UserCaptcha" WatermarkText="Enter the Captcha!" WatermarkCssClass="WatermarkCssClass" />
                        </li>
                        <li>
                            <asp:Button runat="server" ID="btn_RegisterNewUser" Text="Register New User " CssClass="btn btn-primary registerButton" OnClick="btn_RegisterNewUser_Click" CausesValidation="true" />
                        </li>
                        <li>
                            <asp:RadioButtonList runat="server" Visible="false" ID="rbList_UserType" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbList_UserType_SelectedIndexChanged">
                                <asp:ListItem Text="Alumni" Value="6" Selected="False" />
                                <asp:ListItem Text="Student" Value="4" Selected="True" />
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
