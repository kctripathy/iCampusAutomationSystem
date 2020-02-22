<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="Error500.aspx.cs" Inherits="Micro.WebApplication.App_Error.Error500" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="innercontent">
        <h1 class="PageTitle">Error 500!</h1>
        <br />

        <ul>
            <li>Sorry, an error occured while execution of the application.</li>
            <li>Please <a href="#l" style="color:#ff0000; cursor: text; font-size:11pt;" onclick="javascript:ErrorPanel.style.display='';">click here</a> to know about the details about the Error.
                <br />
                or
                <br />
                <asp:Literal ID="lit_ErrorMessage" runat="server" Text=" "></asp:Literal></li>
            <li>You can go back to <asp:HyperLink ID="LinkHome1" runat="server" NavigateUrl="~/Default.aspx">home page</asp:HyperLink> or  <a href="#l" onclick="javascript:ReLoadPage();">try again to load the page</a>. </li>
        </ul>
        <div id="ErrorPanel" class="fontsize" style="display: none;">
            <u><b>Error Description</b></u><br /><br />
            <b>Date :</b><asp:Label ID="LabelTime" runat="server" /><br />
            <b>Reason:</b><asp:Label ID="lbl_Reason" runat="server" Text="untracable"  /><br />
            <b>Page :</b><asp:Label ID="LabelErrorPage" runat="server" /><br />
            <b>Message :</b><asp:Label ID="LabelError" runat="server" /><br />
            <b>Target :</b><asp:Label ID="LabelTarget" runat="server" /><br />
        </div>
    </div>
    <script type="text/javascript">
        function ReLoadPage() {
            var RedirectPage = "<%=RedirectPage%>";

            var myDate = new Date();
            var token = '' + myDate.getSeconds() + myDate.getFullYear() + myDate.getHours() + myDate.getDate() + myDate.getMinutes() + myDate.getMonth();

            if (RedirectPage.indexOf('?') == -1) {
                RedirectPage = RedirectPage + '?T=' + token;
            }
            else {
                RedirectPage = RedirectPage + '&T=' + token;
            }

            window.location.href = RedirectPage;
        }
    </script>
</asp:Content>
