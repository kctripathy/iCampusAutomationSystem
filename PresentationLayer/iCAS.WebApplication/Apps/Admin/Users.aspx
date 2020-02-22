<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Micro.WebApplication.MicroERP.ADMIN.Users" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<h1 class="PageTitle">
		Manages Users:
	</h1>
	<asp:UpdatePanel ID="updatePanel_User" runat="server">
		<ContentTemplate>
			<asp:MultiView ID="multiView_User" runat="server" ActiveViewIndex="0">
				<asp:View ID="view_InputControl" runat="server">
					<div id="Mode">
						<asp:Label runat="server" ID="lbl_DataOperationMode" />
					</div>
					<ul id="Users">
						<li class="FormButton_Top">
							<div id="Top">
								<asp:Button ID="btn_ViewTop" runat="server" Text="View" CausesValidation="false" OnClick="btn_ViewTop_Click" />
								<asp:Button ID="btn_SaveTop" runat="server" Text="Save" OnClick="btn_SaveTop_Click" />
								<asp:Button ID="btn_ResetTop" runat="server" Text="Reset" CausesValidation="false" OnClick="btn_ResetTop_Click" />
							</div>
						</li>
						<li class="PageSubTitle"></li>
						<li class="FormLabel">
							<asp:Label ID="lbl_UserLogInName" runat="server" Text="User LogIn Name:" />
						</li>
						<li class="FormValue">
							<asp:TextBox ID="txt_UserLogInName" runat="server" />
							<asp:RequiredFieldValidator ID="requiredFieldValidator_UserLogInName" runat="server" ControlToValidate="txt_UserLogInName" Display="Dynamic" SetFocusOnError="true" />
							<%-- <asp:RegularExpressionValidator ID="regularExpressionValidator_UserLogInName" runat="server" ControlToValidate="txt_UserLogInName" Display="Dynamic" SetFocusOnError="true" />--%>
						</li>
						<li class="FormLabel">
							<asp:Label runat="server" ID="lbl_SelectGroup" Text="User Type:" />
						</li>
						<li class="FormValue">
							<asp:DropDownList ID="ddl_UserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_UserType_SelectedIndexChanged" />
							<asp:RequiredFieldValidator ID="requiredFieldValidator_UserType" runat="server" ControlToValidate="ddl_UserType" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label ID="lbl_UserReferenceName" runat="server" Text="User Reference Name:" />
						</li>
						<li class="FormValue">
							<asp:DropDownList ID="ddl_UserReferenceName" runat="server" />
							<%-- <asp:Label ID="lbl_UserRefName" runat="server" />--%>
							<asp:RequiredFieldValidator ID="requiredFieldValidator_UserName" runat="server" ControlToValidate="ddl_UserReferenceName" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label ID="lbl_Role" runat="server" Text="Role:" />
						</li>
						<li class="FormValue">
							<asp:DropDownList ID="ddl_Role" runat="server" />
							<asp:RequiredFieldValidator ID="requiredFieldValidator_Role" runat="server" ControlToValidate="ddl_Role" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label ID="lbl_Password" runat="server" Text="Password:" />
						</li>
						<li class="FormValue">
							<asp:TextBox ID="txt_LogInPassword" runat="server" TextMode="Password" />
							<asp:RequiredFieldValidator ID="requiredFieldValiddator_LogInPassword" runat="server" ControlToValidate="txt_LogInPassword" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormLabel">
							<asp:Label ID="lbl_ConfirmPassword" runat="server" Text="Confirm Password:" />
						</li>
						<li class="FormValue">
							<asp:TextBox ID="txt_ConfirmPassword" runat="server" TextMode="Password" />
							<asp:RequiredFieldValidator ID="requiredFieldValidator_ConfirmPassword" runat="server" ControlToValidate="txt_ConfirmPassword" Display="Dynamic" SetFocusOnError="true" />
							<asp:CompareValidator ID="compareValidator_ConfirmPassword" runat="server" ControlToValidate="txt_ConfirmPassword" ControlToCompare="txt_LogInPassword" Display="Dynamic" SetFocusOnError="true" />
						</li>
						<li class="FormButton_Top">
						<div id="Buttom">
							<asp:Button ID="btn_ViewBottom" runat="server" Text="View" CausesValidation="false" OnClick="btn_ViewTop_Click" />
							<asp:Button ID="btn_SaveBottom" runat="server" Text="Save" OnClick="btn_SaveTop_Click" />
							<asp:Button ID="btn_ResetBottom" runat="server" CausesValidation="false" Text="Reset" OnClick="btn_ResetTop_Click" />
							</div>
						</li>
					</ul>
				</asp:View>
				<asp:View ID="view_GridView" runat="server">
					<ul>
						<li class="FormButton_Top">
							<asp:Button ID="btn_AddNewUser" runat="server" Text="Add New User" OnClick="btn_AddNewUser_Click" />
						</li>
						<li class="FormPageCounter">
							<asp:Literal runat="server" ID="lit_PageCounter" />
						</li>
						<li class="GridView">
							<asp:GridView runat="server" ID="gview_Users" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="20" Width="98%" CssClass="GridView" GridLines="Both" OnRowCommand="gview_Users_RowCommand" OnPageIndexChanging="gview_Users_PageIndexChanging" OnRowEditing="gview_Users_RowEditing" OnRowDeleting="gview_Users_RowDeleting" OnRowDataBound="gview_Users_RowDataBound">
								<PagerStyle HorizontalAlign="Center" />
								<HeaderStyle CssClass="HeaderStyle" />
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<asp:Label runat="server" ID="lbl_UserId" Text='<%# Eval("UserID") %>'/>
											<asp:Label runat="server" ID="lbl_UserReferenceId" Text='<%# Eval("UserReferenceID") %>' Visible="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="UserName" HeaderText="User Name" ItemStyle-CssClass="UName" />
									<asp:BoundField DataField="UserReferenceName" HeaderText="User Reference Name" ItemStyle-CssClass="URName" />
									<asp:BoundField DataField="RoleDescription" HeaderText="Role Description" ItemStyle-CssClass="RoleDescription" />
									<asp:BoundField DataField="EmailAddress" HeaderText="Email" ItemStyle-CssClass="Email" />
									<asp:CommandField ShowEditButton="true" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ItemStyle-CssClass="EditLinkItem" ControlStyle-CssClass="EditLink" />
									<asp:CommandField ShowDeleteButton="true" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ItemStyle-CssClass="DeleteLinkItem" ControlStyle-CssClass="DeleteLink" />
								</Columns>
								<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
								<PagerStyle CssClass="MicroPagerStyle" />
							</asp:GridView>
						</li>
					</ul>
				</asp:View>
			</asp:MultiView>
			<IAControl:DialogBox ID="dialog_Message" runat="server" CssClass="modalPopup" BackgroundCssClass="modalBackground" EnableViewState="true" Style="display: none;" Title="">
				<ItemTemplate>
					<ul>
						<li>
							<asp:Label ID="lbl_TheMessage" runat="server" />
						</li>
					</ul>
				</ItemTemplate>
			</IAControl:DialogBox>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdateProgress runat="server" ID="PageUpdateProgress">
		<ProgressTemplate>
			<div id="UpdateProgress">
				<div class="UpdateProgressArea">
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
