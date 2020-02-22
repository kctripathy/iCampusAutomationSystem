<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LibraryBooks.ascx.cs" Inherits="TCon.iCAS.WebApplication.App_UserControls.ICAS.UC_LibraryBooks" %>
<%@ Register Assembly="Micro.Commons" Namespace="Micro.Commons" TagPrefix="IAControl" %>

<script type="text/javascript">
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
</script>
<style type="text/css">
    #LibraryBooksLoadingDiv
    {
    }

    #LibraryBooksDiv
    {
    }

    @media only screen and (max-device-width: 480px)
    {
        #LibraryBooksLoadingDiv
        {
        }

        #LibraryBooksDiv
        {
        }
    }
</style>
<div id="LibraryBooksLoadingDiv" runat="server">
    <h5>Loading library books...</h5>
    <img src="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Images/lightbox-ico-loading.gif" />
</div>
<div id="LibraryBooksDiv">
    <ul>
        <li>
            <asp:GridView ID="gridViewEstb" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gridViewEstb_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="ItemStyle_DT">
                        <ItemTemplate>
                            <asp:Literal ID="lit_Date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EstbDate", "{0:dd-MMM}") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" ItemStyle-CssClass="ItemStyle_Title">
                        <ItemTemplate>
                            <asp:Literal ID="lit_Title" runat="server" Text='<%# Eval("EstbTitleZone").ToString().Length >= 60? (Eval("EstbTitleZone").ToString().Substring(0,59) + "...more") : (Eval("EstbTitleZone").ToString()) %>'></asp:Literal>
                            <asp:Literal ID="lit_EstbID" runat="server" Visible="False" Text='<%# Eval("EstbId") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="ItemStyle_Icon">
                        <ItemTemplate>
                            <asp:Button ID="ViewButton" runat="server"
                                CommandName="ViewEstablishment"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="View" CssClass="btn btn-success btn-xs" ToolTip='View This Information'></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="gridViewEstbHeaderStyle" />
                <RowStyle CssClass="gridViewEstbRowStyle" />
            </asp:GridView>
        </li>
    </ul>
</div>
<IAControl:DialogBox ID="dialog_Message" runat="server" Title="ESTABLISHMENT:" BackgroundCssClass="modalBackground" Style="display: none" CssClass="modalPopupEstablishment" EnableViewState="true">
    <ItemTemplate>
        <ul id="LibraryBookDetailDiv">
            <li>
                <h1 class="PageTitle">
                    <asp:Literal runat="server" ID="lit_BookDetailLabel" Text="Book Details for: " />
                </h1>
            </li>
        </ul>
    </ItemTemplate>
</IAControl:DialogBox>
