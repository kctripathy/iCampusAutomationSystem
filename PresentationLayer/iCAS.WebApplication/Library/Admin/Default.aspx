<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TCon.iCAS.WebApplication.Library.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
        #LibraryAdminZone {
            display: block;
            float: left;
            width: 100%;
            margin: 5px 0px;
            padding: 5px;
            background-color: #2fa4e7;
        }

        .BooksAdminBox1 {
            background: #0898ea;
            width: 100%;
            padding: 7px;
            margin: 0px 0px 0px -15px;
        }

        .BooksAdminBox2 {
            background-color: transparent;
            width: 100%;
            padding: 3px;
            margin: 0px 0px 0px 5px;
        }

        .BooksAdminBox3 {
            background: #0898ea;
            width: 100%;
            padding: 7px;
            margin: 0px 0px 0px 5px;
        }
        .BooksAdminBox4 {
            background: #b6ff00;
            color: black;
            width: 100%;
            padding: 7px;
            margin: 0px 0px 0px 5px;
        }




        #LibraryAdminZone > div > a {
            transition: all 0.7s ease;
            text-decoration: none;
            font-size: 1.1em;
            text-shadow: 1px 2px 1px #1e1ee4;
            font-weight: bold;
            color: whitesmoke;
            display: block;
            float: left;
            width: 100%;
            text-align: center;
        }

            #LibraryAdminZone > div > a:hover {
                transition: all 0.7s ease;
                text-decoration: none;
                font-size: 1.1em;
                text-shadow: 1px 2px 1px #1e1ee4;
                font-weight: bold;
                background-color: whitesmoke;
                color: darkblue;
                display: block;
                float: left;
                width: 100%;
                text-align: center;
            }

        @media only screen and (max-device-width: 480px) {

            #LibraryZone {
                display: block;
                float: left;
                width: 100%;
                margin: 0;
                padding: 0;
                margin-left: -4%;
                margin-right: -2%;
            }
        }
    </style>
    <div id="LibraryAdminZone">
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Library/Admin/Books.aspx" class="BooksAdminBox BooksAdminBox1">BOOKS MASTER FILE</a>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Library/BookIssue.aspx" class="BooksAdminBox BooksAdminBox2">ISSUE A BOOOK</a>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Library/BookReturn.aspx" class="BooksAdminBox BooksAdminBox3">RETRUN A BOOK</a>
        </div>
        <div class="col-lg-3  col-md-3 col-sm-12 col-xs-12">
            <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Library/BookCategories.aspx" class="BooksAdminBox BooksAdminBox4">CATEGORY MANAGEMENT</a>
        </div>
    </div>
</asp:Content>
