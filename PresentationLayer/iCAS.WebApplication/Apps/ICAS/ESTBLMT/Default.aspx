<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Micro.WebApplication.APPS.ICAS.ESTBLMT.Default" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
        
        .submitBtnClass
        {
            margin: 0px 10px;
        }
         
        .title-text-box {
            padding: 5px;
            
        }
         
        .estb-desc {
             width: 90%;
             height: 80px;
             padding: 5px;
        }
        .estb-dropdown {
            height: 30px;
            width: 87%;
            padding: 5px;
            font-size: inherit;
            font-weight: bold;
        }
         .estb-dropdown-view {
            height: 30px;
            width: 100%;
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
          .estb-btn {
              padding: 5px 40px !important;
          }
          .estb-btn:hover {
              color: darkred;
          }
          
          .ajax__calendar_today {
              font-weight: bold;
              border: solid 1px #ccc;
          }
          .page-title-estb-type {
              color: #04164d;
                font-weight: 800;
                font-size: 17px;
                padding-left: 5px;
          }
    </style>
    <script type="text/javascript">
         
        function onEstbTypeChage(e) {
            var selectedText = e.options[e.selectedIndex].innerHTML;
            var selectedValue = e.value;

            if (selectedValue == '') selectedText = '';
            
            setEstbTypeLabels(selectedText, selectedValue);

        }
        function setEstbTypeLabels(estbText, estbValue) {
            var lblTitle = document.getElementById('<%= lbl_NoticeTitle.ClientID %>');
            var lblPageTitle = document.getElementById('<%= lbl_PageTitle.ClientID %>');
            var lblDescription = document.getElementById('<%= lbl_Description.ClientID %>');
            var lblDescription1 = document.getElementById('<%= lbl_Description1.ClientID %>');
            var lblDescription2 = document.getElementById('<%= lbl_Description2.ClientID %>');

            lblPageTitle.innerHTML = estbText;
            debugger;

            if (estbValue == 'Y') {
                lblTitle.innerHTML = "Please enter the name of the student to be displyed in the " + titleCase(estbText) + " section of the website:";
                lblDescription.innerHTML = "Class of the student:"
                lblDescription1.innerHTML = "Description about " + titleCase(estbText) + ":";
                lblDescription2.innerHTML = "Description (paragraph 1) about " + titleCase(estbText) + ":";
                textAreaAdjust('25px');
            }
            if (estbValue == 'Q') {
                lblTitle.innerHTML = "Please enter the subject of the " + titleCase(estbText);
                lblDescription.innerHTML = "Class:"

                var txtDesc = document.getElementById('<%= txt_Description.ClientID %>');
                txtDesc.value = "+3 SCIENCE | ARTS";
                txtDesc.style.height = "25px";

                lblDescription1.innerHTML = "Semester:";
                var txtAreaDesc1 = document.getElementById('<%= txt_Description1.ClientID %>');
                txtAreaDesc1.value = "? SEMESTER EXAM";
                txtAreaDesc1.style.height = "25px";

                lblDescription2.innerHTML = "Year:";
                var txtAreaDesc2 = document.getElementById('<%= txt_Description2.ClientID %>');
                txtAreaDesc2.value = "";
                txtAreaDesc2.style.height = "25px";

                lblDescription2.innerHTML = "Additional info (if any) " + titleCase(estbText) + ":";
            }else {
                lblTitle.innerHTML = "Title for the " + titleCase(estbText) + ":";
                lblDescription.innerHTML = "Description for " + titleCase(estbText) + ":";
                lblDescription1.innerHTML = "Description (paragraph 1) for " + titleCase(estbText) + ":";
                lblDescription2.innerHTML = "Description (paragraph 2) for " + titleCase(estbText) + ":";
                textAreaAdjust('80px');
            }

            if (estbValue == 'P' || estbValue == 'S' || estbValue == 'D') {
                showHideTextArea('none');
            }
            else {
                showHideTextArea('block');
            }

            //upload section label
            var lblUploadLabel = document.getElementById('<%= Label1.ClientID %>');
            if (estbValue == 'P' || estbValue == 'Y') {
                lblUploadLabel.innerHTML = "Please choose a photo to upload (jpg / jpeg / png / gif) Max.(4MB):";
            }
            else if (estbValue == 'G') {
                lblUploadLabel.innerHTML = "Please choose a file/photo to upload (pdf / doc / docx / jpg / jpeg / png / gif) Max.(4MB):";
            }
            else {
                lblUploadLabel.innerHTML = "Please choose a PDF file to upload (Max. 4MB):";
            }
        }

        function textAreaAdjust(size) {
            var txtAreaDesc = document.getElementById('<%= txt_Description.ClientID %>');
            txtAreaDesc.style.height = size;
        }

        function showHideTextArea(willShow) {
            var lblDescription1 = document.getElementById('<%= lbl_Description1.ClientID %>');
            var lblDescription2 = document.getElementById('<%= lbl_Description2.ClientID %>');

            var txtAreaDesc1 = document.getElementById('<%= txt_Description1.ClientID %>');
            var txtAreaDesc2 = document.getElementById('<%= txt_Description2.ClientID %>');

            lblDescription1.style.display = willShow;
            lblDescription2.style.display = willShow;

            txtAreaDesc1.style.display = willShow;
            txtAreaDesc2.style.display = willShow;
        }


        function titleCase(str) {
            str = str.toLowerCase().split(' ');
            for (var i = 0; i < str.length; i++) {
                str[i] = str[i].charAt(0).toUpperCase() + str[i].slice(1);
            }
            return str.join(' ');
        }

        function validate() {
            var ddlType = document.getElementById('<%= ddlEstbType.ClientID %>');
            var txtNoticeTitle = document.getElementById('<%= txt_NoticeTitle.ClientID %>');
            var txtDescription = document.getElementById('<%= txt_Description.ClientID %>');

            var selectedValue = ddlType.value;
            

            if (selectedValue == '') {
                alert('Please choose a establishment type');
                return false;
            }
            else if (txtNoticeTitle.value == '') {
                if (selectedValue == 'Y')
                    alert('Please enter name of the student');
                else
                    alert('Please enter some text for title');

                return false;
            }
            else if (txtDescription.value == '') {
                if (selectedValue == 'Y')
                    alert('Please enter class and achievement of the student');
                else
                    alert('Please enter some text for description');
                return false;
            }
            return true;
            <%--else {

                var array = ['pdf', 'doc', 'docx'];
                if (selectedValue == 'P' || selectedValue == 'Y') {
                    array = ['jpg', 'jpeg', 'png', 'gif'];
                }

                var fileUploadEstb = document.getElementById('<%= fileUploadEstb.ClientID %>');
                if (fileUploadEstb.value == '') {
                    alert('please choose a file to upload');
                    return false;
                }

                var Extension = fileUploadEstb.value.substring(fileUploadEstb.value.lastIndexOf('.') + 1).toLowerCase();
                if (array.indexOf(Extension) <= -1) {
                    alert("Please Upload flle with extension " + array.toString());
                    return false;
                }

                return true;
            }--%>
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel_Establishment" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1 class="PageTitle">
                <asp:Literal runat="server" ID="lit_PageTitle" Text="Manage Establishments:-" />
                <asp:Label runat="server" ID="lbl_PageTitle" CssClass="page-title-estb-type"></asp:Label>
            </h1>

            <asp:MultiView ID="Establishment_multi" runat="server">
                <asp:View ID="InputControls" runat="server">

                    <ul id="Establishments">
                        <li class="Formlabel" style="text-align: right;">
                            <asp:Label ID="lbl_Startdate" runat="server" Text="Date:" />
                            <span class="RequiredField">*</span>
                        </li>
                        <li class="Formvalue">
                            <asp:TextBox ID="txt_Startdate" runat="server" AutoPostBack="false" Width="26%" CssClass="disable_future_dates" />
                            <asp:ImageButton runat="server" ID="imgbtn_Startdate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                            <ajax:CalendarExtender runat="server" 
                                Format="dd-MMM-yyyy" 
                                ID="clndrextender_Startdate" 
                                PopupButtonID="imgbtn_Startdate" 
                                OnClientDateSelectionChanged="CheckLeaveDateRange"
                                CssClass="MicroCalendar" 
                                TargetControlID="txt_Startdate">
                            </ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="requiredFieldValidator_Startdate" runat="server" ControlToValidate="txt_Startdate" SetFocusOnError="true" ErrorMessage="*" ForeColor="Red" Text="required" />
                        </li>

                        <li class="Formlabel" style="text-align: right;">
                            <asp:Label ID="lbl_MessageType" runat="server" Text="Establishment Type:" />
                            <span class="RequiredField">*</span>
                        </li>
                        <li class="Formvalue">
                            <asp:DropDownList 
                                runat="server" 
                                ID="ddlEstbType" 
                                onchange="javascript: onEstbTypeChage(this);"
                                CssClass="estb-dropdown">
					        </asp:DropDownList>
                           
                            <asp:RequiredFieldValidator 
                                ID="requiredFieldValidator_EstablishmentTypeCode" 
                                runat="server" ControlToValidate="ddlEstbType" 
                                Display="Dynamic" 
                                ForeColor="Red"
                                ErrorMessage="required"
                                SetFocusOnError="true" />
                        </li>

                        
<%--                        <asp:Panel runat="server" ID="pnlQuestionPaper" Visible="true">
                             <li class="FormLabelFullWidth" style="margin-top:10px;">
                                 <b>Class:</b>
                                 <asp:RadioButtonList runat="server" ID="rblClass" onchange="javascript: onEstbClassChange(this);">
                                     <asp:ListItem Text="+3 ARTS" Value="+3 ARTS"></asp:ListItem>
                                     <asp:ListItem Text="+3 SCIENCE" Value="+3 SCIENCE"></asp:ListItem>
                                 </asp:RadioButtonList>

                                 <b>Semester:</b>
                                 <asp:DropDownList runat="server" ID="ddlSemester" onchange="javascript: onEstbSemesterChange(this);">
                                     <asp:ListItem Text="SEMESTER - 1" Value="SEMESTER - 1"></asp:ListItem>
                                     <asp:ListItem Text="SEMESTER - 2" Value="SEMESTER - 2"></asp:ListItem>
                                     <asp:ListItem Text="SEMESTER - 3" Value="SEMESTER - 3"></asp:ListItem>
                                     <asp:ListItem Text="SEMESTER - 4" Value="SEMESTER - 4"></asp:ListItem>
                                     <asp:ListItem Text="SEMESTER - 5" Value="SEMESTER - 5"></asp:ListItem>
                                     <asp:ListItem Text="SEMESTER - 6" Value="SEMESTER - 6"></asp:ListItem>
                                 </asp:DropDownList>
                            </li>
                        </asp:Panel>--%>


                        <li class="FormLabelFullWidth">
                            <asp:Label ID="lbl_NoticeTitle" runat="server" Text="Title: " />
                            <span class="RequiredField">*</span>
                        </li>
                        <li class="FormvalueFullWidth">
                            <asp:TextBox ID="txt_NoticeTitle" runat="server" Width="90%" MaxLength="100" CssClass="title-text-box" />
                            <%--<ajax:TextBoxWatermarkExtender runat="server" 
                                ID="watermarkTxt_NoticeTitle" 
                                TargetControlID="txt_NoticeTitle" 
                                WatermarkText="Please enter here the title or subject (Max 100 alphabets)" 
                                WatermarkCssClass="WatermarkCssClass" />--%>
                            <asp:RequiredFieldValidator ID="req_NoticeTitle" runat="server" ControlToValidate="txt_NoticeTitle" ErrorMessage="*" ForeColor="Red" Text="required" SetFocusOnError="true" />
                        </li>
                        

                        <%--<asp:Panel runat="server" ID="allOthers" Visible="true">--%>
                             <li class="FormLabelFullWidth" style="margin-top:5px;">
                                <asp:Label ID="lbl_Description" runat="server" Text="Description:" />
                                <span class="RequiredField">*</span>
                            </li>
                            <li class="FormvalueFullWidth">
                                <asp:TextBox ID="txt_Description" runat="server" CssClass="estb-desc" TextMode="MultiLine" Rows="1" Height="25"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Description" runat="server" ControlToValidate="txt_Description" ErrorMessage="*" ForeColor="Red" Text="required" />
                            </li>

                            <li class="FormLabelFullWidth" style="margin-top:5px;">
                                <asp:Label ID="lbl_Description1" runat="server" Text="Description (Paragraph 1):" />
                            </li>
                            <li class="FormvalueFullWidth">
                                <asp:TextBox ID="txt_Description1" runat="server" CssClass="estb-desc" TextMode="MultiLine" Rows="1" Height="25"/>
                            </li>

                        
                            <li class="FormLabelFullWidth" style="margin-top:5px;">
                                <asp:Label ID="lbl_Description2" runat="server" Text="Description (Paragraph 2):" />
                            </li>
                            <li class="FormvalueFullWidth">
                                <asp:TextBox ID="txt_Description2" runat="server" CssClass="estb-desc" TextMode="MultiLine" Rows="1" Height="25" />
                            </li>
                        <%--</asp:Panel>--%>
                        <li class="FormLabelFullWidth" style="margin-top:5px;">
                            <asp:Label ID="Label1" runat="server" Text="Choose a file to Upload:" />
                        </li>
                        
                        <li class="FormvalueFullWidth">
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
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save" CssClass="btn btn-primary p-2 m-1 estb-btn" CausesValidation="true"/>
                            <asp:Button ID="btn_view" runat="server" Text="View" OnClick="btn_view_Click" CausesValidation="false" CssClass="btn btn-primary p-Align2Center m-1 estb-btn" />
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
