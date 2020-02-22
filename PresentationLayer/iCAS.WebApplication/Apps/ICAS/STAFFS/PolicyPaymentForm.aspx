<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="PolicyPaymentForm.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.STAFFS.PolicyPaymentForm" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="~/App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="micro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Text="Policy Payment Form:-" />
	</h1>
	<asp:UpdatePanel runat="server" ID="updatePanel_PolicyApplication">
		<ContentTemplate>
        <asp:MultiView ID="Multiview_Policy" runat="server">
        <asp:View ID="view_InputControls" runat="server">
        <ul id="Policymaster">
			 <div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
             <li class="FormButton_Top">
              <li class="FormButton_Top">
                 <asp:Button ID="btn_NewPolicy" runat="server" Text="Add New Policy" 
                      onclick="btn_NewPolicy_Click" />
                 <asp:Button ID="btn_PolicyCancel" runat="server" CausesValidation="false"  OnClick="btn_PolicyCancel_Click" Text="Cancel" />
             </li>
             <li class="GridView">
							<asp:GridView runat="server" ID="gview_Employee" AutoGenerateColumns="False" 
                                AllowPaging="True" AllowSorting="True" PageSize="15" Width="98%" 
                                CssClass="GridView" CellPadding="2">
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>											
											<asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />											
										</ItemTemplate>
									    <ItemStyle CssClass="CheckBox" />
									</asp:TemplateField>
                                     <asp:TemplateField HeaderText="View">
                                           <ItemTemplate>
                                               <asp:LinkButton ID="lnk_ViewPolicy" runat="server" 
                                                   CommandArgument='<%# Eval("EmployeeID") %>' onclick="lnk_ViewPolicy_Click">View</asp:LinkButton>
                                           </ItemTemplate>
                                       </asp:TemplateField>  
									<asp:BoundField DataField="EmployeeCode" HeaderText="Code " 
                                        ItemStyle-CssClass="EmployeeCode" >
									<ItemStyle CssClass="EmployeeCode" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Name ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemployeeName" runat="server" 
                                                Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle CssClass="EmployeeName" />
                                    </asp:TemplateField>
									<asp:BoundField DataField="DesignationDescription" HeaderText="Designation " 
                                        ItemStyle-CssClass="DesignationAndRole" >
									<ItemStyle CssClass="DesignationAndRole" />
                                    </asp:BoundField>
									<asp:BoundField DataField="OfficeName" HeaderText="Office" 
                                        ItemStyle-CssClass="OfficeName" >
									<ItemStyle CssClass="OfficeName" />
                                    </asp:BoundField>
									<asp:BoundField DataField="DepartmentDescription" HeaderText="Department" 
                                        ItemStyle-CssClass="Department" >
									<ItemStyle CssClass="Department" />
                                    </asp:BoundField>
								</Columns>
								<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
								<PagerStyle CssClass="MicroPagerStyle" />
							</asp:GridView>
						</li>
              <li class="AppMessages">
                  <asp:Literal ID="lblStatus" runat="server" Text="." />
              </li>
             </li>                       
                    <li class="FullWidth">
							<ul>
                                <%--<li class="PageSubTitle">
                                    <asp:Label ID="lbl_title" runat="server" Font-Bold="True"  Text="Policy Details:-" />
                                </li>
                               
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
                                </li>--%>
                                
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
                                
                          </ul>                           
                    </li>
                                        
         </ul>
         </asp:View>
         <asp:View ID="view_GridView" runat="server">
					<ul class="GridView">
						<li class="FormButton_Top">
							<asp:Button runat="server" ID="btn_AddApplication" Text="Swith To Other Employee" 
                                CausesValidation="false" onclick="btn_AddApplication_Click"  />
						</li>						
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li>
                            <%--<asp:GridView ID="gridview_PolicyMASTER" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BorderStyle="None" CellPadding="4" GridLines="None" Height="45px" PageSize="7"
                                Width="100%" >
                                <Columns>
                                 <asp:BoundField ShowHeader="false" DataField="AttendanceApplicationID" Visible="false" />
									<asp:TemplateField ItemStyle-CssClass="CheckBox">
										<ItemTemplate>
											<asp:CheckBox runat="server" ID="chk_PolicyID" Visible="true" />
											<asp:Label runat="server" ID="lbl_PolicyID" Text='<%# Eval("PolicyID") %>' Visible="false" />
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
                            </asp:GridView>--%>
                        </li>
                        <li class="PageSubTitle">
                                    <asp:Label ID="lblBasic" runat="server" Font-Bold="True"  
                                        Text="Staff Policy List" />
                                    &nbsp;<asp:Label ID="lbl_HeadingText" runat="server"></asp:Label>
                                </li>

                               <li class="FullWidth">
                                   <asp:Panel ID="pnlPolicy" runat="server" Width="98%" ScrollBars="Horizontal">                                  
                               <asp:GridView ID="GridBindEmpPolicy" runat="server" Width="100%" CssClass="GridView"
           
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
            CellPadding="3" GridLines="None" CellSpacing="1" EmptyDataText="--No Records Found--" AutoGenerateColumns="False"
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
                                               <asp:LinkButton ID="lnk_ViewEmpPolicy" runat="server" 
                                                   CommandArgument='<%# Eval("EmployeeID") %>' onclick="lnk_ViewEmpPolicy_Click">View</asp:LinkButton>
                                           </ItemTemplate>
                                       </asp:TemplateField>                                      									
									<asp:BoundField DataField="EmployeeCode" HeaderText="Code " 
                                           ItemStyle-CssClass="EmployeeCode" >
									   <ItemStyle CssClass="EmployeeCode" />
                                       </asp:BoundField>
									<asp:BoundField DataField="EmployeeName" HeaderText="Name " 
                                           ItemStyle-CssClass="EmployeeName" >
									   <ItemStyle CssClass="EmployeeName" />
                                       </asp:BoundField>
									<asp:BoundField DataField="Mobile" HeaderText="Mobile " 
                                           ItemStyle-CssClass="DesignationAndRole" >
									   <ItemStyle CssClass="DesignationAndRole" />
                                       </asp:BoundField>
									<asp:BoundField DataField="PolicyID" HeaderText="PolicyID" 
                                           ItemStyle-CssClass="OfficeName" >
									   <ItemStyle CssClass="OfficeName" />
                                       </asp:BoundField>
									<asp:BoundField DataField="PolicyAmount" HeaderText="PolicyAmount" 
                                           ItemStyle-CssClass="Department" >
                                       <ItemStyle CssClass="Department" />
                                       </asp:BoundField>
                                    <asp:BoundField DataField="PolicyDate" HeaderText="PolicyDate" 
                                           ItemStyle-CssClass="Department" >
                                       <ItemStyle CssClass="Department" />
                                       </asp:BoundField>
                                    <asp:BoundField DataField="PolicyStatus" HeaderText="PolicyStatus" 
                                           ItemStyle-CssClass="Department" >
                                       <ItemStyle CssClass="Department" />
                                       </asp:BoundField>
                                    <asp:BoundField DataField="Comment" HeaderText="Comment" 
                                           ItemStyle-CssClass="Department" >
                                       <ItemStyle CssClass="Department" />
                                       </asp:BoundField>
                                    <asp:BoundField DataField="EMI" HeaderText="EMI" ItemStyle-CssClass="Department" >
                                       <ItemStyle CssClass="Department" />
                                       </asp:BoundField>
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
                              <%-- <li class="FormLabel">
                                    <asp:Label ID="lblNetPay" runat="server" Text="Total Net Pay Of The Month:"></asp:Label>
                                </li>
                                <li class="FormValue">
                                    <asp:TextBox ID="txt_NetPayMonth" runat="server" CssClass="NetPayAmountTextBox" Enabled="False"></asp:TextBox>
                                </li>--%>
                                <li class="FullWidth">
                                   <asp:DetailsView ID="DetailsView1" runat="server" Width="100%" Font-Bold="False" 
                                        HeaderText="Detail Policy Structure Of The Employee">
                                       <EmptyDataRowStyle Width="80%" />
                                       <FieldHeaderStyle Font-Size="9pt" 
                                           Width="30%" />
                                       <HeaderStyle 
                                           BorderStyle="Solid" />
                                       <%--<RowStyle BackColor="#EEEEEE" ForeColor="Black" />--%>
                                   </asp:DetailsView>
                               </li> 
                               <li class="StaffpolicyFullWidth">                               
                                   <asp:Panel ID="pnlPayment" runat="server" Visible="False">
                                   <ul class="Policy">
                                   <li class="FormLabel">
                                       <asp:Label ID="lbl_Instalment" runat="server" Text="Instalment Amount"></asp:Label></li>
                                   <li class="FormValue">
                                       <asp:Label ID="lbl_IntalmentAmount" runat="server" Text=""></asp:Label></li>
                                   <li class="FormLabel">
                                       <asp:Label ID="lbl_NoOfInstal" runat="server" Text="No Of Instalment :"></asp:Label></li>
                                   <li class="FormValue">
                                       <asp:TextBox ID="txt_NoOfInstal" runat="server" AutoPostBack="True" 
                                           ontextchanged="txt_NoOfInstal_TextChanged"></asp:TextBox></li>
                                   <li class="FormLabel">
                                       <asp:Label ID="lbl_Instalamount" runat="server" Text="Amount in Rs."></asp:Label></li>
                                   <li class="FormValue">
                                       <asp:TextBox ID="txt_InstalAmount" runat="server"></asp:TextBox></li>
                                   <li class="FormLabel">
                                       <asp:Label ID="lbl_Date" runat="server" Text="Date Of Transaction :"></asp:Label></li>
                                   <li class="FormValue">
                                    <asp:TextBox ID="txt_DateOfPay" runat="server" CssClass="TextBoxClass" Width="150px" />
                                    <ajax:CalendarExtender ID="CalendarExtenderDateOFPay" runat="server"  CssClass="MicroCalendar" Format="dd-MMM-yyyy"  OnClientDateSelectionChanged="CheckLeaveDateRangeForLeave"   PopupButtonID="imgButton_dateOfPay" TargetControlID="txt_DateOfPay" />
                                    <asp:ImageButton ID="imgButton_dateOfPay" runat="server"  CausesValidation="false" Height="21" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" ToolTip="Show Calender"  Width="21" />
                                    <asp:RequiredFieldValidator ID="requiredFieldValidator_DateOfPay" runat="server" 
                                           ControlToValidate="txt_DateOfPay" Display="Dynamic" SetFocusOnError="true" 
                                           ValidationGroup="0" />
                                       <asp:HiddenField ID="HiddenField1" runat="server" />
                                       </li>
                                   </ul>
                                   </asp:Panel>
                               </li> 
                               <li class="FullWidth">
                               <ul class="StaffFullWidth">
					            <li class="FormButton_Top">
						            <asp:Button runat="server" ID="btn_Save" Text="Save" 
                                    CausesValidation="false" OnClick="Btn_Save_Click" />
						            <asp:Button ID="btn_Reset" runat="server" CausesValidation="false" Text="Reset" 
                                        OnClick="btn_Reset_Click"></asp:Button>
					            </li>
				                </ul>
                               </li>                            
                        <li class="FormSpacer" />
                    </ul>
                    </asp:View>
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
