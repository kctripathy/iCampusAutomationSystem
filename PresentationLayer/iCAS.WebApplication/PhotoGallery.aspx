<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="PhotoGallery.aspx.cs" Inherits="TCon.iCAS.WebApplication.PhotoGallery" %>

<%@ Register src="App_UserControls/ICAS/UC_PhotoGallery.ascx" tagname="UC_PhotoGallery" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" media="all" href="css/styles.css" />
    <link rel="stylesheet" type="text/css" media="all" href="css/jquery.lightbox-0.5.css" />
    <script type="text/javascript" src="js/jquery-1.10.1.min.js"></script>
    <script type="text/javascript" src="js/jquery.lightbox-0.5.min.js"></script>


    <div id="w">
        <div id="content">
            <uc1:UC_PhotoGallery ID="UC_PhotoGallery1" runat="server" />
        </div>
        <!-- @end #content -->
    </div>
    <!-- @end #w -->
    <script type="text/javascript">
        $(function () {
            $('#thumbnails a').lightBox();
        });
    </script>

</asp:Content>
