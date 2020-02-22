<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Login.ascx.cs" Inherits="Micro.WebApplication.App_UserControls.UC_Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:UpdatePanel ID="updatePanel_User" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="multiView_Login" runat="server" ActiveViewIndex="0">
            <asp:View ID="view_InputControl" runat="server">
                <ul id="UC_Login_UL_input">
                    <li class="FullWidthRowTitle">Please <a href="../APPS/Login.aspx">Login</a>: </li>
                    <li class="UCFormLabel">
                        <asp:Label runat="server" ID="lbl_UCLoginId" Text="User ID:" />
                    </li>
                    <li class="UCFormValue">
                        <asp:TextBox runat="server" ID="txt_UCLoginId" CssClass="LoginTextBox" />
                    </li>
                    <li class="UCFormLabel">
                        <asp:Label runat="server" ID="Label1" Text="Password:" />
                    </li>
                    <li class="UCFormValue">
                        <asp:TextBox runat="server" ID="txt_UCPassword" TextMode="Password" CssClass="LoginTextBox" />
                    </li>
                    <li class="UCFormLabel">. </li>
                    <li class="UCFormValueForgotPwd">
                        <asp:LinkButton runat="server" ID="lnkBtn_ForgotPassword" Text="Forgot Password? Click..."
                            CausesValidation="false" OnClick="lnkBtn_ForgotPassword_Click" />
                    </li>
                    <!-- Button Submit -->
                    <li class="FullWidthRowLoginUC">
                        <asp:CheckBox runat="server" ID="chk_Remember" TextAlign="Right" Height="26px" Text="Remember My Id." />
                        <asp:Button runat="server" ID="btn_UCLogin" Text="  " CssClass="UC_BtnLogin" OnClick="btn_UCLogin_Click" />
                        <asp:Literal runat="server" ID="lit_Message" Text="" />
                    </li>
                    <li class="FullWidthRowLoginLinks2">
                        <ul>
                            <li class="LoginLinkLi"><a href="#" class="LoginLinks">Create Your Own PROFILE</a></li>
                            <li class="LoginLinkLi"><a href="#" class="LoginLinks">Log into: iCAS WEB APPS.</a></li>
                            <li class="LoginLinkLi"><a href="#" class="LoginLinks">View/Sign Guest Book</a></li>
                            <li class="LoginLinkLi"><a href="#" class="LoginLinks">Odisha / Odia SAHiTYA</a></li>
                        </ul>
                    </li>
                </ul>
            </asp:View>
            <asp:View ID="view_LoginSuccees" runat="server">
                <ul id="UC_Login_Success">
                     
                    <li class="FullWidthRowTitle">
                        <asp:Literal runat="server" ID="lit_WelcomeText" Text=" Welcome <b>Guest</b>" />
                    </li>
                   
                    <li class="UCFormLabelLogin0">
                        <asp:Label runat="server" ID="lbl_CodeLabel" Text="LoginID / User Code: " />
                    </li>
                    <li class="UCFormValueLogin0">
                        <asp:Label runat="server" ID="lbl_CodeValue" Text="----" />
                    </li>
                    <li class="UCFormLabelLogin0x">
                        <asp:Label runat="server" ID="Label10" Text="Logged User Type: " />
                    </li>
                    <li class="UCFormValueLogin0x">
                        <asp:Label runat="server" ID="lbl_UserType" Text="----" />
                    </li>
                    <li class="UCFormLabelLogin0">
                        <asp:Label runat="server" ID="Label3" Text="User Role / Group: " />
                    </li>
                    <li class="UCFormValueLogin0">
                        <asp:Label runat="server" ID="lbl_Role" Text="----" />
                    </li>
                    <li class="FullWidthRowTitle">
                        <asp:Label runat="server" ID="lbl_NameLabel" Text="Name:" />
                    </li>
                    <li class="FullWidthRowTitle">
                        <asp:Label runat="server" ID="lbl_NameValue" Text="----" />
                    </li>
                    <li id="PhotoLoggedOnUser1">
                    <ul>
                        <li>
                            <asp:LinkButton runat="server" ID="lnk_EditProfile" Text="Edit Your Profile" /> 
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="lnk_EditPicture" Text="Edit Profile Picture" />
                        </li>
                        <li> 
                            Total Msg.(s): <asp:LinkButton runat="server" ID="lnk_UserMessages" Text= "{0} " CommandName="lnk_UserMessages_Clicked" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="lnk_YourFeedback" Text="Your Feedback" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton1" Text="Your Dashboard" />
                        </li>
                    </ul>
                    </li>
                    <li id="PhotoLoggedOnUser2">
                    
                        <asp:Image runat="server" ID="img_LoggedOnUser"   CssClass="LoginPhoto" ImageUrl="~/App_Data/USER-PHOTO/stud-01.png" Width="80" Height="80" BorderStyle="Solid" BorderWidth="1"/>
                        

                    </li>
                    <li class="FullWidthRowTitle">
                        <asp:Label runat="server" ID="lbl_LastLoginDateTime" Text="" />
                        Today: <asp:Label runat="server" ID="lbl_CurrentDayDateTime" Text="" />
                    </li>
       <li class="LoginImgLink">
            <a href="#" target="_blank">
                <img src="../Themes/Common/Images/ICAS-SN-live-class.jpg" />
            </a>
       </li>
       <li class="LoginImgLink">
            <a href="https://portal.cvc.gov.in/portal/index.jsp" target="_blank">
                <img src="../Themes/Common/Images/LOGIN-links-h40px-corruptio.jpg" />
            </a>
       </li>
                    <%--<li class="FullWidthRowTitle">
                        <asp:Label runat="server" ID="Label8" Text="Today:" />
                    </li>--%>
                   
                    <%--<li class="UCFormLabelLogin2">
                        <asp:Label runat="server" ID="Label2" Text="Current Date :" />
                    </li>
                    <li class="UCFormValueLogin2">
                        <asp:Label runat="server" ID="lbl_CurrentDayDateTimeWeek" Text="Mon, 10 Aug 2012 20:04" />
                    </li>
                    <li class="FullWidthRowLoginLinks">
                        <ul>
                            <li><a href="#" class="LoginLinks">Edit Identity</a></li>
                            <li><a href="#" class="LoginLinks">My Dashboard</a></li>
                            <li><a href="#" class="LoginLinks">Manage Feedbacks</a></li>
                            <li><a href="../APPS/Logout.aspx?SRC=UC" class="LoginLinks">LOG OUT</a>
                                <asp:LinkButton runat="server" ID="lnkBtn_SignOut" Text="Sign me Out" OnClick="lnkBtn_SignOut_OnClick" />
                            </li>
                            <li id="FullWidthRowLoginLinksAdmin" runat="server"><a href="../APPS/ADMIN/Default.aspx"
                                class="LoginLinksAdmin">Admin Website</a> </li>
                        </ul>
                    </li>--%>
                </ul>
            </asp:View>
            <asp:View ID="view_LoginLink" runat="server">
                <ul id="UC_Login_UL">
                    <li class="FullWidthRowTitleLogin"><a href="../APPS/Login.aspx">Please Click here to
                        <b>LOGIN</b> into TSDC - iCAS <asp:Label runat="server" ID="lit_version" Text="v1.2.3.4" /></a></li>
                    <li class="FullWidthRowTitleLogin"><a href="../APPS/Login.aspx">Are you a new User? Please Click here
                        for </b> your Registration</a></li>
                    <li class="FullWidthRowTitleLogin"><a href="../APPS/ICAS/ALUMNI/Default.aspx">Are you an Alumni/Ex-Student?
                        Click here for Registration</a></li>
                     <li class="LoginImgLink">
                            <a href="http://india.gov.in/services/online-services" target="_blank">
                                <img src="../Themes/Common/Images/LOGIN-links-h40px-services.jpg" />
                            </a>
                     </li>
                     <li class="LoginImgLink">
                            <a href="http://rti.india.gov.in/" target="_blank">
                                <img src="../Themes/Common/Images/LOGIN-links-h40px-rti.jpg" />
                            </a>
                     </li>
                     <li class="LoginImgLink">
                            <a href="https://portal.cvc.gov.in/portal/index.jsp" target="_blank">
                                <img src="../Themes/Common/Images/LOGIN-links-h40px-corruptio.jpg" />
                            </a>
                     </li>
                     <li class="LoginImgLink">
                            <a href="http://www.bdpur.org/" target="_blank">
                                <img src="../Themes/Common/Images/LOGIN-links-h40px-bdpur.jpg" />
                            </a>
                     </li>   
                </ul>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
