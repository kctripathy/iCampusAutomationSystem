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
          
        }
        .WatermarkCssClass
        {
            color: #ccc;
        }
         
        .estb-desc {
             width: 80%;
             height: 80px;
        }
        .estb-dropdown {
            height: 30px;
            width: 80%;
            padding: 5px;
            font-size: inherit;
            font-weight: bold;
        }
         .estb-dropdown-view {
            height: 30px;
            width: 94%;
            padding: 5px;
            font-size: inherit;
            font-weight: bold;
        }

         .estb-form-button {
             display: block;
            float: left;
            width: 100%;
            text-align: center;
         }
        
         .gv-td-date {
             width: 66px;
         }
          .GridView table.gv-inner-table,
          .GridView table.gv-inner-table > tbody > tr, 
          .GridView table.gv-inner-table > tbody >  tr > td{
              border: none;
              width: 100%;
              margin: 0px;
              padding: 0px;
          }

          .GridView table.gv-inner-table > tbody > tr {
              padding: 4px 0px !important;
              border-bottom: solid 1px #ccc;

          }
          .GridView table.gv-inner-table > tbody > tr:last-child {
              border-bottom: none;
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
                            <asp:Label ID="lbl_MessageType" runat="server" Text="Establishment Type:" />
                            <span class="RequiredField">*</span>
                        </li>

                        <li class="Formvalue">
                            <asp:DropDownList runat="server" ID="ddlEstbType" CssClass="estb-dropdown">
					        </asp:DropDownList>
                           
                            <asp:RequiredFieldValidator 
                                ID="requiredFieldValidator_EstablishmentTypeCode" 
                                runat="server" ControlToValidate="ddlEstbType" 
                                Display="Dynamic" 
                                ForeColor="Red"
                                ErrorMessage="required"
                                SetFocusOnError="true" />
                        </li>

                        <li class="Formlabel">
                            <asp:Label ID="lbl_Startdate" runat="server" Text="Date:" />
                            <span class="RequiredField">*</span>
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_Startdate" runat="server" AutoPostBack="false" />
                            <asp:ImageButton runat="server" ID="imgbtn_Startdate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_Startdate" PopupButtonID="imgbtn_Startdate" CssClass="MicroCalendar" TargetControlID="txt_Startdate">
                            </ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_Startdate" runat="server" ControlToValidate="txt_Startdate" SetFocusOnError="true" ErrorMessage="*" ForeColor="Red" Text="required" />
                        </li>



                        <li class="Formlabel">
                            <asp:Label ID="lbl_NoticeTitle" runat="server" Text="Title: " />
                            <span class="RequiredField">*</span>
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_NoticeTitle" runat="server" Width="80%" MaxLength="100" />
                            <ajax:TextBoxWatermarkExtender runat="server" 
                                ID="watermarkTxt_NoticeTitle" 
                                TargetControlID="txt_NoticeTitle" 
                                WatermarkText="Please enter here the title or subject (Max 100 alphabets)" 
                                WatermarkCssClass="WatermarkCssClass" />
                            <asp:RequiredFieldValidator ID="req_NoticeTitle" runat="server" ControlToValidate="txt_NoticeTitle" ErrorMessage="*" ForeColor="Red" Text="required" SetFocusOnError="true" />
                        </li>
                        

                         <li class="Formlabel">
                            <asp:Label ID="lbl_Description" runat="server" Text="Description:" />
                            <span class="RequiredField">*</span>
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_Description" runat="server" CssClass="estb-desc" TextMode="MultiLine" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Description" runat="server" ControlToValidate="txt_Description" ErrorMessage="*" ForeColor="Red" Text="required" />
                        </li>

                        <li class="Formlabel">
                            <asp:Label ID="lbl_Description1" runat="server" Text="Description (Paragraph 1):" />
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_Description1" runat="server" CssClass="estb-desc" TextMode="MultiLine" />
                        </li>

                        
                        <li class="Formlabel">
                            <asp:Label ID="lbl_Description2" runat="server" Text="Description (Paragraph 2):" />
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_Description2" runat="server" CssClass="estb-desc" TextMode="MultiLine" />
                        </li>

                        <li class="Formlabel" style="text-align:right">
                            <asp:Label ID="Label1" runat="server" Text="Choose a file to Upload:" />
                        </li>
                        
                        <li class="Formvalue">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:FileUpload runat="server" ID="fileUploadEstb" Width="63%" BorderStyle="Solid" BorderWidth="1" BorderColor="DarkGray" class="btn btn-outline-primary btn-xs" />
                                    <asp:Button ID="btnUpload" runat="server" Text="UPLOAD FILE" OnClick="Upload_File" CssClass="btn btn-primary m-2 p-2" CausesValidation="false" />
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


                        
                        <li class="FormButton_Top" style="text-align: center !important;">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save" CssClass="btn btn-primary p-2 m-1" />
                            <asp:Button ID="btn_view" runat="server" Text="View" OnClick="btn_view_Click" CausesValidation="false" CssClass="btn btn-primary p-Align2Center m-1" />
                        </li>
                        
                    </ul>
                </asp:View>
                <asp:View ID="view_gridView" runat="server">
                    <ul>
                        <li class="FormButton_Top">
                            <asp:Literal runat="server" ID="lit_CurrentPage" Text="Current Page: 1/" />                           
                            <asp:Button ID="btn_AddNew" runat="server" Text="Add New" OnClick="btn_AddNew_Click" />
                        </li>
                        <li class="FormButton_Top">
                            <asp:DropDownList runat="server" ID="ddlEstbTypeView" CssClass="estb-dropdown-view">
					        </asp:DropDownList>                         
                            <asp:Button ID="btnViewEstbType" runat="server" Text="View" OnClick="btnViewEstbType_Click" />
                        </li>
                        <li class="GridView">
                            <asp:GridView ID="gridview_Establishment" runat="server" 
                                AllowPaging="True" 
                                AllowSorting="True"
                                 PageSize="30" 
                                AutoGenerateColumns="False" 
                                OnPageIndexChanging="gridview_Establishment_PageIndexChanging"
                                OnRowDataBound="gridview_Establishment_RowDataBound"
                                OnRowCommand="gridview_Establishment_RowCommand" 
                                OnRowDeleting="gridview_Establishment_RowDeleting" 
                                OnRowEditing="gridview_Establishment_RowEditing">
                                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_EstbID" Text='<%# Eval("EstbID") %>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EstbID" HeaderText="EstablishmentId" Visible="false" />
                                    <asp:BoundField DataField="EstbViewStartDate" HeaderText="Date" DataFormatString="{0:dd/MM/yy}" ItemStyle-CssClass="gv-td-date" />
                                    <asp:BoundField DataField="EstbTypeCodeDesc" HeaderText="Estb. Type" />
                                    <asp:TemplateField HeaderText="Title and Description">
                                        <ItemTemplate>
                                            <table class="gv-inner-table">
                                                <tr><td><asp:Label runat="server" ID="Label2" Text='<%# Eval("EstbTitle") %>'  Font-Bold="true" /></td></tr>
                                                <tr><td><asp:Label runat="server" ID="Label5" Text='<%# Eval("EstbDescription") %>' /></td></tr>
                                                <tr><td><asp:Label runat="server" ID="Label3" Text='<%# Eval("EstbDescription1") %>' /></td></tr>
                                                <tr><td><asp:Label runat="server" ID="Label4" Text='<%# Eval("EstbDescription2") %>' /></td></tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="EstbStatusFlagDesc" HeaderText="Status" />
                                    
                                    <asp:CommandField 
                                                ShowSelectButton="True" 
                                                HeaderText="View" 
                                                ButtonType="Image" 
                                                SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" 
                                                ControlStyle-CssClass="ViewLink" 
                                                ItemStyle-CssClass="ViewLinkItem">
                                                <ControlStyle CssClass="ViewLink" />
                                                <ItemStyle CssClass="ViewLinkItem" />
                                    </asp:CommandField>

                                    <asp:CommandField 
                                        ShowEditButton="true" 
                                        HeaderText="Edit" 
                                        ButtonType="Image" 
                                        EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" 
                                        ControlStyle-CssClass="EditLink" 
                                        ItemStyle-CssClass="EditLinkItem">
                                        <ControlStyle CssClass="EditLink" />
                                        <ItemStyle CssClass="EditLinkItem" />
                                    </asp:CommandField>


                                     <asp:CommandField 
                                        ShowDeleteButton="True" 
                                        ButtonType="Button" 
                                        ItemStyle-CssClass="DeleteLink btn btn-danger btn-xs" 
                                        HeaderText="Delete" />
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
