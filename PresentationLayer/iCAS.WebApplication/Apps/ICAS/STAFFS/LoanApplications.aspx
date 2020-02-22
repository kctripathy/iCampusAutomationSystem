<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="LoanApplications.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.LoanApplications" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%--<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>--%>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
 <asp:UpdatePanel runat="server" ID="updatepanel_LoanMaster">
        <ContentTemplate>
            
               
                <asp:MultiView ID="multiView_LoanMasters" runat="server">
                    <asp:View ID="view_InputControls" runat="server">
                       <div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					
                        <ul id="LoanEntryDetails">
                           <li class="FormButton_Top">
							<div id="Top">
								<asp:Button runat="server" ID="btn_ViewApplication" CausesValidation="false" 
                                    Text=" View " onclick="btn_ViewApplication_Click"  />
								<asp:Button runat="server" ID="btn_Top_Save" Text="Save" OnClick="Btn_Save_Click" />
								<asp:Button ID="btn_Cancel_Top" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
							</div>
						</li>
						    
                          <li class="FullWidth">
								<ul>
									<li class="PageSubTitle">
										<asp:Label runat="server" ID="Label14" Text="Office Details :" />
									</li>
                   
                           
                             <!--LoanId-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_loanid" Text="Loan Application Type "></asp:Label>
                             
                            </li>
                           <li class="FormValue">
                                <asp:DropDownList ID="ddl_LoanType" runat="server" AutoPostBack="true"/>
                                 <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_LoanType" ControlToValidate="ddl_LoanType" Display="Dynamic" SetFocusOnError="true" />
                            </li>                            
                             <!--Accademic Year-->
                             <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_AcademicYear" Text="Academic Year " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_AcademicYear" runat="server" AutoPostBack="true"/>
                                 <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AcademicYear" ControlToValidate="ddl_AcademicYear" Display="Dynamic" SetFocusOnError="true" />
                            </li>                            
                           
                            <!--Employee-->
									<li class="FormLabel">
										<asp:Label runat="server" ID="lbl_EmployeeName" Text="Employee Name:" />
										<asp:Label runat="server" ID="Label25" Text="*" CssClass="ValidationColor" />
									</li>
									<li class="FormValue">
										<asp:DropDownList runat="server" ID="ddl_EmployeeName" Width="95%" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_EmployeeName" ControlToValidate="ddl_EmployeeName" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
									</li>
                             <!--LoanappDate-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_loanappdate" Text="Loanappdate" />
                            </li>
                            <li class="FormValue">
                               
                                <li class="FormValue">
										<asp:TextBox runat="server" ID="txt_loanappdate" AutoPostBack="true" CssClass="JoinDate" />
										<ajax:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_loanappdate" CssClass="MicroCalendar" TargetControlID="txt_loanappdate"  />
										<asp:ImageButton runat="server" ID="imgButton_loanappdate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_loanappdate" ControlToValidate="txt_loanappdate" Display="Dynamic" SetFocusOnError="true" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_loanappdate" ControlToValidate="txt_loanappdate" Display="Dynamic" SetFocusOnError="true" />
									</li>
                            </li>
                           <!--Loanamount-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_loanamount" Text=" loanamount" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_loanamount" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_LoanAmount" ControlToValidate="txt_loanamount" Display="Dynamic" SetFocusOnError="true" />
                            </li>

                            <!--TotalNoInstalment-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_totalnoinstalment" Text="Totalnoinstalment" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_toalnoinstalment" />
                            </li>
                              <!--EMI-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_emi" Text="EMI" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_emi"  />
                            </li>

                             <!--RequiredFor-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_RequiredFor" Text="Required For" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_RequiredFor"  />
                            </li>
                     
                      <li class="FormLabel"></li>
						<!--Action Button-->
						<li class="FormButton_Top">
							<div id="Buttom">
								<asp:Button runat="server" ID="Button3" CausesValidation="false" Text=" View "  onclick="btn_ViewApplication_Click"  />
								<asp:Button runat="server" ID="Btn_Save" Text="Save" OnClick="Btn_Save_Click" />
								<asp:Button ID="btn_Cancel" runat="server" CausesValidation="false" OnClick="btn_Cancel_Click" Text="Reset" />
							</div>
						</li>
						<li class="FormMessage">
							<asp:Literal runat="server" ID="lit_Message" Text="" />
						</li>
						<li class="FormSpacer" />
					</ul>
                </ul> 
                    </asp:View>
                

                 <asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_AddApplication" Text="Add Application" 
                                CausesValidation="false" onclick="btn_AddApplication_Click"  />
						</li>
						<%--<li>
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search AttendanceApplication(s), where:" />
						</li>--%>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
                            <asp:GridView ID="gridview_LoanMaster" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BorderStyle="None" CellPadding="4" GridLines="None" Height="45px" PageSize="7"
                                Width="100%" OnRowCommand="gridview_LoanMaster_RowCommand" OnRowEditing="gridview_LoanMaster_RowEditing" OnRowDeleting="gridview_LoanMaster_RowDeleting" OnPageIndexChanging="gridview_LoanMaster_PageIndexChanging" OnRowDataBound="gridview_LoanMaster_RowDataBound">
                                <Columns>
                                 <asp:BoundField ShowHeader="false" DataField="LoanApplicationID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_LoanApplicationID" Visible="true" />
											<asp:Label runat="server" ID="lbl_LoanApplicationID" Text='<%# Eval("LoanApplicationID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
                                     <asp:BoundField DataField="LoanApplicationDate" HeaderText="Date"  DataFormatString="{0:dd-MMM-yyyy}"/>
                                    <asp:BoundField DataField="LoanAmount" HeaderText="Amount" >
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalNoInstallment" HeaderText="TotalNoInstallment" />
                                    <asp:BoundField DataField="RequiredFor" HeaderText="Reason" />
                                    <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
                                </Columns>
                            </asp:GridView>
                        </li>
                        <li class="FormSpacer" />
                    </ul>
                    </asp:View>
                
                </asp:MultiView>
           
             <IAControl:DialogBox ID="dialog_Message" runat="server" BackgroundCssClass="modalBackground"
                CssClass="modalPopup" EnableViewState="true" Style="display: none" Title="">
                <ItemTemplate>
                    <ul>
                        <li>
                            <asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
                        </li>
                    </ul>
                </ItemTemplate>
            </IAControl:DialogBox>
        
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
