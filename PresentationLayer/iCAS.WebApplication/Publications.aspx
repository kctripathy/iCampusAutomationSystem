<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="Publications.aspx.cs" Inherits="Micro.WebApplication.Publications" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<asp:UpdatePanel ID="UpdatePanel_Establishment" runat="server" UpdateMode="Conditional">

		<ContentTemplate>

			<div class="innercontent">
				<h1 class="PageTitle">
					<asp:Literal runat="server" ID="lit_PageTitle" Text="Publications:-" />

				</h1>
				<div class="OptionsStyle">

					<asp:CheckBoxList ID="chkBoxList_EstbType" runat="server"
						RepeatDirection="Horizontal"
						RepeatColumns="9"
						OnSelectedIndexChanged="chkBoxList_EstbType_SelectedIndexChanged"
						AutoPostBack="true">
						<asp:ListItem Value="1" Selected="False"> Articles&nbsp;</asp:ListItem>
						<asp:ListItem Value="2">Research Paper&nbsp;</asp:ListItem>
						<asp:ListItem Value="3" Selected="True">Books&nbsp;</asp:ListItem>
						<asp:ListItem Value="4">Achievments&nbsp;&nbsp;</asp:ListItem>
						<asp:ListItem Value="5">Seminar Papers&nbsp;&nbsp; </asp:ListItem>
						<asp:ListItem Value="6" Selected="True">Study Materials&nbsp;&nbsp;</asp:ListItem>
						<asp:ListItem Value="7">Literatures&nbsp;&nbsp;</asp:ListItem>
						<asp:ListItem Value="8">Staff Profile&nbsp;&nbsp;</asp:ListItem>
						<asp:ListItem Value="A">Show me All</asp:ListItem>
					</asp:CheckBoxList>
				</div>

				<asp:MultiView ID="Establishment_multi" runat="server">
					<asp:View ID="InputControls" runat="server">
						<ul id="UploadStyleUL">
							<li class="FormButton_Top">
								<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save" />
								<asp:Button ID="btn_view" runat="server" Text="View" OnClick="btn_view_Click" CausesValidation="false" />
							</li>
							<li class="Formlabel">&nbsp;</li>
							<li class="Formvalue">&nbsp;<asp:Label runat="server" ID="lblMessage" Text="Please specify the type:" /></li>
							<div style="display: block; border: solid 1px #ccc; margin: 0px 0px 20px 0px; font-size: 10px;">
								<li class="Formlabel">
									<asp:Label ID="lbl_MessageType" runat="server" Text="" />
								</li>
								<li class="Formvalue">
									<asp:RadioButtonList ID="rbl_EstablishmentTypeCode" runat="server" RepeatDirection="Vertical">
										<asp:ListItem Value="P" Selected="True">Published Articles(P)</asp:ListItem>
										<asp:ListItem Value="R">Publications or Research Project Paper (R)</asp:ListItem>
										<asp:ListItem Value="B">Books /Proceedings/ Study Materials(B)</asp:ListItem>
										<asp:ListItem Value="C">Awards/Rewards(C) </asp:ListItem>
										<asp:ListItem Value="N">Seminar Papers (D)</asp:ListItem>
										<asp:ListItem Value="A">All Artifacts</asp:ListItem>
									</asp:RadioButtonList>
									<asp:RequiredFieldValidator ID="requiredFieldValidator_EstablishmentTypeCode" runat="server" ControlToValidate="rbl_EstablishmentTypeCode" Display="Dynamic" SetFocusOnError="true" />
								</li>
							</div>


							<li class="Formlabel">
								<span class="RequiredField">*</span>
								<asp:Label ID="lbl_NoticeTitle" runat="server" Text="Please Enter here Title/Subject: " />
							</li>
							<li class="Formvalue">
								<asp:TextBox ID="txt_NoticeTitle" runat="server" Width="98%" />
								<ajax:TextBoxWatermarkExtender runat="server" ID="watermark_NoticeTitleWater" TargetControlID="txt_NoticeTitle" WatermarkText="Title of the Article/Thesis/etc." WatermarkCssClass="" />
								<asp:RequiredFieldValidator ID="req_NoticeTitle" runat="server" ControlToValidate="txt_NoticeTitle" ErrorMessage="*" ForeColor="Red" Text="* Please enter!" SetFocusOnError="true" />
							</li>

							<li class="Formlabel">
								<span class="RequiredField">*</span>
								<asp:Label ID="lbl_Startdate" runat="server" Text="Publication Date:" />
							</li>
							<li class="Formvalue">
								<asp:TextBox ID="txt_Startdate" runat="server" AutoPostBack="false" />
								<asp:ImageButton runat="server" ID="imgbtn_Startdate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
								<ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_Startdate" PopupButtonID="imgbtn_Startdate" CssClass="MicroCalendar" TargetControlID="txt_Startdate">
								</ajax:CalendarExtender>
								<asp:RequiredFieldValidator ID="requiredFieldValidator_Startdate" runat="server" ControlToValidate="txt_Startdate" SetFocusOnError="true" ErrorMessage="*" ForeColor="Red" Text="It can't be left empty!" />
							</li>

							<li class="Formlabel">
								<span class="RequiredField">*</span>
								<asp:Label ID="lbl_Enddate" runat="server" Text="Display This in webpage Till Date:" />
							</li>
							<li class="Formvalue">
								<asp:TextBox ID="txt_Enddate" runat="server" AutoPostBack="false" />
								<asp:ImageButton runat="server" ID="imgbtn_Enddate" CausesValidation="false" ToolTip="Show Calender" ImageAlign="AbsMiddle" ImageUrl="~/Themes/Default/Images/Calander 01.gif" Height="21" Width="21" />
								<ajax:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="clndrextender_Enddate" PopupButtonID="imgbtn_Enddate" CssClass="MicroCalendar" TargetControlID="txt_Enddate" />

								<asp:RequiredFieldValidator ID="requiredFieldValidator_Enddate" runat="server" ControlToValidate="txt_Enddate" SetFocusOnError="true" ErrorMessage="*" ForeColor="Red" Text="It can't be left empty!" />

							</li>

							<li class="Formlabel">
								<span class="RequiredField">*</span>
								<asp:Label ID="lbl_Description" runat="server" Text="Brief Description (max 200 alphabets) Please:" />
							</li>
							<li class="Formvalue">
								<asp:TextBox ID="txt_Description" runat="server" Height="125px" Width="100%" TextMode="MultiLine" MaxLength="200" /><br />
								<ajax:TextBoxWatermarkExtender runat="server" ID="TextBoxWatermarkExtender_txt_Description" TargetControlID="txt_Description" WatermarkText="Enter Detail Description of the Notice/ Tender/ Circular/ Recent Activities Here" WatermarkCssClass="" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator_Description" runat="server" ControlToValidate="txt_Description" ErrorMessage="*" ForeColor="Red" Text="Please enter the establishment description! it can't left blank." />
							</li>

							<div style="display: block; border-top: solid 1px #808080; margin: 10px 0px 40px 0px; font-size: 15px;">


								<li class="Formlabel">
									<asp:Label ID="Label1" runat="server" Text="Select the File to Upload (only pdf / word files):" />
								</li>
								<li class="Formvalue">
									<asp:UpdatePanel ID="UpdatePanel1" runat="server">
										<ContentTemplate>
											<asp:FileUpload runat="server" ID="fileUploadEstb" Width="80%" Height="30px" BorderStyle="Solid" BorderWidth="1" BorderColor="LightGray" />

											<asp:Button ID="btnUpload" runat="server" Text=" Upload Now" OnClick="Upload_File" CausesValidation="true" />
											<br />
											<asp:Label runat="server" ID="lbl_FileUploadStatus" ForeColor="Red" Text="File uploaded successfully. please save/update the record now" Visible="false" />

										</ContentTemplate>
										<Triggers>
											<asp:PostBackTrigger ControlID="btnUpload" />
										</Triggers>
									</asp:UpdatePanel>
								</li>
							</div>
						</ul>
					</asp:View>

					<asp:View ID="view_gridView" runat="server">
						<ul>
							<li class="FormButton_Top">
								<asp:Button ID="btn_AddNew" runat="server" Text="Add New" OnClick="btn_AddNew_Click" />
							</li>
							<li class="GridView">
								<asp:GridView ID="gridview_Establishment"
									runat="server"
									AllowPaging="True"
									AllowSorting="True"
									PageSize="200"
									AutoGenerateColumns="False"
									RowStyle-CssClass="RowStyleCss"
									OnRowCommand="gridview_Establishment_RowCommand">

									<AlternatingRowStyle CssClass="AlternatingRowStyle" />
									<RowStyle CssClass="RowStyle" />
									<HeaderStyle CssClass="HeaderStyle" />

									<Columns>

										<asp:TemplateField ItemStyle-CssClass="StudentId" Visible="false">
											<ItemTemplate>
												<asp:Label runat="server" ID="lbl_EstbID" Text='<%# Eval("EstbID") %>' Visible="false" />
											</ItemTemplate>
										</asp:TemplateField>

										<asp:BoundField DataField="EstbID" HeaderText="EstablishmentId" Visible="false" />
										<asp:BoundField DataField="EstbTypeCodeDesc" HeaderText="Type" HeaderStyle-Width="10%" />
										<asp:HyperLinkField
											DataNavigateUrlFields="AddedBy"
											DataNavigateUrlFormatString="~/icas/staffs.aspx?Page=View&ID={0}"
											DataTextField="AuthorOrContributorName"
											HeaderText="Author/Contributor's Name"
											HeaderStyle-Width="20%" />
										<asp:BoundField DataField="EstbTitle" HeaderText="Tittle/Subject:" HeaderStyle-Width="50%" />
										<%--<asp:BoundField DataField="EstbViewStartDate" HeaderText="Date:" DataFormatString="{0:dd/MMM/yyyy}" />--%>

										<asp:CommandField SelectText="SHOW_RECORD" ShowSelectButton="True" HeaderText="View" ButtonType="Image" SelectImageUrl="~/Themes/Default/Images/GRID_SELECT.ico" ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem" HeaderStyle-Width="5%">
											<ControlStyle CssClass="ViewLink" />
											<ItemStyle CssClass="ViewLinkItem" />
										</asp:CommandField>
										<%--<asp:CommandField SelectText="DOWNLOAD" ShowSelectButton="True" HeaderText="-" ButtonType="Image" SelectImageUrl="~/Images/pdf.gif" ControlStyle-CssClass="ViewLink" ItemStyle-CssClass="ViewLinkItem" HeaderStyle-Width="5%">
                                            <ControlStyle CssClass="ViewLink" />
                                            <ItemStyle CssClass="ViewLinkItem" />
                                        </asp:CommandField>--%>
									</Columns>
									<PagerSettings Position="TopAndBottom" FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
									<PagerStyle CssClass="MicroPagerStyle" />
								</asp:GridView>

							</li>

						</ul>
					</asp:View>
				</asp:MultiView>
			</div>


			<IAControl:DialogBox ID="dialog_Message" runat="server"
				Title="Displaying Publication Record:-"
				BackgroundCssClass="modalBackground"
				Style="display: none;"
				CssClass="modalPopup"
				EnableViewState="true">
				<ItemTemplate>
					<ul>
						<li>
							<asp:Label ID="lbl_TheMessage" runat="server" Text="'" Visible="false" />
						</li>
					</ul>
					<ul id="DialogBoxUL">
						<li class="FLabel">Type:</li>
						<li class="FValue">
							<asp:Label ID="LabelType" runat="server" Text=""></asp:Label>.
						</li>

						<li class="FLabel">Title:</li>
						<li class="FValue">
							<asp:Label ID="LabelTitle" runat="server" Text=""></asp:Label>
						</li>

						<li class="FLabel">Publication Date:</li>
						<li class="FValue">
							<asp:Label ID="LabelDate" runat="server" Text=""></asp:Label>.
						</li>


						<li class="FLabel">Display Till</li>
						<li class="FValue">
							<asp:Label ID="LabelDisplayTill" runat="server" Text=""></asp:Label>.
						</li>


						<li class="FLabel">Description</li>
						<li class="FValue">
							<asp:Label ID="LabelDesc" runat="server" Text=""></asp:Label>.
						</li>


						<li class="FLabel">Uploaded File</li>
						<li class="FValue">
							<asp:HyperLink runat="server" ID="lnkPage" NavigateUrl="#">Click here to download</asp:HyperLink>

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

			<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
				<ProgressTemplate>
					Please wait image is getting uploaded....
				</ProgressTemplate>
			</asp:UpdateProgress>
		</ContentTemplate>

	</asp:UpdatePanel>
</asp:Content>
