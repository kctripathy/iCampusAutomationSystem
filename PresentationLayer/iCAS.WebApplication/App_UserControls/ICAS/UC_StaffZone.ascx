<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_StaffZone.ascx.cs" Inherits="LTPL.ICAS.WebApplication.App_UserControls.ICAS.UC_StaffZone" %>

<div id="StaffZone" class="col-md-6">
	<ul>
		<li class="WebpartTitle">
			Staffs Zone :
			<asp:Literal runat="server" ID="lit_Welcome" Text="" />
		</li>
		<li class="StaffZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/principals-list">Succession List of Principals</a>
		</li>
		<li class="StaffZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/Publications.aspx">Publications</a>
		</li>
		<li class="StaffZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/icas/staffs.aspx"><span class="glyphicons glyphicons-group"></span>List of College Staffs</a>
		</li>
		<li class="StaffZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-staff-achievements">Staff Achievements</a>
		</li>
		<li class="StaffZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-staff-associations">Staff Associations</a>
		</li>
		<li class="StaffZoneLink">
			<a href="http://<%=ConfigurationManager.AppSettings["WebServerIP"] %>/about-staffdistributioncurricularactivities">Extra Curriculars</a>
		</li>
	</ul>
</div>
