<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffLICPolicies.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.StaffLICPolicies" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%--<%@ Register Src="../../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>--%>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
 <asp:UpdatePanel runat="server" ID="updatepanel_PolicyMaster">
        <ContentTemplate>
            
               
                <asp:MultiView ID="multiView_PolicyMasters" runat="server">
                    <asp:View ID="view_InputControls" runat="server">
                       <div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					
                        <ul id="PolicyEntryDetails">
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
										<asp:Label runat="server" ID="Label14" Text="Policy Details :" />
									</li>
                   
                           
                             <!--PolicyId-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Policyid" Text="Policy Type "></asp:Label>
                             
                            </li>
                           <li class="FormValue">
                                <asp:DropDownList ID="ddl_PolicyType" runat="server">
                                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">LIC-POLICY</asp:ListItem>
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_PolicyType" ControlToValidate="ddl_PolicyType" Display="Dynamic" SetFocusOnError="true" />
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
                             <!--PolicyappDate-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Policyappdate" Text="Policy Date" />
                            </li>
                            <li class="FormValue">
                               
                                <li class="FormValue">
										<asp:TextBox runat="server" ID="txt_Policyappdate" AutoPostBack="true" CssClass="JoinDate" />
										<ajax:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgButton_Policyappdate" CssClass="MicroCalendar" TargetControlID="txt_Policyappdate"  />
										<asp:ImageButton runat="server" ID="imgButton_Policyappdate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
										<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Policyappdate" ControlToValidate="txt_Policyappdate" Display="Dynamic" SetFocusOnError="true" />
										<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_Policyappdate" ControlToValidate="txt_Policyappdate" Display="Dynamic" SetFocusOnError="true" />
									</li>
                            </li>
                           <!--Policyamount-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_Policyamount" Text="Policy Amount" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox runat="server" ID="txt_Policyamount" />
                                <asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_PolicyAmount" ControlToValidate="txt_Policyamount" Display="Dynamic" SetFocusOnError="true" />
                            </li>

                            <!--TotalNoInstalment-->
                            <li class="FormLabel">
                                <asp:Label runat="server" ID="lbl_totalnoinstalment" 
                                    Text="Total Number Of Instalment" />
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
                                <asp:Label runat="server" ID="lbl_RequiredFor" Text="Comment" />
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
                            <asp:GridView ID="gridview_PolicyMaster" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BorderStyle="None" CellPadding="4" GridLines="None" Height="45px" PageSize="7"
                                Width="100%" OnRowCommand="gridview_PolicyMaster_RowCommand" OnRowEditing="gridview_PolicyMaster_RowEditing" OnRowDeleting="gridview_PolicyMaster_RowDeleting" OnPageIndexChanging="gridview_PolicyMaster_PageIndexChanging" OnRowDataBound="gridview_PolicyMaster_RowDataBound">
                                <PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <Columns>                                
                                 <asp:BoundField ShowHeader="false" DataField="PolicyApplicationID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_PolicyApplicationID" Visible="true" />
											<asp:Label runat="server" ID="lbl_PolicyApplicationID" Text='<%# Eval("PolicyApplicationID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID"/>
                                    <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName"/>
                                    <asp:BoundField DataField="PolicyDate" HeaderText="PolicyDate"  DataFormatString="{0:dd-MMM-yyyy}"/>
                                    <asp:BoundField DataField="PolicyAmount" HeaderText="Amount" >
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalNoInstallment" HeaderText="TotalNoInstallment" />
                                    <asp:BoundField DataField="Comment" HeaderText="Comment" />
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
