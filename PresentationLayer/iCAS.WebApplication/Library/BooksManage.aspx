<%@ Page Title="Library Books Master File - TSD College, BD Pur -761120" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="BooksManage.aspx.cs" Inherits="TCon.iCAS.WebApplication.Library.BooksManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Src="../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
	<asp:UpdatePanel runat="server" ID="UpdatePanel_Books" UpdateMode="Conditional">
		<ContentTemplate>
			<div class="innercontent">
				<h1 class="PageTitle">Library [ Total Books:
                    <asp:Literal runat="server" ID="lit_BookCount" Text="0" />]</h1>


				<%--New Book--%>
				<ul>
					<li>
						<asp:Panel runat="server" ID="panel_InputBookDetails" Visible="true">
							<ul id="LibraryBookUL" runat="server">
								<li class="PageSubTitle" style="margin: 0; padding: 0;">
									<asp:Label runat="server" ID="lbl_1" Text="Book Details:" />
									<span class="RequiredField">'*' </span>Indicates the mandatory or required fields.
								</li>
								<li>
									<asp:Button ID="ButtonView" runat="server" Text="View Books" CausesValidation="false" OnClick="ButtonView_Click" class="btn btn-primary btn-xs" />
									<asp:Button ID="ButtonSave" runat="server" Text="Save" CausesValidation="true" OnClick="ButtonSave_Click" class="btn btn-primary btn-xs" />
									<asp:Button ID="ButtonCancel" runat="server" Text="&nbsp;&nbsp;Cancel&nbsp;&nbsp;&nbsp;" CausesValidation="false" OnClick="ButtonCancel_Click" class="btn btn-primary btn-xs" />
								</li>
								<li class="FormLabel">
									<asp:Label runat="server" ID="Label1" Text="Book Type:" /><span class="RequiredField">*</span>

								</li>
								<li class="FormValue">
									<asp:RadioButtonList ID="rblst_BookTypes" RepeatDirection="Horizontal" runat="server" AutoPostBack="false" CssClass="BookTypeClass">
										<asp:ListItem Text="General" Value="GEN"></asp:ListItem>
										<asp:ListItem Text="UGC" Value="UGC" Selected="True"></asp:ListItem>
									</asp:RadioButtonList>
								</li>

								<%--Segment--%>
								<li class="FormLabel">
									<asp:Label runat="server" ID="lbl_2" Text="Segment:" /><span class="RequiredField">*</span>
								</li>
								<li class="FormValue">
									<ul>
										<li>
											<asp:DropDownList ID="ddl_Segments" runat="server" CssClass="SegmentClass" Width="50%" />
											<asp:LinkButton ID="lnkbtn_NewSegment" runat="server" OnClick="lnkbtn_NewSegment_Click" Text="Add New Segment?" CausesValidation="false" CssClass="btn btn-primary btn-xs" />
										</li>

									</ul>
								</li>
								<%--Category--%>
								<li class="FormLabel">
									<asp:Label runat="server" ID="Label18" Text="Category:" /><span class="RequiredField">*</span>
								</li>
								<li class="FormValue">
									<asp:DropDownList ID="ddl_Category" runat="server" Width="40%" CssClass="SegmentClass" />
									<asp:LinkButton ID="lnkbtn_NewCategory" runat="server" OnClick="lnkbtn_NewCategory_Click" Text="Add New Category?" CausesValidation="false" CssClass="btn btn-primary btn-xs" />
								</li>

								<%--Accession Details.--%>
								<li class="FormLabel">
									<asp:Label runat="server" ID="lbl_AccessionNo" Text="Accession No.:" />
									<span class="RequiredField">*</span>
								</li>
								<li class="FormValue">
									<asp:TextBox runat="server" ID="txt_AccessionNo" MaxLength="6" CssClass="AccessionNoStyle" Width="26%" />
									<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AccessionNo" ControlToValidate="txt_AccessionNo" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Please enter Accession Number" CssClass="RequiredField" />
									<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_AccessionNo" ControlToValidate="txt_AccessionNo" Display="Dynamic" SetFocusOnError="true" />

								</li>
								<li class="FormLabel">
									<asp:Label runat="server" ID="lbl_DateOfAccession" Text="Accession Date: " />
									<span class="RequiredField">*</span>
								</li>
								<li class="FormValue">
									<asp:TextBox runat="server" ID="txt_AccessionDate" Width="26%" CssClass="AccesionDateStyle" />
									<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_AccessionDate" ControlToValidate="txt_AccessionDate" CssClass="RequiredField" Display="Dynamic" ErrorMessage="Please enter Date of Accession" SetFocusOnError="true" />

									<asp:ImageButton runat="server" ID="imgbtn_Startdate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
									<ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_Startdate" PopupButtonID="imgbtn_Startdate" CssClass="MicroCalendar" TargetControlID="txt_AccessionDate"></ajax:CalendarExtender>

									<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_AccessionDate" ControlToValidate="txt_AccessionDate" Display="Dynamic" SetFocusOnError="true" />

								</li>


								<li class="FormLabel">
									<asp:Label runat="server" ID="Label11" Text="Bill No:" />
								</li>
								<li class="FormValue">
									<asp:TextBox ID="txt_BillNo" runat="server" Width="26%" MaxLength="20" />
								</li>

								<li class="FormLabel">
									<asp:Label runat="server" ID="Label15" Text="Bill Date: " />
								</li>
								<li class="FormValue">
									<asp:TextBox runat="server" ID="txt_BillDate" Width="26%" CssClass="AccesionDateStyle" />
									<asp:ImageButton runat="server" ID="ImageButtonBillDate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
									<ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="CalendarExtender1" PopupButtonID="ImageButtonBillDate" CssClass="MicroCalendar" TargetControlID="txt_BillDate"></ajax:CalendarExtender>

								</li>

								<%--Title--%>
								<li class="FormLabel">
									<asp:Label runat="server" ID="Label2" Text="Title:" /><span class="RequiredField">*</span>
								</li>
								<li class="FormValue">
									<asp:TextBox ID="txt_Title" runat="server" TextMode="SingleLine" MaxLength="499" Width="70%" />
									<asp:RequiredFieldValidator runat="server" ID="requiredFieldValidator_Name" ControlToValidate="txt_Title" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Title Can't be empty!" CssClass="RequiredField" />
								</li>


								<li class="FormLabel">
									<asp:Label runat="server" ID="Label3" Text="Author:" /><span class="RequiredField">*</span>
								</li>
								<li class="FormValue">
									<asp:DropDownList ID="ddl_Author" runat="server" Width="70%" CssClass="SegmentClass" />
									<asp:LinkButton ID="lnkbtn_NewAuthor" runat="server" OnClick="btn_NewAuthor_Click" Text="Add New Author?" CausesValidation="false" CssClass="btn btn-primary btn-xs" />
								</li>
								<li class="FormLabel">
									<asp:Label runat="server" ID="Label8" Text="Publisher:" /><span class="RequiredField">*</span>
								</li>
								<li class="FormValue">
									<asp:DropDownList ID="ddl_Publisher" runat="server" Width="70%" CssClass="SegmentClass" />
									<asp:LinkButton ID="lnkbtn_NewPublisher" runat="server" OnClick="lnkbtn_NewPublisher_Click" Text="Add New Publisher?" CausesValidation="false" CssClass="btn btn-primary btn-xs" />
								</li>


								<li class="FormLabel">
									<asp:Label runat="server" ID="Label9" Text="Supplier:" /><span class="RequiredField">*</span>
								</li>
								<li class="FormValue">
									<asp:DropDownList ID="ddl_Supplier" runat="server" Width="70%" CssClass="SegmentClass" />
									<asp:LinkButton ID="lnkbtn_Supplier" runat="server" OnClick="lnkbtn_Supplier_Click" Text="Add New Supplier?" CausesValidation="false" CssClass="btn btn-primary btn-xs" />
								</li>


								<li class="FormLabel ">
									<asp:Label runat="server" ID="Label4" Text="Edition:" />
								</li>
								<li class="FormValue ">
									<asp:TextBox ID="txt_Edition" runat="server" MaxLength="15" Width="20%" />
									<asp:Label runat="server" ID="Label5" Text="Year:" />
									<asp:TextBox ID="txt_Year" runat="server" MaxLength="4" Width="20%" />
									<asp:Label runat="server" ID="Label6" Text="Volume No:" />
									<asp:TextBox ID="txt_Volume" runat="server" MaxLength="20" Width="12%" />
								</li>
								<li class="FormLabel">
									<asp:Label runat="server" ID="Label7" Text="Pages:" />
								</li>
								<li class="FormValue">
									<asp:TextBox ID="txt_Pages" runat="server" TextMode="Number" Width="20%" />
									<asp:Label runat="server" ID="Label10" Text="Price:" />
									<asp:TextBox ID="txt_Price" runat="server" TextMode="Number" Width="20%" />
								</li>

								<li class="FormLabel">
									<asp:Label runat="server" ID="Label12" Text="Class No:" />
								</li>
								<li class="FormValue">
									<asp:TextBox ID="txt_ClassNo" runat="server" Width="20%" />
									<asp:Label runat="server" ID="Label13" Text="IBN Num:" />
									<asp:TextBox ID="txt_IBN" runat="server" Width="40%" />
								</li>

								<li class="FormLabel">
									<asp:Label runat="server" ID="Label14" Text="Remarks:" />
								</li>
								<li class="FormValue">
									<asp:TextBox ID="txt_Remarks" runat="server" TextMode="MultiLine" Width="90%" Rows="1" />
								</li>
								<li class="FormLabel">
									<asp:Label runat="server" ID="Label16" Text="Upload Files:" />
								</li>
								<li class="FormValue">
									<%--<asp:FileUpload ID="fileupload_CoverPage" runat="server" Width="90%" CssClass="SegmentClass" />--%>
									<asp:UpdatePanel ID="UpdatePanelBookUpload" runat="server">
										<ContentTemplate>
											<ul id="BookUploadUL">
												<li>
													<asp:Label runat="server" ID="lbl_FileUploadCoverPage" Text="Cover Page Picture (jpg/png):" Font-Bold="true" />

													<asp:FileUpload runat="server" ID="fileUpload_BookCoverPage" CssClass="FileUploadClass" />

													<asp:Button ID="btn_UploadBookCoverPage" runat="server" Text="Upload Cover Page Image" OnClick="btnUpload_BookCoverPage_Click" CausesValidation="true" CssClass="btn btn-primary btn-xs" />
												</li>


												<li>
													<asp:Label runat="server" ID="lbl_FileUploadSoftCopy" Text="Soft Copy (pdf/doc) of the Book:" Font-Bold="true" />

													<asp:FileUpload runat="server" ID="fileUpload_SoftCopy" CssClass="FileUploadClass" />
													<asp:Button ID="btn_UploadBookSoftCopy" runat="server" Text="Upload Soft Copy File" OnClick="btnUpload_BookCoverPage_Click" CausesValidation="true" CssClass="btn btn-primary btn-xs" />
												</li>
											</ul>
										</ContentTemplate>
										<Triggers>
											<asp:PostBackTrigger ControlID="btn_UploadBookCoverPage" />
											<asp:PostBackTrigger ControlID="btn_UploadBookSoftCopy" />
										</Triggers>
									</asp:UpdatePanel>
								</li>
								<li class="FormValue" style="width: 100%; text-align: center;"></li>
							</ul>
						</asp:Panel>
					</li>
					<%--View Book--%>
					<li>
						<asp:Panel runat="server" ID="panel_ViewBook">
							<ul>
								<li>
									<asp:Button ID="btn_AddNewBook" runat="server" Text="Add New Book" CausesValidation="false" OnClick="ButtonAddNewBook_Click" class="btn btn-primary btn-xs" />
									<asp:Button ID="btn_Refresh" runat="server" Text="Refresh" CausesValidation="false" OnClick="btn_Refresh_Click" class="btn btn-primary btn-xs" />
								</li>
								<li>
									<uc:UC_Search ID="ctrl_Search" runat="server" SearchLabel="Search:- " SearchResultCount="" SearchWhat="Books" />
								</li>
								<li>

									<asp:GridView
										runat="server"
										ID="gview_Books"
										AutoGenerateColumns="false"
										AllowPaging="true"
										AllowSorting="true"
										PageSize="50"
										Width="100%"
										CssClass="GridView"
										GridLines="Horizontal"
										CellPadding="2"
										OnPageIndexChanging="gview_Books_PageIndexChanging"
										OnRowCommand="gview_Books_RowCommand"
										OnRowDeleting="gview_Books_RowDeleting"
										OnRowEditing="gview_Books_RowEditing">
										<HeaderStyle CssClass="HeaderStyle" />
										<PagerStyle CssClass="MicroPagerStyle" />
										<RowStyle CssClass="GridRowStyle" />
										<AlternatingRowStyle CssClass="GridAlternatRowStyle" />
										<Columns>

											<asp:TemplateField Visible="false">
												<ItemTemplate>
													<asp:Label runat="server" ID="lbl_BookID" Text='<%# Eval("BookID") %>' />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:BoundField DataField="AccessionNo" HeaderText="ACCN" ItemStyle-Width="5%" />
											<asp:CommandField ShowEditButton="true" HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Themes/Default/Images/GRID_EDIT.ico" ControlStyle-CssClass="EditLink" ItemStyle-CssClass="EditLinkItem">
												<ControlStyle CssClass="EditLink" />
												<ItemStyle CssClass="EditLinkItem" />
											</asp:CommandField>
											<asp:BoundField DataField="Title" HeaderText="Book Title:" ItemStyle-Width="26%" ControlStyle-CssClass="Title" />
											<asp:BoundField DataField="BookType" HeaderText="Type:" ItemStyle-Width="4%" ControlStyle-CssClass="Type" />
											<asp:BoundField DataField="SegmentName" HeaderText="Segment:" ItemStyle-Width="8%" ControlStyle-CssClass="Segment" />
											<asp:BoundField DataField="CategoryName" HeaderText="Category:" ItemStyle-Width="16%" ControlStyle-CssClass="Category" />
											<asp:BoundField DataField="AuthorName" HeaderText="Author:" ItemStyle-Width="15%" ControlStyle-CssClass="Author" />
											<asp:BoundField DataField="PublisherName" HeaderText="Publisher:" ItemStyle-Width="15%" ControlStyle-CssClass="Publisher" />
											<asp:CommandField ShowDeleteButton="True" HeaderText="D" ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
												<ControlStyle CssClass="DeleteLink" />
												<ItemStyle CssClass="DeleteLinkItem" />
											</asp:CommandField>

										</Columns>
										<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
									</asp:GridView>
								</li>
							</ul>
						</asp:Panel>
					</li>
				</ul>


				<%--New Author/Publisher/Supplier--%>
				<%--<asp:Panel runat="server" ID="panel_NewBook">--%>
				<ul id="NewMasterRecordUL">
					<li>
						<asp:RadioButtonList runat="server" ID="rbList_type" RepeatDirection="Horizontal" AutoPostBack="false" Visible="true" Enabled="true">
							<asp:ListItem Value="A" Selected="True">Author&nbsp;&nbsp;&nbsp;</asp:ListItem>
							<asp:ListItem Value="P">Publisher&nbsp;&nbsp;&nbsp;</asp:ListItem>
							<asp:ListItem Value="S">Supplier&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
							<asp:ListItem Value="C">Category</asp:ListItem>
							<asp:ListItem Value="T">Segment</asp:ListItem>
						</asp:RadioButtonList>
						<asp:Label runat="server" ID="lbl_LabelTitle" Text="Enter Author Name:" Font-Bold="true" />
						<asp:TextBox runat="server" ID="txt_NewText" TextMode="SingleLine" MaxLength="200" />
						<asp:Button runat="server" ID="btn_SaveNewRecord" OnClick="btn_SaveNewRecord_Click" Text="Save New Record" CausesValidation="false" CssClass="btn btn-primary btn-xs" />
						<asp:Button runat="server" ID="btn_ResetClose" OnClick="btn_ResetClose_Click" Text="Cancel" CausesValidation="false" CssClass="btn btn-primary btn-xs" />

					</li>
				</ul>
				<%--</asp:Panel>--%>
			</div>

			<asp:UpdateProgress runat="server" ID="PageUpdateProgress">
				<ProgressTemplate>
					<div id="UpdateProgressBooks">
						<div class="UpdateProgressArea">
							<ul id="UpdateProgressUL">
								<li>
									<h1 class="PageTitle">Please wait a while...</h1>
									<asp:Literal runat="server" ID="lit_ProcessingMessage" Text="Processing...the request..." />
								</li>
							</ul>

						</div>
					</div>
				</ProgressTemplate>
			</asp:UpdateProgress>

			<IAControl:DialogBox ID="dialog_Message"
				runat="server" Title="Message:"
				BackgroundCssClass="modalBackground"
				Style="display: none;" Height="100" Width="400"
				CssClass="modalPopup" EnableViewState="true">
				<ItemTemplate>
					<ul id="DialogBoxUL">
						<li>
							<asp:Literal ID="lit_DialogMessage" runat="server" Text="x"></asp:Literal>
						</li>
					</ul>
				</ItemTemplate>
			</IAControl:DialogBox>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
