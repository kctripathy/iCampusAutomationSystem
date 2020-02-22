<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_LibraryZone.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.ICAS.UC_LibraryZone" %>
<style type="text/css">
    #LibraryZone {
        display: block;
        float: left;
        width: 98%;
        margin: 1%;
        padding: 1%;
        /*background-image: linear-gradient(#54b4eb, #2fa4e7 60%, #1d9ce5);*/
        background-image: linear-gradient(#04519b, #044687 60%, #033769);
		background-repeat: no-repeat;
    }

    .eLibraryBox1 {
        width:100%;
        padding: 0px;
        margin: 0px;
    }
     .AdminBox1 {
        width:100%;
        padding: 0px;
        margin: 0px;
    }

      .AlumniBox1 {
        width:100%;
        padding: 0px;
        margin: 0px;
    }

     
  

    #LibraryZone > div > a {
        transition: all 0.7s ease;
        text-decoration: none;
        font-size:1em;
        /*text-shadow: 1px 2px 1px #1e1ee4;*/
        font-weight:normal;
        color: white;
        display: block;
        float: left;
        width:100%;
        text-align:center;
        margin: 2px 0px;
        padding: 4px 0px;
    }

     #LibraryZone > div > a:hover {
        transition: all 0.7s ease;
        text-decoration: none;
        font-size:1em;
        /*text-shadow: 1px 2px 1px #1e1ee4;*/
        font-weight:bold;
        background-color:whitesmoke;
        color: navy;
        display: block;
        float: left;
        width:100%;
        text-align:center;
        margin: 2px 0px;
        padding: 4px 0px;
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
<div id="LibraryZone">
    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Library/Books.aspx">TSD College Library</a>
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Publications.aspx" class="eLibraryBox1" >Research & Publications </a>
        <a href="hhttp://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/StaffResearchPublications.aspx" class="eLibraryBox1" >Books/Study Materials</a>
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/photo-gallery" class="eLibraryBox1">Photo Gallery</a>
    </div>
    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/apps/icas/estblmt/default.aspx" class="AdminBox1" >Recent Activities</a>
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/AdminAuditActivities.aspx" class="AdminBox2" >Audit Activities</a>
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/AdminWorldBank.aspx" class="AdminBox1" >World Bank Assisted OHEPEE Project</a>
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/MinutesOfMeetings.aspx" class="AdminBox1" >MinutesOfMeetings</a>
        
    </div>
    <div class="col-lg-4  col-md-4 col-sm-12 col-xs-12">
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Alumni.aspx" class="AlumniBox1" >Online Alumni Registration</a>
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Alumni.aspx" class="AlumniBox1" >Download Registration Form</a>
        <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Alumni.aspx" class="AlumniBox1" >Alumni/ex-Students List</a>
         <a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Alumni.aspx" class="AlumniBox1" >Search an Alumni</a>
    </div>
</div>
