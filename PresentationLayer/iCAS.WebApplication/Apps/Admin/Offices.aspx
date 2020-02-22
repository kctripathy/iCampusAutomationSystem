<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Offices.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.Offices" %>

<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel_Offices">
        <ContentTemplate>
            <h1 class="PageTitle">Office Master File Maintenance:    </h1>
            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                <ProgressTemplate>
                    <div id="UpdateProgress">
                        <div class="UpdateProgressArea">
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <asp:MultiView runat="server" ID="multiView_Offices">
                    <asp:View ID="view_InputControls" runat="server">
                        <div id="Mode">
                            <asp:Label runat="server" ID="lbl_DataOperationMode" />
                        </div>
                        <ul id="Office">
                            <li class="FormButton_Top">
                                <div id="Top">
                                    <asp:Button runat="server" ID="btn_ViewOffice" CausesValidation="false" Text=" View " OnClick="btn_ViewOffice_Click" />
                                    <asp:Button runat="server" ID="btn_Save_Top" Text="Save" OnClick="btn_Save_Top_Click" />
                                    <asp:Button ID="btn_Reset_Top" runat="server" CausesValidation="false" Text="Reset" OnClick="btn_Reset_Top_Click" />
                                </div>
                            </li>
                            <ul id="Offices">
                                <li class="FullWidth">
                                    <ul>
                                        <li class="PageSubTitle">
                                            <asp:Label runat="server" ID="lbl_OfficeDetails" Text="Office Details:-" />
                                        </li>
                                        <!--OfficeName-->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_OfficeName" Text="Office Name" />
                                            <asp:Label runat="server" ID="lbl_OfficeNameValidation" Text="*" ForeColor="Red" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_OfficeName" />
                                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_OfficeName" ControlToValidate="txt_OfficeName" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <!-- OfficeType -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_OfficeType" Text="Office Type" />
                                            <asp:Label runat="server" ID="lbl_OfficeTypeValidator" Text="*" ForeColor="Red" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:DropDownList runat="server" ID="ddl_OfficeType" />
                                            <asp:RequiredFieldValidator ID="requiredFieldValidator_OfficeType" runat="server" ControlToValidate="ddl_OfficeType" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <!-- EstablishmentDate -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_EstablishmentDate" Text="Establishment Date" />
                                            <asp:Label runat="server" ID="lbl_EstablishmentDateValidator" Text="*" ForeColor="Red" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_EstablishmentDate" Width="195px" />
                                            <asp:ImageButton runat="server" ID="imgButton_EstablishmentDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
                                            <ajax:CalendarExtender ID="CalendarExtenderEstablishmentDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_EstablishmentDate" CssClass="MicroCalendar" TargetControlID="txt_EstablishmentDate" />
                                            <asp:RequiredFieldValidator ID="requiredFieldValidator_EstablishmentDate" runat="server" ControlToValidate="txt_EstablishmentDate" Display="Dynamic" SetFocusOnError="true" />
                                            <asp:RegularExpressionValidator ID="regularExpressionValidator_EstablishmentDate" runat="server" ControlToValidate="txt_EstablishmentDate" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <!-- Reporting Office -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_ReportingOffice" Text="Reporting Office" />
                                            <asp:Label runat="server" ID="lbl_ReportingOfficeValidator" Text="*" ForeColor="Red" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:DropDownList runat="server" ID="ddl_ReportingOffice" />
                                            <asp:RequiredFieldValidator ID="requiredFieldValidator_ReportingOffice" runat="server" ControlToValidate="ddl_ReportingOffice" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <%--<!-- Sub Heading -->
							<li class="PageSubTitle">
								<asp:Label runat="server" ID="lbl_OfficeCharge" Text="Office In Charge:-" />
							</li>--%>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_OfficeInCharge" Text="Office In Charge" />
                                            <asp:Label runat="server" ID="lbl_OfficeInChargeValidator" Text="*" ForeColor="Red" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:DropDownList runat="server" ID="ddl_OfficeInCharge" />
                                            <asp:RequiredFieldValidator ID="requiredFieldValidator_OfficeInCharge" runat="server" ControlToValidate="ddl_OfficeInCharge" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                    </ul>
                                    <ul>
                                        <!-- Office Address Sub Heading -->
                                        <li class="PageSubTitle">
                                            <asp:Label runat="server" ID="lbl_OfficeAddress" Text="Office Address:-" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_OfficeStreet" Text="Street/Town" />
                                            <asp:Label runat="server" ID="lbl_OfficeStreetValidator" Text="*" ForeColor="Red" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_OfficeStreet" TextMode="MultiLine" Rows="4" />
                                            <asp:RequiredFieldValidator ID="requiredFieldValidator_OfficeStreet" runat="server" ControlToValidate="txt_OfficeStreet" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <!-- OfficeLandMark -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_OfficeLandMark" Text="LandMark" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_OfficeLandMark" />
                                        </li>
                                        <!-- OfficeDistrict -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_OfficeDistrict" Text="District" />
                                            <asp:Label runat="server" ID="lbl_OfficeDistrictValidator" Text="*" ForeColor="Red" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:DropDownList runat="server" ID="ddl_OfficeDistrict" AutoPostBack="True" OnSelectedIndexChanged="ddl_OfficeDistrict_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_OfficeDistrict" ControlToValidate="ddl_OfficeDistrict" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <!-- OfficeState -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_OfficeState" Text="State" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_OfficeState" Enabled="false" />
                                        </li>
                                        <!-- OfficePincode -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_OfficePinCode" Text="Pincode" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_OfficePincode" />
                                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator_OfficePinCode" Display="Dynamic" ControlToValidate="txt_OfficePincode" SetFocusOnError="true" />
                                        </li>
                                    </ul>
                                </li>
                                <li class="FullWidth">
                                    <ul>
                                        <!-- Contact Number Sub Heading -->
                                        <li class="PageSubTitle">
                                            <asp:Label runat="server" ID="lbl_ContactPhoneNumber" Text="Office Contact:-" />
                                        </li>
                                        <!-- STDcode -->
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_StdCode" Text="STD Code(Phone)" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_StdCode" />
                                            <asp:RegularExpressionValidator ID="regularExpressionValidator_StdCode" runat="server" ControlToValidate="txt_StdCode" Display="Dynamic" SetFocusOnError="true" />
                                            <li class="FormLabel">
                                                <asp:Label runat="server" ID="lbl_Phone1" Text="Phone Number1" />
                                            </li>
                                            <li class="FormValue">
                                                <asp:TextBox runat="server" ID="txt_PhoneNumber1" />
                                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PhoneNo1" ControlToValidate="txt_PhoneNumber1" Display="Dynamic" SetFocusOnError="true" />
                                            </li>
                                            <li class="FormLabel">
                                                <asp:Label runat="server" ID="lbl_Phone2" Text="Phone Number2" />
                                            </li>
                                            <li class="FormValue">
                                                <asp:TextBox runat="server" ID="txt_PhoneNumber2" />
                                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PhoneNo2" ControlToValidate="txt_PhoneNumber2" Display="Dynamic" SetFocusOnError="true" />
                                            </li>
                                            <li class="FormLabel">
                                                <asp:Label runat="server" ID="lbl_Phone3" Text="Phone Number3" />
                                            </li>
                                            <li class="FormValue">
                                                <asp:TextBox runat="server" ID="txt_PhoneNumber3" />
                                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PhoneNo3" ControlToValidate="txt_PhoneNumber3" Display="Dynamic" SetFocusOnError="true" />
                                            </li>
                                            <%--<!-- Contact FAX Number Sub Heading -->
							<li class="PageSubTitle">
								<asp:Label runat="server" ID="lbl_FaxNumber" Text="Contact Fax:-" />
							</li>--%>
                                            <!-- STDcode -->
                                            <li class="FormLabel">
                                                <asp:Label runat="server" ID="lbl_StdCodeFax" Text="STD Code(Fax)" />
                                            </li>
                                            <li class="FormValue">
                                                <asp:TextBox runat="server" ID="txt_StdCodeFax" />
                                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_StdCodeFax" ControlToValidate="txt_StdCodeFax" Display="Dynamic" SetFocusOnError="true" />
                                            </li>
                                            <!-- Phone1 -->
                                            <li class="FormLabel">
                                                <asp:Label runat="server" ID="lbl_Fax1" Text="Fax Number1" />
                                            </li>
                                            <li class="FormValue">
                                                <asp:TextBox runat="server" ID="txt_FaxNumber1" />
                                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_FaxNo1" ControlToValidate="txt_FaxNumber1" Display="Dynamic" SetFocusOnError="true" />
                                            </li>
                                            <!-- Phone2 -->
                                            <li class="FormLabel">
                                                <asp:Label runat="server" ID="lbl_Fax2" Text="Fax Number2" />
                                            </li>
                                            <li class="FormValue">
                                                <asp:TextBox runat="server" ID="txt_FaxNumber2" />
                                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_FaxNo2" ControlToValidate="txt_FaxNumber2" Display="Dynamic" SetFocusOnError="true" />
                                            </li>
                                            <!-- Phone3 -->
                                            <li class="FormLabel">
                                                <asp:Label runat="server" ID="lbl_Fax3" Text="Fax Number3" />
                                            </li>
                                            <li class="FormValue">
                                                <asp:TextBox runat="server" ID="txt_FaxNumber3" />
                                                <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_FaxNo3" ControlToValidate="txt_FaxNumber3" Display="Dynamic" SetFocusOnError="true" />
                                            </li>
                                    </ul>
                                    <ul>
                                        <!-- Contact Persons Sub Heading -->
                                        <li class="PageSubTitle">
                                            <asp:Label runat="server" ID="lbl_ContactPerson" Text="Contact Persons:-" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_PersonName1" Text="Contact Person1:" Font-Bold="true" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonName1" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Person1" ControlToValidate="txt_PersonName1" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_Mobile1" Text="Mobile" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonMobile1" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonMobile1" ControlToValidate="txt_PersonMobile1" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_Email" Text="Email" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonEmail1" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonEmail1" ControlToValidate="txt_PersonEmail1" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_Extension" Text="Extension" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonExtension1" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonExtension1" ControlToValidate="txt_PersonExtension1" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_PersonName2" Text="Contact Person2" Font-Bold="true" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonName2" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonName2" ControlToValidate="txt_PersonName2" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_Mobile2" Text="Mobile" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonMobile2" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Personmobile2" ControlToValidate="txt_PersonMobile2" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="Label1" Text="Email" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonEmail2" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonEmail2" ControlToValidate="txt_PersonEmail2" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="Label2" Text="Extension" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonExtension2" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonExtension2" ControlToValidate="txt_PersonExtension2" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_PersonName3" Text="Contact Person3" Font-Bold="true" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonName3" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Person3" ControlToValidate="txt_PersonName3" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="lbl_Mobile3" Text="Mobile" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonMobile3" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonMobile3" ControlToValidate="txt_PersonMobile3" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="Label3" Text="Email" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonEmail3" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonEmail3" ControlToValidate="txt_PersonEmail3" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                        <li class="FormLabel">
                                            <asp:Label runat="server" ID="Label4" Text="Extension" />
                                        </li>
                                        <li class="FormValue">
                                            <asp:TextBox runat="server" ID="txt_PersonExtension3" />
                                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_PersonExtnsion3" ControlToValidate="txt_PersonExtension3" Display="Dynamic" SetFocusOnError="true" />
                                        </li>
                                    </ul>
                                </li>
                                <%--<li class="PageSubTitle">
									<asp:Label runat="server" ID="Label5" Text="" />
								</li>--%>
                                <%--<li class="FormLabel">
									<asp:Label ID="lbl_IsHavingShift" runat="server" Text="Is Having Shift" />
								</li>
								<li class="FormValue">
									<asp:CheckBox runat="server" ID="chk_IsHavingShift" />
								</li>--%>
                                <li class="FormSpacer" />
                                <li class="FormButton_Top">
                                    <div id="Buttom">
                                        <asp:Button runat="server" ID="btn_BottomViewOffice" CausesValidation="false" Text=" View " OnClick="btn_ViewOffice_Click" />
                                        <asp:Button runat="server" ID="btn_Save" Text="Save" OnClick="btn_Save_Top_Click" />
                                        <asp:Button ID="btn_Bottom_Reset" runat="server" CausesValidation="false" OnClick="btn_Reset_Top_Click" Text="Reset" />
                                    </div>
                                </li>
                                <li class="FormMessage">
                                    <asp:Literal runat="server" ID="lit_Message" Text="." />
                                </li>
                            </ul>
                    </asp:View>
                    <asp:View ID="view_GridView" runat="server">
                        <ul class="GridView">
                            <li class="FormButton_Top">
                                <asp:Button runat="server" ID="btn_Offices" Text="Add Offices" CausesValidation="false" OnClick="btn_Offices_Click" />
                            </li>
                            <li>
                                <micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search Office(s), where:" />
                            </li>
                            <li class="FormPageCounter">
                                <asp:Literal runat="server" ID="lit_PageCounter" />
                            </li>
                            <li>
                                <asp:GridView runat="server" ID="gview_Office" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20" Width="98%" CssClass="GridView" GridLines="Both" OnPageIndexChanging="gview_Office_PageIndexChanging" OnRowCommand="gview_Office_RowCommand" OnRowDeleting="gview_Office_RowDeleting" OnRowEditing="gview_Office_RowEditing" OnRowDataBound="gview_Office_RowDataBound">
                                    <PagerStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="CheckBox">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk_OfficeID" Visible="true" />
                                                <asp:Label runat="server" ID="lbl_OfficeID" Text='<%# Eval("OfficeID") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OfficeName" HeaderText="Name " ItemStyle-CssClass="OfficeName" />
                                        <asp:BoundField DataField="OfficeTypeDescription" HeaderText="Office Type " ItemStyle-CssClass="OfficeTypeDesc" />
                                        <asp:BoundField DataField="OfficeCode" HeaderText="Code " ItemStyle-CssClass="OfficeCode" />
                                        <asp:CommandField ShowEditButton="true" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
                                        <asp:CommandField ShowDeleteButton="true" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
                                        <asp:CommandField ShowSelectButton="true" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ItemStyle-CssClass="ViewLinkItem" ControlStyle-CssClass="ViewLink" />
                                    </Columns>
                                    <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="MicroPagerStyle" />
                                </asp:GridView>
                            </li>
                            <li class="FormSpacer" />
                        </ul>
                    </asp:View>
                </asp:MultiView>
                <IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
                    <ItemTemplate>
                        <ul>
                            <li>
                                <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
                            </li>
                        </ul>
                    </ItemTemplate>
                </IAControl:DialogBox>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
