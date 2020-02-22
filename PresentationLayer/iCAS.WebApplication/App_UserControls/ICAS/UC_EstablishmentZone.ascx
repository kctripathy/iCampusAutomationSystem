<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_EstablishmentZone.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.ICAS.UC_EstablishmentZone" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<asp:UpdatePanel ID="updatePanel_Estb" runat="server" UpdateMode="Conditional">
	<ContentTemplate>
		<%--<script type="text/javascript">
            $(document).ready(function () {
                $("#ctrl_EstablishmentZone1_LoadingDiv").css("display", "block");

                var apiUrl = '<%=ConfigurationManager.AppSettings["WebServerIP"].ToString() %>';
                apiUrl = "http://" + apiUrl + "/api/Establishment";
                //alert(apiUrl);
                //debugger
                $.ajax({
                    type: "GET",
                    url: apiUrl,
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        LoadFirstNews(result);
                        $("#displayFirstNewsLi").css("display", "none");
                    },
                    error: function () {
                        //alert("Error loading data! Please try again.");
                    }
                });

                $("#ctrl_EstablishmentZone1_LoadingDiv").css("display", "none");
                function LoadFirstNews(result) {
                    //alert('LoadFirstNews()' + result);
                }


            });
        </script>--%>
		<style type="text/css">
			#EstblmntZone
			{
				background-color: white;
			}

			.EstbDateClass
			{
				width: 17%;
				font-size: 0.9em;
			}

			.EstbTitleZoneClass
			{
				width: 80%;
				font-size: 0.9em;
				cursor: zoom-in;
				text-wrap:none;
				color: blue;
			}

			.EstbViewIconClass
			{
				height: 22px;
				width: 22px;
				margin: 1px;
				padding: 1px;
				cursor: zoom-in;
			}
		</style>
		<div id="EstblmntZone">
			<ul>
				<li class="UCTitleEstb">
					<asp:RadioButtonList runat="server" ID="radioList_Estb" RepeatDirection="Horizontal" AutoPostBack="true"
						OnSelectedIndexChanged="radioList_Estb_SelectedIndexChanged"
						CssClass="radioboxlist">
						<asp:ListItem Text="View All" Value="A" />
						<asp:ListItem Text="Notices" Value="N" />
						<asp:ListItem Text="Tenders" Value="T" />
						<asp:ListItem Text="Syllabuses" Value="S" />
						<asp:ListItem Text="Recent Activities" Value="R" />
					</asp:RadioButtonList>
				</li>
				<li id="displayGridNewsLi">
					<asp:GridView ID="gridViewEstb" runat="server"
						AutoGenerateColumns="false"
						AllowPaging="true"
						PageSize="7"
						Width="100%"
						OnRowCommand="gridViewEstb_RowCommand"
						OnPageIndexChanging="gridViewEstb_PageIndexChanging">
						<Columns>
							<asp:TemplateField ItemStyle-CssClass="EstbViewIconClass" ControlStyle-CssClass="EstbViewIconClass">
								<ItemTemplate>
									<asp:ImageButton ID="DownloadButton" Text="Download" runat="server"
										ImageUrl="~/Images/Glossary/ViewDetails.gif"
										CommandName="ViewEstablishment"
										CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
										ToolTip='Please click here to read this record details and/or download the attached file.'></asp:ImageButton>
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Date" ControlStyle-CssClass="EstbDateClass" ItemStyle-CssClass="EstbDateClass">
								<ItemTemplate>
									<asp:Literal ID="lit_EstbID" runat="server" Visible="False" Text='<%# Eval("EstbId") %>'></asp:Literal>
									<asp:Literal ID="lit_Date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EstbDate", "{0:dd-MMM-yy}") %>'></asp:Literal>
									<%--<asp:Literal ID="lit_Title" runat="server" Text='<%# Eval("EstbTitleZone").ToString().Length >= 80? (Eval("EstbTitleZone").ToString().Substring(0,79) + "......") : (Eval("EstbTitleZone").ToString()) %>'></asp:Literal>--%>
								</ItemTemplate>
							</asp:TemplateField>

							<asp:HyperLinkField
								HeaderText="Title:"
								DataTextField="EstbTitleZone"
								DataNavigateUrlFields="FileNameWithPath"
								HeaderImageUrl="~/Images/Glossary/pdf1.gif"
								DataNavigateUrlFormatString="~/Documents/{0}"
								Target="_blank"
								ControlStyle-CssClass="EstbTitleZoneClass" ItemStyle-CssClass="EstbTitleZoneClass" />


						</Columns>
						<HeaderStyle CssClass="gridViewEstbHeaderStyle" />
						<RowStyle CssClass="gridViewEstbRowStyle" />
						<PagerStyle CssClass="MicroPagerStyle" />
					</asp:GridView>
				</li>
			</ul>
		</div>

		<IAControl:DialogBox ID="dialog_Message"
			runat="server" Title="Display Establishment:"
			Height="300px"
			BackgroundCssClass="modalBackground"
			Style="display: none;"
			CssClass="modalPopupEstablishment" EnableViewState="true">
			<ItemTemplate>
				<asp:Literal runat="server" ID="lit_DialogMessageDetails" />

			</ItemTemplate>
		</IAControl:DialogBox>

		<asp:UpdateProgress runat="server" ID="PageUpdateProgress">
			<ProgressTemplate>
				<div id="UpdateProgress">
					<div class="UpdateProgressArea">
						<ul id="UpdateProgressEstablishment">
							<li>
								Processing the request....Please wait a while! 
							</li>
						</ul>
					</div>
				</div>
			</ProgressTemplate>
		</asp:UpdateProgress>
	</ContentTemplate>
</asp:UpdatePanel>
