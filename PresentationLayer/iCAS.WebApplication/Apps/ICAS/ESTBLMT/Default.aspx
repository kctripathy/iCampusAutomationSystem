<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Micro.WebApplication.APPS.ICAS.ESTBLMT.Default" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
        @import "~/Content/Calendar.css";
        .submitBtnClass
        {
            margin: 0px 10px;
        }
        .viewBtnClass
        {
            border: solid 1px red;
        }
        .WatermarkCssClass
        {
            color: darkgray;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel_Establishment" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1 class="PageTitle">
                <asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Establishments:-" />
            </h1>

            <asp:MultiView ID="Establishment_multi" runat="server">
                <asp:View ID="InputControls" runat="server">

                    <ul id="Establishments">
                        <li class="Formlabel">
                            <asp:Label ID="lbl_MessageType" runat="server" Text="Select Establishment Type:" />
                        </li>

                        <li class="Formvalue">
                            <asp:RadioButtonList ID="rbl_EstablishmentTypeCode" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbl_EstablishmentTypeCode_SelectedIndexChanged">
                                <asp:ListItem Value="R" Selected="True">Recent Activities</asp:ListItem>
                                <asp:ListItem Value="N">Notice</asp:ListItem>
                                <asp:ListItem Value="T">Tender</asp:ListItem>
                                <asp:ListItem Value="C">Circular</asp:ListItem>
                                <asp:ListItem Value="W">World Bank Project</asp:ListItem>
                                <asp:ListItem Value="M">Minutes of Meetings</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_EstablishmentTypeCode" runat="server" ControlToValidate="rbl_EstablishmentTypeCode" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <li class="Formlabel">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lbl_NoticeTitle" runat="server" Text="Please Enter the Title/Subject: " />
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_NoticeTitle" runat="server" Width="80%" />
                            <ajax:TextBoxWatermarkExtender runat="server" ID="watermarkTxt_NoticeTitle" TargetControlID="txt_NoticeTitle" WatermarkText="Example: World Bank Team visited our college" WatermarkCssClass="WatermarkCssClass" />
                            <asp:RequiredFieldValidator ID="req_NoticeTitle" runat="server" ControlToValidate="txt_NoticeTitle" ErrorMessage="*" ForeColor="Red" Text="* Please enter!" SetFocusOnError="true" />
                        </li>
                        <li class="Formlabel">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lbl_Startdate" runat="server" Text="Display This From Date:" />
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_Startdate" runat="server" AutoPostBack="false" />
                            <asp:ImageButton runat="server" ID="imgbtn_Startdate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_Startdate" PopupButtonID="imgbtn_Startdate" CssClass="MicroCalendar" TargetControlID="txt_Startdate">
                            </ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_Startdate" runat="server" ControlToValidate="txt_Startdate" SetFocusOnError="true" ErrorMessage="*" ForeColor="Red" Text="It can't be left empty!" />
                        </li>
                        <li class="Formlabel">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lbl_Enddate" runat="server" Text="Display This Till Date:" />
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_Enddate" runat="server" AutoPostBack="false" />
                            <asp:ImageButton runat="server" ID="imgbtn_Enddate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_Enddate" PopupButtonID="imgbtn_Enddate" CssClass="MicroCalendar" TargetControlID="txt_Enddate" />

                            <asp:RequiredFieldValidator ID="requiredFieldValidator_Enddate" runat="server" ControlToValidate="txt_Enddate" SetFocusOnError="true" ErrorMessage="*" ForeColor="Red" Text="It can't be left empty!" />

                        </li>
                        <li class="Formlabel">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lbl_Description" runat="server" Text="Description:" />
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_Description" runat="server" Height="81px" Width="400px" TextMode="MultiLine" /><br />
                            <ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender_txt_Description" TargetControlID="txt_Description" WatermarkText="Enter Detail Description of the Notice/ Tender/ Circular/ Recent Activities Here" WatermarkCssClass="" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Description" runat="server" ControlToValidate="txt_Description" ErrorMessage="*" ForeColor="Red" Text="Please enter the establishment description! it can't left blank." />
                        </li>
                        <li class="Formlabel">
                            <asp:Label ID="Label1" runat="server" Text="File to Upload:" />
                        </li>
                        <li class="Formvalue">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:FileUpload runat="server" ID="fileUploadEstb" Width="63%" BorderStyle="Solid" BorderWidth="1" BorderColor="DarkGray" />

                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload_File" CausesValidation="true" />
                                    <br />
                                    <asp:Label runat="server" ID="lbl_FileUploadStatus" ForeColor="Red" Text="File uploaded successfully. please save/update the record now" Visible="false" />

                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </li>
                        <li class="Formlabel">&nbsp;</li>
                        <li class="Formvalue">&nbsp;<asp:Label runat="server" ID="lblMessage" Text="" /></li>
                        <li class="FormButton_Top">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save" CssClass="submitBtnClass" />
                            <asp:Button ID="btn_view" runat="server" Text="View" OnClick="btn_view_Click" CausesValidation="false" CssClass="viewBtnClass" />
                        </li>
                        
                    </ul>
                </asp:View>
                <asp:View ID="view_gridView" runat="server">
                    <ul>
                        <li class="FormButton_Top">
                            <asp:Literal runat="server" ID="lit_CurrentPage" Text="Current Page: 0/" />                           
                            <asp:Button ID="btn_AddNew" runat="server" Text="Add New" OnClick="btn_AddNew_Click" />
                        </li>
                        <li class="GridView">
                            <asp:GridView ID="gridview_Establishment" runat="server" 
                                AllowPaging="True" 
                                AllowSorting="True"
                                 PageSize="30" 
                                AutoGenerateColumns="False" 
                                OnPageIndexChanging="gridview_Establishment_PageIndexChanging"
                                OnRowCommand="gridview_Establishment_RowCommand" 
                                OnRowDeleting="gridview_Establishment_RowDeleting" 
                                OnRowEditing="gridview_Establishment_RowEditing">
                                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="StudentId">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_EstbID" Text='<%# Eval("EstbID") %>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EstbID" HeaderText="EstablishmentId" Visible="false" />
                                    <asp:BoundField DataField="EstbTypeCodeDesc" HeaderText="Type" />
                                    <asp:BoundField DataField="EstbTitle" HeaderText="Tittle" />
                                    <asp:BoundField DataField="EstbViewStartDate" HeaderText="Start Date" DataFormatString="{0:dd/MMM/yyyy}" />
                                    <asp:BoundField DataField="EstbViewEndDate" HeaderText="End Date" DataFormatString="{0:dd/MMM/yyyy}" />
                                    <%--<asp:BoundField DataField="EstbDescription" HeaderText="Description" />--%>
                                    <asp:CommandField ShowEditButton="true" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
                                        <ControlStyle CssClass="EditLink" />
                                        <ItemStyle CssClass="EditLinkItem" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
                                        <ControlStyle CssClass="DeleteLink" />
                                        <ItemStyle CssClass="DeleteLinkItem" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="EstbStatusFlagDesc" HeaderText="Status" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
                                        <ControlStyle CssClass="ViewLink" />
                                        <ItemStyle CssClass="ViewLinkItem" />
                                    </asp:CommandField>
                                </Columns>
                                <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <PagerStyle CssClass="MicroPagerStyle" />
                            </asp:GridView>
                        </li>
                    </ul>
                </asp:View>
            </asp:MultiView>



            <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
                <ItemTemplate>
                    <ul id="DialogBoxUL">
                        <li>
                            <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
                            <asp:HyperLink runat="server" ID="lnkPage" NavigateUrl="#" />
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

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    Please wait image is getting uploaded....
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
