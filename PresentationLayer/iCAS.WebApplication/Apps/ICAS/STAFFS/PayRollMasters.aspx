<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="PayRollMasters.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.PayRollMasters" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="~/App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Pay Roll Master:-" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_PayrollApplication">
		<ContentTemplate>
        <asp:MultiView ID="Multiview_Payroll" runat="server">
        <asp:View ID="view_InputControls" runat="server">
        <ul id="payrollmaster">
			        <div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
                     <li class="FormButton_Top">
                                    <li class="FormButton_Top">
                                        <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" />
                                        <asp:Button ID="btn_PayrollCancel" runat="server" CausesValidation="false"  
                                            OnClick="btn_PayrollCancel_Click" Text="Cancel" />
                                    </li>
                                    <li class="AppMessages">
                                        <asp:Literal ID="lblStatus" runat="server" Text="." />
                                    </li>
                                </li>
                       
                    <li class="FullWidth">
							<ul>
                                <li class="PageSubTitle">
                                    <asp:Label ID="lbl_title" runat="server" Font-Bold="True"  Text="PayRoll Details:-" />
                                </li>
                                <%--<li class="FormLabel">
                                    <asp:Label ID="lbl_EmpID" runat="server" Text="Emp ID:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_EmpID" runat="server" CssClass="empid" Width="150px" />
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_EmpID"  runat="server" ControlToValidate="txt_EmpID" Display="Dynamic" SetFocusOnError="true" />
                                </li>--%>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_Month" runat="server" Text="Month:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:DropDownList ID="DropDown_Month" runat="server" 
                                        CssClass="MonthDropDownList" Width="150px" >
                                        <asp:ListItem Selected="True">--Select--</asp:ListItem>
                                        <asp:ListItem Value="01">January</asp:ListItem>
                                        <asp:ListItem>February</asp:ListItem>
                                        <asp:ListItem>March</asp:ListItem>
                                        <asp:ListItem>April</asp:ListItem>
                                        <asp:ListItem>May</asp:ListItem>
                                        <asp:ListItem>June</asp:ListItem>
                                        <asp:ListItem>July</asp:ListItem>
                                        <asp:ListItem>August</asp:ListItem>
                                        <asp:ListItem>September</asp:ListItem>
                                        <asp:ListItem>October</asp:ListItem>
                                        <asp:ListItem>November</asp:ListItem>
                                        <asp:ListItem>December</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_Month"  runat="server" ControlToValidate="DropDown_Month" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_Year" runat="server" Text="Year:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:DropDownList ID="DropDown_Year" runat="server" 
                                        CssClass="YearDropDownList" Width="150px" >
                                        <asp:ListItem Selected="True">--Select--</asp:ListItem>
                                        <asp:ListItem>2002</asp:ListItem>
                                        <asp:ListItem>2003</asp:ListItem>
                                        <asp:ListItem>2004</asp:ListItem>
                                        <asp:ListItem>2005</asp:ListItem>
                                        <asp:ListItem>2006</asp:ListItem>
                                        <asp:ListItem>2007</asp:ListItem>
                                        <asp:ListItem>2008</asp:ListItem>
                                        <asp:ListItem>2009</asp:ListItem>
                                        <asp:ListItem>2010</asp:ListItem>
                                        <asp:ListItem>2011</asp:ListItem>
                                        <asp:ListItem>2012</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_year"  runat="server" ControlToValidate="DropDown_Year" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_Session" runat="server" Text="Session:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:DropDownList ID="DropDown_Session" runat="server" 
                                        CssClass="SessionDropDownList" Width="150px" >
                                        <asp:ListItem>2013-14</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_Session"  runat="server" ControlToValidate="DropDown_Session" Display="Dynamic" InitialValue="--Select--" SetFocusOnError="true" />
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_DateOfPay" runat="server" Text="Date Of Transaction:"></asp:Label>
                                </li>
                                <%--<head id="Head1" runat="server" />--%>
                                <li class="FormValueCalendar">
                                    <asp:TextBox ID="txt_DateOfPay" runat="server" CssClass="TextBoxClass" 
                                        Width="150px" />
                                    <ajax:CalendarExtender ID="CalendarExtenderDateOFPay" runat="server"  CssClass="MicroCalendar" Format="dd-MMM-yyyy"  OnClientDateSelectionChanged="CheckLeaveDateRangeForLeave"   PopupButtonID="imgButton_dateOfPay" TargetControlID="txt_DateOfPay" />
                                    <asp:ImageButton ID="imgButton_dateOfPay" runat="server"  CausesValidation="false" Height="21" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" ToolTip="Show Calender"  Width="21" />
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_DateOfPay" runat="server" ControlToValidate="txt_DateOfPay" Display="Dynamic" SetFocusOnError="true" />
                                    <asp:Button ID="btnPayslip" runat="server" onclick="btnPayslip_Click" 
                                        Text="View Pay Slip" />
                                    <asp:Button ID="btnexport" runat="server" onclick="btnexport_Click" 
                                        Text="Export To EXCEL" />
                                </li>
                                <li class="PageSubTitle">
                                    <asp:Label ID="lblBasic" runat="server" Font-Bold="True"  
                                        Text="Staff Payroll List" />
                                    &nbsp;<asp:Label ID="lbl_HeadingText" runat="server"></asp:Label>
                                </li>

                               <li class="FullWidth">
                                   <asp:Panel ID="pnlpayroll" runat="server" Width="98%" ScrollBars="Horizontal">                                  
                               <asp:GridView ID="GridBindEmpPayroll" runat="server" Width="100%" CssClass="GridView"
           
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
            CellPadding="3" GridLines="None" CellSpacing="1" EmptyDataText="--No Records Found--"
             >
            <HeaderStyle CssClass="HeaderStyle" />
            <HeaderStyle CssClass="HeaderStyle" />

                                   <Columns>
                                       <asp:TemplateField HeaderText="Slno">
                                       <ItemTemplate>
                                        <asp:Label ID="lbl_Slno" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>
                                       </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="View">
                                           <ItemTemplate>
                                               <asp:LinkButton ID="lnk_ViewPayRoll" runat="server" 
                                                   CommandArgument='<%# Eval("EmployeeID") %>' onclick="lnk_ViewPayRoll_Click">View</asp:LinkButton>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>                                   
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
 
        </asp:GridView>
                                   </asp:Panel>
                               </li>                               
                               <%-- <li class="PageSubTitle">
                                    <asp:Label ID="lblSavingDeduction" runat="server" Font-Bold="True"  Text="Saving Deduction Details:-" />
                                </li>

                               <li class="FullWidth">
                               </li>
         </li>
                                <li class="PageSubTitle">
                                    <asp:Label ID="lbltaxHead" runat="server" Font-Bold="True"  Text="Tax Deduction Details:-" />
                                </li>

                               <li class="FullWidth">
                               </li>--%>
                               <%-- <li class="FormLabel">
                                    <asp:Label ID="lbl_TotWorkingDays" runat="server" Text="Total day(s) of Working:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_TotWorkingDays" runat="server" CssClass="CountTextBox" Enabled="False" Width="40"></asp:TextBox>
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_PresentDays" runat="server" Text="Present Working Days:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_PresentDays" runat="server" CssClass="PresentDaysTextBox" ></asp:TextBox>
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_LeavingDays" runat="server" Text="Absent Working Days:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_LeavingDays" runat="server" CssClass="LeavingDaysTextBox" ></asp:TextBox>
                                </li>
                                <li class="FormLabel">
                                    <asp:Label ID="lbl_AbsentDeduction" runat="server" Text="Absent Deduction Amount:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_AbsentDeductionAmount" runat="server" CssClass="AbsentDeductionAmountTextBox"></asp:TextBox>
                                </li>
                                 <li class="FormLabel">
                                    <asp:Label ID="lbl_EmiDeduction" runat="server" Text="EMI Deduction(if any):"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_EmiDeduction" runat="server" CssClass="EmiDeductionAmountTextBox" ></asp:TextBox>
                                </li>--%>
                                <li class="FormLabel">
                                    <asp:Label ID="lblNetPay" runat="server" Text="Total Net Pay Of The Month:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_NetPayMonth" runat="server" CssClass="NetPayAmountTextBox" 
                                        Enabled="False"></asp:TextBox>
                                </li>
                                <li class="FullWidth">
                                   <asp:DetailsView ID="DetailsView1" runat="server" Width="100%" 
                                       BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                                       CellPadding="3" GridLines="Vertical" CellSpacing="10" Font-Bold="False" 
                                        HeaderText="Detail Payroll Structure Of The Employee">
                                       <AlternatingRowStyle BackColor="#DCDCDC" />
                                       <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                       <EmptyDataRowStyle Width="80%" />
                                       <FieldHeaderStyle Font-Bold="True" Font-Size="9pt" ForeColor="#990099" 
                                           Width="30%" />
                                       <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                       <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" 
                                           BorderStyle="Solid" />
                                       <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                       <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                   </asp:DetailsView>
                               </li>
                          </ul>                           
                    </li>
                                        
         </ul>
         </asp:View>
         <%--<asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_AddApplication" Text="Add Application" 
                                CausesValidation="false" onclick="btn_AddApplication_Click"  />
						</li>
						<li>
							<micro:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search AttendanceApplication(s), where:" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
                            <asp:GridView ID="gridview_pAYROLLMASTER" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BorderStyle="None" CellPadding="4" GridLines="None" Height="45px" PageSize="7"
                                Width="100%" >
                                <Columns>
                                 <asp:BoundField ShowHeader="false" DataField="AttendanceApplicationID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_PayRollID" Visible="true" />
											<asp:Label runat="server" ID="lbl_PayRollID" Text='<%# Eval("PayRollID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>                                     
                                    <asp:BoundField DataField="BillNo" HeaderText="BillNo" />
                                    <asp:BoundField DataField="TvNo" HeaderText="TvNo" />
                                    <asp:BoundField DataField="BillDDate" HeaderText="BillDDate"  DataFormatString="{0:dd-MMM-yyyy}"/>                                                                      
                                    <asp:BoundField DataField="Month" HeaderText="Month" />
                                    <asp:BoundField DataField="Year" HeaderText="Year" />
                                    <asp:BoundField DataField="Month" HeaderText="BillDDate" />
                                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />
                                    <asp:BoundField DataField="PresentDay" HeaderText="PresentDay" />
                                    <asp:BoundField DataField="BankLoanEMI" HeaderText="BankLoanEMI" />
                                    <asp:BoundField DataField="FixedDeduction" HeaderText="FixedDeduction" />
                                    <asp:BoundField DataField="OtherDeduction" HeaderText="OtherDeduction" />
                                    <asp:BoundField DataField="NetPayable" HeaderText="NetPayable" />
                                    <asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
                                </Columns>
                            </asp:GridView>
                        </li>
                        <li class="FormSpacer" />
                    </ul>
                    </asp:View>--%>
        </asp:MultiView>
                    
		
    <%-- <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
		<ProgressTemplate>
			<div id="UpdateProgress">
				<div class="UpdateProgressArea" />
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
    --%>
    </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>
