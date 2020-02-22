<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LibraryBookSearch.ascx.cs" Inherits="TCon.iCAS.WebApplication.App_UserControls.Library.UC_LibraryBookSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<style type="text/css">
	#LibraryBookSearchUL
	{
		list-style-type: none;
		display: block;
		float: left;
		margin: 0px;
		padding: 0px;
		min-height: 250px;
		margin: 5px 0px 0px 0px;
		padding: 0px;
		width: 100%;
		background-image: url(images/slides_tsdc/slide_2017_3.jpg);
		background-position-x: -668px;
	}



	#ctrl_LibraryBookSearch_dgrid_Books > tbody > tr > td
	{
		font-size: 0.9em;
	}

	 

	.bgtableheader
	{
		background-color: #e7f3ff;
		filter: progid:dximagetransform.microsoft.gradient(enabled='true',startcolorstr=#f9fcff, endcolorstr=#d7eeff);
		font-family: Arial;
		font-size: 1em;
	}


	.GridView table
	{
		background-color: floralwhite;
	}

	.PageTitleLibrary
	{
		font-size: 0.9em;
		font-weight: bold;
		margin-left: 0px;
		padding-left: 2px;

	}
</style>


<script lang="JavaScript">
	ie4 = (document.all) ? true : false;
	//alert(ie4);
	var x = 0;
	var y = 0;
	var snow = 0;
	var sw = 0;
	var cnt = 0;
	var dir = 1;
	var tr = 0;
	if (ie4) {
		if (ie4) over = overDiv.style
		document.onmousemove = mouseMove;
	}
	document.onmousemove = mouseMove;

	function drc(text) {
		txt = text + "&nbsp;&nbsp;";
		layerWrite(txt);
		dir = 1;
		disp();
	}
	function drc2(text) {
		txt = text + "&nbsp;&nbsp;";
		layerWrite(txt);
		dir = 2;
		disp();
	}
	function nd() {
		if (cnt >= 1) { sw = 0 };
		if (ie4) {
			if (sw == 0) {
				snow = 0;
				hideObject(over);
			} else {
				cnt++;
			}
		}
	}

	function disp() {
		if (ie4) {
			if (snow == 0) {
				if (dir == 1) { // Right
					moveTo(over, event.x + document.body.scrollLeft + 5, event.y + document.body.scrollTop);
				}
				else {
					moveTo(over, event.x + document.body.scrollLeft - 130, event.y + document.body.scrollTop);
				}

				showObject(over);
				snow = 1;
			}
		}
	}

	function mouseMove(e) {
		if (snow) {
			if (dir == 1) { // Right
				moveTo(over, event.x + document.body.scrollLeft + 5, event.y + document.body.scrollTop);
			}
		}
	}

	function cClick() {
		hideObject(over);
		sw = 0;
	}

	function layerWrite(txt) {
		var div1 = document.getElementById('overDiv');
		div1.innerHTML = '';
		var table1 = document.createElement('table');
		var Tbody1 = document.createElement('tbody');
		table1.setAttribute('className', 'LeftMenu_select');
		var Row1 = document.createElement('tr');
		var Cell = document.createElement('td');
		Cell.innerHTML = txt;
		Row1.appendChild(Cell);
		Tbody1.appendChild(Row1);
		table1.appendChild(Tbody1);
		div1.appendChild(table1);
		if (tr) { trk(); }
	}

	function showObject(obj) {
		obj.visibility = 'visible'
	}

	function hideObject(obj) {
		obj.visibility = 'hidden'
	}

	function moveTo(obj, xL, yL) {
		obj.left = xL
		obj.top = yL
	}

	function trk() {
		tr = 0;
	}
	// -->
</script>
<div id="overDiv" style="z-index: 10; position: absolute; background-color: whitesmoke; color: navy; border: solid 1px #ccc; display: none;">
	&nbsp;---
</div>
<ul id="LibraryBookSearchUL">
	<li>
		<asp:Label runat="server" ID="lbl_Title" Text="College Library: " CssClass="PageTitleLibrary" />
		<asp:TextBox runat="server" ID="txt_SearchText" Width="56%" CausesValidation="false" />
		<ajax:TextBoxWatermarkExtender
			ID="watermark_SearchText"
			TargetControlID="txt_SearchText"
			WatermarkText="Type here few alphabets to search"
			WatermarkCssClass="WatermarkCss" runat="server" />
		<asp:Button runat="server" ID="btnGoSearch" Text="Go" OnClick="btnGoSearch_Click" CssClass="btn btn-success btn-xs" Width="10%" CausesValidation="false" />
		<asp:Literal runat="server" ID="lit_RecordCount" Text="4112 Books found" Visible="false" />
	</li>
	<li>
	</li>
	<li class="GridView">
		<asp:DataGrid ID="dgrid_Books" runat="server" AutoGenerateColumns="False" GridLines="None" Width="100%" PageSize="13" OnPageIndexChanged="dgrid_Books_PageIndexChanged"
			OnItemCommand="dataGrid_Books_ItemCommand"
			OnItemDataBound="dgrid_Books_ItemDataBound">
			<HeaderStyle Font-Bold="True" HorizontalAlign="Left" Height="15px" CssClass="bgtableheader"></HeaderStyle>
			<Columns>
				<asp:BoundColumn Visible="False" DataField="BookID">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:ButtonColumn DataTextField="AccessionNo" HeaderText="ACC.No." CommandName="CmdAccessionNo">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				</asp:ButtonColumn>
				<asp:BoundColumn DataField="TITLE" HeaderText="Book Title:">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn DataField="ISBOOKISSUED" HeaderText="CanBorrow?" Visible="False">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn Visible="True" DataField="AuthorName" HeaderText="Author:">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn Visible="False" DataField="PublisherName">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn Visible="False" DataField="SegmentName">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn DataField="CategoryName" SortExpression="STATE ASC" HeaderText="" Visible="False">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn Visible="False" DataField="IssuedToUserName">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:TemplateColumn>
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
					<ItemTemplate>
						<asp:LinkButton runat="server" Text="Issue" CommandName="IssueBook" CausesValidation="false" ID="LinkbuttonIssueBook" NAME="LinkbuttonIssueBook" Visible="true">
							<img border="0" src="../../../images/glossary/ViewDetails.gif" />
						</asp:LinkButton>
					</ItemTemplate>
				</asp:TemplateColumn>
			</Columns>
		</asp:DataGrid>
		<%--		<asp:DataGrid ID="dgrid_Books" runat="server" AutoGenerateColumns="False" GridLines="None" Width="100%">
			<HeaderStyle Font-Bold="True" HorizontalAlign="Left" Height="15px" CssClass="bgtableheader"></HeaderStyle>
			<Columns>
				<asp:BoundColumn Visible="False" DataField="CLIENTPARTNERID">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:ButtonColumn DataTextField="PARTNERCODE" HeaderText="Partner Code" CommandName="CmdPartnerInformation">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:ButtonColumn>
				<asp:BoundColumn DataField="PARTNERNAME" HeaderText="Partner Name">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn DataField="COUNTRY_NAME" HeaderText="Country(State)">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn DataField="TOWN" HeaderText="Town">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn DataField="STATUS" HeaderText="Status">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:TemplateColumn>
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
					<ItemTemplate>
						<asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" ID="Linkbutton1" NAME="Linkbutton1" Visible="False"><img border="0" src="../../../_images/icon_delete.gif" ></asp:LinkButton>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:BoundColumn Visible="False" DataField="ADDRESS1">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn Visible="False" DataField="ADDRESS2">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn Visible="False" DataField="ADDRESS3">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn DataField="STATE" SortExpression="STATE ASC" HeaderText="" Visible="False">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn DataField="COUNTRY" SortExpression="COUNTRY ASC" HeaderText="" Visible="False">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
				<asp:BoundColumn Visible="False" DataField="POSTALCODE">
					<HeaderStyle ForeColor="#42729A" CssClass="bgTableHeader"></HeaderStyle>
				</asp:BoundColumn>
			</Columns>
		</asp:DataGrid>--%>
	</li>
	<li>
		<asp:GridView runat="server" ID="gview_Books" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false" CssClass="GridViewBookSearch" Visible="false">
			<HeaderStyle CssClass="GridViewBookSearchHeaderStyle" />
			<RowStyle CssClass="GridViewBookSearchRowStyle" />
			<AlternatingRowStyle CssClass="GridViewBookSearchAlternatRowStyle" />
			<Columns>
				<asp:BoundField DataField="BookID" HeaderText="ID" Visible="false" />
				<asp:BoundField DataField="AccessionNo" HeaderText="ACCN#" ItemStyle-Width="10%" ItemStyle-CssClass="AccessionNo" />
				<asp:HyperLinkField
					DataNavigateUrlFields="BookID"
					DataNavigateUrlFormatString="~/Library/Books.aspx?ID={0}"
					DataTextField="Title"
					HeaderText="Book Title:"
					ItemStyle-Width="45%"
					ItemStyle-CssClass="TitleClass" />
				<asp:BoundField DataField="AuthorName" HeaderText="Author:" ItemStyle-Width="40%" ItemStyle-CssClass="Author" />
				<asp:BoundField DataField="IsBookIssued" HeaderText="ISSUED?" ItemStyle-Width="5%" ItemStyle-CssClass="IsBookIssued" />

			</Columns>
		</asp:GridView>
	</li>
</ul>


<IAControl:DialogBox ID="dialog_Message"
	runat="server" Title="Library Book Details:"
	BackgroundCssClass="modalBackground"
	Style="display: none;"
	CssClass="modalPopupEstablishment" EnableViewState="true">
	<ItemTemplate>
		<ul>
			<li>
				<asp:Literal ID="lit_TheMessage" runat="server" Text=""></asp:Literal>
			</li>
		</ul>
	</ItemTemplate>
</IAControl:DialogBox>

<%--<asp:UpdateProgress runat="server" ID="PageUpdateProgress">
	<ProgressTemplate>
		<div id="UpdateProgress">
			<div class="UpdateProgressArea">
				<ul id="UpdateProgressLibraryControl">
					<li>
						Serching book(s) in Library...Please wait a moment! 
					</li>
				</ul>
			</div>
		</div>
	</ProgressTemplate>--%>
</asp:UpdateProgress>
