<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="AcademicYears.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.FINANCE.AcademicYears" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <h1 class="PageTitle">
<asp:Literal runat="server" ID="lit_PageTitle" Text="AcademicYear" />
</h1>
<asp:UpdatePanel runat="server" ID="UpdatePanel1_AcademicYear" ClientIDMode="Inherit" EnableViewState="True" RenderMode="Block" UpdateMode="Always">
<ContentTemplate>
<asp:MultiView runat="server" ID="multiView_AcademicYear">
<asp:View ID="view_InputControls" runat="server">
<div id="Mode">
<asp:Label runat="server" ID="lbl_DataOperationMode" />
</div>
<ul id="AcademicYear">
<li class="FormButton_Top">
<div id="Top">
   <asp:Button runat="server" ID="btn_ViewAcademicYear" CausesValidation="false" Text="View" />
   <asp:Button runat="server" ID="btn_Save_Top" Text="Save" />
   <asp:Button runat="server" ID="btn_Cancel_Top" CausesValidation="false" Text="Reset" />

</div>
</li>
<ul id="DCAccounts">
							<%--<li class="PageSubTitle">
								<asp:Label runat="server" ID="lbl_Head_PersonalDetails" Text="Personal Details :-" />
							</li>--%>
                          
                          <li class="FormLabel">
								<asp:Label runat="server" ID="lbl_Catagory" Text="Catagory " />
								<asp:Label runat="server" ID="lbl_CatagoryValidator" Text="*" CssClass="ValidationColor" />
							</li>
							<li class="FormValue">
								<asp:DropDownList runat="server" ID="ddl_Catagory" AutoPostBack="True"  />
								<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Catagory" ControlToValidate="ddl_Catagory" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
							</li>
							<li class="FormLabel">
								<asp:Label runat="server" ID="lbl_YearCode" Text="Year Code " />
								<asp:Label runat="server" ID="lbl_YearCode_Validator" Text="*" CssClass="ValidationColor" />
                                 
							</li>
							<li class="FormValue">
								<asp:TextBox runat="server" ID="txt_YearCode" />
								 
							</li>
                            <li class="FormLabel">
								<asp:Label runat="server" ID="lbl_StartDate" Text="Start Date " />
								<asp:Label runat="server" ID="lbl_StartDate_Validator" Text="*" CssClass="ValidationColor" />
                                 
							</li>
							<li class="FormValue">

                            
								    <asp:TextBox runat="server" ID="txt_StartDate"   AutoPostBack="true"  />
									<asp:ImageButton runat="server" ID="imgButton_StartDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
									<ajax:CalendarExtender runat="server" ID="ajaxCalender_StartDate" Enabled="true" Format="dd-MMM-yyyy" PopupButtonID="imgButton_StartDate" CssClass="MicroCalendar" TargetControlId="txt_StartDate" />
									<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_StartDate" ControlToValidate="txt_StartDate" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Start Date must be given" SetFocusOnError="true" />
									<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_StartDate" ControlToValidate="txt_StartDate" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Date" />
								 
							</li>
                            
                             <li class="FormLabel">
								<asp:Label runat="server" ID="lbl_CloseDate" Text="Close Date " />
								<asp:Label runat="server" ID="lbl_CloseDateValidator" Text="*" CssClass="ValidationColor" />
                                 
							</li>
							<li class="FormValue">
                                    <asp:TextBox runat="server" ID="txt_CloseDate"   AutoPostBack="true"  />
									<asp:ImageButton runat="server" ID="ImageButton_CloseDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
									<ajax:CalendarExtender runat="server" ID="ajaxCalender_CloseDate" Enabled="true" Format="dd-MMM-yyyy"  PopupButtonID="ImageButton_CloseDate" CssClass="MicroCalendar" TargetControlID="txt_CloseDate" />
									<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_CloseDate" ControlToValidate="txt_CloseDate" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage=" Close Date must be given" SetFocusOnError="true" />
									<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_CloseDate" ControlToValidate="txt_CloseDate" CssClass="ValidateMessage" Display="Dynamic" ErrorMessage="Invalid Date" />
								 
							</li>
                            <li class="FormLabel">
                            <asp:Label runat="server" ID="lbl_CloseFlag" Text="Close Flag" />
                            <asp:Label runat="server" ID="lbl_CloseFlagValidator" Text="*" CssClass="ValidationColor" />
                       
                           <li class="FormValue">
                                <asp:RadioButton runat="server" ID="radio_CloseFlagYes" GroupName="grp_CloseFlag" Text="Yes" /> 
                                <asp:RadioButton runat="server" ID="radio_CloseFlagNo" GroupName="grp_CloseFlag" Text="No" />
                             </li>
                             
                             <li class="FormButton_Top">
								<div id="Buttom">
									<asp:Button runat="server" ID="btn_View" CausesValidation="false" Text=" View "   />
									<asp:Button runat="server" ID="btn_Save" Text="Save"   />
									<asp:Button ID="btn_Cancel" runat="server" CausesValidation="false"   Text="Reset" />
								</div>
							</li>


</ul>

</ul>
             </asp:View>
             <asp:View ID="view_GridView" runat="server">
                <ul class="GridView">
                <li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_AcademicYears" Text="Add AcademicYears" CausesValidation="false"  OnClick="btn_AcademicYears_Click"  />
				</li>
                <li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
				</li>
                <li>
                  <asp:GridView runat="server" ID="gview_AcademicYear" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" CssClass="GridView" GridLines="Both" OnPageIndexChanging="gview_AcademicYear_PageIndexChanging" OnRowCommand="gview_AcademicYear_RowCommand" OnRowDataBound="gview_AcademicYear_RowDataBound" OnRowDeleting="gview_AcademicYear_RowDeleting" OnRowEditing="gview_AcademicYear_RowEditing" PageSize="25" PagerSettings-Position="Bottom" Width="98%">
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
                                    <asp:BoundField DataField="AccountingYearCode" HeaderText="Yead Code" ItemStyle-CssClass="Yearcode" />
                                    <asp:BoundField DataField="StartYearDate" HeaderText="Start Date" ItemStyle-CssClass="StartDate" />
                                    <asp:BoundField DataField="EndYearDate" HeaderText="Close Date" ItemStyle-CssClass="CloseDate" />
                                    <asp:BoundField DataField="ClosingFlag" HeaderText="Close Flag" ItemStyle-CssClass="CloseFlag" />

                       </Columns>
                       </asp:GridView>
                </li>
                </ul>
             </asp:View>
   </asp:MultiView>

   </ContentTemplate>

   </asp:UpdatePanel>

  </asp:Content>
