<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="TCon.iCAS.WebApplication.Library.Transactions" %>

<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="../App_UserControls/UC_Search.ascx" TagName="UC_Search" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
		ul#LibraryTransaction
		{
			width: 100%;
			margin: 0;
			padding: 0;
			display: block;
			float: left;
		}

			ul#LibraryTransaction li
			{
				display: block;
				float: left;
				width: 100%;
				margin: 0;
				padding: 0;
				border-bottom: solid 1px cyan;
			}

		#ContentPlaceHolder1_rbList_TransactionType,
		#ContentPlaceHolder1_rbList_TransactionType > tbody,
		#ContentPlaceHolder1_rbList_TransactionType > tbody > tr
		{
			display: block;
			float: left;
			width: 100%;
			background-color: cyan;
		}

			#ContentPlaceHolder1_rbList_TransactionType > tbody > tr > td
			{
				display: block;
				float: left;
				width: 25%;
				text-align: center;
			}


		#ContentPlaceHolder1_rbList_UserType,
		#ContentPlaceHolder1_rbList_UserType > tbody,
		#ContentPlaceHolder1_rbList_UserType > tbody > tr
		{
			display: block;
			float: left;
			width: 100%;
			background-color: lightcyan;
		}

			#ContentPlaceHolder1_rbList_UserType > tbody > tr > td
			{
				display: block;
				float: left;
				width: 50%;
				text-align: center;
			}

		.BooksDropdown
		{
			display: block;
			float: left;
			width: 100%;
			padding: 1px;
			margin: 1px 1px 1px 5px;
			font-size: 1.1em;
			font-family: monospace;
			border: solid 1px darkcyan;
		}

			.BooksDropdown > option
			{
				color: darkgreen;
				font-family: monospace;
				font-size: 1em;
			}

		.UserDropdown
		{
			display: block;
			float: left;
			width: 100%;
			padding: 1px;
			margin: 1px;
			font-size: 1.1em;
			font-family: monospace;
			border: solid 1px darkcyan;
		}

		#ContentPlaceHolder1_ddl_TransactionToFromUser > option
		{
			color: navy;
			font-family: monospace;
			font-size: 1.1em;
		}

		.RequiredField
		{
			color: red;
		}

		#ContentPlaceHolder1_ddl_TransactionToFromUser > option
		{
			font-size: 1em;
			font-family: monospace;
		}

		#UpdateProgressArea
		{
			display: block;
			float: left;
			width: 100%;
			height: 17px;
			background-color: red;
			color: white;
		}

		#UpdateProgressAreaBooksLoading
		{
			display: block;
			float: left;
			width: 100%;
			height: 17px;
			background-color: red;
			color: white;
		}

		.GridViewClass
		{
			width: 100%;
			border: solid 1px red;
		}



		#LibraryTransaction > li.PageSubTitle > ul > li:nth-child(1) > div.GeneralDialogBox
		{
			background-image: url(../images/ArrowRightRed.gif);
			background-repeat: no-repeat;
			background-position: left 10px top 5px;
			color: navy;
			padding: 1px 10px 0 16px;
			position: absolute;
			left: 100px;
			text-align: center;
			width: 25%;
			margin-left: 50%;
			font-size: 1.3em;
		}
	</style>

	<asp:UpdatePanel runat="server" ID="updatePanel_Account">
		<ContentTemplate>
			<h1 class="PageTitle">
				<asp:Literal runat="server" ID="Literal1" Text="Library Book Transaction:" />
			</h1>
			<div>
				<asp:RadioButtonList runat="server" ID="rbList_TransactionType" RepeatDirection="Horizontal" AutoPostBack="true" CssClass="TranTypeClass" OnSelectedIndexChanged="rbList_TransactionType_SelectedIndexChanged">
					<asp:ListItem Text="ISSUE A BOOK" Value="ISSUE" />
					<asp:ListItem Text="RECEIVE A BOOK" Value="RECEIVE" />
					<asp:ListItem Text="MISSING BOOK" Value="MISSING" />
					<asp:ListItem Text="DAMAGED BOOK" Value="DAMAGED" />
				</asp:RadioButtonList>
				<asp:RadioButtonList runat="server" ID="rbList_UserType" RepeatDirection="Horizontal" AutoPostBack="true" CssClass="TranTypeClass" OnSelectedIndexChanged="rbList_UserType_SelectedIndexChanged">
					<asp:ListItem Text="STUDENT" Value="STUDENT" Selected="True" />
					<asp:ListItem Text="STAFF" Value="STAFF" />
				</asp:RadioButtonList>
			</div>
			<div class="innercontent">
				<ul id="LibraryTransaction">
					<li class="PageSubTitle">
						<ul>
							<li>
								<asp:Literal runat="server" ID="lit_PageTitle" Text="ISSUE A BOOK TO STUDENT" />
							</li>
							<li>
								<asp:Label runat="server" ID="Label1" Text="Transaction Date:"></asp:Label>
								<asp:TextBox runat="server" ID="txt_TransactionDate" Width="17%" CssClass="AccesionDateStyle" />
								<asp:ImageButton runat="server" ID="imgbtn_Startdate" CausesValidation="true" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
								<ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_TranDate" PopupButtonID="imgbtn_Trandate" CssClass="MicroCalendar" TargetControlID="txt_TransactionDate"></ajax:CalendarExtender>
								<%--<asp:RegularExpressionValidator runat="server" ID="regularExpressionValidator_TransactionDate" ControlToValidate="txt_TransactionDate" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Transaction Date Please!" CssClass="RequiredField" />--%>
							</li>
						</ul>
					</li>
					<li>
						<asp:DropDownList runat="server" ID="ddl_TransactionToFromUser" AutoPostBack="true" CssClass="UserDropdown" OnSelectedIndexChanged="ddl_TransactionToFromUser_SelectedIndexChanged" />
					</li>
					<li>
						<asp:Label runat="server" ID="Label2" Text="Book:"></asp:Label>
						<asp:UpdateProgress runat="server" ID="tranPageUpdateProgress">
							<ProgressTemplate>
								<div id="UpdateProgressBooksLoading">
									<div class="UpdateProgressAreaBooksLoading">
										Processing...Please wait a while
									</div>
								</div>
							</ProgressTemplate>
						</asp:UpdateProgress>
						<asp:DropDownList runat="server" ID="ddl_Books" AutoPostBack="false" CssClass="BooksDropdown" OnSelectedIndexChanged="ddl_Books_SelectedIndexChanged" />
					</li>
					<li>
						<asp:Button
							runat="server" ID="btn_Add2List"
							OnClick="btn_Add2List_Click"
							Text="Add to Transaction List"
							CausesValidation="false"
							CssClass="btn FormButton" />
					</li>
					<li class="GridView">
						<asp:GridView runat="server" ID="gview_Books4Transaction" AutoGenerateColumns="false" CssClass="GridViewClass">
							<Columns>
								<asp:BoundField DataField="TitleAccessionNo" HeaderText="Title (AccesionNo)" ItemStyle-CssClass="AccessionNoClass" />
								<asp:BoundField DataField="ExpetedReturnDate" DataFormatString="{0:D}" HeaderText="Expeted Return Date" ItemStyle-CssClass="ExpetedReturnDateClass" />
								<asp:BoundField DataField="ActualReturnDate" DataFormatString="{0:D}" HeaderText="Actual Return Date" ItemStyle-CssClass="ActualReturnDateClass" />
								<asp:BoundField DataField="FineAmount" HeaderText="Fine" DataFormatString="{0:C}" ItemStyle-CssClass="FineAmountClass" />
								<asp:ButtonField ButtonType="Link" CommandName="Delete" Text="Delete" ItemStyle-CssClass="DeleteClass" />
							</Columns>
						</asp:GridView>
					</li>
					<li class="FormButton_Top">
						<asp:Button runat="server" ID="btn_Save" OnClick="btn_Save_Click" Text="Save Transaction" CausesValidation="false" CssClass="btn btn-success" />
						<asp:Button runat="server" ID="btn_View" OnClick="btn_View_Click" Text="View" CausesValidation="false" CssClass="btn btn-success" Visible="false" />
						<asp:Button runat="server" ID="btn_Cancel" OnClick="btn_Cancel_Click" Text="Cancel" CausesValidation="false" CssClass="btn btn-success" />
					</li>
					<li>
						<asp:Label runat="server" ID="lbl_MessageOperation" />
					</li>
				</ul>
				<ul id="TranPageBody" style="display: none;">
					<li>
						<asp:MultiView runat="server" ID="mview_Transactions" ActiveViewIndex="0">
							<%--ISSUE--%>
							<asp:View runat="server" ID="vu_Issue" OnInit="vu_Issue_Init">
								<h1 class="PageSubTitle">ISSUE:</h1>
							</asp:View>
							<%--RETURN--%>
							<asp:View runat="server" ID="vu_Return" OnInit="vu_Return_Init">
								<h1 class="PageSubTitle">RETURN:</h1>
							</asp:View>
							<%--RETURN--%>
							<asp:View runat="server" ID="vu_Missing" OnInit="vu_Return_Init">
								<h1 class="PageSubTitle">MISSING:</h1>
							</asp:View>
							<%--RETURN--%>
							<asp:View runat="server" ID="vu_Damaged" OnInit="vu_Return_Init">
								<h1 class="PageSubTitle">DAMAGED:</h1>
							</asp:View>
							<%--View--%>
							<asp:View runat="server" ID="vu_View" OnInit="vu_Return_Init">
								<h1 class="PageSubTitle">View Transactions:</h1>
								<asp:GridView
									runat="server"
									ID="gview_Transactions"
									AutoGenerateColumns="false"
									AllowPaging="true"
									AllowSorting="true"
									PageSize="13"
									Width="100%"
									CssClass="GridView"
									GridLines="Horizontal"
									CellPadding="2"
									OnPageIndexChanging="gview_Transactions_PageIndexChanging"
									OnRowCommand="gview_Transactions_RowCommand"
									OnRowDeleting="gview_Transactions_RowDeleting"
									OnRowEditing="gview_Transactions_RowEditing">
									<HeaderStyle CssClass="HeaderStyle" />
									<PagerStyle CssClass="MicroPagerStyle" />
									<RowStyle CssClass="GridRowStyle" />
									<AlternatingRowStyle CssClass="GridAlternatRowStyle" />
									<Columns>
										<asp:TemplateField Visible="true">
											<ItemTemplate>
												<asp:Label runat="server" ID="lbl_TransactionID" Text='<%# Eval("TransactionID") %>' />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:BoundField DataField="TransactionTypeDesc" HeaderText="Type:" ItemStyle-Width="20%" />
										<asp:BoundField DataField="Issued2UserTypeDesc" HeaderText="User Type" ItemStyle-Width="30%" />
										<asp:BoundField DataField="Issued2UserFullName" HeaderText="Name:" ItemStyle-Width="15%" />
										<asp:BoundField DataField="Title" HeaderText="Book:" ItemStyle-Width="15%" />
										<asp:BoundField DataField="AccessionNo" HeaderText="ACCN" ItemStyle-Width="5%" />
										<asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ButtonType="Image" DeleteImageUrl="~/Themes/Default/Images/GRID_DELETE.ico" ControlStyle-CssClass="DeleteLink" ItemStyle-CssClass="DeleteLinkItem">
											<ControlStyle CssClass="DeleteLink" />
											<ItemStyle CssClass="DeleteLinkItem" />
										</asp:CommandField>
										<asp:CommandField ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem">
											<ControlStyle CssClass="ViewLink" />
											<ItemStyle CssClass="ViewLinkItem" />
										</asp:CommandField>
									</Columns>
									<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />

								</asp:GridView>
							</asp:View>
						</asp:MultiView>
					</li>
				</ul>
			</div>
			<IAControl:DialogBox ID="dialog_Message" runat="server" Title="Message:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopup" EnableViewState="true">
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

