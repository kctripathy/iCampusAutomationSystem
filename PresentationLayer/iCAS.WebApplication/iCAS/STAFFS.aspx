<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="STAFFS.aspx.cs" Inherits="LTPL.ICAS.WebApplication.iCAS.STAFFS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style type="text/css">
		

		span.Name
		{
			font-size: 1.1em;
			margin-left: 5px;
		}

		span.Desig
		{
			font-size: 1.1em;
			margin-left: 5px;
		}

		span.dept
		{
			font-size: 1.1em;
			margin-left: 5px;
		}

		#StaffProfiles
		{
			margin: 0px;
			padding: 0px;
			width: 97%;
		}


		#StaffDetailsView
		{
			display: block;
			float: left;
			width: 100%;
		}



		/*  Define the background color for all the ODD background rows  */
		.StaffDetails li:nth-child(odd)
		{
			background: #b8d1f3;
			display: block;
			float: left;
			width: 25%;
		}
		/*  Define the background color for all the EVEN background rows  */
		.StaffDetails li:nth-child(even)
		{
			background: #dae5f4;
			display: block;
			float: left;
			width: 70%;
		}
		#ContentPlaceHolder1_gview_Employee > tbody > tr > td > a
		{
			color:navy;
			text-decoration:underline;
		}
		#ContentPlaceHolder1_gview_Employee > tbody > tr > td > a:hover
		{
			color:red;
			font-weight:bold;
			text-decoration:none;
		}

	</style>
	<h1 class="PageTitle">
		<asp:Literal runat="server" ID="lit_PageTitle" Visible="false" />
		<asp:Literal runat="server" ID="lit_StaffDetails" />
		<asp:Literal runat="server" ID="lit_StaffDetailsInfo" />
		<asp:LinkButton runat="server" ID="lnkViewAllStaffs" Text=" View All Staffs" OnClick="lnkViewAllStaffs_Click" Visible="false" />
		<asp:Label runat="server" ID="lbl_StaffCategory" />
	</h1>
	<div class="innercontent">
		<ul id="StaffProfiles">
			<li>
				<asp:RadioButtonList runat="server" Visible="true"
					ID="optCategory"
					AutoPostBack="true"
					OnSelectedIndexChanged="optCategory_OnSelectedIndexChanged"
					RepeatDirection="Horizontal"
					CellSpacing="8"
					CellPadding="1">
					<asp:ListItem Text="&nbsp;Display All Staffs&nbsp;&nbsp;&nbsp;" Value="A" Selected="True" />
					<asp:ListItem Text="&nbsp;Teaching Staffs &nbsp;&nbsp;&nbsp;" Value="T" Selected="False" />
					<asp:ListItem Text="&nbsp;Non-Teaching Staffs&nbsp;&nbsp;&nbsp;" Value="N" Selected="False" />
				</asp:RadioButtonList>
			</li>
			<li class="GridView StaffDetails">
				<asp:GridView runat="server" ID="gview_Employee" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="70" Width="99%" CssClass="GridView" GridLines="Both" CellPadding="2" OnPageIndexChanging="gview_Employee_PageIndexChanging">
					<HeaderStyle CssClass="HeaderStyle" />
					<Columns>
						<%-- <asp:TemplateField ItemStyle-CssClass="CheckBox">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chk_EmployeeID" Visible="true" />
                            <asp:Label runat="server" ID="lbl_EmployeeID" Text='<%# Eval("EmployeeID") %>' Visible="false" />
                            <asp:Label runat="server" ID="lbl_ServiceDetailsID" Text='<%#Eval("EmployeeServiceDetailsID") %>' Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
						<asp:BoundField DataField="DepartmentDescription" HeaderText="Department" ItemStyle-CssClass="Department" />
						<%--<asp:BoundField DataField="EmployeeName" HeaderText="Name " ItemStyle-CssClass="EmployeeName" />--%>
						<asp:HyperLinkField
							DataNavigateUrlFields="EmployeeID"
							DataNavigateUrlFormatString="staffs.aspx?Page=View&ID={0}"
							DataTextField="EmployeeName"
							HeaderText="Staff Name" />

						<asp:BoundField DataField="DesignationDescription" HeaderText="Designation " ItemStyle-CssClass="DesignationAndRole" />
						<%--<asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" ItemStyle-CssClass="OfficeName" />--%>
						<%--<asp:BoundField DataField="JoiningDateInOffice" HeaderText="JoiningDate" ItemStyle-CssClass="OfficeName" />--%>
						<%-- <asp:BoundField DataField="LastQualification" HeaderText="Qualification" ItemStyle-CssClass="OfficeName" />--%>
						<%-- <asp:BoundField DataField="Employeetype1" HeaderText="-" ItemStyle-CssClass="OfficeName" />
                        <asp:BoundField DataField="Employeetype2" HeaderText="-" ItemStyle-CssClass="OfficeName" />
                        <asp:BoundField DataField="Employeetype3" HeaderText="-" ItemStyle-CssClass="OfficeName" />
                        <asp:BoundField DataField="Employeetype4" HeaderText="-" ItemStyle-CssClass="OfficeName" />--%>
						<asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ItemStyle-CssClass="Department" Visible="false" />
						<asp:BoundField DataField="EmployeeCode" HeaderText="Code " ItemStyle-CssClass="EmployeeCode" />

						<%-- <asp:CommandField ShowSelectButton="true" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ItemStyle-CssClass="ViewLinkItem" ControlStyle-CssClass="ViewLink" />--%>
					</Columns>
					<PagerSettings Position="Bottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
					<PagerStyle CssClass="MicroPagerStyle" />
				</asp:GridView>
			</li>
		</ul>		 
	</div>
</asp:Content>
