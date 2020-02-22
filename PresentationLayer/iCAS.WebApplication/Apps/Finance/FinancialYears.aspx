<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="FinancialYears.aspx.cs" Inherits="Micro.WebApplication.MicroERP.FINANCE.FinancialYears" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
        <asp:Literal runat="server" ID="lit_PageTitle" Text="Financial Year"/>
    </h1>
    <asp:UpdatePanel runat="server" ID="updatePanel_FinancialYear">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="multiView_FinancialYear">
                <asp:View ID="view_InputControls" runat="server">
                <div id="Mode">
                 <asp:Label runat="server" ID="lbl_DataOperationMode" />
                </div>
                <ul id="FinancilaYear">
                    <li class="FormButton_Top">
                        <div id="Top">
                            <asp:Button runat="server" ID="btn_ViewFinancialYear" CausesValidation="false" Text=" View " />
						    <asp:Button runat="server" ID="btn_Save_Top" Text="Save" />
						    <asp:Button runat="server" ID="btn_Cancel_Top" CausesValidation="false" Text="Reset" />
                        </div>
                    </li>
                    <ul id="FinancialYears">
                         <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_Category" Text="Category" />
                            <asp:Label runat="server" ID="lbl_CategoryValidator" Text="*" CssClass="ValidationColor" />
                         </li>
                         <li class="FormValue">
                            <asp:DropDownList runat="server" ID="drpdwn_Category" AutoPostBack="True">
                                <asp:ListItem Text="Choose Category of Year"  Selected="True" />
                                <asp:ListItem Text="Financial Year" Value="F"/>
                                <asp:ListItem Text="Calendar Year" Value="C"/>
                                <asp:ListItem Text="Academic Year" Value="A"/>
                            </asp:DropDownList>
                         </li>
                         <li class="FormLabel">
                         <!-- Year Code -->
                            <asp:Label runat="server" ID="lbl_YearCode" Text="Year Code" />
                            <asp:Label runat="server" ID="lbl_YearCodeValidator" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                        <asp:TextBox runat="server" ID="txt_YearCode" />
                        <asp:RequiredFieldValidator runat="server" ID="requiredFieldvalidator_YearCode" ControlToValidate="txt_YearCode" Display="Dynamic" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_YearCode" ControlToValidate="txt_YearCode" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <li class="FormLabel">
                        <!--- Start Date --->
                            <asp:Label runat="server" ID="lbl_StartDate" Text="Start Date" />
                            <asp:Label runat="server" ID="lbl_StartDateValidator" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_StartDate" AutoPostBack="true" />
                            <asp:ImageButton runat="server" ID="imgButton_StartDate" CausesValidation="false" ToolTip="Show Calendar" ImageAlign="AbsMiddle"
                             ImageUrl="../../Themes/Default/Images/Calander%2001.gif"  Height="21" Width="21" />
                            <ajax:CalendarExtender runat="server" ID="ajaxCalendar_StartDate" Animated="true" Enabled="true" Format="dd-MMM-yyyy" PopupButtonID="imgButton_StartDate" TargetControlID="txt_StartDate" CssClass="MicroCalendar" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldvalidator_StartDate" ControlToValidate="txt_StartDate" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_StartDate" ControlToValidate="txt_StartDate" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <li class="FormLabel">
                        <!-- Close Date -->
                            <asp:Label runat="server" ID="lbl_CloseDate" Text="Close Date" />
                            <asp:Label runat="server" ID="lbl_CloseDateValidator" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:TextBox runat="server" ID="txt_CloseDate" AutoPostBack="true"/>
                            <asp:ImageButton runat="server" ID="imgButton_CloseDate" CausesValidation="false" ToolTip="Show Calendar" ImageAlign="AbsMiddle"
                             ImageUrl="../../Themes/Default/Images/Calander%2001.gif"  Height="21" Width="21" />
                            <ajax:CalendarExtender runat="server" ID="ajaxCalendar_CloseDate" Animated="true" Enabled="true" Format="dd-MMM-yyyy" PopupButtonID="imgButton_CloseDate" TargetControlID="txt_CloseDate" CssClass="MicroCalendar" />
                            <asp:RequiredFieldValidator runat="server" ID="requiredFieldvalidator_EndDate" ControlToValidate="txt_EndDate" Display="Dynamic" SetFocusOnError="true" />
                            <asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_EndDate" ControlToValidate="txt_EndDate" Display="Dynamic" SetFocusOnError="true" />
                        </li>
                        <li class="FormLabel">
                        <!--- Close Flag --->
                            <asp:Label runat="server" ID="lbl_CloseFlag" Text="Close Flag" />
                            <asp:Label runat="server" ID="lbl_CloseFlagValidator" Text="*" CssClass="ValidationColor" />
                        </li>
                        <li class="FormValue">
                            <asp:RadioButton runat="server" ID="radio_CloseFlagYes" GroupName="grp_CloseFlag" Text="Yes" />
                            <asp:RadioButton runat="server" ID="radioCloseFlagNo" GroupName="grp_CloseFlag" Text="No" />
                        </li>
                        <li class="FormButton_Top">
                            <div id="Bottom">
                                <asp:Button runat="server" ID="btn_View" Text="View" CausesValidation="false" 
                                    onclick="btn_View_Click" />
                                <asp:Button runat="server" ID="btn_Save" Text="Save" />
                                <asp:Button runat="server" ID="btn_Reset" Text="Reset" CausesValidation="false" />
                            </div>
                        </li>
                    </ul>
                </ul>

                </asp:View>
                <asp:View ID="view_GridView" runat="server">
                    <ul class="GridView">
                        <li class="FormButton_Top">
                            <asp:Button runat="server" ID="btn_FinancialYear" Text="Add Financial Years" CausesValidation="false" />
                        </li>
                        <li class="FormPageCounter">
                            <asp:Literal runat="server" ID="lit_PageCounter" />
                        </li> 
                        <li>
                            <asp:GridView runat="server" ID="gview_FinancialYear" 
                                AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" 
                                CssClass="GridView" GridLines="Both" PageSize="25" 
                                PagerSettings-Position="Bottom" Width="98%" 
                                onselectedindexchanged="gview_FinancialYear_SelectedIndexChanged">
                                <PagerStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>
                                    <asp:BoundField ShowHeader="false" DataField="AccountingYearId" Visible="false" />
                                    <asp:TemplateField ItemStyle-CssClass="CheckBox">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chk_AccountingYearId" Visible="true" />
                                            <asp:Label runat="server" ID="lbl_AccountingYearId" Text='<%# Eval("AccountingYearId") %>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AnalysisFlag" HeaderText="Year Category" ItemStyle-CssClass="Category" />
                                    <asp:BoundField DataField="AccountingYearCode" HeaderText="Year Code" ItemStyle-CssClass="YearCode" />
                                    <asp:BoundField DataField="StartYearDate" HeaderText="Start Date" ItemStyle-CssClass="StartDate" />
                                    <asp:BoundField DataField="EndYearDate" HeaderText="End Date" ItemStyle-CssClass="EndDate" />
                                    <asp:BoundField DataField="ClosingFlag" HeaderText="Close Flag" ItemStyle-CssClass="CloseFlag" />
                                    <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
									<asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ICO" ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem"/>
                                </Columns>
                                <PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
								<PagerStyle CssClass="MicroPagerStyle" />
                            </asp:GridView>
                        </li>
                    </ul>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
        


</asp:Content>
