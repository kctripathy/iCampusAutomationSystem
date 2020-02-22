<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="QuestionMaster.aspx.cs" Inherits="LTPL.ICAS.WebApplication.APPS.ICAS.ADMIN.QuestionMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<asp:UpdatePanel ID="updatepanel_ManageFeedbacks" runat="server">
		<ContentTemplate>
			<h1 class="PageTitle">
				<asp:Literal runat="server" ID="lit_PageTitle" 
                    Text="Student feedback  Master File Maintanance:-" />
			</h1>
			<h2>
                <asp:RadioButtonList ID="RadioList_FeedBack" runat="server" AutoPostBack="True" 
                    Font-Bold="True" Font-Size="Medium" 
                    onselectedindexchanged="RadioList_FeedBack_SelectedIndexChanged" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">Create FeedBack</asp:ListItem>
                    <asp:ListItem Value="1">Set Options</asp:ListItem>
                </asp:RadioButtonList>
			</h2>
			<div>
				<asp:MultiView ID="multiview_ManageFeedbacks" runat="server">
					<asp:View ID="view_EnterQuestions" runat="server">
						<ul>							
							<li class="Spacer" />
							<li class="FormLabel">
								<asp:Label ID="lbl_QuestionTitle" runat="server" Text="Feedback Type:" />
                                <asp:Label ID="lbl_QuestionIDHide" runat="server" Text="lbl_QuestionIDHide" Visible="false"></asp:Label>
							</li>
							<li class="FormValue">
								<asp:TextBox ID="txt_QuestionTitle" runat="server" />
								<asp:RequiredFieldValidator ID="requriad_QuestionTitle" runat="server" ControlToValidate="txt_QuestionTitle" ErrorMessage="*" ForeColor="Red" />
							</li>
							<li class="Spacer" />
							<li class="FormLabel">
								<asp:Label ID="lbl_EnterQuestion" runat="server" 
                                    Text="Enter Feedback Questions : " />
							</li>
							<li class="FormValue">
								<asp:TextBox ID="txt_EnterQuestion" runat="server" Height="22px" Width="278px" />
								<asp:RequiredFieldValidator ID="Required_EnterQuestion" runat="server" ControlToValidate="txt_EnterQuestion" ErrorMessage="*" ForeColor="Red" />                                
							</li>
                            <li class="FormButton_Top">
                            <br /><br /><br />
                        <asp:Button ID="btn_Save" runat="server" Text="Save and Continue For Options" 
                                    OnClick="btn_Save_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Reset" CausesValidation="false" 
                            onclick="btn_Reset_Click" />
                        <asp:Button ID="Button3" runat="server" OnClick="btn_ViewAll_Click" Text="ViewAll" CausesValidation="false" />
                        </li>
						</ul>
					</asp:View>                    
					<asp:View ID="View_Grid" runat="server">
						<ul>
							<li class="Spacer" />
							<li class="FormButton_Top">
								<asp:Button ID="btn_AddNew" runat="server" Text="Add New" OnClick="btn_AddNew_Click" CausesValidation="false" />
							</li>
							<li class="PageSubTitle">
								<asp:Label runat="server" ID="Label1" />
							</li>
							<li class="GridView">
								<asp:GridView ID="gridview_Question" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" PageSize="10" CssClass="GridView" GridLines="Both" PagerSettings-Position="Bottom" Width="100%" OnPageIndexChanging="gridview_Question_PageIndexChanging" OnRowCommand="gridview_Question_RowCommand" OnRowDataBound="gridview_Question_RowDataBound" OnRowDeleting="gridview_Question_RowDeleting" OnRowEditing="gridview_Question_RowEditing">
									<PagerStyle CssClass="PagerStyle" VerticalAlign="Bottom" HorizontalAlign="Center" />
									<HeaderStyle CssClass="HeaderStyle" />
									<Columns>
                                    <asp:Templatefield>
                                        <HeaderTemplate>
                                            Sno
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Slno" runat="server"><%#(Container.DataItemIndex+1)%></asp:Label>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
										<asp:TemplateField ItemStyle-CssClass="QuestionID" Visible="false">
											<ItemTemplate>
												<asp:Label runat="server" ID="lbl_QuestionID" Text='<%# Eval("QuestionID") %>' Visible="false" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:BoundField DataField="QuestionID" HeaderText="QuestionID" Visible="false" />
										<asp:BoundField DataField="QuestionTitle" HeaderText="Question Title" ItemStyle-CssClass="QuestionTitle" />
										<asp:BoundField DataField="QuestionDesc" HeaderText="QuestionDesc" ItemStyle-CssClass="QuestionDesc" />
										<asp:CommandField ShowEditButton="True" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
											<ControlStyle CssClass="EditLink" />
											<ItemStyle CssClass="EditLinkItem" />
										</asp:CommandField>
										<asp:CommandField ShowDeleteButton="True" HeaderText="Del." ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
											<ControlStyle CssClass="DeleteLink" />
											<ItemStyle CssClass="DeleteLinkItem" />
										</asp:CommandField>
                                        <asp:CommandField ShowSelectButton="True" HeaderText="View Options" ButtonType="Link" ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
											<ControlStyle CssClass="EditLink" />
											<ItemStyle CssClass="EditLinkItem" />
										</asp:CommandField>
									</Columns>
									<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
									<PagerStyle CssClass="MicroPagerStyle" />
								</asp:GridView>
							</li>
						</ul>
					</asp:View>
                    <asp:View ID="option_EnterQuestions" runat="server">
                        <ul>
                            <li class="FormLabel">
                                <asp:Label ID="lbl_Question" runat="server" Text="Please Select a Question: " />
                            </li>
                            <li class="FormValue">
                                <asp:DropDownList ID="ddl_Question" runat="server" />
                            </li>
                           <li class="FormLabel">
                           <asp:Label ID="lbl_options" runat="server" Text="                 Option# 1 " /> 
                           </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Option1" runat="server" />
                                <asp:RequiredFieldValidator ID="Required_Option1" runat="server" ControlToValidate="txt_Option1" ErrorMessage="*" ForeColor="Red" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label ID="lbl_Option2" runat="server" Text="                 Option# 2" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Option2" runat="server" />
                                <asp:RequiredFieldValidator ID="Required_Option2" runat="server" ControlToValidate="txt_Option2" ErrorMessage="*" ForeColor="Red" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label ID="lbl_Option3" runat="server" Text="                 Option# 3" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Option3" runat="server" />
                                <asp:RequiredFieldValidator ID="Required_Option3" runat="server" ControlToValidate="txt_Option3" ErrorMessage="*" ForeColor="Red" />
                            </li>
                            <li class="FormLabel">
                                <asp:Label ID="lbl_Option4" runat="server" Text="                 Option# 4" />
                            </li>
                            <li class="FormValue">
                                <asp:TextBox ID="txt_Option4" runat="server" />
                                <asp:RequiredFieldValidator ID="Required_Option4" runat="server" ControlToValidate="txt_Option4" ErrorMessage="*" ForeColor="Red" />
                            </li>
                        </ul>
                        <ul id="Button">
                        <li class="FormButton_Top">
								<asp:Button ID="btn_SaveQ" runat="server" Text="Save" 
                                    onclick="btn_SaveQ_Click" />
								<asp:Button ID="btn_ResetQ" runat="server" Text="Reset" 
                                    CausesValidation="false" onclick="btn_ResetQ_Click" />
								<asp:Button ID="btn_ViewAllQ" runat="server" Text="ViewAll" 
                                    CausesValidation="false" onclick="btn_ViewAllQ_Click" />
							</li>

                            
                        </ul>
                        
                    </asp:View>
                    <asp:View ID="View_Options" runat="server">
                        <ul>
                            <li class="FormButton_Top">
                                <asp:Button ID="btn_AddNewQ" runat="server" Text="Add New" 
                                    CausesValidation="false" onclick="btn_AddNewQ_Click" />
                            </li>
                            <li class="PageSubTitle">
                                <asp:Label runat="server" ID="Label2" />
                                <asp:GridView ID="gridview_Option" runat="server" AllowPaging="true" 
                                    AllowSorting="true" AutoGenerateColumns="false" CssClass="GridView" 
                                    GridLines="Both" onpageindexchanging="gridview_Option_PageIndexChanging" 
                                    OnRowCommand="gridview_Option_RowCommand" 
                                    OnRowDataBound="gridview_Option_RowDataBound" 
                                    OnRowDeleting="gridview_Option_RowDeleting" 
                                    OnRowEditing="gridview_Option_RowEditing" PagerSettings-Position="Bottom" 
                                    PageSize="10" Width="100%">
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <PagerStyle CssClass="PagerStyle" HorizontalAlign="Center" 
                                        VerticalAlign="Bottom" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-CssClass="OptionID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_OptionID" runat="server" Text='<%# Eval("OptionID") %>' 
                                                     />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="QuestionDesc" HeaderText="QuestionDesc" Visible="true" />
                                        <asp:BoundField DataField="Option1" HeaderText="Option1" 
                                            ItemStyle-CssClass="Option1" />
                                        <asp:BoundField DataField="Option2" HeaderText="Option2" 
                                            ItemStyle-CssClass="Option2" />
                                        <asp:BoundField DataField="Option3" HeaderText="Option3" 
                                            ItemStyle-CssClass="Option3" />
                                        <asp:BoundField DataField="Option4" HeaderText="Option4" 
                                            ItemStyle-CssClass="Option4" />
                                        <asp:CommandField ButtonType="Image" ControlStyle-CssClass="EditLink" 
                                            EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" HeaderText="Edit" 
                                            ItemStyle-CssClass="EditLinkItem" ShowEditButton="True">
                                        <ControlStyle CssClass="EditLink" />
                                        <ItemStyle CssClass="EditLinkItem" />
                                        </asp:CommandField>
                                        <asp:CommandField ButtonType="Image" ControlStyle-CssClass="DeleteLink" 
                                            DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" HeaderText="Del." 
                                            ItemStyle-CssClass="DeleteLinkItem" ShowDeleteButton="True">
                                        <ControlStyle CssClass="DeleteLink" />
                                        <ItemStyle CssClass="DeleteLinkItem" />
                                        </asp:CommandField>
                                    </Columns>
                                    <PagerSettings FirstPageText="First" LastPageText="Last" 
                                        Mode="NumericFirstLast" Position="TopAndBottom" />
                                    <PagerStyle CssClass="MicroPagerStyle" />
                                </asp:GridView>
                            </li>
                        </ul>
                    </asp:View>
				</asp:MultiView>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
		<ItemTemplate>
			<ul>
				<li>
					<asp:Label ID="lbl_TheMessage" runat="server" Text=""></asp:Label>
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
</asp:Content>
