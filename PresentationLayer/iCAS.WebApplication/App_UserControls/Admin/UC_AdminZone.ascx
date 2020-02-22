<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_AdminZone.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.Admin.UC_AdminZone" %>
<style type="text/css">
    #TwoZones {
        display: block;
        list-style-type: none;
        margin: 0;
        padding: 0;
        width: 100%;
        min-height: 145px;
    }

    .zone1 {
        display: block;
        float: left;
        width: 88%;
    border: solid 1px #ccc;
    background-color: lightgreen;
    margin: 2px 2px 3px 0px;
    height: 23px;
    padding: 10px;
    }

    #zone2 {
        display: block;
        float: left;
        width: 100%;
        border: solid 1px green;
        margin: 0 0 5px 0;
        height: 71px;
    }

    .zone1 a {
        text-decoration: none;
        text-align: center;
        color: green;
    }

        .zone1 a:hover {
            text-decoration: none;
            font-size: 17px;
            text-align: center;
            color: red;
        }

        .green1
        {
            background-color: lightgreen
        }
        .yellow1
        {
            background-color: lightyellow;
        }
        .blue1
        {
            background-color: lightblue;
        }
</style>
<div id="AlumniZone">
    <ul id="TwoZones">
        <li class="zone1 green1">
            <a href="http://alumni.tsdcollege.in/About/AlumniAssociation" class="OHEPEE"><b>World Bank Assisted OHEPEE Project</b></a>
        </li>
        <li class="zone1 blue1 pink1">
             <a href="http://alumni.tsdcollege.in/About/AlumniAssociation" class="OHEPEE"><b>Governing Body</b></a>
        </li>
        <li class="zone1 yellow1">
             <a href="http:/lib.tsdcollege.in" target="_blank" class="OHEPEE"><b>ONLINE COLLEGE LIBRARY</b></a>
        </li>
    </ul>
    <%--<ul >
        <li class="WebpartTitle">
            <div id="WebpartTitleAlumni" />
        </li>
        <li class="AlumniZoneLink">
            <a href="http://alumni.tsdcollege.in/About/AlumniAssociation" target="_blank">Association</a>
        </li>
         <li class="AlumniZoneLink">
            <a href="#">Activities</a>
        </li>
      
         <li class="AlumniZoneLink">
            <a href="#" target="_blank">Achievements</a>
        </li>
         <li class="AlumniZoneLink">
            <a href="/Alumni.aspx?Operation=View" target="_blank">Alumni List</a>
        </li>
         <li class="StaffZoneLink100">
             <a href="/Alumni.aspx"><b>Online Registration</b></a><br />
            <a href="/Downloads/AlumniRegistrationForm.rar" target="_blank"><img src='/Images/pdf.gif' />&nbsp;Download Registration Form</a>             
        </li>         
    </ul>--%>
</div>
