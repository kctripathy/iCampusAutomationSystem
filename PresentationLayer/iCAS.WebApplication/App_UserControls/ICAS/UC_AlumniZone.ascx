<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_AlumniZone.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.ICAS.UC_AlumniZone" %>
<style type="text/css">
	@media only screen and (max-device-width: 480px) {
		#AlumniZone {
			display: block;
			float: left;
			width: 108%;
			margin: 0;
			padding: 4%;
			margin-left: -4%;
			margin-right: -2%;
		}
	}
</style>
<div id="AlumniZone">
	<ul>
		<li class="WebpartTitle">
			<div id="WebpartTitleAlumni" />
		</li>
		 <%-- <li class="StaffZoneLink100">
            <a href="about-alumni-association" target="_blank">Association</a>
        </li>
        <li class="StaffZoneLink100">
            <a href="#">Activities</a>
        </li>
     
         <li class="AlumniZoneLink">
            <a href="#" target="_blank">Achievements</a>
        </li>--%>
		<li class="StaffZoneLink100">
			<%--<a href="/Alumni.aspx?Operation=View" target="_blank">Alumni List</a>--%>
			<a href="/Alumni.aspx"><b>Online Registration</b></a><br />
		</li>
		<li class="StaffZoneLink100">

			<a href="/Downloads/AlumniRegistrationForm.pdf" target="_blank"> <i class="fa fa-cloud-download" aria-hidden="true"></i>&nbsp;Registration Form</a>

		</li>
		<%--<li class="WebpartSubTitle">Alumni Sub-Zone1</li>
        
         <li class="AlumniZoneLink">
            <a href="#">AlumniZoneLink 1</a>
        </li>
         <li class="AlumniZoneLink">
            <a href="#">AlumniZoneLink 2</a>
        </li>
         <li class="WebpartSubTitle">Alumni Sub-Zone2</li>
        <li class="AlumniZoneLink">
            <a href="#">AlumniZoneLink 1</a>
        </li>
         <li class="AlumniZoneLink">
            <a href="#">AlumniZoneLink 2</a>
        </li>--%>
         
	</ul>
</div>
