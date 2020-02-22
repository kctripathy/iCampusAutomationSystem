<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="LTPL.ICAS.WebApplication.ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel_Establishment" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1 class="PageTitle">Contact Us:</h1>

            <div id="ColumnOne">
                <ul id="ContactUs">
                    <li class="FormLabel">Contact For: </li>
                    <li class="FormValue">
                        <asp:DropDownList runat="server" ID="ddl_ContactReason" AutoPostBack="true">
                            <asp:ListItem Text="Admission" Value="Admission" Selected="True" />
                            <asp:ListItem Text="Appointment " Value="Appointment" />
                            <asp:ListItem Text="Feedback" Value="Feedback" />
                            <asp:ListItem Text="Suggestion" Value="Suggestion" />
                            <asp:ListItem Text="Events" Value="Events" />
                        </asp:DropDownList>
                    </li>
                    <!-- sender's name -->
                    <li class="FormLabel">
                        <asp:Label runat="server" ID="lbl_Name" Text="Sender's Name:" />
                    </li>
                    <li class="FormValue">
                        <asp:TextBox runat="server" ID="txt_Name" Width="273px" />
                        <asp:RequiredFieldValidator ID="req_Name" runat="server" ControlToValidate="txt_Name" ErrorMessage="*" ForeColor="Red" Text="* Please enter!" SetFocusOnError="true" />
                        <ajax:TextBoxWatermarkExtender runat="server" ID="watermark_NameWater" TargetControlID="txt_Name" WatermarkText="Please enter your Full Name" WatermarkCssClass="Watermark" />
                    </li>
                    <!-- sender's email -->
                    <li class="FormLabel">
                        <asp:Label runat="server" ID="Label3" Text="Email:" />
                    </li>
                    <li class="FormValue">
                        <asp:TextBox runat="server" ID="txt_Email" Width="272px" />
                        <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender1" TargetControlID="txt_Email" WatermarkText="Enter your email address" WatermarkCssClass="Watermark" />
                    </li>
                    <!-- sender's subject -->
                    <li class="FormLabel">
                        <asp:Label runat="server" ID="Label2" Text="Subject:" />
                    </li>
                    <li class="FormValue">
                        <asp:TextBox runat="server" ID="txt_Subject" Width="368px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Subject" ErrorMessage="*" ForeColor="Red" Text="* Please enter!" SetFocusOnError="true" />
                        <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender2" TargetControlID="txt_Subject" WatermarkText="Subject matter of the email" WatermarkCssClass="Watermark" />

                    </li>
                    <li class="FormValue100pc">
                        <asp:Label runat="server" ID="Label1" Text="Mail Message:" />
                    </li>
                    <li class="FormValue100pc">
                        <asp:TextBox runat="server" ID="txt_SupportBody" TextMode="MultiLine" Rows="5" Width="99%" Height="62px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_SupportBody" ErrorMessage="*" ForeColor="Red" Text="* Please enter!" SetFocusOnError="true" />
                        <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender3" TargetControlID="txt_SupportBody" WatermarkText="Please type here the contents of the email message" WatermarkCssClass="Watermark" />
                    </li>
                    <li class="FormSpacer" />
                    <li class="FormButton_Top">
                        <asp:Label runat="server" ID="lit_Message" Text="" ForeColor="Red" Font-Size="16pt" />
                        <asp:Button runat="server" ID="btn_SendMail" Text="&nbsp;&nbsp;Submit&nbsp;&nbsp;|&nbsp;&nbsp;Send Email&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="btn_SendMail_Click" Height="31px" />
                    </li>
                </ul>
            </div>
            <div id="ColumnTwo">
                <ul class="Address">
                    <li class="PageSubTitle">
                        <b>Snail Mail Address:</b>
                    </li>
                    <li class="FormSpacer" />
                    <li class="FormValue">Tentulia Sasan Debastan College,</li>
                    <li class="FormValue">B.D.Pur Sasan (Ganjam)</li>
                    <li class="FormValue">Odisha, India - 761120</li>
                    <li class="FormValue">Phone: +91-06818-267959</li>
                    <li class="FormValue">Web: <a href='http://www.tsdcollege.in' target="_blank">http://www.tsdcollege.in</a></li>
                </ul>
            </div>




            <IAControl:DialogBox ID="dialog_Message" runat="server"
                Title="Message:-"
                BackgroundCssClass="modalBackground"
                Style="display: none;"
                CssClass="modalPopup"
                EnableViewState="true">
                <ItemTemplate>
                    <ul>
                        <li>
                            <asp:Label ID="lbl_TheMessage" runat="server" Text="'" Visible="false" />
                        </li>
                    </ul>
                </ItemTemplate>
            </IAControl:DialogBox>


            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                <ProgressTemplate>
                    <div id="UpdateProgress">
                        <div class="UpdateProgressArea">
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
